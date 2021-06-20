import Popper from "popper.js";
export function CardRender(Base) {
    return class extends Base {
        handleDropDownToggleClick(evt) {
            const dropDownMenu = this.element.querySelector(".dropdown-menu");
            dropDownMenu.classList.toggle("show");
            const toggleButton = evt.target;
            if (this.popper) {
                this.popper.destroy();
            }
            this.popper = new Popper(toggleButton, dropDownMenu, {
                placement: "bottom-start"
            });
            this.bodyClickHandler = bodyClickEvt => {
                const target = bodyClickEvt.target;
                if (target === toggleButton) {
                    return;
                }
                dropDownMenu.classList.remove("show");
            };
            setTimeout(() => {
                document.body.addEventListener("click", this.bodyClickHandler, {
                    once: true
                });
            }, 10);
        }
        componentDidUnload() {
            if (this.bodyClickHandler) {
                document.body.removeEventListener("click", this.bodyClickHandler);
            }
            if (this.popper) {
                this.popper.destroy();
            }
        }
        componentDidLoad() {
            this.toggleHeaderFooterVisibility();
        }
        componentDidUpdate() {
            this.toggleHeaderFooterVisibility();
        }
        toggleHeaderFooterVisibility() {
            const cardHeader = this.element.querySelector(":scope > .card > .card-header");
            const cardFooter = this.element.querySelector(":scope > .card > .card-footer");
            const lowPriorityActions = cardFooter
                ? Array.from(cardFooter.querySelectorAll("[slot='low-priority-action']"))
                : [];
            const highPriorityActions = cardHeader
                ? Array.from(cardHeader.querySelectorAll("[slot='high-priority-action']"))
                : [];
            const normalPriorityActions = cardFooter
                ? Array.from(cardFooter.querySelectorAll("[slot='normal-priority-action']"))
                : [];
            const buttonActions = [...highPriorityActions, ...normalPriorityActions];
            buttonActions.forEach((btn) => (btn.size = "small"));
            lowPriorityActions.forEach((action) => {
                if (action.cssClass && action.cssClass.indexOf("dropdown-item") >= 0) {
                    return;
                }
                action.cssClass = (action.cssClass || "") + " dropdown-item";
            });
            const hasLowPriorityActions = lowPriorityActions.length > 0;
            const hasFooterActions = hasLowPriorityActions || normalPriorityActions.length > 0;
            const hasHeaderActions = highPriorityActions.length > 0;
            const renderHeader = hasHeaderActions ||
                (cardHeader && !!cardHeader.querySelector("[slot='header']"));
            const renderFooter = hasFooterActions ||
                (cardFooter && !!cardFooter.querySelector("[slot='footer']"));
            if (cardHeader) {
                cardHeader.hidden = !renderHeader;
            }
            if (cardFooter) {
                cardFooter.hidden = !renderFooter;
            }
        }
        render() {
            const lowPriorityActions = Array.from(this.element.querySelectorAll("[slot='low-priority-action']"));
            const highPriorityActions = Array.from(this.element.querySelectorAll("[slot='high-priority-action']"));
            const normalPriorityActions = Array.from(this.element.querySelectorAll("[slot='normal-priority-action']"));
            const buttonActions = [...highPriorityActions, ...normalPriorityActions];
            buttonActions.forEach((btn) => (btn.size = "small"));
            lowPriorityActions.forEach((action) => {
                if (action.cssClass && action.cssClass.indexOf("dropdown-item") >= 0) {
                    return;
                }
                action.cssClass = (action.cssClass || "") + " dropdown-item";
            });
            const hasLowPriorityActions = lowPriorityActions.length > 0;
            const hasFooterActions = hasLowPriorityActions || !!normalPriorityActions;
            const renderFooter = hasFooterActions || !!this.element.querySelector("[slot='footer']");
            return (h("div", { class: "card" },
                h("div", { class: "card-header" },
                    h("slot", { name: "header" }),
                    h("div", { class: "float-right" },
                        h("slot", { name: "high-priority-action" }))),
                h("slot", { name: "body" }),
                h("slot", null),
                renderFooter && (h("div", { class: "card-footer" },
                    h("slot", { name: "footer" }),
                    hasFooterActions && (h("div", { class: "float-right" },
                        h("slot", { name: "normal-priority-action" }),
                        hasLowPriorityActions && (h("button", { class: "btn btn-sm gx-dropdown-toggle", type: "button", "aria-haspopup": "true", "aria-expanded": "false", "aria-label": "More actions", onClick: this.handleDropDownToggleClick.bind(this) })),
                        hasLowPriorityActions && (h("div", { class: "dropdown-menu" },
                            h("slot", { name: "low-priority-action" })))))))));
        }
    };
}
