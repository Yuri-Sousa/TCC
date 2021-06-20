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

/*! Built with http://stenciljs.com */ GxWebControls.loadBundle("oxrqrytd", [ "exports", "./chunk-440ea385.js" ], function(e, n) {
  var t = window.GxWebControls.h, r = /** @class */ function(e) {
    function CanvasCell() {
      var n = e.apply(this, arguments) || this;
      /**
             * Defines the horizontal aligmnent of the content of the cell.
             */      return n.align = "left", 
      /**
             * Defines the vertical aligmnent of the content of the cell.
             */
      n.valign = "top", n;
    }
    return __extends(CanvasCell, e), CanvasCell.prototype.render = function() {
      return t("slot", null);
    }, Object.defineProperty(CanvasCell, "is", {
      get: function() {
        return "gx-canvas-cell";
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(CanvasCell, "properties", {
      get: function() {
        return {
          align: {
            type: String,
            attr: "align"
          },
          element: {
            elementRef: !0
          },
          overflowMode: {
            type: String,
            attr: "overflow-mode"
          },
          valign: {
            type: String,
            attr: "valign"
          }
        };
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(CanvasCell, "style", {
      get: function() {
        return "gx-canvas-cell{position:absolute;display:-webkit-box;display:-ms-flexbox;display:flex}gx-canvas-cell[hidden]{display:none}gx-canvas-cell[hidden][invisible-mode=keep-space]{display:-webkit-box;display:-ms-flexbox;display:flex;visibility:hidden}gx-canvas-cell[overflow-mode=clip]{overflow:hidden}gx-canvas-cell[overflow-mode=scroll]{overflow:auto}gx-canvas-cell:not([align])>*,gx-canvas-cell[align=left]>*{-webkit-box-flex:1;-ms-flex-positive:1;flex-grow:1}gx-canvas-cell[align=center]{-webkit-box-pack:center;-ms-flex-pack:center;justify-content:center}gx-canvas-cell[align=right]{-webkit-box-pack:end;-ms-flex-pack:end;justify-content:flex-end}gx-canvas-cell[valign=middle]{-webkit-box-align:center;-ms-flex-align:center;align-items:center}gx-canvas-cell[valign=bottom]{-webkit-box-align:end;-ms-flex-align:end;align-items:flex-end}";
      },
      enumerable: !0,
      configurable: !0
    }), CanvasCell;
  }(n.BaseComponent);
  e.GxCanvasCell = r, Object.defineProperty(e, "__esModule", {
    value: !0
  });
});