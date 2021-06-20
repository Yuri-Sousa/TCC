import { BaseComponent } from "../common/base-component";
export class TextBlock extends BaseComponent {
    constructor() {
        super(...arguments);
        /**
         * This attribute lets you specify an URL. If a URL is specified, the textblock acts as an anchor.
         */
        this.href = "";
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
    handleClick(event) {
        if (this.disabled) {
            return;
        }
        this.onClick.emit(event);
        event.preventDefault();
    }
    render() {
        const body = (h("div", { class: "content", onClick: this.handleClick.bind(this) },
            h("slot", null)));
        if (this.href) {
            return h("a", { href: this.href }, body);
        }
        return body;
    }
    static get is() { return "gx-textblock"; }
    static get properties() { return {
        "disabled": {
            "type": Boolean,
            "attr": "disabled"
        },
        "href": {
            "type": String,
            "attr": "href"
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
    static get style() { return "/**style-placeholder:gx-textblock:**/"; }
}
