import { BaseComponent } from "../common/base-component";
import { TabRender } from "../renders/bootstrap/tab/tab-render";
export class Tab extends TabRender(BaseComponent) {
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
    tabClickHandler(event) {
        const oldSelectedTab = this.lastSelectedTab;
        this.setSelectedTab(event.target);
        if (oldSelectedTab !== this.lastSelectedTab) {
            this.onTabChange.emit(event);
        }
    }
    setSelectedTab(captionElement) {
        this.lastSelectedTab = captionElement;
        super.setSelectedTab(captionElement);
    }
    componentDidLoad() {
        this.linkTabs(true);
    }
    componentDidUpdate() {
        this.linkTabs();
    }
    componentDidUnload() {
        this.lastSelectedTab = null;
    }
    linkTabs(resolveSelected = false) {
        const captionSlots = super.getCaptionSlots();
        const pageSlots = super.getPageSlots();
        if (captionSlots.length === pageSlots.length) {
            captionSlots.forEach((captionElement, i) => {
                const pageElement = pageSlots[i];
                captionElement.setAttribute("aria-controls", pageElement.id);
                pageElement.setAttribute("aria-labelledby", captionElement.id);
                if (resolveSelected) {
                    super.mapPageToCaptionSelection(captionElement, pageElement);
                    if (captionElement.selected) {
                        this.lastSelectedTab = captionElement;
                    }
                }
            });
        }
    }
    static get is() { return "gx-tab"; }
    static get properties() { return {
        "element": {
            "elementRef": true
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        }
    }; }
    static get events() { return [{
            "name": "onTabChange",
            "method": "onTabChange",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get listeners() { return [{
            "name": "onTabSelect",
            "method": "tabClickHandler"
        }]; }
    static get style() { return "/**style-placeholder:gx-tab:**/"; }
}
