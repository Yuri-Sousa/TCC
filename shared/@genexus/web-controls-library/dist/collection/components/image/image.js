import { BaseComponent } from "../common/base-component";
export class Image extends BaseComponent {
    constructor() {
        super(...arguments);
        /**
         * This attribute lets you specify the alternative text.
         */
        this.alt = "";
        /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
        this.disabled = false;
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
         * This attribute lets you specify the low resolution image SRC.
         */
        this.lowResolutionSrc = "";
        /**
         * This attribute lets you specify the SRC.
         */
        this.src = "";
    }
    handleClick(event) {
        if (this.disabled) {
            return;
        }
        this.onClick.emit(event);
        event.preventDefault();
    }
    render() {
        const body = (h("img", { class: this.cssClass, onClick: this.handleClick.bind(this), src: this.src, alt: this.alt ? this.alt : "", 
            // title={this.title}
            width: this.width, height: this.height }));
        return body;
    }
    static get is() { return "gx-image"; }
    static get properties() { return {
        "alt": {
            "type": String,
            "attr": "alt"
        },
        "cssClass": {
            "type": String,
            "attr": "css-class"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled"
        },
        "height": {
            "type": String,
            "attr": "height"
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "lowResolutionSrc": {
            "type": String,
            "attr": "low-resolution-src"
        },
        "src": {
            "type": String,
            "attr": "src"
        },
        "width": {
            "type": String,
            "attr": "width"
        }
    }; }
    static get events() { return [{
            "name": "onClick",
            "method": "onClick",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-image:**/"; }
}
