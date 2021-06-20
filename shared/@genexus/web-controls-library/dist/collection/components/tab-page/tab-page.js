import { BaseComponent } from "../common/base-component";
export class TabPage extends BaseComponent {
    componentWillLoad() {
        if (!this.element.id) {
            this.element.id = `gx-tab-page-auto-id-${autoTabId++}`;
        }
    }
    hostData() {
        return {
            role: "tabpanel",
            tabindex: 0
        };
    }
    render() {
        return h("slot", null);
    }
    static get is() { return "gx-tab-page"; }
    static get properties() { return {
        "element": {
            "elementRef": true
        }
    }; }
    static get style() { return "/**style-placeholder:gx-tab-page:**/"; }
}
let autoTabId = 0;
