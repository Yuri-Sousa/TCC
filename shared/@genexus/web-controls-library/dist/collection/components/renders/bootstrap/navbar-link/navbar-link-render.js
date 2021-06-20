export function NavBarLinkRender(Base) {
    return class extends Base {
        handleClick(event) {
            if (this.disabled) {
                return;
            }
            this.onClick.emit(event);
            event.preventDefault();
        }
        render() {
            this.element.classList.add("nav-item");
            return (h("a", { class: {
                    active: this.active,
                    disabled: this.disabled,
                    "nav-link": true,
                    [this.cssClass]: !!this.cssClass
                }, href: this.href, onClick: this.handleClick.bind(this) },
                h("slot", null)));
        }
    };
}
