/*! Built with http://stenciljs.com */
var __extends = this && this.__extends || function() {
  var e = Object.setPrototypeOf || {
    __proto__: []
  } instanceof Array && function(e, t) {
    e.__proto__ = t;
  } || function(e, t) {
    for (var o in t) t.hasOwnProperty(o) && (e[o] = t[o]);
  };
  return function(t, o) {
    function __() {
      this.constructor = t;
    }
    e(t, o), t.prototype = null === o ? Object.create(o) : (__.prototype = o.prototype, 
    new __());
  };
}();

/*! Built with http://stenciljs.com */ GxWebControls.loadBundle("vhgopzpp", [ "exports", "./chunk-7e7496b6.js", "./chunk-440ea385.js" ], function(e, t, o) {
  for (var r = window.GxWebControls.h, n = "undefined" != typeof window && "undefined" != typeof document, i = [ "Edge", "Trident", "Firefox" ], s = 0, a = 0
  /**!
     * @fileOverview Kickass library to create and place poppers near their reference elements.
     * @version 1.14.3
     * @license
     * Copyright (c) 2016 Federico Zivolo and contributors
     *
     * Permission is hereby granted, free of charge, to any person obtaining a copy
     * of this software and associated documentation files (the "Software"), to deal
     * in the Software without restriction, including without limitation the rights
     * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
     * copies of the Software, and to permit persons to whom the Software is
     * furnished to do so, subject to the following conditions:
     *
     * The above copyright notice and this permission notice shall be included in all
     * copies or substantial portions of the Software.
     *
     * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
     * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
     * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
     * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
     * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
     * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
     * SOFTWARE.
     */; a < i.length; a += 1) if (n && navigator.userAgent.indexOf(i[a]) >= 0) {
    s = 1;
    break;
  }
  var l = n && window.Promise ? function(e) {
    var t = !1;
    return function() {
      t || (t = !0, window.Promise.resolve().then(function() {
        t = !1, e();
      }));
    };
  } : function(e) {
    var t = !1;
    return function() {
      t || (t = !0, setTimeout(function() {
        t = !1, e();
      }, s));
    };
  };
  /**
    * Create a debounced version of a method, that's asynchronously deferred
    * but called in the minimum time possible.
    *
    * @method
    * @memberof Popper.Utils
    * @argument {Function} fn
    * @returns {Function}
    */  
  /**
     * Check if the given variable is a function
     * @method
     * @memberof Popper.Utils
     * @argument {Any} functionToCheck - variable to check
     * @returns {Boolean} answer to: is a function?
     */
  function isFunction(e) {
    return e && "[object Function]" === {}.toString.call(e);
  }
  /**
     * Get CSS computed property of the given element
     * @method
     * @memberof Popper.Utils
     * @argument {Eement} element
     * @argument {String} property
     */  function getStyleComputedProperty(e, t) {
    if (1 !== e.nodeType) return [];
    // NOTE: 1 DOM access here
        var o = getComputedStyle(e, null);
    return t ? o[t] : o;
  }
  /**
     * Returns the parentNode or the host of the element
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @returns {Element} parent
     */  function getParentNode(e) {
    return "HTML" === e.nodeName ? e : e.parentNode || e.host;
  }
  /**
     * Returns the scrolling parent of the given element
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @returns {Element} scroll parent
     */  function getScrollParent(e) {
    // Return body, `getScroll` will take care to get the correct `scrollTop` from it
    if (!e) return document.body;
    switch (e.nodeName) {
     case "HTML":
     case "BODY":
      return e.ownerDocument.body;

     case "#document":
      return e.body;
    }
    // Firefox want us to check `-x` and `-y` variations as well
        var t = getStyleComputedProperty(e), o = t.overflow, r = t.overflowX, n = t.overflowY;
    return /(auto|scroll|overlay)/.test(o + n + r) ? e : getScrollParent(getParentNode(e));
  }
  var f = n && !(!window.MSInputMethodContext || !document.documentMode), p = n && /MSIE 10/.test(navigator.userAgent);
  /**
     * Determines if the browser is Internet Explorer
     * @method
     * @memberof Popper.Utils
     * @param {Number} version to check
     * @returns {Boolean} isIE
     */
  function isIE(e) {
    return 11 === e ? f : 10 === e ? p : f || p;
  }
  /**
     * Returns the offset parent of the given element
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @returns {Element} offset parent
     */  function getOffsetParent(e) {
    if (!e) return document.documentElement;
    // Skip hidden elements which don't have an offsetParent
    for (var t = isIE(10) ? document.body : null, o = e.offsetParent
    // NOTE: 1 DOM access here
    ; o === t && e.nextElementSibling; ) o = (e = e.nextElementSibling).offsetParent;
    var r = o && o.nodeName;
    return r && "BODY" !== r && "HTML" !== r ? 
    // .offsetParent will return the closest TD or TABLE in case
    // no offsetParent is present, I hate this job...
    -1 !== [ "TD", "TABLE" ].indexOf(o.nodeName) && "static" === getStyleComputedProperty(o, "position") ? getOffsetParent(o) : o : e ? e.ownerDocument.documentElement : document.documentElement;
  }
  /**
     * Finds the root node (document, shadowDOM root) of the given element
     * @method
     * @memberof Popper.Utils
     * @argument {Element} node
     * @returns {Element} root node
     */
  function getRoot(e) {
    return null !== e.parentNode ? getRoot(e.parentNode) : e;
  }
  /**
     * Finds the offset parent common to the two provided nodes
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element1
     * @argument {Element} element2
     * @returns {Element} common offset parent
     */  function findCommonOffsetParent(e, t) {
    // This check is needed to avoid errors in case one of the elements isn't defined for any reason
    if (!(e && e.nodeType && t && t.nodeType)) return document.documentElement;
    // Here we make sure to give as "start" the element that comes first in the DOM
        var o = e.compareDocumentPosition(t) & Node.DOCUMENT_POSITION_FOLLOWING, r = o ? e : t, n = o ? t : e, i = document.createRange();
    i.setStart(r, 0), i.setEnd(n, 0);
    var s, a, l = i.commonAncestorContainer;
    // Both nodes are inside #document
        if (e !== l && t !== l || r.contains(n)) return "BODY" === (a = (s = l).nodeName) || "HTML" !== a && getOffsetParent(s.firstElementChild) !== s ? getOffsetParent(l) : l;
    // one of the nodes is inside shadowDOM, find which one
        var f = getRoot(e);
    return f.host ? findCommonOffsetParent(f.host, t) : findCommonOffsetParent(e, getRoot(t).host);
  }
  /**
     * Gets the scroll value of the given element in the given side (top and left)
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @argument {String} side `top` or `left`
     * @returns {number} amount of scrolled pixels
     */  function getScroll(e) {
    var t = "top" === (arguments.length > 1 && void 0 !== arguments[1] ? arguments[1] : "top") ? "scrollTop" : "scrollLeft", o = e.nodeName;
    if ("BODY" === o || "HTML" === o) {
      var r = e.ownerDocument.documentElement;
      return (e.ownerDocument.scrollingElement || r)[t];
    }
    return e[t];
  }
  /*
     * Sum or subtract the element scroll values (left and top) from a given rect object
     * @method
     * @memberof Popper.Utils
     * @param {Object} rect - Rect object you want to change
     * @param {HTMLElement} element - The element from the function reads the scroll values
     * @param {Boolean} subtract - set to true if you want to subtract the scroll values
     * @return {Object} rect - The modifier rect object
     */  
  /*
     * Helper to detect borders of a given element
     * @method
     * @memberof Popper.Utils
     * @param {CSSStyleDeclaration} styles
     * Result of `getStyleComputedProperty` on the given element
     * @param {String} axis - `x` or `y`
     * @return {number} borders - The borders size of the given axis
     */
  function getBordersSize(e, t) {
    var o = "x" === t ? "Left" : "Top", r = "Left" === o ? "Right" : "Bottom";
    return parseFloat(e["border" + o + "Width"], 10) + parseFloat(e["border" + r + "Width"], 10);
  }
  function getSize(e, t, o, r) {
    return Math.max(t["offset" + e], t["scroll" + e], o["client" + e], o["offset" + e], o["scroll" + e], isIE(10) ? o["offset" + e] + r["margin" + ("Height" === e ? "Top" : "Left")] + r["margin" + ("Height" === e ? "Bottom" : "Right")] : 0);
  }
  function getWindowSizes() {
    var e = document.body, t = document.documentElement, o = isIE(10) && getComputedStyle(t);
    return {
      height: getSize("Height", e, t, o),
      width: getSize("Width", e, t, o)
    };
  }
  var c = function(e, t) {
    if (!(e instanceof t)) throw new TypeError("Cannot call a class as a function");
  }, d = function() {
    function defineProperties(e, t) {
      for (var o = 0; o < t.length; o++) {
        var r = t[o];
        r.enumerable = r.enumerable || !1, r.configurable = !0, "value" in r && (r.writable = !0), 
        Object.defineProperty(e, r.key, r);
      }
    }
    return function(e, t, o) {
      return t && defineProperties(e.prototype, t), o && defineProperties(e, o), e;
    };
  }(), u = function(e, t, o) {
    return t in e ? Object.defineProperty(e, t, {
      value: o,
      enumerable: !0,
      configurable: !0,
      writable: !0
    }) : e[t] = o, e;
  }, h = Object.assign || function(e) {
    for (var t = 1; t < arguments.length; t++) {
      var o = arguments[t];
      for (var r in o) Object.prototype.hasOwnProperty.call(o, r) && (e[r] = o[r]);
    }
    return e;
  };
  /**
     * Given element offsets, generate an output similar to getBoundingClientRect
     * @method
     * @memberof Popper.Utils
     * @argument {Object} offsets
     * @returns {Object} ClientRect like output
     */
  function getClientRect(e) {
    return h({}, e, {
      right: e.left + e.width,
      bottom: e.top + e.height
    });
  }
  /**
     * Get bounding client rect of given element
     * @method
     * @memberof Popper.Utils
     * @param {HTMLElement} element
     * @return {Object} client rect
     */  function getBoundingClientRect(e) {
    var t = {};
    // IE10 10 FIX: Please, don't ask, the element isn't
    // considered in DOM in some circumstances...
    // This isn't reproducible in IE10 compatibility mode of IE11
        try {
      if (isIE(10)) {
        t = e.getBoundingClientRect();
        var o = getScroll(e, "top"), r = getScroll(e, "left");
        t.top += o, t.left += r, t.bottom += o, t.right += r;
      } else t = e.getBoundingClientRect();
    } catch (e) {}
    var n = {
      left: t.left,
      top: t.top,
      width: t.right - t.left,
      height: t.bottom - t.top
    }, i = "HTML" === e.nodeName ? getWindowSizes() : {}, s = i.width || e.clientWidth || n.right - n.left, a = i.height || e.clientHeight || n.bottom - n.top, l = e.offsetWidth - s, f = e.offsetHeight - a;
    // subtract scrollbar size from sizes
        // if an hypothetical scrollbar is detected, we must be sure it's not a `border`
    // we make this check conditional for performance reasons
    if (l || f) {
      var p = getStyleComputedProperty(e);
      l -= getBordersSize(p, "x"), f -= getBordersSize(p, "y"), n.width -= l, n.height -= f;
    }
    return getClientRect(n);
  }
  function getOffsetRectRelativeToArbitraryNode(e, t) {
    var o = arguments.length > 2 && void 0 !== arguments[2] && arguments[2], r = isIE(10), n = "HTML" === t.nodeName, i = getBoundingClientRect(e), s = getBoundingClientRect(t), a = getScrollParent(e), l = getStyleComputedProperty(t), f = parseFloat(l.borderTopWidth, 10), p = parseFloat(l.borderLeftWidth, 10);
    // In cases where the parent is fixed, we must ignore negative scroll in offset calc
    o && "HTML" === t.nodeName && (s.top = Math.max(s.top, 0), s.left = Math.max(s.left, 0));
    var c = getClientRect({
      top: i.top - s.top - f,
      left: i.left - s.left - p,
      width: i.width,
      height: i.height
    });
    // Subtract margins of documentElement in case it's being used as parent
    // we do this only on HTML because it's the only element that behaves
    // differently when margins are applied to it. The margins are included in
    // the box of the documentElement, in the other cases not.
    if (c.marginTop = 0, c.marginLeft = 0, !r && n) {
      var d = parseFloat(l.marginTop, 10), u = parseFloat(l.marginLeft, 10);
      c.top -= f - d, c.bottom -= f - d, c.left -= p - u, c.right -= p - u, 
      // Attach marginTop and marginLeft because in some circumstances we may need them
      c.marginTop = d, c.marginLeft = u;
    }
    return (r && !o ? t.contains(a) : t === a && "BODY" !== a.nodeName) && (c = function(e, t) {
      var o = arguments.length > 2 && void 0 !== arguments[2] && arguments[2], r = getScroll(t, "top"), n = getScroll(t, "left"), i = o ? -1 : 1;
      return e.top += r * i, e.bottom += r * i, e.left += n * i, e.right += n * i, e;
    }(c, t)), c;
  }
  /**
     * Finds the first parent of an element that has a transformed property defined
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @returns {Element} first transformed parent or documentElement
     */
  function getFixedPositionOffsetParent(e) {
    // This check is needed to avoid errors in case one of the elements isn't defined for any reason
    if (!e || !e.parentElement || isIE()) return document.documentElement;
    for (var t = e.parentElement; t && "none" === getStyleComputedProperty(t, "transform"); ) t = t.parentElement;
    return t || document.documentElement;
  }
  /**
     * Computed the boundaries limits and return them
     * @method
     * @memberof Popper.Utils
     * @param {HTMLElement} popper
     * @param {HTMLElement} reference
     * @param {number} padding
     * @param {HTMLElement} boundariesElement - Element used to define the boundaries
     * @param {Boolean} fixedPosition - Is in fixed position mode
     * @returns {Object} Coordinates of the boundaries
     */  function getBoundaries(e, t, o, r) {
    var n = arguments.length > 4 && void 0 !== arguments[4] && arguments[4], i = {
      top: 0,
      left: 0
    }, s = n ? getFixedPositionOffsetParent(e) : findCommonOffsetParent(e, t);
    // NOTE: 1 DOM access here
        // Handle viewport case
    if ("viewport" === r) i = function(e) {
      var t = arguments.length > 1 && void 0 !== arguments[1] && arguments[1], o = e.ownerDocument.documentElement, r = getOffsetRectRelativeToArbitraryNode(e, o), n = Math.max(o.clientWidth, window.innerWidth || 0), i = Math.max(o.clientHeight, window.innerHeight || 0), s = t ? 0 : getScroll(o), a = t ? 0 : getScroll(o, "left");
      return getClientRect({
        top: s - r.top + r.marginTop,
        left: a - r.left + r.marginLeft,
        width: n,
        height: i
      });
    }
    /**
     * Check if the given element is fixed or is inside a fixed parent
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @argument {Element} customContainer
     * @returns {Boolean} answer to "isFixed?"
     */ (s, n); else {
      // Handle other cases based on DOM element used as boundaries
      var a = void 0;
      "scrollParent" === r ? "BODY" === (a = getScrollParent(getParentNode(t))).nodeName && (a = e.ownerDocument.documentElement) : a = "window" === r ? e.ownerDocument.documentElement : r;
      var l = getOffsetRectRelativeToArbitraryNode(a, s, n);
      // In case of HTML, we need a different computation
            if ("HTML" !== a.nodeName || function isFixed(e) {
        var t = e.nodeName;
        return "BODY" !== t && "HTML" !== t && ("fixed" === getStyleComputedProperty(e, "position") || isFixed(getParentNode(e)));
      }(s)) 
      // for all the other DOM elements, this one is good
      i = l; else {
        var f = getWindowSizes(), p = f.height, c = f.width;
        i.top += l.top - l.marginTop, i.bottom = p + l.top, i.left += l.left - l.marginLeft, 
        i.right = c + l.left;
      }
    }
    // Add paddings
        return i.left += o, i.top += o, i.right -= o, i.bottom -= o, i;
  }
  /**
     * Utility used to transform the `auto` placement to the placement with more
     * available space.
     * @method
     * @memberof Popper.Utils
     * @argument {Object} data - The data object generated by update method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */
  function computeAutoPlacement(e, t, o, r, n) {
    var i = arguments.length > 5 && void 0 !== arguments[5] ? arguments[5] : 0;
    if (-1 === e.indexOf("auto")) return e;
    var s = getBoundaries(o, r, i, n), a = {
      top: {
        width: s.width,
        height: t.top - s.top
      },
      right: {
        width: s.right - t.right,
        height: s.height
      },
      bottom: {
        width: s.width,
        height: s.bottom - t.bottom
      },
      left: {
        width: t.left - s.left,
        height: s.height
      }
    }, l = Object.keys(a).map(function(e) {
      return h({
        key: e
      }, a[e], {
        area: (t = a[e], t.width * t.height)
      });
      var t;
    }).sort(function(e, t) {
      return t.area - e.area;
    }), f = l.filter(function(e) {
      var t = e.width, r = e.height;
      return t >= o.clientWidth && r >= o.clientHeight;
    }), p = f.length > 0 ? f[0].key : l[0].key, c = e.split("-")[1];
    return p + (c ? "-" + c : "");
  }
  /**
     * Get offsets to the reference element
     * @method
     * @memberof Popper.Utils
     * @param {Object} state
     * @param {Element} popper - the popper element
     * @param {Element} reference - the reference element (the popper will be relative to this)
     * @param {Element} fixedPosition - is in fixed position mode
     * @returns {Object} An object containing the offsets which will be applied to the popper
     */  function getReferenceOffsets(e, t, o) {
    var r = arguments.length > 3 && void 0 !== arguments[3] ? arguments[3] : null;
    return getOffsetRectRelativeToArbitraryNode(o, r ? getFixedPositionOffsetParent(t) : findCommonOffsetParent(t, o), r);
  }
  /**
     * Get the outer sizes of the given element (offset size + margins)
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element
     * @returns {Object} object containing width and height properties
     */  function getOuterSizes(e) {
    var t = getComputedStyle(e), o = parseFloat(t.marginTop) + parseFloat(t.marginBottom), r = parseFloat(t.marginLeft) + parseFloat(t.marginRight);
    return {
      width: e.offsetWidth + r,
      height: e.offsetHeight + o
    };
  }
  /**
     * Get the opposite placement of the given one
     * @method
     * @memberof Popper.Utils
     * @argument {String} placement
     * @returns {String} flipped placement
     */  function getOppositePlacement(e) {
    var t = {
      left: "right",
      right: "left",
      bottom: "top",
      top: "bottom"
    };
    return e.replace(/left|right|bottom|top/g, function(e) {
      return t[e];
    });
  }
  /**
     * Get offsets to the popper
     * @method
     * @memberof Popper.Utils
     * @param {Object} position - CSS position the Popper will get applied
     * @param {HTMLElement} popper - the popper element
     * @param {Object} referenceOffsets - the reference offsets (the popper will be relative to this)
     * @param {String} placement - one of the valid placement options
     * @returns {Object} popperOffsets - An object containing the offsets which will be applied to the popper
     */  function getPopperOffsets(e, t, o) {
    o = o.split("-")[0];
    // Get popper node sizes
    var r = getOuterSizes(e), n = {
      width: r.width,
      height: r.height
    }, i = -1 !== [ "right", "left" ].indexOf(o), s = i ? "top" : "left", a = i ? "left" : "top", l = i ? "height" : "width", f = i ? "width" : "height";
    // Add position, width and height to our offsets object
        return n[s] = t[s] + t[l] / 2 - r[l] / 2, n[a] = o === a ? t[a] - r[f] : t[getOppositePlacement(a)], 
    n;
  }
  /**
     * Mimics the `find` method of Array
     * @method
     * @memberof Popper.Utils
     * @argument {Array} arr
     * @argument prop
     * @argument value
     * @returns index or -1
     */  function find(e, t) {
    // use native find if supported
    return Array.prototype.find ? e.find(t) : e.filter(t)[0];
    // use `filter` to obtain the same behavior of `find`
    }
  /**
     * Return the index of the matching object
     * @method
     * @memberof Popper.Utils
     * @argument {Array} arr
     * @argument prop
     * @argument value
     * @returns index or -1
     */  
  /**
     * Loop trough the list of modifiers and run them in order,
     * each of them will then edit the data object.
     * @method
     * @memberof Popper.Utils
     * @param {dataObject} data
     * @param {Array} modifiers
     * @param {String} ends - Optional modifier name used as stopper
     * @returns {dataObject}
     */
  function runModifiers(e, t, o) {
    return (void 0 === o ? e : e.slice(0, function(e, t, o) {
      // use native findIndex if supported
      if (Array.prototype.findIndex) return e.findIndex(function(e) {
        return e.name === o;
      });
      // use `find` + `indexOf` if `findIndex` isn't supported
            var r = find(e, function(e) {
        return e.name === o;
      });
      return e.indexOf(r);
    }(e, 0, o))).forEach(function(e) {
      e.function && 
      // eslint-disable-line dot-notation
      console.warn("`modifier.function` is deprecated, use `modifier.fn`!");
      var o = e.function || e.fn;
 // eslint-disable-line dot-notation
            e.enabled && isFunction(o) && (
      // Add properties to offsets to make them a complete clientRect object
      // we do this before each modifier to make sure the previous one doesn't
      // mess with these values
      t.offsets.popper = getClientRect(t.offsets.popper), t.offsets.reference = getClientRect(t.offsets.reference), 
      t = o(t, e));
    }), t;
  }
  /**
     * Updates the position of the popper, computing the new offsets and applying
     * the new style.<br />
     * Prefer `scheduleUpdate` over `update` because of performance reasons.
     * @method
     * @memberof Popper
     */  
  /**
     * Helper used to know if the given modifier is enabled.
     * @method
     * @memberof Popper.Utils
     * @returns {Boolean}
     */
  function isModifierEnabled(e, t) {
    return e.some(function(e) {
      var o = e.name;
      return e.enabled && o === t;
    });
  }
  /**
     * Get the prefixed supported property name
     * @method
     * @memberof Popper.Utils
     * @argument {String} property (camelCase)
     * @returns {String} prefixed property (camelCase or PascalCase, depending on the vendor prefix)
     */  function getSupportedPropertyName(e) {
    for (var t = [ !1, "ms", "Webkit", "Moz", "O" ], o = e.charAt(0).toUpperCase() + e.slice(1), r = 0; r < t.length; r++) {
      var n = t[r], i = n ? "" + n + o : e;
      if (void 0 !== document.body.style[i]) return i;
    }
    return null;
  }
  /**
     * Destroy the popper
     * @method
     * @memberof Popper
     */  
  /**
     * Get the window associated with the element
     * @argument {Element} element
     * @returns {Window}
     */
  function getWindow(e) {
    var t = e.ownerDocument;
    return t ? t.defaultView : window;
  }
  /**
     * Tells if a given input is a number
     * @method
     * @memberof Popper.Utils
     * @param {*} input to check
     * @return {Boolean}
     */
  function isNumeric(e) {
    return "" !== e && !isNaN(parseFloat(e)) && isFinite(e);
  }
  /**
     * Set the style to the given popper
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element - Element to apply the style to
     * @argument {Object} styles
     * Object with a list of properties and values which will be applied to the element
     */  function setStyles(e, t) {
    Object.keys(t).forEach(function(o) {
      var r = "";
      // add unit if the value is numeric and is one of the following
            -1 !== [ "width", "height", "top", "right", "bottom", "left" ].indexOf(o) && isNumeric(t[o]) && (r = "px"), 
      e.style[o] = t[o] + r;
    });
  }
  /**
     * Set the attributes to the given popper
     * @method
     * @memberof Popper.Utils
     * @argument {Element} element - Element to apply the attributes to
     * @argument {Object} styles
     * Object with a list of properties and values which will be applied to the element
     */  
  /**
     * Helper used to know if the given modifier depends from another one.<br />
     * It checks if the needed modifier is listed and enabled.
     * @method
     * @memberof Popper.Utils
     * @param {Array} modifiers - list of modifiers
     * @param {String} requestingName - name of requesting modifier
     * @param {String} requestedName - name of requested modifier
     * @returns {Boolean}
     */
  function isModifierRequired(e, t, o) {
    var r = find(e, function(e) {
      return e.name === t;
    }), n = !!r && e.some(function(e) {
      return e.name === o && e.enabled && e.order < r.order;
    });
    if (!n) {
      var i = "`" + t + "`", s = "`" + o + "`";
      console.warn(s + " modifier is required by " + i + " modifier in order to work, be sure to include it before " + i + "!");
    }
    return n;
  }
  /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by update method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */  
  /**
     * List of accepted placements to use as values of the `placement` option.<br />
     * Valid placements are:
     * - `auto`
     * - `top`
     * - `right`
     * - `bottom`
     * - `left`
     *
     * Each placement can have a variation from this list:
     * - `-start`
     * - `-end`
     *
     * Variations are interpreted easily if you think of them as the left to right
     * written languages. Horizontally (`top` and `bottom`), `start` is left and `end`
     * is right.<br />
     * Vertically (`left` and `right`), `start` is top and `end` is bottom.
     *
     * Some valid examples are:
     * - `top-end` (on top of reference, right aligned)
     * - `right-start` (on right of reference, top aligned)
     * - `bottom` (on bottom, centered)
     * - `auto-right` (on the side with more space available, alignment depends by placement)
     *
     * @static
     * @type {Array}
     * @enum {String}
     * @readonly
     * @method placements
     * @memberof Popper
     */
  var m = [ "auto-start", "auto", "auto-end", "top-start", "top", "top-end", "right-start", "right", "right-end", "bottom-end", "bottom", "bottom-start", "left-end", "left", "left-start" ], g = m.slice(3);
  // Get rid of `auto` `auto-start` and `auto-end`
    /**
     * Given an initial placement, returns all the subsequent placements
     * clockwise (or counter-clockwise).
     *
     * @method
     * @memberof Popper.Utils
     * @argument {String} placement - A valid placement (it accepts variations)
     * @argument {Boolean} counter - Set to true to walk the placements counterclockwise
     * @returns {Array} placements including their variations
     */
  function clockwise(e) {
    var t = arguments.length > 1 && void 0 !== arguments[1] && arguments[1], o = g.indexOf(e), r = g.slice(o + 1).concat(g.slice(0, o));
    return t ? r.reverse() : r;
  }
  var v = "flip", y = "clockwise", b = "counterclockwise";
  /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by update method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */  
  /**
     * Modifier function, each modifier can have a function of this type assigned
     * to its `fn` property.<br />
     * These functions will be called on each update, this means that you must
     * make sure they are performant enough to avoid performance bottlenecks.
     *
     * @function ModifierFn
     * @argument {dataObject} data - The data object generated by `update` method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {dataObject} The data object, properly modified
     */
  /**
     * Modifiers are plugins used to alter the behavior of your poppers.<br />
     * Popper.js uses a set of 9 modifiers to provide all the basic functionalities
     * needed by the library.
     *
     * Usually you don't want to override the `order`, `fn` and `onLoad` props.
     * All the other properties are configurations that could be tweaked.
     * @namespace modifiers
     */
  var w = {
    /**
         * Popper's placement
         * @prop {Popper.placements} placement='bottom'
         */
    placement: "bottom",
    /**
         * Set this to true if you want popper to position it self in 'fixed' mode
         * @prop {Boolean} positionFixed=false
         */
    positionFixed: !1,
    /**
         * Whether events (resize, scroll) are initially enabled
         * @prop {Boolean} eventsEnabled=true
         */
    eventsEnabled: !0,
    /**
         * Set to true if you want to automatically remove the popper when
         * you call the `destroy` method.
         * @prop {Boolean} removeOnDestroy=false
         */
    removeOnDestroy: !1,
    /**
         * Callback called when the popper is created.<br />
         * By default, is set to no-op.<br />
         * Access Popper.js instance with `data.instance`.
         * @prop {onCreate}
         */
    onCreate: function() {},
    /**
         * Callback called when the popper is updated, this callback is not called
         * on the initialization/creation of the popper, but only on subsequent
         * updates.<br />
         * By default, is set to no-op.<br />
         * Access Popper.js instance with `data.instance`.
         * @prop {onUpdate}
         */
    onUpdate: function() {},
    /**
         * List of modifiers used to modify the offsets before they are applied to the popper.
         * They provide most of the functionalities of Popper.js
         * @prop {modifiers}
         */
    modifiers: {
      /**
         * Modifier used to shift the popper on the start or end of its reference
         * element.<br />
         * It will read the variation of the `placement` property.<br />
         * It can be one either `-end` or `-start`.
         * @memberof modifiers
         * @inner
         */
      shift: {
        /** @prop {number} order=100 - Index used to define the order of execution */
        order: 100,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: 
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by `update` method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */
        function(e) {
          var t = e.placement, o = t.split("-")[0], r = t.split("-")[1];
          // if shift shiftvariation is specified, run the modifier
          if (r) {
            var n = e.offsets, i = n.reference, s = n.popper, a = -1 !== [ "bottom", "top" ].indexOf(o), l = a ? "left" : "top", f = a ? "width" : "height", p = {
              start: u({}, l, i[l]),
              end: u({}, l, i[l] + i[f] - s[f])
            };
            e.offsets.popper = h({}, s, p[r]);
          }
          return e;
        }
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by update method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */      },
      /**
         * The `offset` modifier can shift your popper on both its axis.
         *
         * It accepts the following units:
         * - `px` or unitless, interpreted as pixels
         * - `%` or `%r`, percentage relative to the length of the reference element
         * - `%p`, percentage relative to the length of the popper element
         * - `vw`, CSS viewport width unit
         * - `vh`, CSS viewport height unit
         *
         * For length is intended the main axis relative to the placement of the popper.<br />
         * This means that if the placement is `top` or `bottom`, the length will be the
         * `width`. In case of `left` or `right`, it will be the height.
         *
         * You can provide a single value (as `Number` or `String`), or a pair of values
         * as `String` divided by a comma or one (or more) white spaces.<br />
         * The latter is a deprecated method because it leads to confusion and will be
         * removed in v2.<br />
         * Additionally, it accepts additions and subtractions between different units.
         * Note that multiplications and divisions aren't supported.
         *
         * Valid examples are:
         * ```
         * 10
         * '10%'
         * '10, 10'
         * '10%, 10'
         * '10 + 10%'
         * '10 - 5vh + 3%'
         * '-10px + 5vh, 5px - 6%'
         * ```
         * > **NB**: If you desire to apply offsets to your poppers in a way that may make them overlap
         * > with their reference element, unfortunately, you will have to disable the `flip` modifier.
         * > More on this [reading this issue](https://github.com/FezVrasta/popper.js/issues/373)
         *
         * @memberof modifiers
         * @inner
         */
      offset: {
        /** @prop {number} order=200 - Index used to define the order of execution */
        order: 200,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: 
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by update method
     * @argument {Object} options - Modifiers configuration and options
     * @argument {Number|String} options.offset=0
     * The offset value as described in the modifier description
     * @returns {Object} The data object, properly modified
     */
        function(e, t) {
          var o, r = t.offset, n = e.placement, i = e.offsets, s = i.popper, a = i.reference, l = n.split("-")[0];
          return o = isNumeric(+r) ? [ +r, 0 ] : 
          /**
     * Parse an `offset` string to extrapolate `x` and `y` numeric offsets.
     * @function
     * @memberof {modifiers~offset}
     * @private
     * @argument {String} offset
     * @argument {Object} popperOffsets
     * @argument {Object} referenceOffsets
     * @argument {String} basePlacement
     * @returns {Array} a two cells array with x and y offsets in numbers
     */
          function(e, t, o, r) {
            var n = [ 0, 0 ], i = -1 !== [ "right", "left" ].indexOf(r), s = e.split(/(\+|\-)/).map(function(e) {
              return e.trim();
            }), a = s.indexOf(find(s, function(e) {
              return -1 !== e.search(/,|\s/);
            }));
            // Use height if placement is left or right and index is 0 otherwise use width
            // in this way the first offset will use an axis and the second one
            // will use the other one
                        s[a] && -1 === s[a].indexOf(",") && console.warn("Offsets separated by white space(s) are deprecated, use a comma (,) instead.");
            // If divider is found, we divide the list of values and operands to divide
            // them by ofset X and Y.
                        var l = /\s*,\s*|\s+/, f = -1 !== a ? [ s.slice(0, a).concat([ s[a].split(l)[0] ]), [ s[a].split(l)[1] ].concat(s.slice(a + 1)) ] : [ s ];
            // Convert the values with units to absolute pixels to allow our computations
            // Loop trough the offsets arrays and execute the operations
            return (f = f.map(function(e, r) {
              // Most of the units rely on the orientation of the popper
              var n = (1 === r ? !i : i) ? "height" : "width", s = !1;
              return e.reduce(function(e, t) {
                return "" === e[e.length - 1] && -1 !== [ "+", "-" ].indexOf(t) ? (e[e.length - 1] = t, 
                s = !0, e) : s ? (e[e.length - 1] += t, s = !1, e) : e.concat(t);
              }, []).map(function(e) {
                /**
     * Converts a string containing value + unit into a px value number
     * @function
     * @memberof {modifiers~offset}
     * @private
     * @argument {String} str - Value + unit string
     * @argument {String} measurement - `height` or `width`
     * @argument {Object} popperOffsets
     * @argument {Object} referenceOffsets
     * @returns {Number|String}
     * Value in pixels, or original string if no values were extracted
     */
                return function(e, t, o, r) {
                  // separate value from unit
                  var n = e.match(/((?:\-|\+)?\d*\.?\d*)(.*)/), i = +n[1], s = n[2];
                  // If it's not a number it's an operator, I guess
                  if (!i) return e;
                  if (0 === s.indexOf("%")) {
                    var a = void 0;
                    switch (s) {
                     case "%p":
                      a = o;
                      break;

                     case "%":
                     case "%r":
                     default:
                      a = r;
                    }
                    return getClientRect(a)[t] / 100 * i;
                  }
                  return "vh" === s || "vw" === s ? ("vh" === s ? Math.max(document.documentElement.clientHeight, window.innerHeight || 0) : Math.max(document.documentElement.clientWidth, window.innerWidth || 0)) / 100 * i : i;
                }(e, n, t, o);
              });
            })).forEach(function(e, t) {
              e.forEach(function(o, r) {
                isNumeric(o) && (n[t] += o * ("-" === e[r - 1] ? -1 : 1));
              });
            }), n;
          }(r, s, a, l), "left" === l ? (s.top += o[0], s.left -= o[1]) : "right" === l ? (s.top += o[0], 
          s.left += o[1]) : "top" === l ? (s.left += o[0], s.top -= o[1]) : "bottom" === l && (s.left += o[0], 
          s.top += o[1]), e.popper = s, e;
        }
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by `update` method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */ ,
        /** @prop {Number|String} offset=0
             * The offset value as described in the modifier description
             */
        offset: 0
      },
      /**
         * Modifier used to prevent the popper from being positioned outside the boundary.
         *
         * An scenario exists where the reference itself is not within the boundaries.<br />
         * We can say it has "escaped the boundaries" — or just "escaped".<br />
         * In this case we need to decide whether the popper should either:
         *
         * - detach from the reference and remain "trapped" in the boundaries, or
         * - if it should ignore the boundary and "escape with its reference"
         *
         * When `escapeWithReference` is set to`true` and reference is completely
         * outside its boundaries, the popper will overflow (or completely leave)
         * the boundaries in order to remain attached to the edge of the reference.
         *
         * @memberof modifiers
         * @inner
         */
      preventOverflow: {
        /** @prop {number} order=300 - Index used to define the order of execution */
        order: 300,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: function(e, t) {
          var o = t.boundariesElement || getOffsetParent(e.instance.popper);
          // If offsetParent is the reference element, we really want to
          // go one step up and use the next offsetParent as reference to
          // avoid to make this modifier completely useless and look like broken
                    e.instance.reference === o && (o = getOffsetParent(o));
          // NOTE: DOM access here
          // resets the popper's position so that the document size can be calculated excluding
          // the size of the popper element itself
                    var r = getSupportedPropertyName("transform"), n = e.instance.popper.style, i = n.top, s = n.left, a = n[r];
          n.top = "", n.left = "", n[r] = "";
          var l = getBoundaries(e.instance.popper, e.instance.reference, t.padding, o, e.positionFixed);
          // NOTE: DOM access here
          // restores the original style properties after the offsets have been computed
                    n.top = i, n.left = s, n[r] = a, t.boundaries = l;
          var f = t.priority, p = e.offsets.popper, c = {
            primary: function(e) {
              var o = p[e];
              return p[e] < l[e] && !t.escapeWithReference && (o = Math.max(p[e], l[e])), u({}, e, o);
            },
            secondary: function(e) {
              var o = "right" === e ? "left" : "top", r = p[o];
              return p[e] > l[e] && !t.escapeWithReference && (r = Math.min(p[o], l[e] - ("right" === e ? p.width : p.height))), 
              u({}, o, r);
            }
          };
          return f.forEach(function(e) {
            var t = -1 !== [ "left", "top" ].indexOf(e) ? "primary" : "secondary";
            p = h({}, p, c[t](e));
          }), e.offsets.popper = p, e;
        },
        /**
             * @prop {Array} [priority=['left','right','top','bottom']]
             * Popper will try to prevent overflow following these priorities by default,
             * then, it could overflow on the left and on top of the `boundariesElement`
             */
        priority: [ "left", "right", "top", "bottom" ],
        /**
             * @prop {number} padding=5
             * Amount of pixel used to define a minimum distance between the boundaries
             * and the popper this makes sure the popper has always a little padding
             * between the edges of its container
             */
        padding: 5,
        /**
             * @prop {String|HTMLElement} boundariesElement='scrollParent'
             * Boundaries used by the modifier, can be `scrollParent`, `window`,
             * `viewport` or any DOM element.
             */
        boundariesElement: "scrollParent"
      },
      /**
         * Modifier used to make sure the reference and its popper stay near eachothers
         * without leaving any gap between the two. Expecially useful when the arrow is
         * enabled and you want to assure it to point to its reference element.
         * It cares only about the first axis, you can still have poppers with margin
         * between the popper and its reference element.
         * @memberof modifiers
         * @inner
         */
      keepTogether: {
        /** @prop {number} order=400 - Index used to define the order of execution */
        order: 400,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: 
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by update method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */
        function(e) {
          var t = e.offsets, o = t.popper, r = t.reference, n = e.placement.split("-")[0], i = Math.floor, s = -1 !== [ "top", "bottom" ].indexOf(n), a = s ? "right" : "bottom", l = s ? "left" : "top", f = s ? "width" : "height";
          return o[a] < i(r[l]) && (e.offsets.popper[l] = i(r[l]) - o[f]), o[l] > i(r[a]) && (e.offsets.popper[l] = i(r[a])), 
          e;
        }
      },
      /**
         * This modifier is used to move the `arrowElement` of the popper to make
         * sure it is positioned between the reference element and its popper element.
         * It will read the outer size of the `arrowElement` node to detect how many
         * pixels of conjuction are needed.
         *
         * It has no effect if no `arrowElement` is provided.
         * @memberof modifiers
         * @inner
         */
      arrow: {
        /** @prop {number} order=500 - Index used to define the order of execution */
        order: 500,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: function(e, t) {
          var o;
          // arrow depends on keepTogether in order to work
                    if (!isModifierRequired(e.instance.modifiers, "arrow", "keepTogether")) return e;
          var r = t.element;
          // if arrowElement is a string, suppose it's a CSS selector
                    if ("string" == typeof r) {
            // if arrowElement is not found, don't run the modifier
            if (!(r = e.instance.popper.querySelector(r))) return e;
          } else 
          // if the arrowElement isn't a query selector we must check that the
          // provided DOM node is child of its popper node
          if (!e.instance.popper.contains(r)) return console.warn("WARNING: `arrow.element` must be child of its popper element!"), 
          e;
          var n = e.placement.split("-")[0], i = e.offsets, s = i.popper, a = i.reference, l = -1 !== [ "left", "right" ].indexOf(n), f = l ? "height" : "width", p = l ? "Top" : "Left", c = p.toLowerCase(), d = l ? "left" : "top", h = l ? "bottom" : "right", m = getOuterSizes(r)[f];
          //
          // extends keepTogether behavior making sure the popper and its
          // reference have enough pixels in conjuction
          //
          // top/left side
          a[h] - m < s[c] && (e.offsets.popper[c] -= s[c] - (a[h] - m)), 
          // bottom/right side
          a[c] + m > s[h] && (e.offsets.popper[c] += a[c] + m - s[h]), e.offsets.popper = getClientRect(e.offsets.popper);
          // compute center of the popper
          var g = a[c] + a[f] / 2 - m / 2, v = getStyleComputedProperty(e.instance.popper), y = parseFloat(v["margin" + p], 10), b = parseFloat(v["border" + p + "Width"], 10), w = g - e.offsets.popper[c] - y - b;
          // Compute the sideValue using the updated popper offsets
          // take popper margin in account because we don't have this info available
                    // prevent arrowElement from being placed not contiguously to its popper
          return w = Math.max(Math.min(s[f] - m, w), 0), e.arrowElement = r, e.offsets.arrow = (u(o = {}, c, Math.round(w)), 
          u(o, d, ""), o), e;
        }
        /**
     * Get the opposite placement variation of the given one
     * @method
     * @memberof Popper.Utils
     * @argument {String} placement variation
     * @returns {String} flipped placement variation
     */ ,
        /** @prop {String|HTMLElement} element='[x-arrow]' - Selector or node used as arrow */
        element: "[x-arrow]"
      },
      /**
         * Modifier used to flip the popper's placement when it starts to overlap its
         * reference element.
         *
         * Requires the `preventOverflow` modifier before it in order to work.
         *
         * **NOTE:** this modifier will interrupt the current update cycle and will
         * restart it if it detects the need to flip the placement.
         * @memberof modifiers
         * @inner
         */
      flip: {
        /** @prop {number} order=600 - Index used to define the order of execution */
        order: 600,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: function(e, t) {
          // if `inner` modifier is enabled, we can't use the `flip` modifier
          if (isModifierEnabled(e.instance.modifiers, "inner")) return e;
          if (e.flipped && e.placement === e.originalPlacement) 
          // seems like flip is trying to loop, probably there's not enough space on any of the flippable sides
          return e;
          var o = getBoundaries(e.instance.popper, e.instance.reference, t.padding, t.boundariesElement, e.positionFixed), r = e.placement.split("-")[0], n = getOppositePlacement(r), i = e.placement.split("-")[1] || "", s = [];
          switch (t.behavior) {
           case v:
            s = [ r, n ];
            break;

           case y:
            s = clockwise(r);
            break;

           case b:
            s = clockwise(r, !0);
            break;

           default:
            s = t.behavior;
          }
          return s.forEach(function(a, l) {
            if (r !== a || s.length === l + 1) return e;
            r = e.placement.split("-")[0], n = getOppositePlacement(r);
            var f = e.offsets.popper, p = e.offsets.reference, c = Math.floor, d = "left" === r && c(f.right) > c(p.left) || "right" === r && c(f.left) < c(p.right) || "top" === r && c(f.bottom) > c(p.top) || "bottom" === r && c(f.top) < c(p.bottom), u = c(f.left) < c(o.left), m = c(f.right) > c(o.right), g = c(f.top) < c(o.top), v = c(f.bottom) > c(o.bottom), y = "left" === r && u || "right" === r && m || "top" === r && g || "bottom" === r && v, b = -1 !== [ "top", "bottom" ].indexOf(r), w = !!t.flipVariations && (b && "start" === i && u || b && "end" === i && m || !b && "start" === i && g || !b && "end" === i && v);
            (d || y || w) && (
            // this boolean to detect any flip loop
            e.flipped = !0, (d || y) && (r = s[l + 1]), w && (i = function(e) {
              return "end" === e ? "start" : "start" === e ? "end" : e;
            }(i)), e.placement = r + (i ? "-" + i : ""), 
            // this object contains `position`, we want to preserve it along with
            // any additional property we may add in the future
            e.offsets.popper = h({}, e.offsets.popper, getPopperOffsets(e.instance.popper, e.offsets.reference, e.placement)), 
            e = runModifiers(e.instance.modifiers, e, "flip"));
          }), e;
        },
        /**
             * @prop {String|Array} behavior='flip'
             * The behavior used to change the popper's placement. It can be one of
             * `flip`, `clockwise`, `counterclockwise` or an array with a list of valid
             * placements (with optional variations).
             */
        behavior: "flip",
        /**
             * @prop {number} padding=5
             * The popper will flip if it hits the edges of the `boundariesElement`
             */
        padding: 5,
        /**
             * @prop {String|HTMLElement} boundariesElement='viewport'
             * The element which will define the boundaries of the popper position,
             * the popper will never be placed outside of the defined boundaries
             * (except if keepTogether is enabled)
             */
        boundariesElement: "viewport"
      },
      /**
         * Modifier used to make the popper flow toward the inner of the reference element.
         * By default, when this modifier is disabled, the popper will be placed outside
         * the reference element.
         * @memberof modifiers
         * @inner
         */
      inner: {
        /** @prop {number} order=700 - Index used to define the order of execution */
        order: 700,
        /** @prop {Boolean} enabled=false - Whether the modifier is enabled or not */
        enabled: !1,
        /** @prop {ModifierFn} */
        fn: 
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by `update` method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */
        function(e) {
          var t = e.placement, o = t.split("-")[0], r = e.offsets, n = r.popper, i = r.reference, s = -1 !== [ "left", "right" ].indexOf(o), a = -1 === [ "top", "left" ].indexOf(o);
          return n[s ? "left" : "top"] = i[o] - (a ? n[s ? "width" : "height"] : 0), e.placement = getOppositePlacement(t), 
          e.offsets.popper = getClientRect(n), e;
        }
      },
      /**
         * Modifier used to hide the popper when its reference element is outside of the
         * popper boundaries. It will set a `x-out-of-boundaries` attribute which can
         * be used to hide with a CSS selector the popper when its reference is
         * out of boundaries.
         *
         * Requires the `preventOverflow` modifier before it in order to work.
         * @memberof modifiers
         * @inner
         */
      hide: {
        /** @prop {number} order=800 - Index used to define the order of execution */
        order: 800,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: function(e) {
          if (!isModifierRequired(e.instance.modifiers, "hide", "preventOverflow")) return e;
          var t = e.offsets.reference, o = find(e.instance.modifiers, function(e) {
            return "preventOverflow" === e.name;
          }).boundaries;
          if (t.bottom < o.top || t.left > o.right || t.top > o.bottom || t.right < o.left) {
            // Avoid unnecessary DOM access if visibility hasn't changed
            if (!0 === e.hide) return e;
            e.hide = !0, e.attributes["x-out-of-boundaries"] = "";
          } else {
            // Avoid unnecessary DOM access if visibility hasn't changed
            if (!1 === e.hide) return e;
            e.hide = !1, e.attributes["x-out-of-boundaries"] = !1;
          }
          return e;
        }
      },
      /**
         * Computes the style that will be applied to the popper element to gets
         * properly positioned.
         *
         * Note that this modifier will not touch the DOM, it just prepares the styles
         * so that `applyStyle` modifier can apply it. This separation is useful
         * in case you need to replace `applyStyle` with a custom implementation.
         *
         * This modifier has `850` as `order` value to maintain backward compatibility
         * with previous versions of Popper.js. Expect the modifiers ordering method
         * to change in future major versions of the library.
         *
         * @memberof modifiers
         * @inner
         */
      computeStyle: {
        /** @prop {number} order=850 - Index used to define the order of execution */
        order: 850,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: 
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by `update` method
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The data object, properly modified
     */
        function(e, t) {
          var o = t.x, r = t.y, n = e.offsets.popper, i = find(e.instance.modifiers, function(e) {
            return "applyStyle" === e.name;
          }).gpuAcceleration;
          void 0 !== i && console.warn("WARNING: `gpuAcceleration` option moved to `computeStyle` modifier and will not be supported in future versions of Popper.js!");
          var s, a, l = void 0 !== i ? i : t.gpuAcceleration, f = getBoundingClientRect(getOffsetParent(e.instance.popper)), p = {
            position: n.position
          }, c = {
            left: Math.floor(n.left),
            top: Math.round(n.top),
            bottom: Math.round(n.bottom),
            right: Math.floor(n.right)
          }, d = "bottom" === o ? "top" : "bottom", u = "right" === r ? "left" : "right", m = getSupportedPropertyName("transform");
          if (a = "bottom" === d ? -f.height + c.bottom : c.top, s = "right" === u ? -f.width + c.right : c.left, 
          l && m) p[m] = "translate3d(" + s + "px, " + a + "px, 0)", p[d] = 0, p[u] = 0, p.willChange = "transform"; else {
            // othwerise, we use the standard `top`, `left`, `bottom` and `right` properties
            var g = "bottom" === d ? -1 : 1, v = "right" === u ? -1 : 1;
            p[d] = a * g, p[u] = s * v, p.willChange = d + ", " + u;
          }
          // Attributes
                    var y = {
            "x-placement": e.placement
          };
          // Update `data` attributes, styles and arrowStyles
                    return e.attributes = h({}, y, e.attributes), e.styles = h({}, p, e.styles), 
          e.arrowStyles = h({}, e.offsets.arrow, e.arrowStyles), e;
        },
        /**
             * @prop {Boolean} gpuAcceleration=true
             * If true, it uses the CSS 3d transformation to position the popper.
             * Otherwise, it will use the `top` and `left` properties.
             */
        gpuAcceleration: !0,
        /**
             * @prop {string} [x='bottom']
             * Where to anchor the X axis (`bottom` or `top`). AKA X offset origin.
             * Change this if your popper should grow in a direction different from `bottom`
             */
        x: "bottom",
        /**
             * @prop {string} [x='left']
             * Where to anchor the Y axis (`left` or `right`). AKA Y offset origin.
             * Change this if your popper should grow in a direction different from `right`
             */
        y: "right"
      },
      /**
         * Applies the computed styles to the popper element.
         *
         * All the DOM manipulations are limited to this modifier. This is useful in case
         * you want to integrate Popper.js inside a framework or view library and you
         * want to delegate all the DOM manipulations to it.
         *
         * Note that if you disable this modifier, you must make sure the popper element
         * has its position set to `absolute` before Popper.js can do its work!
         *
         * Just disable this modifier and define you own to achieve the desired effect.
         *
         * @memberof modifiers
         * @inner
         */
      applyStyle: {
        /** @prop {number} order=900 - Index used to define the order of execution */
        order: 900,
        /** @prop {Boolean} enabled=true - Whether the modifier is enabled or not */
        enabled: !0,
        /** @prop {ModifierFn} */
        fn: 
        /**
     * @function
     * @memberof Modifiers
     * @argument {Object} data - The data object generated by `update` method
     * @argument {Object} data.styles - List of style properties - values to apply to popper element
     * @argument {Object} data.attributes - List of attribute properties - values to apply to popper element
     * @argument {Object} options - Modifiers configuration and options
     * @returns {Object} The same data object
     */
        function(e) {
          var t, o;
          // any property present in `data.styles` will be applied to the popper,
          // in this way we can make the 3rd party modifiers add custom styles to it
          // Be aware, modifiers could override the properties defined in the previous
          // lines of this modifier!
          return setStyles(e.instance.popper, e.styles), 
          // any property present in `data.attributes` will be applied to the popper,
          // they will be set as HTML attributes of the element
          t = e.instance.popper, o = e.attributes, Object.keys(o).forEach(function(e) {
            !1 !== o[e] ? t.setAttribute(e, o[e]) : t.removeAttribute(e);
          }), 
          // if arrowElement is defined and arrowStyles has some properties
          e.arrowElement && Object.keys(e.arrowStyles).length && setStyles(e.arrowElement, e.arrowStyles), 
          e;
        }
        /**
     * Set the x-placement attribute before everything else because it could be used
     * to add margins to the popper margins needs to be calculated to get the
     * correct popper offsets.
     * @method
     * @memberof Popper.modifiers
     * @param {HTMLElement} reference - The reference element used to position the popper
     * @param {HTMLElement} popper - The HTML element used as popper
     * @param {Object} options - Popper.js options
     */ ,
        /** @prop {Function} */
        onLoad: function(e, t, o, r, n) {
          // compute reference element offsets
          var i = getReferenceOffsets(n, t, e, o.positionFixed), s = computeAutoPlacement(o.placement, i, t, e, o.modifiers.flip.boundariesElement, o.modifiers.flip.padding);
          // compute auto placement, store placement inside the data object,
          // modifiers will be able to edit `placement` if needed
          // and refer to originalPlacement to know the original value
                    return t.setAttribute("x-placement", s), 
          // Apply `position` to popper before anything else because
          // without the position applied we can't guarantee correct computations
          setStyles(t, {
            position: o.positionFixed ? "fixed" : "absolute"
          }), o;
        },
        /**
             * @deprecated since version 1.10.0, the property moved to `computeStyle` modifier
             * @prop {Boolean} gpuAcceleration=true
             * If true, it uses the CSS 3d transformation to position the popper.
             * Otherwise, it will use the `top` and `left` properties.
             */
        gpuAcceleration: void 0
      }
    }
  }, O = function() {
    /**
         * Create a new Popper.js instance
         * @class Popper
         * @param {HTMLElement|referenceObject} reference - The reference element used to position the popper
         * @param {HTMLElement} popper - The HTML element used as popper.
         * @param {Object} options - Your custom options to override the ones defined in [Defaults](#defaults)
         * @return {Object} instance - The generated Popper.js instance
         */
    function Popper(e, t) {
      var o = this, r = arguments.length > 2 && void 0 !== arguments[2] ? arguments[2] : {};
      c(this, Popper), this.scheduleUpdate = function() {
        return requestAnimationFrame(o.update);
      }, 
      // make update() debounced, so that it only runs at most once-per-tick
      this.update = l(this.update.bind(this)), 
      // with {} we create a new object with the options inside it
      this.options = h({}, Popper.Defaults, r), 
      // init state
      this.state = {
        isDestroyed: !1,
        isCreated: !1,
        scrollParents: []
      }, 
      // get reference and popper elements (allow jQuery wrappers)
      this.reference = e && e.jquery ? e[0] : e, this.popper = t && t.jquery ? t[0] : t, 
      // Deep merge modifiers options
      this.options.modifiers = {}, Object.keys(h({}, Popper.Defaults.modifiers, r.modifiers)).forEach(function(e) {
        o.options.modifiers[e] = h({}, Popper.Defaults.modifiers[e] || {}, r.modifiers ? r.modifiers[e] : {});
      }), 
      // Refactoring modifiers' list (Object => Array)
      this.modifiers = Object.keys(this.options.modifiers).map(function(e) {
        return h({
          name: e
        }, o.options.modifiers[e]);
      }).sort(function(e, t) {
        return e.order - t.order;
      }), 
      // modifiers have the ability to execute arbitrary code when Popper.js get inited
      // such code is executed in the same order of its modifier
      // they could add new properties to their options configuration
      // BE AWARE: don't add options to `options.modifiers.name` but to `modifierOptions`!
      this.modifiers.forEach(function(e) {
        e.enabled && isFunction(e.onLoad) && e.onLoad(o.reference, o.popper, o.options, e, o.state);
      }), 
      // fire the first update to position the popper in the right place
      this.update();
      var n = this.options.eventsEnabled;
      n && 
      // setup event listeners, they will take care of update the position in specific situations
      this.enableEventListeners(), this.state.eventsEnabled = n;
    }
    // We can't use class properties because they don't get listed in the
    // class prototype and break stuff like Sinon stubs
        return d(Popper, [ {
      key: "update",
      value: function() {
        return function() {
          // if popper is destroyed, don't perform any further update
          if (!this.state.isDestroyed) {
            var e = {
              instance: this,
              styles: {},
              arrowStyles: {},
              attributes: {},
              flipped: !1,
              offsets: {}
            };
            // compute reference element offsets
                        e.offsets.reference = getReferenceOffsets(this.state, this.popper, this.reference, this.options.positionFixed), 
            // compute auto placement, store placement inside the data object,
            // modifiers will be able to edit `placement` if needed
            // and refer to originalPlacement to know the original value
            e.placement = computeAutoPlacement(this.options.placement, e.offsets.reference, this.popper, this.reference, this.options.modifiers.flip.boundariesElement, this.options.modifiers.flip.padding), 
            // store the computed placement inside `originalPlacement`
            e.originalPlacement = e.placement, e.positionFixed = this.options.positionFixed, 
            // compute the popper offsets
            e.offsets.popper = getPopperOffsets(this.popper, e.offsets.reference, e.placement), 
            e.offsets.popper.position = this.options.positionFixed ? "fixed" : "absolute", 
            // run the modifiers
            e = runModifiers(this.modifiers, e), 
            // the first `update` will call `onCreate` callback
            // the other ones will call `onUpdate` callback
            this.state.isCreated ? this.options.onUpdate(e) : (this.state.isCreated = !0, this.options.onCreate(e));
          }
        }.call(this);
      }
    }, {
      key: "destroy",
      value: function() {
        return function() {
          return this.state.isDestroyed = !0, 
          // touch DOM only if `applyStyle` modifier is enabled
          isModifierEnabled(this.modifiers, "applyStyle") && (this.popper.removeAttribute("x-placement"), 
          this.popper.style.position = "", this.popper.style.top = "", this.popper.style.left = "", 
          this.popper.style.right = "", this.popper.style.bottom = "", this.popper.style.willChange = "", 
          this.popper.style[getSupportedPropertyName("transform")] = ""), this.disableEventListeners(), 
          // remove the popper if user explicity asked for the deletion on destroy
          // do not use `remove` because IE11 doesn't support it
          this.options.removeOnDestroy && this.popper.parentNode.removeChild(this.popper), 
          this;
        }.call(this);
      }
    }, {
      key: "enableEventListeners",
      value: function() {
        /**
     * It will add resize/scroll events and start recalculating
     * position of the popper element when they are triggered.
     * @method
     * @memberof Popper
     */
        return function() {
          this.state.eventsEnabled || (this.state = 
          /**
     * Setup needed event listeners used to update the popper position
     * @method
     * @memberof Popper.Utils
     * @private
     */
          function(e, t, o, r) {
            // Resize event listener on window
            o.updateBound = r, getWindow(e).addEventListener("resize", o.updateBound, {
              passive: !0
            });
            // Scroll event listener on scroll parents
            var n = getScrollParent(e);
            return function attachToScrollParents(e, t, o, r) {
              var n = "BODY" === e.nodeName, i = n ? e.ownerDocument.defaultView : e;
              i.addEventListener(t, o, {
                passive: !0
              }), n || attachToScrollParents(getScrollParent(i.parentNode), t, o, r), r.push(i);
            }(n, "scroll", o.updateBound, o.scrollParents), o.scrollElement = n, o.eventsEnabled = !0, 
            o;
          }(this.reference, this.options, this.state, this.scheduleUpdate));
        }
        /**
     * Remove event listeners used to update the popper position
     * @method
     * @memberof Popper.Utils
     * @private
     */ .call(this);
      }
    }, {
      key: "disableEventListeners",
      value: function() {
        /**
     * It will remove resize/scroll events and won't recalculate popper position
     * when they are triggered. It also won't trigger onUpdate callback anymore,
     * unless you call `update` method manually.
     * @method
     * @memberof Popper
     */
        return function() {
          var e, t;
          this.state.eventsEnabled && (cancelAnimationFrame(this.scheduleUpdate), this.state = (e = this.reference, 
          t = this.state, 
          // Remove resize event listener on window
          getWindow(e).removeEventListener("resize", t.updateBound), 
          // Remove scroll event listener on scroll parents
          t.scrollParents.forEach(function(e) {
            e.removeEventListener("scroll", t.updateBound);
          }), 
          // Reset state
          t.updateBound = null, t.scrollParents = [], t.scrollElement = null, t.eventsEnabled = !1, 
          t));
        }.call(this);
      }
      /**
                 * Schedule an update, it will run on the next UI update available
                 * @method scheduleUpdate
                 * @memberof Popper
                 */
      /**
                 * Collection of utilities useful when writing custom modifiers.
                 * Starting from version 1.7, this method is available only if you
                 * include `popper-utils.js` before `popper.js`.
                 *
                 * **DEPRECATION**: This way to access PopperUtils is deprecated
                 * and will be removed in v2! Use the PopperUtils module directly instead.
                 * Due to the high instability of the methods contained in Utils, we can't
                 * guarantee them to follow semver. Use them at your own risk!
                 * @static
                 * @private
                 * @type {Object}
                 * @deprecated since version 1.8
                 * @member Utils
                 * @memberof Popper
                 */    } ]), Popper;
  }();
  /**
     * The `dataObject` is an object containing all the informations used by Popper.js
     * this object get passed to modifiers and to the `onCreate` and `onUpdate` callbacks.
     * @name dataObject
     * @property {Object} data.instance The Popper.js instance
     * @property {String} data.placement Placement applied to popper
     * @property {String} data.originalPlacement Placement originally defined on init
     * @property {Boolean} data.flipped True if popper has been flipped by flip modifier
     * @property {Boolean} data.hide True if the reference element is out of boundaries, useful to know when to hide the popper.
     * @property {HTMLElement} data.arrowElement Node used as arrow by arrow modifier
     * @property {Object} data.styles Any CSS property defined here will be applied to the popper, it expects the JavaScript nomenclature (eg. `marginBottom`)
     * @property {Object} data.arrowStyles Any CSS property defined here will be applied to the popper arrow, it expects the JavaScript nomenclature (eg. `marginBottom`)
     * @property {Object} data.boundaries Offsets of the popper boundaries
     * @property {Object} data.offsets The measurements of popper, reference and arrow elements.
     * @property {Object} data.offsets.popper `top`, `left`, `width`, `height` values
     * @property {Object} data.offsets.reference `top`, `left`, `width`, `height` values
     * @property {Object} data.offsets.arrow] `top` and `left` offsets, only one of them will be different from 0
     */
  /**
     * Default options provided to Popper.js constructor.<br />
     * These can be overriden using the `options` argument of Popper.js.<br />
     * To override an option, simply pass as 3rd argument an object with the same
     * structure of this object, example:
     * ```
     * new Popper(ref, pop, {
     *   modifiers: {
     *     preventOverflow: { enabled: false }
     *   }
     * })
     * ```
     * @type {Object}
     * @static
     * @memberof Popper
     */  
  /**
     * The `referenceObject` is an object that provides an interface compatible with Popper.js
     * and lets you use it as replacement of a real DOM node.<br />
     * You can use this method to position a popper relatively to a set of coordinates
     * in case you don't have a DOM node to use as reference.
     *
     * ```
     * new Popper(referenceObject, popperNode);
     * ```
     *
     * NB: This feature isn't supported in Internet Explorer 10
     * @name referenceObject
     * @property {Function} data.getBoundingClientRect
     * A function that returns a set of coordinates compatible with the native `getBoundingClientRect` method.
     * @property {number} data.clientWidth
     * An ES6 getter that will return the width of the virtual reference element.
     * @property {number} data.clientHeight
     * An ES6 getter that will return the height of the virtual reference element.
     */
  O.Utils = ("undefined" != typeof window ? window : t.global).PopperUtils, O.placements = m, 
  O.Defaults = w;
  var P = /** @class */ function(e) {
    function Card() {
      var t = e.apply(this, arguments) || this;
      /**
             * This attribute lets you specify how this element will behave when hidden.
             *
             * | Value        | Details                                                                     |
             * | ------------ | --------------------------------------------------------------------------- |
             * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
             * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
             */      return t.invisibleMode = "collapse", t;
    }
    return __extends(Card, e), Card.prototype.componentDidLoad = function() {
      e.prototype.componentDidLoad.call(this);
    }, Card.prototype.componentDidUpdate = function() {
      e.prototype.componentDidUpdate.call(this);
    }, Card.prototype.componentDidUnload = function() {
      e.prototype.componentDidUnload.call(this);
    }, Object.defineProperty(Card, "is", {
      get: function() {
        return "gx-card";
      },
      enumerable: !0,
      configurable: !0
    }), Object.defineProperty(Card, "properties", {
      get: function() {
        return {
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
    }), Object.defineProperty(Card, "style", {
      get: function() {
        return "\@charset \"UTF-8\";/*!\n * Bootstrap v4.1.2 (https://getbootstrap.com/)\n * Copyright 2011-2018 The Bootstrap Authors\n * Copyright 2011-2018 Twitter, Inc.\n * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)\n */:root{--blue:#007bff;--indigo:#6610f2;--purple:#6f42c1;--pink:#e83e8c;--red:#dc3545;--orange:#fd7e14;--yellow:#ffc107;--green:#28a745;--teal:#20c997;--cyan:#17a2b8;--white:#fff;--gray:#6c757d;--gray-dark:#343a40;--primary:#007bff;--secondary:#6c757d;--success:#28a745;--info:#17a2b8;--warning:#ffc107;--danger:#dc3545;--light:#f8f9fa;--dark:#343a40;--breakpoint-xs:0;--breakpoint-sm:576px;--breakpoint-md:768px;--breakpoint-lg:992px;--breakpoint-xl:1200px;--font-family-sans-serif:-apple-system,BlinkMacSystemFont,\"Segoe UI\",Roboto,\"Helvetica Neue\",Arial,sans-serif,\"Apple Color Emoji\",\"Segoe UI Emoji\",\"Segoe UI Symbol\";--font-family-monospace:SFMono-Regular,Menlo,Monaco,Consolas,\"Liberation Mono\",\"Courier New\",monospace}*,::after,::before{-webkit-box-sizing:border-box;box-sizing:border-box}html{font-family:sans-serif;line-height:1.15;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;-ms-overflow-style:scrollbar;-webkit-tap-highlight-color:transparent}\@-ms-viewport{width:device-width}article,aside,figcaption,figure,footer,header,hgroup,main,nav,section{display:block}body{margin:0;font-family:-apple-system,BlinkMacSystemFont,\"Segoe UI\",Roboto,\"Helvetica Neue\",Arial,sans-serif,\"Apple Color Emoji\",\"Segoe UI Emoji\",\"Segoe UI Symbol\";font-size:1rem;font-weight:400;line-height:1.5;color:#212529;text-align:left;background-color:#fff}[tabindex=\"-1\"]:focus{outline:0!important}hr{-webkit-box-sizing:content-box;box-sizing:content-box;height:0;overflow:visible}h1,h2,h3,h4,h5,h6{margin-top:0}dl,ol,p,ul{margin-top:0;margin-bottom:1rem}abbr[data-original-title],abbr[title]{text-decoration:underline;-webkit-text-decoration:underline dotted;text-decoration:underline dotted;cursor:help;border-bottom:0}address{margin-bottom:1rem;font-style:normal;line-height:inherit}ol ol,ol ul,ul ol,ul ul{margin-bottom:0}dt{font-weight:700}dd{margin-bottom:.5rem;margin-left:0}blockquote,figure{margin:0 0 1rem}dfn{font-style:italic}b,strong{font-weight:bolder}sub,sup{position:relative;font-size:75%;line-height:0;vertical-align:baseline}sub{bottom:-.25em}sup{top:-.5em}a{color:#007bff;text-decoration:none;background-color:transparent;-webkit-text-decoration-skip:objects}a:hover{color:#0056b3;text-decoration:underline}a:not([href]):not([tabindex]),a:not([href]):not([tabindex]):focus,a:not([href]):not([tabindex]):hover{color:inherit;text-decoration:none}a:not([href]):not([tabindex]):focus{outline:0}code,kbd,pre,samp{font-family:SFMono-Regular,Menlo,Monaco,Consolas,\"Liberation Mono\",\"Courier New\",monospace;font-size:1em}pre{margin-top:0;margin-bottom:1rem;overflow:auto;-ms-overflow-style:scrollbar}img{vertical-align:middle;border-style:none}svg:not(:root){overflow:hidden;vertical-align:middle}table{border-collapse:collapse}caption{padding-top:.75rem;padding-bottom:.75rem;color:#6c757d;text-align:left;caption-side:bottom}th{text-align:inherit}label{display:inline-block;margin-bottom:.5rem}button{border-radius:0}button:focus{outline:dotted 1px;outline:-webkit-focus-ring-color auto 5px}button,input,optgroup,select,textarea{margin:0;font-family:inherit;font-size:inherit;line-height:inherit}button,input{overflow:visible}button,select{text-transform:none}[type=reset],[type=submit],button,html [type=button]{-webkit-appearance:button}[type=button]::-moz-focus-inner,[type=reset]::-moz-focus-inner,[type=submit]::-moz-focus-inner,button::-moz-focus-inner{padding:0;border-style:none}input[type=checkbox],input[type=radio]{-webkit-box-sizing:border-box;box-sizing:border-box;padding:0}input[type=date],input[type=datetime-local],input[type=month],input[type=time]{-webkit-appearance:listbox}textarea{overflow:auto;resize:vertical}fieldset{min-width:0;padding:0;margin:0;border:0}legend{display:block;width:100%;max-width:100%;padding:0;margin-bottom:.5rem;font-size:1.5rem;line-height:inherit;color:inherit;white-space:normal}progress{vertical-align:baseline}[type=number]::-webkit-inner-spin-button,[type=number]::-webkit-outer-spin-button{height:auto}[type=search]{outline-offset:-2px;-webkit-appearance:none}[type=search]::-webkit-search-cancel-button,[type=search]::-webkit-search-decoration{-webkit-appearance:none}::-webkit-file-upload-button{font:inherit;-webkit-appearance:button}output{display:inline-block}summary{display:list-item;cursor:pointer}template{display:none}[hidden]{display:none!important}.h1,.h2,.h3,.h4,.h5,.h6,h1,h2,h3,h4,h5,h6{margin-bottom:.5rem;font-family:inherit;font-weight:500;line-height:1.2;color:inherit}.h1,h1{font-size:2.5rem}.h2,h2{font-size:2rem}.h3,h3{font-size:1.75rem}.h4,h4{font-size:1.5rem}.h5,h5{font-size:1.25rem}.h6,h6{font-size:1rem}.lead{font-size:1.25rem;font-weight:300}.display-1{font-size:6rem;font-weight:300;line-height:1.2}.display-2{font-size:5.5rem;font-weight:300;line-height:1.2}.display-3{font-size:4.5rem;font-weight:300;line-height:1.2}.display-4{font-size:3.5rem;font-weight:300;line-height:1.2}hr{margin-top:1rem;margin-bottom:1rem;border:0;border-top:1px solid rgba(0,0,0,.1)}.small,small{font-size:80%;font-weight:400}.mark,mark{padding:.2em;background-color:#fcf8e3}.list-inline,.list-unstyled{padding-left:0;list-style:none}.list-inline-item{display:inline-block}.list-inline-item:not(:last-child){margin-right:.5rem}.initialism{font-size:90%;text-transform:uppercase}.blockquote{margin-bottom:1rem;font-size:1.25rem}.blockquote-footer{display:block;font-size:80%;color:#6c757d}.blockquote-footer::before{content:\"\\2014 \\00A0\"}.img-fluid{max-width:100%;height:auto}.img-thumbnail{padding:.25rem;background-color:#fff;border:1px solid #dee2e6;border-radius:.25rem;max-width:100%;height:auto}.figure{display:inline-block}.figure-img{margin-bottom:.5rem;line-height:1}.figure-caption{font-size:90%;color:#6c757d}code{font-size:87.5%;color:#e83e8c;word-break:break-word}a>code{color:inherit}kbd{padding:.2rem .4rem;font-size:87.5%;color:#fff;background-color:#212529;border-radius:.2rem}kbd kbd{padding:0;font-size:100%;font-weight:700}pre{display:block;font-size:87.5%;color:#212529}pre code{font-size:inherit;color:inherit;word-break:normal}.pre-scrollable{max-height:340px;overflow-y:scroll}.container{width:100%;padding-right:15px;padding-left:15px;margin-right:auto;margin-left:auto}\@media (min-width:576px){.container{max-width:540px}}\@media (min-width:768px){.container{max-width:720px}}\@media (min-width:992px){.container{max-width:960px}}\@media (min-width:1200px){.container{max-width:1140px}}.container-fluid{width:100%;padding-right:15px;padding-left:15px;margin-right:auto;margin-left:auto}.row{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;margin-right:-15px;margin-left:-15px}.no-gutters{margin-right:0;margin-left:0}.no-gutters>.col,.no-gutters>[class*=col-]{padding-right:0;padding-left:0}.col,.col-1,.col-10,.col-11,.col-12,.col-2,.col-3,.col-4,.col-5,.col-6,.col-7,.col-8,.col-9,.col-auto,.col-lg,.col-lg-1,.col-lg-10,.col-lg-11,.col-lg-12,.col-lg-2,.col-lg-3,.col-lg-4,.col-lg-5,.col-lg-6,.col-lg-7,.col-lg-8,.col-lg-9,.col-lg-auto,.col-md,.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9,.col-md-auto,.col-sm,.col-sm-1,.col-sm-10,.col-sm-11,.col-sm-12,.col-sm-2,.col-sm-3,.col-sm-4,.col-sm-5,.col-sm-6,.col-sm-7,.col-sm-8,.col-sm-9,.col-sm-auto,.col-xl,.col-xl-1,.col-xl-10,.col-xl-11,.col-xl-12,.col-xl-2,.col-xl-3,.col-xl-4,.col-xl-5,.col-xl-6,.col-xl-7,.col-xl-8,.col-xl-9,.col-xl-auto{position:relative;width:100%;min-height:1px;padding-right:15px;padding-left:15px}.col{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;max-width:100%}.col-auto{-ms-flex:0 0 auto;-webkit-box-flex:0;flex:0 0 auto;width:auto;max-width:none}.col-1{-ms-flex:0 0 8.333333%;-webkit-box-flex:0;flex:0 0 8.333333%;max-width:8.333333%}.col-2{-ms-flex:0 0 16.666667%;-webkit-box-flex:0;flex:0 0 16.666667%;max-width:16.666667%}.col-3{-ms-flex:0 0 25%;-webkit-box-flex:0;flex:0 0 25%;max-width:25%}.col-4{-ms-flex:0 0 33.333333%;-webkit-box-flex:0;flex:0 0 33.333333%;max-width:33.333333%}.col-5{-ms-flex:0 0 41.666667%;-webkit-box-flex:0;flex:0 0 41.666667%;max-width:41.666667%}.col-6{-ms-flex:0 0 50%;-webkit-box-flex:0;flex:0 0 50%;max-width:50%}.col-7{-ms-flex:0 0 58.333333%;-webkit-box-flex:0;flex:0 0 58.333333%;max-width:58.333333%}.col-8{-ms-flex:0 0 66.666667%;-webkit-box-flex:0;flex:0 0 66.666667%;max-width:66.666667%}.col-9{-ms-flex:0 0 75%;-webkit-box-flex:0;flex:0 0 75%;max-width:75%}.col-10{-ms-flex:0 0 83.333333%;-webkit-box-flex:0;flex:0 0 83.333333%;max-width:83.333333%}.col-11{-ms-flex:0 0 91.666667%;-webkit-box-flex:0;flex:0 0 91.666667%;max-width:91.666667%}.col-12{-ms-flex:0 0 100%;-webkit-box-flex:0;flex:0 0 100%;max-width:100%}.order-first{-ms-flex-order:-1;-webkit-box-ordinal-group:0;order:-1}.order-last{-ms-flex-order:13;-webkit-box-ordinal-group:14;order:13}.order-0{-ms-flex-order:0;-webkit-box-ordinal-group:1;order:0}.order-1{-ms-flex-order:1;-webkit-box-ordinal-group:2;order:1}.order-2{-ms-flex-order:2;-webkit-box-ordinal-group:3;order:2}.order-3{-ms-flex-order:3;-webkit-box-ordinal-group:4;order:3}.order-4{-ms-flex-order:4;-webkit-box-ordinal-group:5;order:4}.order-5{-ms-flex-order:5;-webkit-box-ordinal-group:6;order:5}.order-6{-ms-flex-order:6;-webkit-box-ordinal-group:7;order:6}.order-7{-ms-flex-order:7;-webkit-box-ordinal-group:8;order:7}.order-8{-ms-flex-order:8;-webkit-box-ordinal-group:9;order:8}.order-9{-ms-flex-order:9;-webkit-box-ordinal-group:10;order:9}.order-10{-ms-flex-order:10;-webkit-box-ordinal-group:11;order:10}.order-11{-ms-flex-order:11;-webkit-box-ordinal-group:12;order:11}.order-12{-ms-flex-order:12;-webkit-box-ordinal-group:13;order:12}.offset-1{margin-left:8.333333%}.offset-2{margin-left:16.666667%}.offset-3{margin-left:25%}.offset-4{margin-left:33.333333%}.offset-5{margin-left:41.666667%}.offset-6{margin-left:50%}.offset-7{margin-left:58.333333%}.offset-8{margin-left:66.666667%}.offset-9{margin-left:75%}.offset-10{margin-left:83.333333%}.offset-11{margin-left:91.666667%}\@media (min-width:576px){.col-sm{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;max-width:100%}.col-sm-auto{-ms-flex:0 0 auto;-webkit-box-flex:0;flex:0 0 auto;width:auto;max-width:none}.col-sm-1{-ms-flex:0 0 8.333333%;-webkit-box-flex:0;flex:0 0 8.333333%;max-width:8.333333%}.col-sm-2{-ms-flex:0 0 16.666667%;-webkit-box-flex:0;flex:0 0 16.666667%;max-width:16.666667%}.col-sm-3{-ms-flex:0 0 25%;-webkit-box-flex:0;flex:0 0 25%;max-width:25%}.col-sm-4{-ms-flex:0 0 33.333333%;-webkit-box-flex:0;flex:0 0 33.333333%;max-width:33.333333%}.col-sm-5{-ms-flex:0 0 41.666667%;-webkit-box-flex:0;flex:0 0 41.666667%;max-width:41.666667%}.col-sm-6{-ms-flex:0 0 50%;-webkit-box-flex:0;flex:0 0 50%;max-width:50%}.col-sm-7{-ms-flex:0 0 58.333333%;-webkit-box-flex:0;flex:0 0 58.333333%;max-width:58.333333%}.col-sm-8{-ms-flex:0 0 66.666667%;-webkit-box-flex:0;flex:0 0 66.666667%;max-width:66.666667%}.col-sm-9{-ms-flex:0 0 75%;-webkit-box-flex:0;flex:0 0 75%;max-width:75%}.col-sm-10{-ms-flex:0 0 83.333333%;-webkit-box-flex:0;flex:0 0 83.333333%;max-width:83.333333%}.col-sm-11{-ms-flex:0 0 91.666667%;-webkit-box-flex:0;flex:0 0 91.666667%;max-width:91.666667%}.col-sm-12{-ms-flex:0 0 100%;-webkit-box-flex:0;flex:0 0 100%;max-width:100%}.order-sm-first{-ms-flex-order:-1;-webkit-box-ordinal-group:0;order:-1}.order-sm-last{-ms-flex-order:13;-webkit-box-ordinal-group:14;order:13}.order-sm-0{-ms-flex-order:0;-webkit-box-ordinal-group:1;order:0}.order-sm-1{-ms-flex-order:1;-webkit-box-ordinal-group:2;order:1}.order-sm-2{-ms-flex-order:2;-webkit-box-ordinal-group:3;order:2}.order-sm-3{-ms-flex-order:3;-webkit-box-ordinal-group:4;order:3}.order-sm-4{-ms-flex-order:4;-webkit-box-ordinal-group:5;order:4}.order-sm-5{-ms-flex-order:5;-webkit-box-ordinal-group:6;order:5}.order-sm-6{-ms-flex-order:6;-webkit-box-ordinal-group:7;order:6}.order-sm-7{-ms-flex-order:7;-webkit-box-ordinal-group:8;order:7}.order-sm-8{-ms-flex-order:8;-webkit-box-ordinal-group:9;order:8}.order-sm-9{-ms-flex-order:9;-webkit-box-ordinal-group:10;order:9}.order-sm-10{-ms-flex-order:10;-webkit-box-ordinal-group:11;order:10}.order-sm-11{-ms-flex-order:11;-webkit-box-ordinal-group:12;order:11}.order-sm-12{-ms-flex-order:12;-webkit-box-ordinal-group:13;order:12}.offset-sm-0{margin-left:0}.offset-sm-1{margin-left:8.333333%}.offset-sm-2{margin-left:16.666667%}.offset-sm-3{margin-left:25%}.offset-sm-4{margin-left:33.333333%}.offset-sm-5{margin-left:41.666667%}.offset-sm-6{margin-left:50%}.offset-sm-7{margin-left:58.333333%}.offset-sm-8{margin-left:66.666667%}.offset-sm-9{margin-left:75%}.offset-sm-10{margin-left:83.333333%}.offset-sm-11{margin-left:91.666667%}}\@media (min-width:768px){.col-md{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;max-width:100%}.col-md-auto{-ms-flex:0 0 auto;-webkit-box-flex:0;flex:0 0 auto;width:auto;max-width:none}.col-md-1{-ms-flex:0 0 8.333333%;-webkit-box-flex:0;flex:0 0 8.333333%;max-width:8.333333%}.col-md-2{-ms-flex:0 0 16.666667%;-webkit-box-flex:0;flex:0 0 16.666667%;max-width:16.666667%}.col-md-3{-ms-flex:0 0 25%;-webkit-box-flex:0;flex:0 0 25%;max-width:25%}.col-md-4{-ms-flex:0 0 33.333333%;-webkit-box-flex:0;flex:0 0 33.333333%;max-width:33.333333%}.col-md-5{-ms-flex:0 0 41.666667%;-webkit-box-flex:0;flex:0 0 41.666667%;max-width:41.666667%}.col-md-6{-ms-flex:0 0 50%;-webkit-box-flex:0;flex:0 0 50%;max-width:50%}.col-md-7{-ms-flex:0 0 58.333333%;-webkit-box-flex:0;flex:0 0 58.333333%;max-width:58.333333%}.col-md-8{-ms-flex:0 0 66.666667%;-webkit-box-flex:0;flex:0 0 66.666667%;max-width:66.666667%}.col-md-9{-ms-flex:0 0 75%;-webkit-box-flex:0;flex:0 0 75%;max-width:75%}.col-md-10{-ms-flex:0 0 83.333333%;-webkit-box-flex:0;flex:0 0 83.333333%;max-width:83.333333%}.col-md-11{-ms-flex:0 0 91.666667%;-webkit-box-flex:0;flex:0 0 91.666667%;max-width:91.666667%}.col-md-12{-ms-flex:0 0 100%;-webkit-box-flex:0;flex:0 0 100%;max-width:100%}.order-md-first{-ms-flex-order:-1;-webkit-box-ordinal-group:0;order:-1}.order-md-last{-ms-flex-order:13;-webkit-box-ordinal-group:14;order:13}.order-md-0{-ms-flex-order:0;-webkit-box-ordinal-group:1;order:0}.order-md-1{-ms-flex-order:1;-webkit-box-ordinal-group:2;order:1}.order-md-2{-ms-flex-order:2;-webkit-box-ordinal-group:3;order:2}.order-md-3{-ms-flex-order:3;-webkit-box-ordinal-group:4;order:3}.order-md-4{-ms-flex-order:4;-webkit-box-ordinal-group:5;order:4}.order-md-5{-ms-flex-order:5;-webkit-box-ordinal-group:6;order:5}.order-md-6{-ms-flex-order:6;-webkit-box-ordinal-group:7;order:6}.order-md-7{-ms-flex-order:7;-webkit-box-ordinal-group:8;order:7}.order-md-8{-ms-flex-order:8;-webkit-box-ordinal-group:9;order:8}.order-md-9{-ms-flex-order:9;-webkit-box-ordinal-group:10;order:9}.order-md-10{-ms-flex-order:10;-webkit-box-ordinal-group:11;order:10}.order-md-11{-ms-flex-order:11;-webkit-box-ordinal-group:12;order:11}.order-md-12{-ms-flex-order:12;-webkit-box-ordinal-group:13;order:12}.offset-md-0{margin-left:0}.offset-md-1{margin-left:8.333333%}.offset-md-2{margin-left:16.666667%}.offset-md-3{margin-left:25%}.offset-md-4{margin-left:33.333333%}.offset-md-5{margin-left:41.666667%}.offset-md-6{margin-left:50%}.offset-md-7{margin-left:58.333333%}.offset-md-8{margin-left:66.666667%}.offset-md-9{margin-left:75%}.offset-md-10{margin-left:83.333333%}.offset-md-11{margin-left:91.666667%}}\@media (min-width:992px){.col-lg{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;max-width:100%}.col-lg-auto{-ms-flex:0 0 auto;-webkit-box-flex:0;flex:0 0 auto;width:auto;max-width:none}.col-lg-1{-ms-flex:0 0 8.333333%;-webkit-box-flex:0;flex:0 0 8.333333%;max-width:8.333333%}.col-lg-2{-ms-flex:0 0 16.666667%;-webkit-box-flex:0;flex:0 0 16.666667%;max-width:16.666667%}.col-lg-3{-ms-flex:0 0 25%;-webkit-box-flex:0;flex:0 0 25%;max-width:25%}.col-lg-4{-ms-flex:0 0 33.333333%;-webkit-box-flex:0;flex:0 0 33.333333%;max-width:33.333333%}.col-lg-5{-ms-flex:0 0 41.666667%;-webkit-box-flex:0;flex:0 0 41.666667%;max-width:41.666667%}.col-lg-6{-ms-flex:0 0 50%;-webkit-box-flex:0;flex:0 0 50%;max-width:50%}.col-lg-7{-ms-flex:0 0 58.333333%;-webkit-box-flex:0;flex:0 0 58.333333%;max-width:58.333333%}.col-lg-8{-ms-flex:0 0 66.666667%;-webkit-box-flex:0;flex:0 0 66.666667%;max-width:66.666667%}.col-lg-9{-ms-flex:0 0 75%;-webkit-box-flex:0;flex:0 0 75%;max-width:75%}.col-lg-10{-ms-flex:0 0 83.333333%;-webkit-box-flex:0;flex:0 0 83.333333%;max-width:83.333333%}.col-lg-11{-ms-flex:0 0 91.666667%;-webkit-box-flex:0;flex:0 0 91.666667%;max-width:91.666667%}.col-lg-12{-ms-flex:0 0 100%;-webkit-box-flex:0;flex:0 0 100%;max-width:100%}.order-lg-first{-ms-flex-order:-1;-webkit-box-ordinal-group:0;order:-1}.order-lg-last{-ms-flex-order:13;-webkit-box-ordinal-group:14;order:13}.order-lg-0{-ms-flex-order:0;-webkit-box-ordinal-group:1;order:0}.order-lg-1{-ms-flex-order:1;-webkit-box-ordinal-group:2;order:1}.order-lg-2{-ms-flex-order:2;-webkit-box-ordinal-group:3;order:2}.order-lg-3{-ms-flex-order:3;-webkit-box-ordinal-group:4;order:3}.order-lg-4{-ms-flex-order:4;-webkit-box-ordinal-group:5;order:4}.order-lg-5{-ms-flex-order:5;-webkit-box-ordinal-group:6;order:5}.order-lg-6{-ms-flex-order:6;-webkit-box-ordinal-group:7;order:6}.order-lg-7{-ms-flex-order:7;-webkit-box-ordinal-group:8;order:7}.order-lg-8{-ms-flex-order:8;-webkit-box-ordinal-group:9;order:8}.order-lg-9{-ms-flex-order:9;-webkit-box-ordinal-group:10;order:9}.order-lg-10{-ms-flex-order:10;-webkit-box-ordinal-group:11;order:10}.order-lg-11{-ms-flex-order:11;-webkit-box-ordinal-group:12;order:11}.order-lg-12{-ms-flex-order:12;-webkit-box-ordinal-group:13;order:12}.offset-lg-0{margin-left:0}.offset-lg-1{margin-left:8.333333%}.offset-lg-2{margin-left:16.666667%}.offset-lg-3{margin-left:25%}.offset-lg-4{margin-left:33.333333%}.offset-lg-5{margin-left:41.666667%}.offset-lg-6{margin-left:50%}.offset-lg-7{margin-left:58.333333%}.offset-lg-8{margin-left:66.666667%}.offset-lg-9{margin-left:75%}.offset-lg-10{margin-left:83.333333%}.offset-lg-11{margin-left:91.666667%}}\@media (min-width:1200px){.col-xl{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;max-width:100%}.col-xl-auto{-ms-flex:0 0 auto;-webkit-box-flex:0;flex:0 0 auto;width:auto;max-width:none}.col-xl-1{-ms-flex:0 0 8.333333%;-webkit-box-flex:0;flex:0 0 8.333333%;max-width:8.333333%}.col-xl-2{-ms-flex:0 0 16.666667%;-webkit-box-flex:0;flex:0 0 16.666667%;max-width:16.666667%}.col-xl-3{-ms-flex:0 0 25%;-webkit-box-flex:0;flex:0 0 25%;max-width:25%}.col-xl-4{-ms-flex:0 0 33.333333%;-webkit-box-flex:0;flex:0 0 33.333333%;max-width:33.333333%}.col-xl-5{-ms-flex:0 0 41.666667%;-webkit-box-flex:0;flex:0 0 41.666667%;max-width:41.666667%}.col-xl-6{-ms-flex:0 0 50%;-webkit-box-flex:0;flex:0 0 50%;max-width:50%}.col-xl-7{-ms-flex:0 0 58.333333%;-webkit-box-flex:0;flex:0 0 58.333333%;max-width:58.333333%}.col-xl-8{-ms-flex:0 0 66.666667%;-webkit-box-flex:0;flex:0 0 66.666667%;max-width:66.666667%}.col-xl-9{-ms-flex:0 0 75%;-webkit-box-flex:0;flex:0 0 75%;max-width:75%}.col-xl-10{-ms-flex:0 0 83.333333%;-webkit-box-flex:0;flex:0 0 83.333333%;max-width:83.333333%}.col-xl-11{-ms-flex:0 0 91.666667%;-webkit-box-flex:0;flex:0 0 91.666667%;max-width:91.666667%}.col-xl-12{-ms-flex:0 0 100%;-webkit-box-flex:0;flex:0 0 100%;max-width:100%}.order-xl-first{-ms-flex-order:-1;-webkit-box-ordinal-group:0;order:-1}.order-xl-last{-ms-flex-order:13;-webkit-box-ordinal-group:14;order:13}.order-xl-0{-ms-flex-order:0;-webkit-box-ordinal-group:1;order:0}.order-xl-1{-ms-flex-order:1;-webkit-box-ordinal-group:2;order:1}.order-xl-2{-ms-flex-order:2;-webkit-box-ordinal-group:3;order:2}.order-xl-3{-ms-flex-order:3;-webkit-box-ordinal-group:4;order:3}.order-xl-4{-ms-flex-order:4;-webkit-box-ordinal-group:5;order:4}.order-xl-5{-ms-flex-order:5;-webkit-box-ordinal-group:6;order:5}.order-xl-6{-ms-flex-order:6;-webkit-box-ordinal-group:7;order:6}.order-xl-7{-ms-flex-order:7;-webkit-box-ordinal-group:8;order:7}.order-xl-8{-ms-flex-order:8;-webkit-box-ordinal-group:9;order:8}.order-xl-9{-ms-flex-order:9;-webkit-box-ordinal-group:10;order:9}.order-xl-10{-ms-flex-order:10;-webkit-box-ordinal-group:11;order:10}.order-xl-11{-ms-flex-order:11;-webkit-box-ordinal-group:12;order:11}.order-xl-12{-ms-flex-order:12;-webkit-box-ordinal-group:13;order:12}.offset-xl-0{margin-left:0}.offset-xl-1{margin-left:8.333333%}.offset-xl-2{margin-left:16.666667%}.offset-xl-3{margin-left:25%}.offset-xl-4{margin-left:33.333333%}.offset-xl-5{margin-left:41.666667%}.offset-xl-6{margin-left:50%}.offset-xl-7{margin-left:58.333333%}.offset-xl-8{margin-left:66.666667%}.offset-xl-9{margin-left:75%}.offset-xl-10{margin-left:83.333333%}.offset-xl-11{margin-left:91.666667%}}.table{width:100%;max-width:100%;margin-bottom:1rem;background-color:transparent}.table td,.table th{padding:.75rem;vertical-align:top;border-top:1px solid #dee2e6}.table thead th{vertical-align:bottom;border-bottom:2px solid #dee2e6}.table tbody+tbody{border-top:2px solid #dee2e6}.table .table{background-color:#fff}.table-sm td,.table-sm th{padding:.3rem}.table-bordered,.table-bordered td,.table-bordered th{border:1px solid #dee2e6}.table-bordered thead td,.table-bordered thead th{border-bottom-width:2px}.table-borderless tbody+tbody,.table-borderless td,.table-borderless th,.table-borderless thead th{border:0}.table-striped tbody tr:nth-of-type(odd){background-color:rgba(0,0,0,.05)}.table-hover tbody tr:hover{background-color:rgba(0,0,0,.075)}.table-primary,.table-primary>td,.table-primary>th{background-color:#b8daff}.table-hover .table-primary:hover,.table-hover .table-primary:hover>td,.table-hover .table-primary:hover>th{background-color:#9fcdff}.table-secondary,.table-secondary>td,.table-secondary>th{background-color:#d6d8db}.table-hover .table-secondary:hover,.table-hover .table-secondary:hover>td,.table-hover .table-secondary:hover>th{background-color:#c8cbcf}.table-success,.table-success>td,.table-success>th{background-color:#c3e6cb}.table-hover .table-success:hover,.table-hover .table-success:hover>td,.table-hover .table-success:hover>th{background-color:#b1dfbb}.table-info,.table-info>td,.table-info>th{background-color:#bee5eb}.table-hover .table-info:hover,.table-hover .table-info:hover>td,.table-hover .table-info:hover>th{background-color:#abdde5}.table-warning,.table-warning>td,.table-warning>th{background-color:#ffeeba}.table-hover .table-warning:hover,.table-hover .table-warning:hover>td,.table-hover .table-warning:hover>th{background-color:#ffe8a1}.table-danger,.table-danger>td,.table-danger>th{background-color:#f5c6cb}.table-hover .table-danger:hover,.table-hover .table-danger:hover>td,.table-hover .table-danger:hover>th{background-color:#f1b0b7}.table-light,.table-light>td,.table-light>th{background-color:#fdfdfe}.table-hover .table-light:hover,.table-hover .table-light:hover>td,.table-hover .table-light:hover>th{background-color:#ececf6}.table-dark,.table-dark>td,.table-dark>th{background-color:#c6c8ca}.table-hover .table-dark:hover,.table-hover .table-dark:hover>td,.table-hover .table-dark:hover>th{background-color:#b9bbbe}.table-active,.table-active>td,.table-active>th,.table-hover .table-active:hover,.table-hover .table-active:hover>td,.table-hover .table-active:hover>th{background-color:rgba(0,0,0,.075)}.table .thead-dark th{color:#fff;background-color:#212529;border-color:#32383e}.table .thead-light th{color:#495057;background-color:#e9ecef;border-color:#dee2e6}.table-dark{color:#fff;background-color:#212529}.table-dark td,.table-dark th,.table-dark thead th{border-color:#32383e}.table-dark.table-bordered{border:0}.table-dark.table-striped tbody tr:nth-of-type(odd){background-color:rgba(255,255,255,.05)}.table-dark.table-hover tbody tr:hover{background-color:rgba(255,255,255,.075)}\@media (max-width:575.98px){.table-responsive-sm{display:block;width:100%;overflow-x:auto;-webkit-overflow-scrolling:touch;-ms-overflow-style:-ms-autohiding-scrollbar}.table-responsive-sm>.table-bordered{border:0}}\@media (max-width:767.98px){.table-responsive-md{display:block;width:100%;overflow-x:auto;-webkit-overflow-scrolling:touch;-ms-overflow-style:-ms-autohiding-scrollbar}.table-responsive-md>.table-bordered{border:0}}\@media (max-width:991.98px){.table-responsive-lg{display:block;width:100%;overflow-x:auto;-webkit-overflow-scrolling:touch;-ms-overflow-style:-ms-autohiding-scrollbar}.table-responsive-lg>.table-bordered{border:0}}\@media (max-width:1199.98px){.table-responsive-xl{display:block;width:100%;overflow-x:auto;-webkit-overflow-scrolling:touch;-ms-overflow-style:-ms-autohiding-scrollbar}.table-responsive-xl>.table-bordered{border:0}}.table-responsive{display:block;width:100%;overflow-x:auto;-webkit-overflow-scrolling:touch;-ms-overflow-style:-ms-autohiding-scrollbar}.table-responsive>.table-bordered{border:0}.form-control{display:block;width:100%;padding:.375rem .75rem;font-size:1rem;line-height:1.5;color:#495057;background-color:#fff;background-clip:padding-box;border:1px solid #ced4da;border-radius:.25rem;-webkit-transition:border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:border-color .15s ease-in-out,box-shadow .15s ease-in-out;transition:border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out}\@media screen and (prefers-reduced-motion:reduce){.form-control{-webkit-transition:none;transition:none}}.form-control::-ms-expand{background-color:transparent;border:0}.form-control:focus{color:#495057;background-color:#fff;border-color:#80bdff;outline:0;-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.25);box-shadow:0 0 0 .2rem rgba(0,123,255,.25)}.form-control::-webkit-input-placeholder{color:#6c757d;opacity:1}.form-control::-moz-placeholder{color:#6c757d;opacity:1}.form-control:-ms-input-placeholder{color:#6c757d;opacity:1}.form-control::-ms-input-placeholder{color:#6c757d;opacity:1}.form-control::placeholder{color:#6c757d;opacity:1}.form-control:disabled,.form-control[readonly]{background-color:#e9ecef;opacity:1}select.form-control:not([size]):not([multiple]){height:calc(2.25rem + 2px)}select.form-control:focus::-ms-value{color:#495057;background-color:#fff}.form-control-file,.form-control-range{display:block;width:100%}.col-form-label{padding-top:calc(.375rem + 1px);padding-bottom:calc(.375rem + 1px);margin-bottom:0;font-size:inherit;line-height:1.5}.col-form-label-lg{padding-top:calc(.5rem + 1px);padding-bottom:calc(.5rem + 1px);font-size:1.25rem;line-height:1.5}.col-form-label-sm{padding-top:calc(.25rem + 1px);padding-bottom:calc(.25rem + 1px);font-size:.875rem;line-height:1.5}.form-control-plaintext{display:block;width:100%;padding-top:.375rem;padding-bottom:.375rem;margin-bottom:0;line-height:1.5;color:#212529;background-color:transparent;border:solid transparent;border-width:1px 0}.form-control-plaintext.form-control-lg,.form-control-plaintext.form-control-sm,.input-group-lg>.form-control-plaintext.form-control,.input-group-lg>.input-group-append>.form-control-plaintext.btn,.input-group-lg>.input-group-append>.form-control-plaintext.input-group-text,.input-group-lg>.input-group-prepend>.form-control-plaintext.btn,.input-group-lg>.input-group-prepend>.form-control-plaintext.input-group-text,.input-group-sm>.form-control-plaintext.form-control,.input-group-sm>.input-group-append>.form-control-plaintext.btn,.input-group-sm>.input-group-append>.form-control-plaintext.input-group-text,.input-group-sm>.input-group-prepend>.form-control-plaintext.btn,.input-group-sm>.input-group-prepend>.form-control-plaintext.input-group-text{padding-right:0;padding-left:0}.form-control-sm,.input-group-sm>.form-control,.input-group-sm>.input-group-append>.btn,.input-group-sm>.input-group-append>.input-group-text,.input-group-sm>.input-group-prepend>.btn,.input-group-sm>.input-group-prepend>.input-group-text{padding:.25rem .5rem;font-size:.875rem;line-height:1.5;border-radius:.2rem}.input-group-sm>.input-group-append>select.btn:not([size]):not([multiple]),.input-group-sm>.input-group-append>select.input-group-text:not([size]):not([multiple]),.input-group-sm>.input-group-prepend>select.btn:not([size]):not([multiple]),.input-group-sm>.input-group-prepend>select.input-group-text:not([size]):not([multiple]),.input-group-sm>select.form-control:not([size]):not([multiple]),select.form-control-sm:not([size]):not([multiple]){height:calc(1.8125rem + 2px)}.form-control-lg,.input-group-lg>.form-control,.input-group-lg>.input-group-append>.btn,.input-group-lg>.input-group-append>.input-group-text,.input-group-lg>.input-group-prepend>.btn,.input-group-lg>.input-group-prepend>.input-group-text{padding:.5rem 1rem;font-size:1.25rem;line-height:1.5;border-radius:.3rem}.input-group-lg>.input-group-append>select.btn:not([size]):not([multiple]),.input-group-lg>.input-group-append>select.input-group-text:not([size]):not([multiple]),.input-group-lg>.input-group-prepend>select.btn:not([size]):not([multiple]),.input-group-lg>.input-group-prepend>select.input-group-text:not([size]):not([multiple]),.input-group-lg>select.form-control:not([size]):not([multiple]),select.form-control-lg:not([size]):not([multiple]){height:calc(2.875rem + 2px)}.form-group{margin-bottom:1rem}.form-text{display:block;margin-top:.25rem}.form-row{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;margin-right:-5px;margin-left:-5px}.form-row>.col,.form-row>[class*=col-]{padding-right:5px;padding-left:5px}.form-check{position:relative;display:block;padding-left:1.25rem}.form-check-input{position:absolute;margin-top:.3rem;margin-left:-1.25rem}.form-check-input:disabled~.form-check-label{color:#6c757d}.form-check-label{margin-bottom:0}.form-check-inline{display:-ms-inline-flexbox;display:-webkit-inline-box;display:inline-flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;padding-left:0;margin-right:.75rem}.form-check-inline .form-check-input{position:static;margin-top:0;margin-right:.3125rem;margin-left:0}.valid-feedback{display:none;width:100%;margin-top:.25rem;font-size:80%;color:#28a745}.valid-tooltip{position:absolute;top:100%;z-index:5;display:none;max-width:100%;padding:.5rem;margin-top:.1rem;font-size:.875rem;line-height:1;color:#fff;background-color:rgba(40,167,69,.8);border-radius:.2rem}.custom-select.is-valid,.form-control.is-valid,.was-validated .custom-select:valid,.was-validated .form-control:valid{border-color:#28a745}.custom-select.is-valid:focus,.form-control.is-valid:focus,.was-validated .custom-select:valid:focus,.was-validated .form-control:valid:focus{border-color:#28a745;-webkit-box-shadow:0 0 0 .2rem rgba(40,167,69,.25);box-shadow:0 0 0 .2rem rgba(40,167,69,.25)}.custom-select.is-valid~.valid-feedback,.custom-select.is-valid~.valid-tooltip,.form-control.is-valid~.valid-feedback,.form-control.is-valid~.valid-tooltip,.was-validated .custom-select:valid~.valid-feedback,.was-validated .custom-select:valid~.valid-tooltip,.was-validated .form-control:valid~.valid-feedback,.was-validated .form-control:valid~.valid-tooltip{display:block}.form-control-file.is-valid~.valid-feedback,.form-control-file.is-valid~.valid-tooltip,.was-validated .form-control-file:valid~.valid-feedback,.was-validated .form-control-file:valid~.valid-tooltip{display:block}.form-check-input.is-valid~.form-check-label,.was-validated .form-check-input:valid~.form-check-label{color:#28a745}.form-check-input.is-valid~.valid-feedback,.form-check-input.is-valid~.valid-tooltip,.was-validated .form-check-input:valid~.valid-feedback,.was-validated .form-check-input:valid~.valid-tooltip{display:block}.custom-control-input.is-valid~.custom-control-label,.was-validated .custom-control-input:valid~.custom-control-label{color:#28a745}.custom-control-input.is-valid~.custom-control-label::before,.was-validated .custom-control-input:valid~.custom-control-label::before{background-color:#71dd8a}.custom-control-input.is-valid~.valid-feedback,.custom-control-input.is-valid~.valid-tooltip,.was-validated .custom-control-input:valid~.valid-feedback,.was-validated .custom-control-input:valid~.valid-tooltip{display:block}.custom-control-input.is-valid:checked~.custom-control-label::before,.was-validated .custom-control-input:valid:checked~.custom-control-label::before{background-color:#34ce57}.custom-control-input.is-valid:focus~.custom-control-label::before,.was-validated .custom-control-input:valid:focus~.custom-control-label::before{-webkit-box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(40,167,69,.25);box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(40,167,69,.25)}.custom-file-input.is-valid~.custom-file-label,.was-validated .custom-file-input:valid~.custom-file-label{border-color:#28a745}.custom-file-input.is-valid~.custom-file-label::before,.was-validated .custom-file-input:valid~.custom-file-label::before{border-color:inherit}.custom-file-input.is-valid~.valid-feedback,.custom-file-input.is-valid~.valid-tooltip,.was-validated .custom-file-input:valid~.valid-feedback,.was-validated .custom-file-input:valid~.valid-tooltip{display:block}.custom-file-input.is-valid:focus~.custom-file-label,.was-validated .custom-file-input:valid:focus~.custom-file-label{-webkit-box-shadow:0 0 0 .2rem rgba(40,167,69,.25);box-shadow:0 0 0 .2rem rgba(40,167,69,.25)}.invalid-feedback{display:none;width:100%;margin-top:.25rem;font-size:80%;color:#dc3545}.invalid-tooltip{position:absolute;top:100%;z-index:5;display:none;max-width:100%;padding:.5rem;margin-top:.1rem;font-size:.875rem;line-height:1;color:#fff;background-color:rgba(220,53,69,.8);border-radius:.2rem}.custom-select.is-invalid,.form-control.is-invalid,.was-validated .custom-select:invalid,.was-validated .form-control:invalid{border-color:#dc3545}.custom-select.is-invalid:focus,.form-control.is-invalid:focus,.was-validated .custom-select:invalid:focus,.was-validated .form-control:invalid:focus{border-color:#dc3545;-webkit-box-shadow:0 0 0 .2rem rgba(220,53,69,.25);box-shadow:0 0 0 .2rem rgba(220,53,69,.25)}.custom-select.is-invalid~.invalid-feedback,.custom-select.is-invalid~.invalid-tooltip,.form-control.is-invalid~.invalid-feedback,.form-control.is-invalid~.invalid-tooltip,.was-validated .custom-select:invalid~.invalid-feedback,.was-validated .custom-select:invalid~.invalid-tooltip,.was-validated .form-control:invalid~.invalid-feedback,.was-validated .form-control:invalid~.invalid-tooltip{display:block}.form-control-file.is-invalid~.invalid-feedback,.form-control-file.is-invalid~.invalid-tooltip,.was-validated .form-control-file:invalid~.invalid-feedback,.was-validated .form-control-file:invalid~.invalid-tooltip{display:block}.form-check-input.is-invalid~.form-check-label,.was-validated .form-check-input:invalid~.form-check-label{color:#dc3545}.form-check-input.is-invalid~.invalid-feedback,.form-check-input.is-invalid~.invalid-tooltip,.was-validated .form-check-input:invalid~.invalid-feedback,.was-validated .form-check-input:invalid~.invalid-tooltip{display:block}.custom-control-input.is-invalid~.custom-control-label,.was-validated .custom-control-input:invalid~.custom-control-label{color:#dc3545}.custom-control-input.is-invalid~.custom-control-label::before,.was-validated .custom-control-input:invalid~.custom-control-label::before{background-color:#efa2a9}.custom-control-input.is-invalid~.invalid-feedback,.custom-control-input.is-invalid~.invalid-tooltip,.was-validated .custom-control-input:invalid~.invalid-feedback,.was-validated .custom-control-input:invalid~.invalid-tooltip{display:block}.custom-control-input.is-invalid:checked~.custom-control-label::before,.was-validated .custom-control-input:invalid:checked~.custom-control-label::before{background-color:#e4606d}.custom-control-input.is-invalid:focus~.custom-control-label::before,.was-validated .custom-control-input:invalid:focus~.custom-control-label::before{-webkit-box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(220,53,69,.25);box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(220,53,69,.25)}.custom-file-input.is-invalid~.custom-file-label,.was-validated .custom-file-input:invalid~.custom-file-label{border-color:#dc3545}.custom-file-input.is-invalid~.custom-file-label::before,.was-validated .custom-file-input:invalid~.custom-file-label::before{border-color:inherit}.custom-file-input.is-invalid~.invalid-feedback,.custom-file-input.is-invalid~.invalid-tooltip,.was-validated .custom-file-input:invalid~.invalid-feedback,.was-validated .custom-file-input:invalid~.invalid-tooltip{display:block}.custom-file-input.is-invalid:focus~.custom-file-label,.was-validated .custom-file-input:invalid:focus~.custom-file-label{-webkit-box-shadow:0 0 0 .2rem rgba(220,53,69,.25);box-shadow:0 0 0 .2rem rgba(220,53,69,.25)}.form-inline{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-flow:row wrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row wrap;-ms-flex-align:center;-webkit-box-align:center;align-items:center}.form-inline .form-check{width:100%}\@media (min-width:576px){.form-inline label{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center;margin-bottom:0}.form-inline .form-group{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex:0 0 auto;-webkit-box-flex:0;flex:0 0 auto;-ms-flex-flow:row wrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row wrap;-ms-flex-align:center;-webkit-box-align:center;align-items:center;margin-bottom:0}.form-inline .form-control{display:inline-block;width:auto;vertical-align:middle}.form-inline .form-control-plaintext{display:inline-block}.form-inline .custom-select,.form-inline .input-group{width:auto}.form-inline .form-check{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center;width:auto;padding-left:0}.form-inline .form-check-input{position:relative;margin-top:0;margin-right:.25rem;margin-left:0}.form-inline .custom-control{-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center}.form-inline .custom-control-label{margin-bottom:0}}.btn{display:inline-block;font-weight:400;text-align:center;white-space:nowrap;vertical-align:middle;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;border:1px solid transparent;padding:.375rem .75rem;font-size:1rem;line-height:1.5;border-radius:.25rem;-webkit-transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;transition:color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out}\@media screen and (prefers-reduced-motion:reduce){.btn{-webkit-transition:none;transition:none}}.btn:focus,.btn:hover{text-decoration:none}.btn.focus,.btn:focus{outline:0;-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.25);box-shadow:0 0 0 .2rem rgba(0,123,255,.25)}.btn.disabled,.btn:disabled{opacity:.65}.btn:not(:disabled):not(.disabled){cursor:pointer}.btn:not(:disabled):not(.disabled).active,.btn:not(:disabled):not(.disabled):active{background-image:none}a.btn.disabled,fieldset:disabled a.btn{pointer-events:none}.btn-primary{color:#fff;background-color:#007bff;border-color:#007bff}.btn-primary:hover{color:#fff;background-color:#0069d9;border-color:#0062cc}.btn-primary.focus,.btn-primary:focus{-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.5);box-shadow:0 0 0 .2rem rgba(0,123,255,.5)}.btn-primary.disabled,.btn-primary:disabled{color:#fff;background-color:#007bff;border-color:#007bff}.btn-primary:not(:disabled):not(.disabled).active,.btn-primary:not(:disabled):not(.disabled):active,.show>.btn-primary.dropdown-toggle{color:#fff;background-color:#0062cc;border-color:#005cbf}.btn-primary:not(:disabled):not(.disabled).active:focus,.btn-primary:not(:disabled):not(.disabled):active:focus,.show>.btn-primary.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.5);box-shadow:0 0 0 .2rem rgba(0,123,255,.5)}.btn-secondary{color:#fff;background-color:#6c757d;border-color:#6c757d}.btn-secondary:hover{color:#fff;background-color:#5a6268;border-color:#545b62}.btn-secondary.focus,.btn-secondary:focus{-webkit-box-shadow:0 0 0 .2rem rgba(108,117,125,.5);box-shadow:0 0 0 .2rem rgba(108,117,125,.5)}.btn-secondary.disabled,.btn-secondary:disabled{color:#fff;background-color:#6c757d;border-color:#6c757d}.btn-secondary:not(:disabled):not(.disabled).active,.btn-secondary:not(:disabled):not(.disabled):active,.show>.btn-secondary.dropdown-toggle{color:#fff;background-color:#545b62;border-color:#4e555b}.btn-secondary:not(:disabled):not(.disabled).active:focus,.btn-secondary:not(:disabled):not(.disabled):active:focus,.show>.btn-secondary.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(108,117,125,.5);box-shadow:0 0 0 .2rem rgba(108,117,125,.5)}.btn-success{color:#fff;background-color:#28a745;border-color:#28a745}.btn-success:hover{color:#fff;background-color:#218838;border-color:#1e7e34}.btn-success.focus,.btn-success:focus{-webkit-box-shadow:0 0 0 .2rem rgba(40,167,69,.5);box-shadow:0 0 0 .2rem rgba(40,167,69,.5)}.btn-success.disabled,.btn-success:disabled{color:#fff;background-color:#28a745;border-color:#28a745}.btn-success:not(:disabled):not(.disabled).active,.btn-success:not(:disabled):not(.disabled):active,.show>.btn-success.dropdown-toggle{color:#fff;background-color:#1e7e34;border-color:#1c7430}.btn-success:not(:disabled):not(.disabled).active:focus,.btn-success:not(:disabled):not(.disabled):active:focus,.show>.btn-success.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(40,167,69,.5);box-shadow:0 0 0 .2rem rgba(40,167,69,.5)}.btn-info{color:#fff;background-color:#17a2b8;border-color:#17a2b8}.btn-info:hover{color:#fff;background-color:#138496;border-color:#117a8b}.btn-info.focus,.btn-info:focus{-webkit-box-shadow:0 0 0 .2rem rgba(23,162,184,.5);box-shadow:0 0 0 .2rem rgba(23,162,184,.5)}.btn-info.disabled,.btn-info:disabled{color:#fff;background-color:#17a2b8;border-color:#17a2b8}.btn-info:not(:disabled):not(.disabled).active,.btn-info:not(:disabled):not(.disabled):active,.show>.btn-info.dropdown-toggle{color:#fff;background-color:#117a8b;border-color:#10707f}.btn-info:not(:disabled):not(.disabled).active:focus,.btn-info:not(:disabled):not(.disabled):active:focus,.show>.btn-info.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(23,162,184,.5);box-shadow:0 0 0 .2rem rgba(23,162,184,.5)}.btn-warning{color:#212529;background-color:#ffc107;border-color:#ffc107}.btn-warning:hover{color:#212529;background-color:#e0a800;border-color:#d39e00}.btn-warning.focus,.btn-warning:focus{-webkit-box-shadow:0 0 0 .2rem rgba(255,193,7,.5);box-shadow:0 0 0 .2rem rgba(255,193,7,.5)}.btn-warning.disabled,.btn-warning:disabled{color:#212529;background-color:#ffc107;border-color:#ffc107}.btn-warning:not(:disabled):not(.disabled).active,.btn-warning:not(:disabled):not(.disabled):active,.show>.btn-warning.dropdown-toggle{color:#212529;background-color:#d39e00;border-color:#c69500}.btn-warning:not(:disabled):not(.disabled).active:focus,.btn-warning:not(:disabled):not(.disabled):active:focus,.show>.btn-warning.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(255,193,7,.5);box-shadow:0 0 0 .2rem rgba(255,193,7,.5)}.btn-danger{color:#fff;background-color:#dc3545;border-color:#dc3545}.btn-danger:hover{color:#fff;background-color:#c82333;border-color:#bd2130}.btn-danger.focus,.btn-danger:focus{-webkit-box-shadow:0 0 0 .2rem rgba(220,53,69,.5);box-shadow:0 0 0 .2rem rgba(220,53,69,.5)}.btn-danger.disabled,.btn-danger:disabled{color:#fff;background-color:#dc3545;border-color:#dc3545}.btn-danger:not(:disabled):not(.disabled).active,.btn-danger:not(:disabled):not(.disabled):active,.show>.btn-danger.dropdown-toggle{color:#fff;background-color:#bd2130;border-color:#b21f2d}.btn-danger:not(:disabled):not(.disabled).active:focus,.btn-danger:not(:disabled):not(.disabled):active:focus,.show>.btn-danger.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(220,53,69,.5);box-shadow:0 0 0 .2rem rgba(220,53,69,.5)}.btn-light{color:#212529;background-color:#f8f9fa;border-color:#f8f9fa}.btn-light:hover{color:#212529;background-color:#e2e6ea;border-color:#dae0e5}.btn-light.focus,.btn-light:focus{-webkit-box-shadow:0 0 0 .2rem rgba(248,249,250,.5);box-shadow:0 0 0 .2rem rgba(248,249,250,.5)}.btn-light.disabled,.btn-light:disabled{color:#212529;background-color:#f8f9fa;border-color:#f8f9fa}.btn-light:not(:disabled):not(.disabled).active,.btn-light:not(:disabled):not(.disabled):active,.show>.btn-light.dropdown-toggle{color:#212529;background-color:#dae0e5;border-color:#d3d9df}.btn-light:not(:disabled):not(.disabled).active:focus,.btn-light:not(:disabled):not(.disabled):active:focus,.show>.btn-light.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(248,249,250,.5);box-shadow:0 0 0 .2rem rgba(248,249,250,.5)}.btn-dark{color:#fff;background-color:#343a40;border-color:#343a40}.btn-dark:hover{color:#fff;background-color:#23272b;border-color:#1d2124}.btn-dark.focus,.btn-dark:focus{-webkit-box-shadow:0 0 0 .2rem rgba(52,58,64,.5);box-shadow:0 0 0 .2rem rgba(52,58,64,.5)}.btn-dark.disabled,.btn-dark:disabled{color:#fff;background-color:#343a40;border-color:#343a40}.btn-dark:not(:disabled):not(.disabled).active,.btn-dark:not(:disabled):not(.disabled):active,.show>.btn-dark.dropdown-toggle{color:#fff;background-color:#1d2124;border-color:#171a1d}.btn-dark:not(:disabled):not(.disabled).active:focus,.btn-dark:not(:disabled):not(.disabled):active:focus,.show>.btn-dark.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(52,58,64,.5);box-shadow:0 0 0 .2rem rgba(52,58,64,.5)}.btn-outline-primary{color:#007bff;background-color:transparent;background-image:none;border-color:#007bff}.btn-outline-primary:hover{color:#fff;background-color:#007bff;border-color:#007bff}.btn-outline-primary.focus,.btn-outline-primary:focus{-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.5);box-shadow:0 0 0 .2rem rgba(0,123,255,.5)}.btn-outline-primary.disabled,.btn-outline-primary:disabled{color:#007bff;background-color:transparent}.btn-outline-primary:not(:disabled):not(.disabled).active,.btn-outline-primary:not(:disabled):not(.disabled):active,.show>.btn-outline-primary.dropdown-toggle{color:#fff;background-color:#007bff;border-color:#007bff}.btn-outline-primary:not(:disabled):not(.disabled).active:focus,.btn-outline-primary:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-primary.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.5);box-shadow:0 0 0 .2rem rgba(0,123,255,.5)}.btn-outline-secondary{color:#6c757d;background-color:transparent;background-image:none;border-color:#6c757d}.btn-outline-secondary:hover{color:#fff;background-color:#6c757d;border-color:#6c757d}.btn-outline-secondary.focus,.btn-outline-secondary:focus{-webkit-box-shadow:0 0 0 .2rem rgba(108,117,125,.5);box-shadow:0 0 0 .2rem rgba(108,117,125,.5)}.btn-outline-secondary.disabled,.btn-outline-secondary:disabled{color:#6c757d;background-color:transparent}.btn-outline-secondary:not(:disabled):not(.disabled).active,.btn-outline-secondary:not(:disabled):not(.disabled):active,.show>.btn-outline-secondary.dropdown-toggle{color:#fff;background-color:#6c757d;border-color:#6c757d}.btn-outline-secondary:not(:disabled):not(.disabled).active:focus,.btn-outline-secondary:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-secondary.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(108,117,125,.5);box-shadow:0 0 0 .2rem rgba(108,117,125,.5)}.btn-outline-success{color:#28a745;background-color:transparent;background-image:none;border-color:#28a745}.btn-outline-success:hover{color:#fff;background-color:#28a745;border-color:#28a745}.btn-outline-success.focus,.btn-outline-success:focus{-webkit-box-shadow:0 0 0 .2rem rgba(40,167,69,.5);box-shadow:0 0 0 .2rem rgba(40,167,69,.5)}.btn-outline-success.disabled,.btn-outline-success:disabled{color:#28a745;background-color:transparent}.btn-outline-success:not(:disabled):not(.disabled).active,.btn-outline-success:not(:disabled):not(.disabled):active,.show>.btn-outline-success.dropdown-toggle{color:#fff;background-color:#28a745;border-color:#28a745}.btn-outline-success:not(:disabled):not(.disabled).active:focus,.btn-outline-success:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-success.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(40,167,69,.5);box-shadow:0 0 0 .2rem rgba(40,167,69,.5)}.btn-outline-info{color:#17a2b8;background-color:transparent;background-image:none;border-color:#17a2b8}.btn-outline-info:hover{color:#fff;background-color:#17a2b8;border-color:#17a2b8}.btn-outline-info.focus,.btn-outline-info:focus{-webkit-box-shadow:0 0 0 .2rem rgba(23,162,184,.5);box-shadow:0 0 0 .2rem rgba(23,162,184,.5)}.btn-outline-info.disabled,.btn-outline-info:disabled{color:#17a2b8;background-color:transparent}.btn-outline-info:not(:disabled):not(.disabled).active,.btn-outline-info:not(:disabled):not(.disabled):active,.show>.btn-outline-info.dropdown-toggle{color:#fff;background-color:#17a2b8;border-color:#17a2b8}.btn-outline-info:not(:disabled):not(.disabled).active:focus,.btn-outline-info:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-info.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(23,162,184,.5);box-shadow:0 0 0 .2rem rgba(23,162,184,.5)}.btn-outline-warning{color:#ffc107;background-color:transparent;background-image:none;border-color:#ffc107}.btn-outline-warning:hover{color:#212529;background-color:#ffc107;border-color:#ffc107}.btn-outline-warning.focus,.btn-outline-warning:focus{-webkit-box-shadow:0 0 0 .2rem rgba(255,193,7,.5);box-shadow:0 0 0 .2rem rgba(255,193,7,.5)}.btn-outline-warning.disabled,.btn-outline-warning:disabled{color:#ffc107;background-color:transparent}.btn-outline-warning:not(:disabled):not(.disabled).active,.btn-outline-warning:not(:disabled):not(.disabled):active,.show>.btn-outline-warning.dropdown-toggle{color:#212529;background-color:#ffc107;border-color:#ffc107}.btn-outline-warning:not(:disabled):not(.disabled).active:focus,.btn-outline-warning:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-warning.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(255,193,7,.5);box-shadow:0 0 0 .2rem rgba(255,193,7,.5)}.btn-outline-danger{color:#dc3545;background-color:transparent;background-image:none;border-color:#dc3545}.btn-outline-danger:hover{color:#fff;background-color:#dc3545;border-color:#dc3545}.btn-outline-danger.focus,.btn-outline-danger:focus{-webkit-box-shadow:0 0 0 .2rem rgba(220,53,69,.5);box-shadow:0 0 0 .2rem rgba(220,53,69,.5)}.btn-outline-danger.disabled,.btn-outline-danger:disabled{color:#dc3545;background-color:transparent}.btn-outline-danger:not(:disabled):not(.disabled).active,.btn-outline-danger:not(:disabled):not(.disabled):active,.show>.btn-outline-danger.dropdown-toggle{color:#fff;background-color:#dc3545;border-color:#dc3545}.btn-outline-danger:not(:disabled):not(.disabled).active:focus,.btn-outline-danger:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-danger.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(220,53,69,.5);box-shadow:0 0 0 .2rem rgba(220,53,69,.5)}.btn-outline-light{color:#f8f9fa;background-color:transparent;background-image:none;border-color:#f8f9fa}.btn-outline-light:hover{color:#212529;background-color:#f8f9fa;border-color:#f8f9fa}.btn-outline-light.focus,.btn-outline-light:focus{-webkit-box-shadow:0 0 0 .2rem rgba(248,249,250,.5);box-shadow:0 0 0 .2rem rgba(248,249,250,.5)}.btn-outline-light.disabled,.btn-outline-light:disabled{color:#f8f9fa;background-color:transparent}.btn-outline-light:not(:disabled):not(.disabled).active,.btn-outline-light:not(:disabled):not(.disabled):active,.show>.btn-outline-light.dropdown-toggle{color:#212529;background-color:#f8f9fa;border-color:#f8f9fa}.btn-outline-light:not(:disabled):not(.disabled).active:focus,.btn-outline-light:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-light.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(248,249,250,.5);box-shadow:0 0 0 .2rem rgba(248,249,250,.5)}.btn-outline-dark{color:#343a40;background-color:transparent;background-image:none;border-color:#343a40}.btn-outline-dark:hover{color:#fff;background-color:#343a40;border-color:#343a40}.btn-outline-dark.focus,.btn-outline-dark:focus{-webkit-box-shadow:0 0 0 .2rem rgba(52,58,64,.5);box-shadow:0 0 0 .2rem rgba(52,58,64,.5)}.btn-outline-dark.disabled,.btn-outline-dark:disabled{color:#343a40;background-color:transparent}.btn-outline-dark:not(:disabled):not(.disabled).active,.btn-outline-dark:not(:disabled):not(.disabled):active,.show>.btn-outline-dark.dropdown-toggle{color:#fff;background-color:#343a40;border-color:#343a40}.btn-outline-dark:not(:disabled):not(.disabled).active:focus,.btn-outline-dark:not(:disabled):not(.disabled):active:focus,.show>.btn-outline-dark.dropdown-toggle:focus{-webkit-box-shadow:0 0 0 .2rem rgba(52,58,64,.5);box-shadow:0 0 0 .2rem rgba(52,58,64,.5)}.btn-link{font-weight:400;color:#007bff;background-color:transparent}.btn-link:hover{color:#0056b3;text-decoration:underline;background-color:transparent;border-color:transparent}.btn-link.focus,.btn-link:focus{text-decoration:underline;border-color:transparent;-webkit-box-shadow:none;box-shadow:none}.btn-link.disabled,.btn-link:disabled{color:#6c757d;pointer-events:none}.btn-group-lg>.btn,.btn-lg{padding:.5rem 1rem;font-size:1.25rem;line-height:1.5;border-radius:.3rem}.btn-group-sm>.btn,.btn-sm{padding:.25rem .5rem;font-size:.875rem;line-height:1.5;border-radius:.2rem}.btn-block{display:block;width:100%}.btn-block+.btn-block{margin-top:.5rem}input[type=button].btn-block,input[type=reset].btn-block,input[type=submit].btn-block{width:100%}.fade{-webkit-transition:opacity .15s linear;transition:opacity .15s linear}\@media screen and (prefers-reduced-motion:reduce){.fade{-webkit-transition:none;transition:none}}.fade:not(.show){opacity:0}.collapse:not(.show){display:none}.collapsing{position:relative;height:0;overflow:hidden;-webkit-transition:height .35s ease;transition:height .35s ease}\@media screen and (prefers-reduced-motion:reduce){.collapsing{-webkit-transition:none;transition:none}}.dropdown,.dropleft,.dropright,.dropup{position:relative}.dropdown-toggle::after{display:inline-block;width:0;height:0;margin-left:.255em;vertical-align:.255em;content:\"\";border-top:.3em solid;border-right:.3em solid transparent;border-bottom:0;border-left:.3em solid transparent}.dropdown-toggle:empty::after{margin-left:0}.dropdown-menu{position:absolute;top:100%;left:0;z-index:1000;display:none;float:left;min-width:10rem;padding:.5rem 0;margin:.125rem 0 0;font-size:1rem;color:#212529;text-align:left;list-style:none;background-color:#fff;background-clip:padding-box;border:1px solid rgba(0,0,0,.15);border-radius:.25rem}.dropdown-menu-right{right:0;left:auto}.dropup .dropdown-menu{top:auto;bottom:100%;margin-top:0;margin-bottom:.125rem}.dropup .dropdown-toggle::after{display:inline-block;width:0;height:0;margin-left:.255em;vertical-align:.255em;content:\"\";border-top:0;border-right:.3em solid transparent;border-bottom:.3em solid;border-left:.3em solid transparent}.dropup .dropdown-toggle:empty::after{margin-left:0}.dropright .dropdown-menu{top:0;right:auto;left:100%;margin-top:0;margin-left:.125rem}.dropright .dropdown-toggle::after{display:inline-block;width:0;height:0;margin-left:.255em;content:\"\";border-top:.3em solid transparent;border-right:0;border-bottom:.3em solid transparent;border-left:.3em solid;vertical-align:0}.dropright .dropdown-toggle:empty::after{margin-left:0}.dropleft .dropdown-menu{top:0;right:100%;left:auto;margin-top:0;margin-right:.125rem}.dropleft .dropdown-toggle::after{width:0;height:0;margin-left:.255em;vertical-align:.255em;content:\"\";display:none}.dropleft .dropdown-toggle::before{display:inline-block;width:0;height:0;margin-right:.255em;content:\"\";border-top:.3em solid transparent;border-right:.3em solid;border-bottom:.3em solid transparent;vertical-align:0}.dropleft .dropdown-toggle:empty::after{margin-left:0}.dropdown-menu[x-placement^=bottom],.dropdown-menu[x-placement^=left],.dropdown-menu[x-placement^=right],.dropdown-menu[x-placement^=top]{right:auto;bottom:auto}.dropdown-divider{height:0;margin:.5rem 0;overflow:hidden;border-top:1px solid #e9ecef}.dropdown-item{display:block;width:100%;padding:.25rem 1.5rem;clear:both;font-weight:400;color:#212529;text-align:inherit;white-space:nowrap;background-color:transparent;border:0}.dropdown-item:focus,.dropdown-item:hover{color:#16181b;text-decoration:none;background-color:#f8f9fa}.dropdown-item.active,.dropdown-item:active{color:#fff;text-decoration:none;background-color:#007bff}.dropdown-item.disabled,.dropdown-item:disabled{color:#6c757d;background-color:transparent}.dropdown-menu.show{display:block}.dropdown-header{display:block;padding:.5rem 1.5rem;margin-bottom:0;font-size:.875rem;color:#6c757d;white-space:nowrap}.dropdown-item-text{display:block;padding:.25rem 1.5rem;color:#212529}.btn-group,.btn-group-vertical{position:relative;display:-ms-inline-flexbox;display:-webkit-inline-box;display:inline-flex;vertical-align:middle}.btn-group-vertical>.btn,.btn-group>.btn{position:relative;-ms-flex:0 1 auto;-webkit-box-flex:0;flex:0 1 auto}.btn-group-vertical>.btn.active,.btn-group-vertical>.btn:active,.btn-group-vertical>.btn:focus,.btn-group-vertical>.btn:hover,.btn-group>.btn.active,.btn-group>.btn:active,.btn-group>.btn:focus,.btn-group>.btn:hover{z-index:1}.btn-group .btn+.btn,.btn-group .btn+.btn-group,.btn-group .btn-group+.btn,.btn-group .btn-group+.btn-group,.btn-group-vertical .btn+.btn,.btn-group-vertical .btn+.btn-group,.btn-group-vertical .btn-group+.btn,.btn-group-vertical .btn-group+.btn-group{margin-left:-1px}.btn-toolbar{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;-ms-flex-pack:start;-webkit-box-pack:start;justify-content:flex-start}.btn-toolbar .input-group{width:auto}.btn-group>.btn:first-child{margin-left:0}.btn-group>.btn-group:not(:last-child)>.btn,.btn-group>.btn:not(:last-child):not(.dropdown-toggle){border-top-right-radius:0;border-bottom-right-radius:0}.btn-group>.btn-group:not(:first-child)>.btn,.btn-group>.btn:not(:first-child){border-top-left-radius:0;border-bottom-left-radius:0}.dropdown-toggle-split{padding-right:.5625rem;padding-left:.5625rem}.dropdown-toggle-split::after,.dropright .dropdown-toggle-split::after,.dropup .dropdown-toggle-split::after{margin-left:0}.dropleft .dropdown-toggle-split::before{margin-right:0}.btn-group-sm>.btn+.dropdown-toggle-split,.btn-sm+.dropdown-toggle-split{padding-right:.375rem;padding-left:.375rem}.btn-group-lg>.btn+.dropdown-toggle-split,.btn-lg+.dropdown-toggle-split{padding-right:.75rem;padding-left:.75rem}.btn-group-vertical{-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;-ms-flex-align:start;-webkit-box-align:start;align-items:flex-start;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center}.btn-group-vertical .btn,.btn-group-vertical .btn-group{width:100%}.btn-group-vertical>.btn+.btn,.btn-group-vertical>.btn+.btn-group,.btn-group-vertical>.btn-group+.btn,.btn-group-vertical>.btn-group+.btn-group{margin-top:-1px;margin-left:0}.btn-group-vertical>.btn-group:not(:last-child)>.btn,.btn-group-vertical>.btn:not(:last-child):not(.dropdown-toggle){border-bottom-right-radius:0;border-bottom-left-radius:0}.btn-group-vertical>.btn-group:not(:first-child)>.btn,.btn-group-vertical>.btn:not(:first-child){border-top-left-radius:0;border-top-right-radius:0}.btn-group-toggle>.btn,.btn-group-toggle>.btn-group>.btn{margin-bottom:0}.btn-group-toggle>.btn input[type=checkbox],.btn-group-toggle>.btn input[type=radio],.btn-group-toggle>.btn-group>.btn input[type=checkbox],.btn-group-toggle>.btn-group>.btn input[type=radio]{position:absolute;clip:rect(0,0,0,0);pointer-events:none}.input-group{position:relative;display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;-ms-flex-align:stretch;-webkit-box-align:stretch;align-items:stretch;width:100%}.input-group>.custom-file,.input-group>.custom-select,.input-group>.form-control{position:relative;-ms-flex:1 1 auto;-webkit-box-flex:1;flex:1 1 auto;width:1%;margin-bottom:0}.input-group>.custom-file+.custom-file,.input-group>.custom-file+.custom-select,.input-group>.custom-file+.form-control,.input-group>.custom-select+.custom-file,.input-group>.custom-select+.custom-select,.input-group>.custom-select+.form-control,.input-group>.form-control+.custom-file,.input-group>.form-control+.custom-select,.input-group>.form-control+.form-control{margin-left:-1px}.input-group>.custom-file .custom-file-input:focus~.custom-file-label,.input-group>.custom-select:focus,.input-group>.form-control:focus{z-index:3}.input-group>.custom-select:not(:last-child),.input-group>.form-control:not(:last-child){border-top-right-radius:0;border-bottom-right-radius:0}.input-group>.custom-select:not(:first-child),.input-group>.form-control:not(:first-child){border-top-left-radius:0;border-bottom-left-radius:0}.input-group>.custom-file{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center}.input-group>.custom-file:not(:last-child) .custom-file-label,.input-group>.custom-file:not(:last-child) .custom-file-label::after{border-top-right-radius:0;border-bottom-right-radius:0}.input-group>.custom-file:not(:first-child) .custom-file-label{border-top-left-radius:0;border-bottom-left-radius:0}.input-group-append,.input-group-prepend{display:-ms-flexbox;display:-webkit-box;display:flex}.input-group-append .btn,.input-group-prepend .btn{position:relative;z-index:2}.input-group-append .btn+.btn,.input-group-append .btn+.input-group-text,.input-group-append .input-group-text+.btn,.input-group-append .input-group-text+.input-group-text,.input-group-prepend .btn+.btn,.input-group-prepend .btn+.input-group-text,.input-group-prepend .input-group-text+.btn,.input-group-prepend .input-group-text+.input-group-text{margin-left:-1px}.input-group-prepend{margin-right:-1px}.input-group-append{margin-left:-1px}.input-group-text{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;padding:.375rem .75rem;margin-bottom:0;font-size:1rem;font-weight:400;line-height:1.5;color:#495057;text-align:center;white-space:nowrap;background-color:#e9ecef;border:1px solid #ced4da;border-radius:.25rem}.input-group-text input[type=checkbox],.input-group-text input[type=radio]{margin-top:0}.input-group>.input-group-append:last-child>.btn:not(:last-child):not(.dropdown-toggle),.input-group>.input-group-append:last-child>.input-group-text:not(:last-child),.input-group>.input-group-append:not(:last-child)>.btn,.input-group>.input-group-append:not(:last-child)>.input-group-text,.input-group>.input-group-prepend>.btn,.input-group>.input-group-prepend>.input-group-text{border-top-right-radius:0;border-bottom-right-radius:0}.input-group>.input-group-append>.btn,.input-group>.input-group-append>.input-group-text,.input-group>.input-group-prepend:first-child>.btn:not(:first-child),.input-group>.input-group-prepend:first-child>.input-group-text:not(:first-child),.input-group>.input-group-prepend:not(:first-child)>.btn,.input-group>.input-group-prepend:not(:first-child)>.input-group-text{border-top-left-radius:0;border-bottom-left-radius:0}.custom-control{position:relative;display:block;min-height:1.5rem;padding-left:1.5rem}.custom-control-inline{display:-ms-inline-flexbox;display:-webkit-inline-box;display:inline-flex;margin-right:1rem}.custom-control-input{position:absolute;z-index:-1;opacity:0}.custom-control-input:checked~.custom-control-label::before{color:#fff;background-color:#007bff}.custom-control-input:focus~.custom-control-label::before{-webkit-box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(0,123,255,.25);box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(0,123,255,.25)}.custom-control-input:active~.custom-control-label::before{color:#fff;background-color:#b3d7ff}.custom-control-input:disabled~.custom-control-label{color:#6c757d}.custom-control-input:disabled~.custom-control-label::before{background-color:#e9ecef}.custom-control-label{position:relative;margin-bottom:0}.custom-control-label::before{position:absolute;top:.25rem;left:-1.5rem;display:block;width:1rem;height:1rem;pointer-events:none;content:\"\";-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none;background-color:#dee2e6}.custom-control-label::after{position:absolute;top:.25rem;left:-1.5rem;display:block;width:1rem;height:1rem;content:\"\";background-repeat:no-repeat;background-position:center center;background-size:50% 50%}.custom-checkbox .custom-control-label::before{border-radius:.25rem}.custom-checkbox .custom-control-input:checked~.custom-control-label::before{background-color:#007bff}.custom-checkbox .custom-control-input:checked~.custom-control-label::after{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 8 8'%3E%3Cpath fill='%23fff' d='M6.564.75l-3.59 3.612-1.538-1.55L0 4.26 2.974 7.25 8 2.193z'/%3E%3C/svg%3E\")}.custom-checkbox .custom-control-input:indeterminate~.custom-control-label::before{background-color:#007bff}.custom-checkbox .custom-control-input:indeterminate~.custom-control-label::after{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 4 4'%3E%3Cpath stroke='%23fff' d='M0 2h4'/%3E%3C/svg%3E\")}.custom-checkbox .custom-control-input:disabled:checked~.custom-control-label::before{background-color:rgba(0,123,255,.5)}.custom-checkbox .custom-control-input:disabled:indeterminate~.custom-control-label::before{background-color:rgba(0,123,255,.5)}.custom-radio .custom-control-label::before{border-radius:50%}.custom-radio .custom-control-input:checked~.custom-control-label::before{background-color:#007bff}.custom-radio .custom-control-input:checked~.custom-control-label::after{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='-4 -4 8 8'%3E%3Ccircle r='3' fill='%23fff'/%3E%3C/svg%3E\")}.custom-radio .custom-control-input:disabled:checked~.custom-control-label::before{background-color:rgba(0,123,255,.5)}.custom-select{display:inline-block;width:100%;height:calc(2.25rem + 2px);padding:.375rem 1.75rem .375rem .75rem;line-height:1.5;color:#495057;vertical-align:middle;background:url(\"data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 4 5'%3E%3Cpath fill='%23343a40' d='M2 0L0 2h4zm0 5L0 3h4z'/%3E%3C/svg%3E\") right .75rem center/8px 10px no-repeat #fff;border:1px solid #ced4da;border-radius:.25rem;-webkit-appearance:none;-moz-appearance:none;appearance:none}.custom-select:focus{border-color:#80bdff;outline:0;-webkit-box-shadow:0 0 0 .2rem rgba(128,189,255,.5);box-shadow:0 0 0 .2rem rgba(128,189,255,.5)}.custom-select:focus::-ms-value{color:#495057;background-color:#fff}.custom-select[multiple],.custom-select[size]:not([size=\"1\"]){height:auto;padding-right:.75rem;background-image:none}.custom-select:disabled{color:#6c757d;background-color:#e9ecef}.custom-select::-ms-expand{opacity:0}.custom-select-sm{height:calc(1.8125rem + 2px);padding-top:.375rem;padding-bottom:.375rem;font-size:75%}.custom-select-lg{height:calc(2.875rem + 2px);padding-top:.375rem;padding-bottom:.375rem;font-size:125%}.custom-file{position:relative;display:inline-block;width:100%;height:calc(2.25rem + 2px);margin-bottom:0}.custom-file-input{position:relative;z-index:2;width:100%;height:calc(2.25rem + 2px);margin:0;opacity:0}.custom-file-input:focus~.custom-file-label{border-color:#80bdff;-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.25);box-shadow:0 0 0 .2rem rgba(0,123,255,.25)}.custom-file-input:focus~.custom-file-label::after{border-color:#80bdff}.custom-file-input:disabled~.custom-file-label{background-color:#e9ecef}.custom-file-input:lang(en)~.custom-file-label::after{content:\"Browse\"}.custom-file-label{position:absolute;top:0;right:0;left:0;z-index:1;height:calc(2.25rem + 2px);padding:.375rem .75rem;line-height:1.5;color:#495057;background-color:#fff;border:1px solid #ced4da;border-radius:.25rem}.custom-file-label::after{position:absolute;top:0;right:0;bottom:0;z-index:3;display:block;height:2.25rem;padding:.375rem .75rem;line-height:1.5;color:#495057;content:\"Browse\";background-color:#e9ecef;border-left:1px solid #ced4da;border-radius:0 .25rem .25rem 0}.custom-range{width:100%;padding-left:0;background-color:transparent;-webkit-appearance:none;-moz-appearance:none;appearance:none}.custom-range:focus{outline:0}.custom-range::-moz-focus-outer{border:0}.custom-range::-webkit-slider-thumb{width:1rem;height:1rem;margin-top:-.25rem;background-color:#007bff;border:0;border-radius:1rem;-webkit-transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;-webkit-appearance:none;appearance:none}\@media screen and (prefers-reduced-motion:reduce){.custom-range::-webkit-slider-thumb{-webkit-transition:none;transition:none}}.custom-range::-webkit-slider-thumb:focus{outline:0;-webkit-box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(0,123,255,.25);box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(0,123,255,.25)}.custom-range::-webkit-slider-thumb:active{background-color:#b3d7ff}.custom-range::-webkit-slider-runnable-track{width:100%;height:.5rem;color:transparent;cursor:pointer;background-color:#dee2e6;border-color:transparent;border-radius:1rem}.custom-range::-moz-range-thumb{width:1rem;height:1rem;background-color:#007bff;border:0;border-radius:1rem;-webkit-transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;-moz-appearance:none;appearance:none}\@media screen and (prefers-reduced-motion:reduce){.custom-range::-moz-range-thumb{-webkit-transition:none;transition:none}}.custom-range::-moz-range-thumb:focus{outline:0;box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(0,123,255,.25)}.custom-range::-moz-range-thumb:active{background-color:#b3d7ff}.custom-range::-moz-range-track{width:100%;height:.5rem;color:transparent;cursor:pointer;background-color:#dee2e6;border-color:transparent;border-radius:1rem}.custom-range::-ms-thumb{width:1rem;height:1rem;background-color:#007bff;border:0;border-radius:1rem;-webkit-transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;appearance:none}\@media screen and (prefers-reduced-motion:reduce){.custom-range::-ms-thumb{-webkit-transition:none;transition:none}}.custom-range::-ms-thumb:focus{outline:0;box-shadow:0 0 0 1px #fff,0 0 0 .2rem rgba(0,123,255,.25)}.custom-range::-ms-thumb:active{background-color:#b3d7ff}.custom-range::-ms-track{width:100%;height:.5rem;color:transparent;cursor:pointer;background-color:transparent;border-color:transparent;border-width:.5rem}.custom-range::-ms-fill-lower{background-color:#dee2e6;border-radius:1rem}.custom-range::-ms-fill-upper{margin-right:15px;background-color:#dee2e6;border-radius:1rem}.custom-control-label::before,.custom-file-label,.custom-select{-webkit-transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,-webkit-box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;transition:background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out,-webkit-box-shadow .15s ease-in-out}\@media screen and (prefers-reduced-motion:reduce){.custom-control-label::before,.custom-file-label,.custom-select{-webkit-transition:none;transition:none}}.nav{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;padding-left:0;margin-bottom:0;list-style:none}.nav-link{display:block;padding:.5rem 1rem}.nav-link:focus,.nav-link:hover{text-decoration:none}.nav-link.disabled{color:#6c757d}.nav-tabs{border-bottom:1px solid #dee2e6}.nav-tabs .nav-item{margin-bottom:-1px}.nav-tabs .nav-link{border:1px solid transparent;border-top-left-radius:.25rem;border-top-right-radius:.25rem}.nav-tabs .nav-link:focus,.nav-tabs .nav-link:hover{border-color:#e9ecef #e9ecef #dee2e6}.nav-tabs .nav-link.disabled{color:#6c757d;background-color:transparent;border-color:transparent}.nav-tabs .nav-item.show .nav-link,.nav-tabs .nav-link.active{color:#495057;background-color:#fff;border-color:#dee2e6 #dee2e6 #fff}.nav-tabs .dropdown-menu{margin-top:-1px;border-top-left-radius:0;border-top-right-radius:0}.nav-pills .nav-link{border-radius:.25rem}.nav-pills .nav-link.active,.nav-pills .show>.nav-link{color:#fff;background-color:#007bff}.nav-fill .nav-item{-ms-flex:1 1 auto;-webkit-box-flex:1;flex:1 1 auto;text-align:center}.nav-justified .nav-item{-ms-flex-preferred-size:0;flex-basis:0;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;text-align:center}.tab-content>.tab-pane{display:none}.tab-content>.active{display:block}.navbar{position:relative;display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:justify;-webkit-box-pack:justify;justify-content:space-between;padding:.5rem 1rem}.navbar>.container,.navbar>.container-fluid{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:justify;-webkit-box-pack:justify;justify-content:space-between}.navbar-brand{display:inline-block;padding-top:.3125rem;padding-bottom:.3125rem;margin-right:1rem;font-size:1.25rem;line-height:inherit;white-space:nowrap}.navbar-brand:focus,.navbar-brand:hover{text-decoration:none}.navbar-nav{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;padding-left:0;margin-bottom:0;list-style:none}.navbar-nav .nav-link{padding-right:0;padding-left:0}.navbar-nav .dropdown-menu{position:static;float:none}.navbar-text{display:inline-block;padding-top:.5rem;padding-bottom:.5rem}.navbar-collapse{-ms-flex-preferred-size:100%;flex-basis:100%;-ms-flex-positive:1;-webkit-box-flex:1;flex-grow:1;-ms-flex-align:center;-webkit-box-align:center;align-items:center}.navbar-toggler{padding:.25rem .75rem;font-size:1.25rem;line-height:1;background-color:transparent;border:1px solid transparent;border-radius:.25rem}.navbar-toggler:focus,.navbar-toggler:hover{text-decoration:none}.navbar-toggler:not(:disabled):not(.disabled){cursor:pointer}.navbar-toggler-icon{display:inline-block;width:1.5em;height:1.5em;vertical-align:middle;content:\"\";background:center center/100% 100% no-repeat}\@media (max-width:575.98px){.navbar-expand-sm>.container,.navbar-expand-sm>.container-fluid{padding-right:0;padding-left:0}}\@media (min-width:576px){.navbar-expand-sm{-ms-flex-flow:row nowrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row nowrap;-ms-flex-pack:start;-webkit-box-pack:start;justify-content:flex-start}.navbar-expand-sm .navbar-nav{-ms-flex-direction:row;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-direction:row}.navbar-expand-sm .navbar-nav .dropdown-menu{position:absolute}.navbar-expand-sm .navbar-nav .nav-link{padding-right:.5rem;padding-left:.5rem}.navbar-expand-sm>.container,.navbar-expand-sm>.container-fluid{-ms-flex-wrap:nowrap;flex-wrap:nowrap}.navbar-expand-sm .navbar-collapse{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important;-ms-flex-preferred-size:auto;flex-basis:auto}.navbar-expand-sm .navbar-toggler{display:none}}\@media (max-width:767.98px){.navbar-expand-md>.container,.navbar-expand-md>.container-fluid{padding-right:0;padding-left:0}}\@media (min-width:768px){.navbar-expand-md{-ms-flex-flow:row nowrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row nowrap;-ms-flex-pack:start;-webkit-box-pack:start;justify-content:flex-start}.navbar-expand-md .navbar-nav{-ms-flex-direction:row;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-direction:row}.navbar-expand-md .navbar-nav .dropdown-menu{position:absolute}.navbar-expand-md .navbar-nav .nav-link{padding-right:.5rem;padding-left:.5rem}.navbar-expand-md>.container,.navbar-expand-md>.container-fluid{-ms-flex-wrap:nowrap;flex-wrap:nowrap}.navbar-expand-md .navbar-collapse{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important;-ms-flex-preferred-size:auto;flex-basis:auto}.navbar-expand-md .navbar-toggler{display:none}}\@media (max-width:991.98px){.navbar-expand-lg>.container,.navbar-expand-lg>.container-fluid{padding-right:0;padding-left:0}}\@media (min-width:992px){.navbar-expand-lg{-ms-flex-flow:row nowrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row nowrap;-ms-flex-pack:start;-webkit-box-pack:start;justify-content:flex-start}.navbar-expand-lg .navbar-nav{-ms-flex-direction:row;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-direction:row}.navbar-expand-lg .navbar-nav .dropdown-menu{position:absolute}.navbar-expand-lg .navbar-nav .nav-link{padding-right:.5rem;padding-left:.5rem}.navbar-expand-lg>.container,.navbar-expand-lg>.container-fluid{-ms-flex-wrap:nowrap;flex-wrap:nowrap}.navbar-expand-lg .navbar-collapse{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important;-ms-flex-preferred-size:auto;flex-basis:auto}.navbar-expand-lg .navbar-toggler{display:none}}\@media (max-width:1199.98px){.navbar-expand-xl>.container,.navbar-expand-xl>.container-fluid{padding-right:0;padding-left:0}}\@media (min-width:1200px){.navbar-expand-xl{-ms-flex-flow:row nowrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row nowrap;-ms-flex-pack:start;-webkit-box-pack:start;justify-content:flex-start}.navbar-expand-xl .navbar-nav{-ms-flex-direction:row;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-direction:row}.navbar-expand-xl .navbar-nav .dropdown-menu{position:absolute}.navbar-expand-xl .navbar-nav .nav-link{padding-right:.5rem;padding-left:.5rem}.navbar-expand-xl>.container,.navbar-expand-xl>.container-fluid{-ms-flex-wrap:nowrap;flex-wrap:nowrap}.navbar-expand-xl .navbar-collapse{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important;-ms-flex-preferred-size:auto;flex-basis:auto}.navbar-expand-xl .navbar-toggler{display:none}}.navbar-expand{-ms-flex-flow:row nowrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row nowrap;-ms-flex-pack:start;-webkit-box-pack:start;justify-content:flex-start}.navbar-expand .navbar-nav{-ms-flex-direction:row;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-direction:row}.navbar-expand .navbar-nav .dropdown-menu{position:absolute}.navbar-expand .navbar-nav .nav-link{padding-right:.5rem;padding-left:.5rem}.navbar-expand>.container,.navbar-expand>.container-fluid{padding-right:0;padding-left:0;-ms-flex-wrap:nowrap;flex-wrap:nowrap}.navbar-expand .navbar-collapse{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important;-ms-flex-preferred-size:auto;flex-basis:auto}.navbar-expand .navbar-toggler{display:none}.navbar-light .navbar-brand,.navbar-light .navbar-brand:focus,.navbar-light .navbar-brand:hover{color:rgba(0,0,0,.9)}.navbar-light .navbar-nav .nav-link{color:rgba(0,0,0,.5)}.navbar-light .navbar-nav .nav-link:focus,.navbar-light .navbar-nav .nav-link:hover{color:rgba(0,0,0,.7)}.navbar-light .navbar-nav .nav-link.disabled{color:rgba(0,0,0,.3)}.navbar-light .navbar-nav .active>.nav-link,.navbar-light .navbar-nav .nav-link.active,.navbar-light .navbar-nav .nav-link.show,.navbar-light .navbar-nav .show>.nav-link{color:rgba(0,0,0,.9)}.navbar-light .navbar-toggler{color:rgba(0,0,0,.5);border-color:rgba(0,0,0,.1)}.navbar-light .navbar-toggler-icon{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg viewBox='0 0 30 30' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath stroke='rgba(0, 0, 0, 0.5)' stroke-width='2' stroke-linecap='round' stroke-miterlimit='10' d='M4 7h22M4 15h22M4 23h22'/%3E%3C/svg%3E\")}.navbar-light .navbar-text{color:rgba(0,0,0,.5)}.navbar-light .navbar-text a,.navbar-light .navbar-text a:focus,.navbar-light .navbar-text a:hover{color:rgba(0,0,0,.9)}.navbar-dark .navbar-brand,.navbar-dark .navbar-brand:focus,.navbar-dark .navbar-brand:hover{color:#fff}.navbar-dark .navbar-nav .nav-link{color:rgba(255,255,255,.5)}.navbar-dark .navbar-nav .nav-link:focus,.navbar-dark .navbar-nav .nav-link:hover{color:rgba(255,255,255,.75)}.navbar-dark .navbar-nav .nav-link.disabled{color:rgba(255,255,255,.25)}.navbar-dark .navbar-nav .active>.nav-link,.navbar-dark .navbar-nav .nav-link.active,.navbar-dark .navbar-nav .nav-link.show,.navbar-dark .navbar-nav .show>.nav-link{color:#fff}.navbar-dark .navbar-toggler{color:rgba(255,255,255,.5);border-color:rgba(255,255,255,.1)}.navbar-dark .navbar-toggler-icon{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg viewBox='0 0 30 30' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath stroke='rgba(255, 255, 255, 0.5)' stroke-width='2' stroke-linecap='round' stroke-miterlimit='10' d='M4 7h22M4 15h22M4 23h22'/%3E%3C/svg%3E\")}.navbar-dark .navbar-text{color:rgba(255,255,255,.5)}.navbar-dark .navbar-text a,.navbar-dark .navbar-text a:focus,.navbar-dark .navbar-text a:hover{color:#fff}.card{position:relative;display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;min-width:0;word-wrap:break-word;background-color:#fff;background-clip:border-box;border:1px solid rgba(0,0,0,.125);border-radius:.25rem}.card>hr{margin-right:0;margin-left:0}.card>.list-group:first-child .list-group-item:first-child{border-top-left-radius:.25rem;border-top-right-radius:.25rem}.card>.list-group:last-child .list-group-item:last-child{border-bottom-right-radius:.25rem;border-bottom-left-radius:.25rem}.card-body{-ms-flex:1 1 auto;-webkit-box-flex:1;flex:1 1 auto;padding:1.25rem}.card-title{margin-bottom:.75rem}.card-subtitle{margin-top:-.375rem;margin-bottom:0}.card-text:last-child{margin-bottom:0}.card-link:hover{text-decoration:none}.card-link+.card-link{margin-left:1.25rem}.card-header{padding:.75rem 1.25rem;margin-bottom:0;background-color:rgba(0,0,0,.03);border-bottom:1px solid rgba(0,0,0,.125)}.card-header:first-child{border-radius:calc(.25rem - 1px) calc(.25rem - 1px) 0 0}.card-header+.list-group .list-group-item:first-child{border-top:0}.card-footer{padding:.75rem 1.25rem;background-color:rgba(0,0,0,.03);border-top:1px solid rgba(0,0,0,.125)}.card-footer:last-child{border-radius:0 0 calc(.25rem - 1px) calc(.25rem - 1px)}.card-header-tabs{margin-right:-.625rem;margin-bottom:-.75rem;margin-left:-.625rem;border-bottom:0}.card-header-pills{margin-right:-.625rem;margin-left:-.625rem}.card-img-overlay{position:absolute;top:0;right:0;bottom:0;left:0;padding:1.25rem}.card-img{width:100%;border-radius:calc(.25rem - 1px)}.card-img-top{width:100%;border-top-left-radius:calc(.25rem - 1px);border-top-right-radius:calc(.25rem - 1px)}.card-img-bottom{width:100%;border-bottom-right-radius:calc(.25rem - 1px);border-bottom-left-radius:calc(.25rem - 1px)}.card-deck{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column}.card-deck .card{margin-bottom:15px}\@media (min-width:576px){.card-deck{-ms-flex-flow:row wrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row wrap;margin-right:-15px;margin-left:-15px}.card-deck .card{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex:1 0 0%;-webkit-box-flex:1;flex:1 0 0%;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;margin-right:15px;margin-bottom:0;margin-left:15px}}.card-group{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column}.card-group>.card{margin-bottom:15px}\@media (min-width:576px){.card-group{-ms-flex-flow:row wrap;-webkit-box-orient:horizontal;-webkit-box-direction:normal;flex-flow:row wrap}.card-group>.card{-ms-flex:1 0 0%;-webkit-box-flex:1;flex:1 0 0%;margin-bottom:0}.card-group>.card+.card{margin-left:0;border-left:0}.card-group>.card:first-child{border-top-right-radius:0;border-bottom-right-radius:0}.card-group>.card:first-child .card-header,.card-group>.card:first-child .card-img-top{border-top-right-radius:0}.card-group>.card:first-child .card-footer,.card-group>.card:first-child .card-img-bottom{border-bottom-right-radius:0}.card-group>.card:last-child{border-top-left-radius:0;border-bottom-left-radius:0}.card-group>.card:last-child .card-header,.card-group>.card:last-child .card-img-top{border-top-left-radius:0}.card-group>.card:last-child .card-footer,.card-group>.card:last-child .card-img-bottom{border-bottom-left-radius:0}.card-group>.card:only-child{border-radius:.25rem}.card-group>.card:only-child .card-header,.card-group>.card:only-child .card-img-top{border-top-left-radius:.25rem;border-top-right-radius:.25rem}.card-group>.card:only-child .card-footer,.card-group>.card:only-child .card-img-bottom{border-bottom-right-radius:.25rem;border-bottom-left-radius:.25rem}.card-group>.card:not(:first-child):not(:last-child):not(:only-child),.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-footer,.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-header,.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-img-bottom,.card-group>.card:not(:first-child):not(:last-child):not(:only-child) .card-img-top{border-radius:0}.card-columns{-webkit-column-count:3;-moz-column-count:3;column-count:3;-webkit-column-gap:1.25rem;-moz-column-gap:1.25rem;column-gap:1.25rem;orphans:1;widows:1}.card-columns .card{display:inline-block;width:100%}}.card-columns .card{margin-bottom:.75rem}.accordion .card:not(:first-of-type):not(:last-of-type){border-bottom:0;border-radius:0}.accordion .card:not(:first-of-type) .card-header:first-child{border-radius:0}.accordion .card:first-of-type{border-bottom:0;border-bottom-right-radius:0;border-bottom-left-radius:0}.accordion .card:last-of-type{border-top-left-radius:0;border-top-right-radius:0}.breadcrumb{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-wrap:wrap;flex-wrap:wrap;padding:.75rem 1rem;margin-bottom:1rem;list-style:none;background-color:#e9ecef;border-radius:.25rem}.breadcrumb-item+.breadcrumb-item{padding-left:.5rem}.breadcrumb-item+.breadcrumb-item::before{display:inline-block;padding-right:.5rem;color:#6c757d;content:\"/\"}.breadcrumb-item+.breadcrumb-item:hover::before{text-decoration:none}.breadcrumb-item.active{color:#6c757d}.pagination{display:-ms-flexbox;display:-webkit-box;display:flex;padding-left:0;list-style:none;border-radius:.25rem}.page-link{position:relative;display:block;padding:.5rem .75rem;margin-left:-1px;line-height:1.25;color:#007bff;background-color:#fff;border:1px solid #dee2e6}.page-link:hover{z-index:2;color:#0056b3;text-decoration:none;background-color:#e9ecef;border-color:#dee2e6}.page-link:focus{z-index:2;outline:0;-webkit-box-shadow:0 0 0 .2rem rgba(0,123,255,.25);box-shadow:0 0 0 .2rem rgba(0,123,255,.25)}.page-link:not(:disabled):not(.disabled){cursor:pointer}.page-item:first-child .page-link{margin-left:0;border-top-left-radius:.25rem;border-bottom-left-radius:.25rem}.page-item:last-child .page-link{border-top-right-radius:.25rem;border-bottom-right-radius:.25rem}.page-item.active .page-link{z-index:1;color:#fff;background-color:#007bff;border-color:#007bff}.page-item.disabled .page-link{color:#6c757d;pointer-events:none;cursor:auto;background-color:#fff;border-color:#dee2e6}.pagination-lg .page-link{padding:.75rem 1.5rem;font-size:1.25rem;line-height:1.5}.pagination-lg .page-item:first-child .page-link{border-top-left-radius:.3rem;border-bottom-left-radius:.3rem}.pagination-lg .page-item:last-child .page-link{border-top-right-radius:.3rem;border-bottom-right-radius:.3rem}.pagination-sm .page-link{padding:.25rem .5rem;font-size:.875rem;line-height:1.5}.pagination-sm .page-item:first-child .page-link{border-top-left-radius:.2rem;border-bottom-left-radius:.2rem}.pagination-sm .page-item:last-child .page-link{border-top-right-radius:.2rem;border-bottom-right-radius:.2rem}.badge{display:inline-block;padding:.25em .4em;font-size:75%;font-weight:700;line-height:1;text-align:center;white-space:nowrap;vertical-align:baseline;border-radius:.25rem}.badge:empty{display:none}.btn .badge{position:relative;top:-1px}.badge-pill{padding-right:.6em;padding-left:.6em;border-radius:10rem}.badge-primary{color:#fff;background-color:#007bff}.badge-primary[href]:focus,.badge-primary[href]:hover{color:#fff;text-decoration:none;background-color:#0062cc}.badge-secondary{color:#fff;background-color:#6c757d}.badge-secondary[href]:focus,.badge-secondary[href]:hover{color:#fff;text-decoration:none;background-color:#545b62}.badge-success{color:#fff;background-color:#28a745}.badge-success[href]:focus,.badge-success[href]:hover{color:#fff;text-decoration:none;background-color:#1e7e34}.badge-info{color:#fff;background-color:#17a2b8}.badge-info[href]:focus,.badge-info[href]:hover{color:#fff;text-decoration:none;background-color:#117a8b}.badge-warning{color:#212529;background-color:#ffc107}.badge-warning[href]:focus,.badge-warning[href]:hover{color:#212529;text-decoration:none;background-color:#d39e00}.badge-danger{color:#fff;background-color:#dc3545}.badge-danger[href]:focus,.badge-danger[href]:hover{color:#fff;text-decoration:none;background-color:#bd2130}.badge-light{color:#212529;background-color:#f8f9fa}.badge-light[href]:focus,.badge-light[href]:hover{color:#212529;text-decoration:none;background-color:#dae0e5}.badge-dark{color:#fff;background-color:#343a40}.badge-dark[href]:focus,.badge-dark[href]:hover{color:#fff;text-decoration:none;background-color:#1d2124}.jumbotron{padding:2rem 1rem;margin-bottom:2rem;background-color:#e9ecef;border-radius:.3rem}\@media (min-width:576px){.jumbotron{padding:4rem 2rem}}.jumbotron-fluid{padding-right:0;padding-left:0;border-radius:0}.alert{position:relative;padding:.75rem 1.25rem;margin-bottom:1rem;border:1px solid transparent;border-radius:.25rem}.alert-heading{color:inherit}.alert-link{font-weight:700}.alert-dismissible{padding-right:4rem}.alert-dismissible .close{position:absolute;top:0;right:0;padding:.75rem 1.25rem;color:inherit}.alert-primary{color:#004085;background-color:#cce5ff;border-color:#b8daff}.alert-primary hr{border-top-color:#9fcdff}.alert-primary .alert-link{color:#002752}.alert-secondary{color:#383d41;background-color:#e2e3e5;border-color:#d6d8db}.alert-secondary hr{border-top-color:#c8cbcf}.alert-secondary .alert-link{color:#202326}.alert-success{color:#155724;background-color:#d4edda;border-color:#c3e6cb}.alert-success hr{border-top-color:#b1dfbb}.alert-success .alert-link{color:#0b2e13}.alert-info{color:#0c5460;background-color:#d1ecf1;border-color:#bee5eb}.alert-info hr{border-top-color:#abdde5}.alert-info .alert-link{color:#062c33}.alert-warning{color:#856404;background-color:#fff3cd;border-color:#ffeeba}.alert-warning hr{border-top-color:#ffe8a1}.alert-warning .alert-link{color:#533f03}.alert-danger{color:#721c24;background-color:#f8d7da;border-color:#f5c6cb}.alert-danger hr{border-top-color:#f1b0b7}.alert-danger .alert-link{color:#491217}.alert-light{color:#818182;background-color:#fefefe;border-color:#fdfdfe}.alert-light hr{border-top-color:#ececf6}.alert-light .alert-link{color:#686868}.alert-dark{color:#1b1e21;background-color:#d6d8d9;border-color:#c6c8ca}.alert-dark hr{border-top-color:#b9bbbe}.alert-dark .alert-link{color:#040505}\@-webkit-keyframes progress-bar-stripes{from{background-position:1rem 0}to{background-position:0 0}}\@keyframes progress-bar-stripes{from{background-position:1rem 0}to{background-position:0 0}}.progress{display:-ms-flexbox;display:-webkit-box;display:flex;height:1rem;overflow:hidden;font-size:.75rem;background-color:#e9ecef;border-radius:.25rem}.progress-bar{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center;color:#fff;text-align:center;white-space:nowrap;background-color:#007bff;-webkit-transition:width .6s ease;transition:width .6s ease}\@media screen and (prefers-reduced-motion:reduce){.progress-bar{-webkit-transition:none;transition:none}}.progress-bar-striped{background-image:linear-gradient(45deg,rgba(255,255,255,.15) 25%,transparent 25%,transparent 50%,rgba(255,255,255,.15) 50%,rgba(255,255,255,.15) 75%,transparent 75%,transparent);background-size:1rem 1rem}.progress-bar-animated{-webkit-animation:1s linear infinite progress-bar-stripes;animation:1s linear infinite progress-bar-stripes}.media{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:start;-webkit-box-align:start;align-items:flex-start}.media-body{-ms-flex:1;-webkit-box-flex:1;flex:1}.list-group{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;padding-left:0;margin-bottom:0}.list-group-item-action{width:100%;color:#495057;text-align:inherit}.list-group-item-action:focus,.list-group-item-action:hover{color:#495057;text-decoration:none;background-color:#f8f9fa}.list-group-item-action:active{color:#212529;background-color:#e9ecef}.list-group-item{position:relative;display:block;padding:.75rem 1.25rem;margin-bottom:-1px;background-color:#fff;border:1px solid rgba(0,0,0,.125)}.list-group-item:first-child{border-top-left-radius:.25rem;border-top-right-radius:.25rem}.list-group-item:last-child{margin-bottom:0;border-bottom-right-radius:.25rem;border-bottom-left-radius:.25rem}.list-group-item:focus,.list-group-item:hover{z-index:1;text-decoration:none}.list-group-item.disabled,.list-group-item:disabled{color:#6c757d;background-color:#fff}.list-group-item.active{z-index:2;color:#fff;background-color:#007bff;border-color:#007bff}.list-group-flush .list-group-item{border-right:0;border-left:0;border-radius:0}.list-group-flush:first-child .list-group-item:first-child{border-top:0}.list-group-flush:last-child .list-group-item:last-child{border-bottom:0}.list-group-item-primary{color:#004085;background-color:#b8daff}.list-group-item-primary.list-group-item-action:focus,.list-group-item-primary.list-group-item-action:hover{color:#004085;background-color:#9fcdff}.list-group-item-primary.list-group-item-action.active{color:#fff;background-color:#004085;border-color:#004085}.list-group-item-secondary{color:#383d41;background-color:#d6d8db}.list-group-item-secondary.list-group-item-action:focus,.list-group-item-secondary.list-group-item-action:hover{color:#383d41;background-color:#c8cbcf}.list-group-item-secondary.list-group-item-action.active{color:#fff;background-color:#383d41;border-color:#383d41}.list-group-item-success{color:#155724;background-color:#c3e6cb}.list-group-item-success.list-group-item-action:focus,.list-group-item-success.list-group-item-action:hover{color:#155724;background-color:#b1dfbb}.list-group-item-success.list-group-item-action.active{color:#fff;background-color:#155724;border-color:#155724}.list-group-item-info{color:#0c5460;background-color:#bee5eb}.list-group-item-info.list-group-item-action:focus,.list-group-item-info.list-group-item-action:hover{color:#0c5460;background-color:#abdde5}.list-group-item-info.list-group-item-action.active{color:#fff;background-color:#0c5460;border-color:#0c5460}.list-group-item-warning{color:#856404;background-color:#ffeeba}.list-group-item-warning.list-group-item-action:focus,.list-group-item-warning.list-group-item-action:hover{color:#856404;background-color:#ffe8a1}.list-group-item-warning.list-group-item-action.active{color:#fff;background-color:#856404;border-color:#856404}.list-group-item-danger{color:#721c24;background-color:#f5c6cb}.list-group-item-danger.list-group-item-action:focus,.list-group-item-danger.list-group-item-action:hover{color:#721c24;background-color:#f1b0b7}.list-group-item-danger.list-group-item-action.active{color:#fff;background-color:#721c24;border-color:#721c24}.list-group-item-light{color:#818182;background-color:#fdfdfe}.list-group-item-light.list-group-item-action:focus,.list-group-item-light.list-group-item-action:hover{color:#818182;background-color:#ececf6}.list-group-item-light.list-group-item-action.active{color:#fff;background-color:#818182;border-color:#818182}.list-group-item-dark{color:#1b1e21;background-color:#c6c8ca}.list-group-item-dark.list-group-item-action:focus,.list-group-item-dark.list-group-item-action:hover{color:#1b1e21;background-color:#b9bbbe}.list-group-item-dark.list-group-item-action.active{color:#fff;background-color:#1b1e21;border-color:#1b1e21}.close{float:right;font-size:1.5rem;font-weight:700;line-height:1;color:#000;text-shadow:0 1px 0 #fff;opacity:.5}.close:not(:disabled):not(.disabled){cursor:pointer}.close:not(:disabled):not(.disabled):focus,.close:not(:disabled):not(.disabled):hover{color:#000;text-decoration:none;opacity:.75}button.close{padding:0;background-color:transparent;border:0;-webkit-appearance:none}.modal-open{overflow:hidden}.modal{position:fixed;top:0;right:0;bottom:0;left:0;z-index:1050;display:none;overflow:hidden;outline:0}.modal-open .modal{overflow-x:hidden;overflow-y:auto}.modal-dialog{position:relative;width:auto;margin:.5rem;pointer-events:none}.modal.fade .modal-dialog{transition:-webkit-transform .3s ease-out;-webkit-transition:-webkit-transform .3s ease-out;transition:transform .3s ease-out;transition:transform .3s ease-out,-webkit-transform .3s ease-out;transition:transform .3s ease-out,-webkit-transform .3s ease-out;-webkit-transform:translate(0,-25%);transform:translate(0,-25%)}\@media screen and (prefers-reduced-motion:reduce){.modal.fade .modal-dialog{-webkit-transition:none;transition:none}}.modal.show .modal-dialog{-webkit-transform:translate(0,0);transform:translate(0,0)}.modal-dialog-centered{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;min-height:calc(100% - (.5rem * 2))}.modal-content{position:relative;display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-direction:column;-webkit-box-orient:vertical;-webkit-box-direction:normal;flex-direction:column;width:100%;pointer-events:auto;background-color:#fff;background-clip:padding-box;border:1px solid rgba(0,0,0,.2);border-radius:.3rem;outline:0}.modal-backdrop{position:fixed;top:0;right:0;bottom:0;left:0;z-index:1040;background-color:#000}.modal-backdrop.fade{opacity:0}.modal-backdrop.show{opacity:.5}.modal-header{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:start;-webkit-box-align:start;align-items:flex-start;-ms-flex-pack:justify;-webkit-box-pack:justify;justify-content:space-between;padding:1rem;border-bottom:1px solid #e9ecef;border-top-left-radius:.3rem;border-top-right-radius:.3rem}.modal-header .close{padding:1rem;margin:-1rem -1rem -1rem auto}.modal-title{margin-bottom:0;line-height:1.5}.modal-body{position:relative;-ms-flex:1 1 auto;-webkit-box-flex:1;flex:1 1 auto;padding:1rem}.modal-footer{display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:end;-webkit-box-pack:end;justify-content:flex-end;padding:1rem;border-top:1px solid #e9ecef}.modal-footer>:not(:first-child){margin-left:.25rem}.modal-footer>:not(:last-child){margin-right:.25rem}.modal-scrollbar-measure{position:absolute;top:-9999px;width:50px;height:50px;overflow:scroll}\@media (min-width:576px){.modal-dialog{max-width:500px;margin:1.75rem auto}.modal-dialog-centered{min-height:calc(100% - (1.75rem * 2))}.modal-sm{max-width:300px}}\@media (min-width:992px){.modal-lg{max-width:800px}}.tooltip{position:absolute;z-index:1070;display:block;margin:0;font-family:-apple-system,BlinkMacSystemFont,\"Segoe UI\",Roboto,\"Helvetica Neue\",Arial,sans-serif,\"Apple Color Emoji\",\"Segoe UI Emoji\",\"Segoe UI Symbol\";font-style:normal;font-weight:400;line-height:1.5;text-align:left;text-align:start;text-decoration:none;text-shadow:none;text-transform:none;letter-spacing:normal;word-break:normal;word-spacing:normal;white-space:normal;line-break:auto;font-size:.875rem;word-wrap:break-word;opacity:0}.tooltip.show{opacity:.9}.tooltip .arrow{position:absolute;display:block;width:.8rem;height:.4rem}.tooltip .arrow::before{position:absolute;content:\"\";border-color:transparent;border-style:solid}.bs-tooltip-auto[x-placement^=top],.bs-tooltip-top{padding:.4rem 0}.bs-tooltip-auto[x-placement^=top] .arrow,.bs-tooltip-top .arrow{bottom:0}.bs-tooltip-auto[x-placement^=top] .arrow::before,.bs-tooltip-top .arrow::before{top:0;border-width:.4rem .4rem 0;border-top-color:#000}.bs-tooltip-auto[x-placement^=right],.bs-tooltip-right{padding:0 .4rem}.bs-tooltip-auto[x-placement^=right] .arrow,.bs-tooltip-right .arrow{left:0;width:.4rem;height:.8rem}.bs-tooltip-auto[x-placement^=right] .arrow::before,.bs-tooltip-right .arrow::before{right:0;border-width:.4rem .4rem .4rem 0;border-right-color:#000}.bs-tooltip-auto[x-placement^=bottom],.bs-tooltip-bottom{padding:.4rem 0}.bs-tooltip-auto[x-placement^=bottom] .arrow,.bs-tooltip-bottom .arrow{top:0}.bs-tooltip-auto[x-placement^=bottom] .arrow::before,.bs-tooltip-bottom .arrow::before{bottom:0;border-width:0 .4rem .4rem;border-bottom-color:#000}.bs-tooltip-auto[x-placement^=left],.bs-tooltip-left{padding:0 .4rem}.bs-tooltip-auto[x-placement^=left] .arrow,.bs-tooltip-left .arrow{right:0;width:.4rem;height:.8rem}.bs-tooltip-auto[x-placement^=left] .arrow::before,.bs-tooltip-left .arrow::before{left:0;border-width:.4rem 0 .4rem .4rem;border-left-color:#000}.tooltip-inner{max-width:200px;padding:.25rem .5rem;color:#fff;text-align:center;background-color:#000;border-radius:.25rem}.popover{position:absolute;top:0;left:0;z-index:1060;display:block;max-width:276px;font-family:-apple-system,BlinkMacSystemFont,\"Segoe UI\",Roboto,\"Helvetica Neue\",Arial,sans-serif,\"Apple Color Emoji\",\"Segoe UI Emoji\",\"Segoe UI Symbol\";font-style:normal;font-weight:400;line-height:1.5;text-align:left;text-align:start;text-decoration:none;text-shadow:none;text-transform:none;letter-spacing:normal;word-break:normal;word-spacing:normal;white-space:normal;line-break:auto;font-size:.875rem;word-wrap:break-word;background-color:#fff;background-clip:padding-box;border:1px solid rgba(0,0,0,.2);border-radius:.3rem}.popover .arrow{position:absolute;display:block;width:1rem;height:.5rem;margin:0 .3rem}.popover .arrow::after,.popover .arrow::before{position:absolute;display:block;content:\"\";border-color:transparent;border-style:solid}.bs-popover-auto[x-placement^=top],.bs-popover-top{margin-bottom:.5rem}.bs-popover-auto[x-placement^=top] .arrow,.bs-popover-top .arrow{bottom:calc((.5rem + 1px) * -1)}.bs-popover-auto[x-placement^=top] .arrow::after,.bs-popover-auto[x-placement^=top] .arrow::before,.bs-popover-top .arrow::after,.bs-popover-top .arrow::before{border-width:.5rem .5rem 0}.bs-popover-auto[x-placement^=top] .arrow::before,.bs-popover-top .arrow::before{bottom:0;border-top-color:rgba(0,0,0,.25)}.bs-popover-auto[x-placement^=top] .arrow::after,.bs-popover-top .arrow::after{bottom:1px;border-top-color:#fff}.bs-popover-auto[x-placement^=right],.bs-popover-right{margin-left:.5rem}.bs-popover-auto[x-placement^=right] .arrow,.bs-popover-right .arrow{left:calc((.5rem + 1px) * -1);width:.5rem;height:1rem;margin:.3rem 0}.bs-popover-auto[x-placement^=right] .arrow::after,.bs-popover-auto[x-placement^=right] .arrow::before,.bs-popover-right .arrow::after,.bs-popover-right .arrow::before{border-width:.5rem .5rem .5rem 0}.bs-popover-auto[x-placement^=right] .arrow::before,.bs-popover-right .arrow::before{left:0;border-right-color:rgba(0,0,0,.25)}.bs-popover-auto[x-placement^=right] .arrow::after,.bs-popover-right .arrow::after{left:1px;border-right-color:#fff}.bs-popover-auto[x-placement^=bottom],.bs-popover-bottom{margin-top:.5rem}.bs-popover-auto[x-placement^=bottom] .arrow,.bs-popover-bottom .arrow{top:calc((.5rem + 1px) * -1)}.bs-popover-auto[x-placement^=bottom] .arrow::after,.bs-popover-auto[x-placement^=bottom] .arrow::before,.bs-popover-bottom .arrow::after,.bs-popover-bottom .arrow::before{border-width:0 .5rem .5rem}.bs-popover-auto[x-placement^=bottom] .arrow::before,.bs-popover-bottom .arrow::before{top:0;border-bottom-color:rgba(0,0,0,.25)}.bs-popover-auto[x-placement^=bottom] .arrow::after,.bs-popover-bottom .arrow::after{top:1px;border-bottom-color:#fff}.bs-popover-auto[x-placement^=bottom] .popover-header::before,.bs-popover-bottom .popover-header::before{position:absolute;top:0;left:50%;display:block;width:1rem;margin-left:-.5rem;content:\"\";border-bottom:1px solid #f7f7f7}.bs-popover-auto[x-placement^=left],.bs-popover-left{margin-right:.5rem}.bs-popover-auto[x-placement^=left] .arrow,.bs-popover-left .arrow{right:calc((.5rem + 1px) * -1);width:.5rem;height:1rem;margin:.3rem 0}.bs-popover-auto[x-placement^=left] .arrow::after,.bs-popover-auto[x-placement^=left] .arrow::before,.bs-popover-left .arrow::after,.bs-popover-left .arrow::before{border-width:.5rem 0 .5rem .5rem}.bs-popover-auto[x-placement^=left] .arrow::before,.bs-popover-left .arrow::before{right:0;border-left-color:rgba(0,0,0,.25)}.bs-popover-auto[x-placement^=left] .arrow::after,.bs-popover-left .arrow::after{right:1px;border-left-color:#fff}.popover-header{padding:.5rem .75rem;margin-bottom:0;font-size:1rem;color:inherit;background-color:#f7f7f7;border-bottom:1px solid #ebebeb;border-top-left-radius:calc(.3rem - 1px);border-top-right-radius:calc(.3rem - 1px)}.popover-header:empty{display:none}.popover-body{padding:.5rem .75rem;color:#212529}.carousel{position:relative}.carousel-inner{position:relative;width:100%;overflow:hidden}.carousel-item{position:relative;display:none;-ms-flex-align:center;-webkit-box-align:center;align-items:center;width:100%;-webkit-backface-visibility:hidden;backface-visibility:hidden;-webkit-perspective:1000px;perspective:1000px}.carousel-item-next,.carousel-item-prev,.carousel-item.active{display:block;transition:-webkit-transform .6s ease;-webkit-transition:-webkit-transform .6s ease;transition:transform .6s ease;transition:transform .6s ease,-webkit-transform .6s ease;transition:transform .6s ease,-webkit-transform .6s ease}\@media screen and (prefers-reduced-motion:reduce){.carousel-item-next,.carousel-item-prev,.carousel-item.active{-webkit-transition:none;transition:none}}.carousel-item-next,.carousel-item-prev{position:absolute;top:0}.carousel-item-next.carousel-item-left,.carousel-item-prev.carousel-item-right{-webkit-transform:translateX(0);transform:translateX(0)}\@supports ((-webkit-transform-style:preserve-3d) or (transform-style:preserve-3d)){.carousel-item-next.carousel-item-left,.carousel-item-prev.carousel-item-right{-webkit-transform:translate3d(0,0,0);transform:translate3d(0,0,0)}}.active.carousel-item-right,.carousel-item-next{-webkit-transform:translateX(100%);transform:translateX(100%)}\@supports ((-webkit-transform-style:preserve-3d) or (transform-style:preserve-3d)){.active.carousel-item-right,.carousel-item-next{-webkit-transform:translate3d(100%,0,0);transform:translate3d(100%,0,0)}}.active.carousel-item-left,.carousel-item-prev{-webkit-transform:translateX(-100%);transform:translateX(-100%)}\@supports ((-webkit-transform-style:preserve-3d) or (transform-style:preserve-3d)){.active.carousel-item-left,.carousel-item-prev{-webkit-transform:translate3d(-100%,0,0);transform:translate3d(-100%,0,0)}}.carousel-fade .carousel-item{opacity:0;-webkit-transition-duration:.6s;transition-duration:.6s;-webkit-transition-property:opacity;transition-property:opacity}.carousel-fade .carousel-item-next.carousel-item-left,.carousel-fade .carousel-item-prev.carousel-item-right,.carousel-fade .carousel-item.active{opacity:1}.carousel-fade .active.carousel-item-left,.carousel-fade .active.carousel-item-right{opacity:0}.carousel-fade .active.carousel-item-left,.carousel-fade .active.carousel-item-prev,.carousel-fade .carousel-item-next,.carousel-fade .carousel-item-prev,.carousel-fade .carousel-item.active{-webkit-transform:translateX(0);transform:translateX(0)}\@supports ((-webkit-transform-style:preserve-3d) or (transform-style:preserve-3d)){.carousel-fade .active.carousel-item-left,.carousel-fade .active.carousel-item-prev,.carousel-fade .carousel-item-next,.carousel-fade .carousel-item-prev,.carousel-fade .carousel-item.active{-webkit-transform:translate3d(0,0,0);transform:translate3d(0,0,0)}}.carousel-control-next,.carousel-control-prev{position:absolute;top:0;bottom:0;display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-align:center;-webkit-box-align:center;align-items:center;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center;width:15%;color:#fff;text-align:center;opacity:.5}.carousel-control-next:focus,.carousel-control-next:hover,.carousel-control-prev:focus,.carousel-control-prev:hover{color:#fff;text-decoration:none;outline:0;opacity:.9}.carousel-control-prev{left:0}.carousel-control-next{right:0}.carousel-control-next-icon,.carousel-control-prev-icon{display:inline-block;width:20px;height:20px;background:center center/100% 100% no-repeat}.carousel-control-prev-icon{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='%23fff' viewBox='0 0 8 8'%3E%3Cpath d='M5.25 0l-4 4 4 4 1.5-1.5-2.5-2.5 2.5-2.5-1.5-1.5z'/%3E%3C/svg%3E\")}.carousel-control-next-icon{background-image:url(\"data:image/svg+xml;charset=utf8,%3Csvg xmlns='http://www.w3.org/2000/svg' fill='%23fff' viewBox='0 0 8 8'%3E%3Cpath d='M2.75 0l-1.5 1.5 2.5 2.5-2.5 2.5 1.5 1.5 4-4-4-4z'/%3E%3C/svg%3E\")}.carousel-indicators{position:absolute;right:0;bottom:10px;left:0;z-index:15;display:-ms-flexbox;display:-webkit-box;display:flex;-ms-flex-pack:center;-webkit-box-pack:center;justify-content:center;padding-left:0;margin-right:15%;margin-left:15%;list-style:none}.carousel-indicators li{position:relative;-ms-flex:0 1 auto;-webkit-box-flex:0;flex:0 1 auto;width:30px;height:3px;margin-right:3px;margin-left:3px;text-indent:-999px;cursor:pointer;background-color:rgba(255,255,255,.5)}.carousel-indicators li::before{position:absolute;top:-10px;left:0;display:inline-block;width:100%;height:10px;content:\"\"}.carousel-indicators li::after{position:absolute;bottom:-10px;left:0;display:inline-block;width:100%;height:10px;content:\"\"}.carousel-indicators .active{background-color:#fff}.carousel-caption{position:absolute;right:15%;bottom:20px;left:15%;z-index:10;padding-top:20px;padding-bottom:20px;color:#fff;text-align:center}.align-baseline{vertical-align:baseline!important}.align-top{vertical-align:top!important}.align-middle{vertical-align:middle!important}.align-bottom{vertical-align:bottom!important}.align-text-bottom{vertical-align:text-bottom!important}.align-text-top{vertical-align:text-top!important}.bg-primary{background-color:#007bff!important}a.bg-primary:focus,a.bg-primary:hover,button.bg-primary:focus,button.bg-primary:hover{background-color:#0062cc!important}.bg-secondary{background-color:#6c757d!important}a.bg-secondary:focus,a.bg-secondary:hover,button.bg-secondary:focus,button.bg-secondary:hover{background-color:#545b62!important}.bg-success{background-color:#28a745!important}a.bg-success:focus,a.bg-success:hover,button.bg-success:focus,button.bg-success:hover{background-color:#1e7e34!important}.bg-info{background-color:#17a2b8!important}a.bg-info:focus,a.bg-info:hover,button.bg-info:focus,button.bg-info:hover{background-color:#117a8b!important}.bg-warning{background-color:#ffc107!important}a.bg-warning:focus,a.bg-warning:hover,button.bg-warning:focus,button.bg-warning:hover{background-color:#d39e00!important}.bg-danger{background-color:#dc3545!important}a.bg-danger:focus,a.bg-danger:hover,button.bg-danger:focus,button.bg-danger:hover{background-color:#bd2130!important}.bg-light{background-color:#f8f9fa!important}a.bg-light:focus,a.bg-light:hover,button.bg-light:focus,button.bg-light:hover{background-color:#dae0e5!important}.bg-dark{background-color:#343a40!important}a.bg-dark:focus,a.bg-dark:hover,button.bg-dark:focus,button.bg-dark:hover{background-color:#1d2124!important}.bg-white{background-color:#fff!important}.bg-transparent{background-color:transparent!important}.border{border:1px solid #dee2e6!important}.border-top{border-top:1px solid #dee2e6!important}.border-right{border-right:1px solid #dee2e6!important}.border-bottom{border-bottom:1px solid #dee2e6!important}.border-left{border-left:1px solid #dee2e6!important}.border-0{border:0!important}.border-top-0{border-top:0!important}.border-right-0{border-right:0!important}.border-bottom-0{border-bottom:0!important}.border-left-0{border-left:0!important}.border-primary{border-color:#007bff!important}.border-secondary{border-color:#6c757d!important}.border-success{border-color:#28a745!important}.border-info{border-color:#17a2b8!important}.border-warning{border-color:#ffc107!important}.border-danger{border-color:#dc3545!important}.border-light{border-color:#f8f9fa!important}.border-dark{border-color:#343a40!important}.border-white{border-color:#fff!important}.rounded{border-radius:.25rem!important}.rounded-top{border-top-left-radius:.25rem!important;border-top-right-radius:.25rem!important}.rounded-right{border-top-right-radius:.25rem!important;border-bottom-right-radius:.25rem!important}.rounded-bottom{border-bottom-right-radius:.25rem!important;border-bottom-left-radius:.25rem!important}.rounded-left{border-top-left-radius:.25rem!important;border-bottom-left-radius:.25rem!important}.rounded-circle{border-radius:50%!important}.rounded-0{border-radius:0!important}.clearfix::after{display:block;clear:both;content:\"\"}.d-none{display:none!important}.d-inline{display:inline!important}.d-inline-block{display:inline-block!important}.d-block{display:block!important}.d-table{display:table!important}.d-table-row{display:table-row!important}.d-table-cell{display:table-cell!important}.d-flex{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important}.d-inline-flex{display:-ms-inline-flexbox!important;display:-webkit-inline-box!important;display:inline-flex!important}\@media (min-width:576px){.d-sm-none{display:none!important}.d-sm-inline{display:inline!important}.d-sm-inline-block{display:inline-block!important}.d-sm-block{display:block!important}.d-sm-table{display:table!important}.d-sm-table-row{display:table-row!important}.d-sm-table-cell{display:table-cell!important}.d-sm-flex{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important}.d-sm-inline-flex{display:-ms-inline-flexbox!important;display:-webkit-inline-box!important;display:inline-flex!important}}\@media (min-width:768px){.d-md-none{display:none!important}.d-md-inline{display:inline!important}.d-md-inline-block{display:inline-block!important}.d-md-block{display:block!important}.d-md-table{display:table!important}.d-md-table-row{display:table-row!important}.d-md-table-cell{display:table-cell!important}.d-md-flex{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important}.d-md-inline-flex{display:-ms-inline-flexbox!important;display:-webkit-inline-box!important;display:inline-flex!important}}\@media (min-width:992px){.d-lg-none{display:none!important}.d-lg-inline{display:inline!important}.d-lg-inline-block{display:inline-block!important}.d-lg-block{display:block!important}.d-lg-table{display:table!important}.d-lg-table-row{display:table-row!important}.d-lg-table-cell{display:table-cell!important}.d-lg-flex{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important}.d-lg-inline-flex{display:-ms-inline-flexbox!important;display:-webkit-inline-box!important;display:inline-flex!important}}\@media (min-width:1200px){.d-xl-none{display:none!important}.d-xl-inline{display:inline!important}.d-xl-inline-block{display:inline-block!important}.d-xl-block{display:block!important}.d-xl-table{display:table!important}.d-xl-table-row{display:table-row!important}.d-xl-table-cell{display:table-cell!important}.d-xl-flex{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important}.d-xl-inline-flex{display:-ms-inline-flexbox!important;display:-webkit-inline-box!important;display:inline-flex!important}}\@media print{.d-print-none{display:none!important}.d-print-inline{display:inline!important}.d-print-inline-block{display:inline-block!important}.d-print-block{display:block!important}.d-print-table{display:table!important}.d-print-table-row{display:table-row!important}.d-print-table-cell{display:table-cell!important}.d-print-flex{display:-ms-flexbox!important;display:-webkit-box!important;display:flex!important}.d-print-inline-flex{display:-ms-inline-flexbox!important;display:-webkit-inline-box!important;display:inline-flex!important}}.embed-responsive{position:relative;display:block;width:100%;padding:0;overflow:hidden}.embed-responsive::before{display:block;content:\"\"}.embed-responsive .embed-responsive-item,.embed-responsive embed,.embed-responsive iframe,.embed-responsive object,.embed-responsive video{position:absolute;top:0;bottom:0;left:0;width:100%;height:100%;border:0}.embed-responsive-21by9::before{padding-top:42.857143%}.embed-responsive-16by9::before{padding-top:56.25%}.embed-responsive-4by3::before{padding-top:75%}.embed-responsive-1by1::before{padding-top:100%}.flex-row{-ms-flex-direction:row!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:normal!important;flex-direction:row!important}.flex-column{-ms-flex-direction:column!important;-webkit-box-orient:vertical!important;-webkit-box-direction:normal!important;flex-direction:column!important}.flex-row-reverse{-ms-flex-direction:row-reverse!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:reverse!important;flex-direction:row-reverse!important}.flex-column-reverse{-ms-flex-direction:column-reverse!important;-webkit-box-orient:vertical!important;-webkit-box-direction:reverse!important;flex-direction:column-reverse!important}.flex-wrap{-ms-flex-wrap:wrap!important;flex-wrap:wrap!important}.flex-nowrap{-ms-flex-wrap:nowrap!important;flex-wrap:nowrap!important}.flex-wrap-reverse{-ms-flex-wrap:wrap-reverse!important;flex-wrap:wrap-reverse!important}.flex-fill{-ms-flex:1 1 auto!important;-webkit-box-flex:1!important;flex:1 1 auto!important}.flex-grow-0{-ms-flex-positive:0!important;-webkit-box-flex:0!important;flex-grow:0!important}.flex-grow-1{-ms-flex-positive:1!important;-webkit-box-flex:1!important;flex-grow:1!important}.flex-shrink-0{-ms-flex-negative:0!important;flex-shrink:0!important}.flex-shrink-1{-ms-flex-negative:1!important;flex-shrink:1!important}.justify-content-start{-ms-flex-pack:start!important;-webkit-box-pack:start!important;justify-content:flex-start!important}.justify-content-end{-ms-flex-pack:end!important;-webkit-box-pack:end!important;justify-content:flex-end!important}.justify-content-center{-ms-flex-pack:center!important;-webkit-box-pack:center!important;justify-content:center!important}.justify-content-between{-ms-flex-pack:justify!important;-webkit-box-pack:justify!important;justify-content:space-between!important}.justify-content-around{-ms-flex-pack:distribute!important;justify-content:space-around!important}.align-items-start{-ms-flex-align:start!important;-webkit-box-align:start!important;align-items:flex-start!important}.align-items-end{-ms-flex-align:end!important;-webkit-box-align:end!important;align-items:flex-end!important}.align-items-center{-ms-flex-align:center!important;-webkit-box-align:center!important;align-items:center!important}.align-items-baseline{-ms-flex-align:baseline!important;-webkit-box-align:baseline!important;align-items:baseline!important}.align-items-stretch{-ms-flex-align:stretch!important;-webkit-box-align:stretch!important;align-items:stretch!important}.align-content-start{-ms-flex-line-pack:start!important;align-content:flex-start!important}.align-content-end{-ms-flex-line-pack:end!important;align-content:flex-end!important}.align-content-center{-ms-flex-line-pack:center!important;align-content:center!important}.align-content-between{-ms-flex-line-pack:justify!important;align-content:space-between!important}.align-content-around{-ms-flex-line-pack:distribute!important;align-content:space-around!important}.align-content-stretch{-ms-flex-line-pack:stretch!important;align-content:stretch!important}.align-self-auto{-ms-flex-item-align:auto!important;align-self:auto!important}.align-self-start{-ms-flex-item-align:start!important;align-self:flex-start!important}.align-self-end{-ms-flex-item-align:end!important;align-self:flex-end!important}.align-self-center{-ms-flex-item-align:center!important;align-self:center!important}.align-self-baseline{-ms-flex-item-align:baseline!important;align-self:baseline!important}.align-self-stretch{-ms-flex-item-align:stretch!important;align-self:stretch!important}.float-left{float:left!important}.float-right{float:right!important}.float-none{float:none!important}.position-static{position:static!important}.position-relative{position:relative!important}.position-absolute{position:absolute!important}.position-fixed{position:fixed!important}.position-sticky{position:-webkit-sticky!important;position:sticky!important}.fixed-top{position:fixed;top:0;right:0;left:0;z-index:1030}.fixed-bottom{position:fixed;right:0;bottom:0;left:0;z-index:1030}\@supports ((position:-webkit-sticky) or (position:sticky)){.sticky-top{position:-webkit-sticky;position:sticky;top:0;z-index:1020}}.sr-only{clip:rect(0,0,0,0);white-space:nowrap}.shadow-sm{-webkit-box-shadow:0 .125rem .25rem rgba(0,0,0,.075)!important;box-shadow:0 .125rem .25rem rgba(0,0,0,.075)!important}.shadow{-webkit-box-shadow:0 .5rem 1rem rgba(0,0,0,.15)!important;box-shadow:0 .5rem 1rem rgba(0,0,0,.15)!important}.shadow-lg{-webkit-box-shadow:0 1rem 3rem rgba(0,0,0,.175)!important;box-shadow:0 1rem 3rem rgba(0,0,0,.175)!important}.shadow-none{-webkit-box-shadow:none!important;box-shadow:none!important}.w-25{width:25%!important}.w-50{width:50%!important}.w-75{width:75%!important}.w-100{width:100%!important}.w-auto{width:auto!important}.h-25{height:25%!important}.h-50{height:50%!important}.h-75{height:75%!important}.h-100{height:100%!important}.h-auto{height:auto!important}.mw-100{max-width:100%!important}.mh-100{max-height:100%!important}.m-0{margin:0!important}.mt-0,.my-0{margin-top:0!important}.mr-0,.mx-0{margin-right:0!important}.mb-0,.my-0{margin-bottom:0!important}.ml-0,.mx-0{margin-left:0!important}.m-1{margin:.25rem!important}.mt-1,.my-1{margin-top:.25rem!important}.mr-1,.mx-1{margin-right:.25rem!important}.mb-1,.my-1{margin-bottom:.25rem!important}.ml-1,.mx-1{margin-left:.25rem!important}.m-2{margin:.5rem!important}.mt-2,.my-2{margin-top:.5rem!important}.mr-2,.mx-2{margin-right:.5rem!important}.mb-2,.my-2{margin-bottom:.5rem!important}.ml-2,.mx-2{margin-left:.5rem!important}.m-3{margin:1rem!important}.mt-3,.my-3{margin-top:1rem!important}.mr-3,.mx-3{margin-right:1rem!important}.mb-3,.my-3{margin-bottom:1rem!important}.ml-3,.mx-3{margin-left:1rem!important}.m-4{margin:1.5rem!important}.mt-4,.my-4{margin-top:1.5rem!important}.mr-4,.mx-4{margin-right:1.5rem!important}.mb-4,.my-4{margin-bottom:1.5rem!important}.ml-4,.mx-4{margin-left:1.5rem!important}.m-5{margin:3rem!important}.mt-5,.my-5{margin-top:3rem!important}.mr-5,.mx-5{margin-right:3rem!important}.mb-5,.my-5{margin-bottom:3rem!important}.ml-5,.mx-5{margin-left:3rem!important}.p-0{padding:0!important}.pt-0,.py-0{padding-top:0!important}.pr-0,.px-0{padding-right:0!important}.pb-0,.py-0{padding-bottom:0!important}.pl-0,.px-0{padding-left:0!important}.p-1{padding:.25rem!important}.pt-1,.py-1{padding-top:.25rem!important}.pr-1,.px-1{padding-right:.25rem!important}.pb-1,.py-1{padding-bottom:.25rem!important}.pl-1,.px-1{padding-left:.25rem!important}.p-2{padding:.5rem!important}.pt-2,.py-2{padding-top:.5rem!important}.pr-2,.px-2{padding-right:.5rem!important}.pb-2,.py-2{padding-bottom:.5rem!important}.pl-2,.px-2{padding-left:.5rem!important}.p-3{padding:1rem!important}.pt-3,.py-3{padding-top:1rem!important}.pr-3,.px-3{padding-right:1rem!important}.pb-3,.py-3{padding-bottom:1rem!important}.pl-3,.px-3{padding-left:1rem!important}.p-4{padding:1.5rem!important}.pt-4,.py-4{padding-top:1.5rem!important}.pr-4,.px-4{padding-right:1.5rem!important}.pb-4,.py-4{padding-bottom:1.5rem!important}.pl-4,.px-4{padding-left:1.5rem!important}.p-5{padding:3rem!important}.pt-5,.py-5{padding-top:3rem!important}.pr-5,.px-5{padding-right:3rem!important}.pb-5,.py-5{padding-bottom:3rem!important}.pl-5,.px-5{padding-left:3rem!important}.m-auto{margin:auto!important}.mt-auto,.my-auto{margin-top:auto!important}.mr-auto,.mx-auto{margin-right:auto!important}.mb-auto,.my-auto{margin-bottom:auto!important}.ml-auto,.mx-auto{margin-left:auto!important}.text-monospace{font-family:SFMono-Regular,Menlo,Monaco,Consolas,\"Liberation Mono\",\"Courier New\",monospace}.text-justify{text-align:justify!important}.text-nowrap{white-space:nowrap!important}.text-truncate{overflow:hidden;text-overflow:ellipsis;white-space:nowrap}.text-left{text-align:left!important}.text-right{text-align:right!important}.text-center{text-align:center!important}\@media (min-width:576px){.flex-sm-row{-ms-flex-direction:row!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:normal!important;flex-direction:row!important}.flex-sm-column{-ms-flex-direction:column!important;-webkit-box-orient:vertical!important;-webkit-box-direction:normal!important;flex-direction:column!important}.flex-sm-row-reverse{-ms-flex-direction:row-reverse!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:reverse!important;flex-direction:row-reverse!important}.flex-sm-column-reverse{-ms-flex-direction:column-reverse!important;-webkit-box-orient:vertical!important;-webkit-box-direction:reverse!important;flex-direction:column-reverse!important}.flex-sm-wrap{-ms-flex-wrap:wrap!important;flex-wrap:wrap!important}.flex-sm-nowrap{-ms-flex-wrap:nowrap!important;flex-wrap:nowrap!important}.flex-sm-wrap-reverse{-ms-flex-wrap:wrap-reverse!important;flex-wrap:wrap-reverse!important}.flex-sm-fill{-ms-flex:1 1 auto!important;-webkit-box-flex:1!important;flex:1 1 auto!important}.flex-sm-grow-0{-ms-flex-positive:0!important;-webkit-box-flex:0!important;flex-grow:0!important}.flex-sm-grow-1{-ms-flex-positive:1!important;-webkit-box-flex:1!important;flex-grow:1!important}.flex-sm-shrink-0{-ms-flex-negative:0!important;flex-shrink:0!important}.flex-sm-shrink-1{-ms-flex-negative:1!important;flex-shrink:1!important}.justify-content-sm-start{-ms-flex-pack:start!important;-webkit-box-pack:start!important;justify-content:flex-start!important}.justify-content-sm-end{-ms-flex-pack:end!important;-webkit-box-pack:end!important;justify-content:flex-end!important}.justify-content-sm-center{-ms-flex-pack:center!important;-webkit-box-pack:center!important;justify-content:center!important}.justify-content-sm-between{-ms-flex-pack:justify!important;-webkit-box-pack:justify!important;justify-content:space-between!important}.justify-content-sm-around{-ms-flex-pack:distribute!important;justify-content:space-around!important}.align-items-sm-start{-ms-flex-align:start!important;-webkit-box-align:start!important;align-items:flex-start!important}.align-items-sm-end{-ms-flex-align:end!important;-webkit-box-align:end!important;align-items:flex-end!important}.align-items-sm-center{-ms-flex-align:center!important;-webkit-box-align:center!important;align-items:center!important}.align-items-sm-baseline{-ms-flex-align:baseline!important;-webkit-box-align:baseline!important;align-items:baseline!important}.align-items-sm-stretch{-ms-flex-align:stretch!important;-webkit-box-align:stretch!important;align-items:stretch!important}.align-content-sm-start{-ms-flex-line-pack:start!important;align-content:flex-start!important}.align-content-sm-end{-ms-flex-line-pack:end!important;align-content:flex-end!important}.align-content-sm-center{-ms-flex-line-pack:center!important;align-content:center!important}.align-content-sm-between{-ms-flex-line-pack:justify!important;align-content:space-between!important}.align-content-sm-around{-ms-flex-line-pack:distribute!important;align-content:space-around!important}.align-content-sm-stretch{-ms-flex-line-pack:stretch!important;align-content:stretch!important}.align-self-sm-auto{-ms-flex-item-align:auto!important;align-self:auto!important}.align-self-sm-start{-ms-flex-item-align:start!important;align-self:flex-start!important}.align-self-sm-end{-ms-flex-item-align:end!important;align-self:flex-end!important}.align-self-sm-center{-ms-flex-item-align:center!important;align-self:center!important}.align-self-sm-baseline{-ms-flex-item-align:baseline!important;align-self:baseline!important}.align-self-sm-stretch{-ms-flex-item-align:stretch!important;align-self:stretch!important}.float-sm-left{float:left!important}.float-sm-right{float:right!important}.float-sm-none{float:none!important}.m-sm-0{margin:0!important}.mt-sm-0,.my-sm-0{margin-top:0!important}.mr-sm-0,.mx-sm-0{margin-right:0!important}.mb-sm-0,.my-sm-0{margin-bottom:0!important}.ml-sm-0,.mx-sm-0{margin-left:0!important}.m-sm-1{margin:.25rem!important}.mt-sm-1,.my-sm-1{margin-top:.25rem!important}.mr-sm-1,.mx-sm-1{margin-right:.25rem!important}.mb-sm-1,.my-sm-1{margin-bottom:.25rem!important}.ml-sm-1,.mx-sm-1{margin-left:.25rem!important}.m-sm-2{margin:.5rem!important}.mt-sm-2,.my-sm-2{margin-top:.5rem!important}.mr-sm-2,.mx-sm-2{margin-right:.5rem!important}.mb-sm-2,.my-sm-2{margin-bottom:.5rem!important}.ml-sm-2,.mx-sm-2{margin-left:.5rem!important}.m-sm-3{margin:1rem!important}.mt-sm-3,.my-sm-3{margin-top:1rem!important}.mr-sm-3,.mx-sm-3{margin-right:1rem!important}.mb-sm-3,.my-sm-3{margin-bottom:1rem!important}.ml-sm-3,.mx-sm-3{margin-left:1rem!important}.m-sm-4{margin:1.5rem!important}.mt-sm-4,.my-sm-4{margin-top:1.5rem!important}.mr-sm-4,.mx-sm-4{margin-right:1.5rem!important}.mb-sm-4,.my-sm-4{margin-bottom:1.5rem!important}.ml-sm-4,.mx-sm-4{margin-left:1.5rem!important}.m-sm-5{margin:3rem!important}.mt-sm-5,.my-sm-5{margin-top:3rem!important}.mr-sm-5,.mx-sm-5{margin-right:3rem!important}.mb-sm-5,.my-sm-5{margin-bottom:3rem!important}.ml-sm-5,.mx-sm-5{margin-left:3rem!important}.p-sm-0{padding:0!important}.pt-sm-0,.py-sm-0{padding-top:0!important}.pr-sm-0,.px-sm-0{padding-right:0!important}.pb-sm-0,.py-sm-0{padding-bottom:0!important}.pl-sm-0,.px-sm-0{padding-left:0!important}.p-sm-1{padding:.25rem!important}.pt-sm-1,.py-sm-1{padding-top:.25rem!important}.pr-sm-1,.px-sm-1{padding-right:.25rem!important}.pb-sm-1,.py-sm-1{padding-bottom:.25rem!important}.pl-sm-1,.px-sm-1{padding-left:.25rem!important}.p-sm-2{padding:.5rem!important}.pt-sm-2,.py-sm-2{padding-top:.5rem!important}.pr-sm-2,.px-sm-2{padding-right:.5rem!important}.pb-sm-2,.py-sm-2{padding-bottom:.5rem!important}.pl-sm-2,.px-sm-2{padding-left:.5rem!important}.p-sm-3{padding:1rem!important}.pt-sm-3,.py-sm-3{padding-top:1rem!important}.pr-sm-3,.px-sm-3{padding-right:1rem!important}.pb-sm-3,.py-sm-3{padding-bottom:1rem!important}.pl-sm-3,.px-sm-3{padding-left:1rem!important}.p-sm-4{padding:1.5rem!important}.pt-sm-4,.py-sm-4{padding-top:1.5rem!important}.pr-sm-4,.px-sm-4{padding-right:1.5rem!important}.pb-sm-4,.py-sm-4{padding-bottom:1.5rem!important}.pl-sm-4,.px-sm-4{padding-left:1.5rem!important}.p-sm-5{padding:3rem!important}.pt-sm-5,.py-sm-5{padding-top:3rem!important}.pr-sm-5,.px-sm-5{padding-right:3rem!important}.pb-sm-5,.py-sm-5{padding-bottom:3rem!important}.pl-sm-5,.px-sm-5{padding-left:3rem!important}.m-sm-auto{margin:auto!important}.mt-sm-auto,.my-sm-auto{margin-top:auto!important}.mr-sm-auto,.mx-sm-auto{margin-right:auto!important}.mb-sm-auto,.my-sm-auto{margin-bottom:auto!important}.ml-sm-auto,.mx-sm-auto{margin-left:auto!important}.text-sm-left{text-align:left!important}.text-sm-right{text-align:right!important}.text-sm-center{text-align:center!important}}\@media (min-width:768px){.flex-md-row{-ms-flex-direction:row!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:normal!important;flex-direction:row!important}.flex-md-column{-ms-flex-direction:column!important;-webkit-box-orient:vertical!important;-webkit-box-direction:normal!important;flex-direction:column!important}.flex-md-row-reverse{-ms-flex-direction:row-reverse!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:reverse!important;flex-direction:row-reverse!important}.flex-md-column-reverse{-ms-flex-direction:column-reverse!important;-webkit-box-orient:vertical!important;-webkit-box-direction:reverse!important;flex-direction:column-reverse!important}.flex-md-wrap{-ms-flex-wrap:wrap!important;flex-wrap:wrap!important}.flex-md-nowrap{-ms-flex-wrap:nowrap!important;flex-wrap:nowrap!important}.flex-md-wrap-reverse{-ms-flex-wrap:wrap-reverse!important;flex-wrap:wrap-reverse!important}.flex-md-fill{-ms-flex:1 1 auto!important;-webkit-box-flex:1!important;flex:1 1 auto!important}.flex-md-grow-0{-ms-flex-positive:0!important;-webkit-box-flex:0!important;flex-grow:0!important}.flex-md-grow-1{-ms-flex-positive:1!important;-webkit-box-flex:1!important;flex-grow:1!important}.flex-md-shrink-0{-ms-flex-negative:0!important;flex-shrink:0!important}.flex-md-shrink-1{-ms-flex-negative:1!important;flex-shrink:1!important}.justify-content-md-start{-ms-flex-pack:start!important;-webkit-box-pack:start!important;justify-content:flex-start!important}.justify-content-md-end{-ms-flex-pack:end!important;-webkit-box-pack:end!important;justify-content:flex-end!important}.justify-content-md-center{-ms-flex-pack:center!important;-webkit-box-pack:center!important;justify-content:center!important}.justify-content-md-between{-ms-flex-pack:justify!important;-webkit-box-pack:justify!important;justify-content:space-between!important}.justify-content-md-around{-ms-flex-pack:distribute!important;justify-content:space-around!important}.align-items-md-start{-ms-flex-align:start!important;-webkit-box-align:start!important;align-items:flex-start!important}.align-items-md-end{-ms-flex-align:end!important;-webkit-box-align:end!important;align-items:flex-end!important}.align-items-md-center{-ms-flex-align:center!important;-webkit-box-align:center!important;align-items:center!important}.align-items-md-baseline{-ms-flex-align:baseline!important;-webkit-box-align:baseline!important;align-items:baseline!important}.align-items-md-stretch{-ms-flex-align:stretch!important;-webkit-box-align:stretch!important;align-items:stretch!important}.align-content-md-start{-ms-flex-line-pack:start!important;align-content:flex-start!important}.align-content-md-end{-ms-flex-line-pack:end!important;align-content:flex-end!important}.align-content-md-center{-ms-flex-line-pack:center!important;align-content:center!important}.align-content-md-between{-ms-flex-line-pack:justify!important;align-content:space-between!important}.align-content-md-around{-ms-flex-line-pack:distribute!important;align-content:space-around!important}.align-content-md-stretch{-ms-flex-line-pack:stretch!important;align-content:stretch!important}.align-self-md-auto{-ms-flex-item-align:auto!important;align-self:auto!important}.align-self-md-start{-ms-flex-item-align:start!important;align-self:flex-start!important}.align-self-md-end{-ms-flex-item-align:end!important;align-self:flex-end!important}.align-self-md-center{-ms-flex-item-align:center!important;align-self:center!important}.align-self-md-baseline{-ms-flex-item-align:baseline!important;align-self:baseline!important}.align-self-md-stretch{-ms-flex-item-align:stretch!important;align-self:stretch!important}.float-md-left{float:left!important}.float-md-right{float:right!important}.float-md-none{float:none!important}.m-md-0{margin:0!important}.mt-md-0,.my-md-0{margin-top:0!important}.mr-md-0,.mx-md-0{margin-right:0!important}.mb-md-0,.my-md-0{margin-bottom:0!important}.ml-md-0,.mx-md-0{margin-left:0!important}.m-md-1{margin:.25rem!important}.mt-md-1,.my-md-1{margin-top:.25rem!important}.mr-md-1,.mx-md-1{margin-right:.25rem!important}.mb-md-1,.my-md-1{margin-bottom:.25rem!important}.ml-md-1,.mx-md-1{margin-left:.25rem!important}.m-md-2{margin:.5rem!important}.mt-md-2,.my-md-2{margin-top:.5rem!important}.mr-md-2,.mx-md-2{margin-right:.5rem!important}.mb-md-2,.my-md-2{margin-bottom:.5rem!important}.ml-md-2,.mx-md-2{margin-left:.5rem!important}.m-md-3{margin:1rem!important}.mt-md-3,.my-md-3{margin-top:1rem!important}.mr-md-3,.mx-md-3{margin-right:1rem!important}.mb-md-3,.my-md-3{margin-bottom:1rem!important}.ml-md-3,.mx-md-3{margin-left:1rem!important}.m-md-4{margin:1.5rem!important}.mt-md-4,.my-md-4{margin-top:1.5rem!important}.mr-md-4,.mx-md-4{margin-right:1.5rem!important}.mb-md-4,.my-md-4{margin-bottom:1.5rem!important}.ml-md-4,.mx-md-4{margin-left:1.5rem!important}.m-md-5{margin:3rem!important}.mt-md-5,.my-md-5{margin-top:3rem!important}.mr-md-5,.mx-md-5{margin-right:3rem!important}.mb-md-5,.my-md-5{margin-bottom:3rem!important}.ml-md-5,.mx-md-5{margin-left:3rem!important}.p-md-0{padding:0!important}.pt-md-0,.py-md-0{padding-top:0!important}.pr-md-0,.px-md-0{padding-right:0!important}.pb-md-0,.py-md-0{padding-bottom:0!important}.pl-md-0,.px-md-0{padding-left:0!important}.p-md-1{padding:.25rem!important}.pt-md-1,.py-md-1{padding-top:.25rem!important}.pr-md-1,.px-md-1{padding-right:.25rem!important}.pb-md-1,.py-md-1{padding-bottom:.25rem!important}.pl-md-1,.px-md-1{padding-left:.25rem!important}.p-md-2{padding:.5rem!important}.pt-md-2,.py-md-2{padding-top:.5rem!important}.pr-md-2,.px-md-2{padding-right:.5rem!important}.pb-md-2,.py-md-2{padding-bottom:.5rem!important}.pl-md-2,.px-md-2{padding-left:.5rem!important}.p-md-3{padding:1rem!important}.pt-md-3,.py-md-3{padding-top:1rem!important}.pr-md-3,.px-md-3{padding-right:1rem!important}.pb-md-3,.py-md-3{padding-bottom:1rem!important}.pl-md-3,.px-md-3{padding-left:1rem!important}.p-md-4{padding:1.5rem!important}.pt-md-4,.py-md-4{padding-top:1.5rem!important}.pr-md-4,.px-md-4{padding-right:1.5rem!important}.pb-md-4,.py-md-4{padding-bottom:1.5rem!important}.pl-md-4,.px-md-4{padding-left:1.5rem!important}.p-md-5{padding:3rem!important}.pt-md-5,.py-md-5{padding-top:3rem!important}.pr-md-5,.px-md-5{padding-right:3rem!important}.pb-md-5,.py-md-5{padding-bottom:3rem!important}.pl-md-5,.px-md-5{padding-left:3rem!important}.m-md-auto{margin:auto!important}.mt-md-auto,.my-md-auto{margin-top:auto!important}.mr-md-auto,.mx-md-auto{margin-right:auto!important}.mb-md-auto,.my-md-auto{margin-bottom:auto!important}.ml-md-auto,.mx-md-auto{margin-left:auto!important}.text-md-left{text-align:left!important}.text-md-right{text-align:right!important}.text-md-center{text-align:center!important}}\@media (min-width:992px){.flex-lg-row{-ms-flex-direction:row!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:normal!important;flex-direction:row!important}.flex-lg-column{-ms-flex-direction:column!important;-webkit-box-orient:vertical!important;-webkit-box-direction:normal!important;flex-direction:column!important}.flex-lg-row-reverse{-ms-flex-direction:row-reverse!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:reverse!important;flex-direction:row-reverse!important}.flex-lg-column-reverse{-ms-flex-direction:column-reverse!important;-webkit-box-orient:vertical!important;-webkit-box-direction:reverse!important;flex-direction:column-reverse!important}.flex-lg-wrap{-ms-flex-wrap:wrap!important;flex-wrap:wrap!important}.flex-lg-nowrap{-ms-flex-wrap:nowrap!important;flex-wrap:nowrap!important}.flex-lg-wrap-reverse{-ms-flex-wrap:wrap-reverse!important;flex-wrap:wrap-reverse!important}.flex-lg-fill{-ms-flex:1 1 auto!important;-webkit-box-flex:1!important;flex:1 1 auto!important}.flex-lg-grow-0{-ms-flex-positive:0!important;-webkit-box-flex:0!important;flex-grow:0!important}.flex-lg-grow-1{-ms-flex-positive:1!important;-webkit-box-flex:1!important;flex-grow:1!important}.flex-lg-shrink-0{-ms-flex-negative:0!important;flex-shrink:0!important}.flex-lg-shrink-1{-ms-flex-negative:1!important;flex-shrink:1!important}.justify-content-lg-start{-ms-flex-pack:start!important;-webkit-box-pack:start!important;justify-content:flex-start!important}.justify-content-lg-end{-ms-flex-pack:end!important;-webkit-box-pack:end!important;justify-content:flex-end!important}.justify-content-lg-center{-ms-flex-pack:center!important;-webkit-box-pack:center!important;justify-content:center!important}.justify-content-lg-between{-ms-flex-pack:justify!important;-webkit-box-pack:justify!important;justify-content:space-between!important}.justify-content-lg-around{-ms-flex-pack:distribute!important;justify-content:space-around!important}.align-items-lg-start{-ms-flex-align:start!important;-webkit-box-align:start!important;align-items:flex-start!important}.align-items-lg-end{-ms-flex-align:end!important;-webkit-box-align:end!important;align-items:flex-end!important}.align-items-lg-center{-ms-flex-align:center!important;-webkit-box-align:center!important;align-items:center!important}.align-items-lg-baseline{-ms-flex-align:baseline!important;-webkit-box-align:baseline!important;align-items:baseline!important}.align-items-lg-stretch{-ms-flex-align:stretch!important;-webkit-box-align:stretch!important;align-items:stretch!important}.align-content-lg-start{-ms-flex-line-pack:start!important;align-content:flex-start!important}.align-content-lg-end{-ms-flex-line-pack:end!important;align-content:flex-end!important}.align-content-lg-center{-ms-flex-line-pack:center!important;align-content:center!important}.align-content-lg-between{-ms-flex-line-pack:justify!important;align-content:space-between!important}.align-content-lg-around{-ms-flex-line-pack:distribute!important;align-content:space-around!important}.align-content-lg-stretch{-ms-flex-line-pack:stretch!important;align-content:stretch!important}.align-self-lg-auto{-ms-flex-item-align:auto!important;align-self:auto!important}.align-self-lg-start{-ms-flex-item-align:start!important;align-self:flex-start!important}.align-self-lg-end{-ms-flex-item-align:end!important;align-self:flex-end!important}.align-self-lg-center{-ms-flex-item-align:center!important;align-self:center!important}.align-self-lg-baseline{-ms-flex-item-align:baseline!important;align-self:baseline!important}.align-self-lg-stretch{-ms-flex-item-align:stretch!important;align-self:stretch!important}.float-lg-left{float:left!important}.float-lg-right{float:right!important}.float-lg-none{float:none!important}.m-lg-0{margin:0!important}.mt-lg-0,.my-lg-0{margin-top:0!important}.mr-lg-0,.mx-lg-0{margin-right:0!important}.mb-lg-0,.my-lg-0{margin-bottom:0!important}.ml-lg-0,.mx-lg-0{margin-left:0!important}.m-lg-1{margin:.25rem!important}.mt-lg-1,.my-lg-1{margin-top:.25rem!important}.mr-lg-1,.mx-lg-1{margin-right:.25rem!important}.mb-lg-1,.my-lg-1{margin-bottom:.25rem!important}.ml-lg-1,.mx-lg-1{margin-left:.25rem!important}.m-lg-2{margin:.5rem!important}.mt-lg-2,.my-lg-2{margin-top:.5rem!important}.mr-lg-2,.mx-lg-2{margin-right:.5rem!important}.mb-lg-2,.my-lg-2{margin-bottom:.5rem!important}.ml-lg-2,.mx-lg-2{margin-left:.5rem!important}.m-lg-3{margin:1rem!important}.mt-lg-3,.my-lg-3{margin-top:1rem!important}.mr-lg-3,.mx-lg-3{margin-right:1rem!important}.mb-lg-3,.my-lg-3{margin-bottom:1rem!important}.ml-lg-3,.mx-lg-3{margin-left:1rem!important}.m-lg-4{margin:1.5rem!important}.mt-lg-4,.my-lg-4{margin-top:1.5rem!important}.mr-lg-4,.mx-lg-4{margin-right:1.5rem!important}.mb-lg-4,.my-lg-4{margin-bottom:1.5rem!important}.ml-lg-4,.mx-lg-4{margin-left:1.5rem!important}.m-lg-5{margin:3rem!important}.mt-lg-5,.my-lg-5{margin-top:3rem!important}.mr-lg-5,.mx-lg-5{margin-right:3rem!important}.mb-lg-5,.my-lg-5{margin-bottom:3rem!important}.ml-lg-5,.mx-lg-5{margin-left:3rem!important}.p-lg-0{padding:0!important}.pt-lg-0,.py-lg-0{padding-top:0!important}.pr-lg-0,.px-lg-0{padding-right:0!important}.pb-lg-0,.py-lg-0{padding-bottom:0!important}.pl-lg-0,.px-lg-0{padding-left:0!important}.p-lg-1{padding:.25rem!important}.pt-lg-1,.py-lg-1{padding-top:.25rem!important}.pr-lg-1,.px-lg-1{padding-right:.25rem!important}.pb-lg-1,.py-lg-1{padding-bottom:.25rem!important}.pl-lg-1,.px-lg-1{padding-left:.25rem!important}.p-lg-2{padding:.5rem!important}.pt-lg-2,.py-lg-2{padding-top:.5rem!important}.pr-lg-2,.px-lg-2{padding-right:.5rem!important}.pb-lg-2,.py-lg-2{padding-bottom:.5rem!important}.pl-lg-2,.px-lg-2{padding-left:.5rem!important}.p-lg-3{padding:1rem!important}.pt-lg-3,.py-lg-3{padding-top:1rem!important}.pr-lg-3,.px-lg-3{padding-right:1rem!important}.pb-lg-3,.py-lg-3{padding-bottom:1rem!important}.pl-lg-3,.px-lg-3{padding-left:1rem!important}.p-lg-4{padding:1.5rem!important}.pt-lg-4,.py-lg-4{padding-top:1.5rem!important}.pr-lg-4,.px-lg-4{padding-right:1.5rem!important}.pb-lg-4,.py-lg-4{padding-bottom:1.5rem!important}.pl-lg-4,.px-lg-4{padding-left:1.5rem!important}.p-lg-5{padding:3rem!important}.pt-lg-5,.py-lg-5{padding-top:3rem!important}.pr-lg-5,.px-lg-5{padding-right:3rem!important}.pb-lg-5,.py-lg-5{padding-bottom:3rem!important}.pl-lg-5,.px-lg-5{padding-left:3rem!important}.m-lg-auto{margin:auto!important}.mt-lg-auto,.my-lg-auto{margin-top:auto!important}.mr-lg-auto,.mx-lg-auto{margin-right:auto!important}.mb-lg-auto,.my-lg-auto{margin-bottom:auto!important}.ml-lg-auto,.mx-lg-auto{margin-left:auto!important}.text-lg-left{text-align:left!important}.text-lg-right{text-align:right!important}.text-lg-center{text-align:center!important}}\@media (min-width:1200px){.flex-xl-row{-ms-flex-direction:row!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:normal!important;flex-direction:row!important}.flex-xl-column{-ms-flex-direction:column!important;-webkit-box-orient:vertical!important;-webkit-box-direction:normal!important;flex-direction:column!important}.flex-xl-row-reverse{-ms-flex-direction:row-reverse!important;-webkit-box-orient:horizontal!important;-webkit-box-direction:reverse!important;flex-direction:row-reverse!important}.flex-xl-column-reverse{-ms-flex-direction:column-reverse!important;-webkit-box-orient:vertical!important;-webkit-box-direction:reverse!important;flex-direction:column-reverse!important}.flex-xl-wrap{-ms-flex-wrap:wrap!important;flex-wrap:wrap!important}.flex-xl-nowrap{-ms-flex-wrap:nowrap!important;flex-wrap:nowrap!important}.flex-xl-wrap-reverse{-ms-flex-wrap:wrap-reverse!important;flex-wrap:wrap-reverse!important}.flex-xl-fill{-ms-flex:1 1 auto!important;-webkit-box-flex:1!important;flex:1 1 auto!important}.flex-xl-grow-0{-ms-flex-positive:0!important;-webkit-box-flex:0!important;flex-grow:0!important}.flex-xl-grow-1{-ms-flex-positive:1!important;-webkit-box-flex:1!important;flex-grow:1!important}.flex-xl-shrink-0{-ms-flex-negative:0!important;flex-shrink:0!important}.flex-xl-shrink-1{-ms-flex-negative:1!important;flex-shrink:1!important}.justify-content-xl-start{-ms-flex-pack:start!important;-webkit-box-pack:start!important;justify-content:flex-start!important}.justify-content-xl-end{-ms-flex-pack:end!important;-webkit-box-pack:end!important;justify-content:flex-end!important}.justify-content-xl-center{-ms-flex-pack:center!important;-webkit-box-pack:center!important;justify-content:center!important}.justify-content-xl-between{-ms-flex-pack:justify!important;-webkit-box-pack:justify!important;justify-content:space-between!important}.justify-content-xl-around{-ms-flex-pack:distribute!important;justify-content:space-around!important}.align-items-xl-start{-ms-flex-align:start!important;-webkit-box-align:start!important;align-items:flex-start!important}.align-items-xl-end{-ms-flex-align:end!important;-webkit-box-align:end!important;align-items:flex-end!important}.align-items-xl-center{-ms-flex-align:center!important;-webkit-box-align:center!important;align-items:center!important}.align-items-xl-baseline{-ms-flex-align:baseline!important;-webkit-box-align:baseline!important;align-items:baseline!important}.align-items-xl-stretch{-ms-flex-align:stretch!important;-webkit-box-align:stretch!important;align-items:stretch!important}.align-content-xl-start{-ms-flex-line-pack:start!important;align-content:flex-start!important}.align-content-xl-end{-ms-flex-line-pack:end!important;align-content:flex-end!important}.align-content-xl-center{-ms-flex-line-pack:center!important;align-content:center!important}.align-content-xl-between{-ms-flex-line-pack:justify!important;align-content:space-between!important}.align-content-xl-around{-ms-flex-line-pack:distribute!important;align-content:space-around!important}.align-content-xl-stretch{-ms-flex-line-pack:stretch!important;align-content:stretch!important}.align-self-xl-auto{-ms-flex-item-align:auto!important;align-self:auto!important}.align-self-xl-start{-ms-flex-item-align:start!important;align-self:flex-start!important}.align-self-xl-end{-ms-flex-item-align:end!important;align-self:flex-end!important}.align-self-xl-center{-ms-flex-item-align:center!important;align-self:center!important}.align-self-xl-baseline{-ms-flex-item-align:baseline!important;align-self:baseline!important}.align-self-xl-stretch{-ms-flex-item-align:stretch!important;align-self:stretch!important}.float-xl-left{float:left!important}.float-xl-right{float:right!important}.float-xl-none{float:none!important}.m-xl-0{margin:0!important}.mt-xl-0,.my-xl-0{margin-top:0!important}.mr-xl-0,.mx-xl-0{margin-right:0!important}.mb-xl-0,.my-xl-0{margin-bottom:0!important}.ml-xl-0,.mx-xl-0{margin-left:0!important}.m-xl-1{margin:.25rem!important}.mt-xl-1,.my-xl-1{margin-top:.25rem!important}.mr-xl-1,.mx-xl-1{margin-right:.25rem!important}.mb-xl-1,.my-xl-1{margin-bottom:.25rem!important}.ml-xl-1,.mx-xl-1{margin-left:.25rem!important}.m-xl-2{margin:.5rem!important}.mt-xl-2,.my-xl-2{margin-top:.5rem!important}.mr-xl-2,.mx-xl-2{margin-right:.5rem!important}.mb-xl-2,.my-xl-2{margin-bottom:.5rem!important}.ml-xl-2,.mx-xl-2{margin-left:.5rem!important}.m-xl-3{margin:1rem!important}.mt-xl-3,.my-xl-3{margin-top:1rem!important}.mr-xl-3,.mx-xl-3{margin-right:1rem!important}.mb-xl-3,.my-xl-3{margin-bottom:1rem!important}.ml-xl-3,.mx-xl-3{margin-left:1rem!important}.m-xl-4{margin:1.5rem!important}.mt-xl-4,.my-xl-4{margin-top:1.5rem!important}.mr-xl-4,.mx-xl-4{margin-right:1.5rem!important}.mb-xl-4,.my-xl-4{margin-bottom:1.5rem!important}.ml-xl-4,.mx-xl-4{margin-left:1.5rem!important}.m-xl-5{margin:3rem!important}.mt-xl-5,.my-xl-5{margin-top:3rem!important}.mr-xl-5,.mx-xl-5{margin-right:3rem!important}.mb-xl-5,.my-xl-5{margin-bottom:3rem!important}.ml-xl-5,.mx-xl-5{margin-left:3rem!important}.p-xl-0{padding:0!important}.pt-xl-0,.py-xl-0{padding-top:0!important}.pr-xl-0,.px-xl-0{padding-right:0!important}.pb-xl-0,.py-xl-0{padding-bottom:0!important}.pl-xl-0,.px-xl-0{padding-left:0!important}.p-xl-1{padding:.25rem!important}.pt-xl-1,.py-xl-1{padding-top:.25rem!important}.pr-xl-1,.px-xl-1{padding-right:.25rem!important}.pb-xl-1,.py-xl-1{padding-bottom:.25rem!important}.pl-xl-1,.px-xl-1{padding-left:.25rem!important}.p-xl-2{padding:.5rem!important}.pt-xl-2,.py-xl-2{padding-top:.5rem!important}.pr-xl-2,.px-xl-2{padding-right:.5rem!important}.pb-xl-2,.py-xl-2{padding-bottom:.5rem!important}.pl-xl-2,.px-xl-2{padding-left:.5rem!important}.p-xl-3{padding:1rem!important}.pt-xl-3,.py-xl-3{padding-top:1rem!important}.pr-xl-3,.px-xl-3{padding-right:1rem!important}.pb-xl-3,.py-xl-3{padding-bottom:1rem!important}.pl-xl-3,.px-xl-3{padding-left:1rem!important}.p-xl-4{padding:1.5rem!important}.pt-xl-4,.py-xl-4{padding-top:1.5rem!important}.pr-xl-4,.px-xl-4{padding-right:1.5rem!important}.pb-xl-4,.py-xl-4{padding-bottom:1.5rem!important}.pl-xl-4,.px-xl-4{padding-left:1.5rem!important}.p-xl-5{padding:3rem!important}.pt-xl-5,.py-xl-5{padding-top:3rem!important}.pr-xl-5,.px-xl-5{padding-right:3rem!important}.pb-xl-5,.py-xl-5{padding-bottom:3rem!important}.pl-xl-5,.px-xl-5{padding-left:3rem!important}.m-xl-auto{margin:auto!important}.mt-xl-auto,.my-xl-auto{margin-top:auto!important}.mr-xl-auto,.mx-xl-auto{margin-right:auto!important}.mb-xl-auto,.my-xl-auto{margin-bottom:auto!important}.ml-xl-auto,.mx-xl-auto{margin-left:auto!important}.text-xl-left{text-align:left!important}.text-xl-right{text-align:right!important}.text-xl-center{text-align:center!important}}.text-lowercase{text-transform:lowercase!important}.text-uppercase{text-transform:uppercase!important}.text-capitalize{text-transform:capitalize!important}.font-weight-light{font-weight:300!important}.font-weight-normal{font-weight:400!important}.font-weight-bold{font-weight:700!important}.font-italic{font-style:italic!important}.text-white{color:#fff!important}.text-primary{color:#007bff!important}a.text-primary:focus,a.text-primary:hover{color:#0062cc!important}.text-secondary{color:#6c757d!important}a.text-secondary:focus,a.text-secondary:hover{color:#545b62!important}.text-success{color:#28a745!important}a.text-success:focus,a.text-success:hover{color:#1e7e34!important}.text-info{color:#17a2b8!important}a.text-info:focus,a.text-info:hover{color:#117a8b!important}.text-warning{color:#ffc107!important}a.text-warning:focus,a.text-warning:hover{color:#d39e00!important}.text-danger{color:#dc3545!important}a.text-danger:focus,a.text-danger:hover{color:#bd2130!important}.text-light{color:#f8f9fa!important}a.text-light:focus,a.text-light:hover{color:#dae0e5!important}.text-dark{color:#343a40!important}a.text-dark:focus,a.text-dark:hover{color:#1d2124!important}.text-body{color:#212529!important}.text-muted{color:#6c757d!important}.text-black-50{color:rgba(0,0,0,.5)!important}.text-white-50{color:rgba(255,255,255,.5)!important}.text-hide{font:0/0 a;color:transparent;text-shadow:none;background-color:transparent;border:0}.visible{visibility:visible!important}.invisible{visibility:hidden!important}\@media print{*,::after,::before{text-shadow:none!important;-webkit-box-shadow:none!important;box-shadow:none!important}a:not(.btn){text-decoration:underline}abbr[title]::after{content:\" (\" attr(title) \")\"}pre{white-space:pre-wrap!important}blockquote,pre{border:1px solid #adb5bd;page-break-inside:avoid}thead{display:table-header-group}img,tr{page-break-inside:avoid}h2,h3,p{orphans:3;widows:3}h2,h3{page-break-after:avoid}\@page{size:a3}.container,body{min-width:992px!important}.navbar{display:none}.badge{border:1px solid #000}.table{border-collapse:collapse!important}.table td,.table th{background-color:#fff!important}.table-bordered td,.table-bordered th{border:1px solid #dee2e6!important}.table-dark{color:inherit}.table-dark tbody+tbody,.table-dark td,.table-dark th,.table-dark thead th{border-color:#dee2e6}.table .thead-dark th{color:inherit;border-color:#dee2e6}}/*!\n *  Font Awesome 4.7.0 by \@davegandy - http://fontawesome.io - \@fontawesome\n *  License - http://fontawesome.io/license (Font: SIL OFL 1.1, CSS: MIT License)\n */\@font-face{font-family:FontAwesome;src:url(bootstrap/font-awesome/fonts/fontawesome-webfont.eot?v=4.7.0);src:url(bootstrap/font-awesome/fonts/fontawesome-webfont.eot?#iefix&v=4.7.0) format(\"embedded-opentype\"),url(bootstrap/font-awesome/fonts/fontawesome-webfont.woff2?v=4.7.0) format(\"woff2\"),url(bootstrap/font-awesome/fonts/fontawesome-webfont.woff?v=4.7.0) format(\"woff\"),url(bootstrap/font-awesome/fonts/fontawesome-webfont.ttf?v=4.7.0) format(\"truetype\"),url(bootstrap/font-awesome/fonts/fontawesome-webfont.svg?v=4.7.0#fontawesomeregular) format(\"svg\");font-weight:400;font-style:normal}.fa{display:inline-block;font:14px/1 FontAwesome;font-size:inherit;text-rendering:auto;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale}.fa-lg{font-size:1.33333em;line-height:.75em;vertical-align:-15%}.fa-2x{font-size:2em}.fa-3x{font-size:3em}.fa-4x{font-size:4em}.fa-5x{font-size:5em}.fa-fw{width:1.28571em;text-align:center}.fa-ul{padding-left:0;margin-left:2.14286em;list-style-type:none}.fa-ul>li{position:relative}.fa-li{position:absolute;left:-2.14286em;width:2.14286em;top:.14286em;text-align:center}.fa-li.fa-lg{left:-1.85714em}.fa-border{padding:.2em .25em .15em;border:.08em solid #eee;border-radius:.1em}.fa-pull-left{float:left}.fa-pull-right{float:right}.fa.fa-pull-left{margin-right:.3em}.fa.fa-pull-right{margin-left:.3em}.pull-right{float:right}.pull-left{float:left}.fa.pull-left{margin-right:.3em}.fa.pull-right{margin-left:.3em}.fa-spin{-webkit-animation:2s linear infinite fa-spin;animation:2s linear infinite fa-spin}.fa-pulse{-webkit-animation:1s steps(8) infinite fa-spin;animation:1s steps(8) infinite fa-spin}\@-webkit-keyframes fa-spin{0%{-webkit-transform:rotate(0);transform:rotate(0)}100%{-webkit-transform:rotate(359deg);transform:rotate(359deg)}}\@keyframes fa-spin{0%{-webkit-transform:rotate(0);transform:rotate(0)}100%{-webkit-transform:rotate(359deg);transform:rotate(359deg)}}.fa-rotate-90{-webkit-transform:rotate(90deg);-ms-transform:rotate(90deg);transform:rotate(90deg)}.fa-rotate-180{-webkit-transform:rotate(180deg);-ms-transform:rotate(180deg);transform:rotate(180deg)}.fa-rotate-270{-webkit-transform:rotate(270deg);-ms-transform:rotate(270deg);transform:rotate(270deg)}.fa-flip-horizontal{-webkit-transform:scale(-1,1);-ms-transform:scale(-1,1);transform:scale(-1,1)}.fa-flip-vertical{-webkit-transform:scale(1,-1);-ms-transform:scale(1,-1);transform:scale(1,-1)}:root .fa-flip-horizontal,:root .fa-flip-vertical,:root .fa-rotate-180,:root .fa-rotate-270,:root .fa-rotate-90{-webkit-filter:none;filter:none}.fa-stack{position:relative;display:inline-block;width:2em;height:2em;line-height:2em;vertical-align:middle}.fa-stack-1x,.fa-stack-2x{position:absolute;left:0;width:100%;text-align:center}.fa-stack-1x{line-height:inherit}.fa-stack-2x{font-size:2em}.fa-inverse{color:#fff}.fa-glass:before{content:\"\"}.fa-music:before{content:\"\"}.fa-search:before{content:\"\"}.fa-envelope-o:before{content:\"\"}.fa-heart:before{content:\"\"}.fa-star:before{content:\"\"}.fa-star-o:before{content:\"\"}.fa-user:before{content:\"\"}.fa-film:before{content:\"\"}.fa-th-large:before{content:\"\"}.fa-th:before{content:\"\"}.fa-th-list:before{content:\"\"}.fa-check:before{content:\"\"}.fa-close:before,.fa-remove:before,.fa-times:before{content:\"\"}.fa-search-plus:before{content:\"\"}.fa-search-minus:before{content:\"\"}.fa-power-off:before{content:\"\"}.fa-signal:before{content:\"\"}.fa-cog:before,.fa-gear:before{content:\"\"}.fa-trash-o:before{content:\"\"}.fa-home:before{content:\"\"}.fa-file-o:before{content:\"\"}.fa-clock-o:before{content:\"\"}.fa-road:before{content:\"\"}.fa-download:before{content:\"\"}.fa-arrow-circle-o-down:before{content:\"\"}.fa-arrow-circle-o-up:before{content:\"\"}.fa-inbox:before{content:\"\"}.fa-play-circle-o:before{content:\"\"}.fa-repeat:before,.fa-rotate-right:before{content:\"\"}.fa-refresh:before{content:\"\"}.fa-list-alt:before{content:\"\"}.fa-lock:before{content:\"\"}.fa-flag:before{content:\"\"}.fa-headphones:before{content:\"\"}.fa-volume-off:before{content:\"\"}.fa-volume-down:before{content:\"\"}.fa-volume-up:before{content:\"\"}.fa-qrcode:before{content:\"\"}.fa-barcode:before{content:\"\"}.fa-tag:before{content:\"\"}.fa-tags:before{content:\"\"}.fa-book:before{content:\"\"}.fa-bookmark:before{content:\"\"}.fa-print:before{content:\"\"}.fa-camera:before{content:\"\"}.fa-font:before{content:\"\"}.fa-bold:before{content:\"\"}.fa-italic:before{content:\"\"}.fa-text-height:before{content:\"\"}.fa-text-width:before{content:\"\"}.fa-align-left:before{content:\"\"}.fa-align-center:before{content:\"\"}.fa-align-right:before{content:\"\"}.fa-align-justify:before{content:\"\"}.fa-list:before{content:\"\"}.fa-dedent:before,.fa-outdent:before{content:\"\"}.fa-indent:before{content:\"\"}.fa-video-camera:before{content:\"\"}.fa-image:before,.fa-photo:before,.fa-picture-o:before{content:\"\"}.fa-pencil:before{content:\"\"}.fa-map-marker:before{content:\"\"}.fa-adjust:before{content:\"\"}.fa-tint:before{content:\"\"}.fa-edit:before,.fa-pencil-square-o:before{content:\"\"}.fa-share-square-o:before{content:\"\"}.fa-check-square-o:before{content:\"\"}.fa-arrows:before{content:\"\"}.fa-step-backward:before{content:\"\"}.fa-fast-backward:before{content:\"\"}.fa-backward:before{content:\"\"}.fa-play:before{content:\"\"}.fa-pause:before{content:\"\"}.fa-stop:before{content:\"\"}.fa-forward:before{content:\"\"}.fa-fast-forward:before{content:\"\"}.fa-step-forward:before{content:\"\"}.fa-eject:before{content:\"\"}.fa-chevron-left:before{content:\"\"}.fa-chevron-right:before{content:\"\"}.fa-plus-circle:before{content:\"\"}.fa-minus-circle:before{content:\"\"}.fa-times-circle:before{content:\"\"}.fa-check-circle:before{content:\"\"}.fa-question-circle:before{content:\"\"}.fa-info-circle:before{content:\"\"}.fa-crosshairs:before{content:\"\"}.fa-times-circle-o:before{content:\"\"}.fa-check-circle-o:before{content:\"\"}.fa-ban:before{content:\"\"}.fa-arrow-left:before{content:\"\"}.fa-arrow-right:before{content:\"\"}.fa-arrow-up:before{content:\"\"}.fa-arrow-down:before{content:\"\"}.fa-mail-forward:before,.fa-share:before{content:\"\"}.fa-expand:before{content:\"\"}.fa-compress:before{content:\"\"}.fa-plus:before{content:\"\"}.fa-minus:before{content:\"\"}.fa-asterisk:before{content:\"\"}.fa-exclamation-circle:before{content:\"\"}.fa-gift:before{content:\"\"}.fa-leaf:before{content:\"\"}.fa-fire:before{content:\"\"}.fa-eye:before{content:\"\"}.fa-eye-slash:before{content:\"\"}.fa-exclamation-triangle:before,.fa-warning:before{content:\"\"}.fa-plane:before{content:\"\"}.fa-calendar:before{content:\"\"}.fa-random:before{content:\"\"}.fa-comment:before{content:\"\"}.fa-magnet:before{content:\"\"}.fa-chevron-up:before{content:\"\"}.fa-chevron-down:before{content:\"\"}.fa-retweet:before{content:\"\"}.fa-shopping-cart:before{content:\"\"}.fa-folder:before{content:\"\"}.fa-folder-open:before{content:\"\"}.fa-arrows-v:before{content:\"\"}.fa-arrows-h:before{content:\"\"}.fa-bar-chart-o:before,.fa-bar-chart:before{content:\"\"}.fa-twitter-square:before{content:\"\"}.fa-facebook-square:before{content:\"\"}.fa-camera-retro:before{content:\"\"}.fa-key:before{content:\"\"}.fa-cogs:before,.fa-gears:before{content:\"\"}.fa-comments:before{content:\"\"}.fa-thumbs-o-up:before{content:\"\"}.fa-thumbs-o-down:before{content:\"\"}.fa-star-half:before{content:\"\"}.fa-heart-o:before{content:\"\"}.fa-sign-out:before{content:\"\"}.fa-linkedin-square:before{content:\"\"}.fa-thumb-tack:before{content:\"\"}.fa-external-link:before{content:\"\"}.fa-sign-in:before{content:\"\"}.fa-trophy:before{content:\"\"}.fa-github-square:before{content:\"\"}.fa-upload:before{content:\"\"}.fa-lemon-o:before{content:\"\"}.fa-phone:before{content:\"\"}.fa-square-o:before{content:\"\"}.fa-bookmark-o:before{content:\"\"}.fa-phone-square:before{content:\"\"}.fa-twitter:before{content:\"\"}.fa-facebook-f:before,.fa-facebook:before{content:\"\"}.fa-github:before{content:\"\"}.fa-unlock:before{content:\"\"}.fa-credit-card:before{content:\"\"}.fa-feed:before,.fa-rss:before{content:\"\"}.fa-hdd-o:before{content:\"\"}.fa-bullhorn:before{content:\"\"}.fa-bell:before{content:\"\"}.fa-certificate:before{content:\"\"}.fa-hand-o-right:before{content:\"\"}.fa-hand-o-left:before{content:\"\"}.fa-hand-o-up:before{content:\"\"}.fa-hand-o-down:before{content:\"\"}.fa-arrow-circle-left:before{content:\"\"}.fa-arrow-circle-right:before{content:\"\"}.fa-arrow-circle-up:before{content:\"\"}.fa-arrow-circle-down:before{content:\"\"}.fa-globe:before{content:\"\"}.fa-wrench:before{content:\"\"}.fa-tasks:before{content:\"\"}.fa-filter:before{content:\"\"}.fa-briefcase:before{content:\"\"}.fa-arrows-alt:before{content:\"\"}.fa-group:before,.fa-users:before{content:\"\"}.fa-chain:before,.fa-link:before{content:\"\"}.fa-cloud:before{content:\"\"}.fa-flask:before{content:\"\"}.fa-cut:before,.fa-scissors:before{content:\"\"}.fa-copy:before,.fa-files-o:before{content:\"\"}.fa-paperclip:before{content:\"\"}.fa-floppy-o:before,.fa-save:before{content:\"\"}.fa-square:before{content:\"\"}.fa-bars:before,.fa-navicon:before,.fa-reorder:before{content:\"\"}.fa-list-ul:before{content:\"\"}.fa-list-ol:before{content:\"\"}.fa-strikethrough:before{content:\"\"}.fa-underline:before{content:\"\"}.fa-table:before{content:\"\"}.fa-magic:before{content:\"\"}.fa-truck:before{content:\"\"}.fa-pinterest:before{content:\"\"}.fa-pinterest-square:before{content:\"\"}.fa-google-plus-square:before{content:\"\"}.fa-google-plus:before{content:\"\"}.fa-money:before{content:\"\"}.fa-caret-down:before{content:\"\"}.fa-caret-up:before{content:\"\"}.fa-caret-left:before{content:\"\"}.fa-caret-right:before{content:\"\"}.fa-columns:before{content:\"\"}.fa-sort:before,.fa-unsorted:before{content:\"\"}.fa-sort-desc:before,.fa-sort-down:before{content:\"\"}.fa-sort-asc:before,.fa-sort-up:before{content:\"\"}.fa-envelope:before{content:\"\"}.fa-linkedin:before{content:\"\"}.fa-rotate-left:before,.fa-undo:before{content:\"\"}.fa-gavel:before,.fa-legal:before{content:\"\"}.fa-dashboard:before,.fa-tachometer:before{content:\"\"}.fa-comment-o:before{content:\"\"}.fa-comments-o:before{content:\"\"}.fa-bolt:before,.fa-flash:before{content:\"\"}.fa-sitemap:before{content:\"\"}.fa-umbrella:before{content:\"\"}.fa-clipboard:before,.fa-paste:before{content:\"\"}.fa-lightbulb-o:before{content:\"\"}.fa-exchange:before{content:\"\"}.fa-cloud-download:before{content:\"\"}.fa-cloud-upload:before{content:\"\"}.fa-user-md:before{content:\"\"}.fa-stethoscope:before{content:\"\"}.fa-suitcase:before{content:\"\"}.fa-bell-o:before{content:\"\"}.fa-coffee:before{content:\"\"}.fa-cutlery:before{content:\"\"}.fa-file-text-o:before{content:\"\"}.fa-building-o:before{content:\"\"}.fa-hospital-o:before{content:\"\"}.fa-ambulance:before{content:\"\"}.fa-medkit:before{content:\"\"}.fa-fighter-jet:before{content:\"\"}.fa-beer:before{content:\"\"}.fa-h-square:before{content:\"\"}.fa-plus-square:before{content:\"\"}.fa-angle-double-left:before{content:\"\"}.fa-angle-double-right:before{content:\"\"}.fa-angle-double-up:before{content:\"\"}.fa-angle-double-down:before{content:\"\"}.fa-angle-left:before{content:\"\"}.fa-angle-right:before{content:\"\"}.fa-angle-up:before{content:\"\"}.fa-angle-down:before{content:\"\"}.fa-desktop:before{content:\"\"}.fa-laptop:before{content:\"\"}.fa-tablet:before{content:\"\"}.fa-mobile-phone:before,.fa-mobile:before{content:\"\"}.fa-circle-o:before{content:\"\"}.fa-quote-left:before{content:\"\"}.fa-quote-right:before{content:\"\"}.fa-spinner:before{content:\"\"}.fa-circle:before{content:\"\"}.fa-mail-reply:before,.fa-reply:before{content:\"\"}.fa-github-alt:before{content:\"\"}.fa-folder-o:before{content:\"\"}.fa-folder-open-o:before{content:\"\"}.fa-smile-o:before{content:\"\"}.fa-frown-o:before{content:\"\"}.fa-meh-o:before{content:\"\"}.fa-gamepad:before{content:\"\"}.fa-keyboard-o:before{content:\"\"}.fa-flag-o:before{content:\"\"}.fa-flag-checkered:before{content:\"\"}.fa-terminal:before{content:\"\"}.fa-code:before{content:\"\"}.fa-mail-reply-all:before,.fa-reply-all:before{content:\"\"}.fa-star-half-empty:before,.fa-star-half-full:before,.fa-star-half-o:before{content:\"\"}.fa-location-arrow:before{content:\"\"}.fa-crop:before{content:\"\"}.fa-code-fork:before{content:\"\"}.fa-chain-broken:before,.fa-unlink:before{content:\"\"}.fa-question:before{content:\"\"}.fa-info:before{content:\"\"}.fa-exclamation:before{content:\"\"}.fa-superscript:before{content:\"\"}.fa-subscript:before{content:\"\"}.fa-eraser:before{content:\"\"}.fa-puzzle-piece:before{content:\"\"}.fa-microphone:before{content:\"\"}.fa-microphone-slash:before{content:\"\"}.fa-shield:before{content:\"\"}.fa-calendar-o:before{content:\"\"}.fa-fire-extinguisher:before{content:\"\"}.fa-rocket:before{content:\"\"}.fa-maxcdn:before{content:\"\"}.fa-chevron-circle-left:before{content:\"\"}.fa-chevron-circle-right:before{content:\"\"}.fa-chevron-circle-up:before{content:\"\"}.fa-chevron-circle-down:before{content:\"\"}.fa-html5:before{content:\"\"}.fa-css3:before{content:\"\"}.fa-anchor:before{content:\"\"}.fa-unlock-alt:before{content:\"\"}.fa-bullseye:before{content:\"\"}.fa-ellipsis-h:before{content:\"\"}.fa-ellipsis-v:before{content:\"\"}.fa-rss-square:before{content:\"\"}.fa-play-circle:before{content:\"\"}.fa-ticket:before{content:\"\"}.fa-minus-square:before{content:\"\"}.fa-minus-square-o:before{content:\"\"}.fa-level-up:before{content:\"\"}.fa-level-down:before{content:\"\"}.fa-check-square:before{content:\"\"}.fa-pencil-square:before{content:\"\"}.fa-external-link-square:before{content:\"\"}.fa-share-square:before{content:\"\"}.fa-compass:before{content:\"\"}.fa-caret-square-o-down:before,.fa-toggle-down:before{content:\"\"}.fa-caret-square-o-up:before,.fa-toggle-up:before{content:\"\"}.fa-caret-square-o-right:before,.fa-toggle-right:before{content:\"\"}.fa-eur:before,.fa-euro:before{content:\"\"}.fa-gbp:before{content:\"\"}.fa-dollar:before,.fa-usd:before{content:\"\"}.fa-inr:before,.fa-rupee:before{content:\"\"}.fa-cny:before,.fa-jpy:before,.fa-rmb:before,.fa-yen:before{content:\"\"}.fa-rouble:before,.fa-rub:before,.fa-ruble:before{content:\"\"}.fa-krw:before,.fa-won:before{content:\"\"}.fa-bitcoin:before,.fa-btc:before{content:\"\"}.fa-file:before{content:\"\"}.fa-file-text:before{content:\"\"}.fa-sort-alpha-asc:before{content:\"\"}.fa-sort-alpha-desc:before{content:\"\"}.fa-sort-amount-asc:before{content:\"\"}.fa-sort-amount-desc:before{content:\"\"}.fa-sort-numeric-asc:before{content:\"\"}.fa-sort-numeric-desc:before{content:\"\"}.fa-thumbs-up:before{content:\"\"}.fa-thumbs-down:before{content:\"\"}.fa-youtube-square:before{content:\"\"}.fa-youtube:before{content:\"\"}.fa-xing:before{content:\"\"}.fa-xing-square:before{content:\"\"}.fa-youtube-play:before{content:\"\"}.fa-dropbox:before{content:\"\"}.fa-stack-overflow:before{content:\"\"}.fa-instagram:before{content:\"\"}.fa-flickr:before{content:\"\"}.fa-adn:before{content:\"\"}.fa-bitbucket:before{content:\"\"}.fa-bitbucket-square:before{content:\"\"}.fa-tumblr:before{content:\"\"}.fa-tumblr-square:before{content:\"\"}.fa-long-arrow-down:before{content:\"\"}.fa-long-arrow-up:before{content:\"\"}.fa-long-arrow-left:before{content:\"\"}.fa-long-arrow-right:before{content:\"\"}.fa-apple:before{content:\"\"}.fa-windows:before{content:\"\"}.fa-android:before{content:\"\"}.fa-linux:before{content:\"\"}.fa-dribbble:before{content:\"\"}.fa-skype:before{content:\"\"}.fa-foursquare:before{content:\"\"}.fa-trello:before{content:\"\"}.fa-female:before{content:\"\"}.fa-male:before{content:\"\"}.fa-gittip:before,.fa-gratipay:before{content:\"\"}.fa-sun-o:before{content:\"\"}.fa-moon-o:before{content:\"\"}.fa-archive:before{content:\"\"}.fa-bug:before{content:\"\"}.fa-vk:before{content:\"\"}.fa-weibo:before{content:\"\"}.fa-renren:before{content:\"\"}.fa-pagelines:before{content:\"\"}.fa-stack-exchange:before{content:\"\"}.fa-arrow-circle-o-right:before{content:\"\"}.fa-arrow-circle-o-left:before{content:\"\"}.fa-caret-square-o-left:before,.fa-toggle-left:before{content:\"\"}.fa-dot-circle-o:before{content:\"\"}.fa-wheelchair:before{content:\"\"}.fa-vimeo-square:before{content:\"\"}.fa-try:before,.fa-turkish-lira:before{content:\"\"}.fa-plus-square-o:before{content:\"\"}.fa-space-shuttle:before{content:\"\"}.fa-slack:before{content:\"\"}.fa-envelope-square:before{content:\"\"}.fa-wordpress:before{content:\"\"}.fa-openid:before{content:\"\"}.fa-bank:before,.fa-institution:before,.fa-university:before{content:\"\"}.fa-graduation-cap:before,.fa-mortar-board:before{content:\"\"}.fa-yahoo:before{content:\"\"}.fa-google:before{content:\"\"}.fa-reddit:before{content:\"\"}.fa-reddit-square:before{content:\"\"}.fa-stumbleupon-circle:before{content:\"\"}.fa-stumbleupon:before{content:\"\"}.fa-delicious:before{content:\"\"}.fa-digg:before{content:\"\"}.fa-pied-piper-pp:before{content:\"\"}.fa-pied-piper-alt:before{content:\"\"}.fa-drupal:before{content:\"\"}.fa-joomla:before{content:\"\"}.fa-language:before{content:\"\"}.fa-fax:before{content:\"\"}.fa-building:before{content:\"\"}.fa-child:before{content:\"\"}.fa-paw:before{content:\"\"}.fa-spoon:before{content:\"\"}.fa-cube:before{content:\"\"}.fa-cubes:before{content:\"\"}.fa-behance:before{content:\"\"}.fa-behance-square:before{content:\"\"}.fa-steam:before{content:\"\"}.fa-steam-square:before{content:\"\"}.fa-recycle:before{content:\"\"}.fa-automobile:before,.fa-car:before{content:\"\"}.fa-cab:before,.fa-taxi:before{content:\"\"}.fa-tree:before{content:\"\"}.fa-spotify:before{content:\"\"}.fa-deviantart:before{content:\"\"}.fa-soundcloud:before{content:\"\"}.fa-database:before{content:\"\"}.fa-file-pdf-o:before{content:\"\"}.fa-file-word-o:before{content:\"\"}.fa-file-excel-o:before{content:\"\"}.fa-file-powerpoint-o:before{content:\"\"}.fa-file-image-o:before,.fa-file-photo-o:before,.fa-file-picture-o:before{content:\"\"}.fa-file-archive-o:before,.fa-file-zip-o:before{content:\"\"}.fa-file-audio-o:before,.fa-file-sound-o:before{content:\"\"}.fa-file-movie-o:before,.fa-file-video-o:before{content:\"\"}.fa-file-code-o:before{content:\"\"}.fa-vine:before{content:\"\"}.fa-codepen:before{content:\"\"}.fa-jsfiddle:before{content:\"\"}.fa-life-bouy:before,.fa-life-buoy:before,.fa-life-ring:before,.fa-life-saver:before,.fa-support:before{content:\"\"}.fa-circle-o-notch:before{content:\"\"}.fa-ra:before,.fa-rebel:before,.fa-resistance:before{content:\"\"}.fa-empire:before,.fa-ge:before{content:\"\"}.fa-git-square:before{content:\"\"}.fa-git:before{content:\"\"}.fa-hacker-news:before,.fa-y-combinator-square:before,.fa-yc-square:before{content:\"\"}.fa-tencent-weibo:before{content:\"\"}.fa-qq:before{content:\"\"}.fa-wechat:before,.fa-weixin:before{content:\"\"}.fa-paper-plane:before,.fa-send:before{content:\"\"}.fa-paper-plane-o:before,.fa-send-o:before{content:\"\"}.fa-history:before{content:\"\"}.fa-circle-thin:before{content:\"\"}.fa-header:before{content:\"\"}.fa-paragraph:before{content:\"\"}.fa-sliders:before{content:\"\"}.fa-share-alt:before{content:\"\"}.fa-share-alt-square:before{content:\"\"}.fa-bomb:before{content:\"\"}.fa-futbol-o:before,.fa-soccer-ball-o:before{content:\"\"}.fa-tty:before{content:\"\"}.fa-binoculars:before{content:\"\"}.fa-plug:before{content:\"\"}.fa-slideshare:before{content:\"\"}.fa-twitch:before{content:\"\"}.fa-yelp:before{content:\"\"}.fa-newspaper-o:before{content:\"\"}.fa-wifi:before{content:\"\"}.fa-calculator:before{content:\"\"}.fa-paypal:before{content:\"\"}.fa-google-wallet:before{content:\"\"}.fa-cc-visa:before{content:\"\"}.fa-cc-mastercard:before{content:\"\"}.fa-cc-discover:before{content:\"\"}.fa-cc-amex:before{content:\"\"}.fa-cc-paypal:before{content:\"\"}.fa-cc-stripe:before{content:\"\"}.fa-bell-slash:before{content:\"\"}.fa-bell-slash-o:before{content:\"\"}.fa-trash:before{content:\"\"}.fa-copyright:before{content:\"\"}.fa-at:before{content:\"\"}.fa-eyedropper:before{content:\"\"}.fa-paint-brush:before{content:\"\"}.fa-birthday-cake:before{content:\"\"}.fa-area-chart:before{content:\"\"}.fa-pie-chart:before{content:\"\"}.fa-line-chart:before{content:\"\"}.fa-lastfm:before{content:\"\"}.fa-lastfm-square:before{content:\"\"}.fa-toggle-off:before{content:\"\"}.fa-toggle-on:before{content:\"\"}.fa-bicycle:before{content:\"\"}.fa-bus:before{content:\"\"}.fa-ioxhost:before{content:\"\"}.fa-angellist:before{content:\"\"}.fa-cc:before{content:\"\"}.fa-ils:before,.fa-shekel:before,.fa-sheqel:before{content:\"\"}.fa-meanpath:before{content:\"\"}.fa-buysellads:before{content:\"\"}.fa-connectdevelop:before{content:\"\"}.fa-dashcube:before{content:\"\"}.fa-forumbee:before{content:\"\"}.fa-leanpub:before{content:\"\"}.fa-sellsy:before{content:\"\"}.fa-shirtsinbulk:before{content:\"\"}.fa-simplybuilt:before{content:\"\"}.fa-skyatlas:before{content:\"\"}.fa-cart-plus:before{content:\"\"}.fa-cart-arrow-down:before{content:\"\"}.fa-diamond:before{content:\"\"}.fa-ship:before{content:\"\"}.fa-user-secret:before{content:\"\"}.fa-motorcycle:before{content:\"\"}.fa-street-view:before{content:\"\"}.fa-heartbeat:before{content:\"\"}.fa-venus:before{content:\"\"}.fa-mars:before{content:\"\"}.fa-mercury:before{content:\"\"}.fa-intersex:before,.fa-transgender:before{content:\"\"}.fa-transgender-alt:before{content:\"\"}.fa-venus-double:before{content:\"\"}.fa-mars-double:before{content:\"\"}.fa-venus-mars:before{content:\"\"}.fa-mars-stroke:before{content:\"\"}.fa-mars-stroke-v:before{content:\"\"}.fa-mars-stroke-h:before{content:\"\"}.fa-neuter:before{content:\"\"}.fa-genderless:before{content:\"\"}.fa-facebook-official:before{content:\"\"}.fa-pinterest-p:before{content:\"\"}.fa-whatsapp:before{content:\"\"}.fa-server:before{content:\"\"}.fa-user-plus:before{content:\"\"}.fa-user-times:before{content:\"\"}.fa-bed:before,.fa-hotel:before{content:\"\"}.fa-viacoin:before{content:\"\"}.fa-train:before{content:\"\"}.fa-subway:before{content:\"\"}.fa-medium:before{content:\"\"}.fa-y-combinator:before,.fa-yc:before{content:\"\"}.fa-optin-monster:before{content:\"\"}.fa-opencart:before{content:\"\"}.fa-expeditedssl:before{content:\"\"}.fa-battery-4:before,.fa-battery-full:before,.fa-battery:before{content:\"\"}.fa-battery-3:before,.fa-battery-three-quarters:before{content:\"\"}.fa-battery-2:before,.fa-battery-half:before{content:\"\"}.fa-battery-1:before,.fa-battery-quarter:before{content:\"\"}.fa-battery-0:before,.fa-battery-empty:before{content:\"\"}.fa-mouse-pointer:before{content:\"\"}.fa-i-cursor:before{content:\"\"}.fa-object-group:before{content:\"\"}.fa-object-ungroup:before{content:\"\"}.fa-sticky-note:before{content:\"\"}.fa-sticky-note-o:before{content:\"\"}.fa-cc-jcb:before{content:\"\"}.fa-cc-diners-club:before{content:\"\"}.fa-clone:before{content:\"\"}.fa-balance-scale:before{content:\"\"}.fa-hourglass-o:before{content:\"\"}.fa-hourglass-1:before,.fa-hourglass-start:before{content:\"\"}.fa-hourglass-2:before,.fa-hourglass-half:before{content:\"\"}.fa-hourglass-3:before,.fa-hourglass-end:before{content:\"\"}.fa-hourglass:before{content:\"\"}.fa-hand-grab-o:before,.fa-hand-rock-o:before{content:\"\"}.fa-hand-paper-o:before,.fa-hand-stop-o:before{content:\"\"}.fa-hand-scissors-o:before{content:\"\"}.fa-hand-lizard-o:before{content:\"\"}.fa-hand-spock-o:before{content:\"\"}.fa-hand-pointer-o:before{content:\"\"}.fa-hand-peace-o:before{content:\"\"}.fa-trademark:before{content:\"\"}.fa-registered:before{content:\"\"}.fa-creative-commons:before{content:\"\"}.fa-gg:before{content:\"\"}.fa-gg-circle:before{content:\"\"}.fa-tripadvisor:before{content:\"\"}.fa-odnoklassniki:before{content:\"\"}.fa-odnoklassniki-square:before{content:\"\"}.fa-get-pocket:before{content:\"\"}.fa-wikipedia-w:before{content:\"\"}.fa-safari:before{content:\"\"}.fa-chrome:before{content:\"\"}.fa-firefox:before{content:\"\"}.fa-opera:before{content:\"\"}.fa-internet-explorer:before{content:\"\"}.fa-television:before,.fa-tv:before{content:\"\"}.fa-contao:before{content:\"\"}.fa-500px:before{content:\"\"}.fa-amazon:before{content:\"\"}.fa-calendar-plus-o:before{content:\"\"}.fa-calendar-minus-o:before{content:\"\"}.fa-calendar-times-o:before{content:\"\"}.fa-calendar-check-o:before{content:\"\"}.fa-industry:before{content:\"\"}.fa-map-pin:before{content:\"\"}.fa-map-signs:before{content:\"\"}.fa-map-o:before{content:\"\"}.fa-map:before{content:\"\"}.fa-commenting:before{content:\"\"}.fa-commenting-o:before{content:\"\"}.fa-houzz:before{content:\"\"}.fa-vimeo:before{content:\"\"}.fa-black-tie:before{content:\"\"}.fa-fonticons:before{content:\"\"}.fa-reddit-alien:before{content:\"\"}.fa-edge:before{content:\"\"}.fa-credit-card-alt:before{content:\"\"}.fa-codiepie:before{content:\"\"}.fa-modx:before{content:\"\"}.fa-fort-awesome:before{content:\"\"}.fa-usb:before{content:\"\"}.fa-product-hunt:before{content:\"\"}.fa-mixcloud:before{content:\"\"}.fa-scribd:before{content:\"\"}.fa-pause-circle:before{content:\"\"}.fa-pause-circle-o:before{content:\"\"}.fa-stop-circle:before{content:\"\"}.fa-stop-circle-o:before{content:\"\"}.fa-shopping-bag:before{content:\"\"}.fa-shopping-basket:before{content:\"\"}.fa-hashtag:before{content:\"\"}.fa-bluetooth:before{content:\"\"}.fa-bluetooth-b:before{content:\"\"}.fa-percent:before{content:\"\"}.fa-gitlab:before{content:\"\"}.fa-wpbeginner:before{content:\"\"}.fa-wpforms:before{content:\"\"}.fa-envira:before{content:\"\"}.fa-universal-access:before{content:\"\"}.fa-wheelchair-alt:before{content:\"\"}.fa-question-circle-o:before{content:\"\"}.fa-blind:before{content:\"\"}.fa-audio-description:before{content:\"\"}.fa-volume-control-phone:before{content:\"\"}.fa-braille:before{content:\"\"}.fa-assistive-listening-systems:before{content:\"\"}.fa-american-sign-language-interpreting:before,.fa-asl-interpreting:before{content:\"\"}.fa-deaf:before,.fa-deafness:before,.fa-hard-of-hearing:before{content:\"\"}.fa-glide:before{content:\"\"}.fa-glide-g:before{content:\"\"}.fa-sign-language:before,.fa-signing:before{content:\"\"}.fa-low-vision:before{content:\"\"}.fa-viadeo:before{content:\"\"}.fa-viadeo-square:before{content:\"\"}.fa-snapchat:before{content:\"\"}.fa-snapchat-ghost:before{content:\"\"}.fa-snapchat-square:before{content:\"\"}.fa-pied-piper:before{content:\"\"}.fa-first-order:before{content:\"\"}.fa-yoast:before{content:\"\"}.fa-themeisle:before{content:\"\"}.fa-google-plus-circle:before,.fa-google-plus-official:before{content:\"\"}.fa-fa:before,.fa-font-awesome:before{content:\"\"}.fa-handshake-o:before{content:\"\"}.fa-envelope-open:before{content:\"\"}.fa-envelope-open-o:before{content:\"\"}.fa-linode:before{content:\"\"}.fa-address-book:before{content:\"\"}.fa-address-book-o:before{content:\"\"}.fa-address-card:before,.fa-vcard:before{content:\"\"}.fa-address-card-o:before,.fa-vcard-o:before{content:\"\"}.fa-user-circle:before{content:\"\"}.fa-user-circle-o:before{content:\"\"}.fa-user-o:before{content:\"\"}.fa-id-badge:before{content:\"\"}.fa-drivers-license:before,.fa-id-card:before{content:\"\"}.fa-drivers-license-o:before,.fa-id-card-o:before{content:\"\"}.fa-quora:before{content:\"\"}.fa-free-code-camp:before{content:\"\"}.fa-telegram:before{content:\"\"}.fa-thermometer-4:before,.fa-thermometer-full:before,.fa-thermometer:before{content:\"\"}.fa-thermometer-3:before,.fa-thermometer-three-quarters:before{content:\"\"}.fa-thermometer-2:before,.fa-thermometer-half:before{content:\"\"}.fa-thermometer-1:before,.fa-thermometer-quarter:before{content:\"\"}.fa-thermometer-0:before,.fa-thermometer-empty:before{content:\"\"}.fa-shower:before{content:\"\"}.fa-bath:before,.fa-bathtub:before,.fa-s15:before{content:\"\"}.fa-podcast:before{content:\"\"}.fa-window-maximize:before{content:\"\"}.fa-window-minimize:before{content:\"\"}.fa-window-restore:before{content:\"\"}.fa-times-rectangle:before,.fa-window-close:before{content:\"\"}.fa-times-rectangle-o:before,.fa-window-close-o:before{content:\"\"}.fa-bandcamp:before{content:\"\"}.fa-grav:before{content:\"\"}.fa-etsy:before{content:\"\"}.fa-imdb:before{content:\"\"}.fa-ravelry:before{content:\"\"}.fa-eercast:before{content:\"\"}.fa-microchip:before{content:\"\"}.fa-snowflake-o:before{content:\"\"}.fa-superpowers:before{content:\"\"}.fa-wpexplorer:before{content:\"\"}.fa-meetup:before{content:\"\"}.sr-only{position:absolute;width:1px;height:1px;padding:0;margin:-1px;overflow:hidden;clip:rect(0,0,0,0);border:0}.sr-only-focusable:active,.sr-only-focusable:focus{clip:auto;white-space:normal;position:static;width:auto;height:auto;margin:0;overflow:visible;clip:auto}gx-card gx-button[slot=high-priority-action],gx-card gx-button[slot=normal-priority-action]{margin-right:5px}gx-card .gx-dropdown-toggle::after{content:\"\\2807\";padding-left:4px}gx-card .dropdown-menu [slot=low-priority-action]{display:block;width:100%;clear:both;border:0}gx-card{display:block}gx-card[hidden]{display:none}gx-card[hidden][invisible-mode=keep-space]{display:block;visibility:hidden}";
      },
      enumerable: !0,
      configurable: !0
    }), Card;
  }(/** @class */ function(e) {
    function class_1() {
      return null !== e && e.apply(this, arguments) || this;
    }
    return __extends(class_1, e), class_1.prototype.handleDropDownToggleClick = function(e) {
      var t = this, o = this.element.querySelector(".dropdown-menu");
      o.classList.toggle("show");
      var r = e.target;
      this.popper && this.popper.destroy(), this.popper = new O(r, o, {
        placement: "bottom-start"
      }), this.bodyClickHandler = function(e) {
        e.target !== r && o.classList.remove("show");
      }, setTimeout(function() {
        document.body.addEventListener("click", t.bodyClickHandler, {
          once: !0
        });
      }, 10);
    }, class_1.prototype.componentDidUnload = function() {
      this.bodyClickHandler && document.body.removeEventListener("click", this.bodyClickHandler), 
      this.popper && this.popper.destroy();
    }, class_1.prototype.componentDidLoad = function() {
      this.toggleHeaderFooterVisibility();
    }, class_1.prototype.componentDidUpdate = function() {
      this.toggleHeaderFooterVisibility();
    }, class_1.prototype.toggleHeaderFooterVisibility = function() {
      var e = this.element.querySelector(":scope > .card > .card-header"), t = this.element.querySelector(":scope > .card > .card-footer"), o = t ? Array.from(t.querySelectorAll("[slot='low-priority-action']")) : [], r = e ? Array.from(e.querySelectorAll("[slot='high-priority-action']")) : [], n = t ? Array.from(t.querySelectorAll("[slot='normal-priority-action']")) : [];
      r.concat(n).forEach(function(e) {
        return e.size = "small";
      }), o.forEach(function(e) {
        e.cssClass && e.cssClass.indexOf("dropdown-item") >= 0 || (e.cssClass = (e.cssClass || "") + " dropdown-item");
      });
      var i = o.length > 0 || n.length > 0, s = r.length > 0 || e && !!e.querySelector("[slot='header']"), a = i || t && !!t.querySelector("[slot='footer']");
      e && (e.hidden = !s), t && (t.hidden = !a);
    }, class_1.prototype.render = function() {
      var e = Array.from(this.element.querySelectorAll("[slot='low-priority-action']")), t = Array.from(this.element.querySelectorAll("[slot='high-priority-action']")), o = Array.from(this.element.querySelectorAll("[slot='normal-priority-action']"));
      t.concat(o).forEach(function(e) {
        return e.size = "small";
      }), e.forEach(function(e) {
        e.cssClass && e.cssClass.indexOf("dropdown-item") >= 0 || (e.cssClass = (e.cssClass || "") + " dropdown-item");
      });
      var n = e.length > 0, i = n || !!o, s = i || !!this.element.querySelector("[slot='footer']");
      return r("div", {
        class: "card"
      }, r("div", {
        class: "card-header"
      }, r("slot", {
        name: "header"
      }), r("div", {
        class: "float-right"
      }, r("slot", {
        name: "high-priority-action"
      }))), r("slot", {
        name: "body"
      }), r("slot", null), s && r("div", {
        class: "card-footer"
      }, r("slot", {
        name: "footer"
      }), i && r("div", {
        class: "float-right"
      }, r("slot", {
        name: "normal-priority-action"
      }), n && r("button", {
        class: "btn btn-sm gx-dropdown-toggle",
        type: "button",
        "aria-haspopup": "true",
        "aria-expanded": "false",
        "aria-label": "More actions",
        onClick: this.handleDropDownToggleClick.bind(this)
      }), n && r("div", {
        class: "dropdown-menu"
      }, r("slot", {
        name: "low-priority-action"
      })))));
    }, class_1;
  }(o.BaseComponent));
  e.GxCard = P, Object.defineProperty(e, "__esModule", {
    value: !0
  });
});