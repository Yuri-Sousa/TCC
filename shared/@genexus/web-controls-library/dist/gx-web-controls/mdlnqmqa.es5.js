/*! Built with http://stenciljs.com */
var __extends = this && this.__extends || function() {
  var e = Object.setPrototypeOf || {
    __proto__: []
  } instanceof Array && function(e, n) {
    e.__proto__ = n;
  } || function(e, n) {
    for (var t in n) n.hasOwnProperty(t) && (e[t] = n[t]);
  };
  return function(n, t) {
    function __() {
      this.constructor = n;
    }
    e(n, t), n.prototype = null === t ? Object.create(t) : (__.prototype = t.prototype, 
    new __());
  };
}();

/*! Built with http://stenciljs.com */ GxWebControls.loadBundle("mdlnqmqa", [ "exports", "./chunk-440ea385.js" ], function(e, n) {
  var t = window.GxWebControls.h, o = /** @class */ function(e) {
    function Canvas() {
      var n = e.apply(this, arguments) || this;
      /**
             * This attribute lets you specify how this element will behave when hidden.
             *
             * | Value        | Details                                                                     |
             * | ------------ | --------------------------------------------------------------------------- |
             * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
             * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
             */      return n.invisibleMode = "collapse", 
      /**
             * This attribute lets you specify if the element is disabled.
             * If disabled, it will not fire any user interaction related event
             * (for example, click event).
             */
      n.disabled = !1, n;
    }
    // TODO: Implement touch devices events (Tap, DoubleTap, LongTap, SwipeX)
        return __extends(Canvas, e), Canvas.prototype.handleClick = function(e) {
      this.disabled || this.onClick.emit(e);
    }, Canvas.prototype.render = function() {
      return this.element.addEventListener("click", this.handleClick.bind(this)), t("slot", null);
    }, Object.defineProperty(Canvas, "is", {
      get: function() {
        return "gx-canvas";
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(Canvas, "properties", {
      get: function() {
        return {
          disabled: {
            type: Boolean,
            attr: "disabled"
          },
          element: {
            elementRef: !0
          },
          invisibleMode: {
            type: String,
            attr: "invisible-mode"
          }
        };
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(Canvas, "events", {
      get: function() {
        return [ {
          name: "onClick",
          method: "onClick",
          bubbles: !0,
          cancelable: !0,
          composed: !0
        } ];
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(Canvas, "style", {
      get: function() {
        return "gx-canvas{display:block;position:relative}gx-canvas[hidden]{display:none}gx-canvas[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
      },
      enumerable: !0,
      configurable: !0
    }), Canvas;
  }(n.BaseComponent);
  e.GxCanvas = o, Object.defineProperty(e, "__esModule", {
    value: !0
  });
});