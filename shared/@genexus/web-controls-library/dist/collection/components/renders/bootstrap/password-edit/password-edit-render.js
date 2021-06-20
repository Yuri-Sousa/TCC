export function PasswordEditRender(Base) {
    return class extends Base {
        constructor() {
            super(...arguments);
            this.disabled = false;
            this.revealed = false;
        }
        getNativeInputId() {
            return this.innerEdit.getNativeInputId();
        }
        getValueFromEvent(event) {
            return event.target && event.target.value;
        }
        handleChange(event) {
            this.value = this.getValueFromEvent(event);
            this.onChange.emit(event);
        }
        handleInput(event) {
            this.value = this.getValueFromEvent(event);
            this.onInput.emit(event);
        }
        handleTriggerClick() {
            this.innerEdit.type = this.revealed ? "text" : "password";
        }
        /**
         * Update the native input element when the value changes
         */
        valueChanged() {
            const innerEdit = this.innerEdit;
            if (innerEdit && innerEdit.value !== this.value) {
                innerEdit.value = this.value;
            }
        }
        componentDidUnload() {
            this.innerEdit = null;
        }
        render() {
            return (h("gx-edit", { ref: input => (this.innerEdit = input), "css-class": this.cssClass, disabled: this.disabled, id: this.id, placeholder: this.placeholder, readonly: this.readonly, "show-trigger": !this.readonly && this.showRevealButton, "trigger-class": this.revealed ? "active" : "", "trigger-text": this.revealed ? this.revealButtonTextOff : this.revealButtonTextOn, type: this.revealed ? "text" : "password", value: this.value, onChange: this.handleChange.bind(this), onInput: this.handleInput.bind(this) },
                h("i", { class: "fa fa-eye" + (this.revealed ? "-slash" : ""), slot: "trigger-content" })));
        }
    };
}
