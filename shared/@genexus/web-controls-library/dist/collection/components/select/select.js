import { BaseComponent } from "../common/base-component";
import { SelectRender } from "../renders/bootstrap/select/select-render";
export class Select extends SelectRender(BaseComponent) {
    constructor() {
        super(...arguments);
        this.options = [];
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
    // private getValueFromEvent(event: UIEvent): string {
    //   return event.target && (event.target as HTMLInputElement).value;
    // }
    //
    // handleChange(event: UIEvent) {
    //   this.value = this.getValueFromEvent(event);
    //   this.onChange.emit(event);
    // }
    // @Watch("disabled")
    // disabledChanged() {
    //   this.setDisabled();
    // }
    getChildOptions() {
        return Array.from(this.element.querySelectorAll("gx-select-option")).map((option) => ({
            disabled: option.getAttribute("disabled") !== null,
            innerText: option.innerText,
            selected: option.getAttribute("selected") !== null,
            value: option.value
        }));
    }
    valueChanged() {
        // this select's value just changed
        // double check the option with this value is selected
        if (this.value === undefined) {
            // set to undefined
            // ensure all that are checked become unchecked
            this.options.filter(o => o.selected).forEach(option => {
                option.selected = false;
            });
        }
        else {
            let hasSelected = false;
            this.options.forEach(option => {
                if (option.value === this.value) {
                    if (!option.selected && !hasSelected) {
                        // correct value for this option
                        // but this option isn't selected yet
                        // and we haven't found a selected yet
                        // so SELECT IT!
                        option.selected = true;
                    }
                    else if (hasSelected && option.selected) {
                        // somehow we've got multiple options
                        // with the same value, but only one can be selected
                        option.selected = false;
                    }
                    // remember we've got a selected option now
                    hasSelected = true;
                }
                else if (option.selected) {
                    // this option doesn't have the correct value
                    // and it's also selected, so let's unselect it
                    option.selected = false;
                }
            });
        }
        if (this.didLoad) {
            // emit the new value
            this.onChange.emit({ value: this.value });
        }
    }
    onSelectOptionDidLoad(ev) {
        const option = ev.target;
        this.options = this.getChildOptions();
        if (this.value !== undefined && option.value === this.value) {
            // this select has a value and this
            // option equals the correct select value
            // so let's check this option
            option.selected = true;
        }
        else if (this.value === undefined && option.selected) {
            // this select does not have a value
            // but this option is checked, so let's set the
            // select's value from the checked option
            this.value = option.value;
        }
        else if (option.selected) {
            // if it doesn't match one of the above cases, but the
            // option is still checked, then we need to uncheck it
            option.selected = false;
        }
    }
    onSelectOptionDidUnload() {
        this.options = this.getChildOptions();
    }
    onSelectOptionDisable() {
        this.options = this.getChildOptions();
    }
    onSelectOptionChange() {
        this.options = this.getChildOptions();
    }
    onSelectOptionSelect(ev) {
        this.options.forEach(option => {
            if (option === ev.target) {
                if (option.value !== this.value) {
                    this.value = option.value;
                }
            }
            else {
                option.selected = false;
            }
        });
    }
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId() {
        return super.getNativeInputId();
    }
    setDisabled() {
        this.options.forEach(option => {
            option.disabled = this.disabled;
        });
    }
    componentDidLoad() {
        this.setDisabled();
        this.didLoad = true;
    }
    hostData() {
        return {
            role: "combobox"
        };
    }
    static get is() { return "gx-select"; }
    static get properties() { return {
        "cssClass": {
            "type": String,
            "attr": "css-class"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled"
        },
        "element": {
            "elementRef": true
        },
        "getNativeInputId": {
            "method": true
        },
        "id": {
            "type": String,
            "attr": "id"
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "options": {
            "state": true
        },
        "readonly": {
            "type": Boolean,
            "attr": "readonly"
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
            "name": "gxSelectDidLoad",
            "method": "onSelectOptionDidLoad"
        }, {
            "name": "gxSelectDidUnload",
            "method": "onSelectOptionDidUnload"
        }, {
            "name": "gxDisable",
            "method": "onSelectOptionDisable"
        }, {
            "name": "onChange",
            "method": "onSelectOptionChange"
        }, {
            "name": "gxSelect",
            "method": "onSelectOptionSelect"
        }]; }
}
