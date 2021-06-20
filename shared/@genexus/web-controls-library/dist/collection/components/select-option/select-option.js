import { BaseComponent } from "../common/base-component";
export class SelectOption extends BaseComponent {
    constructor() {
        super(...arguments);
        /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
        this.disabled = false;
    }
    selectedChanged(isSelected) {
        if (isSelected) {
            this.gxSelect.emit({ select: this });
        }
    }
    disabledChanged(isDisabled) {
        if (isDisabled) {
            this.gxDisable.emit({ select: this });
        }
    }
    valueChanged() {
        this.onChange.emit({ select: this });
    }
    componentDidLoad() {
        this.gxSelectDidLoad.emit({ select: this });
    }
    componentDidUnload() {
        this.gxSelectDidUnload.emit({ select: this });
    }
    hostData() {
        return {
            "aria-hidden": "true",
            hidden: true
        };
    }
    render() {
        return h("slot", null);
    }
    static get is() { return "gx-select-option"; }
    static get properties() { return {
        "cssClass": {
            "type": String,
            "attr": "css-class"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled",
            "watchCallbacks": ["disabledChanged"]
        },
        "selected": {
            "type": Boolean,
            "attr": "selected",
            "mutable": true,
            "watchCallbacks": ["selectedChanged"]
        },
        "value": {
            "type": String,
            "attr": "value",
            "mutable": true,
            "watchCallbacks": ["valueChanged"]
        }
    }; }
    static get events() { return [{
            "name": "onChange",
            "method": "onChange",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "gxSelect",
            "method": "gxSelect",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "gxDisable",
            "method": "gxDisable",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "gxSelectDidLoad",
            "method": "gxSelectDidLoad",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "gxSelectDidUnload",
            "method": "gxSelectDidUnload",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
}
