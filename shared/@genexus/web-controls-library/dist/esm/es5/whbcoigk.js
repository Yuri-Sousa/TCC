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

function PasswordEditRender(e) {
  /** @class */
  return function(e) {
    function class_1() {
      var t = e.apply(this, arguments) || this;
      return t.disabled = !1, t.revealed = !1, t;
    }
    return __extends(class_1, e), class_1.prototype.getNativeInputId = function() {
      return this.innerEdit.getNativeInputId();
    }, class_1.prototype.getValueFromEvent = function(e) {
      return e.target && e.target.value;
    }, class_1.prototype.handleChange = function(e) {
      this.value = this.getValueFromEvent(e), this.onChange.emit(e);
    }, class_1.prototype.handleInput = function(e) {
      this.value = this.getValueFromEvent(e), this.onInput.emit(e);
    }, class_1.prototype.handleTriggerClick = function() {
      this.innerEdit.type = this.revealed ? "text" : "password";
    }, 
    /**
         * Update the native input element when the value changes
         */
    class_1.prototype.valueChanged = function() {
      var e = this.innerEdit;
      e && e.value !== this.value && (e.value = this.value);
    }, class_1.prototype.componentDidUnload = function() {
      this.innerEdit = null;
    }, class_1.prototype.render = function() {
      var e = this;
      return h("gx-edit", {
        ref: function(t) {
          return e.innerEdit = t;
        },
        "css-class": this.cssClass,
        disabled: this.disabled,
        id: this.id,
        placeholder: this.placeholder,
        readonly: this.readonly,
        "show-trigger": !this.readonly && this.showRevealButton,
        "trigger-class": this.revealed ? "active" : "",
        "trigger-text": this.revealed ? this.revealButtonTextOff : this.revealButtonTextOn,
        type: this.revealed ? "text" : "password",
        value: this.value,
        onChange: this.handleChange.bind(this),
        onInput: this.handleInput.bind(this)
      }, h("i", {
        class: "fa fa-eye" + (this.revealed ? "-slash" : ""),
        slot: "trigger-content"
      }));
    }, class_1;
  }(e);
}

var PasswordEdit = /** @class */ function(e) {
  function PasswordEdit() {
    var t = e.apply(this, arguments) || this;
    /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */    return t.invisibleMode = "collapse", 
    /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
    t.disabled = !1, t.revealed = !1, t;
  }
  /**
     * Returns the id of the inner `input` element (if set).
     */  return __extends(PasswordEdit, e), PasswordEdit.prototype.getNativeInputId = function() {
    return e.prototype.getNativeInputId.call(this);
  }, PasswordEdit.prototype.valueChanged = function() {
    e.prototype.valueChanged.call(this);
  }, PasswordEdit.prototype.handleTriggerClick = function() {
    this.revealed = !this.revealed, e.prototype.handleTriggerClick.call(this);
  }, Object.defineProperty(PasswordEdit, "is", {
    get: function() {
      return "gx-password-edit";
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(PasswordEdit, "properties", {
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
        placeholder: {
          type: String,
          attr: "placeholder"
        },
        readonly: {
          type: Boolean,
          attr: "readonly"
        },
        revealButtonTextOff: {
          type: String,
          attr: "reveal-button-text-off"
        },
        revealButtonTextOn: {
          type: String,
          attr: "reveal-button-text-on"
        },
        revealed: {
          state: !0
        },
        showRevealButton: {
          type: Boolean,
          attr: "show-reveal-button"
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
  }), Object.defineProperty(PasswordEdit, "events", {
    get: function() {
      return [ {
        name: "onChange",
        method: "onChange",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      }, {
        name: "onInput",
        method: "onInput",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      } ];
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(PasswordEdit, "listeners", {
    get: function() {
      return [ {
        name: "gxTriggerClick",
        method: "handleTriggerClick"
      } ];
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(PasswordEdit, "style", {
    get: function() {
      return "gx-edit{display:block}gx-edit[hidden]{display:none}gx-edit[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
    },
    enumerable: !0,
    configurable: !0
  }), PasswordEdit;
}(PasswordEditRender(BaseComponent));

export { PasswordEdit as GxPasswordEdit };