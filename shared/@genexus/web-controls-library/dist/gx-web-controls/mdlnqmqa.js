/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

class s extends t {
  constructor() {
    super(...arguments), 
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
  // TODO: Implement touch devices events (Tap, DoubleTap, LongTap, SwipeX)
  handleClick(e) {
    this.disabled || this.onClick.emit(e);
  }
  render() {
    return this.element.addEventListener("click", this.handleClick.bind(this)), e("slot", null);
  }
  static get is() {
    return "gx-canvas";
  }
  static get properties() {
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
  }
  static get events() {
    return [ {
      name: "onClick",
      method: "onClick",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    } ];
  }
  static get style() {
    return "gx-canvas{display:block;position:relative}gx-canvas[hidden]{display:none}gx-canvas[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
  }
}

export { s as GxCanvas };