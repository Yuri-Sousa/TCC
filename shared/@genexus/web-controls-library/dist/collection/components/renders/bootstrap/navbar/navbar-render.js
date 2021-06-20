export function NavBarRender(Base) {
    return class extends Base {
        toggleCollapseHandler(event) {
            const button = event.currentTarget;
            const targetSelector = button.getAttribute("data-target");
            const targetElement = this.element.querySelector(targetSelector);
            if (this.expanded) {
                this.collapse(targetElement);
            }
            else {
                this.expand(targetElement);
            }
        }
        expand(target) {
            if (this.transitioning) {
                return;
            }
            this.expanded = true;
            target.classList.remove("collapse");
            target.classList.add("collapsing");
            setTimeout(() => {
                this.transitioning = true;
                target.style.height = `${target.scrollHeight}px`;
            }, 10);
        }
        collapse(target) {
            if (this.transitioning) {
                return;
            }
            this.expanded = false;
            target.style.height = getComputedStyle(target).height;
            target.classList.add("collapsing");
            target.classList.remove("show");
            target.classList.remove("collapse");
            setTimeout(() => {
                this.transitioning = true;
                target.style.height = "";
            }, 10);
        }
        handleTransitionEnd(event) {
            const target = event.currentTarget;
            target.classList.remove("collapsing");
            target.classList.add("collapse");
            if (this.expanded) {
                target.style.height = "";
                target.classList.add("show");
            }
            this.transitioning = false;
        }
        render() {
            if (!this.navBarId) {
                this.navBarId = this.id
                    ? `${this.id}__navbar`
                    : `gx-navbar-auto-id-${autoNavBarId++}`;
            }
            const navBarNavId = `${this.navBarId}_navbarNav`;
            const header = this.element.querySelector("[slot='header']");
            if (header) {
                header.classList.add("d-inline-block", "align-top");
                header.alt = header.alt || "";
            }
            return (h("nav", { id: this.navBarId, class: {
                    "bg-white": true,
                    navbar: true,
                    "navbar-expand-sm": true,
                    "navbar-light": true,
                    [this.cssClass]: !!this.cssClass
                } },
                h("a", { class: "navbar-brand", tabindex: "-1" },
                    h("slot", { name: "header" }),
                    this.caption),
                h("button", { class: "navbar-toggler", type: "button", "data-target": `#${navBarNavId}`, "aria-controls": navBarNavId, "aria-expanded": this.expanded, "aria-label": this.toggleButtonLabel, onClick: this.toggleCollapseHandler.bind(this) },
                    h("span", { class: "navbar-toggler-icon" })),
                h("div", { class: {
                        collapse: true,
                        "navbar-collapse": true,
                        show: this.expanded
                    }, id: navBarNavId, ref: (el) => {
                        // Had to subscribe to the transitionend this way because onTransitionEnd attribute is not working
                        el.addEventListener("transitionend", this.handleTransitionEnd.bind(this));
                    } },
                    h("div", { class: "navbar-nav" },
                        h("slot", null)))));
        }
    };
}
let autoNavBarId = 0;
