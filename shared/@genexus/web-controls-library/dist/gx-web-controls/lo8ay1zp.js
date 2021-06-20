/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

class a extends t {
  componentWillLoad() {
    this.element.id || (this.element.id = `gx-tab-page-auto-id-${n++}`);
  }
  hostData() {
    return {
      role: "tabpanel",
      tabindex: 0
    };
  }
  render() {
    return e("slot", null);
  }
  static get is() {
    return "gx-tab-page";
  }
  static get properties() {
    return {
      element: {
        elementRef: !0
      }
    };
  }
  static get style() {
    return "gx-tab-page{display:block}gx-tab-page[hidden]{display:none}gx-tab-page[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
  }
}

let n = 0;

export { a as GxTabPage };