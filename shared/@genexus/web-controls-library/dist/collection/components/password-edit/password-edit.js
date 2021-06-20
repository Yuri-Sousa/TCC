import { BaseComponent } from "../common/base-component";
import { PasswordEditRender } from "../renders/bootstrap/password-edit/password-edit-render";
export class PasswordEdit extends PasswordEditRender(BaseComponent) {
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
        this.revealed = false;
    }
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId() {
        return super.getNativeInputId();
    }
    valueChanged() {
        super.valueChanged();
    }
    handleTriggerClick() {
        this.revealed = !this.revealed;
        super.handleTriggerClick();
    }
    static get is() { return "gx-password-edit"; }
    static get properties() { return {
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
        },
        "placeholder": {
            "type": String,
            "attr": "placeholder"
        },
        "readonly": {
            "type": Boolean,
            "attr": "readonly"
        },
        "revealButtonTextOff": {
            "type": String,
            "attr": "reveal-button-text-off"
        },
        "revealButtonTextOn": {
            "type": String,
            "attr": "reveal-button-text-on"
        },
        "revealed": {
            "state": true
        },
        "showRevealButton": {
            "type": Boolean,
            "attr": "show-reveal-button"
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
        }]; }
    static get listeners() { return [{
            "name": "gxTriggerClick",
            "method": "handleTriggerClick"
        }]; }
    static get style() { return "/**style-placeholder:gx-password-edit:**/"; }
}
