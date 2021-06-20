export function findParentCell(el) {
    if (el.hasAttribute("data-gx-le-drop-area")) {
        return el;
    }
    while (el) {
        const parent = el.parentElement;
        if (parent && parent.hasAttribute("data-gx-le-drop-area")) {
            return parent;
        }
        el = parent;
    }
}
export function getCellData(el) {
    return {
        cellId: el.getAttribute("data-gx-le-cell-id"),
        dropArea: el.getAttribute("data-gx-le-drop-area"),
        rowId: el.getAttribute("data-gx-le-row-id")
    };
}
export function getDropTargetData(el) {
    return {
        nextRowId: el.getAttribute("data-gx-le-next-row-id"),
        placeholderType: el.getAttribute("data-gx-le-placeholder")
    };
}
export function isEmptyContainerDrop(el) {
    return (el.matches("gx-layout-editor-placeholder") &&
        el.parentElement &&
        el.parentElement.getAttribute("data-gx-le-container-empty") === "true");
}
export function getControlId(el) {
    return el.getAttribute("data-gx-le-control-id") || "";
}
