/*! Built with http://stenciljs.com */
var __extends = this && this.__extends || function() {
  var e = Object.setPrototypeOf || {
    __proto__: []
  } instanceof Array && function(e, t) {
    e.__proto__ = t;
  } || function(e, t) {
    for (var n in t) t.hasOwnProperty(n) && (e[n] = t[n]);
  };
  return function(t, n) {
    function __() {
      this.constructor = t;
    }
    e(t, n), t.prototype = null === n ? Object.create(n) : (__.prototype = n.prototype, 
    new __());
  };
}();

/*! Built with http://stenciljs.com */ import { h } from "./gx-web-controls.core.js";

import { a as BaseComponent } from "./chunk-e6709a3b.js";

function SelectRender(e) {
  /** @class */
  return function(e) {
    function class_1() {
      var t = e.apply(this, arguments) || this;
      return t.options = [], t.disabled = !1, t;
    }
    return __extends(class_1, e), class_1.prototype.getNativeInputId = function() {
      return this.nativeSelect.id;
    }, class_1.prototype.getCssClasses = function() {
      var e = [];
      return this.readonly ? e.push("form-control-plaintext") : e.push("custom-select"), 
      this.cssClass && e.push(this.cssClass), e.join(" ");
    }, class_1.prototype.getReadonlyTextContent = function() {
      var e = this, t = this.options.filter(function(t) {
        return t.value === e.value;
      });
      return t.length > 0 ? t[0].innerText : "";
    }, class_1.prototype.getValueFromEvent = function(e) {
      return e.target && e.target.value;
    }, class_1.prototype.handleChange = function(e) {
      this.value = this.getValueFromEvent(e), this.onChange.emit(e);
    }, class_1.prototype.componentDidUnload = function() {
      this.nativeSelect = null;
    }, class_1.prototype.render = function() {
      var e = this;
      if (this.selectId || (this.selectId = this.id ? this.id + "__select" : "gx-select-auto-id-" + autoSelectId++), 
      this.readonly) return h("span", {
        class: this.getCssClasses()
      }, this.getReadonlyTextContent());
      var t = {
        "aria-disabled": this.disabled ? "true" : void 0,
        class: this.getCssClasses(),
        disabled: this.disabled,
        id: this.selectId,
        onChange: this.handleChange.bind(this),
        ref: function(t) {
          t.value = e.value, e.nativeSelect = t;
        }
      };
      return h("select", Object.assign({}, t), this.options.map(function(e) {
        var t = e.disabled, n = e.innerText, o = e.selected, i = e.value;
        return h("option", {
          disabled: t,
          selected: o,
          value: i
        }, n);
      }));
    }, class_1;
  }(e);
}

var autoSelectId = 0, Select = /** @class */ function(e) {
  function Select() {
    var t = e.apply(this, arguments) || this;
    return t.options = [], 
    /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
    t.invisibleMode = "collapse", 
    /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
    t.disabled = !1, t;
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
    return __extends(Select, e), Select.prototype.getChildOptions = function() {
    return Array.from(this.element.querySelectorAll("gx-select-option")).map(function(e) {
      return {
        disabled: null !== e.getAttribute("disabled"),
        innerText: e.innerText,
        selected: null !== e.getAttribute("selected"),
        value: e.value
      };
    });
  }, Select.prototype.valueChanged = function() {
    var e = this;
    // this select's value just changed
    // double check the option with this value is selected
        if (void 0 === this.value) 
    // set to undefined
    // ensure all that are checked become unchecked
    this.options.filter(function(e) {
      return e.selected;
    }).forEach(function(e) {
      e.selected = !1;
    }); else {
      var t = !1;
      this.options.forEach(function(n) {
        n.value === e.value ? (n.selected || t ? t && n.selected && (
        // somehow we've got multiple options
        // with the same value, but only one can be selected
        n.selected = !1) : 
        // correct value for this option
        // but this option isn't selected yet
        // and we haven't found a selected yet
        // so SELECT IT!
        n.selected = !0, 
        // remember we've got a selected option now
        t = !0) : n.selected && (
        // this option doesn't have the correct value
        // and it's also selected, so let's unselect it
        n.selected = !1);
      });
    }
    this.didLoad && 
    // emit the new value
    this.onChange.emit({
      value: this.value
    });
  }, Select.prototype.onSelectOptionDidLoad = function(e) {
    var t = e.target;
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
  }, Select.prototype.onSelectOptionDidUnload = function() {
    this.options = this.getChildOptions();
  }, Select.prototype.onSelectOptionDisable = function() {
    this.options = this.getChildOptions();
  }, Select.prototype.onSelectOptionChange = function() {
    this.options = this.getChildOptions();
  }, Select.prototype.onSelectOptionSelect = function(e) {
    var t = this;
    this.options.forEach(function(n) {
      n === e.target ? n.value !== t.value && (t.value = n.value) : n.selected = !1;
    });
  }, 
  /**
     * Returns the id of the inner `input` element (if set).
     */
  Select.prototype.getNativeInputId = function() {
    return e.prototype.getNativeInputId.call(this);
  }, Select.prototype.setDisabled = function() {
    var e = this;
    this.options.forEach(function(t) {
      t.disabled = e.disabled;
    });
  }, Select.prototype.componentDidLoad = function() {
    this.setDisabled(), this.didLoad = !0;
  }, Select.prototype.hostData = function() {
    return {
      role: "combobox"
    };
  }, Object.defineProperty(Select, "is", {
    get: function() {
      return "gx-select";
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(Select, "properties", {
    get: function() {
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
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(Select, "events", {
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
  }), Object.defineProperty(Select, "listeners", {
    get: function() {
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
    },
    enumerable: !0,
    configurable: !0
  }), Select;
}(SelectRender(BaseComponent));

export { Select as GxSelect };