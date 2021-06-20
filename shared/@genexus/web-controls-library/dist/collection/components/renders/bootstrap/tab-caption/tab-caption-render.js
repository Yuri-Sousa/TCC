export function TabCaptionRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.disabled = false;
            this.selected = false;
        }
        render() {
            this.element.setAttribute("aria-selected", this.selected.toString());
            return (h("a", { class: {
                    active: this.selected,
                    disabled: this.disabled,
                    "nav-link": true
                }, href: "#", onClick: this.clickHandler.bind(this) },
                h("slot", null)));
        }
        clickHandler(event) {
            if (this.disabled) {
                return;
            }
            event.preventDefault();
            this.onTabSelect.emit(event);
        }
    };
}
