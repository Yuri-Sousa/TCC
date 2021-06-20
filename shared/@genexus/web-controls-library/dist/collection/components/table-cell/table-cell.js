import { BaseComponent } from "../common/base-component";
export class TableCell extends BaseComponent {
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
        if (this.element) {
            if (this.area) {
                // tslint:disable-next-line
                this.element.style["gridArea"] = this.area;
            }
        }
        return h("slot", null);
    }
    static get is() { return "gx-table-cell"; }
    static get properties() { return {
        "align": {
            "type": String,
            "attr": "align"
        },
        "area": {
            "type": String,
            "attr": "area"
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
    static get style() { return "/**style-placeholder:gx-table-cell:**/"; }
}
