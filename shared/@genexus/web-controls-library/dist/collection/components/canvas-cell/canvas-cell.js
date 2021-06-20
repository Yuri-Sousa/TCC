import { BaseComponent } from "../common/base-component";
export class CanvasCell extends BaseComponent {
    constructor() {
        super(...arguments);
        /**
         * Defines the horizontal aligmnent of the content of the cell.
         */
        this.align = "left";
        /**
         * Defines the vertical aligmnent of the content of the cell.
         */
        this.valign = "top";
    }
    render() {
        return h("slot", null);
    }
    static get is() { return "gx-canvas-cell"; }
    static get properties() { return {
        "align": {
            "type": String,
            "attr": "align"
        },
        "element": {
            "elementRef": true
        },
        "overflowMode": {
            "type": String,
            "attr": "overflow-mode"
        },
        "valign": {
            "type": String,
            "attr": "valign"
        }
    }; }
    static get style() { return "/**style-placeholder:gx-canvas-cell:**/"; }
}
