export function SelectRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.options = [];
            this.disabled = false;
        }
        getNativeInputId() {
            return this.nativeSelect.id;
        }
        getCssClasses() {
            const classList = [];
            if (this.readonly) {
                classList.push("form-control-plaintext");
            }
            else {
                classList.push("custom-select");
            }
            if (this.cssClass) {
                classList.push(this.cssClass);
            }
            return classList.join(" ");
        }
        getReadonlyTextContent() {
            const matchingOpts = this.options.filter(o => o.value === this.value);
            if (matchingOpts.length > 0) {
                return matchingOpts[0].innerText;
            }
            return "";
        }
        getValueFromEvent(event) {
            return event.target && event.target.value;
        }
        handleChange(event) {
            this.value = this.getValueFromEvent(event);
            this.onChange.emit(event);
        }
        componentDidUnload() {
            this.nativeSelect = null;
        }
        render() {
            if (!this.selectId) {
                this.selectId = this.id
                    ? `${this.id}__select`
                    : `gx-select-auto-id-${autoSelectId++}`;
            }
            if (this.readonly) {
                return (h("span", { class: this.getCssClasses() }, this.getReadonlyTextContent()));
            }
            else {
                const attris = {
                    "aria-disabled": this.disabled ? "true" : undefined,
                    class: this.getCssClasses(),
                    disabled: this.disabled,
                    id: this.selectId,
                    onChange: this.handleChange.bind(this),
                    ref: (select) => {
                        select.value = this.value;
                        this.nativeSelect = select;
                    }
                };
                return (h("select", Object.assign({}, attris), this.options.map(({ disabled, innerText, selected, value }) => (h("option", { disabled: disabled, selected: selected, value: value }, innerText)))));
            }
        }
    };
}
let autoSelectId = 0;
