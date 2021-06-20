/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

class s extends(function(t) {
  return class extends t {
    handleClick(e) {
      this.disabled || (this.onClick.emit(e), e.preventDefault());
    }
    render() {
      return this.element.classList.add("nav-item"), e("a", {
        class: {
          active: this.active,
          disabled: this.disabled,
          "nav-link": !0,
          [this.cssClass]: !!this.cssClass
        },
        href: this.href,
        onClick: this.handleClick.bind(this)
      }, e("slot", null));
    }
  };
}(t)){
  constructor() {
    super(...arguments), 
    /**
         * Indicates if the navbar item is the active one (for example, when the item represents the current page)
         */
    this.active = !1, 
    /**
         * This attribute lets you specify if the navbar item is disabled.
         */
    this.disabled = !1, 
    /**
         * This attribute lets you specify the URL of the navbar item.
         */
    this.href = "", 
    /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
    this.invisibleMode = "collapse";
  }
  static get is() {
    return "gx-navbar-link";
  }
  static get properties() {
    return {
      active: {
        type: Boolean,
        attr: "active"
      },
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
      href: {
        type: String,
        attr: "href"
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
    return "gx-navbar-link{display:inline}gx-navbar-link[hidden]{display:none}gx-navbar-link[hidden][invisible-mode=keep-space]{display:inline;visibility:hidden}";
  }
}

export { s as GxNavbarLink };