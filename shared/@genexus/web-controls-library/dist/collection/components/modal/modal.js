import { BaseComponent } from "../common/base-component";
import { ModalRender } from "../renders/bootstrap/modal/modal-render";
export class Modal extends ModalRender(BaseComponent) {
    constructor() {
        super(...arguments);
        /**
         * This attribute lets you specify if the modal dialog is opened or closed.
         */
        this.opened = false;
    }
    openedHandler(newValue, oldValue = false) {
        if (newValue === oldValue) {
            return;
        }
        if (newValue) {
            this.open();
        }
        else {
            this.close();
        }
    }
    static get is() { return "gx-modal"; }
    static get properties() { return {
        "autoClose": {
            "type": Boolean,
            "attr": "auto-close"
        },
        "closeButtonLabel": {
            "type": String,
            "attr": "close-button-label"
        },
        "element": {
            "elementRef": true
        },
        "opened": {
            "type": Boolean,
            "attr": "opened",
            "mutable": true,
            "watchCallbacks": ["openedHandler"]
        }
    }; }
    static get events() { return [{
            "name": "onClose",
            "method": "onClose",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "onOpen",
            "method": "onOpen",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-modal:**/"; }
}
