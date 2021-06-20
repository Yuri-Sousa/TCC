import { BaseComponent } from "../common/base-component";
import { NavBarRender } from "../renders/bootstrap/navbar/navbar-render";
export class NavBar extends NavBarRender(BaseComponent) {
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
    static get is() { return "gx-navbar"; }
    static get properties() { return {
        "caption": {
            "type": String,
            "attr": "caption"
        },
        "cssClass": {
            "type": String,
            "attr": "css-class"
        },
        "element": {
            "elementRef": true
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "toggleButtonLabel": {
            "type": String,
            "attr": "toggle-button-label"
        }
    }; }
    static get style() { return "/**style-placeholder:gx-navbar:**/"; }
}
