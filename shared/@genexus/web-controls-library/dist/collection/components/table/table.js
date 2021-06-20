import { BaseComponent } from "../common/base-component";
export class Table extends BaseComponent {
    constructor() {
        super(...arguments);
        /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
        this.invisibleMode = "collapse";
        /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
        this.disabled = false;
    }
    // TODO: Implement touch devices events (Tap, DoubleTap, LongTap, SwipeX)
    handleClick(event) {
        if (this.disabled) {
            return;
        }
        this.onClick.emit(event);
    }
    render() {
        if (this.areasTemplate) {
            // tslint:disable-next-line
            this.element.style["gridTemplateAreas"] = this.areasTemplate;
        }
        if (this.columnsTemplate) {
            // tslint:disable-next-line
            this.element.style["gridTemplateColumns"] = this.columnsTemplate;
        }
        if (this.rowsTemplate) {
            // tslint:disable-next-line
            this.element.style["gridTemplateRows"] = this.rowsTemplate;
        }
        this.element.addEventListener("click", this.handleClick.bind(this));
        return h("slot", null);
    }
    static get is() { return "gx-table"; }
    static get properties() { return {
        "areasTemplate": {
            "type": String,
            "attr": "areas-template"
        },
        "columnsTemplate": {
            "type": String,
            "attr": "columns-template"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled"
        },
        "element": {
            "elementRef": true
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "rowsTemplate": {
            "type": String,
            "attr": "rows-template"
        }
    }; }
    static get events() { return [{
            "name": "onClick",
            "method": "onClick",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-table:**/"; }
}
