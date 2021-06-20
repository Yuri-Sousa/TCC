/*! Built with http://stenciljs.com */
var __extends = this && this.__extends || function() {
  var e = Object.setPrototypeOf || {
    __proto__: []
  } instanceof Array && function(e, o) {
    e.__proto__ = o;
  } || function(e, o) {
    for (var t in o) o.hasOwnProperty(t) && (e[t] = o[t]);
  };
  return function(o, t) {
    function __() {
      this.constructor = o;
    }
    e(o, t), o.prototype = null === t ? Object.create(t) : (__.prototype = t.prototype, 
    new __());
  };
}();

/*! Built with http://stenciljs.com */ import { h } from "./gx-web-controls.core.js";

import { a as BaseComponent } from "./chunk-e6709a3b.js";

var RadioGroup = /** @class */ function(e) {
  function RadioGroup() {
    var o = e.apply(this, arguments) || this;
    return o.radios = [], 
    /**
         * Specifies how the child `gx-radio-option` will be layed out.
         * It supports two values:
         *
         * * `horizontal`
         * * `vertical` (default)
         */
    o.direction = "horizontal", 
    /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
    o.invisibleMode = "collapse", 
    /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
    o.disabled = !1, o;
  }
  return __extends(RadioGroup, e), RadioGroup.prototype.getValueFromEvent = function(e) {
    return e.target && e.target.value;
  }, RadioGroup.prototype.handleChange = function(e) {
    this.value = this.getValueFromEvent(e), this.onChange.emit(e);
  }, RadioGroup.prototype.disabledChanged = function() {
    this.setDisabled();
  }, RadioGroup.prototype.valueChanged = function() {
    var e = this;
    // this radio group's value just changed
    // double check the button with this value is checked
        if (void 0 === this.value) 
    // set to undefined
    // ensure all that are checked become unchecked
    this.radios.filter(function(e) {
      return e.checked;
    }).forEach(function(e) {
      e.checked = !1;
    }); else {
      var o = !1;
      this.radios.forEach(function(t) {
        t.value === e.value ? (t.checked || o ? o && t.checked && (
        // somehow we've got multiple radios
        // with the same value, but only one can be checked
        t.checked = !1) : 
        // correct value for this radio
        // but this radio isn't checked yet
        // and we haven't found a checked yet
        // so CHECK IT!
        t.checked = !0, 
        // remember we've got a checked radio button now
        o = !0) : t.checked && (
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
  }, RadioGroup.prototype.onRadioDidLoad = function(e) {
    var o = e.target;
    this.radios.push(o), o.name = this.name, void 0 !== this.value && o.value === this.value ? 
    // this radio-group has a value and this
    // radio equals the correct radio-group value
    // so let's check this radio
    o.checked = !0 : void 0 === this.value && o.checked ? 
    // this radio-group does not have a value
    // but this radio is checked, so let's set the
    // radio-group's value from the checked radio
    this.value = o.value : o.checked && (
    // if it doesn't match one of the above cases, but the
    // radio is still checked, then we need to uncheck it
    o.checked = !1);
  }, RadioGroup.prototype.onRadioDidUnload = function(e) {
    var o = this.radios.indexOf(e.target);
    o > -1 && this.radios.splice(o, 1);
  }, RadioGroup.prototype.onRadioSelect = function(e) {
    var o = this;
    this.radios.forEach(function(t) {
      t === e.target ? t.value !== o.value && (o.value = t.value) : t.checked = !1;
    });
  }, RadioGroup.prototype.setDisabled = function() {
    var e = this;
    this.radios.forEach(function(o) {
      o.disabled = e.disabled;
    });
  }, RadioGroup.prototype.componentDidLoad = function() {
    this.setDisabled(), this.didLoad = !0;
  }, RadioGroup.prototype.hostData = function() {
    return {
      role: "radiogroup"
    };
  }, RadioGroup.prototype.render = function() {
    return h("slot", null);
  }, Object.defineProperty(RadioGroup, "is", {
    get: function() {
      return "gx-radio-group";
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(RadioGroup, "properties", {
    get: function() {
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
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(RadioGroup, "events", {
    get: function() {
      return [ {
        name: "onChange",
        method: "onChange",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      } ];
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(RadioGroup, "listeners", {
    get: function() {
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
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(RadioGroup, "style", {
    get: function() {
      return "gx-radio-group{display:block}gx-radio-group[hidden]{display:none}gx-radio-group[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}gx-radio-group[direction=horizontal]>gx-radio-option{display:-webkit-inline-box;display:-ms-inline-flexbox;display:inline-flex;margin-right:1rem}";
    },
    enumerable: !0,
    configurable: !0
  }), RadioGroup;
}(BaseComponent);

export { RadioGroup as GxRadioGroup };