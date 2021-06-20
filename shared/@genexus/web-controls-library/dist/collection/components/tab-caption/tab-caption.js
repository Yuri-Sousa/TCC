import { BaseComponent } from "../common/base-component";
import { TabCaptionRender } from "../renders/bootstrap/tab-caption/tab-caption-render";
export class TabCaption extends TabCaptionRender(BaseComponent) {
    componentWillLoad() {
        if (!this.element.id) {
            this.element.id = `gx-tab-caption-auto-id-${autoTabId++}`;
        }
    }
    hostData() {
        return {
            role: "tab"
        };
    }
    static get is() { return "gx-tab-caption"; }
    static get properties() { return {
        "disabled": {
            "type": Boolean,
            "attr": "disabled"
        },
        "element": {
            "elementRef": true
        },
        "selected": {
            "type": Boolean,
            "attr": "selected"
        }
    }; }
    static get events() { return [{
            "name": "onTabSelect",
            "method": "onTabSelect",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-tab-caption:**/"; }
}
let autoTabId = 0;
