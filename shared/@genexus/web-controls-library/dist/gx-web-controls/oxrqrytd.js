/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: t} = window.GxWebControls;

import { a as e } from "./chunk-e6709a3b.js";

class r extends e {
  constructor() {
    super(...arguments), 
    /**
         * Defines the horizontal aligmnent of the content of the cell.
         */
    this.align = "left", 
    /**
         * Defines the vertical aligmnent of the content of the cell.
         */
    this.valign = "top";
  }
  render() {
    return t("slot", null);
  }
  static get is() {
    return "gx-canvas-cell";
  }
  static get properties() {
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
  }
  static get style() {
    return "gx-canvas-cell{position:absolute;display:-webkit-box;display:-ms-flexbox;display:flex}gx-canvas-cell[hidden]{display:none}gx-canvas-cell[hidden][invisible-mode=keep-space]{display:-webkit-box;display:-ms-flexbox;display:flex;visibility:hidden}gx-canvas-cell[overflow-mode=clip]{overflow:hidden}gx-canvas-cell[overflow-mode=scroll]{overflow:auto}gx-canvas-cell:not([align])>*,gx-canvas-cell[align=left]>*{-webkit-box-flex:1;-ms-flex-positive:1;flex-grow:1}gx-canvas-cell[align=center]{-webkit-box-pack:center;-ms-flex-pack:center;justify-content:center}gx-canvas-cell[align=right]{-webkit-box-pack:end;-ms-flex-pack:end;justify-content:flex-end}gx-canvas-cell[valign=middle]{-webkit-box-align:center;-ms-flex-align:center;align-items:center}gx-canvas-cell[valign=bottom]{-webkit-box-align:end;-ms-flex-align:end;align-items:flex-end}";
  }
}

export { r as GxCanvasCell };