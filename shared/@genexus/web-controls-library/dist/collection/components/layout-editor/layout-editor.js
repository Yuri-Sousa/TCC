import Dragula from "dragula";
import controlResolver from "./layout-editor-control-resolver";
import { findParentCell, getCellData, getControlId, getDropTargetData, isEmptyContainerDrop } from "./layout-editor-helpers";
export class LayoutEditor {
    constructor() {
        /**
         * Array with the identifiers of the selected control's cells. If empty the whole layout-editor is marked as selected.
         */
        this.selectedCells = [];
        this.dragulaOptions = {
            accepts: (el, target) => {
                return !el.contains(target) && el.parentNode !== target;
            },
            copy: true,
            direction: "horizontal"
        };
        this.ignoreDragulaDrop = false;
    }
    // private ignoreFocus = false;
    componentDidLoad() {
        this.initDragAndDrop();
        this.element.addEventListener("keydown", this.handleKeyDown.bind(this));
        this.element.addEventListener("click", this.handleClick.bind(this));
    }
    componentWillUpdate() {
        this.restoreAfterDragDrop();
    }
    handleKeyDown(event) {
        const target = event.target;
        const { cellId } = getCellData(target);
        if (cellId) {
            switch (event.key) {
                case "Delete":
                    this.handleDelete();
                    break;
                case " ":
                    this.handleSelection(event.target, event.ctrlKey);
                    event.preventDefault();
                    break;
            }
        }
    }
    handleDelete() {
        this.controlRemoved.emit({
            cellIds: this.selectedCells.join(",")
        });
    }
    initDragAndDrop() {
        this.drake = Dragula(this.getDropAreas(), this.dragulaOptions);
        this.drake.on("shadow", (el, container) => {
            const { dropArea: direction } = getCellData(container);
            // Update dragula's direction dynamically according to the direction
            // stated at the `data-gx-le-drop-area` attribute
            this.dragulaOptions.direction = direction;
            const position = container.children.length === 1
                ? "empty"
                : el.nextElementSibling
                    ? direction === "vertical" ? "top" : "left"
                    : direction === "vertical" ? "bottom" : "right";
            container.setAttribute("data-gx-le-active-target", position);
        });
        this.drake.on("out", (...parms) => {
            const [, container] = parms;
            container.removeAttribute("data-gx-le-active-target");
        });
        this.drake.on("drag", () => {
            this.element.setAttribute("data-gx-le-dragging", "");
        });
        this.drake.on("dragend", () => {
            this.element.removeAttribute("data-gx-le-dragging");
        });
        // Drop of controls that were already part of the layout
        this.drake.on("drop", this.handleMoveElementDrop.bind(this));
        // Drop of controls from outside of the editor (e.g. GeneXus' toolbox)
        this.element.addEventListener("drop", this.handleExternalElementDrop.bind(this));
        this.element.addEventListener("dragover", this.handleExternalElementOver.bind(this));
        this.element.addEventListener("dragend", () => {
            // End Dragula's drag operation
            this.drake.end();
        });
    }
    handleMoveElementDrop(droppedEl, target, source) {
        const targetCell = target;
        if (this.ignoreDragulaDrop) {
            return;
        }
        if (!targetCell) {
            return;
        }
        if (source.getAttribute("data-gx-le-external") !== null) {
            return;
        }
        this.ddDroppedEl = droppedEl;
        const { rowId: sourceRowId, cellId: sourceCellId } = getCellData(source);
        // Retrieve the drop event data before cancelling dragula's default drop behavior
        const eventData = this.getEventDataForDropAction(targetCell, droppedEl);
        // After retreiving the drop event data, the dragula drop action can be reverted, so we don't
        // mess with the element's DOM and let the user update the DOM by changing the model property
        this.drake.cancel(true);
        this.moveCompleted.emit(Object.assign({}, eventData, { sourceCellId,
            sourceRowId }));
    }
    handleExternalElementOver(event) {
        function triggerMouseEvent(node, eventType) {
            const clickEvent = new MouseEvent(eventType, {
                altKey: event.altKey,
                bubbles: true,
                button: event.button,
                buttons: event.buttons,
                cancelable: true,
                clientX: event.clientX,
                clientY: event.clientY,
                ctrlKey: event.ctrlKey,
                metaKey: event.metaKey,
                relatedTarget: event.relatedTarget,
                screenX: event.screenX,
                screenY: event.screenY,
                shiftKey: event.shiftKey,
                view: window
            });
            node.dispatchEvent(clickEvent);
        }
        const item = this.element.querySelector("[data-gx-le-external-transit]");
        // Enter Dragula's drag mode programatically
        this.drake.start(item);
        event.preventDefault();
        // Simulate a mousedown and a mousemove to trick Dragula into starting
        // its drag operation with the item being dragged, even though it didn't
        // originally come from a registered Dragula container.
        setTimeout(() => {
            triggerMouseEvent(item, "mousedown");
            setTimeout(() => {
                triggerMouseEvent(document.documentElement, "mousemove");
            }, 100);
        }, 100);
        return false;
    }
    handleExternalElementDrop(event) {
        let eventData;
        const evtTarget = event.target;
        const targetCell = findParentCell(evtTarget) || evtTarget;
        const el = targetCell.querySelector("[data-gx-le-external-transit]");
        this.ignoreDragulaDrop = true;
        this.drake.end();
        this.ignoreDragulaDrop = false;
        this.ddDroppedEl = el;
        eventData = this.getEventDataForDropAction(targetCell, el);
        const evtDataTransfer = event.dataTransfer.getData("text");
        const evtDataArr = evtDataTransfer ? evtDataTransfer.split(",") : [];
        if (evtDataArr.length === 1) {
            this.controlAdded.emit(Object.assign({}, eventData, { kbObjectName: evtDataArr[0] }));
        }
        else if (evtDataArr.length === 2 &&
            evtDataArr[0] === "GX_DASHBOARD_ADDELEMENT") {
            this.controlAdded.emit(Object.assign({}, eventData, { elementType: evtDataArr[1] }));
        }
    }
    getEventDataForDropAction(targetCell, droppedEl) {
        let eventData;
        const { placeholderType, nextRowId } = getDropTargetData(targetCell);
        if (placeholderType === "row") {
            if (isEmptyContainerDrop(targetCell)) {
                // Dropped on an empty container
                eventData = {
                    containerId: getControlId(targetCell.parentElement)
                };
            }
            else {
                // Dropped on a new row
                const beforeRowId = nextRowId;
                if (beforeRowId) {
                    eventData = {
                        beforeRowId
                    };
                }
                else {
                    eventData = {
                        containerId: getControlId(targetCell.parentElement)
                    };
                }
            }
        }
        else {
            const { rowId: targetRowId } = getCellData(targetCell);
            // Dropped on an existing row
            if (targetCell.children.length === 1) {
                // Dropped on an empty cell
                const { cellId: targetCellId } = getCellData(targetCell);
                eventData = {
                    targetCellId
                };
            }
            else {
                // Dropped on a non-empty cell
                let beforeCellId = null;
                if (droppedEl.nextElementSibling) {
                    beforeCellId = getCellData(targetCell).cellId;
                }
                else {
                    if (targetCell.nextElementSibling) {
                        const nextElementData = getCellData(targetCell.nextElementSibling);
                        if (targetRowId === nextElementData.rowId) {
                            beforeCellId = nextElementData.cellId;
                        }
                    }
                }
                eventData = {
                    beforeCellId,
                    targetRowId
                };
            }
        }
        return eventData;
    }
    getDropAreas() {
        return Array.from(this.element.querySelectorAll("[data-gx-le-drop-area], [data-gx-le-placeholder]"));
    }
    restoreAfterDragDrop() {
        if (this.ddDroppedEl && this.ddDroppedEl.parentNode) {
            this.ddDroppedEl.parentNode.removeChild(this.ddDroppedEl);
        }
        this.ddDroppedEl = null;
        const activeTargets = Array.from(this.element.querySelectorAll("[data-gx-le-active-target]"));
        for (const target of activeTargets) {
            target.removeAttribute("data-gx-le-active-target");
        }
    }
    componentDidUpdate() {
        if (this.drake) {
            this.drake.containers = this.getDropAreas();
        }
    }
    componentDidUnload() {
        this.drake.destroy();
    }
    render() {
        if (this.model && this.model.layout) {
            const isSelected = this.selectedCells.find(id => id === "") === "";
            this.element.setAttribute("data-gx-le-selected", isSelected.toString());
            return (h("div", null,
                controlResolver(this.model.layout, {
                    selectedCells: this.selectedCells
                }),
                h("gx-layout-editor-placeholder", { "data-gx-le-external": true, "data-gx-le-placeholder": "row", style: {
                        display: "none"
                    } },
                    h("div", { "data-gx-le-external-transit": true }))));
        }
    }
    watchSelectedCells() {
        this.controlSelected.emit({
            cellIds: this.selectedCells.join(",")
        });
    }
    handleClick(event) {
        const target = event.target;
        this.handleSelection(target, event.ctrlKey);
        const selCell = findParentCell(target);
        if (selCell) {
            selCell.focus();
        }
    }
    handleSelection(target, add) {
        const selCell = findParentCell(target);
        if (selCell) {
            const { cellId: selectedCellId } = getCellData(selCell);
            this.updateSelection(selectedCellId, add);
        }
        else {
            this.updateSelection("", add);
        }
    }
    updateSelection(selectedCellId, add) {
        this.selectedCells = add
            ? [...this.selectedCells, selectedCellId]
            : [selectedCellId];
    }
    static get is() { return "gx-layout-editor"; }
    static get properties() { return {
        "element": {
            "elementRef": true
        },
        "model": {
            "type": "Any",
            "attr": "model"
        },
        "selectedCells": {
            "type": "Any",
            "attr": "selected-cells",
            "mutable": true,
            "watchCallbacks": ["watchSelectedCells"]
        }
    }; }
    static get events() { return [{
            "name": "moveCompleted",
            "method": "moveCompleted",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "controlAdded",
            "method": "controlAdded",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "controlRemoved",
            "method": "controlRemoved",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "controlSelected",
            "method": "controlSelected",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-layout-editor:**/"; }
}
// const MAIN_TABLE_IDENTIFIER = "1";
