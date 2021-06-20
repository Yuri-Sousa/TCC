export function EditRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.disabled = false;
            this.type = "text";
        }
        getNativeInputId() {
            return this.nativeInput.id;
        }
        getCssClasses() {
            const classList = [];
            if (this.readonly) {
                classList.push("form-control-plaintext");
            }
            else {
                if (this.type === "file") {
                    classList.push("form-control-file");
                }
                else {
                    classList.push("form-control");
                }
            }
            return classList.join(" ");
        }
        getTriggerCssClasses() {
            const classList = [];
            classList.push("btn");
            classList.push("btn-outline-secondary");
            return classList.join(" ");
        }
        getValueFromEvent(event) {
            return event.target && event.target.value;
        }
        handleChange(event) {
            this.value = this.getValueFromEvent(event);
            this.onChange.emit(event);
        }
        handleValueChanging(event) {
            this.value = this.getValueFromEvent(event);
            this.onInput.emit(event);
        }
        handleTriggerClick(event) {
            this.gxTriggerClick.emit(event);
        }
        /**
         * Update the native input element when the value changes
         */
        valueChanged() {
            const inputEl = this.nativeInput;
            if (inputEl && inputEl.value !== this.value) {
                inputEl.value = this.value;
            }
        }
        componentDidUnload() {
            this.nativeInput = null;
        }
        render() {
            const valueChangingHandler = this.handleValueChanging.bind(this);
            if (!this.inputId) {
                this.inputId = this.id
                    ? `${this.id}__edit`
                    : `gx-edit-auto-id-${autoEditId++}`;
            }
            const attris = {
                "aria-disabled": this.disabled ? "true" : undefined,
                autocapitalize: this.autocapitalize,
                autocomplete: this.autocomplete,
                autocorrect: this.autocorrect,
                class: this.getCssClasses(),
                disabled: this.disabled,
                id: this.inputId,
                onChange: this.handleChange.bind(this),
                onInput: valueChangingHandler,
                placeholder: this.placeholder,
                readonly: this.readonly,
                ref: input => (this.nativeInput = input)
            };
            if (this.multiline) {
                return h("textarea", Object.assign({}, attris), this.value);
            }
            else {
                const input = h("input", Object.assign({}, attris, { type: this.type, value: this.value }));
                if (this.showTrigger && !this.readonly) {
                    return (h("div", { class: "input-group" },
                        input,
                        h("div", { class: "input-group-append" },
                            h("button", { class: this.getTriggerCssClasses(), onClick: this.handleTriggerClick.bind(this), type: "button", disabled: this.disabled, "aria-label": this.triggerText },
                                h("slot", { name: "trigger-content" })))));
                }
                else {
                    return input;
                }
            }
        }
    };
}
let autoEditId = 0;
