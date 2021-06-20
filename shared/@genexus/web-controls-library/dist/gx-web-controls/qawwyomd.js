/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

class s extends(function(t) {
  return class extends t {
    constructor() {
      super(...arguments), this.disabled = !1, this.selected = !1;
    }
    render() {
      return this.element.setAttribute("aria-selected", this.selected.toString()), e("a", {
        class: {
          active: this.selected,
          disabled: this.disabled,
          "nav-link": !0
        },
        href: "#",
        onClick: this.clickHandler.bind(this)
      }, e("slot", null));
    }
    clickHandler(e) {
      this.disabled || (e.preventDefault(), this.onTabSelect.emit(e));
    }
  };
}(t)){
  componentWillLoad() {
    this.element.id || (this.element.id = `gx-tab-caption-auto-id-${a++}`);
  }
  hostData() {
    return {
      role: "tab"
    };
  }
  static get is() {
    return "gx-tab-caption";
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
      selected: {
        type: Boolean,
        attr: "selected"
      }
    };
  }
  static get events() {
    return [ {
      name: "onTabSelect",
      method: "onTabSelect",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    } ];
  }
  static get style() {
    return "gx-tab-caption{display:block}gx-tab-caption[hidden]{display:none}gx-tab-caption[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
  }
}

let a = 0;

export { s as GxTabCaption };