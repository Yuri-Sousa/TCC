import { BaseComponent } from "../common/base-component";
import { MessageRender } from "../renders/bootstrap/message/message-render";
export class Message extends MessageRender(BaseComponent) {
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
    }
    componentDidLoad() {
        super.componentDidLoad();
    }
    static get is() { return "gx-message"; }
    static get properties() { return {
        "closeButtonText": {
            "type": String,
            "attr": "close-button-text"
        },
        "duration": {
            "type": Number,
            "attr": "duration"
        },
        "element": {
            "elementRef": true
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "showCloseButton": {
            "type": Boolean,
            "attr": "show-close-button"
        },
        "type": {
            "type": String,
            "attr": "type"
        }
    }; }
    static get style() { return "/**style-placeholder:gx-message:**/"; }
}
