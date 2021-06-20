export function RadioOptionRender(Base) {
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
        getInnerControlContainerClass() {
            const classList = ["custom-control", "custom-radio"];
            if (this.disabled) {
                classList.push("disabled");
            }
            return classList.join(" ");
        }
        handleClick() {
            this.checkedChanged(true);
        }
        handleChange(event) {
            this.checked = true;
            this.nativeInput.focus();
            this.onChange.emit(event);
        }
        checkedChanged(isChecked) {
            const inputEl = this.nativeInput;
            if (inputEl && inputEl.checked !== isChecked) {
                inputEl.checked = isChecked;
            }
            clearTimeout(this.checkedTmr);
            this.checkedTmr = setTimeout(() => {
                // only emit onSelect when checked is true
                if (this.didLoad && isChecked) {
                    this.gxSelect.emit({
                        checked: isChecked,
                        value: this.value
                    });
                }
            });
        }
        disabledChanged(isDisabled) {
            this.nativeInput.disabled = isDisabled;
        }
        componentDidLoad() {
            this.didLoad = true;
        }
        componentDidUnload() {
            this.nativeInput = null;
        }
        render() {
            if (!this.inputId) {
                this.inputId = this.id
                    ? `${this.id}__radio-option`
                    : `gx-radio-auto-id-${autoRadioId++}`;
            }
            const attris = {
                "aria-disabled": this.disabled ? "true" : undefined,
                class: this.getCssClasses(),
                disabled: this.disabled,
                id: this.inputId,
                name: this.name,
                onChange: this.handleChange.bind(this),
                onClick: this.handleClick.bind(this),
                ref: input => (this.nativeInput = input),
                value: this.value
            };
            const forAttris = {
                for: attris.id
            };
            return (h("div", { class: this.getInnerControlContainerClass() },
                h("input", Object.assign({}, attris, { type: "radio", checked: this.checked })),
                h("label", Object.assign({ class: "custom-control-label" }, forAttris), this.caption)));
        }
    };
}
let autoRadioId = 0;
