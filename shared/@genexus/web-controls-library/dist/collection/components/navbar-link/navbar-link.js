import { BaseComponent } from "../common/base-component";
import { NavBarLinkRender } from "../renders/bootstrap/navbar-link/navbar-link-render";
export class NavBarLink extends NavBarLinkRender(BaseComponent) {
    constructor() {
        super(...arguments);
        /**
         * Indicates if the navbar item is the active one (for example, when the item represents the current page)
         */
        this.active = false;
        /**
         * This attribute lets you specify if the navbar item is disabled.
         */
        this.disabled = false;
        /**
         * This attribute lets you specify the URL of the navbar item.
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
    }
    static get is() { return "gx-navbar-link"; }
    static get properties() { return {
        "active": {
            "type": Boolean,
            "attr": "active"
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
    static get style() { return "/**style-placeholder:gx-navbar-link:**/"; }
}
