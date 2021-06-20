export function ButtonRender(Base) {
    return class extends Base {
        handleClick(event) {
            if (this.disabled) {
                return;
            }
            this.onClick.emit(event);
        }
        render() {
            // Main image and disabled image are set an empty alt as they are decorative images.
            const images = this.element.querySelectorAll("[slot='main-image'], [slot='disabled-image']");
            Array.from(images).forEach((img) => {
                if (!img.alt) {
                    img.setAttribute("alt", "");
                }
            });
            return (h("button", { class: {
                    btn: true,
                    "btn-default": true,
                    "btn-lg": this.size === "large",
                    "btn-sm": this.size === "small",
                    "gx-button": true,
                    [this.cssClass]: true
                }, onClick: this.handleClick.bind(this), tabindex: "0" },
                h("slot", { name: "main-image" }),
                h("slot", { name: "disabled-image" }),
                h("span", null,
                    h("slot", null))));
        }
    };
}
