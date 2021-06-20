import { BaseComponent } from "../common/base-component";
import { EditRender } from "../renders/bootstrap/edit/edit-render";
export class Edit extends EditRender(BaseComponent) {
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
        /**
         * The type of control to render. A subset of the types supported by the `input` element is supported:
         *
         * * `"date"`
         * * `"datetime-local"`
         * * `"email"`
         * * `"file"`
         * * `"number"`
         * * `"password"`
         * * `"search"`
         * * `"tel"`
         * * `"text"`
         * * `"url"`
         */
        this.type = "text";
    }
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId() {
        return super.getNativeInputId();
    }
    componentDidLoad() {
        this.toggleValueSetClass();
    }
    valueChanged() {
        super.valueChanged();
        this.toggleValueSetClass();
    }
    toggleValueSetClass() {
        if (this.value === "") {
            this.element.classList.remove("value-set");
        }
        else {
            this.element.classList.add("value-set");
        }
    }
    static get is() { return "gx-edit"; }
    static get properties() { return {
        "area": {
            "type": String,
            "attr": "area"
        },
        "autocapitalize": {
            "type": String,
            "attr": "autocapitalize"
        },
        "autocomplete": {
            "type": String,
            "attr": "autocomplete"
        },
        "autocorrect": {
            "type": String,
            "attr": "autocorrect"
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
        },
        "multiline": {
            "type": Boolean,
            "attr": "multiline"
        },
        "placeholder": {
            "type": String,
            "attr": "placeholder"
        },
        "readonly": {
            "type": Boolean,
            "attr": "readonly"
        },
        "showTrigger": {
            "type": Boolean,
            "attr": "show-trigger"
        },
        "triggerText": {
            "type": String,
            "attr": "trigger-text"
        },
        "type": {
            "type": String,
            "attr": "type"
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
            "name": "onInput",
            "method": "onInput",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "gxTriggerClick",
            "method": "gxTriggerClick",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-edit:**/"; }
}
