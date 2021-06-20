/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

let s = 0;

class i extends(function(t) {
  return class extends t {
    constructor() {
      super(...arguments), this.options = [], this.disabled = !1;
    }
    getNativeInputId() {
      return this.nativeSelect.id;
    }
    getCssClasses() {
      const e = [];
      return this.readonly ? e.push("form-control-plaintext") : e.push("custom-select"), 
      this.cssClass && e.push(this.cssClass), e.join(" ");
    }
    getReadonlyTextContent() {
      const e = this.options.filter(e => e.value === this.value);
      return e.length > 0 ? e[0].innerText : "";
    }
    getValueFromEvent(e) {
      return e.target && e.target.value;
    }
    handleChange(e) {
      this.value = this.getValueFromEvent(e), this.onChange.emit(e);
    }
    componentDidUnload() {
      this.nativeSelect = null;
    }
    render() {
      if (this.selectId || (this.selectId = this.id ? `${this.id}__select` : `gx-select-auto-id-${s++}`), 
      this.readonly) return e("span", {
        class: this.getCssClasses()
      }, this.getReadonlyTextContent());
      {
        const t = {
          "aria-disabled": this.disabled ? "true" : void 0,
          class: this.getCssClasses(),
          disabled: this.disabled,
          id: this.selectId,
          onChange: this.handleChange.bind(this),
          ref: e => {
            e.value = this.value, this.nativeSelect = e;
          }
        };
        return e("select", Object.assign({}, t), this.options.map(({disabled: t, innerText: s, selected: i, value: l}) => e("option", {
          disabled: t,
          selected: i,
          value: l
        }, s)));
      }
    }
  };
}(t)){
  constructor() {
    super(...arguments), this.options = [], 
    /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
    this.invisibleMode = "collapse", 
    /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
    this.disabled = !1;
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
    return Array.from(this.element.querySelectorAll("gx-select-option")).map(e => ({
      disabled: null !== e.getAttribute("disabled"),
      innerText: e.innerText,
      selected: null !== e.getAttribute("selected"),
      value: e.value
    }));
  }
  valueChanged() {
    // this select's value just changed
    // double check the option with this value is selected
    if (void 0 === this.value) 
    // set to undefined
    // ensure all that are checked become unchecked
    this.options.filter(e => e.selected).forEach(e => {
      e.selected = !1;
    }); else {
      let e = !1;
      this.options.forEach(t => {
        t.value === this.value ? (t.selected || e ? e && t.selected && (
        // somehow we've got multiple options
        // with the same value, but only one can be selected
        t.selected = !1) : 
        // correct value for this option
        // but this option isn't selected yet
        // and we haven't found a selected yet
        // so SELECT IT!
        t.selected = !0, 
        // remember we've got a selected option now
        e = !0) : t.selected && (
        // this option doesn't have the correct value
        // and it's also selected, so let's unselect it
        t.selected = !1);
      });
    }
    this.didLoad && 
    // emit the new value
    this.onChange.emit({
      value: this.value
    });
  }
  onSelectOptionDidLoad(e) {
    const t = e.target;
    this.options = this.getChildOptions(), void 0 !== this.value && t.value === this.value ? 
    // this select has a value and this
    // option equals the correct select value
    // so let's check this option
    t.selected = !0 : void 0 === this.value && t.selected ? 
    // this select does not have a value
    // but this option is checked, so let's set the
    // select's value from the checked option
    this.value = t.value : t.selected && (
    // if it doesn't match one of the above cases, but the
    // option is still checked, then we need to uncheck it
    t.selected = !1);
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
  onSelectOptionSelect(e) {
    this.options.forEach(t => {
      t === e.target ? t.value !== this.value && (this.value = t.value) : t.selected = !1;
    });
  }
  /**
     * Returns the id of the inner `input` element (if set).
     */  getNativeInputId() {
    return super.getNativeInputId();
  }
  setDisabled() {
    this.options.forEach(e => {
      e.disabled = this.disabled;
    });
  }
  componentDidLoad() {
    this.setDisabled(), this.didLoad = !0;
  }
  hostData() {
    return {
      role: "combobox"
    };
  }
  static get is() {
    return "gx-select";
  }
  static get properties() {
    return {
      cssClass: {
        type: String,
        attr: "css-class"
      },
      disabled: {
        type: Boolean,
        attr: "disabled"
      },
      element: {
        elementRef: !0
      },
      getNativeInputId: {
        method: !0
      },
      id: {
        type: String,
        attr: "id"
      },
      invisibleMode: {
        type: String,
        attr: "invisible-mode"
      },
      options: {
        state: !0
      },
      readonly: {
        type: Boolean,
        attr: "readonly"
      },
      value: {
        type: String,
        attr: "value",
        mutable: !0,
        watchCallbacks: [ "valueChanged" ]
      }
    };
  }
  static get events() {
    return [ {
      name: "onChange",
      method: "onChange",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    } ];
  }
  static get listeners() {
    return [ {
      name: "gxSelectDidLoad",
      method: "onSelectOptionDidLoad"
    }, {
      name: "gxSelectDidUnload",
      method: "onSelectOptionDidUnload"
    }, {
      name: "gxDisable",
      method: "onSelectOptionDisable"
    }, {
      name: "onChange",
      method: "onSelectOptionChange"
    }, {
      name: "gxSelect",
      method: "onSelectOptionSelect"
    } ];
  }
}

export { i as GxSelect };