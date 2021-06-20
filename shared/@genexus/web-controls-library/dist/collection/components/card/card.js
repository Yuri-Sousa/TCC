import { BaseComponent } from "../common/base-component";
import { CardRender } from "../renders/bootstrap/card/card-render";
export class Card extends CardRender(BaseComponent) {
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
    componentDidUpdate() {
        super.componentDidUpdate();
    }
    componentDidUnload() {
        super.componentDidUnload();
    }
    static get is() { return "gx-card"; }
    static get properties() { return {
        "element": {
            "elementRef": true
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        }
    }; }
    static get style() { return "/**style-placeholder:gx-card:**/"; }
}
