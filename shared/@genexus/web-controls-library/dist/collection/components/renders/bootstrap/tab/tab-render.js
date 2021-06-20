export function TabRender(Base) {
    return class extends Base {
        setSelectedTab(captionElement) {
            this.getCaptionSlots().forEach((slotElement, i) => {
                slotElement.selected = slotElement === captionElement;
                const pageElement = this.element.querySelector(`gx-tab-page:nth-child(${i + 1})`);
                this.mapPageToCaptionSelection(slotElement, pageElement);
            });
        }
        mapPageToCaptionSelection(captionElement, pageElement) {
            pageElement.classList.toggle("active", captionElement.selected);
        }
        render() {
            this.setCaptionSlotsClass();
            this.setPageSlotsClass();
            return (h("div", { role: "tablist" },
                h("div", { class: "nav nav-tabs" },
                    h("slot", { name: "caption" })),
                h("div", { class: "tab-content" },
                    h("slot", { name: "page" }))));
        }
        setCaptionSlotsClass() {
            this.getCaptionSlots().forEach(captionElement => {
                if (!captionElement.classList.contains("nav-item")) {
                    captionElement.classList.add("nav-item");
                }
            });
        }
        getCaptionSlots() {
            return Array.from(this.element.querySelectorAll("[slot='caption']"));
        }
        setPageSlotsClass() {
            this.getPageSlots().forEach(pageElement => {
                if (!pageElement.classList.contains("tab-pane")) {
                    pageElement.classList.add("tab-pane");
                }
            });
        }
        getPageSlots() {
            return Array.from(this.element.querySelectorAll("[slot='page']"));
        }
    };
}
