import { BaseComponent } from "../common/base-component";
export class Canvas extends BaseComponent {
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
        this.element.addEventListener("click", this.handleClick.bind(this));
        return h("slot", null);
    }
    static get is() { return "gx-canvas"; }
    static get properties() { return {
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
        }
    }; }
    static get events() { return [{
            "name": "onClick",
            "method": "onClick",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-canvas:**/"; }
}
