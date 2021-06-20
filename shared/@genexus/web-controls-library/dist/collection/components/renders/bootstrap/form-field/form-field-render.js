export function FormFieldRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.LABEL_WIDTH_BY_POSITION = {
                bottom: "col-sm-12",
                float: "",
                left: "col-sm-2",
                none: "sr-only",
                right: "col-sm-2",
                top: "col-sm-12"
            };
            this.INNER_CONTROL_WIDTH_BY_LABEL_POSITION = {
                bottom: "col-sm-12",
                float: "",
                left: "col-sm-10",
                none: "col-sm-12",
                right: "col-sm-10",
                top: "col-sm-12"
            };
        }
        getLabelCssClass() {
            const classList = [];
            classList.push(this.LABEL_WIDTH_BY_POSITION[this.labelPosition]);
            if (this.labelPosition !== "float") {
                classList.push("col-form-label");
            }
            return classList.join(" ");
        }
        getInnerControlContainerClass() {
            return this.INNER_CONTROL_WIDTH_BY_LABEL_POSITION[this.labelPosition];
        }
        shouldRenderLabelBefore() {
            return (!this.labelPosition ||
                this.labelPosition === "top" ||
                this.labelPosition === "left" ||
                this.labelPosition === "none");
        }
        componentDidLoad() {
            const innerControl = this.element.querySelector("[area='field']");
            if (innerControl && innerControl.getNativeInputId) {
                const nativeInputId = innerControl.getNativeInputId();
                const nativeInput = this.element.querySelector(`#${nativeInputId}`);
                if (nativeInput) {
                    nativeInput.setAttribute("data-part", "field");
                }
                if (nativeInputId) {
                    this.element
                        .querySelector("label")
                        .setAttribute("for", nativeInputId);
                }
            }
        }
        renderForRadio(renderLabelBefore) {
            const labelId = `${this.formFieldId}-label`;
            const label = (h("div", { class: this.getLabelCssClass(), id: labelId, "data-part": "label" },
                h("div", { class: "label-content" }, this.labelCaption)));
            return (h("div", { class: "form-group", "aria-labelledby": labelId, role: "group" },
                h("div", { class: "row" },
                    renderLabelBefore ? label : null,
                    h("div", { class: this.getInnerControlContainerClass() },
                        h("slot", null)),
                    !renderLabelBefore ? label : null)));
        }
        render() {
            const isRadioGroup = !!this.element.querySelector("gx-radio-group[area='field']");
            const renderLabelBefore = this.shouldRenderLabelBefore();
            if (!this.formFieldId) {
                this.formFieldId =
                    this.id || `gx-form-field-auto-id-${autoFormFieldId++}`;
            }
            if (isRadioGroup) {
                return this.renderForRadio(renderLabelBefore);
            }
            else {
                const label = (h("label", { class: this.getLabelCssClass(), "data-part": "label" },
                    h("div", { class: "label-content" }, this.labelCaption)));
                if (this.labelPosition === "float") {
                    return (h("div", null,
                        h("slot", null),
                        label));
                }
                else {
                    return (h("div", { class: "form-group row" },
                        renderLabelBefore ? label : null,
                        h("div", { class: this.getInnerControlContainerClass() },
                            h("slot", null)),
                        !renderLabelBefore ? label : null));
                }
            }
        }
    };
}
let autoFormFieldId = 0;
