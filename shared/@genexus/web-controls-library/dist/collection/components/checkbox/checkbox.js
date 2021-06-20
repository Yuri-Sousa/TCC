import { BaseComponent } from "../common/base-component";
import { CheckBoxRender } from "../renders/bootstrap/checkbox/checkbox-render";
export class CheckBox extends CheckBoxRender(BaseComponent) {
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
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId() {
        return super.getNativeInputId();
    }
    checkedChanged() {
        super.checkedChanged();
    }
    static get is() { return "gx-checkbox"; }
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
            "attr": "disabled"
        },
        "element": {
            "elementRef": true
        },
        "getNativeInputId": {
            "method": true
        },
        "id": {
            "type": String,
            "attr": "id"
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        }
    }; }
    static get events() { return [{
            "name": "onChange",
            "method": "onChange",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-checkbox:**/"; }
}
