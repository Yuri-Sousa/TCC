const TYPE_TO_CLASS_MAPPING = {
    error: "alert-danger",
    info: "alert-info",
    warning: "alert-warning"
};
const DEFAULT_SHOW_WAIT = 100;
export function MessageRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.dismissing = false;
        }
        wrapperClass() {
            const typeClass = TYPE_TO_CLASS_MAPPING[this.type] || "alert-info";
            return {
                alert: true,
                [`${typeClass}`]: true,
                "alert-dismissible": true,
                fade: true
            };
        }
        dismiss() {
            if (!this.dismissing) {
                this.dismissing = true;
                this.element.querySelector(".alert").classList.remove("show");
            }
        }
        transitionEnd() {
            if (this.dismissing) {
                if (this.element) {
                    this.element.parentNode.removeChild(this.element);
                }
            }
        }
        componentDidLoad() {
            const anchors = this.element.querySelectorAll("a");
            Array.from(anchors).forEach(a => a.classList.add("alert-link"));
            setTimeout(() => {
                this.element.querySelector(".alert").classList.add("show");
                if (this.duration) {
                    setTimeout(() => {
                        this.dismiss();
                    }, this.duration);
                }
            }, DEFAULT_SHOW_WAIT);
        }
        render() {
            return (h("div", { class: this.wrapperClass(), role: "alert", onTransitionEnd: this.transitionEnd.bind(this) },
                h("slot", null),
                this.showCloseButton ? (h("button", { type: "button", class: "close", "aria-label": this.closeButtonText, onClick: this.dismiss.bind(this) },
                    h("span", { "aria-hidden": "true" }, "\u00D7"))) : null));
        }
    };
}
