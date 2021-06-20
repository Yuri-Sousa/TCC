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

var SelectOption = /** @class */ function(e) {
  function SelectOption() {
    var t = e.apply(this, arguments) || this;
    /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */    return t.disabled = !1, t;
  }
  return __extends(SelectOption, e), SelectOption.prototype.selectedChanged = function(e) {
    e && this.gxSelect.emit({
      select: this
    });
  }, SelectOption.prototype.disabledChanged = function(e) {
    e && this.gxDisable.emit({
      select: this
    });
  }, SelectOption.prototype.valueChanged = function() {
    this.onChange.emit({
      select: this
    });
  }, SelectOption.prototype.componentDidLoad = function() {
    this.gxSelectDidLoad.emit({
      select: this
    });
  }, SelectOption.prototype.componentDidUnload = function() {
    this.gxSelectDidUnload.emit({
      select: this
    });
  }, SelectOption.prototype.hostData = function() {
    return {
      "aria-hidden": "true",
      hidden: !0
    };
  }, SelectOption.prototype.render = function() {
    return h("slot", null);
  }, Object.defineProperty(SelectOption, "is", {
    get: function() {
      return "gx-select-option";
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(SelectOption, "properties", {
    get: function() {
      return {
        cssClass: {
          type: String,
          attr: "css-class"
        },
        disabled: {
          type: Boolean,
          attr: "disabled",
          watchCallbacks: [ "disabledChanged" ]
        },
        selected: {
          type: Boolean,
          attr: "selected",
          mutable: !0,
          watchCallbacks: [ "selectedChanged" ]
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
  }), Object.defineProperty(SelectOption, "events", {
    get: function() {
      return [ {
        name: "onChange",
        method: "onChange",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      }, {
        name: "gxSelect",
        method: "gxSelect",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      }, {
        name: "gxDisable",
        method: "gxDisable",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      }, {
        name: "gxSelectDidLoad",
        method: "gxSelectDidLoad",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      }, {
        name: "gxSelectDidUnload",
        method: "gxSelectDidUnload",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      } ];
    },
    enumerable: !0,
    configurable: !0
  }), SelectOption;
}(BaseComponent);

export { SelectOption as GxSelectOption };