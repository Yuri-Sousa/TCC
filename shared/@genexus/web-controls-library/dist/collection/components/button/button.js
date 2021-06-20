import { BaseComponent } from "../common/base-component";
import { ButtonRender } from "../renders/bootstrap/button/button-render";
export class Button extends ButtonRender(BaseComponent) {
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
         * (for example, click event). If a disabled image has been specified,
         * it will be shown, hiding the base image (if specified).
         */
        this.disabled = false;
        /**
         * This attribute lets you specify the relative location of the image to the text.
         *
         * | Value    | Details                                                 |
         * | -------- | ------------------------------------------------------- |
         * | `above`  | The image is located above the text.                    |
         * | `before` | The image is located before the text, in the same line. |
         * | `after`  | The image is located after the text, in the same line.  |
         * | `below`  | The image is located below the text.                    |
         * | `behind` | The image is located behind the text.                   |
         */
        this.imagePosition = "above";
        /**
         * This attribute lets you specify the size of the button.
         *
         * | Value    | Details                                                 |
         * | -------- | ------------------------------------------------------- |
         * | `large`  | Large sized button.                                     |
         * | `normal` | Standard sized button.                                  |
         * | `small`  | Small sized button.                                     |
         */
        this.size = "normal";
    }
    hostData() {
        return {
            role: "button"
        };
    }
    static get is() { return "gx-button"; }
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
        "imagePosition": {
            "type": String,
            "attr": "image-position"
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "size": {
            "type": String,
            "attr": "size"
        }
    }; }
    static get events() { return [{
            "name": "onClick",
            "method": "onClick",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-button:**/"; }
}
