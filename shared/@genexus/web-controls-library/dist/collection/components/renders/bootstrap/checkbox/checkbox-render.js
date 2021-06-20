export function CheckBoxRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.disabled = false;
        }
        getNativeInputId() {
            return this.nativeInput.id;
        }
        getCssClasses() {
            const classList = [];
            classList.push("custom-control-input");
            if (this.cssClass) {
                classList.push(this.cssClass);
            }
            if (!this.caption) {
                classList.push("position-static");
            }
            return classList.join(" ");
        }
        getValueFromEvent(event) {
            return event.target && event.target.checked;
        }
        handleChange(event) {
            this.checked = this.getValueFromEvent(event);
            this.onChange.emit(event);
        }
        /**
         * Update the native input element when the value changes
         */
        checkedChanged() {
            const inputEl = this.nativeInput;
            if (inputEl && inputEl.checked !== this.checked) {
                inputEl.checked = this.checked;
            }
        }
        componentDidUnload() {
            this.nativeInput = null;
        }
        render() {
            if (!this.inputId) {
                this.inputId = this.id
                    ? `${this.id}__checkbox`
                    : `gx-checkbox-auto-id-${autoCheckBoxId++}`;
            }
            const attris = {
                "aria-disabled": this.disabled ? "true" : undefined,
                class: this.getCssClasses(),
                disabled: this.disabled,
                id: this.inputId,
                onChange: this.handleChange.bind(this),
                ref: input => (this.nativeInput = input)
            };
            const forAttris = {
                for: attris.id
            };
            return (h("div", { class: "custom-control custom-checkbox" },
                h("input", Object.assign({}, attris, { type: "checkbox", checked: this.checked })),
                h("label", Object.assign({ class: "custom-control-label" }, forAttris, { "aria-hidden": !this.caption }), this.caption)));
        }
    };
}
let autoCheckBoxId = 0;
