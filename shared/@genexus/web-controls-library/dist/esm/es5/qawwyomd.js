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

function TabCaptionRender(e) {
  /** @class */
  return function(e) {
    function class_1() {
      var t = e.apply(this, arguments) || this;
      return t.disabled = !1, t.selected = !1, t;
    }
    return __extends(class_1, e), class_1.prototype.render = function() {
      return this.element.setAttribute("aria-selected", this.selected.toString()), h("a", {
        class: {
          active: this.selected,
          disabled: this.disabled,
          "nav-link": !0
        },
        href: "#",
        onClick: this.clickHandler.bind(this)
      }, h("slot", null));
    }, class_1.prototype.clickHandler = function(e) {
      this.disabled || (e.preventDefault(), this.onTabSelect.emit(e));
    }, class_1;
  }(e);
}

var TabCaption = /** @class */ function(e) {
  function TabCaption() {
    return null !== e && e.apply(this, arguments) || this;
  }
  return __extends(TabCaption, e), TabCaption.prototype.componentWillLoad = function() {
    this.element.id || (this.element.id = "gx-tab-caption-auto-id-" + autoTabId++);
  }, TabCaption.prototype.hostData = function() {
    return {
      role: "tab"
    };
  }, Object.defineProperty(TabCaption, "is", {
    get: function() {
      return "gx-tab-caption";
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(TabCaption, "properties", {
    get: function() {
      return {
        disabled: {
          type: Boolean,
          attr: "disabled"
        },
        element: {
          elementRef: !0
        },
        selected: {
          type: Boolean,
          attr: "selected"
        }
      };
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(TabCaption, "events", {
    get: function() {
      return [ {
        name: "onTabSelect",
        method: "onTabSelect",
        bubbles: !0,
        cancelable: !0,
        composed: !0
      } ];
    },
    enumerable: !0,
    configurable: !0
  }), Object.defineProperty(TabCaption, "style", {
    get: function() {
      return "gx-tab-caption{display:block}gx-tab-caption[hidden]{display:none}gx-tab-caption[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
    },
    enumerable: !0,
    configurable: !0
  }), TabCaption;
}(TabCaptionRender(BaseComponent)), autoTabId = 0;

export { TabCaption as GxTabCaption };