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

/*! Built with http://stenciljs.com */ GxWebControls.loadBundle("syt4hxm1", [ "exports", "./chunk-440ea385.js" ], function(e, t) {
  var n = window.GxWebControls.h, i = /** @class */ function(e) {
    function NavBarLink() {
      var t = e.apply(this, arguments) || this;
      /**
             * Indicates if the navbar item is the active one (for example, when the item represents the current page)
             */      return t.active = !1, 
      /**
             * This attribute lets you specify if the navbar item is disabled.
             */
      t.disabled = !1, 
      /**
             * This attribute lets you specify the URL of the navbar item.
             */
      t.href = "", 
      /**
             * This attribute lets you specify how this element will behave when hidden.
             *
             * | Value        | Details                                                                     |
             * | ------------ | --------------------------------------------------------------------------- |
             * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
             * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
             */
      t.invisibleMode = "collapse", t;
    }
    return __extends(NavBarLink, e), Object.defineProperty(NavBarLink, "is", {
      get: function() {
        return "gx-navbar-link";
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(NavBarLink, "properties", {
      get: function() {
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
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(NavBarLink, "events", {
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
    }), Object.defineProperty(NavBarLink, "style", {
      get: function() {
        return "gx-navbar-link{display:inline}gx-navbar-link[hidden]{display:none}gx-navbar-link[hidden][invisible-mode=keep-space]{display:inline;visibility:hidden}";
      },
      enumerable: !0,
      configurable: !0
    }), NavBarLink;
  }(/** @class */ function(e) {
    function class_1() {
      return null !== e && e.apply(this, arguments) || this;
    }
    return __extends(class_1, e), class_1.prototype.handleClick = function(e) {
      this.disabled || (this.onClick.emit(e), e.preventDefault());
    }, class_1.prototype.render = function() {
      var e;
      return this.element.classList.add("nav-item"), n("a", {
        class: (e = {
          active: this.active,
          disabled: this.disabled,
          "nav-link": !0
        }, e[this.cssClass] = !!this.cssClass, e),
        href: this.href,
        onClick: this.handleClick.bind(this)
      }, n("slot", null));
    }, class_1;
  }(t.BaseComponent));
  e.GxNavbarLink = i, Object.defineProperty(e, "__esModule", {
    value: !0
  });
});