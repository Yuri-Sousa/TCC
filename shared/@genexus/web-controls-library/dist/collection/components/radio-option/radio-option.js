import { BaseComponent } from "../common/base-component";
import { RadioOptionRender } from "../renders/bootstrap/radio-option/radio-option-render";
export class RadioOption extends RadioOptionRender(BaseComponent) {
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
    checkedChanged(isChecked) {
        super.checkedChanged(isChecked);
    }
    disabledChanged(isDisabled) {
        super.disabledChanged(isDisabled);
    }
    componentDidLoad() {
        this.gxRadioDidLoad.emit({ radio: this });
        super.componentDidLoad();
        this.nativeInput.checked = this.checked;
    }
    componentDidUnload() {
        this.gxRadioDidUnload.emit({ radio: this });
        super.componentDidUnload();
    }
    static get is() { return "gx-radio-option"; }
    static get properties() { return {
        "caption": {
            "type": String,
            "attr": "caption"
        },
        "checked": {
            "type": Boolean,
            "attr": "checked",
            "mutable": true,
            "watchCallbacks": ["checkedChanged"]
        },
        "cssClass": {
            "type": String,
            "attr": "css-class"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled",
            "watchCallbacks": ["disabledChanged"]
        },
        "element": {
            "elementRef": true
        },
        "id": {
            "type": String,
            "attr": "id"
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "name": {
            "type": String,
            "attr": "name"
        },
        "value": {
            "type": String,
            "attr": "value",
            "mutable": true
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
            "name": "gxRadioDidLoad",
            "method": "gxRadioDidLoad",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "gxRadioDidUnload",
            "method": "gxRadioDidUnload",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-radio-option:**/"; }
}
