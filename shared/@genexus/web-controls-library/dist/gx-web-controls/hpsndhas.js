/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

class a extends t {
  constructor() {
    super(...arguments), this.radios = [], 
    /**
         * Specifies how the child `gx-radio-option` will be layed out.
         * It supports two values:
         *
         * * `horizontal`
         * * `vertical` (default)
         */
    this.direction = "horizontal", 
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
  getValueFromEvent(e) {
    return e.target && e.target.value;
  }
  handleChange(e) {
    this.value = this.getValueFromEvent(e), this.onChange.emit(e);
  }
  disabledChanged() {
    this.setDisabled();
  }
  valueChanged() {
    // this radio group's value just changed
    // double check the button with this value is checked
    if (void 0 === this.value) 
    // set to undefined
    // ensure all that are checked become unchecked
    this.radios.filter(e => e.checked).forEach(e => {
      e.checked = !1;
    }); else {
      let e = !1;
      this.radios.forEach(t => {
        t.value === this.value ? (t.checked || e ? e && t.checked && (
        // somehow we've got multiple radios
        // with the same value, but only one can be checked
        t.checked = !1) : 
        // correct value for this radio
        // but this radio isn't checked yet
        // and we haven't found a checked yet
        // so CHECK IT!
        t.checked = !0, 
        // remember we've got a checked radio button now
        e = !0) : t.checked && (
        // this radio doesn't have the correct value
        // and it's also checked, so let's uncheck it
        t.checked = !1);
      });
    }
    this.didLoad && 
    // emit the new value
    this.onChange.emit({
      value: this.value
    });
  }
  onRadioDidLoad(e) {
    const t = e.target;
    this.radios.push(t), t.name = this.name, void 0 !== this.value && t.value === this.value ? 
    // this radio-group has a value and this
    // radio equals the correct radio-group value
    // so let's check this radio
    t.checked = !0 : void 0 === this.value && t.checked ? 
    // this radio-group does not have a value
    // but this radio is checked, so let's set the
    // radio-group's value from the checked radio
    this.value = t.value : t.checked && (
    // if it doesn't match one of the above cases, but the
    // radio is still checked, then we need to uncheck it
    t.checked = !1);
  }
  onRadioDidUnload(e) {
    const t = this.radios.indexOf(e.target);
    t > -1 && this.radios.splice(t, 1);
  }
  onRadioSelect(e) {
    this.radios.forEach(t => {
      t === e.target ? t.value !== this.value && (this.value = t.value) : t.checked = !1;
    });
  }
  setDisabled() {
    this.radios.forEach(e => {
      e.disabled = this.disabled;
    });
  }
  componentDidLoad() {
    this.setDisabled(), this.didLoad = !0;
  }
  hostData() {
    return {
      role: "radiogroup"
    };
  }
  render() {
    return e("slot", null);
  }
  static get is() {
    return "gx-radio-group";
  }
  static get properties() {
    return {
      direction: {
        type: String,
        attr: "direction"
      },
      disabled: {
        type: Boolean,
        attr: "disabled",
        watchCallbacks: [ "disabledChanged" ]
      },
      element: {
        elementRef: !0
      },
      id: {
        type: String,
        attr: "id"
      },
      invisibleMode: {
        type: String,
        attr: "invisible-mode"
      },
      name: {
        type: String,
        attr: "name"
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
      name: "gxRadioDidLoad",
      method: "onRadioDidLoad"
    }, {
      name: "gxRadioDidUnload",
      method: "onRadioDidUnload"
    }, {
      name: "gxSelect",
      method: "onRadioSelect"
    } ];
  }
  static get style() {
    return "gx-radio-group{display:block}gx-radio-group[hidden]{display:none}gx-radio-group[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}gx-radio-group[direction=horizontal]>gx-radio-option{display:-webkit-inline-box;display:-ms-inline-flexbox;display:inline-flex;margin-right:1rem}";
  }
}

export { a as GxRadioGroup };