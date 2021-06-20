import { BaseComponent } from "../common/base-component";
export class RadioGroup extends BaseComponent {
    constructor() {
        super(...arguments);
        this.radios = [];
        /**
         * Specifies how the child `gx-radio-option` will be layed out.
         * It supports two values:
         *
         * * `horizontal`
         * * `vertical` (default)
         */
        this.direction = "horizontal";
        /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
        this.invisibleMode = "collapse";
        /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
        this.disabled = false;
    }
    getValueFromEvent(event) {
        return event.target && event.target.value;
    }
    handleChange(event) {
        this.value = this.getValueFromEvent(event);
        this.onChange.emit(event);
    }
    disabledChanged() {
        this.setDisabled();
    }
    valueChanged() {
        // this radio group's value just changed
        // double check the button with this value is checked
        if (this.value === undefined) {
            // set to undefined
            // ensure all that are checked become unchecked
            this.radios.filter(r => r.checked).forEach(radio => {
                radio.checked = false;
            });
        }
        else {
            let hasChecked = false;
            this.radios.forEach(radio => {
                if (radio.value === this.value) {
                    if (!radio.checked && !hasChecked) {
                        // correct value for this radio
                        // but this radio isn't checked yet
                        // and we haven't found a checked yet
                        // so CHECK IT!
                        radio.checked = true;
                    }
                    else if (hasChecked && radio.checked) {
                        // somehow we've got multiple radios
                        // with the same value, but only one can be checked
                        radio.checked = false;
                    }
                    // remember we've got a checked radio button now
                    hasChecked = true;
                }
                else if (radio.checked) {
                    // this radio doesn't have the correct value
                    // and it's also checked, so let's uncheck it
                    radio.checked = false;
                }
            });
        }
        if (this.didLoad) {
            // emit the new value
            this.onChange.emit({ value: this.value });
        }
    }
    onRadioDidLoad(ev) {
        const radio = ev.target;
        this.radios.push(radio);
        radio.name = this.name;
        if (this.value !== undefined && radio.value === this.value) {
            // this radio-group has a value and this
            // radio equals the correct radio-group value
            // so let's check this radio
            radio.checked = true;
        }
        else if (this.value === undefined && radio.checked) {
            // this radio-group does not have a value
            // but this radio is checked, so let's set the
            // radio-group's value from the checked radio
            this.value = radio.value;
        }
        else if (radio.checked) {
            // if it doesn't match one of the above cases, but the
            // radio is still checked, then we need to uncheck it
            radio.checked = false;
        }
    }
    onRadioDidUnload(ev) {
        const index = this.radios.indexOf(ev.target);
        if (index > -1) {
            this.radios.splice(index, 1);
        }
    }
    onRadioSelect(ev) {
        this.radios.forEach(radio => {
            if (radio === ev.target) {
                if (radio.value !== this.value) {
                    this.value = radio.value;
                }
            }
            else {
                radio.checked = false;
            }
        });
    }
    setDisabled() {
        this.radios.forEach(radio => {
            radio.disabled = this.disabled;
        });
    }
    componentDidLoad() {
        this.setDisabled();
        this.didLoad = true;
    }
    hostData() {
        return {
            role: "radiogroup"
        };
    }
    render() {
        return h("slot", null);
    }
    static get is() { return "gx-radio-group"; }
    static get properties() { return {
        "direction": {
            "type": String,
            "attr": "direction"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled",
            "watchCallbacks": ["disabledChanged"]
        },
        "element": {
            "elementRef": true
        },
        "id": {
            "type": String,
            "attr": "id"
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "name": {
            "type": String,
            "attr": "name"
        },
        "value": {
            "type": String,
            "attr": "value",
            "mutable": true,
            "watchCallbacks": ["valueChanged"]
        }
    }; }
    static get events() { return [{
            "name": "onChange",
            "method": "onChange",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get listeners() { return [{
            "name": "gxRadioDidLoad",
            "method": "onRadioDidLoad"
        }, {
            "name": "gxRadioDidUnload",
            "method": "onRadioDidUnload"
        }, {
            "name": "gxSelect",
            "method": "onRadioSelect"
        }]; }
    static get style() { return "/**style-placeholder:gx-radio-group:**/"; }
}
