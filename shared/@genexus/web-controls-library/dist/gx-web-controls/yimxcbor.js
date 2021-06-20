/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: t} = window.GxWebControls;

import { a as e, b as i } from "./chunk-ee323282.js";

import { a as s } from "./chunk-e6709a3b.js";

var a = i(function(t) {
  var e, i;
  "undefined" != typeof navigator && (e = window || {}, i = function(t) {
    var e, i = "http://www.w3.org/2000/svg", s = "", a = -999999, r = !0, n = (/^((?!chrome|android).)*safari/i.test(navigator.userAgent), 
    Math.pow), o = Math.sqrt, h = Math.floor, l = Math.min, p = {};
    !function() {
      var t, e = Object.getOwnPropertyNames(Math), i = e.length;
      for (t = 0; t < i; t += 1) p[e[t]] = Math[e[t]];
    }(), p.random = Math.random, p.abs = function(t) {
      if ("object" == typeof t && t.length) {
        var e, i = createSizedArray(t.length), s = t.length;
        for (e = 0; e < s; e += 1) i[e] = Math.abs(t[e]);
        return i;
      }
      return Math.abs(t);
    };
    var f = 150, m = Math.PI / 180;
    function BMEnterFrameEvent(t, e, i, s) {
      this.type = t, this.currentTime = e, this.totalTime = i, this.direction = s < 0 ? -1 : 1;
    }
    function BMCompleteEvent(t, e) {
      this.type = t, this.direction = e < 0 ? -1 : 1;
    }
    function BMCompleteLoopEvent(t, e, i, s) {
      this.type = t, this.currentLoop = i, this.totalLoops = e, this.direction = s < 0 ? -1 : 1;
    }
    function BMSegmentStartEvent(t, e, i) {
      this.type = t, this.firstFrame = e, this.totalFrames = i;
    }
    function BMDestroyEvent(t, e) {
      this.type = t, this.target = e;
    }
    function randomString(t, e) {
      var i;
      void 0 === e && (e = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890");
      var s = "";
      for (i = t; i > 0; --i) s += e[Math.round(Math.random() * (e.length - 1))];
      return s;
    }
    function HSVtoRGB(t, e, i) {
      var s, a, r, n, o, h, l, p;
      switch (h = i * (1 - e), l = i * (1 - (o = 6 * t - (n = Math.floor(6 * t))) * e), 
      p = i * (1 - (1 - o) * e), n % 6) {
       case 0:
        s = i, a = p, r = h;
        break;

       case 1:
        s = l, a = i, r = h;
        break;

       case 2:
        s = h, a = i, r = p;
        break;

       case 3:
        s = h, a = l, r = i;
        break;

       case 4:
        s = p, a = h, r = i;
        break;

       case 5:
        s = i, a = h, r = l;
      }
      return [ s, a, r ];
    }
    function RGBtoHSV(t, e, i) {
      var s, a = Math.max(t, e, i), r = Math.min(t, e, i), n = a - r, o = 0 === a ? 0 : n / a, h = a / 255;
      switch (a) {
       case r:
        s = 0;
        break;

       case t:
        s = e - i + n * (e < i ? 6 : 0), s /= 6 * n;
        break;

       case e:
        s = i - t + 2 * n, s /= 6 * n;
        break;

       case i:
        s = t - e + 4 * n, s /= 6 * n;
      }
      return [ s, o, h ];
    }
    function addSaturationToRGB(t, e) {
      var i = RGBtoHSV(255 * t[0], 255 * t[1], 255 * t[2]);
      return i[1] += e, i[1] > 1 ? i[1] = 1 : i[1] <= 0 && (i[1] = 0), HSVtoRGB(i[0], i[1], i[2]);
    }
    function addBrightnessToRGB(t, e) {
      var i = RGBtoHSV(255 * t[0], 255 * t[1], 255 * t[2]);
      return i[2] += e, i[2] > 1 ? i[2] = 1 : i[2] < 0 && (i[2] = 0), HSVtoRGB(i[0], i[1], i[2]);
    }
    function addHueToRGB(t, e) {
      var i = RGBtoHSV(255 * t[0], 255 * t[1], 255 * t[2]);
      return i[0] += e / 360, i[0] > 1 ? i[0] -= 1 : i[0] < 0 && (i[0] += 1), HSVtoRGB(i[0], i[1], i[2]);
    }
    var d = function() {
      var t, e, i = [];
      for (t = 0; t < 256; t += 1) e = t.toString(16), i[t] = 1 == e.length ? "0" + e : e;
      return function(t, e, s) {
        return t < 0 && (t = 0), e < 0 && (e = 0), s < 0 && (s = 0), "#" + i[t] + i[e] + i[s];
      };
    }();
    function BaseEvent() {}
    BaseEvent.prototype = {
      triggerEvent: function(t, e) {
        if (this._cbs[t]) for (var i = this._cbs[t].length, s = 0; s < i; s++) this._cbs[t][s](e);
      },
      addEventListener: function(t, e) {
        return this._cbs[t] || (this._cbs[t] = []), this._cbs[t].push(e), function() {
          this.removeEventListener(t, e);
        }.bind(this);
      },
      removeEventListener: function(t, e) {
        if (e) {
          if (this._cbs[t]) {
            for (var i = 0, s = this._cbs[t].length; i < s; ) this._cbs[t][i] === e && (this._cbs[t].splice(i, 1), 
            i -= 1, s -= 1), i += 1;
            this._cbs[t].length || (this._cbs[t] = null);
          }
        } else this._cbs[t] = null;
      }
    };
    var c = "function" == typeof Uint8ClampedArray && "function" == typeof Float32Array ? function(t, e) {
      return "float32" === t ? new Float32Array(e) : "int16" === t ? new Int16Array(e) : "uint8c" === t ? new Uint8ClampedArray(e) : void 0;
    } : function(t, e) {
      var i, s = 0, a = [];
      switch (t) {
       case "int16":
       case "uint8c":
        i = 1;
        break;

       default:
        i = 1.1;
      }
      for (s = 0; s < e; s += 1) a.push(i);
      return a;
    };
    function createSizedArray(t) {
      return Array.apply(null, {
        length: t
      });
    }
    function createNS(t) {
      //return {appendChild:function(){},setAttribute:function(){},style:{}}
      return document.createElementNS(i, t);
    }
    function createTag(t) {
      //return {appendChild:function(){},setAttribute:function(){},style:{}}
      return document.createElement(t);
    }
    function DynamicPropertyContainer() {}
    DynamicPropertyContainer.prototype = {
      addDynamicProperty: function(t) {
        -1 === this.dynamicProperties.indexOf(t) && (this.dynamicProperties.push(t), this.container.addDynamicProperty(this), 
        this._isAnimated = !0);
      },
      iterateDynamicProperties: function() {
        this._mdf = !1;
        var t, e = this.dynamicProperties.length;
        for (t = 0; t < e; t += 1) this.dynamicProperties[t].getValue(), this.dynamicProperties[t]._mdf && (this._mdf = !0);
      },
      initDynamicPropertyContainer: function(t) {
        this.container = t, this.dynamicProperties = [], this._mdf = !1, this._isAnimated = !1;
      }
    };
    /*!
 Transformation Matrix v2.0
 (c) Epistemex 2014-2015
 www.epistemex.com
 By Ken Fyrstenberg
 Contributions by leeoniya.
 License: MIT, header required.
 */
    /**
 * 2D transformation matrix object initialized with identity matrix.
 *
 * The matrix can synchronize a canvas context by supplying the context
 * as an argument, or later apply current absolute transform to an
 * existing context.
 *
 * All values are handled as floating point values.
 *
 * @param {CanvasRenderingContext2D} [context] - Optional context to sync with Matrix
 * @prop {number} a - scale x
 * @prop {number} b - shear y
 * @prop {number} c - shear x
 * @prop {number} d - scale y
 * @prop {number} e - translate x
 * @prop {number} f - translate y
 * @prop {CanvasRenderingContext2D|null} [context=null] - set or get current canvas context
 * @constructor
 */
    var u = function() {
      var t = Math.cos, e = Math.sin, i = Math.tan, s = Math.round;
      function reset() {
        return this.props[0] = 1, this.props[1] = 0, this.props[2] = 0, this.props[3] = 0, 
        this.props[4] = 0, this.props[5] = 1, this.props[6] = 0, this.props[7] = 0, this.props[8] = 0, 
        this.props[9] = 0, this.props[10] = 1, this.props[11] = 0, this.props[12] = 0, this.props[13] = 0, 
        this.props[14] = 0, this.props[15] = 1, this;
      }
      function rotate(i) {
        if (0 === i) return this;
        var s = t(i), a = e(i);
        return this._t(s, -a, 0, 0, a, s, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
      }
      function rotateX(i) {
        if (0 === i) return this;
        var s = t(i), a = e(i);
        return this._t(1, 0, 0, 0, 0, s, -a, 0, 0, a, s, 0, 0, 0, 0, 1);
      }
      function rotateY(i) {
        if (0 === i) return this;
        var s = t(i), a = e(i);
        return this._t(s, 0, a, 0, 0, 1, 0, 0, -a, 0, s, 0, 0, 0, 0, 1);
      }
      function rotateZ(i) {
        if (0 === i) return this;
        var s = t(i), a = e(i);
        return this._t(s, -a, 0, 0, a, s, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
      }
      function shear(t, e) {
        return this._t(1, e, t, 1, 0, 0);
      }
      function skew(t, e) {
        return this.shear(i(t), i(e));
      }
      function skewFromAxis(s, a) {
        var r = t(a), n = e(a);
        return this._t(r, n, 0, 0, -n, r, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)._t(1, 0, 0, 0, i(s), 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)._t(r, -n, 0, 0, n, r, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        //return this._t(mCos, mSin, -mSin, mCos, 0, 0)._t(1, 0, _tan(ax), 1, 0, 0)._t(mCos, -mSin, mSin, mCos, 0, 0);
            }
      function scale(t, e, i) {
        return i = isNaN(i) ? 1 : i, 1 == t && 1 == e && 1 == i ? this : this._t(t, 0, 0, 0, 0, e, 0, 0, 0, 0, i, 0, 0, 0, 0, 1);
      }
      function setTransform(t, e, i, s, a, r, n, o, h, l, p, f, m, d, c, u) {
        return this.props[0] = t, this.props[1] = e, this.props[2] = i, this.props[3] = s, 
        this.props[4] = a, this.props[5] = r, this.props[6] = n, this.props[7] = o, this.props[8] = h, 
        this.props[9] = l, this.props[10] = p, this.props[11] = f, this.props[12] = m, this.props[13] = d, 
        this.props[14] = c, this.props[15] = u, this;
      }
      function translate(t, e, i) {
        return i = i || 0, 0 !== t || 0 !== e || 0 !== i ? this._t(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, t, e, i, 1) : this;
      }
      function transform(t, e, i, s, a, r, n, o, h, l, p, f, m, d, c, u) {
        var g = this.props;
        if (1 === t && 0 === e && 0 === i && 0 === s && 0 === a && 1 === r && 0 === n && 0 === o && 0 === h && 0 === l && 1 === p && 0 === f) 
        //NOTE: commenting this condition because TurboFan deoptimizes code when present
        //if(m2 !== 0 || n2 !== 0 || o2 !== 0){
        return g[12] = g[12] * t + g[15] * m, g[13] = g[13] * r + g[15] * d, g[14] = g[14] * p + g[15] * c, 
        g[15] = g[15] * u, 
        //}
        this._identityCalculated = !1, this;
        var y = g[0], v = g[1], S = g[2], b = g[3], P = g[4], _ = g[5], k = g[6], A = g[7], E = g[8], M = g[9], x = g[10], C = g[11], D = g[12], T = g[13], F = g[14], w = g[15];
        /* matrix order (canvas compatible):
         * ace
         * bdf
         * 001
         */
        return g[0] = y * t + v * a + S * h + b * m, g[1] = y * e + v * r + S * l + b * d, 
        g[2] = y * i + v * n + S * p + b * c, g[3] = y * s + v * o + S * f + b * u, g[4] = P * t + _ * a + k * h + A * m, 
        g[5] = P * e + _ * r + k * l + A * d, g[6] = P * i + _ * n + k * p + A * c, g[7] = P * s + _ * o + k * f + A * u, 
        g[8] = E * t + M * a + x * h + C * m, g[9] = E * e + M * r + x * l + C * d, g[10] = E * i + M * n + x * p + C * c, 
        g[11] = E * s + M * o + x * f + C * u, g[12] = D * t + T * a + F * h + w * m, g[13] = D * e + T * r + F * l + w * d, 
        g[14] = D * i + T * n + F * p + w * c, g[15] = D * s + T * o + F * f + w * u, this._identityCalculated = !1, 
        this;
      }
      function isIdentity() {
        return this._identityCalculated || (this._identity = !(1 !== this.props[0] || 0 !== this.props[1] || 0 !== this.props[2] || 0 !== this.props[3] || 0 !== this.props[4] || 1 !== this.props[5] || 0 !== this.props[6] || 0 !== this.props[7] || 0 !== this.props[8] || 0 !== this.props[9] || 1 !== this.props[10] || 0 !== this.props[11] || 0 !== this.props[12] || 0 !== this.props[13] || 0 !== this.props[14] || 1 !== this.props[15]), 
        this._identityCalculated = !0), this._identity;
      }
      function equals(t) {
        for (var e = 0; e < 16; ) {
          if (t.props[e] !== this.props[e]) return !1;
          e += 1;
        }
        return !0;
      }
      function clone(t) {
        var e;
        for (e = 0; e < 16; e += 1) t.props[e] = this.props[e];
      }
      function cloneFromProps(t) {
        var e;
        for (e = 0; e < 16; e += 1) this.props[e] = t[e];
      }
      function applyToPoint(t, e, i) {
        return {
          x: t * this.props[0] + e * this.props[4] + i * this.props[8] + this.props[12],
          y: t * this.props[1] + e * this.props[5] + i * this.props[9] + this.props[13],
          z: t * this.props[2] + e * this.props[6] + i * this.props[10] + this.props[14]
        };
        /*return {
         x: x * me.a + y * me.c + me.e,
         y: x * me.b + y * me.d + me.f
         };*/      }
      function applyToX(t, e, i) {
        return t * this.props[0] + e * this.props[4] + i * this.props[8] + this.props[12];
      }
      function applyToY(t, e, i) {
        return t * this.props[1] + e * this.props[5] + i * this.props[9] + this.props[13];
      }
      function applyToZ(t, e, i) {
        return t * this.props[2] + e * this.props[6] + i * this.props[10] + this.props[14];
      }
      function inversePoint(t) {
        var e = this.props[0] * this.props[5] - this.props[1] * this.props[4], i = this.props[5] / e, s = -this.props[1] / e, a = -this.props[4] / e, r = this.props[0] / e, n = (this.props[4] * this.props[13] - this.props[5] * this.props[12]) / e, o = -(this.props[0] * this.props[13] - this.props[1] * this.props[12]) / e;
        return [ t[0] * i + t[1] * a + n, t[0] * s + t[1] * r + o, 0 ];
      }
      function inversePoints(t) {
        var e, i = t.length, s = [];
        for (e = 0; e < i; e += 1) s[e] = inversePoint(t[e]);
        return s;
      }
      function applyToTriplePoints(t, e, i) {
        var s = c("float32", 6);
        if (this.isIdentity()) s[0] = t[0], s[1] = t[1], s[2] = e[0], s[3] = e[1], s[4] = i[0], 
        s[5] = i[1]; else {
          var a = this.props[0], r = this.props[1], n = this.props[4], o = this.props[5], h = this.props[12], l = this.props[13];
          s[0] = t[0] * a + t[1] * n + h, s[1] = t[0] * r + t[1] * o + l, s[2] = e[0] * a + e[1] * n + h, 
          s[3] = e[0] * r + e[1] * o + l, s[4] = i[0] * a + i[1] * n + h, s[5] = i[0] * r + i[1] * o + l;
        }
        return s;
      }
      function applyToPointArray(t, e, i) {
        return this.isIdentity() ? [ t, e, i ] : [ t * this.props[0] + e * this.props[4] + i * this.props[8] + this.props[12], t * this.props[1] + e * this.props[5] + i * this.props[9] + this.props[13], t * this.props[2] + e * this.props[6] + i * this.props[10] + this.props[14] ];
      }
      function applyToPointStringified(t, e) {
        if (this.isIdentity()) return t + "," + e;
        var i = this.props;
        return Math.round(100 * (t * i[0] + e * i[4] + i[12])) / 100 + "," + Math.round(100 * (t * i[1] + e * i[5] + i[13])) / 100;
      }
      function toCSS() {
        for (
        //Doesn't make much sense to add this optimization. If it is an identity matrix, it's very likely this will get called only once since it won't be keyframed.
        /*if(this.isIdentity()) {
            return '';
        }*/
        var t = 0, e = this.props, i = "matrix3d("; t < 16; ) i += s(1e4 * e[t]) / 1e4, 
        i += 15 === t ? ")" : ",", t += 1;
        return i;
      }
      function roundMatrixProperty(t) {
        return t < 1e-6 && t > 0 || t > -1e-6 && t < 0 ? s(1e4 * t) / 1e4 : t;
      }
      function to2dCSS() {
        //Doesn't make much sense to add this optimization. If it is an identity matrix, it's very likely this will get called only once since it won't be keyframed.
        /*if(this.isIdentity()) {
            return '';
        }*/
        var t = this.props;
        return "matrix(" + roundMatrixProperty(t[0]) + "," + roundMatrixProperty(t[1]) + "," + roundMatrixProperty(t[4]) + "," + roundMatrixProperty(t[5]) + "," + roundMatrixProperty(t[12]) + "," + roundMatrixProperty(t[13]) + ")";
      }
      return function() {
        this.reset = reset, this.rotate = rotate, this.rotateX = rotateX, this.rotateY = rotateY, 
        this.rotateZ = rotateZ, this.skew = skew, this.skewFromAxis = skewFromAxis, this.shear = shear, 
        this.scale = scale, this.setTransform = setTransform, this.translate = translate, 
        this.transform = transform, this.applyToPoint = applyToPoint, this.applyToX = applyToX, 
        this.applyToY = applyToY, this.applyToZ = applyToZ, this.applyToPointArray = applyToPointArray, 
        this.applyToTriplePoints = applyToTriplePoints, this.applyToPointStringified = applyToPointStringified, 
        this.toCSS = toCSS, this.to2dCSS = to2dCSS, this.clone = clone, this.cloneFromProps = cloneFromProps, 
        this.equals = equals, this.inversePoints = inversePoints, this.inversePoint = inversePoint, 
        this._t = this.transform, this.isIdentity = isIdentity, this._identity = !0, this._identityCalculated = !1, 
        this.props = c("float32", 16), this.reset();
      };
    }();
    /*
 Copyright 2014 David Bau.

 Permission is hereby granted, free of charge, to any person obtaining
 a copy of this software and associated documentation files (the
 "Software"), to deal in the Software without restriction, including
 without limitation the rights to use, copy, modify, merge, publish,
 distribute, sublicense, and/or sell copies of the Software, and to
 permit persons to whom the Software is furnished to do so, subject to
 the following conditions:

 The above copyright notice and this permission notice shall be
 included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
 CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 */    
    /*
 Copyright 2014 David Bau.

 Permission is hereby granted, free of charge, to any person obtaining
 a copy of this software and associated documentation files (the
 "Software"), to deal in the Software without restriction, including
 without limitation the rights to use, copy, modify, merge, publish,
 distribute, sublicense, and/or sell copies of the Software, and to
 permit persons to whom the Software is furnished to do so, subject to
 the following conditions:

 The above copyright notice and this permission notice shall be
 included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
 CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 */
    !function(t, e) {
      //
      // The following constants are related to IEEE 754 limits.
      //
      var i = this, s = 256, // rngname: name for Math.random and Math.seedrandom
      a = e.pow(s, 6), r = e.pow(2, 52), n = 2 * r, o = s - 1;
      // node.js crypto module, initialized at the bottom.
      //
      // seedrandom()
      // This is the seedrandom function described above.
      //
            //
      // ARC4
      //
      // An ARC4 implementation.  The constructor takes a key in the form of
      // an array of at most (width) integers that should be 0 <= x < (width).
      //
      // The g(count) method returns a pseudorandom integer that concatenates
      // the next (count) outputs from ARC4.  Its return value is a number x
      // that is in the range 0 <= x < (width ^ count).
      //
      function ARC4(t) {
        var e, i = t.length, a = this, r = 0, n = a.i = a.j = 0, h = a.S = [];
        // The empty key [] is treated as [0].
                // Set up S using the standard key scheduling algorithm.
        for (i || (t = [ i++ ]); r < s; ) h[r] = r++;
        for (r = 0; r < s; r++) h[r] = h[n = o & n + t[r % i] + (e = h[r])], h[n] = e;
        // The "g" method returns the next (count) outputs as one number.
                a.g = function(t) {
          for (
          // Using instance members instead of closure state nearly doubles speed.
          var e, i = 0, r = a.i, n = a.j, h = a.S; t--; ) e = h[r = o & r + 1], i = i * s + h[o & (h[r] = h[n = o & n + e]) + (h[n] = e)];
          return a.i = r, a.j = n, i;
          // For robust unpredictability, the function call below automatically
          // discards an initial batch of values.  This is called RC4-drop[256].
          // See http://google.com/search?q=rsa+fluhrer+response&btnI
                };
      }
      //
      // copy()
      // Copies internal state of ARC4 to or from a plain object.
      //
            function copy(t, e) {
        return e.i = t.i, e.j = t.j, e.S = t.S.slice(), e;
      }
      //
      // flatten()
      // Converts an object tree to nested arrays of strings.
      //
            //
      // mixkey()
      // Mixes a string seed into a key that is an array of integers, and
      // returns a shortened string seed that is equivalent to the result key.
      //
      function mixkey(t, e) {
        for (var i, s = t + "", a = 0; a < s.length; ) e[o & a] = o & (i ^= 19 * e[o & a]) + s.charCodeAt(a++);
        return tostring(e);
      }
      //
      // autoseed()
      // Returns an object for autoseeding, using window.crypto and Node crypto
      // module if available.
      //
            //
      // tostring()
      // Converts an array of charcodes to a string
      //
      function tostring(t) {
        return String.fromCharCode.apply(0, t);
      }
      //
      // When seedrandom.js is loaded, we immediately mix a few bits
      // from the built-in RNG into the entropy pool.  Because we do
      // not want to interfere with deterministic PRNG state later,
      // seedrandom will not call math.random on its own again after
      // initialization.
      //
            e.seedrandom = function(o, h, l) {
        var p = [], f = mixkey(function flatten(t, e) {
          var i, s = [], a = typeof t;
          if (e && "object" == a) for (i in t) try {
            s.push(flatten(t[i], e - 1));
          } catch (t) {}
          return s.length ? s : "string" == a ? t : t + "\0";
        }((h = !0 === h ? {
          entropy: !0
        } : h || {}).entropy ? [ o, tostring(t) ] : null === o ? function() {
          try {
            var e = new Uint8Array(s);
            return (i.crypto || i.msCrypto).getRandomValues(e), tostring(e);
          } catch (e) {
            var a = i.navigator, r = a && a.plugins;
            return [ +new Date(), i, r, i.screen, tostring(t) ];
          }
        }() : o, 3), p), m = new ARC4(p), d = function() {
          //   and no 'extra last byte'.
          for (var t = m.g(6), // Start with a numerator n < 2 ^ 48
          e = a, //   and denominator d = 2 ^ 48.
          i = 0; t < r; ) // Fill up all significant digits by
          t = (t + i) * s, //   shifting numerator and
          e *= s, //   denominator and generating a
          i = m.g(1);
          for (;t >= n; ) // To avoid rounding up, before adding
          t /= 2, //   last byte, shift everything
          e /= 2, //   right using integer math until
          i >>>= 1;
          return (t + i) / e;
 // Form the number within [0, 1).
                };
        // Calling convention: what to return as a function of prng, seed, is_math.
        return d.int32 = function() {
          return 0 | m.g(4);
        }, d.quick = function() {
          return m.g(4) / 4294967296;
        }, d.double = d, 
        // Mix the randomness into accumulated entropy.
        mixkey(tostring(m.S), t), (h.pass || l || function(t, i, s, a) {
          // If called as a method of Math (Math.seedrandom()), mutate
          // Math.random because that is how seedrandom.js has worked since v1.0.
          return a && (
          // Load the arc4 state from the given state if it has an S array.
          a.S && copy(a, m), 
          // Only provide the .state method if requested via options.state.
          t.state = function() {
            return copy(m, {});
          }), s ? (e.random = t, i) : t;
        })(d, f, "global" in h ? h.global : this == e, h.state);
      }, mixkey(e.random(), t);
    }([], // pool: entropy pool starts empty
    p);
    var g = function() {
      /**
     * BezierEasing - use bezier curve for transition easing function
     * by Gaëtan Renaudeau 2014 - 2015 – MIT License
     *
     * Credits: is based on Firefox's nsSMILKeySpline.cpp
     * Usage:
     * var spline = BezierEasing([ 0.25, 0.1, 0.25, 1.0 ])
     * spline.get(x) => returns the easing value | x must be in [0, 1] range
     *
     */
      var t = {
        getBezierEasing: function(t, i, s, a, r) {
          var n = r || ("bez_" + t + "_" + i + "_" + s + "_" + a).replace(/\./g, "p");
          if (e[n]) return e[n];
          var o = new BezierEasing([ t, i, s, a ]);
          return e[n] = o, o;
        }
        // These values are established by empiricism with tests (tradeoff: performance VS precision)
            }, e = {}, i = 11, s = 1 / (i - 1), a = "function" == typeof Float32Array;
      function A(t, e) {
        return 1 - 3 * e + 3 * t;
      }
      function B(t, e) {
        return 3 * e - 6 * t;
      }
      function C(t) {
        return 3 * t;
      }
      // Returns x(t) given t, x1, and x2, or y(t) given t, y1, and y2.
            function calcBezier(t, e, i) {
        return ((A(e, i) * t + B(e, i)) * t + C(e)) * t;
      }
      // Returns dx/dt given t, x1, and x2, or dy/dt given t, y1, and y2.
            function getSlope(t, e, i) {
        return 3 * A(e, i) * t * t + 2 * B(e, i) * t + C(e);
      }
      /**
     * points is an array of [ mX1, mY1, mX2, mY2 ]
     */
      function BezierEasing(t) {
        this._p = t, this._mSampleValues = a ? new Float32Array(i) : new Array(i), this._precomputed = !1, 
        this.get = this.get.bind(this);
      }
      return BezierEasing.prototype = {
        get: function(t) {
          var e = this._p[0], i = this._p[1], s = this._p[2], a = this._p[3];
          return this._precomputed || this._precompute(), e === i && s === a ? t : // linear
          // Because JavaScript number are imprecise, we should guarantee the extremes are right.
          0 === t ? 0 : 1 === t ? 1 : calcBezier(this._getTForX(t), i, a);
        },
        // Private part
        _precompute: function() {
          var t = this._p[0], e = this._p[1], i = this._p[2], s = this._p[3];
          this._precomputed = !0, t === e && i === s || this._calcSampleValues();
        },
        _calcSampleValues: function() {
          for (var t = this._p[0], e = this._p[2], a = 0; a < i; ++a) this._mSampleValues[a] = calcBezier(a * s, t, e);
        },
        /**
         * getTForX chose the fastest heuristic to determine the percentage value precisely from a given X projection.
         */
        _getTForX: function(t) {
          for (var e = this._p[0], a = this._p[2], r = this._mSampleValues, n = 0, o = 1, h = i - 1; o !== h && r[o] <= t; ++o) n += s;
          // Interpolate to provide an initial guess for t
          var l = n + (t - r[--o]) / (r[o + 1] - r[o]) * s, p = getSlope(l, e, a);
          return p >= .001 ? function(t, e, i, s) {
            for (var a = 0; a < 4; ++a) {
              var r = getSlope(e, i, s);
              if (0 === r) return e;
              e -= (calcBezier(e, i, s) - t) / r;
            }
            return e;
          }(t, l, e, a) : 0 === p ? l : function(t, e, i, s, a) {
            var r, n, o = 0;
            do {
              (r = calcBezier(n = e + (i - e) / 2, s, a) - t) > 0 ? i = n : e = n;
            } while (Math.abs(r) > 1e-7 && ++o < 10);
            return n;
          }(t, n, n + s, e, a);
        }
      }, t;
    }();
    function extendPrototype(t, e) {
      var i, s, a = t.length;
      for (i = 0; i < a; i += 1) for (var r in s = t[i].prototype) s.hasOwnProperty(r) && (e.prototype[r] = s[r]);
    }
    !function() {
      for (var e = 0, i = [ "ms", "moz", "webkit", "o" ], s = 0; s < i.length && !t.requestAnimationFrame; ++s) t.requestAnimationFrame = t[i[s] + "RequestAnimationFrame"], 
      t.cancelAnimationFrame = t[i[s] + "CancelAnimationFrame"] || t[i[s] + "CancelRequestAnimationFrame"];
      t.requestAnimationFrame || (t.requestAnimationFrame = function(t, i) {
        var s = new Date().getTime(), a = Math.max(0, 16 - (s - e)), r = setTimeout(function() {
          t(s + a);
        }, a);
        return e = s + a, r;
      }), t.cancelAnimationFrame || (t.cancelAnimationFrame = function(t) {
        clearTimeout(t);
      });
    }();
    var y = function() {
      function pointOnLine2D(t, e, i, s, a, r) {
        var n = t * s + e * a + i * r - a * s - r * t - i * e;
        return n > -.001 && n < .001;
      }
      var t = function(t, e, i, s) {
        var a, r, h, l, p, m, d = f, c = 0, u = [], g = [], y = N.newElement();
        for (h = i.length, a = 0; a < d; a += 1) {
          for (p = a / (d - 1), m = 0, r = 0; r < h; r += 1) l = n(1 - p, 3) * t[r] + 3 * n(1 - p, 2) * p * i[r] + 3 * (1 - p) * n(p, 2) * s[r] + n(p, 3) * e[r], 
          u[r] = l, null !== g[r] && (m += n(u[r] - g[r], 2)), g[r] = u[r];
          m && (c += m = o(m)), y.percents[a] = p, y.lengths[a] = c;
        }
        return y.addedLength = c, y;
      };
      function BezierData(t) {
        this.segmentLength = 0, this.points = new Array(t);
      }
      function PointData(t, e) {
        this.partialLength = t, this.point = e;
      }
      var e, i = (e = {}, function(t) {
        var i = t.s, s = t.e, a = t.to, r = t.ti, h = (i[0] + "_" + i[1] + "_" + s[0] + "_" + s[1] + "_" + a[0] + "_" + a[1] + "_" + r[0] + "_" + r[1]).replace(/\./g, "p");
        if (e[h]) t.bezierData = e[h]; else {
          var l, p, m, d, c, u, g, y = f, v = 0, S = null;
          2 === i.length && (i[0] != s[0] || i[1] != s[1]) && pointOnLine2D(i[0], i[1], s[0], s[1], i[0] + a[0], i[1] + a[1]) && pointOnLine2D(i[0], i[1], s[0], s[1], s[0] + r[0], s[1] + r[1]) && (y = 2);
          var b = new BezierData(y);
          for (m = a.length, l = 0; l < y; l += 1) {
            for (g = createSizedArray(m), c = l / (y - 1), u = 0, p = 0; p < m; p += 1) d = n(1 - c, 3) * i[p] + 3 * n(1 - c, 2) * c * (i[p] + a[p]) + 3 * (1 - c) * n(c, 2) * (s[p] + r[p]) + n(c, 3) * s[p], 
            g[p] = d, null !== S && (u += n(g[p] - S[p], 2));
            v += u = o(u), b.points[l] = new PointData(u, g), S = g;
          }
          b.segmentLength = v, t.bezierData = b, e[h] = b;
        }
      });
      function getDistancePerc(t, e) {
        var i = e.percents, s = e.lengths, a = i.length, r = h((a - 1) * t), n = t * e.addedLength, o = 0;
        if (r === a - 1 || 0 === r || n === s[r]) return i[r];
        for (var l = s[r] > n ? -1 : 1, p = !0; p; ) if (s[r] <= n && s[r + 1] > n ? (o = (n - s[r]) / (s[r + 1] - s[r]), 
        p = !1) : r += l, r < 0 || r >= a - 1) {
          //FIX for TypedArrays that don't store floating point values with enough accuracy
          if (r === a - 1) return i[r];
          p = !1;
        }
        return i[r] + (i[r + 1] - i[r]) * o;
      }
      var s = c("float32", 8);
      return {
        getSegmentsLength: function(e) {
          var i, s = G.newElement(), a = e.c, r = e.v, n = e.o, o = e.i, h = e._length, l = s.lengths, p = 0;
          for (i = 0; i < h - 1; i += 1) l[i] = t(r[i], r[i + 1], n[i], o[i + 1]), p += l[i].addedLength;
          return a && h && (l[i] = t(r[i], r[0], n[i], o[0]), p += l[i].addedLength), s.totalLength = p, 
          s;
        },
        getNewSegment: function(t, e, i, a, r, n, o) {
          var h, l = getDistancePerc(r = r < 0 ? 0 : r > 1 ? 1 : r, o), p = getDistancePerc(n = n > 1 ? 1 : n, o), f = t.length, m = 1 - l, d = 1 - p, c = m * m * m, u = l * m * m * 3, g = l * l * m * 3, y = l * l * l, v = m * m * d, S = l * m * d + m * l * d + m * m * p, b = l * l * d + m * l * p + l * m * p, P = l * l * p, _ = m * d * d, k = l * d * d + m * p * d + m * d * p, A = l * p * d + m * p * p + l * d * p, E = l * p * p, M = d * d * d, x = p * d * d + d * p * d + d * d * p, C = p * p * d + d * p * p + p * d * p, D = p * p * p;
          for (h = 0; h < f; h += 1) s[4 * h] = Math.round(1e3 * (c * t[h] + u * i[h] + g * a[h] + y * e[h])) / 1e3, 
          s[4 * h + 1] = Math.round(1e3 * (v * t[h] + S * i[h] + b * a[h] + P * e[h])) / 1e3, 
          s[4 * h + 2] = Math.round(1e3 * (_ * t[h] + k * i[h] + A * a[h] + E * e[h])) / 1e3, 
          s[4 * h + 3] = Math.round(1e3 * (M * t[h] + x * i[h] + C * a[h] + D * e[h])) / 1e3;
          return s;
        },
        getPointInSegment: function(t, e, i, s, a, r) {
          var n = getDistancePerc(a, r), o = 1 - n;
          return [ Math.round(1e3 * (o * o * o * t[0] + (n * o * o + o * n * o + o * o * n) * i[0] + (n * n * o + o * n * n + n * o * n) * s[0] + n * n * n * e[0])) / 1e3, Math.round(1e3 * (o * o * o * t[1] + (n * o * o + o * n * o + o * o * n) * i[1] + (n * n * o + o * n * n + n * o * n) * s[1] + n * n * n * e[1])) / 1e3 ];
        },
        buildBezierData: i,
        pointOnLine2D,
        pointOnLine3D: function(t, e, i, s, a, r, n, o, h) {
          if (0 === i && 0 === r && 0 === h) return pointOnLine2D(t, e, s, a, n, o);
          var l, p = Math.sqrt(Math.pow(s - t, 2) + Math.pow(a - e, 2) + Math.pow(r - i, 2)), f = Math.sqrt(Math.pow(n - t, 2) + Math.pow(o - e, 2) + Math.pow(h - i, 2)), m = Math.sqrt(Math.pow(n - s, 2) + Math.pow(o - a, 2) + Math.pow(h - r, 2));
          return (l = p > f ? p > m ? p - f - m : m - f - p : m > f ? m - f - p : f - p - m) > -1e-4 && l < 1e-4;
        }
      };
    }(), v = function() {
      function findCompLayers(t, e) {
        for (var i = 0, s = e.length; i < s; ) {
          if (e[i].id === t) return e[i].layers.__used ? JSON.parse(JSON.stringify(e[i].layers)) : (e[i].layers.__used = !0, 
          e[i].layers);
          i += 1;
        }
      }
      function completeShapes(t) {
        var e, i, s;
        for (e = t.length - 1; e >= 0; e -= 1) if ("sh" == t[e].ty) if (t[e].ks.k.i) convertPathsToAbsoluteValues(t[e].ks.k); else for (s = t[e].ks.k.length, 
        i = 0; i < s; i += 1) t[e].ks.k[i].s && convertPathsToAbsoluteValues(t[e].ks.k[i].s[0]), 
        t[e].ks.k[i].e && convertPathsToAbsoluteValues(t[e].ks.k[i].e[0]); else "gr" == t[e].ty && completeShapes(t[e].it);
        /*if(hasPaths){
            //mx: distance
            //ss: sensitivity
            //dc: decay
            arr.splice(arr.length-1,0,{
                "ty": "ms",
                "mx":20,
                "ss":10,
                 "dc":0.001,
                "maxDist":200
            });
        }*/      }
      function convertPathsToAbsoluteValues(t) {
        var e, i = t.i.length;
        for (e = 0; e < i; e += 1) t.i[e][0] += t.v[e][0], t.i[e][1] += t.v[e][1], t.o[e][0] += t.v[e][0], 
        t.o[e][1] += t.v[e][1];
      }
      function checkVersion(t, e) {
        var i = e ? e.split(".") : [ 100, 100, 100 ];
        return t[0] > i[0] || !(i[0] > t[0]) && (t[1] > i[1] || !(i[1] > t[1]) && (t[2] > i[2] || !(i[2] > t[2]) && void 0));
      }
      var t, e = function() {
        var t = [ 4, 4, 14 ];
        function iterateLayers(t) {
          var e, i, s, a = t.length;
          for (e = 0; e < a; e += 1) 5 === t[e].ty && (s = (i = t[e]).t.d, i.t.d = {
            k: [ {
              s,
              t: 0
            } ]
          });
        }
        return function(e) {
          if (checkVersion(t, e.v) && (iterateLayers(e.layers), e.assets)) {
            var i, s = e.assets.length;
            for (i = 0; i < s; i += 1) e.assets[i].layers && iterateLayers(e.assets[i].layers);
          }
        };
      }(), i = (t = [ 4, 7, 99 ], function(e) {
        if (e.chars && !checkVersion(t, e.v)) {
          var i, s, a, r, n, o = e.chars.length;
          for (i = 0; i < o; i += 1) if (e.chars[i].data && e.chars[i].data.shapes) for (a = (n = e.chars[i].data.shapes[0].it).length, 
          s = 0; s < a; s += 1) (r = n[s].ks.k).__converted || (convertPathsToAbsoluteValues(n[s].ks.k), 
          r.__converted = !0);
        }
      }), s = function() {
        var t = [ 4, 1, 9 ];
        function iterateShapes(t) {
          var e, i, s, a = t.length;
          for (e = 0; e < a; e += 1) if ("gr" === t[e].ty) iterateShapes(t[e].it); else if ("fl" === t[e].ty || "st" === t[e].ty) if (t[e].c.k && t[e].c.k[0].i) for (s = t[e].c.k.length, 
          i = 0; i < s; i += 1) t[e].c.k[i].s && (t[e].c.k[i].s[0] /= 255, t[e].c.k[i].s[1] /= 255, 
          t[e].c.k[i].s[2] /= 255, t[e].c.k[i].s[3] /= 255), t[e].c.k[i].e && (t[e].c.k[i].e[0] /= 255, 
          t[e].c.k[i].e[1] /= 255, t[e].c.k[i].e[2] /= 255, t[e].c.k[i].e[3] /= 255); else t[e].c.k[0] /= 255, 
          t[e].c.k[1] /= 255, t[e].c.k[2] /= 255, t[e].c.k[3] /= 255;
        }
        function iterateLayers(t) {
          var e, i = t.length;
          for (e = 0; e < i; e += 1) 4 === t[e].ty && iterateShapes(t[e].shapes);
        }
        return function(e) {
          if (checkVersion(t, e.v) && (iterateLayers(e.layers), e.assets)) {
            var i, s = e.assets.length;
            for (i = 0; i < s; i += 1) e.assets[i].layers && iterateLayers(e.assets[i].layers);
          }
        };
      }(), a = function() {
        var t = [ 4, 4, 18 ];
        function completeShapes(t) {
          var e, i, s;
          for (e = t.length - 1; e >= 0; e -= 1) if ("sh" == t[e].ty) if (t[e].ks.k.i) t[e].ks.k.c = t[e].closed; else for (s = t[e].ks.k.length, 
          i = 0; i < s; i += 1) t[e].ks.k[i].s && (t[e].ks.k[i].s[0].c = t[e].closed), t[e].ks.k[i].e && (t[e].ks.k[i].e[0].c = t[e].closed); else "gr" == t[e].ty && completeShapes(t[e].it);
        }
        function iterateLayers(t) {
          var e, i, s, a, r, n, o = t.length;
          for (i = 0; i < o; i += 1) {
            if ((e = t[i]).hasMask) {
              var h = e.masksProperties;
              for (a = h.length, s = 0; s < a; s += 1) if (h[s].pt.k.i) h[s].pt.k.c = h[s].cl; else for (n = h[s].pt.k.length, 
              r = 0; r < n; r += 1) h[s].pt.k[r].s && (h[s].pt.k[r].s[0].c = h[s].cl), h[s].pt.k[r].e && (h[s].pt.k[r].e[0].c = h[s].cl);
            }
            4 === e.ty && completeShapes(e.shapes);
          }
        }
        return function(e) {
          if (checkVersion(t, e.v) && (iterateLayers(e.layers), e.assets)) {
            var i, s = e.assets.length;
            for (i = 0; i < s; i += 1) e.assets[i].layers && iterateLayers(e.assets[i].layers);
          }
        };
      }(), r = {
        completeData: function(t, r) {
          t.__complete || (s(t), e(t), i(t), a(t), 
          //var tCanvasHelper = createTag('canvas').getContext('2d');
          function completeLayers(t, e, i) {
            var s, a, r, n, o, h, l, p = t.length;
            for (a = 0; a < p; a += 1) if ("ks" in (s = t[a]) && !s.completed) {
              if (s.completed = !0, s.tt && (t[a - 1].td = s.tt), s.hasMask) {
                var f = s.masksProperties;
                for (n = f.length, r = 0; r < n; r += 1) if (f[r].pt.k.i) convertPathsToAbsoluteValues(f[r].pt.k); else for (h = f[r].pt.k.length, 
                o = 0; o < h; o += 1) f[r].pt.k[o].s && convertPathsToAbsoluteValues(f[r].pt.k[o].s[0]), 
                f[r].pt.k[o].e && convertPathsToAbsoluteValues(f[r].pt.k[o].e[0]);
              }
              0 === s.ty ? (s.layers = findCompLayers(s.refId, e), completeLayers(s.layers, e, i)) : 4 === s.ty ? completeShapes(s.shapes) : 5 == s.ty && (0 !== (l = s).t.a.length || "m" in l.t.p || (l.singleShape = !0));
            }
          }(t.layers, t.assets, r), t.__complete = !0);
        }
      };
      return r;
    }(), S = function() {
      var e = {
        w: 0,
        size: 0,
        shapes: []
      }, i = [];
      function setUpNode(t, e) {
        var i = createTag("span");
        i.style.fontFamily = e;
        var s = createTag("span");
        // Characters that vary significantly among different fonts
                s.innerHTML = "giItT1WQy@!-/#", 
        // Visible - so we can measure it - but not on the screen
        i.style.position = "absolute", i.style.left = "-10000px", i.style.top = "-10000px", 
        // Large font size makes even subtle changes obvious
        i.style.fontSize = "300px", 
        // Reset any font properties
        i.style.fontVariant = "normal", i.style.fontStyle = "normal", i.style.fontWeight = "normal", 
        i.style.letterSpacing = "0", i.appendChild(s), document.body.appendChild(i);
        // Remember width with no applied web font
        var a = s.offsetWidth;
        return s.style.fontFamily = t + ", " + e, {
          node: s,
          w: a,
          parent: i
        };
      }
      function createHelper(t, e) {
        var i = createNS("text");
        //tCanvasHelper.font = ' 100px '+ fontData.fFamily;
        return i.style.fontSize = "100px", 
        //tHelper.style.fontFamily = fontData.fFamily;
        i.setAttribute("font-family", e.fFamily), i.setAttribute("font-style", e.fStyle), 
        i.setAttribute("font-weight", e.fWeight), i.textContent = "1", e.fClass ? (i.style.fontFamily = "inherit", 
        i.className = e.fClass) : i.style.fontFamily = e.fFamily, t.appendChild(i), createTag("canvas").getContext("2d").font = e.fWeight + " " + e.fStyle + " 100px " + e.fFamily, 
        i;
      }
      //Hindi characters
      i = i.concat([ 2304, 2305, 2306, 2307, 2362, 2363, 2364, 2364, 2366, 2367, 2368, 2369, 2370, 2371, 2372, 2373, 2374, 2375, 2376, 2377, 2378, 2379, 2380, 2381, 2382, 2383, 2387, 2388, 2389, 2390, 2391, 2402, 2403 ]);
      var s = function() {
        this.fonts = [], this.chars = null, this.typekitLoaded = 0, this.loaded = !1, this.initTime = Date.now();
      };
      //TODO: for now I'm adding these methods to the Class and not the prototype. Think of a better way to implement it. 
            return s.getCombinedCharacterCodes = function() {
        return i;
      }, s.prototype.addChars = function(t) {
        if (t) {
          this.chars || (this.chars = []);
          var e, i, s, a = t.length, r = this.chars.length;
          for (e = 0; e < a; e += 1) {
            for (i = 0, s = !1; i < r; ) this.chars[i].style === t[e].style && this.chars[i].fFamily === t[e].fFamily && this.chars[i].ch === t[e].ch && (s = !0), 
            i += 1;
            s || (this.chars.push(t[e]), r += 1);
          }
        }
      }, s.prototype.addFonts = function(e, i) {
        if (e) {
          if (this.chars) return this.loaded = !0, void (this.fonts = e.list);
          var s, a = e.list, r = a.length;
          for (s = 0; s < r; s += 1) {
            if (a[s].loaded = !1, a[s].monoCase = setUpNode(a[s].fFamily, "monospace"), a[s].sansCase = setUpNode(a[s].fFamily, "sans-serif"), 
            a[s].fPath) {
              if ("p" === a[s].fOrigin || 3 === a[s].origin) {
                var n = createTag("style");
                n.type = "text/css", n.innerHTML = "@font-face {font-family: " + a[s].fFamily + "; font-style: normal; src: url('" + a[s].fPath + "');}", 
                i.appendChild(n);
              } else if ("g" === a[s].fOrigin || 1 === a[s].origin) {
                var o = createTag("link");
                o.type = "text/css", o.rel = "stylesheet", o.href = a[s].fPath, document.body.appendChild(o);
              } else if ("t" === a[s].fOrigin || 2 === a[s].origin) {
                var h = createTag("script");
                h.setAttribute("src", a[s].fPath), i.appendChild(h);
              }
            } else a[s].loaded = !0;
            a[s].helper = createHelper(i, a[s]), a[s].cache = {}, this.fonts.push(a[s]);
          }
          //On some cases the font even if it is loaded, it won't load correctly when measuring text on canvas.
          //Adding this timeout seems to fix it
                    setTimeout(function() {
            (function checkLoadedFonts() {
              var e, i, s, a = this.fonts.length, r = a;
              for (e = 0; e < a; e += 1) if (this.fonts[e].loaded) r -= 1; else if ("t" === this.fonts[e].fOrigin || 2 === this.fonts[e].origin) {
                if (t.Typekit && t.Typekit.load && 0 === this.typekitLoaded) {
                  this.typekitLoaded = 1;
                  try {
                    t.Typekit.load({
                      async: !0,
                      active: function() {
                        this.typekitLoaded = 2;
                      }.bind(this)
                    });
                  } catch (t) {}
                }
                2 === this.typekitLoaded && (this.fonts[e].loaded = !0);
              } else "n" === this.fonts[e].fOrigin || 0 === this.fonts[e].origin ? this.fonts[e].loaded = !0 : (i = this.fonts[e].monoCase.node, 
              s = this.fonts[e].monoCase.w, i.offsetWidth !== s ? (r -= 1, this.fonts[e].loaded = !0) : (i = this.fonts[e].sansCase.node, 
              s = this.fonts[e].sansCase.w, i.offsetWidth !== s && (r -= 1, this.fonts[e].loaded = !0)), 
              this.fonts[e].loaded && (this.fonts[e].sansCase.parent.parentNode.removeChild(this.fonts[e].sansCase.parent), 
              this.fonts[e].monoCase.parent.parentNode.removeChild(this.fonts[e].monoCase.parent)));
              0 !== r && Date.now() - this.initTime < 5e3 ? setTimeout(checkLoadedFonts.bind(this), 20) : setTimeout(function() {
                this.loaded = !0;
              }.bind(this), 0);
            }).bind(this)();
          }.bind(this), 100);
        } else this.loaded = !0;
      }, s.prototype.getCharData = function(t, i, s) {
        for (var a = 0, r = this.chars.length; a < r; ) {
          if (this.chars[a].ch === t && this.chars[a].style === i && this.chars[a].fFamily === s) return this.chars[a];
          a += 1;
        }
        return console && console.warn && console.warn("Missing character from exported characters list: ", t, i, s), 
        e;
      }, s.prototype.getFontByName = function(t) {
        for (var e = 0, i = this.fonts.length; e < i; ) {
          if (this.fonts[e].fName === t) return this.fonts[e];
          e += 1;
        }
        return this.fonts[0];
      }, s.prototype.measureText = function(t, e, i) {
        var s = this.getFontByName(e), a = t.charCodeAt(0);
        if (!s.cache[a + 1]) {
          var r = s.helper;
          //Canvas version
          //fontData.cache[index] = tHelper.measureText(char).width / 100;
          //SVG version
          //console.log(tHelper.getBBox().width)
          /*tHelper.textContent = '|' + char + '|';
            var doubleSize = tHelper.getComputedTextLength();
            tHelper.textContent = '||';
            var singleSize = tHelper.getComputedTextLength();
            fontData.cache[index + 1] = (doubleSize - singleSize)/100;*/          r.textContent = t, 
          s.cache[a + 1] = r.getComputedTextLength() / 100;
        }
        return s.cache[a + 1] * i;
      }, s;
    }(), b = function() {
      var t = a, e = Math.abs;
      function interpolateValue(t, e) {
        var i, s = this.offsetTime;
        "multidimensional" === this.propType && (i = c("float32", this.pv.length));
        for (var a, r, n, o, h, l, p, f, d, u, v, S, b, P, _, k, A, E = e.lastIndex, M = E, x = this.keyframes.length - 1, C = !0; C; ) {
          if (a = this.keyframes[M], r = this.keyframes[M + 1], M == x - 1 && t >= r.t - s) {
            a.h && (a = r), E = 0;
            break;
          }
          if (r.t - s > t) {
            E = M;
            break;
          }
          M < x - 1 ? M += 1 : (E = 0, C = !1);
        }
        if (a.to) {
          a.bezierData || y.buildBezierData(a);
          var D = a.bezierData;
          if (t >= r.t - s || t < a.t - s) {
            var T = t >= r.t - s ? D.points.length - 1 : 0;
            for (o = D.points[T].point.length, n = 0; n < o; n += 1) i[n] = D.points[T].point[n];
            e._lastBezierData = null;
          } else {
            a.__fnct ? f = a.__fnct : (f = g.getBezierEasing(a.o.x, a.o.y, a.i.x, a.i.y, a.n).get, 
            a.__fnct = f), h = f((t - (a.t - s)) / (r.t - s - (a.t - s)));
            var F, w = D.segmentLength * h, I = e.lastFrame < t && e._lastBezierData === D ? e._lastAddedLength : 0;
            for (p = e.lastFrame < t && e._lastBezierData === D ? e._lastPoint : 0, C = !0, 
            l = D.points.length; C; ) {
              if (I += D.points[p].partialLength, 0 === w || 0 === h || p == D.points.length - 1) {
                for (o = D.points[p].point.length, n = 0; n < o; n += 1) i[n] = D.points[p].point[n];
                break;
              }
              if (w >= I && w < I + D.points[p + 1].partialLength) {
                for (F = (w - I) / D.points[p + 1].partialLength, o = D.points[p].point.length, 
                n = 0; n < o; n += 1) i[n] = D.points[p].point[n] + (D.points[p + 1].point[n] - D.points[p].point[n]) * F;
                break;
              }
              p < l - 1 ? p += 1 : C = !1;
            }
            e._lastPoint = p, e._lastAddedLength = I - D.points[p].partialLength, e._lastBezierData = D;
          }
        } else {
          var V, L, R, G, N;
          if (x = a.s.length, this.sh && 1 !== a.h) if (t >= r.t - s) i[0] = a.e[0], i[1] = a.e[1], 
          i[2] = a.e[2]; else if (t <= a.t - s) i[0] = a.s[0], i[1] = a.s[1], i[2] = a.s[2]; else {
            d = i, v = (u = 
            //based on @Toji's https://github.com/toji/gl-matrix/
            function(t, e, i) {
              var s, a, r, n, o, h = [], l = t[0], p = t[1], f = t[2], m = t[3], d = e[0], c = e[1], u = e[2], g = e[3];
              return (a = l * d + p * c + f * u + m * g) < 0 && (a = -a, d = -d, c = -c, u = -u, 
              g = -g), 1 - a > 1e-6 ? (s = Math.acos(a), r = Math.sin(s), n = Math.sin((1 - i) * s) / r, 
              o = Math.sin(i * s) / r) : (n = 1 - i, o = i), h[0] = n * l + o * d, h[1] = n * p + o * c, 
              h[2] = n * f + o * u, h[3] = n * m + o * g, h;
            }(createQuaternion(a.s), createQuaternion(a.e), (t - (a.t - s)) / (r.t - s - (a.t - s))))[0], 
            S = u[1], b = u[2], P = u[3], _ = Math.atan2(2 * S * P - 2 * v * b, 1 - 2 * S * S - 2 * b * b), 
            k = Math.asin(2 * v * S + 2 * b * P), A = Math.atan2(2 * v * P - 2 * S * b, 1 - 2 * v * v - 2 * b * b), 
            d[0] = _ / m, d[1] = k / m, d[2] = A / m;
          } else for (M = 0; M < x; M += 1) 1 !== a.h && (t >= r.t - s ? h = 1 : t < a.t - s ? h = 0 : (a.o.x.constructor === Array ? (a.__fnct || (a.__fnct = []), 
          a.__fnct[M] ? f = a.__fnct[M] : (V = a.o.x[M] || a.o.x[0], L = a.o.y[M] || a.o.y[0], 
          R = a.i.x[M] || a.i.x[0], G = a.i.y[M] || a.i.y[0], f = g.getBezierEasing(V, L, R, G).get, 
          a.__fnct[M] = f)) : a.__fnct ? f = a.__fnct : (V = a.o.x, L = a.o.y, R = a.i.x, 
          G = a.i.y, f = g.getBezierEasing(V, L, R, G).get, a.__fnct = f), h = f((t - (a.t - s)) / (r.t - s - (a.t - s))))), 
          N = 1 === a.h ? a.s[M] : a.s[M] + (a.e[M] - a.s[M]) * h, 1 === x ? i = N : i[M] = N;
        }
        return e.lastIndex = E, i;
      }
      function createQuaternion(t) {
        var e = t[0] * m, i = t[1] * m, s = t[2] * m, a = Math.cos(e / 2), r = Math.cos(i / 2), n = Math.cos(s / 2), o = Math.sin(e / 2), h = Math.sin(i / 2), l = Math.sin(s / 2);
        return [ o * h * n + a * r * l, o * r * n + a * h * l, a * h * n - o * r * l, a * r * n - o * h * l ];
      }
      function getValueAtCurrentTime() {
        var e = this.comp.renderedFrame - this.offsetTime, i = this.keyframes[0].t - this.offsetTime, s = this.keyframes[this.keyframes.length - 1].t - this.offsetTime;
        if (!(e === this._caching.lastFrame || this._caching.lastFrame !== t && (this._caching.lastFrame >= s && e >= s || this._caching.lastFrame < i && e < i))) {
          this._caching.lastIndex = this._caching.lastFrame < e ? this._caching.lastIndex : 0;
          var a = this.interpolateValue(e, this._caching);
          this.pv = a;
        }
        return this._caching.lastFrame = e, this.pv;
      }
      function setVValue(t) {
        var i;
        if ("unidimensional" === this.propType) i = t * this.mult, e(this.v - i) > 1e-5 && (this.v = i, 
        this._mdf = !0); else for (var s = 0, a = this.v.length; s < a; ) i = t[s] * this.mult, 
        e(this.v[s] - i) > 1e-5 && (this.v[s] = i, this._mdf = !0), s += 1;
      }
      function processEffectsSequence() {
        if (this.elem.globalData.frameId !== this.frameId && this.effectsSequence.length) if (this.lock) this.setVValue(this.pv); else {
          this.lock = !0, this._mdf = this._isFirstFrame;
          var t, e = this.effectsSequence.length, i = this.kf ? this.pv : this.data.k;
          for (t = 0; t < e; t += 1) i = this.effectsSequence[t](i);
          this.setVValue(i), this._isFirstFrame = !1, this.lock = !1, this.frameId = this.elem.globalData.frameId;
        }
      }
      function addEffect(t) {
        this.effectsSequence.push(t), this.container.addDynamicProperty(this);
      }
      function ValueProperty(t, e, i, s) {
        this.propType = "unidimensional", this.mult = i || 1, this.data = e, this.v = i ? e.k * i : e.k, 
        this.pv = e.k, this._mdf = !1, this.elem = t, this.container = s, this.comp = t.comp, 
        this.k = !1, this.kf = !1, this.vel = 0, this.effectsSequence = [], this._isFirstFrame = !0, 
        this.getValue = processEffectsSequence, this.setVValue = setVValue, this.addEffect = addEffect;
      }
      function MultiDimensionalProperty(t, e, i, s) {
        this.propType = "multidimensional", this.mult = i || 1, this.data = e, this._mdf = !1, 
        this.elem = t, this.container = s, this.comp = t.comp, this.k = !1, this.kf = !1, 
        this.frameId = -1;
        var a, r = e.k.length;
        for (this.v = c("float32", r), this.pv = c("float32", r), c("float32", r), this.vel = c("float32", r), 
        a = 0; a < r; a += 1) this.v[a] = e.k[a] * this.mult, this.pv[a] = e.k[a];
        this._isFirstFrame = !0, this.effectsSequence = [], this.getValue = processEffectsSequence, 
        this.setVValue = setVValue, this.addEffect = addEffect;
      }
      function KeyframedValueProperty(e, i, s, a) {
        this.propType = "unidimensional", this.keyframes = i.k, this.offsetTime = e.data.st, 
        this.frameId = -1, this._caching = {
          lastFrame: t,
          lastIndex: 0,
          value: 0
        }, this.k = !0, this.kf = !0, this.data = i, this.mult = s || 1, this.elem = e, 
        this.container = a, this.comp = e.comp, this.v = t, this.pv = t, this._isFirstFrame = !0, 
        this.getValue = processEffectsSequence, this.setVValue = setVValue, this.interpolateValue = interpolateValue, 
        this.effectsSequence = [ getValueAtCurrentTime.bind(this) ], this.addEffect = addEffect;
      }
      function KeyframedMultidimensionalProperty(e, i, s, a) {
        this.propType = "multidimensional";
        var r, n, o, h, l, p = i.k.length;
        for (r = 0; r < p - 1; r += 1) i.k[r].to && i.k[r].s && i.k[r].e && (n = i.k[r].s, 
        o = i.k[r].e, h = i.k[r].to, l = i.k[r].ti, (2 === n.length && (n[0] !== o[0] || n[1] !== o[1]) && y.pointOnLine2D(n[0], n[1], o[0], o[1], n[0] + h[0], n[1] + h[1]) && y.pointOnLine2D(n[0], n[1], o[0], o[1], o[0] + l[0], o[1] + l[1]) || 3 === n.length && (n[0] !== o[0] || n[1] !== o[1] || n[2] !== o[2]) && y.pointOnLine3D(n[0], n[1], n[2], o[0], o[1], o[2], n[0] + h[0], n[1] + h[1], n[2] + h[2]) && y.pointOnLine3D(n[0], n[1], n[2], o[0], o[1], o[2], o[0] + l[0], o[1] + l[1], o[2] + l[2])) && (i.k[r].to = null, 
        i.k[r].ti = null), n[0] === o[0] && n[1] === o[1] && 0 === h[0] && 0 === h[1] && 0 === l[0] && 0 === l[1] && (2 === n.length || n[2] === o[2] && 0 === h[2] && 0 === l[2]) && (i.k[r].to = null, 
        i.k[r].ti = null));
        this.effectsSequence = [ getValueAtCurrentTime.bind(this) ], this.keyframes = i.k, 
        this.offsetTime = e.data.st, this.k = !0, this.kf = !0, this._isFirstFrame = !0, 
        this.mult = s || 1, this.elem = e, this.container = a, this.comp = e.comp, this.getValue = processEffectsSequence, 
        this.setVValue = setVValue, this.interpolateValue = interpolateValue, this.frameId = -1;
        var f = i.k[0].s.length;
        for (this.v = c("float32", f), this.pv = c("float32", f), r = 0; r < f; r += 1) this.v[r] = t, 
        this.pv[r] = t;
        this._caching = {
          lastFrame: t,
          lastIndex: 0,
          value: c("float32", f)
        }, this.addEffect = addEffect;
      }
      return {
        getProp: function(t, e, i, s, a) {
          var r;
          if (0 === e.a) r = 0 === i ? new ValueProperty(t, e, s, a) : new MultiDimensionalProperty(t, e, s, a); else if (1 === e.a) r = 0 === i ? new KeyframedValueProperty(t, e, s, a) : new KeyframedMultidimensionalProperty(t, e, s, a); else if (e.k.length) if ("number" == typeof e.k[0]) r = new MultiDimensionalProperty(t, e, s, a); else switch (i) {
           case 0:
            r = new KeyframedValueProperty(t, e, s, a);
            break;

           case 1:
            r = new KeyframedMultidimensionalProperty(t, e, s, a);
          } else r = new ValueProperty(t, e, s, a);
          return r.effectsSequence.length && a.addDynamicProperty(r), r;
        }
      };
    }(), P = function() {
      function TransformProperty(t, e, i) {
        if (this.elem = t, this.frameId = -1, this.propType = "transform", this.data = e, 
        this.v = new u(), 
        //Precalculated matrix with non animated properties
        this.pre = new u(), this.appliedTransformations = 0, this.initDynamicPropertyContainer(i || t), 
        e.p.s ? (this.px = b.getProp(t, e.p.x, 0, 0, this), this.py = b.getProp(t, e.p.y, 0, 0, this), 
        e.p.z && (this.pz = b.getProp(t, e.p.z, 0, 0, this))) : this.p = b.getProp(t, e.p, 1, 0, this), 
        e.r) this.r = b.getProp(t, e.r, 0, m, this); else if (e.rx) {
          if (this.rx = b.getProp(t, e.rx, 0, m, this), this.ry = b.getProp(t, e.ry, 0, m, this), 
          this.rz = b.getProp(t, e.rz, 0, m, this), e.or.k[0].ti) {
            var s, a = e.or.k.length;
            for (s = 0; s < a; s += 1) e.or.k[s].to = e.or.k[s].ti = null;
          }
          this.or = b.getProp(t, e.or, 1, m, this), 
          //sh Indicates it needs to be capped between -180 and 180
          this.or.sh = !0;
        }
        e.sk && (this.sk = b.getProp(t, e.sk, 0, m, this), this.sa = b.getProp(t, e.sa, 0, m, this)), 
        e.a && (this.a = b.getProp(t, e.a, 1, 0, this)), e.s && (this.s = b.getProp(t, e.s, 1, .01, this)), 
        // Opacity is not part of the transform properties, that's why it won't use this.dynamicProperties. That way transforms won't get updated if opacity changes.
        e.o ? this.o = b.getProp(t, e.o, 0, .01, t) : this.o = {
          _mdf: !1,
          v: 1
        }, this._isDirty = !0, this.dynamicProperties.length || this.getValue(!0);
      }
      return TransformProperty.prototype = {
        applyToMatrix: function(t) {
          var e = this._mdf;
          this.iterateDynamicProperties(), this._mdf = this._mdf || e, this.a && t.translate(-this.a.v[0], -this.a.v[1], this.a.v[2]), 
          this.s && t.scale(this.s.v[0], this.s.v[1], this.s.v[2]), this.sk && t.skewFromAxis(-this.sk.v, this.sa.v), 
          this.r ? t.rotate(-this.r.v) : t.rotateZ(-this.rz.v).rotateY(this.ry.v).rotateX(this.rx.v).rotateZ(-this.or.v[2]).rotateY(this.or.v[1]).rotateX(this.or.v[0]), 
          this.data.p.s ? this.data.p.z ? t.translate(this.px.v, this.py.v, -this.pz.v) : t.translate(this.px.v, this.py.v, 0) : t.translate(this.p.v[0], this.p.v[1], -this.p.v[2]);
        },
        getValue: function(t) {
          if (this.elem.globalData.frameId !== this.frameId) {
            if (this._isDirty && (this.precalculateMatrix(), this._isDirty = !1), this.iterateDynamicProperties(), 
            this._mdf || t) {
              if (this.v.cloneFromProps(this.pre.props), this.appliedTransformations < 1 && this.v.translate(-this.a.v[0], -this.a.v[1], this.a.v[2]), 
              this.appliedTransformations < 2 && this.v.scale(this.s.v[0], this.s.v[1], this.s.v[2]), 
              this.sk && this.appliedTransformations < 3 && this.v.skewFromAxis(-this.sk.v, this.sa.v), 
              this.r && this.appliedTransformations < 4 ? this.v.rotate(-this.r.v) : !this.r && this.appliedTransformations < 4 && this.v.rotateZ(-this.rz.v).rotateY(this.ry.v).rotateX(this.rx.v).rotateZ(-this.or.v[2]).rotateY(this.or.v[1]).rotateX(this.or.v[0]), 
              this.autoOriented) {
                var e, i, s = this.elem.globalData.frameRate;
                if (this.p && this.p.keyframes && this.p.getValueAtTime) this.p._caching.lastFrame + this.p.offsetTime <= this.p.keyframes[0].t ? (e = this.p.getValueAtTime((this.p.keyframes[0].t + .01) / s, 0), 
                i = this.p.getValueAtTime(this.p.keyframes[0].t / s, 0)) : this.p._caching.lastFrame + this.p.offsetTime >= this.p.keyframes[this.p.keyframes.length - 1].t ? (e = this.p.getValueAtTime(this.p.keyframes[this.p.keyframes.length - 1].t / s, 0), 
                i = this.p.getValueAtTime((this.p.keyframes[this.p.keyframes.length - 1].t - .01) / s, 0)) : (e = this.p.pv, 
                i = this.p.getValueAtTime((this.p._caching.lastFrame + this.p.offsetTime - .01) / s, this.p.offsetTime)); else if (this.px && this.px.keyframes && this.py.keyframes && this.px.getValueAtTime && this.py.getValueAtTime) {
                  e = [], i = [];
                  var a = this.px, r = this.py;
                  a._caching.lastFrame + a.offsetTime <= a.keyframes[0].t ? (e[0] = a.getValueAtTime((a.keyframes[0].t + .01) / s, 0), 
                  e[1] = r.getValueAtTime((r.keyframes[0].t + .01) / s, 0), i[0] = a.getValueAtTime(a.keyframes[0].t / s, 0), 
                  i[1] = r.getValueAtTime(r.keyframes[0].t / s, 0)) : a._caching.lastFrame + a.offsetTime >= a.keyframes[a.keyframes.length - 1].t ? (e[0] = a.getValueAtTime(a.keyframes[a.keyframes.length - 1].t / s, 0), 
                  e[1] = r.getValueAtTime(r.keyframes[r.keyframes.length - 1].t / s, 0), i[0] = a.getValueAtTime((a.keyframes[a.keyframes.length - 1].t - .01) / s, 0), 
                  i[1] = r.getValueAtTime((r.keyframes[r.keyframes.length - 1].t - .01) / s, 0)) : (e = [ a.pv, r.pv ], 
                  i[0] = a.getValueAtTime((a._caching.lastFrame + a.offsetTime - .01) / s, a.offsetTime), 
                  i[1] = r.getValueAtTime((r._caching.lastFrame + r.offsetTime - .01) / s, r.offsetTime));
                }
                this.v.rotate(-Math.atan2(e[1] - i[1], e[0] - i[0]));
              }
              this.data.p.s ? this.data.p.z ? this.v.translate(this.px.v, this.py.v, -this.pz.v) : this.v.translate(this.px.v, this.py.v, 0) : this.v.translate(this.p.v[0], this.p.v[1], -this.p.v[2]);
            }
            this.frameId = this.elem.globalData.frameId;
          }
        },
        precalculateMatrix: function() {
          if (!this.a.k && (this.pre.translate(-this.a.v[0], -this.a.v[1], this.a.v[2]), this.appliedTransformations = 1, 
          !this.s.effectsSequence.length)) {
            if (this.pre.scale(this.s.v[0], this.s.v[1], this.s.v[2]), this.appliedTransformations = 2, 
            this.sk) {
              if (this.sk.effectsSequence.length || this.sa.effectsSequence.length) return;
              this.pre.skewFromAxis(-this.sk.v, this.sa.v), this.appliedTransformations = 3;
            }
            if (this.r) {
              if (this.r.effectsSequence.length) return;
              this.pre.rotate(-this.r.v), this.appliedTransformations = 4;
            } else this.rz.effectsSequence.length || this.ry.effectsSequence.length || this.rx.effectsSequence.length || this.or.effectsSequence.length || (this.pre.rotateZ(-this.rz.v).rotateY(this.ry.v).rotateX(this.rx.v).rotateZ(-this.or.v[2]).rotateY(this.or.v[1]).rotateX(this.or.v[0]), 
            this.appliedTransformations = 4);
          }
        },
        autoOrient: function() {
          //
          //var prevP = this.getValueAtTime();
        }
      }, extendPrototype([ DynamicPropertyContainer ], TransformProperty), TransformProperty.prototype.addDynamicProperty = function(t) {
        this._addDynamicProperty(t), this.elem.addDynamicProperty(t), this._isDirty = !0;
      }, TransformProperty.prototype._addDynamicProperty = DynamicPropertyContainer.prototype.addDynamicProperty, 
      {
        getTransformProperty: function(t, e, i) {
          return new TransformProperty(t, e, i);
        }
      };
    }();
    function ShapePath() {
      this.c = !1, this._length = 0, this._maxLength = 8, this.v = createSizedArray(this._maxLength), 
      this.o = createSizedArray(this._maxLength), this.i = createSizedArray(this._maxLength);
    }
    ShapePath.prototype.setPathData = function(t, e) {
      this.c = t, this.setLength(e);
      for (var i = 0; i < e; ) this.v[i] = V.newElement(), this.o[i] = V.newElement(), 
      this.i[i] = V.newElement(), i += 1;
    }, ShapePath.prototype.setLength = function(t) {
      for (;this._maxLength < t; ) this.doubleArrayLength();
      this._length = t;
    }, ShapePath.prototype.doubleArrayLength = function() {
      this.v = this.v.concat(createSizedArray(this._maxLength)), this.i = this.i.concat(createSizedArray(this._maxLength)), 
      this.o = this.o.concat(createSizedArray(this._maxLength)), this._maxLength *= 2;
    }, ShapePath.prototype.setXYAt = function(t, e, i, s, a) {
      var r;
      switch (this._length = Math.max(this._length, s + 1), this._length >= this._maxLength && this.doubleArrayLength(), 
      i) {
       case "v":
        r = this.v;
        break;

       case "i":
        r = this.i;
        break;

       case "o":
        r = this.o;
      }
      (!r[s] || r[s] && !a) && (r[s] = V.newElement()), r[s][0] = t, r[s][1] = e;
    }, ShapePath.prototype.setTripleAt = function(t, e, i, s, a, r, n, o) {
      this.setXYAt(t, e, "v", n, o), this.setXYAt(i, s, "o", n, o), this.setXYAt(a, r, "i", n, o);
    }, ShapePath.prototype.reverse = function() {
      var t = new ShapePath();
      t.setPathData(this.c, this._length);
      var e = this.v, i = this.o, s = this.i, a = 0;
      this.c && (t.setTripleAt(e[0][0], e[0][1], s[0][0], s[0][1], i[0][0], i[0][1], 0, !1), 
      a = 1);
      var r, n = this._length - 1, o = this._length;
      for (r = a; r < o; r += 1) t.setTripleAt(e[n][0], e[n][1], s[n][0], s[n][1], i[n][0], i[n][1], r, !1), 
      n -= 1;
      return t;
    };
    var _ = function() {
      var t = -999999;
      function interpolateShape(t, e, i) {
        var s, a, r, n, o, h, l, p, f, m = i.lastIndex, d = this.keyframes;
        if (t < d[0].t - this.offsetTime) s = d[0].s[0], r = !0, m = 0; else if (t >= d[d.length - 1].t - this.offsetTime) s = 1 === d[d.length - 2].h ? d[d.length - 1].s[0] : d[d.length - 2].e[0], 
        r = !0; else {
          for (var c, u, y = m, v = d.length - 1, S = !0; S && (c = d[y], !((u = d[y + 1]).t - this.offsetTime > t)); ) y < v - 1 ? y += 1 : S = !1;
          if (m = y, !(r = 1 === c.h)) {
            if (t >= u.t - this.offsetTime) p = 1; else if (t < c.t - this.offsetTime) p = 0; else {
              var b;
              c.__fnct ? b = c.__fnct : (b = g.getBezierEasing(c.o.x, c.o.y, c.i.x, c.i.y).get, 
              c.__fnct = b), p = b((t - (c.t - this.offsetTime)) / (u.t - this.offsetTime - (c.t - this.offsetTime)));
            }
            a = c.e[0];
          }
          s = c.s[0];
        }
        for (h = e._length, l = s.i[0].length, i.lastIndex = m, n = 0; n < h; n += 1) for (o = 0; o < l; o += 1) f = r ? s.i[n][o] : s.i[n][o] + (a.i[n][o] - s.i[n][o]) * p, 
        e.i[n][o] = f, f = r ? s.o[n][o] : s.o[n][o] + (a.o[n][o] - s.o[n][o]) * p, e.o[n][o] = f, 
        f = r ? s.v[n][o] : s.v[n][o] + (a.v[n][o] - s.v[n][o]) * p, e.v[n][o] = f;
      }
      function resetShape() {
        this.paths = this.localShapeCollection;
      }
      function processEffectsSequence() {
        if (!this.lock && this.elem.globalData.frameId !== this.frameId) {
          this.lock = !0, this.frameId = this.elem.globalData.frameId, this._mdf = !1;
          var t, e = this.kf ? this.pv : this.data.ks ? this.data.ks.k : this.data.pt.k, i = this.effectsSequence.length;
          for (t = 0; t < i; t += 1) e = this.effectsSequence[t](e);
          (function(t, e) {
            if (t._length !== e._length || t.c !== e.c) return !1;
            var i, s = t._length;
            for (i = 0; i < s; i += 1) if (t.v[i][0] !== e.v[i][0] || t.v[i][1] !== e.v[i][1] || t.o[i][0] !== e.o[i][0] || t.o[i][1] !== e.o[i][1] || t.i[i][0] !== e.i[i][0] || t.i[i][1] !== e.i[i][1]) return !1;
            return !0;
          })(this.v, e) || (this.v = L.clone(e), this.localShapeCollection.releaseShapes(), 
          this.localShapeCollection.addShape(this.v), this._mdf = !0, this.paths = this.localShapeCollection), 
          this.lock = !1;
        }
      }
      function ShapeProperty(t, e, i) {
        this.propType = "shape", this.comp = t.comp, this.container = t, this.elem = t, 
        this.data = e, this.k = !1, this.kf = !1, this._mdf = !1;
        var s = 3 === i ? e.pt.k : e.ks.k;
        this.v = L.clone(s), this.pv = L.clone(this.v), this.localShapeCollection = R.newShapeCollection(), 
        this.paths = this.localShapeCollection, this.paths.addShape(this.v), this.reset = resetShape, 
        this.effectsSequence = [];
      }
      function addEffect(t) {
        this.effectsSequence.push(t), this.container.addDynamicProperty(this);
      }
      function KeyframedShapeProperty(e, i, s) {
        this.propType = "shape", this.comp = e.comp, this.elem = e, this.container = e, 
        this.offsetTime = e.data.st, this.keyframes = 3 === s ? i.pt.k : i.ks.k, this.k = !0, 
        this.kf = !0;
        var a = this.keyframes[0].s[0].i.length;
        this.keyframes[0].s[0].i[0].length, this.v = L.newElement(), this.v.setPathData(this.keyframes[0].s[0].c, a), 
        this.pv = L.clone(this.v), this.localShapeCollection = R.newShapeCollection(), this.paths = this.localShapeCollection, 
        this.paths.addShape(this.v), this.lastFrame = t, this.reset = resetShape, this._caching = {
          lastFrame: t,
          lastIndex: 0
        }, this.effectsSequence = [ function() {
          var e = this.comp.renderedFrame - this.offsetTime, i = this.keyframes[0].t - this.offsetTime, s = this.keyframes[this.keyframes.length - 1].t - this.offsetTime, a = this._caching.lastFrame;
          return a !== t && (a < i && e < i || a > s && e > s) || (
          ////
          this._caching.lastIndex = a < e ? this._caching.lastIndex : 0, this.interpolateShape(e, this.pv, this._caching)), 
          this._caching.lastFrame = e, this.pv;
        }.bind(this) ];
      }
      ShapeProperty.prototype.interpolateShape = interpolateShape, ShapeProperty.prototype.getValue = processEffectsSequence, 
      ShapeProperty.prototype.getValue = processEffectsSequence, ShapeProperty.prototype.addEffect = addEffect, 
      KeyframedShapeProperty.prototype.getValue = processEffectsSequence, KeyframedShapeProperty.prototype.interpolateShape = interpolateShape, 
      KeyframedShapeProperty.prototype.addEffect = addEffect;
      var e = function() {
        function EllShapeProperty(t, e) {
          /*this.v = {
                v: createSizedArray(4),
                i: createSizedArray(4),
                o: createSizedArray(4),
                c: true
            };*/
          this.v = L.newElement(), this.v.setPathData(!0, 4), this.localShapeCollection = R.newShapeCollection(), 
          this.paths = this.localShapeCollection, this.localShapeCollection.addShape(this.v), 
          this.d = e.d, this.elem = t, this.comp = t.comp, this.frameId = -1, this.initDynamicPropertyContainer(t), 
          this.p = b.getProp(t, e.p, 1, 0, this), this.s = b.getProp(t, e.s, 1, 0, this), 
          this.dynamicProperties.length ? this.k = !0 : (this.k = !1, this.convertEllToPath());
        }
        return EllShapeProperty.prototype = {
          reset: resetShape,
          getValue: function() {
            this.elem.globalData.frameId !== this.frameId && (this.frameId = this.elem.globalData.frameId, 
            this.iterateDynamicProperties(), this._mdf && this.convertEllToPath());
          },
          convertEllToPath: function() {
            var t = this.p.v[0], e = this.p.v[1], i = this.s.v[0] / 2, s = this.s.v[1] / 2, a = 3 !== this.d, r = this.v;
            r.v[0][0] = t, r.v[0][1] = e - s, r.v[1][0] = a ? t + i : t - i, r.v[1][1] = e, 
            r.v[2][0] = t, r.v[2][1] = e + s, r.v[3][0] = a ? t - i : t + i, r.v[3][1] = e, 
            r.i[0][0] = a ? t - .5519 * i : t + .5519 * i, r.i[0][1] = e - s, r.i[1][0] = a ? t + i : t - i, 
            r.i[1][1] = e - .5519 * s, r.i[2][0] = a ? t + .5519 * i : t - .5519 * i, r.i[2][1] = e + s, 
            r.i[3][0] = a ? t - i : t + i, r.i[3][1] = e + .5519 * s, r.o[0][0] = a ? t + .5519 * i : t - .5519 * i, 
            r.o[0][1] = e - s, r.o[1][0] = a ? t + i : t - i, r.o[1][1] = e + .5519 * s, r.o[2][0] = a ? t - .5519 * i : t + .5519 * i, 
            r.o[2][1] = e + s, r.o[3][0] = a ? t - i : t + i, r.o[3][1] = e - .5519 * s;
          }
        }, extendPrototype([ DynamicPropertyContainer ], EllShapeProperty), EllShapeProperty;
      }(), i = function() {
        function StarShapeProperty(t, e) {
          this.v = L.newElement(), this.v.setPathData(!0, 0), this.elem = t, this.comp = t.comp, 
          this.data = e, this.frameId = -1, this.d = e.d, this.initDynamicPropertyContainer(t), 
          1 === e.sy ? (this.ir = b.getProp(t, e.ir, 0, 0, this), this.is = b.getProp(t, e.is, 0, .01, this), 
          this.convertToPath = this.convertStarToPath) : this.convertToPath = this.convertPolygonToPath, 
          this.pt = b.getProp(t, e.pt, 0, 0, this), this.p = b.getProp(t, e.p, 1, 0, this), 
          this.r = b.getProp(t, e.r, 0, m, this), this.or = b.getProp(t, e.or, 0, 0, this), 
          this.os = b.getProp(t, e.os, 0, .01, this), this.localShapeCollection = R.newShapeCollection(), 
          this.localShapeCollection.addShape(this.v), this.paths = this.localShapeCollection, 
          this.dynamicProperties.length ? this.k = !0 : (this.k = !1, this.convertToPath());
        }
        return StarShapeProperty.prototype = {
          reset: resetShape,
          getValue: function() {
            this.elem.globalData.frameId !== this.frameId && (this.frameId = this.elem.globalData.frameId, 
            this.iterateDynamicProperties(), this._mdf && this.convertToPath());
          },
          convertStarToPath: function() {
            var t, e, i, s, a = 2 * Math.floor(this.pt.v), r = 2 * Math.PI / a, n = !0, o = this.or.v, h = this.ir.v, l = this.os.v, p = this.is.v, f = 2 * Math.PI * o / (2 * a), m = 2 * Math.PI * h / (2 * a), d = -Math.PI / 2;
            d += this.r.v;
            var c = 3 === this.data.d ? -1 : 1;
            for (this.v._length = 0, t = 0; t < a; t += 1) {
              i = n ? l : p, s = n ? f : m;
              var u = (e = n ? o : h) * Math.cos(d), g = e * Math.sin(d), y = 0 === u && 0 === g ? 0 : g / Math.sqrt(u * u + g * g), v = 0 === u && 0 === g ? 0 : -u / Math.sqrt(u * u + g * g);
              u += +this.p.v[0], g += +this.p.v[1], this.v.setTripleAt(u, g, u - y * s * i * c, g - v * s * i * c, u + y * s * i * c, g + v * s * i * c, t, !0), 
              /*this.v.v[i] = [x,y];
                    this.v.i[i] = [x+ox*perimSegment*roundness*dir,y+oy*perimSegment*roundness*dir];
                    this.v.o[i] = [x-ox*perimSegment*roundness*dir,y-oy*perimSegment*roundness*dir];
                    this.v._length = numPts;*/
              n = !n, d += r * c;
            }
          },
          convertPolygonToPath: function() {
            var t, e = Math.floor(this.pt.v), i = 2 * Math.PI / e, s = this.or.v, a = this.os.v, r = 2 * Math.PI * s / (4 * e), n = -Math.PI / 2, o = 3 === this.data.d ? -1 : 1;
            for (n += this.r.v, this.v._length = 0, t = 0; t < e; t += 1) {
              var h = s * Math.cos(n), l = s * Math.sin(n), p = 0 === h && 0 === l ? 0 : l / Math.sqrt(h * h + l * l), f = 0 === h && 0 === l ? 0 : -h / Math.sqrt(h * h + l * l);
              h += +this.p.v[0], l += +this.p.v[1], this.v.setTripleAt(h, l, h - p * r * a * o, l - f * r * a * o, h + p * r * a * o, l + f * r * a * o, t, !0), 
              n += i * o;
            }
            this.paths.length = 0, this.paths[0] = this.v;
          }
        }, extendPrototype([ DynamicPropertyContainer ], StarShapeProperty), StarShapeProperty;
      }(), s = function() {
        function RectShapeProperty(t, e) {
          this.v = L.newElement(), this.v.c = !0, this.localShapeCollection = R.newShapeCollection(), 
          this.localShapeCollection.addShape(this.v), this.paths = this.localShapeCollection, 
          this.elem = t, this.comp = t.comp, this.frameId = -1, this.d = e.d, this.initDynamicPropertyContainer(t), 
          this.p = b.getProp(t, e.p, 1, 0, this), this.s = b.getProp(t, e.s, 1, 0, this), 
          this.r = b.getProp(t, e.r, 0, 0, this), this.dynamicProperties.length ? this.k = !0 : (this.k = !1, 
          this.convertRectToPath());
        }
        return RectShapeProperty.prototype = {
          convertRectToPath: function() {
            var t = this.p.v[0], e = this.p.v[1], i = this.s.v[0] / 2, s = this.s.v[1] / 2, a = l(i, s, this.r.v), r = a * (1 - .5519);
            this.v._length = 0, 2 === this.d || 1 === this.d ? (this.v.setTripleAt(t + i, e - s + a, t + i, e - s + a, t + i, e - s + r, 0, !0), 
            this.v.setTripleAt(t + i, e + s - a, t + i, e + s - r, t + i, e + s - a, 1, !0), 
            0 !== a ? (this.v.setTripleAt(t + i - a, e + s, t + i - a, e + s, t + i - r, e + s, 2, !0), 
            this.v.setTripleAt(t - i + a, e + s, t - i + r, e + s, t - i + a, e + s, 3, !0), 
            this.v.setTripleAt(t - i, e + s - a, t - i, e + s - a, t - i, e + s - r, 4, !0), 
            this.v.setTripleAt(t - i, e - s + a, t - i, e - s + r, t - i, e - s + a, 5, !0), 
            this.v.setTripleAt(t - i + a, e - s, t - i + a, e - s, t - i + r, e - s, 6, !0), 
            this.v.setTripleAt(t + i - a, e - s, t + i - r, e - s, t + i - a, e - s, 7, !0)) : (this.v.setTripleAt(t - i, e + s, t - i + r, e + s, t - i, e + s, 2), 
            this.v.setTripleAt(t - i, e - s, t - i, e - s + r, t - i, e - s, 3))) : (this.v.setTripleAt(t + i, e - s + a, t + i, e - s + r, t + i, e - s + a, 0, !0), 
            0 !== a ? (this.v.setTripleAt(t + i - a, e - s, t + i - a, e - s, t + i - r, e - s, 1, !0), 
            this.v.setTripleAt(t - i + a, e - s, t - i + r, e - s, t - i + a, e - s, 2, !0), 
            this.v.setTripleAt(t - i, e - s + a, t - i, e - s + a, t - i, e - s + r, 3, !0), 
            this.v.setTripleAt(t - i, e + s - a, t - i, e + s - r, t - i, e + s - a, 4, !0), 
            this.v.setTripleAt(t - i + a, e + s, t - i + a, e + s, t - i + r, e + s, 5, !0), 
            this.v.setTripleAt(t + i - a, e + s, t + i - r, e + s, t + i - a, e + s, 6, !0), 
            this.v.setTripleAt(t + i, e + s - a, t + i, e + s - a, t + i, e + s - r, 7, !0)) : (this.v.setTripleAt(t - i, e - s, t - i + r, e - s, t - i, e - s, 1, !0), 
            this.v.setTripleAt(t - i, e + s, t - i, e + s - r, t - i, e + s, 2, !0), this.v.setTripleAt(t + i, e + s, t + i - r, e + s, t + i, e + s, 3, !0)));
          },
          getValue: function(t) {
            this.elem.globalData.frameId !== this.frameId && (this.frameId = this.elem.globalData.frameId, 
            this.iterateDynamicProperties(), this._mdf && this.convertRectToPath());
          },
          reset: resetShape
        }, extendPrototype([ DynamicPropertyContainer ], RectShapeProperty), RectShapeProperty;
      }();
      return {
        getShapeProp: function(t, a, r) {
          var n;
          if (3 === r || 4 === r) {
            var o = 3 === r ? a.pt : a.ks, h = o.k;
            n = 1 === o.a || h.length ? new KeyframedShapeProperty(t, a, r) : new ShapeProperty(t, a, r);
          } else 5 === r ? n = new s(t, a) : 6 === r ? n = new e(t, a) : 7 === r && (n = new i(t, a));
          return n.k && t.addDynamicProperty(n), n;
        },
        getConstructorFunction: function() {
          return ShapeProperty;
        },
        getKeyframedConstructorFunction: function() {
          return KeyframedShapeProperty;
        }
      };
    }(), k = function() {
      var t = {}, e = {};
      return t.registerModifier = function(t, i) {
        e[t] || (e[t] = i);
      }, t.getModifier = function(t, i, s) {
        return new e[t](i, s);
      }, t;
    }();
    function ShapeModifier() {}
    function TrimModifier() {}
    function RoundCornersModifier() {}
    function RepeaterModifier() {}
    function ShapeCollection() {
      this._length = 0, this._maxLength = 4, this.shapes = createSizedArray(this._maxLength);
    }
    function DashProperty(t, e, i, s) {
      this.elem = t, this.frameId = -1, this.dataProps = createSizedArray(e.length), this.renderer = i, 
      this.k = !1, this.dashStr = "", this.dashArray = c("float32", e.length ? e.length - 1 : 0), 
      this.dashoffset = c("float32", 1), this.initDynamicPropertyContainer(s);
      var a, r, n = e.length || 0;
      for (a = 0; a < n; a += 1) r = b.getProp(t, e[a].v, 0, 0, this), this.k = r.k || this.k, 
      this.dataProps[a] = {
        n: e[a].n,
        p: r
      };
      this.k || this.getValue(!0), this._isAnimated = this.k;
    }
    function GradientProperty(t, e) {
      this.data = e, this.c = c("uint8c", 4 * e.p);
      var i = e.k.k[0].s ? e.k.k[0].s.length - 4 * e.p : e.k.k.length - 4 * e.p;
      this.o = c("float32", i), this._cmdf = !1, this._omdf = !1, this._collapsable = this.checkCollapsable(), 
      this._hasOpacity = i, this.initDynamicPropertyContainer(t), this.prop = b.getProp(t, e.k, 1, null, this), 
      this.k = this.prop.k, this.getValue(!0);
    }
    ShapeModifier.prototype.initModifierProperties = function() {}, ShapeModifier.prototype.addShapeToModifier = function() {}, 
    ShapeModifier.prototype.addShape = function(t) {
      if (!this.closed) {
        var e = {
          shape: t.sh,
          data: t,
          localShapeCollection: R.newShapeCollection()
        };
        this.shapes.push(e), this.addShapeToModifier(e), this._isAnimated && t.setAsAnimated();
      }
    }, ShapeModifier.prototype.init = function(t, e) {
      this.shapes = [], this.elem = t, this.initDynamicPropertyContainer(t), this.initModifierProperties(t, e), 
      this.frameId = a, this.closed = !1, this.k = !1, this.dynamicProperties.length ? this.k = !0 : this.getValue(!0);
    }, ShapeModifier.prototype.processKeys = function() {
      this.elem.globalData.frameId !== this.frameId && (this.frameId = this.elem.globalData.frameId, 
      this.iterateDynamicProperties());
    }, extendPrototype([ DynamicPropertyContainer ], ShapeModifier), extendPrototype([ ShapeModifier ], TrimModifier), 
    TrimModifier.prototype.initModifierProperties = function(t, e) {
      this.s = b.getProp(t, e.s, 0, .01, this), this.e = b.getProp(t, e.e, 0, .01, this), 
      this.o = b.getProp(t, e.o, 0, 0, this), this.sValue = 0, this.eValue = 0, this.getValue = this.processKeys, 
      this.m = e.m, this._isAnimated = !!this.s.effectsSequence.length || !!this.e.effectsSequence.length || !!this.o.effectsSequence.length;
    }, TrimModifier.prototype.addShapeToModifier = function(t) {
      t.pathsData = [];
    }, TrimModifier.prototype.calculateShapeEdges = function(t, e, i, s, a) {
      var r = [];
      e <= 1 ? r.push({
        s: t,
        e
      }) : t >= 1 ? r.push({
        s: t - 1,
        e: e - 1
      }) : (r.push({
        s: t,
        e: 1
      }), r.push({
        s: 0,
        e: e - 1
      }));
      var n, o, h = [], l = r.length;
      for (n = 0; n < l; n += 1) {
        var p, f;
        (o = r[n]).e * a < s || o.s * a > s + i || (p = o.s * a <= s ? 0 : (o.s * a - s) / i, 
        f = o.e * a >= s + i ? 1 : (o.e * a - s) / i, h.push([ p, f ]));
      }
      return h.length || h.push([ 0, 0 ]), h;
    }, TrimModifier.prototype.releasePathsData = function(t) {
      var e, i = t.length;
      for (e = 0; e < i; e += 1) G.release(t[e]);
      return t.length = 0, t;
    }, TrimModifier.prototype.processShapes = function(t) {
      var e, i, s;
      if (this._mdf || t) {
        var a = this.o.v % 360 / 360;
        if (a < 0 && (a += 1), (e = this.s.v + a) > (i = this.e.v + a)) {
          var r = e;
          e = i, i = r;
        }
        e = Math.round(1e3 * e) / 1e3, i = Math.round(1e3 * i) / 1e3, this.sValue = e, this.eValue = i;
      } else e = this.sValue, i = this.eValue;
      var n, o, h, l, p, f, m = this.shapes.length, d = 0;
      if (i === e) for (n = 0; n < m; n += 1) this.shapes[n].localShapeCollection.releaseShapes(), 
      this.shapes[n].shape._mdf = !0, this.shapes[n].shape.paths = this.shapes[n].localShapeCollection; else if (1 === i && 0 === e || 0 === i && 1 === e) {
        if (this._mdf) for (n = 0; n < m; n += 1) 
        //Releasign Trim Cached paths data when no trim applied in case shapes are modified inbetween.
        //Don't remove this even if it's losing cached info.
        this.shapes[n].pathsData.length = 0, this.shapes[n].shape._mdf = !0;
      } else {
        var c, u, g = [];
        for (n = 0; n < m; n += 1) 
        // if shape hasn't changed and trim properties haven't changed, cached previous path can be used
        if ((c = this.shapes[n]).shape._mdf || this._mdf || t || 2 === this.m) {
          if (h = (s = c.shape.paths)._length, f = 0, !c.shape._mdf && c.pathsData.length) f = c.totalShapeLength; else {
            for (l = this.releasePathsData(c.pathsData), o = 0; o < h; o += 1) p = y.getSegmentsLength(s.shapes[o]), 
            l.push(p), f += p.totalLength;
            c.totalShapeLength = f, c.pathsData = l;
          }
          d += f, c.shape._mdf = !0;
        } else c.shape.paths = c.localShapeCollection;
        var v, S = e, b = i, P = 0;
        for (n = m - 1; n >= 0; n -= 1) if ((c = this.shapes[n]).shape._mdf) {
          for ((u = c.localShapeCollection).releaseShapes(), 
          //if m === 2 means paths are trimmed individually so edges need to be found for this specific shape relative to whoel group
          2 === this.m && m > 1 ? (v = this.calculateShapeEdges(e, i, c.totalShapeLength, P, d), 
          P += c.totalShapeLength) : v = [ [ S, b ] ], h = v.length, o = 0; o < h; o += 1) {
            S = v[o][0], b = v[o][1], g.length = 0, b <= 1 ? g.push({
              s: c.totalShapeLength * S,
              e: c.totalShapeLength * b
            }) : S >= 1 ? g.push({
              s: c.totalShapeLength * (S - 1),
              e: c.totalShapeLength * (b - 1)
            }) : (g.push({
              s: c.totalShapeLength * S,
              e: c.totalShapeLength
            }), g.push({
              s: 0,
              e: c.totalShapeLength * (b - 1)
            }));
            var _ = this.addShapes(c, g[0]);
            if (g[0].s !== g[0].e) {
              if (g.length > 1) if (c.shape.v.c) {
                var k = _.pop();
                this.addPaths(_, u), _ = this.addShapes(c, g[1], k);
              } else this.addPaths(_, u), _ = this.addShapes(c, g[1]);
              this.addPaths(_, u);
            }
          }
          c.shape.paths = u;
        }
      }
    }, TrimModifier.prototype.addPaths = function(t, e) {
      var i, s = t.length;
      for (i = 0; i < s; i += 1) e.addShape(t[i]);
    }, TrimModifier.prototype.addSegment = function(t, e, i, s, a, r, n) {
      a.setXYAt(e[0], e[1], "o", r), a.setXYAt(i[0], i[1], "i", r + 1), n && a.setXYAt(t[0], t[1], "v", r), 
      a.setXYAt(s[0], s[1], "v", r + 1);
    }, TrimModifier.prototype.addSegmentFromArray = function(t, e, i, s) {
      e.setXYAt(t[1], t[5], "o", i), e.setXYAt(t[2], t[6], "i", i + 1), s && e.setXYAt(t[0], t[4], "v", i), 
      e.setXYAt(t[3], t[7], "v", i + 1);
    }, TrimModifier.prototype.addShapes = function(t, e, i) {
      var s, a, r, n, o, h, l, p, f = t.pathsData, m = t.shape.paths.shapes, d = t.shape.paths._length, c = 0, u = [], g = !0;
      for (i ? (o = i._length, p = i._length) : (i = L.newElement(), o = 0, p = 0), u.push(i), 
      s = 0; s < d; s += 1) {
        for (h = f[s].lengths, i.c = m[s].c, r = m[s].c ? h.length : h.length + 1, a = 1; a < r; a += 1) if (c + (n = h[a - 1]).addedLength < e.s) c += n.addedLength, 
        i.c = !1; else {
          if (c > e.e) {
            i.c = !1;
            break;
          }
          e.s <= c && e.e >= c + n.addedLength ? (this.addSegment(m[s].v[a - 1], m[s].o[a - 1], m[s].i[a], m[s].v[a], i, o, g), 
          g = !1) : (l = y.getNewSegment(m[s].v[a - 1], m[s].v[a], m[s].o[a - 1], m[s].i[a], (e.s - c) / n.addedLength, (e.e - c) / n.addedLength, h[a - 1]), 
          this.addSegmentFromArray(l, i, o, g), 
          // this.addSegment(segment.pt1, segment.pt3, segment.pt4, segment.pt2, shapePath, segmentCount, newShape);
          g = !1, i.c = !1), c += n.addedLength, o += 1;
        }
        if (m[s].c && h.length) {
          if (n = h[a - 1], c <= e.e) {
            var v = h[a - 1].addedLength;
            e.s <= c && e.e >= c + v ? (this.addSegment(m[s].v[a - 1], m[s].o[a - 1], m[s].i[0], m[s].v[0], i, o, g), 
            g = !1) : (l = y.getNewSegment(m[s].v[a - 1], m[s].v[0], m[s].o[a - 1], m[s].i[0], (e.s - c) / v, (e.e - c) / v, h[a - 1]), 
            this.addSegmentFromArray(l, i, o, g), 
            // this.addSegment(segment.pt1, segment.pt3, segment.pt4, segment.pt2, shapePath, segmentCount, newShape);
            g = !1, i.c = !1);
          } else i.c = !1;
          c += n.addedLength, o += 1;
        }
        if (i._length && (i.setXYAt(i.v[p][0], i.v[p][1], "i", p), i.setXYAt(i.v[i._length - 1][0], i.v[i._length - 1][1], "o", i._length - 1)), 
        c > e.e) break;
        s < d - 1 && (i = L.newElement(), g = !0, u.push(i), o = 0);
      }
      return u;
    }, k.registerModifier("tm", TrimModifier), extendPrototype([ ShapeModifier ], RoundCornersModifier), 
    RoundCornersModifier.prototype.initModifierProperties = function(t, e) {
      this.getValue = this.processKeys, this.rd = b.getProp(t, e.r, 0, null, this), this._isAnimated = !!this.rd.effectsSequence.length;
    }, RoundCornersModifier.prototype.processPath = function(t, e) {
      var i = L.newElement();
      i.c = t.c;
      var s, a, r, n, o, h, l, p, f, m, d, c, u, g = t._length, y = 0;
      for (s = 0; s < g; s += 1) a = t.v[s], n = t.o[s], r = t.i[s], a[0] === n[0] && a[1] === n[1] && a[0] === r[0] && a[1] === r[1] ? 0 !== s && s !== g - 1 || t.c ? (o = 0 === s ? t.v[g - 1] : t.v[s - 1], 
      l = (h = Math.sqrt(Math.pow(a[0] - o[0], 2) + Math.pow(a[1] - o[1], 2))) ? Math.min(h / 2, e) / h : 0, 
      p = c = a[0] + (o[0] - a[0]) * l, f = u = a[1] - (a[1] - o[1]) * l, m = p - .5519 * (p - a[0]), 
      d = f - .5519 * (f - a[1]), i.setTripleAt(p, f, m, d, c, u, y), y += 1, o = s === g - 1 ? t.v[0] : t.v[s + 1], 
      l = (h = Math.sqrt(Math.pow(a[0] - o[0], 2) + Math.pow(a[1] - o[1], 2))) ? Math.min(h / 2, e) / h : 0, 
      p = m = a[0] + (o[0] - a[0]) * l, f = d = a[1] + (o[1] - a[1]) * l, c = p - .5519 * (p - a[0]), 
      u = f - .5519 * (f - a[1]), i.setTripleAt(p, f, m, d, c, u, y), y += 1) : (i.setTripleAt(a[0], a[1], n[0], n[1], r[0], r[1], y), 
      /*cloned_path.v[index] = currentV;
                cloned_path.o[index] = currentO;
                cloned_path.i[index] = currentI;*/
      y += 1) : (i.setTripleAt(t.v[s][0], t.v[s][1], t.o[s][0], t.o[s][1], t.i[s][0], t.i[s][1], y), 
      y += 1);
      return i;
    }, RoundCornersModifier.prototype.processShapes = function(t) {
      var e, i, s, a, r, n, o = this.shapes.length, h = this.rd.v;
      if (0 !== h) for (i = 0; i < o; i += 1) {
        if ((r = this.shapes[i]).shape.paths, n = r.localShapeCollection, r.shape._mdf || this._mdf || t) for (n.releaseShapes(), 
        r.shape._mdf = !0, e = r.shape.paths.shapes, a = r.shape.paths._length, s = 0; s < a; s += 1) n.addShape(this.processPath(e[s], h));
        r.shape.paths = r.localShapeCollection;
      }
      this.dynamicProperties.length || (this._mdf = !1);
    }, k.registerModifier("rd", RoundCornersModifier), extendPrototype([ ShapeModifier ], RepeaterModifier), 
    RepeaterModifier.prototype.initModifierProperties = function(t, e) {
      this.getValue = this.processKeys, this.c = b.getProp(t, e.c, 0, null, this), this.o = b.getProp(t, e.o, 0, null, this), 
      this.tr = P.getTransformProperty(t, e.tr, this), this.data = e, this.dynamicProperties.length || this.getValue(!0), 
      this._isAnimated = !!this.dynamicProperties.length, this.pMatrix = new u(), this.rMatrix = new u(), 
      this.sMatrix = new u(), this.tMatrix = new u(), this.matrix = new u();
    }, RepeaterModifier.prototype.applyTransforms = function(t, e, i, s, a, r) {
      var n = r ? -1 : 1, o = s.s.v[0] + (1 - s.s.v[0]) * (1 - a), h = s.s.v[1] + (1 - s.s.v[1]) * (1 - a);
      t.translate(s.p.v[0] * n * a, s.p.v[1] * n * a, s.p.v[2]), e.translate(-s.a.v[0], -s.a.v[1], s.a.v[2]), 
      e.rotate(-s.r.v * n * a), e.translate(s.a.v[0], s.a.v[1], s.a.v[2]), i.translate(-s.a.v[0], -s.a.v[1], s.a.v[2]), 
      i.scale(r ? 1 / o : o, r ? 1 / h : h), i.translate(s.a.v[0], s.a.v[1], s.a.v[2]);
    }, RepeaterModifier.prototype.init = function(t, e, i, s) {
      for (this.elem = t, this.arr = e, this.pos = i, this.elemsData = s, this._currentCopies = 0, 
      this._elements = [], this._groups = [], this.frameId = -1, this.initDynamicPropertyContainer(t), 
      this.initModifierProperties(t, e[i]); i > 0; ) i -= 1, 
      //this._elements.unshift(arr.splice(pos,1)[0]);
      this._elements.unshift(e[i]);
      this.dynamicProperties.length ? this.k = !0 : this.getValue(!0);
    }, RepeaterModifier.prototype.resetElements = function(t) {
      var e, i = t.length;
      for (e = 0; e < i; e += 1) t[e]._processed = !1, "gr" === t[e].ty && this.resetElements(t[e].it);
    }, RepeaterModifier.prototype.cloneElements = function(t) {
      t.length;
      var e = JSON.parse(JSON.stringify(t));
      return this.resetElements(e), e;
    }, RepeaterModifier.prototype.changeGroupRender = function(t, e) {
      var i, s = t.length;
      for (i = 0; i < s; i += 1) t[i]._render = e, "gr" === t[i].ty && this.changeGroupRender(t[i].it, e);
    }, RepeaterModifier.prototype.processShapes = function(t) {
      var e, i, s, a, r;
      if (this._mdf || t) {
        var n, o = Math.ceil(this.c.v);
        if (this._groups.length < o) {
          for (;this._groups.length < o; ) {
            var h = {
              it: this.cloneElements(this._elements),
              ty: "gr"
            };
            h.it.push({
              a: {
                a: 0,
                ix: 1,
                k: [ 0, 0 ]
              },
              nm: "Transform",
              o: {
                a: 0,
                ix: 7,
                k: 100
              },
              p: {
                a: 0,
                ix: 2,
                k: [ 0, 0 ]
              },
              r: {
                a: 1,
                ix: 6,
                k: [ {
                  s: 0,
                  e: 0,
                  t: 0
                }, {
                  s: 0,
                  e: 0,
                  t: 1
                } ]
              },
              s: {
                a: 0,
                ix: 3,
                k: [ 100, 100 ]
              },
              sa: {
                a: 0,
                ix: 5,
                k: 0
              },
              sk: {
                a: 0,
                ix: 4,
                k: 0
              },
              ty: "tr"
            }), this.arr.splice(0, 0, h), this._groups.splice(0, 0, h), this._currentCopies += 1;
          }
          this.elem.reloadShapes();
        }
        for (r = 0, s = 0; s <= this._groups.length - 1; s += 1) n = r < o, this._groups[s]._render = n, 
        this.changeGroupRender(this._groups[s].it, n), r += 1;
        this._currentCopies = o;
        ////
        var l = this.o.v, p = l % 1, f = l > 0 ? Math.floor(l) : Math.ceil(l), m = (this.tr.v.props, 
        this.pMatrix.props), d = this.rMatrix.props, c = this.sMatrix.props;
        this.pMatrix.reset(), this.rMatrix.reset(), this.sMatrix.reset(), this.tMatrix.reset(), 
        this.matrix.reset();
        var u, g, y = 0;
        if (l > 0) {
          for (;y < f; ) this.applyTransforms(this.pMatrix, this.rMatrix, this.sMatrix, this.tr, 1, !1), 
          y += 1;
          p && (this.applyTransforms(this.pMatrix, this.rMatrix, this.sMatrix, this.tr, p, !1), 
          y += p);
        } else if (l < 0) {
          for (;y > f; ) this.applyTransforms(this.pMatrix, this.rMatrix, this.sMatrix, this.tr, 1, !0), 
          y -= 1;
          p && (this.applyTransforms(this.pMatrix, this.rMatrix, this.sMatrix, this.tr, -p, !0), 
          y -= p);
        }
        for (s = 1 === this.data.m ? 0 : this._currentCopies - 1, a = 1 === this.data.m ? 1 : -1, 
        r = this._currentCopies; r; ) {
          if (g = (i = (e = this.elemsData[s].it)[e.length - 1].transform.mProps.v.props).length, 
          e[e.length - 1].transform.mProps._mdf = !0, e[e.length - 1].transform.op._mdf = !0, 
          0 !== y) {
            for ((0 !== s && 1 === a || s !== this._currentCopies - 1 && -1 === a) && this.applyTransforms(this.pMatrix, this.rMatrix, this.sMatrix, this.tr, 1, !1), 
            this.matrix.transform(d[0], d[1], d[2], d[3], d[4], d[5], d[6], d[7], d[8], d[9], d[10], d[11], d[12], d[13], d[14], d[15]), 
            this.matrix.transform(c[0], c[1], c[2], c[3], c[4], c[5], c[6], c[7], c[8], c[9], c[10], c[11], c[12], c[13], c[14], c[15]), 
            this.matrix.transform(m[0], m[1], m[2], m[3], m[4], m[5], m[6], m[7], m[8], m[9], m[10], m[11], m[12], m[13], m[14], m[15]), 
            u = 0; u < g; u += 1) i[u] = this.matrix.props[u];
            this.matrix.reset();
          } else for (this.matrix.reset(), u = 0; u < g; u += 1) i[u] = this.matrix.props[u];
          y += 1, r -= 1, s += a;
        }
      } else for (r = this._currentCopies, s = 0, a = 1; r; ) i = (e = this.elemsData[s].it)[e.length - 1].transform.mProps.v.props, 
      e[e.length - 1].transform.mProps._mdf = !1, e[e.length - 1].transform.op._mdf = !1, 
      r -= 1, s += a;
    }, RepeaterModifier.prototype.addShape = function() {}, k.registerModifier("rp", RepeaterModifier), 
    ShapeCollection.prototype.addShape = function(t) {
      this._length === this._maxLength && (this.shapes = this.shapes.concat(createSizedArray(this._maxLength)), 
      this._maxLength *= 2), this.shapes[this._length] = t, this._length += 1;
    }, ShapeCollection.prototype.releaseShapes = function() {
      var t;
      for (t = 0; t < this._length; t += 1) L.release(this.shapes[t]);
      this._length = 0;
    }, DashProperty.prototype.getValue = function(t) {
      if ((this.elem.globalData.frameId !== this.frameId || t) && (this.frameId = this.elem.globalData.frameId, 
      this.iterateDynamicProperties(), this._mdf = this._mdf || t, this._mdf)) {
        var e = 0, i = this.dataProps.length;
        for ("svg" === this.renderer && (this.dashStr = ""), e = 0; e < i; e += 1) "o" != this.dataProps[e].n ? "svg" === this.renderer ? this.dashStr += " " + this.dataProps[e].p.v : this.dashArray[e] = this.dataProps[e].p.v : this.dashoffset[0] = this.dataProps[e].p.v;
      }
    }, extendPrototype([ DynamicPropertyContainer ], DashProperty), GradientProperty.prototype.comparePoints = function(t, e) {
      for (var i = 0, s = this.o.length / 2; i < s; ) {
        if (Math.abs(t[4 * i] - t[4 * e + 2 * i]) > .01) return !1;
        i += 1;
      }
      return !0;
    }, GradientProperty.prototype.checkCollapsable = function() {
      if (this.o.length / 2 != this.c.length / 4) return !1;
      if (this.data.k.k[0].s) for (var t = 0, e = this.data.k.k.length; t < e; ) {
        if (!this.comparePoints(this.data.k.k[t].s, this.data.p)) return !1;
        t += 1;
      } else if (!this.comparePoints(this.data.k.k, this.data.p)) return !1;
      return !0;
    }, GradientProperty.prototype.getValue = function(t) {
      if (this.prop.getValue(), this._mdf = !1, this._cmdf = !1, this._omdf = !1, this.prop._mdf || t) {
        var e, i, s, a = 4 * this.data.p;
        for (e = 0; e < a; e += 1) i = e % 4 == 0 ? 100 : 255, s = Math.round(this.prop.v[e] * i), 
        this.c[e] !== s && (this.c[e] = s, this._cmdf = !t);
        if (this.o.length) for (a = this.prop.v.length, e = 4 * this.data.p; e < a; e += 1) i = e % 2 == 0 ? 100 : 1, 
        s = e % 2 == 0 ? Math.round(100 * this.prop.v[e]) : this.prop.v[e], this.o[e - 4 * this.data.p] !== s && (this.o[e - 4 * this.data.p] = s, 
        this._omdf = !t);
        this._mdf = !t;
      }
    }, extendPrototype([ DynamicPropertyContainer ], GradientProperty);
    var A, E = function(t, e, i, s) {
      if (0 === e) return "";
      var a, r = t.o, n = t.i, o = t.v, h = " M" + s.applyToPointStringified(o[0][0], o[0][1]);
      for (a = 1; a < e; a += 1) h += " C" + s.applyToPointStringified(r[a - 1][0], r[a - 1][1]) + " " + s.applyToPointStringified(n[a][0], n[a][1]) + " " + s.applyToPointStringified(o[a][0], o[a][1]);
      return i && e && (h += " C" + s.applyToPointStringified(r[a - 1][0], r[a - 1][1]) + " " + s.applyToPointStringified(n[0][0], n[0][1]) + " " + s.applyToPointStringified(o[0][0], o[0][1]), 
      h += "z"), h;
    }, M = function() {
      function imageLoaded() {
        this.loadedAssets += 1, this.loadedAssets === this.totalImages && this.imagesLoadedCb && this.imagesLoadedCb(null);
      }
      function getAssetsPath(t) {
        var e = "";
        if (t.e) e = t.p; else if (this.assetsPath) {
          var i = t.p;
          -1 !== i.indexOf("images/") && (i = i.split("/")[1]), e = this.assetsPath + i;
        } else e = this.path, e += t.u ? t.u : "", e += t.p;
        return e;
      }
      function loadImage(t) {
        var e = createTag("img");
        e.addEventListener("load", imageLoaded.bind(this), !1), e.addEventListener("error", imageLoaded.bind(this), !1), 
        e.src = t;
      }
      function loadAssets(t, e) {
        var i;
        for (this.imagesLoadedCb = e, this.totalAssets = t.length, i = 0; i < this.totalAssets; i += 1) t[i].layers || (loadImage.bind(this)(getAssetsPath.bind(this)(t[i])), 
        this.totalImages += 1);
      }
      function setPath(t) {
        this.path = t || "";
      }
      function setAssetsPath(t) {
        this.assetsPath = t || "";
      }
      function destroy() {
        this.imagesLoadedCb = null;
      }
      return function() {
        this.loadAssets = loadAssets, this.setAssetsPath = setAssetsPath, this.setPath = setPath, 
        this.destroy = destroy, this.assetsPath = "", this.path = "", this.totalAssets = 0, 
        this.totalImages = 0, this.loadedAssets = 0, this.imagesLoadedCb = null;
      };
    }(), x = (A = {
      maskType: !0
    }, (/MSIE 10/i.test(navigator.userAgent) || /MSIE 9/i.test(navigator.userAgent) || /rv:11.0/i.test(navigator.userAgent) || /Edge\/\d./i.test(navigator.userAgent)) && (A.maskType = !1), 
    A), C = function() {
      var t = {
        createFilter: function(t) {
          var e = createNS("filter");
          return e.setAttribute("id", t), e.setAttribute("filterUnits", "objectBoundingBox"), 
          e.setAttribute("x", "0%"), e.setAttribute("y", "0%"), e.setAttribute("width", "100%"), 
          e.setAttribute("height", "100%"), e;
        },
        createAlphaToLuminanceFilter: function() {
          var t = createNS("feColorMatrix");
          return t.setAttribute("type", "matrix"), t.setAttribute("color-interpolation-filters", "sRGB"), 
          t.setAttribute("values", "0 0 0 1 0  0 0 0 1 0  0 0 0 1 0  0 0 0 1 1"), t;
        }
      };
      return t;
    }(), D = function() {
      function formatResponse(t) {
        return t.response && "object" == typeof t.response ? t.response : t.response && "string" == typeof t.response ? JSON.parse(t.response) : t.responseText ? JSON.parse(t.response) : void 0;
      }
      return {
        load: function(t, e, i) {
          var s, a = new XMLHttpRequest();
          a.open("GET", t, !0), 
          // set responseType after calling open or IE will break.
          a.responseType = "json", a.send(), a.onreadystatechange = function() {
            if (4 == a.readyState) if (200 == a.status) s = formatResponse(a), e(s); else try {
              s = formatResponse(a), e(s);
            } catch (t) {
              i && i(t);
            }
          };
        }
      };
    }();
    function TextAnimatorProperty(t, e, i) {
      this._isFirstFrame = !0, this._hasMaskedPath = !1, this._frameId = -1, this._textData = t, 
      this._renderType = e, this._elem = i, this._animatorsData = createSizedArray(this._textData.a.length), 
      this._pathData = {}, this._moreOptions = {
        alignment: {}
      }, this.renderedLetters = [], this.lettersChangedFlag = !1, this.initDynamicPropertyContainer(i);
    }
    function TextAnimatorDataProperty(t, e, i) {
      var s = {
        propType: !1
      }, a = b.getProp, r = e.a;
      this.a = {
        r: r.r ? a(t, r.r, 0, m, i) : s,
        rx: r.rx ? a(t, r.rx, 0, m, i) : s,
        ry: r.ry ? a(t, r.ry, 0, m, i) : s,
        sk: r.sk ? a(t, r.sk, 0, m, i) : s,
        sa: r.sa ? a(t, r.sa, 0, m, i) : s,
        s: r.s ? a(t, r.s, 1, .01, i) : s,
        a: r.a ? a(t, r.a, 1, 0, i) : s,
        o: r.o ? a(t, r.o, 0, .01, i) : s,
        p: r.p ? a(t, r.p, 1, 0, i) : s,
        sw: r.sw ? a(t, r.sw, 0, 0, i) : s,
        sc: r.sc ? a(t, r.sc, 1, 0, i) : s,
        fc: r.fc ? a(t, r.fc, 1, 0, i) : s,
        fh: r.fh ? a(t, r.fh, 0, 0, i) : s,
        fs: r.fs ? a(t, r.fs, 0, .01, i) : s,
        fb: r.fb ? a(t, r.fb, 0, .01, i) : s,
        t: r.t ? a(t, r.t, 0, 0, i) : s
      }, this.s = F.getTextSelectorProp(t, e.s, i), this.s.t = e.s.t;
    }
    function LetterProps(t, e, i, s, a, r) {
      this.o = t, this.sw = e, this.sc = i, this.fc = s, this.m = a, this.p = r, this._mdf = {
        o: !0,
        sw: !!e,
        sc: !!i,
        fc: !!s,
        m: !0,
        p: !0
      };
    }
    function TextProperty(t, e) {
      this._frameId = a, this.pv = "", this.v = "", this.kf = !1, this._isFirstFrame = !0, 
      this._mdf = !1, this.data = e, this.elem = t, this.comp = this.elem.comp, this.keysIndex = 0, 
      this.canResize = !1, this.minimumFontSize = 1, this.effectsSequence = [], this.currentData = {
        ascent: 0,
        boxWidth: this.defaultBoxWidth,
        f: "",
        fStyle: "",
        fWeight: "",
        fc: "",
        j: "",
        justifyOffset: "",
        l: [],
        lh: 0,
        lineWidths: [],
        ls: "",
        of: "",
        s: "",
        sc: "",
        sw: 0,
        t: 0,
        tr: 0,
        sz: 0,
        ps: null,
        fillColorAnim: !1,
        strokeColorAnim: !1,
        strokeWidthAnim: !1,
        yOffset: 0,
        finalSize: 0,
        finalText: [],
        finalLineHeight: 0,
        __complete: !1
      }, this.copyData(this.currentData, this.data.d.k[0].s), this.searchProperty() || this.completeTextData(this.currentData);
    }
    TextAnimatorProperty.prototype.searchProperties = function() {
      var t, e, i = this._textData.a.length, s = b.getProp;
      for (t = 0; t < i; t += 1) e = this._textData.a[t], this._animatorsData[t] = new TextAnimatorDataProperty(this._elem, e, this);
      this._textData.p && "m" in this._textData.p ? (this._pathData = {
        f: s(this._elem, this._textData.p.f, 0, 0, this),
        l: s(this._elem, this._textData.p.l, 0, 0, this),
        r: this._textData.p.r,
        m: this._elem.maskManager.getMaskProperty(this._textData.p.m)
      }, this._hasMaskedPath = !0) : this._hasMaskedPath = !1, this._moreOptions.alignment = s(this._elem, this._textData.m.a, 1, 0, this);
    }, TextAnimatorProperty.prototype.getMeasures = function(t, e) {
      if (this.lettersChangedFlag = e, this._mdf || this._isFirstFrame || e || this._hasMaskedPath && this._pathData.m._mdf) {
        this._isFirstFrame = !1;
        var i, s, a, r, n, o, h, l, p, f, m, d, c, u, g, v, S, b, P, _ = this._moreOptions.alignment.v, k = this._animatorsData, A = this._textData, E = this.mHelper, M = this._renderType, x = this.renderedLetters.length, C = (this.data, 
        t.l);
        if (this._hasMaskedPath) {
          if (P = this._pathData.m, !this._pathData.n || this._pathData._mdf) {
            var D, T = P.v;
            for (this._pathData.r && (T = T.reverse()), 
            // TODO: release bezier data cached from previous pathInfo: this._pathData.pi
            n = {
              tLength: 0,
              segments: []
            }, r = T._length - 1, v = 0, a = 0; a < r; a += 1) D = {
              s: T.v[a],
              e: T.v[a + 1],
              to: [ T.o[a][0] - T.v[a][0], T.o[a][1] - T.v[a][1] ],
              ti: [ T.i[a + 1][0] - T.v[a + 1][0], T.i[a + 1][1] - T.v[a + 1][1] ]
            }, y.buildBezierData(D), n.tLength += D.bezierData.segmentLength, n.segments.push(D), 
            v += D.bezierData.segmentLength;
            a = r, P.v.c && (D = {
              s: T.v[a],
              e: T.v[0],
              to: [ T.o[a][0] - T.v[a][0], T.o[a][1] - T.v[a][1] ],
              ti: [ T.i[0][0] - T.v[0][0], T.i[0][1] - T.v[0][1] ]
            }, y.buildBezierData(D), n.tLength += D.bezierData.segmentLength, n.segments.push(D), 
            v += D.bezierData.segmentLength), this._pathData.pi = n;
          }
          if (n = this._pathData.pi, o = this._pathData.f.v, m = 0, f = 1, l = 0, p = !0, 
          u = n.segments, o < 0 && P.v.c) for (n.tLength < Math.abs(o) && (o = -Math.abs(o) % n.tLength), 
          f = (c = u[m = u.length - 1].bezierData.points).length - 1; o < 0; ) o += c[f].partialLength, 
          (f -= 1) < 0 && (f = (c = u[m -= 1].bezierData.points).length - 1);
          d = (c = u[m].bezierData.points)[f - 1], g = (h = c[f]).partialLength;
        }
        r = C.length, i = 0, s = 0;
        var F, w, I, V, L = 1.2 * t.finalSize * .714, R = !0;
        I = k.length;
        var G, N, B, z, O, q, j, H, W, X, Y, K, U, Z = -1, J = o, Q = m, $ = f, tt = -1, et = "", it = this.defaultPropsArray;
        //
        if (2 === t.j || 1 === t.j) {
          var st = 0, at = 0, rt = 2 === t.j ? -.5 : -1, nt = 0, ot = !0;
          for (a = 0; a < r; a += 1) if (C[a].n) {
            for (st && (st += at); nt < a; ) C[nt].animatorJustifyOffset = st, nt += 1;
            st = 0, ot = !0;
          } else {
            for (w = 0; w < I; w += 1) (F = k[w].a).t.propType && (ot && 2 === t.j && (at += F.t.v * rt), 
            (G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars)).length ? st += F.t.v * G[0] * rt : st += F.t.v * G * rt);
            ot = !1;
          }
          for (st && (st += at); nt < a; ) C[nt].animatorJustifyOffset = st, nt += 1;
        }
        //
                for (a = 0; a < r; a += 1) {
          if (E.reset(), O = 1, C[a].n) i = 0, s += t.yOffset, s += R ? 1 : 0, o = J, R = !1, 
          this._hasMaskedPath && (f = $, d = (c = u[m = Q].bezierData.points)[f - 1], g = (h = c[f]).partialLength, 
          l = 0), U = X = K = et = "", it = this.defaultPropsArray; else {
            if (this._hasMaskedPath) {
              if (tt !== C[a].line) {
                switch (t.j) {
                 case 1:
                  o += v - t.lineWidths[C[a].line];
                  break;

                 case 2:
                  o += (v - t.lineWidths[C[a].line]) / 2;
                }
                tt = C[a].line;
              }
              Z !== C[a].ind && (C[Z] && (o += C[Z].extra), o += C[a].an / 2, Z = C[a].ind), o += _[0] * C[a].an / 200;
              var ht = 0;
              for (w = 0; w < I; w += 1) (F = k[w].a).p.propType && ((G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars)).length ? ht += F.p.v[0] * G[0] : ht += F.p.v[0] * G), 
              F.a.propType && ((G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars)).length ? ht += F.a.v[0] * G[0] : ht += F.a.v[0] * G);
              for (p = !0; p; ) l + g >= o + ht || !c ? (S = (o + ht - l) / h.partialLength, B = d.point[0] + (h.point[0] - d.point[0]) * S, 
              z = d.point[1] + (h.point[1] - d.point[1]) * S, E.translate(-_[0] * C[a].an / 200, -_[1] * L / 100), 
              p = !1) : c && (l += h.partialLength, (f += 1) >= c.length && (f = 0, u[m += 1] ? c = u[m].bezierData.points : P.v.c ? (f = 0, 
              c = u[m = 0].bezierData.points) : (l -= h.partialLength, c = null)), c && (d = h, 
              g = (h = c[f]).partialLength));
              N = C[a].an / 2 - C[a].add, E.translate(-N, 0, 0);
            } else N = C[a].an / 2 - C[a].add, E.translate(-N, 0, 0), 
            // Grouping alignment
            E.translate(-_[0] * C[a].an / 200, -_[1] * L / 100, 0);
            for (C[a].l, w = 0; w < I; w += 1) (F = k[w].a).t.propType && (G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars), 
            //This condition is to prevent applying tracking to first character in each line. Might be better to use a boolean "isNewLine"
            0 === i && 0 === t.j || (this._hasMaskedPath ? G.length ? o += F.t.v * G[0] : o += F.t.v * G : G.length ? i += F.t.v * G[0] : i += F.t.v * G));
            for (C[a].l, t.strokeWidthAnim && (j = t.sw || 0), t.strokeColorAnim && (q = t.sc ? [ t.sc[0], t.sc[1], t.sc[2] ] : [ 0, 0, 0 ]), 
            t.fillColorAnim && t.fc && (H = [ t.fc[0], t.fc[1], t.fc[2] ]), w = 0; w < I; w += 1) (F = k[w].a).a.propType && ((G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars)).length ? E.translate(-F.a.v[0] * G[0], -F.a.v[1] * G[1], F.a.v[2] * G[2]) : E.translate(-F.a.v[0] * G, -F.a.v[1] * G, F.a.v[2] * G));
            for (w = 0; w < I; w += 1) (F = k[w].a).s.propType && ((G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars)).length ? E.scale(1 + (F.s.v[0] - 1) * G[0], 1 + (F.s.v[1] - 1) * G[1], 1) : E.scale(1 + (F.s.v[0] - 1) * G, 1 + (F.s.v[1] - 1) * G, 1));
            for (w = 0; w < I; w += 1) {
              if (F = k[w].a, G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars), F.sk.propType && (G.length ? E.skewFromAxis(-F.sk.v * G[0], F.sa.v * G[1]) : E.skewFromAxis(-F.sk.v * G, F.sa.v * G)), 
              F.r.propType && (G.length ? E.rotateZ(-F.r.v * G[2]) : E.rotateZ(-F.r.v * G)), F.ry.propType && (G.length ? E.rotateY(F.ry.v * G[1]) : E.rotateY(F.ry.v * G)), 
              F.rx.propType && (G.length ? E.rotateX(F.rx.v * G[0]) : E.rotateX(F.rx.v * G)), 
              F.o.propType && (G.length ? O += (F.o.v * G[0] - O) * G[0] : O += (F.o.v * G - O) * G), 
              t.strokeWidthAnim && F.sw.propType && (G.length ? j += F.sw.v * G[0] : j += F.sw.v * G), 
              t.strokeColorAnim && F.sc.propType) for (W = 0; W < 3; W += 1) G.length ? q[W] = q[W] + (F.sc.v[W] - q[W]) * G[0] : q[W] = q[W] + (F.sc.v[W] - q[W]) * G;
              if (t.fillColorAnim && t.fc) {
                if (F.fc.propType) for (W = 0; W < 3; W += 1) G.length ? H[W] = H[W] + (F.fc.v[W] - H[W]) * G[0] : H[W] = H[W] + (F.fc.v[W] - H[W]) * G;
                F.fh.propType && (H = G.length ? addHueToRGB(H, F.fh.v * G[0]) : addHueToRGB(H, F.fh.v * G)), 
                F.fs.propType && (H = G.length ? addSaturationToRGB(H, F.fs.v * G[0]) : addSaturationToRGB(H, F.fs.v * G)), 
                F.fb.propType && (H = G.length ? addBrightnessToRGB(H, F.fb.v * G[0]) : addBrightnessToRGB(H, F.fb.v * G));
              }
            }
            for (w = 0; w < I; w += 1) (F = k[w].a).p.propType && (G = k[w].s.getMult(C[a].anIndexes[w], A.a[w].s.totalChars), 
            this._hasMaskedPath ? G.length ? E.translate(0, F.p.v[1] * G[0], -F.p.v[2] * G[1]) : E.translate(0, F.p.v[1] * G, -F.p.v[2] * G) : G.length ? E.translate(F.p.v[0] * G[0], F.p.v[1] * G[1], -F.p.v[2] * G[2]) : E.translate(F.p.v[0] * G, F.p.v[1] * G, -F.p.v[2] * G));
            if (t.strokeWidthAnim && (X = j < 0 ? 0 : j), t.strokeColorAnim && (Y = "rgb(" + Math.round(255 * q[0]) + "," + Math.round(255 * q[1]) + "," + Math.round(255 * q[2]) + ")"), 
            t.fillColorAnim && t.fc && (K = "rgb(" + Math.round(255 * H[0]) + "," + Math.round(255 * H[1]) + "," + Math.round(255 * H[2]) + ")"), 
            this._hasMaskedPath) {
              if (E.translate(0, -t.ls), E.translate(0, _[1] * L / 100 + s, 0), A.p.p) {
                b = (h.point[1] - d.point[1]) / (h.point[0] - d.point[0]);
                var lt = 180 * Math.atan(b) / Math.PI;
                h.point[0] < d.point[0] && (lt += 180), E.rotate(-lt * Math.PI / 180);
              }
              E.translate(B, z, 0), o -= _[0] * C[a].an / 200, C[a + 1] && Z !== C[a + 1].ind && (o += C[a].an / 2, 
              o += t.tr / 1e3 * t.finalSize);
            } else {
              switch (E.translate(i, s, 0), t.ps && 
              //matrixHelper.translate(documentData.ps[0],documentData.ps[1],0);
              E.translate(t.ps[0], t.ps[1] + t.ascent, 0), t.j) {
               case 1:
                E.translate(C[a].animatorJustifyOffset + t.justifyOffset + (t.boxWidth - t.lineWidths[C[a].line]), 0, 0);
                break;

               case 2:
                E.translate(C[a].animatorJustifyOffset + t.justifyOffset + (t.boxWidth - t.lineWidths[C[a].line]) / 2, 0, 0);
              }
              E.translate(0, -t.ls), E.translate(N, 0, 0), E.translate(_[0] * C[a].an / 200, _[1] * L / 100, 0), 
              i += C[a].l + t.tr / 1e3 * t.finalSize;
            }
            "html" === M ? et = E.toCSS() : "svg" === M ? et = E.to2dCSS() : it = [ E.props[0], E.props[1], E.props[2], E.props[3], E.props[4], E.props[5], E.props[6], E.props[7], E.props[8], E.props[9], E.props[10], E.props[11], E.props[12], E.props[13], E.props[14], E.props[15] ], 
            U = O;
          }
          x <= a ? (V = new LetterProps(U, X, Y, K, et, it), this.renderedLetters.push(V), 
          x += 1, this.lettersChangedFlag = !0) : (V = this.renderedLetters[a], this.lettersChangedFlag = V.update(U, X, Y, K, et, it) || this.lettersChangedFlag);
        }
      }
    }, TextAnimatorProperty.prototype.getValue = function() {
      this._elem.globalData.frameId !== this._frameId && (this._frameId = this._elem.globalData.frameId, 
      this.iterateDynamicProperties());
    }, TextAnimatorProperty.prototype.mHelper = new u(), TextAnimatorProperty.prototype.defaultPropsArray = [], 
    extendPrototype([ DynamicPropertyContainer ], TextAnimatorProperty), LetterProps.prototype.update = function(t, e, i, s, a, r) {
      this._mdf.o = !1, this._mdf.sw = !1, this._mdf.sc = !1, this._mdf.fc = !1, this._mdf.m = !1, 
      this._mdf.p = !1;
      var n = !1;
      return this.o !== t && (this.o = t, this._mdf.o = !0, n = !0), this.sw !== e && (this.sw = e, 
      this._mdf.sw = !0, n = !0), this.sc !== i && (this.sc = i, this._mdf.sc = !0, n = !0), 
      this.fc !== s && (this.fc = s, this._mdf.fc = !0, n = !0), this.m !== a && (this.m = a, 
      this._mdf.m = !0, n = !0), !r.length || this.p[0] === r[0] && this.p[1] === r[1] && this.p[4] === r[4] && this.p[5] === r[5] && this.p[12] === r[12] && this.p[13] === r[13] || (this.p = r, 
      this._mdf.p = !0, n = !0), n;
    }, TextProperty.prototype.defaultBoxWidth = [ 0, 0 ], TextProperty.prototype.copyData = function(t, e) {
      for (var i in e) e.hasOwnProperty(i) && (t[i] = e[i]);
      return t;
    }, TextProperty.prototype.setCurrentData = function(t) {
      t.__complete || this.completeTextData(t), this.currentData = t, this.currentData.boxWidth = this.currentData.boxWidth || this.defaultBoxWidth, 
      this._mdf = !0;
    }, TextProperty.prototype.searchProperty = function() {
      return this.searchKeyframes();
    }, TextProperty.prototype.searchKeyframes = function() {
      return this.kf = this.data.d.k.length > 1, this.kf && this.addEffect(this.getKeyframeValue.bind(this)), 
      this.kf;
    }, TextProperty.prototype.addEffect = function(t) {
      this.effectsSequence.push(t), this.elem.addDynamicProperty(this);
    }, TextProperty.prototype.getValue = function(t) {
      if (this.elem.globalData.frameId !== this.frameId && this.effectsSequence.length || t) {
        var e = this.currentData, i = this.keysIndex;
        if (this.lock) this.setCurrentData(this.currentData, currentTextValue); else {
          this.lock = !0, this._mdf = !1;
          var s, a = this.effectsSequence.length, r = t || this.data.d.k[this.keysIndex].s;
          for (s = 0; s < a; s += 1) 
          //Checking if index changed to prevent creating a new object every time the expression updates.
          r = i !== this.keysIndex ? this.effectsSequence[s](r, r.t) : this.effectsSequence[s](this.currentData, r.t);
          e !== r && this.setCurrentData(r), this.pv = this.v = this.currentData, this.lock = !1, 
          this.frameId = this.elem.globalData.frameId;
        }
      }
    }, TextProperty.prototype.getKeyframeValue = function() {
      for (var t = this.data.d.k, e = this.elem.comp.renderedFrame, i = 0, s = t.length; i <= s - 1 && (t[i].s, 
      !(i === s - 1 || t[i + 1].t > e)); ) i += 1;
      return this.keysIndex !== i && (this.keysIndex = i), this.data.d.k[this.keysIndex].s;
    }, TextProperty.prototype.buildFinalText = function(t) {
      for (var e = S.getCombinedCharacterCodes(), i = [], s = 0, a = t.length; s < a; ) -1 !== e.indexOf(t.charCodeAt(s)) ? i[i.length - 1] += t.charAt(s) : i.push(t.charAt(s)), 
      s += 1;
      return i;
    }, TextProperty.prototype.completeTextData = function(t) {
      t.__complete = !0;
      var e, i, s, a, r, n, o, h = this.elem.globalData.fontManager, l = this.data, p = [], f = 0, m = l.m.g, d = 0, c = 0, u = 0, g = [], y = 0, v = 0, S = h.getFontByName(t.f), b = 0, P = S.fStyle ? S.fStyle.split(" ") : [], _ = "normal", k = "normal";
      for (i = P.length, e = 0; e < i; e += 1) switch (P[e].toLowerCase()) {
       case "italic":
        k = "italic";
        break;

       case "bold":
        _ = "700";
        break;

       case "black":
        _ = "900";
        break;

       case "medium":
        _ = "500";
        break;

       case "regular":
       case "normal":
        _ = "400";
        break;

       case "light":
       case "thin":
        _ = "200";
      }
      t.fWeight = S.fWeight || _, t.fStyle = k, i = t.t.length, t.finalSize = t.s, t.finalText = this.buildFinalText(t.t), 
      t.finalLineHeight = t.lh;
      var A = t.tr / 1e3 * t.finalSize;
      if (t.sz) for (var E, M, x = !0, C = t.sz[0], D = t.sz[1]; x; ) {
        E = 0, y = 0, i = (M = this.buildFinalText(t.t)).length, A = t.tr / 1e3 * t.finalSize;
        var T = -1;
        for (e = 0; e < i; e += 1) s = !1, " " === M[e] ? T = e : 13 === M[e].charCodeAt(0) && (y = 0, 
        s = !0, E += t.finalLineHeight || 1.2 * t.finalSize), h.chars ? (o = h.getCharData(M[e], S.fStyle, S.fFamily), 
        b = s ? 0 : o.w * t.finalSize / 100) : 
        //tCanvasHelper.font = documentData.s + 'px '+ fontData.fFamily;
        b = h.measureText(M[e], t.f, t.finalSize), y + b > C && " " !== M[e] ? (-1 === T ? i += 1 : e = T, 
        E += t.finalLineHeight || 1.2 * t.finalSize, M.splice(e, T === e ? 1 : 0, "\r"), 
        //finalText = finalText.substr(0,i) + "\r" + finalText.substr(i === lastSpaceIndex ? i + 1 : i);
        T = -1, y = 0) : (y += b, y += A);
        E += S.ascent * t.finalSize / 100, this.canResize && t.finalSize > this.minimumFontSize && D < E ? (t.finalSize -= 1, 
        t.finalLineHeight = t.finalSize * t.lh / t.s) : (t.finalText = M, i = t.finalText.length, 
        x = !1);
      }
      y = -A, b = 0;
      var F, w = 0;
      for (e = 0; e < i; e += 1) if (s = !1, " " === (F = t.finalText[e]) ? a = " " : 13 === F.charCodeAt(0) ? (w = 0, 
      g.push(y), v = y > v ? y : v, y = -2 * A, a = "", s = !0, u += 1) : a = t.finalText[e], 
      h.chars ? (o = h.getCharData(F, S.fStyle, h.getFontByName(t.f).fFamily), b = s ? 0 : o.w * t.finalSize / 100) : 
      //var charWidth = fontManager.measureText(val, documentData.f, documentData.finalSize);
      //tCanvasHelper.font = documentData.finalSize + 'px '+ fontManager.getFontByName(documentData.f).fFamily;
      b = h.measureText(a, t.f, t.finalSize), 
      //
      " " === F ? w += b + A : (y += b + A + w, w = 0), p.push({
        l: b,
        an: b,
        add: d,
        n: s,
        anIndexes: [],
        val: a,
        line: u,
        animatorJustifyOffset: 0
      }), 2 == m) {
        if (d += b, "" === a || " " === a || e === i - 1) {
          for ("" !== a && " " !== a || (d -= b); c <= e; ) p[c].an = d, p[c].ind = f, p[c].extra = b, 
          c += 1;
          f += 1, d = 0;
        }
      } else if (3 == m) {
        if (d += b, "" === a || e === i - 1) {
          for ("" === a && (d -= b); c <= e; ) p[c].an = d, p[c].ind = f, p[c].extra = b, 
          c += 1;
          d = 0, f += 1;
        }
      } else p[f].ind = f, p[f].extra = 0, f += 1;
      if (t.l = p, v = y > v ? y : v, g.push(y), t.sz) t.boxWidth = t.sz[0], t.justifyOffset = 0; else switch (t.boxWidth = v, 
      t.j) {
       case 1:
        t.justifyOffset = -t.boxWidth;
        break;

       case 2:
        t.justifyOffset = -t.boxWidth / 2;
        break;

       default:
        t.justifyOffset = 0;
      }
      t.lineWidths = g;
      var I, V, L = l.a;
      n = L.length;
      var R, G, N = [];
      for (r = 0; r < n; r += 1) {
        for ((I = L[r]).a.sc && (t.strokeColorAnim = !0), I.a.sw && (t.strokeWidthAnim = !0), 
        (I.a.fc || I.a.fh || I.a.fs || I.a.fb) && (t.fillColorAnim = !0), G = 0, R = I.s.b, 
        e = 0; e < i; e += 1) (V = p[e]).anIndexes[r] = G, (1 == R && "" !== V.val || 2 == R && "" !== V.val && " " !== V.val || 3 == R && (V.n || " " == V.val || e == i - 1) || 4 == R && (V.n || e == i - 1)) && (1 === I.s.rn && N.push(G), 
        G += 1);
        l.a[r].s.totalChars = G;
        var B, z = -1;
        if (1 === I.s.rn) for (e = 0; e < i; e += 1) z != (V = p[e]).anIndexes[r] && (z = V.anIndexes[r], 
        B = N.splice(Math.floor(Math.random() * N.length), 1)[0]), V.anIndexes[r] = B;
      }
      t.yOffset = t.finalLineHeight || 1.2 * t.finalSize, t.ls = t.ls || 0, t.ascent = S.ascent * t.finalSize / 100;
    }, TextProperty.prototype.updateDocumentData = function(t, e) {
      e = void 0 === e ? this.keysIndex : e;
      var i = this.copyData({}, this.data.d.k[e].s);
      i = this.copyData(i, t), this.data.d.k[e].s = i, this.recalculate(e);
    }, TextProperty.prototype.recalculate = function(t) {
      var e = this.data.d.k[t].s;
      e.__complete = !1, this.keysIndex = 0, this._isFirstFrame = !0, this.getValue(e);
    }, TextProperty.prototype.canResizeFont = function(t) {
      this.canResize = t, this.recalculate(this.keysIndex);
    }, TextProperty.prototype.setMinimumFontSize = function(t) {
      this.minimumFontSize = Math.floor(t) || 1, this.recalculate(this.keysIndex);
    };
    var T, F = function() {
      var t = Math.max, e = Math.min, i = Math.floor;
      function TextSelectorProp(t, e) {
        this._currentTextLength = -1, this.k = !1, this.data = e, this.elem = t, this.comp = t.comp, 
        this.finalS = 0, this.finalE = 0, this.initDynamicPropertyContainer(t), this.s = b.getProp(t, e.s || {
          k: 0
        }, 0, 0, this), this.e = "e" in e ? b.getProp(t, e.e, 0, 0, this) : {
          v: 100
        }, this.o = b.getProp(t, e.o || {
          k: 0
        }, 0, 0, this), this.xe = b.getProp(t, e.xe || {
          k: 0
        }, 0, 0, this), this.ne = b.getProp(t, e.ne || {
          k: 0
        }, 0, 0, this), this.a = b.getProp(t, e.a, 0, .01, this), this.dynamicProperties.length || this.getValue();
      }
      return TextSelectorProp.prototype = {
        getMult: function(s) {
          this._currentTextLength !== this.elem.textProperty.currentData.l.length && this.getValue();
          //var easer = bez.getEasingCurve(this.ne.v/100,0,1-this.xe.v/100,1);
                    var a = g.getBezierEasing(this.ne.v / 100, 0, 1 - this.xe.v / 100, 1).get, r = 0, n = this.finalS, o = this.finalE, h = this.data.sh;
          if (2 == h) r = a(r = o === n ? s >= o ? 1 : 0 : t(0, e(.5 / (o - n) + (s - n) / (o - n), 1))); else if (3 == h) r = a(r = o === n ? s >= o ? 0 : 1 : 1 - t(0, e(.5 / (o - n) + (s - n) / (o - n), 1))); else if (4 == h) o === n ? r = 0 : (r = t(0, e(.5 / (o - n) + (s - n) / (o - n), 1))) < .5 ? r *= 2 : r = 1 - 2 * (r - .5), 
          r = a(r); else if (5 == h) {
            if (o === n) r = 0; else {
              var l = o - n, p = -l / 2 + (
              /*ind += 0.5;
                    mult = -4/(tot*tot)*(ind*ind)+(4/tot)*ind;*/
              s = e(t(0, s + .5 - n), o - n)), f = l / 2;
              r = Math.sqrt(1 - p * p / (f * f));
            }
            r = a(r);
          } else 6 == h ? (o === n ? r = 0 : (s = e(t(0, s + .5 - n), o - n), r = (1 + Math.cos(Math.PI + 2 * Math.PI * s / (o - n))) / 2), 
          r = a(r)) : (s >= i(n) && (r = s - n < 0 ? 1 - (n - s) : t(0, e(o - s, 1))), r = a(r));
          return r * this.a.v;
        },
        getValue: function(t) {
          this.iterateDynamicProperties(), this._mdf = t || this._mdf, this._currentTextLength = this.elem.textProperty.currentData.l.length || 0, 
          t && 2 === this.data.r && (this.e.v = this._currentTextLength);
          var e = 2 === this.data.r ? 1 : 100 / this.data.totalChars, i = this.o.v / e, s = this.s.v / e + i, a = this.e.v / e + i;
          if (s > a) {
            var r = s;
            s = a, a = r;
          }
          this.finalS = s, this.finalE = a;
        }
      }, extendPrototype([ DynamicPropertyContainer ], TextSelectorProp), {
        getTextSelectorProp: function(t, e, i) {
          return new TextSelectorProp(t, e, i);
        }
      };
    }(), w = function(t, e, i, s) {
      var a = 0, r = t, n = createSizedArray(r);
      return {
        newElement: function() {
          return a ? n[a -= 1] : e();
        },
        release: function(t) {
          a === r && (n = I.double(n), r *= 2), i && i(t), n[a] = t, a += 1;
        }
      };
    }, I = {
      double: function(t) {
        return t.concat(createSizedArray(t.length));
      }
    }, V = w(8, function() {
      return c("float32", 2);
    }), L = ((T = w(4, function() {
      return new ShapePath();
    }, function(t) {
      var e, i = t._length;
      for (e = 0; e < i; e += 1) V.release(t.v[e]), V.release(t.i[e]), V.release(t.o[e]), 
      t.v[e] = null, t.i[e] = null, t.o[e] = null;
      t._length = 0, t.c = !1;
    })).clone = function(t) {
      var e, i = T.newElement(), s = void 0 === t._length ? t.v.length : t._length;
      for (i.setLength(s), i.c = t.c, e = 0; e < s; e += 1) i.setTripleAt(t.v[e][0], t.v[e][1], t.o[e][0], t.o[e][1], t.i[e][0], t.i[e][1], e);
      return i;
    }, T), R = function() {
      var t = {
        newShapeCollection: function() {
          return e ? s[e -= 1] : new ShapeCollection();
        },
        release: function(t) {
          var a, r = t._length;
          for (a = 0; a < r; a += 1) L.release(t.shapes[a]);
          t._length = 0, e === i && (s = I.double(s), i *= 2), s[e] = t, e += 1;
        }
      }, e = 0, i = 4, s = createSizedArray(i);
      return t;
    }(), G = w(8, function() {
      return {
        lengths: [],
        totalLength: 0
      };
    }, function(t) {
      var e, i = t.lengths.length;
      for (e = 0; e < i; e += 1) N.release(t.lengths[e]);
      t.lengths.length = 0;
    }), N = w(8, function() {
      return {
        addedLength: 0,
        percents: c("float32", f),
        lengths: c("float32", f)
      };
    });
    function BaseRenderer() {}
    function SVGRenderer(t, e) {
      this.animationItem = t, this.layers = null, this.renderedFrame = -1, this.svgElement = createNS("svg");
      var i = createNS("defs");
      this.svgElement.appendChild(i);
      var s = createNS("g");
      this.svgElement.appendChild(s), this.layerElement = s, this.renderConfig = {
        preserveAspectRatio: e && e.preserveAspectRatio || "xMidYMid meet",
        imagePreserveAspectRatio: e && e.imagePreserveAspectRatio || "xMidYMid slice",
        progressiveLoad: e && e.progressiveLoad || !1,
        hideOnTransparent: !e || !1 !== e.hideOnTransparent,
        viewBoxOnly: e && e.viewBoxOnly || !1,
        viewBoxSize: e && e.viewBoxSize || !1,
        className: e && e.className || ""
      }, this.globalData = {
        _mdf: !1,
        frameNum: -1,
        defs: i,
        renderConfig: this.renderConfig
      }, this.elements = [], this.pendingElements = [], this.destroyed = !1;
    }
    function MaskElement(t, e, i) {
      this.data = t, this.element = e, this.globalData = i, this.storedData = [], this.masksProperties = this.data.masksProperties || [], 
      this.maskElement = null;
      var a, r = this.globalData.defs, n = this.masksProperties ? this.masksProperties.length : 0;
      this.viewData = createSizedArray(n), this.solidPath = "";
      var o, h, l, p, f, m, d, c = this.masksProperties, u = 0, g = [], y = randomString(10), v = "clipPath", S = "clip-path";
      for (a = 0; a < n; a++) if (("a" !== c[a].mode && "n" !== c[a].mode || c[a].inv || 100 !== c[a].o.k) && (v = "mask", 
      S = "mask"), "s" != c[a].mode && "i" != c[a].mode || 0 !== u ? p = null : ((p = createNS("rect")).setAttribute("fill", "#ffffff"), 
      p.setAttribute("width", this.element.comp.data.w || 0), p.setAttribute("height", this.element.comp.data.h || 0), 
      g.push(p)), o = createNS("path"), "n" != c[a].mode) {
        var P;
        if (u += 1, o.setAttribute("fill", "s" === c[a].mode ? "#000000" : "#ffffff"), o.setAttribute("clip-rule", "nonzero"), 
        0 !== c[a].x.k ? (v = "mask", S = "mask", d = b.getProp(this.element, c[a].x, 0, null, this.element), 
        P = "fi_" + randomString(10), (f = createNS("filter")).setAttribute("id", P), (m = createNS("feMorphology")).setAttribute("operator", "dilate"), 
        m.setAttribute("in", "SourceGraphic"), m.setAttribute("radius", "0"), f.appendChild(m), 
        r.appendChild(f), o.setAttribute("stroke", "s" === c[a].mode ? "#000000" : "#ffffff")) : (m = null, 
        d = null), 
        // TODO move this to a factory or to a constructor
        this.storedData[a] = {
          elem: o,
          x: d,
          expan: m,
          lastPath: "",
          lastOperator: "",
          filterId: P,
          lastRadius: 0
        }, "i" == c[a].mode) {
          l = g.length;
          var k = createNS("g");
          for (h = 0; h < l; h += 1) k.appendChild(g[h]);
          var A = createNS("mask");
          A.setAttribute("mask-type", "alpha"), A.setAttribute("id", y + "_" + u), A.appendChild(o), 
          r.appendChild(A), k.setAttribute("mask", "url(" + s + "#" + y + "_" + u + ")"), 
          g.length = 0, g.push(k);
        } else g.push(o);
        c[a].inv && !this.solidPath && (this.solidPath = this.createLayerSolidPath()), 
        // TODO move this to a factory or to a constructor
        this.viewData[a] = {
          elem: o,
          lastPath: "",
          op: b.getProp(this.element, c[a].o, 0, .01, this.element),
          prop: _.getShapeProp(this.element, c[a], 3),
          invRect: p
        }, this.viewData[a].prop.k || this.drawPath(c[a], this.viewData[a].prop.v, this.viewData[a]);
      } else 
      // TODO move this to a factory or to a constructor
      this.viewData[a] = {
        op: b.getProp(this.element, c[a].o, 0, .01, this.element),
        prop: _.getShapeProp(this.element, c[a], 3),
        elem: o,
        lastPath: ""
      }, r.appendChild(o);
      for (this.maskElement = createNS(v), n = g.length, a = 0; a < n; a += 1) this.maskElement.appendChild(g[a]);
      u > 0 && (this.maskElement.setAttribute("id", y), this.element.maskedElement.setAttribute(S, "url(" + s + "#" + y + ")"), 
      r.appendChild(this.maskElement)), this.viewData.length && this.element.addRenderableComponent(this);
    }
    /**
 * @file 
 * Handles AE's layer parenting property.
 *
 */
    function HierarchyElement() {}
    /**
 * @file 
 * Handles element's layer frame update.
 * Checks layer in point and out point
 *
 */
    function FrameElement() {}
    function TransformElement() {}
    function RenderableElement() {}
    function RenderableDOMElement() {}
    function ProcessedElement(t, e) {
      this.elem = t, this.pos = e;
    }
    function SVGStyleData(t, e) {
      this.data = t, this.type = t.ty, this.d = "", this.lvl = e, this._mdf = !1, this.closed = !0 === t.hd, 
      this.pElem = createNS("path"), this.msElem = null;
    }
    function SVGShapeData(t, e, i) {
      this.caches = [], this.styles = [], this.transformers = t, this.lStr = "", this.sh = i, 
      this.lvl = e, 
      //TODO find if there are some cases where _isAnimated can be false. 
      // For now, since shapes add up with other shapes. They have to be calculated every time.
      // One way of finding out is checking if all styles associated to this shape depend only of this shape
      this._isAnimated = !!i.k;
      for (
      // TODO: commenting this for now since all shapes are animated
      var s = 0, a = t.length; s < a; ) {
        if (t[s].mProps.dynamicProperties.length) {
          this._isAnimated = !0;
          break;
        }
        s += 1;
      }
    }
    function SVGTransformData(t, e, i) {
      this.transform = {
        mProps: t,
        op: e,
        container: i
      }, this.elements = [], this._isAnimated = this.transform.mProps.dynamicProperties.length || this.transform.op.effectsSequence.length;
    }
    function SVGStrokeStyleData(t, e, i) {
      this.initDynamicPropertyContainer(t), this.getValue = this.iterateDynamicProperties, 
      this.o = b.getProp(t, e.o, 0, .01, this), this.w = b.getProp(t, e.w, 0, null, this), 
      this.d = new DashProperty(t, e.d || {}, "svg", this), this.c = b.getProp(t, e.c, 1, 255, this), 
      this.style = i, this._isAnimated = !!this._isAnimated;
    }
    function SVGFillStyleData(t, e, i) {
      this.initDynamicPropertyContainer(t), this.getValue = this.iterateDynamicProperties, 
      this.o = b.getProp(t, e.o, 0, .01, this), this.c = b.getProp(t, e.c, 1, 255, this), 
      this.style = i;
    }
    function SVGGradientFillStyleData(t, e, i) {
      this.initDynamicPropertyContainer(t), this.getValue = this.iterateDynamicProperties, 
      this.initGradientData(t, e, i);
    }
    function SVGGradientStrokeStyleData(t, e, i) {
      this.initDynamicPropertyContainer(t), this.getValue = this.iterateDynamicProperties, 
      this.w = b.getProp(t, e.w, 0, null, this), this.d = new DashProperty(t, e.d || {}, "svg", this), 
      this.initGradientData(t, e, i), this._isAnimated = !!this._isAnimated;
    }
    function ShapeGroupData() {
      this.it = [], this.prevViewData = [], this.gr = createNS("g");
    }
    BaseRenderer.prototype.checkLayers = function(t) {
      var e, i, s = this.layers.length;
      for (this.completeLayers = !0, e = s - 1; e >= 0; e--) this.elements[e] || (i = this.layers[e]).ip - i.st <= t - this.layers[e].st && i.op - i.st > t - this.layers[e].st && this.buildItem(e), 
      this.completeLayers = !!this.elements[e] && this.completeLayers;
      this.checkPendingElements();
    }, BaseRenderer.prototype.createItem = function(t) {
      switch (t.ty) {
       case 2:
        return this.createImage(t);

       case 0:
        return this.createComp(t);

       case 1:
        return this.createSolid(t);

       case 3:
        return this.createNull(t);

       case 4:
        return this.createShape(t);

       case 5:
        return this.createText(t);

       case 13:
        return this.createCamera(t);
      }
      return this.createNull(t);
    }, BaseRenderer.prototype.createCamera = function() {
      throw new Error("You're using a 3d camera. Try the html renderer.");
    }, BaseRenderer.prototype.buildAllItems = function() {
      var t, e = this.layers.length;
      for (t = 0; t < e; t += 1) this.buildItem(t);
      this.checkPendingElements();
    }, BaseRenderer.prototype.includeLayers = function(t) {
      this.completeLayers = !1;
      var e, i, s = t.length, a = this.layers.length;
      for (e = 0; e < s; e += 1) for (i = 0; i < a; ) {
        if (this.layers[i].id == t[e].id) {
          this.layers[i] = t[e];
          break;
        }
        i += 1;
      }
    }, BaseRenderer.prototype.setProjectInterface = function(t) {
      this.globalData.projectInterface = t;
    }, BaseRenderer.prototype.initItems = function() {
      this.globalData.progressiveLoad || this.buildAllItems();
    }, BaseRenderer.prototype.buildElementParenting = function(t, e, i) {
      for (var s = this.elements, a = this.layers, r = 0, n = a.length; r < n; ) a[r].ind == e && (s[r] && !0 !== s[r] ? (i.push(s[r]), 
      s[r].setAsParent(), void 0 !== a[r].parent ? this.buildElementParenting(t, a[r].parent, i) : t.setHierarchy(i)) : (this.buildItem(r), 
      this.addPendingElement(t))), r += 1;
    }, BaseRenderer.prototype.addPendingElement = function(t) {
      this.pendingElements.push(t);
    }, BaseRenderer.prototype.searchExtraCompositions = function(t) {
      var e, i = t.length;
      for (e = 0; e < i; e += 1) if (t[e].xt) {
        var s = this.createComp(t[e]);
        s.initExpressions(), this.globalData.projectInterface.registerComposition(s);
      }
    }, BaseRenderer.prototype.setupGlobalData = function(t, e) {
      this.globalData.fontManager = new S(), this.globalData.fontManager.addChars(t.chars), 
      this.globalData.fontManager.addFonts(t.fonts, e), this.globalData.getAssetData = this.animationItem.getAssetData.bind(this.animationItem), 
      this.globalData.getAssetsPath = this.animationItem.getAssetsPath.bind(this.animationItem), 
      this.globalData.elementLoaded = this.animationItem.elementLoaded.bind(this.animationItem), 
      this.globalData.addPendingElement = this.animationItem.addPendingElement.bind(this.animationItem), 
      this.globalData.frameId = 0, this.globalData.frameRate = t.fr, this.globalData.nm = t.nm, 
      this.globalData.compSize = {
        w: t.w,
        h: t.h
      };
    }, extendPrototype([ BaseRenderer ], SVGRenderer), SVGRenderer.prototype.createNull = function(t) {
      return new NullElement(t, this.globalData, this);
    }, SVGRenderer.prototype.createShape = function(t) {
      return new SVGShapeElement(t, this.globalData, this);
    }, SVGRenderer.prototype.createText = function(t) {
      return new SVGTextElement(t, this.globalData, this);
    }, SVGRenderer.prototype.createImage = function(t) {
      return new IImageElement(t, this.globalData, this);
    }, SVGRenderer.prototype.createComp = function(t) {
      return new SVGCompElement(t, this.globalData, this);
    }, SVGRenderer.prototype.createSolid = function(t) {
      return new ISolidElement(t, this.globalData, this);
    }, SVGRenderer.prototype.configAnimation = function(t) {
      this.svgElement.setAttribute("xmlns", "http://www.w3.org/2000/svg"), this.renderConfig.viewBoxSize ? this.svgElement.setAttribute("viewBox", this.renderConfig.viewBoxSize) : this.svgElement.setAttribute("viewBox", "0 0 " + t.w + " " + t.h), 
      this.renderConfig.viewBoxOnly || (this.svgElement.setAttribute("width", t.w), this.svgElement.setAttribute("height", t.h), 
      this.svgElement.style.width = "100%", this.svgElement.style.height = "100%", this.svgElement.style.transform = "translate3d(0,0,0)"), 
      this.renderConfig.className && this.svgElement.setAttribute("class", this.renderConfig.className), 
      this.svgElement.setAttribute("preserveAspectRatio", this.renderConfig.preserveAspectRatio), 
      //this.layerElement.style.transform = 'translate3d(0,0,0)';
      //this.layerElement.style.transformOrigin = this.layerElement.style.mozTransformOrigin = this.layerElement.style.webkitTransformOrigin = this.layerElement.style['-webkit-transform'] = "0px 0px 0px";
      this.animationItem.wrapper.appendChild(this.svgElement);
      //Mask animation
      var e = this.globalData.defs;
      this.setupGlobalData(t, e), this.globalData.progressiveLoad = this.renderConfig.progressiveLoad, 
      this.data = t;
      var i = createNS("clipPath"), a = createNS("rect");
      a.setAttribute("width", t.w), a.setAttribute("height", t.h), a.setAttribute("x", 0), 
      a.setAttribute("y", 0);
      var r = "animationMask_" + randomString(10);
      i.setAttribute("id", r), i.appendChild(a), this.layerElement.setAttribute("clip-path", "url(" + s + "#" + r + ")"), 
      e.appendChild(i), this.layers = t.layers, this.elements = createSizedArray(t.layers.length);
    }, SVGRenderer.prototype.destroy = function() {
      this.animationItem.wrapper.innerHTML = "", this.layerElement = null, this.globalData.defs = null;
      var t, e = this.layers ? this.layers.length : 0;
      for (t = 0; t < e; t++) this.elements[t] && this.elements[t].destroy();
      this.elements.length = 0, this.destroyed = !0, this.animationItem = null;
    }, SVGRenderer.prototype.updateContainerSize = function() {}, SVGRenderer.prototype.buildItem = function(t) {
      var i = this.elements;
      if (!i[t] && 99 != this.layers[t].ty) {
        i[t] = !0;
        var s = this.createItem(this.layers[t]);
        i[t] = s, e && (0 === this.layers[t].ty && this.globalData.projectInterface.registerComposition(s), 
        s.initExpressions()), this.appendElementInPos(s, t), this.layers[t].tt && (this.elements[t - 1] && !0 !== this.elements[t - 1] ? s.setMatte(i[t - 1].layerId) : (this.buildItem(t - 1), 
        this.addPendingElement(s)));
      }
    }, SVGRenderer.prototype.checkPendingElements = function() {
      for (;this.pendingElements.length; ) {
        var t = this.pendingElements.pop();
        if (t.checkParenting(), t.data.tt) for (var e = 0, i = this.elements.length; e < i; ) {
          if (this.elements[e] === t) {
            t.setMatte(this.elements[e - 1].layerId);
            break;
          }
          e += 1;
        }
      }
    }, SVGRenderer.prototype.renderFrame = function(t) {
      if (this.renderedFrame !== t && !this.destroyed) {
        null === t ? t = this.renderedFrame : this.renderedFrame = t, 
        // console.log('-------');
        // console.log('FRAME ',num);
        this.globalData.frameNum = t, this.globalData.frameId += 1, this.globalData.projectInterface.currentFrame = t, 
        this.globalData._mdf = !1;
        var e, i = this.layers.length;
        for (this.completeLayers || this.checkLayers(t), e = i - 1; e >= 0; e--) (this.completeLayers || this.elements[e]) && this.elements[e].prepareFrame(t - this.layers[e].st);
        if (this.globalData._mdf) for (e = 0; e < i; e += 1) (this.completeLayers || this.elements[e]) && this.elements[e].renderFrame();
      }
    }, SVGRenderer.prototype.appendElementInPos = function(t, e) {
      var i = t.getBaseElement();
      if (i) {
        for (var s, a = 0; a < e; ) this.elements[a] && !0 !== this.elements[a] && this.elements[a].getBaseElement() && (s = this.elements[a].getBaseElement()), 
        a += 1;
        s ? this.layerElement.insertBefore(i, s) : this.layerElement.appendChild(i);
      }
    }, SVGRenderer.prototype.hide = function() {
      this.layerElement.style.display = "none";
    }, SVGRenderer.prototype.show = function() {
      this.layerElement.style.display = "block";
    }, MaskElement.prototype.getMaskProperty = function(t) {
      return this.viewData[t].prop;
    }, MaskElement.prototype.renderFrame = function(t) {
      var e, i = this.element.finalTransform.mat, a = this.masksProperties.length;
      for (e = 0; e < a; e++) if ((this.viewData[e].prop._mdf || t) && this.drawPath(this.masksProperties[e], this.viewData[e].prop.v, this.viewData[e]), 
      (this.viewData[e].op._mdf || t) && this.viewData[e].elem.setAttribute("fill-opacity", this.viewData[e].op.v), 
      "n" !== this.masksProperties[e].mode && (this.viewData[e].invRect && (this.element.finalTransform.mProp._mdf || t) && (this.viewData[e].invRect.setAttribute("x", -i.props[12]), 
      this.viewData[e].invRect.setAttribute("y", -i.props[13])), this.storedData[e].x && (this.storedData[e].x._mdf || t))) {
        var r = this.storedData[e].expan;
        this.storedData[e].x.v < 0 ? ("erode" !== this.storedData[e].lastOperator && (this.storedData[e].lastOperator = "erode", 
        this.storedData[e].elem.setAttribute("filter", "url(" + s + "#" + this.storedData[e].filterId + ")")), 
        r.setAttribute("radius", -this.storedData[e].x.v)) : ("dilate" !== this.storedData[e].lastOperator && (this.storedData[e].lastOperator = "dilate", 
        this.storedData[e].elem.setAttribute("filter", null)), this.storedData[e].elem.setAttribute("stroke-width", 2 * this.storedData[e].x.v));
      }
    }, MaskElement.prototype.getMaskelement = function() {
      return this.maskElement;
    }, MaskElement.prototype.createLayerSolidPath = function() {
      var t = "M0,0 ";
      return t += " h" + this.globalData.compSize.w, t += " v" + this.globalData.compSize.h, 
      (t += " h-" + this.globalData.compSize.w) + " v-" + this.globalData.compSize.h + " ";
    }, MaskElement.prototype.drawPath = function(t, e, i) {
      var s, a, r = " M" + e.v[0][0] + "," + e.v[0][1];
      for (a = e._length, s = 1; s < a; s += 1) 
      //pathString += " C"+pathNodes.o[i-1][0]+','+pathNodes.o[i-1][1] + " "+pathNodes.i[i][0]+','+pathNodes.i[i][1] + " "+pathNodes.v[i][0]+','+pathNodes.v[i][1];
      r += " C" + e.o[s - 1][0] + "," + e.o[s - 1][1] + " " + e.i[s][0] + "," + e.i[s][1] + " " + e.v[s][0] + "," + e.v[s][1];
      //pathString += " C"+pathNodes.o[i-1][0]+','+pathNodes.o[i-1][1] + " "+pathNodes.i[0][0]+','+pathNodes.i[0][1] + " "+pathNodes.v[0][0]+','+pathNodes.v[0][1];
            //pathNodes.__renderedString = pathString;
      if (e.c && a > 1 && (r += " C" + e.o[s - 1][0] + "," + e.o[s - 1][1] + " " + e.i[0][0] + "," + e.i[0][1] + " " + e.v[0][0] + "," + e.v[0][1]), 
      i.lastPath !== r) {
        var n = "";
        i.elem && (e.c && (n = t.inv ? this.solidPath + r : r), i.elem.setAttribute("d", n)), 
        i.lastPath = r;
      }
    }, MaskElement.prototype.destroy = function() {
      this.element = null, this.globalData = null, this.maskElement = null, this.data = null, 
      this.masksProperties = null;
    }, HierarchyElement.prototype = {
      /**
     * @function 
     * Initializes hierarchy properties
     *
     */
      initHierarchy: function() {
        //element's parent list
        this.hierarchy = [], 
        //if element is parent of another layer _isParent will be true
        this._isParent = !1, this.checkParenting();
      },
      /**
     * @function 
     * Sets layer's hierarchy.
     * @param {array} hierarch
     * layer's parent list
     *
     */
      setHierarchy: function(t) {
        this.hierarchy = t;
      },
      /**
     * @function 
     * Sets layer as parent.
     *
     */
      setAsParent: function() {
        this._isParent = !0;
      },
      /**
     * @function 
     * Searches layer's parenting chain
     *
     */
      checkParenting: function() {
        void 0 !== this.data.parent && this.comp.buildElementParenting(this, this.data.parent, []);
      }
    }, FrameElement.prototype = {
      /**
     * @function 
     * Initializes frame related properties.
     *
     */
      initFrame: function() {
        //set to true when inpoint is rendered
        this._isFirstFrame = !1, 
        //list of animated properties
        this.dynamicProperties = [], 
        // If layer has been modified in current tick this will be true
        this._mdf = !1;
      },
      /**
     * @function 
     * Calculates all dynamic values
     *
     * @param {number} num
     * current frame number in Layer's time
     * @param {boolean} isVisible
     * if layers is currently in range
     * 
     */
      prepareProperties: function(t, e) {
        var i, s = this.dynamicProperties.length;
        for (i = 0; i < s; i += 1) (e || this._isParent && "transform" === this.dynamicProperties[i].propType) && (this.dynamicProperties[i].getValue(), 
        this.dynamicProperties[i]._mdf && (this.globalData._mdf = !0, this._mdf = !0));
      },
      addDynamicProperty: function(t) {
        -1 === this.dynamicProperties.indexOf(t) && this.dynamicProperties.push(t);
      }
    }, TransformElement.prototype = {
      initTransform: function() {
        this.finalTransform = {
          mProp: this.data.ks ? P.getTransformProperty(this, this.data.ks, this) : {
            o: 0
          },
          _matMdf: !1,
          _opMdf: !1,
          mat: new u()
        }, this.data.ao && (this.finalTransform.mProp.autoOriented = !0), this.data.ty;
      },
      renderTransform: function() {
        if (this.finalTransform._opMdf = this.finalTransform.mProp.o._mdf || this._isFirstFrame, 
        this.finalTransform._matMdf = this.finalTransform.mProp._mdf || this._isFirstFrame, 
        this.hierarchy) {
          var t, e = this.finalTransform.mat, i = 0, s = this.hierarchy.length;
          //Checking if any of the transformation matrices in the hierarchy chain has changed.
          if (!this.finalTransform._matMdf) for (;i < s; ) {
            if (this.hierarchy[i].finalTransform.mProp._mdf) {
              this.finalTransform._matMdf = !0;
              break;
            }
            i += 1;
          }
          if (this.finalTransform._matMdf) for (t = this.finalTransform.mProp.v.props, e.cloneFromProps(t), 
          i = 0; i < s; i += 1) t = this.hierarchy[i].finalTransform.mProp.v.props, e.transform(t[0], t[1], t[2], t[3], t[4], t[5], t[6], t[7], t[8], t[9], t[10], t[11], t[12], t[13], t[14], t[15]);
        }
      },
      globalToLocal: function(t) {
        var e = [];
        e.push(this.finalTransform);
        for (var i = !0, s = this.comp; i; ) s.finalTransform ? (s.data.hasMask && e.splice(0, 0, s.finalTransform), 
        s = s.comp) : i = !1;
        var a, r, n = e.length;
        for (a = 0; a < n; a += 1) r = e[a].mat.applyToPointArray(0, 0, 0), 
        //ptNew = transforms[i].mat.applyToPointArray(pt[0],pt[1],pt[2]);
        t = [ t[0] - r[0], t[1] - r[1], 0 ];
        return t;
      },
      mHelper: new u()
    }, RenderableElement.prototype = {
      initRenderable: function() {
        //layer's visibility related to inpoint and outpoint. Rename isVisible to isInRange
        this.isInRange = !1, 
        //layer's display state
        this.hidden = !1, 
        // If layer's transparency equals 0, it can be hidden
        this.isTransparent = !1, 
        //list of animated components
        this.renderableComponents = [];
      },
      addRenderableComponent: function(t) {
        -1 === this.renderableComponents.indexOf(t) && this.renderableComponents.push(t);
      },
      removeRenderableComponent: function(t) {
        -1 !== this.renderableComponents.indexOf(t) && this.renderableComponents.splice(this.renderableComponents.indexOf(t), 1);
      },
      prepareRenderableFrame: function(t) {
        this.checkLayerLimits(t);
      },
      checkTransparency: function() {
        this.finalTransform.mProp.o.v <= 0 ? !this.isTransparent && this.globalData.renderConfig.hideOnTransparent && (this.isTransparent = !0, 
        this.hide()) : this.isTransparent && (this.isTransparent = !1, this.show());
      },
      /**
     * @function 
     * Initializes frame related properties.
     *
     * @param {number} num
     * current frame number in Layer's time
     * 
     */
      checkLayerLimits: function(t) {
        this.data.ip - this.data.st <= t && this.data.op - this.data.st > t ? !0 !== this.isInRange && (this.globalData._mdf = !0, 
        this._mdf = !0, this.isInRange = !0, this.show()) : !1 !== this.isInRange && (this.globalData._mdf = !0, 
        this.isInRange = !1, this.hide());
      },
      renderRenderable: function() {
        var t, e = this.renderableComponents.length;
        for (t = 0; t < e; t += 1) this.renderableComponents[t].renderFrame(this._isFirstFrame);
        /*this.maskManager.renderFrame(this.finalTransform.mat);
        this.renderableEffectsManager.renderFrame(this._isFirstFrame);*/      },
      sourceRectAtTime: function() {
        return {
          top: 0,
          left: 0,
          width: 100,
          height: 100
        };
      },
      getLayerSize: function() {
        return 5 === this.data.ty ? {
          w: this.data.textData.width,
          h: this.data.textData.height
        } : {
          w: this.data.width,
          h: this.data.height
        };
      }
    }, extendPrototype([ RenderableElement, function(t) {
      function ProxyFunction() {}
      return ProxyFunction.prototype = {
        initElement: function(t, e, i) {
          this.initFrame(), this.initBaseData(t, e, i), this.initTransform(t, e, i), this.initHierarchy(), 
          this.initRenderable(), this.initRendererElement(), this.createContainerElements(), 
          this.addMasks(), this.createContent(), this.hide();
        },
        hide: function() {
          this.hidden || this.isInRange && !this.isTransparent || ((this.baseElement || this.layerElement).style.display = "none", 
          this.hidden = !0);
        },
        show: function() {
          this.isInRange && !this.isTransparent && (this.data.hd || ((this.baseElement || this.layerElement).style.display = "block"), 
          this.hidden = !1, this._isFirstFrame = !0);
        },
        renderFrame: function() {
          //If it is exported as hidden (data.hd === true) no need to render
          //If it is not visible no need to render
          this.data.hd || this.hidden || (this.renderTransform(), this.renderRenderable(), 
          this.renderElement(), this.renderInnerContent(), this._isFirstFrame && (this._isFirstFrame = !1));
        },
        renderInnerContent: function() {},
        prepareFrame: function(t) {
          this._mdf = !1, this.prepareRenderableFrame(t), this.prepareProperties(t, this.isInRange), 
          this.checkTransparency();
        },
        destroy: function() {
          this.innerElem = null, this.destroyBaseElement();
        }
      }, ProxyFunction;
    }() ], RenderableDOMElement), SVGStyleData.prototype.reset = function() {
      this.d = "", this._mdf = !1;
    }, SVGShapeData.prototype.setAsAnimated = function() {
      this._isAnimated = !0;
    }, extendPrototype([ DynamicPropertyContainer ], SVGStrokeStyleData), extendPrototype([ DynamicPropertyContainer ], SVGFillStyleData), 
    SVGGradientFillStyleData.prototype.initGradientData = function(t, e, i) {
      this.o = b.getProp(t, e.o, 0, .01, this), this.s = b.getProp(t, e.s, 1, null, this), 
      this.e = b.getProp(t, e.e, 1, null, this), this.h = b.getProp(t, e.h || {
        k: 0
      }, 0, .01, this), this.a = b.getProp(t, e.a || {
        k: 0
      }, 0, m, this), this.g = new GradientProperty(t, e.g), this.style = i, this.stops = [], 
      this.setGradientData(i.pElem, e), this.setGradientOpacity(e, i), this._isAnimated = !!this._isAnimated;
    }, SVGGradientFillStyleData.prototype.setGradientData = function(t, e) {
      var i = "gr_" + randomString(10), s = createNS(1 === e.t ? "linearGradient" : "radialGradient");
      s.setAttribute("id", i), s.setAttribute("spreadMethod", "pad"), s.setAttribute("gradientUnits", "userSpaceOnUse");
      var a, r, n, o = [];
      for (n = 4 * e.g.p, r = 0; r < n; r += 4) a = createNS("stop"), s.appendChild(a), 
      o.push(a);
      t.setAttribute("gf" === e.ty ? "fill" : "stroke", "url(#" + i + ")"), this.gf = s, 
      this.cst = o;
    }, SVGGradientFillStyleData.prototype.setGradientOpacity = function(t, e) {
      if (this.g._hasOpacity && !this.g._collapsable) {
        var i, s, a, r = createNS("mask"), n = createNS("path");
        r.appendChild(n);
        var o = "op_" + randomString(10), h = "mk_" + randomString(10);
        r.setAttribute("id", h);
        var l = createNS(1 === t.t ? "linearGradient" : "radialGradient");
        l.setAttribute("id", o), l.setAttribute("spreadMethod", "pad"), l.setAttribute("gradientUnits", "userSpaceOnUse"), 
        a = t.g.k.k[0].s ? t.g.k.k[0].s.length : t.g.k.k.length;
        var p = this.stops;
        for (s = 4 * t.g.p; s < a; s += 2) (i = createNS("stop")).setAttribute("stop-color", "rgb(255,255,255)"), 
        l.appendChild(i), p.push(i);
        n.setAttribute("gf" === t.ty ? "fill" : "stroke", "url(#" + o + ")"), this.of = l, 
        this.ms = r, this.ost = p, this.maskId = h, e.msElem = n;
      }
    }, extendPrototype([ DynamicPropertyContainer ], SVGGradientFillStyleData), extendPrototype([ SVGGradientFillStyleData, DynamicPropertyContainer ], SVGGradientStrokeStyleData);
    var B = function() {
      var t = new u(), e = new u();
      function renderContentTransform(t, e, i) {
        (i || e.transform.op._mdf) && e.transform.container.setAttribute("opacity", e.transform.op.v), 
        (i || e.transform.mProps._mdf) && e.transform.container.setAttribute("transform", e.transform.mProps.v.to2dCSS());
      }
      function renderPath(i, s, a) {
        var r, n, o, h, l, p, f, m, d, c, u, g = s.styles.length, y = s.lvl;
        for (p = 0; p < g; p += 1) {
          if (h = s.sh._mdf || a, s.styles[p].lvl < y) {
            for (m = e.reset(), c = y - s.styles[p].lvl, u = s.transformers.length - 1; !h && c > 0; ) h = s.transformers[u].mProps._mdf || h, 
            c--, u--;
            if (h) for (c = y - s.styles[p].lvl, u = s.transformers.length - 1; c > 0; ) d = s.transformers[u].mProps.v.props, 
            m.transform(d[0], d[1], d[2], d[3], d[4], d[5], d[6], d[7], d[8], d[9], d[10], d[11], d[12], d[13], d[14], d[15]), 
            c--, u--;
          } else m = t;
          if (n = (f = s.sh.paths)._length, h) {
            for (o = "", r = 0; r < n; r += 1) (l = f.shapes[r]) && l._length && (o += E(l, l._length, l.c, m));
            s.caches[p] = o;
          } else o = s.caches[p];
          s.styles[p].d += !0 === i.hd ? "" : o, s.styles[p]._mdf = h || s.styles[p]._mdf;
        }
      }
      function renderFill(t, e, i) {
        var s = e.style;
        (e.c._mdf || i) && s.pElem.setAttribute("fill", "rgb(" + h(e.c.v[0]) + "," + h(e.c.v[1]) + "," + h(e.c.v[2]) + ")"), 
        (e.o._mdf || i) && s.pElem.setAttribute("fill-opacity", e.o.v);
      }
      function renderGradientStroke(t, e, i) {
        renderGradient(t, e, i), renderStroke(0, e, i);
      }
      function renderGradient(t, e, i) {
        var s, a, r, n, o, h = e.gf, l = e.g._hasOpacity, p = e.s.v, f = e.e.v;
        if (e.o._mdf || i) {
          var m = "gf" === t.ty ? "fill-opacity" : "stroke-opacity";
          e.style.pElem.setAttribute(m, e.o.v);
        }
        if (e.s._mdf || i) {
          var d = 1 === t.t ? "x1" : "cx", c = "x1" === d ? "y1" : "cy";
          h.setAttribute(d, p[0]), h.setAttribute(c, p[1]), l && !e.g._collapsable && (e.of.setAttribute(d, p[0]), 
          e.of.setAttribute(c, p[1]));
        }
        if (e.g._cmdf || i) {
          s = e.cst;
          var u = e.g.c;
          for (r = s.length, a = 0; a < r; a += 1) (n = s[a]).setAttribute("offset", u[4 * a] + "%"), 
          n.setAttribute("stop-color", "rgb(" + u[4 * a + 1] + "," + u[4 * a + 2] + "," + u[4 * a + 3] + ")");
        }
        if (l && (e.g._omdf || i)) {
          var g = e.g.o;
          for (r = (s = e.g._collapsable ? e.cst : e.ost).length, a = 0; a < r; a += 1) n = s[a], 
          e.g._collapsable || n.setAttribute("offset", g[2 * a] + "%"), n.setAttribute("stop-opacity", g[2 * a + 1]);
        }
        if (1 === t.t) (e.e._mdf || i) && (h.setAttribute("x2", f[0]), h.setAttribute("y2", f[1]), 
        l && !e.g._collapsable && (e.of.setAttribute("x2", f[0]), e.of.setAttribute("y2", f[1]))); else if ((e.s._mdf || e.e._mdf || i) && (o = Math.sqrt(Math.pow(p[0] - f[0], 2) + Math.pow(p[1] - f[1], 2)), 
        h.setAttribute("r", o), l && !e.g._collapsable && e.of.setAttribute("r", o)), e.e._mdf || e.h._mdf || e.a._mdf || i) {
          o || (o = Math.sqrt(Math.pow(p[0] - f[0], 2) + Math.pow(p[1] - f[1], 2)));
          var y = Math.atan2(f[1] - p[1], f[0] - p[0]), v = o * (e.h.v >= 1 ? .99 : e.h.v <= -1 ? -.99 : e.h.v), S = Math.cos(y + e.a.v) * v + p[0], b = Math.sin(y + e.a.v) * v + p[1];
          h.setAttribute("fx", S), h.setAttribute("fy", b), l && !e.g._collapsable && (e.of.setAttribute("fx", S), 
          e.of.setAttribute("fy", b));
        }
        //gfill.setAttribute('fy','200');
            }
      function renderStroke(t, e, i) {
        var s = e.style, a = e.d;
        a && (a._mdf || i) && a.dashStr && (s.pElem.setAttribute("stroke-dasharray", a.dashStr), 
        s.pElem.setAttribute("stroke-dashoffset", a.dashoffset[0])), e.c && (e.c._mdf || i) && s.pElem.setAttribute("stroke", "rgb(" + h(e.c.v[0]) + "," + h(e.c.v[1]) + "," + h(e.c.v[2]) + ")"), 
        (e.o._mdf || i) && s.pElem.setAttribute("stroke-opacity", e.o.v), (e.w._mdf || i) && (s.pElem.setAttribute("stroke-width", e.w.v), 
        s.msElem && s.msElem.setAttribute("stroke-width", e.w.v));
      }
      return {
        createRenderFunction: function(t) {
          switch (t.ty, t.ty) {
           case "fl":
            return renderFill;

           case "gf":
            return renderGradient;

           case "gs":
            return renderGradientStroke;

           case "st":
            return renderStroke;

           case "sh":
           case "el":
           case "rc":
           case "sr":
            return renderPath;

           case "tr":
            return renderContentTransform;
          }
        }
      };
    }();
    function BaseElement() {}
    function NullElement(t, e, i) {
      this.initFrame(), this.initBaseData(t, e, i), this.initFrame(), this.initTransform(t, e, i), 
      this.initHierarchy();
    }
    function SVGBaseElement() {}
    function IShapeElement() {}
    function ITextElement() {}
    function ICompElement() {}
    function IImageElement(t, e, i) {
      this.assetData = e.getAssetData(t.refId), this.initElement(t, e, i);
    }
    function ISolidElement(t, e, i) {
      this.initElement(t, e, i);
    }
    function SVGCompElement(t, e, i) {
      this.layers = t.layers, this.supports3d = !0, this.completeLayers = !1, this.pendingElements = [], 
      this.elements = this.layers ? createSizedArray(this.layers.length) : [], 
      //this.layerElement = createNS('g');
      this.initElement(t, e, i), this.tm = t.tm ? b.getProp(this, t.tm, 0, e.frameRate, this) : {
        _placeholder: !0
      };
    }
    function SVGTextElement(t, e, i) {
      this.textSpans = [], this.renderType = "svg", this.initElement(t, e, i);
    }
    function SVGShapeElement(t, e, i) {
      //List of drawable elements
      this.shapes = [], 
      // Full shape data
      this.shapesData = t.shapes, 
      //List of styles that will be applied to shapes
      this.stylesList = [], 
      //List of modifiers that will be applied to shapes
      this.shapeModifiers = [], 
      //List of items in shape tree
      this.itemsData = [], 
      //List of items in previous shape tree
      this.processedElements = [], 
      // List of animated components
      this.animatedContents = [], this.initElement(t, e, i), 
      //Moving any property that doesn't get too much access after initialization because of v8 way of handling more than 10 properties.
      // List of elements that have been created
      this.prevViewData = [];
    }
    function SVGTintFilter(t, e) {
      this.filterManager = e;
      var i = createNS("feColorMatrix");
      if (i.setAttribute("type", "matrix"), i.setAttribute("color-interpolation-filters", "linearRGB"), 
      i.setAttribute("values", "0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0 0 0 1 0"), 
      i.setAttribute("result", "f1"), t.appendChild(i), (i = createNS("feColorMatrix")).setAttribute("type", "matrix"), 
      i.setAttribute("color-interpolation-filters", "sRGB"), i.setAttribute("values", "1 0 0 0 0 0 1 0 0 0 0 0 1 0 0 0 0 0 1 0"), 
      i.setAttribute("result", "f2"), t.appendChild(i), this.matrixFilter = i, 100 !== e.effectElements[2].p.v || e.effectElements[2].p.k) {
        var s, a = createNS("feMerge");
        t.appendChild(a), (s = createNS("feMergeNode")).setAttribute("in", "SourceGraphic"), 
        a.appendChild(s), (s = createNS("feMergeNode")).setAttribute("in", "f2"), a.appendChild(s);
      }
    }
    function SVGFillFilter(t, e) {
      this.filterManager = e;
      var i = createNS("feColorMatrix");
      i.setAttribute("type", "matrix"), i.setAttribute("color-interpolation-filters", "sRGB"), 
      i.setAttribute("values", "1 0 0 0 0 0 1 0 0 0 0 0 1 0 0 0 0 0 1 0"), t.appendChild(i), 
      this.matrixFilter = i;
    }
    function SVGStrokeEffect(t, e) {
      this.initialized = !1, this.filterManager = e, this.elem = t, this.paths = [];
    }
    function SVGTritoneFilter(t, e) {
      this.filterManager = e;
      var i = createNS("feColorMatrix");
      i.setAttribute("type", "matrix"), i.setAttribute("color-interpolation-filters", "linearRGB"), 
      i.setAttribute("values", "0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0.3333 0.3333 0.3333 0 0 0 0 0 1 0"), 
      i.setAttribute("result", "f1"), t.appendChild(i);
      var s = createNS("feComponentTransfer");
      s.setAttribute("color-interpolation-filters", "sRGB"), t.appendChild(s), this.matrixFilter = s;
      var a = createNS("feFuncR");
      a.setAttribute("type", "table"), s.appendChild(a), this.feFuncR = a;
      var r = createNS("feFuncG");
      r.setAttribute("type", "table"), s.appendChild(r), this.feFuncG = r;
      var n = createNS("feFuncB");
      n.setAttribute("type", "table"), s.appendChild(n), this.feFuncB = n;
    }
    function SVGProLevelsFilter(t, e) {
      this.filterManager = e;
      var i = this.filterManager.effectElements, s = createNS("feComponentTransfer");
      (i[10].p.k || 0 !== i[10].p.v || i[11].p.k || 1 !== i[11].p.v || i[12].p.k || 1 !== i[12].p.v || i[13].p.k || 0 !== i[13].p.v || i[14].p.k || 1 !== i[14].p.v) && (this.feFuncR = this.createFeFunc("feFuncR", s)), 
      (i[17].p.k || 0 !== i[17].p.v || i[18].p.k || 1 !== i[18].p.v || i[19].p.k || 1 !== i[19].p.v || i[20].p.k || 0 !== i[20].p.v || i[21].p.k || 1 !== i[21].p.v) && (this.feFuncG = this.createFeFunc("feFuncG", s)), 
      (i[24].p.k || 0 !== i[24].p.v || i[25].p.k || 1 !== i[25].p.v || i[26].p.k || 1 !== i[26].p.v || i[27].p.k || 0 !== i[27].p.v || i[28].p.k || 1 !== i[28].p.v) && (this.feFuncB = this.createFeFunc("feFuncB", s)), 
      (i[31].p.k || 0 !== i[31].p.v || i[32].p.k || 1 !== i[32].p.v || i[33].p.k || 1 !== i[33].p.v || i[34].p.k || 0 !== i[34].p.v || i[35].p.k || 1 !== i[35].p.v) && (this.feFuncA = this.createFeFunc("feFuncA", s)), 
      (this.feFuncR || this.feFuncG || this.feFuncB || this.feFuncA) && (s.setAttribute("color-interpolation-filters", "sRGB"), 
      t.appendChild(s), s = createNS("feComponentTransfer")), (i[3].p.k || 0 !== i[3].p.v || i[4].p.k || 1 !== i[4].p.v || i[5].p.k || 1 !== i[5].p.v || i[6].p.k || 0 !== i[6].p.v || i[7].p.k || 1 !== i[7].p.v) && (s.setAttribute("color-interpolation-filters", "sRGB"), 
      t.appendChild(s), this.feFuncRComposed = this.createFeFunc("feFuncR", s), this.feFuncGComposed = this.createFeFunc("feFuncG", s), 
      this.feFuncBComposed = this.createFeFunc("feFuncB", s));
    }
    function SVGDropShadowEffect(t, e) {
      t.setAttribute("x", "-100%"), t.setAttribute("y", "-100%"), t.setAttribute("width", "400%"), 
      t.setAttribute("height", "400%"), this.filterManager = e;
      var i = createNS("feGaussianBlur");
      i.setAttribute("in", "SourceAlpha"), i.setAttribute("result", "drop_shadow_1"), 
      i.setAttribute("stdDeviation", "0"), this.feGaussianBlur = i, t.appendChild(i);
      var s = createNS("feOffset");
      s.setAttribute("dx", "25"), s.setAttribute("dy", "0"), s.setAttribute("in", "drop_shadow_1"), 
      s.setAttribute("result", "drop_shadow_2"), this.feOffset = s, t.appendChild(s);
      var a = createNS("feFlood");
      a.setAttribute("flood-color", "#00ff00"), a.setAttribute("flood-opacity", "1"), 
      a.setAttribute("result", "drop_shadow_3"), this.feFlood = a, t.appendChild(a);
      var r = createNS("feComposite");
      r.setAttribute("in", "drop_shadow_3"), r.setAttribute("in2", "drop_shadow_2"), r.setAttribute("operator", "in"), 
      r.setAttribute("result", "drop_shadow_4"), t.appendChild(r);
      var n, o = createNS("feMerge");
      t.appendChild(o), n = createNS("feMergeNode"), o.appendChild(n), (n = createNS("feMergeNode")).setAttribute("in", "SourceGraphic"), 
      this.feMergeNode = n, this.feMerge = o, this.originalNodeAdded = !1, o.appendChild(n);
    }
    BaseElement.prototype = {
      checkMasks: function() {
        if (!this.data.hasMask) return !1;
        for (var t = 0, e = this.data.masksProperties.length; t < e; ) {
          if ("n" !== this.data.masksProperties[t].mode && !1 !== this.data.masksProperties[t].cl) return !0;
          t += 1;
        }
        return !1;
      },
      initExpressions: function() {
        this.layerInterface = LayerExpressionInterface(this), this.data.hasMask && this.maskManager && this.layerInterface.registerMaskInterface(this.maskManager);
        var t = EffectsExpressionInterface.createEffectsInterface(this, this.layerInterface);
        this.layerInterface.registerEffectsInterface(t), 0 === this.data.ty || this.data.xt ? this.compInterface = CompExpressionInterface(this) : 4 === this.data.ty ? (this.layerInterface.shapeInterface = ShapeExpressionInterface(this.shapesData, this.itemsData, this.layerInterface), 
        this.layerInterface.content = this.layerInterface.shapeInterface) : 5 === this.data.ty && (this.layerInterface.textInterface = TextExpressionInterface(this), 
        this.layerInterface.text = this.layerInterface.textInterface);
      },
      blendModeEnums: {
        1: "multiply",
        2: "screen",
        3: "overlay",
        4: "darken",
        5: "lighten",
        6: "color-dodge",
        7: "color-burn",
        8: "hard-light",
        9: "soft-light",
        10: "difference",
        11: "exclusion",
        12: "hue",
        13: "saturation",
        14: "color",
        15: "luminosity"
      },
      getBlendMode: function() {
        return this.blendModeEnums[this.data.bm] || "";
      },
      setBlendMode: function() {
        var t = this.getBlendMode();
        (this.baseElement || this.layerElement).style["mix-blend-mode"] = t;
      },
      initBaseData: function(t, e, i) {
        this.globalData = e, this.comp = i, this.data = t, this.layerId = "ly_" + randomString(10), 
        //Stretch factor for old animations missing this property.
        this.data.sr || (this.data.sr = 1), 
        // effects manager
        this.effectsManager = new EffectsManager(this.data, this, this.dynamicProperties);
      },
      getType: function() {
        return this.type;
      }
    }, NullElement.prototype.prepareFrame = function(t) {
      this.prepareProperties(t, !0);
    }, NullElement.prototype.renderFrame = function() {}, NullElement.prototype.getBaseElement = function() {
      return null;
    }, NullElement.prototype.destroy = function() {}, NullElement.prototype.sourceRectAtTime = function() {}, 
    NullElement.prototype.hide = function() {}, extendPrototype([ BaseElement, TransformElement, HierarchyElement, FrameElement ], NullElement), 
    SVGBaseElement.prototype = {
      initRendererElement: function() {
        this.layerElement = createNS("g");
      },
      createContainerElements: function() {
        this.matteElement = createNS("g"), this.transformedElement = this.layerElement, 
        this.maskedElement = this.layerElement, this._sizeChanged = !1;
        var t, e, i, a = null;
        //If this layer acts as a mask for the following layer
                if (this.data.td) {
          if (3 == this.data.td || 1 == this.data.td) {
            var r = createNS("mask");
            r.setAttribute("id", this.layerId), r.setAttribute("mask-type", 3 == this.data.td ? "luminance" : "alpha"), 
            r.appendChild(this.layerElement), a = r, this.globalData.defs.appendChild(r), 
            // This is only for IE and Edge when mask if of type alpha
            x.maskType || 1 != this.data.td || (r.setAttribute("mask-type", "luminance"), t = randomString(10), 
            e = C.createFilter(t), this.globalData.defs.appendChild(e), e.appendChild(C.createAlphaToLuminanceFilter()), 
            (i = createNS("g")).appendChild(this.layerElement), a = i, r.appendChild(i), i.setAttribute("filter", "url(" + s + "#" + t + ")"));
          } else if (2 == this.data.td) {
            var n = createNS("mask");
            n.setAttribute("id", this.layerId), n.setAttribute("mask-type", "alpha");
            var o = createNS("g");
            n.appendChild(o), t = randomString(10), e = C.createFilter(t);
            ////
            var h = createNS("feColorMatrix");
            h.setAttribute("type", "matrix"), h.setAttribute("color-interpolation-filters", "sRGB"), 
            h.setAttribute("values", "1 0 0 0 0 0 1 0 0 0 0 0 1 0 0 0 0 0 -1 1"), e.appendChild(h), 
            ////
            /*var feCTr = createNS('feComponentTransfer');
                feCTr.setAttribute('in','SourceGraphic');
                fil.appendChild(feCTr);
                var feFunc = createNS('feFuncA');
                feFunc.setAttribute('type','table');
                feFunc.setAttribute('tableValues','1.0 0.0');
                feCTr.appendChild(feFunc);*/
            this.globalData.defs.appendChild(e);
            var l = createNS("rect");
            l.setAttribute("width", this.comp.data.w), l.setAttribute("height", this.comp.data.h), 
            l.setAttribute("x", "0"), l.setAttribute("y", "0"), l.setAttribute("fill", "#ffffff"), 
            l.setAttribute("opacity", "0"), o.setAttribute("filter", "url(" + s + "#" + t + ")"), 
            o.appendChild(l), o.appendChild(this.layerElement), a = o, x.maskType || (n.setAttribute("mask-type", "luminance"), 
            e.appendChild(C.createAlphaToLuminanceFilter()), i = createNS("g"), o.appendChild(l), 
            i.appendChild(this.layerElement), a = i, o.appendChild(i)), this.globalData.defs.appendChild(n);
          }
        } else this.data.tt ? (this.matteElement.appendChild(this.layerElement), a = this.matteElement, 
        this.baseElement = this.matteElement) : this.baseElement = this.layerElement;
        //Clipping compositions to hide content that exceeds boundaries. If collapsed transformations is on, component should not be clipped
        if (this.data.ln && this.layerElement.setAttribute("id", this.data.ln), this.data.cl && this.layerElement.setAttribute("class", this.data.cl), 
        0 === this.data.ty && !this.data.hd) {
          var p = createNS("clipPath"), f = createNS("path");
          f.setAttribute("d", "M0,0 L" + this.data.w + ",0 L" + this.data.w + "," + this.data.h + " L0," + this.data.h + "z");
          var m = "cp_" + randomString(8);
          if (p.setAttribute("id", m), p.appendChild(f), this.globalData.defs.appendChild(p), 
          this.checkMasks()) {
            var d = createNS("g");
            d.setAttribute("clip-path", "url(" + s + "#" + m + ")"), d.appendChild(this.layerElement), 
            this.transformedElement = d, a ? a.appendChild(this.transformedElement) : this.baseElement = this.transformedElement;
          } else this.layerElement.setAttribute("clip-path", "url(" + s + "#" + m + ")");
        }
        0 !== this.data.bm && this.setBlendMode(), this.renderableEffectsManager = new SVGEffects(this);
      },
      renderElement: function() {
        this.finalTransform._matMdf && this.transformedElement.setAttribute("transform", this.finalTransform.mat.to2dCSS()), 
        this.finalTransform._opMdf && this.transformedElement.setAttribute("opacity", this.finalTransform.mProp.o.v);
      },
      destroyBaseElement: function() {
        this.layerElement = null, this.matteElement = null, this.maskManager.destroy();
      },
      getBaseElement: function() {
        return this.data.hd ? null : this.baseElement;
      },
      addMasks: function() {
        this.maskManager = new MaskElement(this.data, this, this.globalData);
      },
      setMatte: function(t) {
        this.matteElement && this.matteElement.setAttribute("mask", "url(" + s + "#" + t + ")");
      }
    }, IShapeElement.prototype = {
      addShapeToModifiers: function(t) {
        var e, i = this.shapeModifiers.length;
        for (e = 0; e < i; e += 1) this.shapeModifiers[e].addShape(t);
      },
      isShapeInAnimatedModifiers: function(t) {
        for (var e = this.shapeModifiers.length; 0 < e; ) if (this.shapeModifiers[0].isAnimatedWithShape(t)) return !0;
        return !1;
      },
      renderModifiers: function() {
        if (this.shapeModifiers.length) {
          var t, e = this.shapes.length;
          for (t = 0; t < e; t += 1) this.shapes[t].sh.reset();
          for (t = (e = this.shapeModifiers.length) - 1; t >= 0; t -= 1) this.shapeModifiers[t].processShapes(this._isFirstFrame);
        }
      },
      lcEnum: {
        1: "butt",
        2: "round",
        3: "square"
      },
      ljEnum: {
        1: "miter",
        2: "round",
        3: "bevel"
      },
      searchProcessedElement: function(t) {
        for (var e = this.processedElements, i = 0, s = e.length; i < s; ) {
          if (e[i].elem === t) return e[i].pos;
          i += 1;
        }
        return 0;
      },
      addProcessedElement: function(t, e) {
        for (var i = this.processedElements, s = i.length; s; ) if (i[s -= 1].elem === t) return void (i[s].pos = e);
        i.push(new ProcessedElement(t, e));
      },
      prepareFrame: function(t) {
        this.prepareRenderableFrame(t), this.prepareProperties(t, this.isInRange);
      }
    }, ITextElement.prototype.initElement = function(t, e, i) {
      this.lettersChangedFlag = !0, this.initFrame(), this.initBaseData(t, e, i), this.textProperty = new TextProperty(this, t.t, this.dynamicProperties), 
      this.textAnimator = new TextAnimatorProperty(t.t, this.renderType, this), this.initTransform(t, e, i), 
      this.initHierarchy(), this.initRenderable(), this.initRendererElement(), this.createContainerElements(), 
      this.addMasks(), this.createContent(), this.hide(), this.textAnimator.searchProperties(this.dynamicProperties);
    }, ITextElement.prototype.prepareFrame = function(t) {
      this._mdf = !1, this.prepareRenderableFrame(t), this.prepareProperties(t, this.isInRange), 
      (this.textProperty._mdf || this.textProperty._isFirstFrame) && (this.buildNewText(), 
      this.textProperty._isFirstFrame = !1, this.textProperty._mdf = !1);
    }, ITextElement.prototype.createPathShape = function(t, e) {
      var i, s, a = e.length, r = "";
      for (i = 0; i < a; i += 1) s = e[i].ks.k, r += E(s, s.i.length, !0, t);
      return r;
    }, ITextElement.prototype.updateDocumentData = function(t, e) {
      this.textProperty.updateDocumentData(t, e);
    }, ITextElement.prototype.canResizeFont = function(t) {
      this.textProperty.canResizeFont(t);
    }, ITextElement.prototype.setMinimumFontSize = function(t) {
      this.textProperty.setMinimumFontSize(t);
    }, ITextElement.prototype.applyTextPropertiesToMatrix = function(t, e, i, s, a) {
      switch (t.ps && e.translate(t.ps[0], t.ps[1] + t.ascent, 0), e.translate(0, -t.ls, 0), 
      t.j) {
       case 1:
        e.translate(t.justifyOffset + (t.boxWidth - t.lineWidths[i]), 0, 0);
        break;

       case 2:
        e.translate(t.justifyOffset + (t.boxWidth - t.lineWidths[i]) / 2, 0, 0);
      }
      e.translate(s, a, 0);
    }, ITextElement.prototype.buildColor = function(t) {
      return "rgb(" + Math.round(255 * t[0]) + "," + Math.round(255 * t[1]) + "," + Math.round(255 * t[2]) + ")";
    }, ITextElement.prototype.emptyProp = new LetterProps(), ITextElement.prototype.destroy = function() {}, 
    extendPrototype([ BaseElement, TransformElement, HierarchyElement, FrameElement, RenderableDOMElement ], ICompElement), 
    ICompElement.prototype.initElement = function(t, e, i) {
      this.initFrame(), this.initBaseData(t, e, i), this.initTransform(t, e, i), this.initRenderable(), 
      this.initHierarchy(), this.initRendererElement(), this.createContainerElements(), 
      this.addMasks(), !this.data.xt && e.progressiveLoad || this.buildAllItems(), this.hide();
    }, 
    /*ICompElement.prototype.hide = function(){
    if(!this.hidden){
        this.hideElement();
        var i,len = this.elements.length;
        for( i = 0; i < len; i+=1 ){
            if(this.elements[i]){
                this.elements[i].hide();
            }
        }
    }
};*/
    ICompElement.prototype.prepareFrame = function(t) {
      if (this._mdf = !1, this.prepareRenderableFrame(t), this.prepareProperties(t, this.isInRange), 
      this.isInRange || this.data.xt) {
        if (this.tm._placeholder) this.renderedFrame = t / this.data.sr; else {
          var e = this.tm.v;
          e === this.data.op && (e = this.data.op - 1), this.renderedFrame = e;
        }
        var i, s = this.elements.length;
        //This iteration needs to be backwards because of how expressions connect between each other
        for (this.completeLayers || this.checkLayers(this.renderedFrame), i = s - 1; i >= 0; i -= 1) (this.completeLayers || this.elements[i]) && (this.elements[i].prepareFrame(this.renderedFrame - this.layers[i].st), 
        this.elements[i]._mdf && (this._mdf = !0));
      }
    }, ICompElement.prototype.renderInnerContent = function() {
      var t, e = this.layers.length;
      for (t = 0; t < e; t += 1) (this.completeLayers || this.elements[t]) && this.elements[t].renderFrame();
    }, ICompElement.prototype.setElements = function(t) {
      this.elements = t;
    }, ICompElement.prototype.getElements = function() {
      return this.elements;
    }, ICompElement.prototype.destroyElements = function() {
      var t, e = this.layers.length;
      for (t = 0; t < e; t += 1) this.elements[t] && this.elements[t].destroy();
    }, ICompElement.prototype.destroy = function() {
      this.destroyElements(), this.destroyBaseElement();
    }, extendPrototype([ BaseElement, TransformElement, SVGBaseElement, HierarchyElement, FrameElement, RenderableDOMElement ], IImageElement), 
    IImageElement.prototype.createContent = function() {
      var t = this.globalData.getAssetsPath(this.assetData);
      this.innerElem = createNS("image"), this.innerElem.setAttribute("width", this.assetData.w + "px"), 
      this.innerElem.setAttribute("height", this.assetData.h + "px"), this.innerElem.setAttribute("preserveAspectRatio", this.assetData.pr || this.globalData.renderConfig.imagePreserveAspectRatio), 
      this.innerElem.setAttributeNS("http://www.w3.org/1999/xlink", "href", t), this.layerElement.appendChild(this.innerElem);
    }, extendPrototype([ IImageElement ], ISolidElement), ISolidElement.prototype.createContent = function() {
      var t = createNS("rect");
      ////rect.style.width = this.data.sw;
      ////rect.style.height = this.data.sh;
      ////rect.style.fill = this.data.sc;
            t.setAttribute("width", this.data.sw), t.setAttribute("height", this.data.sh), 
      t.setAttribute("fill", this.data.sc), this.layerElement.appendChild(t);
    }, extendPrototype([ SVGRenderer, ICompElement, SVGBaseElement ], SVGCompElement), 
    extendPrototype([ BaseElement, TransformElement, SVGBaseElement, HierarchyElement, FrameElement, RenderableDOMElement, ITextElement ], SVGTextElement), 
    SVGTextElement.prototype.createContent = function() {
      this.data.singleShape && !this.globalData.fontManager.chars && (this.textContainer = createNS("text"));
    }, SVGTextElement.prototype.buildTextContents = function(t) {
      for (var e = 0, i = t.length, s = [], a = ""; e < i; ) t[e] === String.fromCharCode(13) ? (s.push(a), 
      a = "") : a += t[e], e += 1;
      return s.push(a), s;
    }, SVGTextElement.prototype.buildNewText = function() {
      var t, e, i = this.textProperty.currentData;
      this.renderedLetters = createSizedArray(i ? i.l.length : 0), i.fc ? this.layerElement.setAttribute("fill", this.buildColor(i.fc)) : this.layerElement.setAttribute("fill", "rgba(0,0,0,0)"), 
      i.sc && (this.layerElement.setAttribute("stroke", this.buildColor(i.sc)), this.layerElement.setAttribute("stroke-width", i.sw)), 
      this.layerElement.setAttribute("font-size", i.finalSize);
      var s = this.globalData.fontManager.getFontByName(i.f);
      if (s.fClass) this.layerElement.setAttribute("class", s.fClass); else {
        this.layerElement.setAttribute("font-family", s.fFamily);
        var a = i.fWeight, r = i.fStyle;
        this.layerElement.setAttribute("font-style", r), this.layerElement.setAttribute("font-weight", a);
      }
      var n, o = i.l || [], h = this.globalData.fontManager.chars;
      e = o.length;
      var l, p = this.mHelper, f = "", m = this.data.singleShape, d = 0, c = 0, u = !0, g = i.tr / 1e3 * i.finalSize;
      if (!m || h || i.sz) {
        var y, v, S = this.textSpans.length;
        for (t = 0; t < e; t += 1) h && m && 0 !== t || (n = S > t ? this.textSpans[t] : createNS(h ? "path" : "text"), 
        S <= t && (n.setAttribute("stroke-linecap", "butt"), n.setAttribute("stroke-linejoin", "round"), 
        n.setAttribute("stroke-miterlimit", "4"), this.textSpans[t] = n, this.layerElement.appendChild(n)), 
        n.style.display = "inherit"), p.reset(), p.scale(i.finalSize / 100, i.finalSize / 100), 
        m && (o[t].n && (d = -g, c += i.yOffset, c += u ? 1 : 0, u = !1), this.applyTextPropertiesToMatrix(i, p, o[t].line, d, c), 
        d += o[t].l || 0, 
        //xPos += letters[i].val === ' ' ? 0 : trackingOffset;
        d += g), h ? (l = (y = (v = this.globalData.fontManager.getCharData(i.finalText[t], s.fStyle, this.globalData.fontManager.getFontByName(i.f).fFamily)) && v.data || {}).shapes ? y.shapes[0].it : [], 
        m ? f += this.createPathShape(p, l) : n.setAttribute("d", this.createPathShape(p, l))) : (m && n.setAttribute("transform", "translate(" + p.props[12] + "," + p.props[13] + ")"), 
        n.textContent = o[t].val, n.setAttributeNS("http://www.w3.org/XML/1998/namespace", "xml:space", "preserve"));
        m && n && n.setAttribute("d", f);
      } else {
        var b = this.textContainer, P = "start";
        switch (i.j) {
         case 1:
          P = "end";
          break;

         case 2:
          P = "middle";
        }
        b.setAttribute("text-anchor", P), b.setAttribute("letter-spacing", g);
        var _ = this.buildTextContents(i.finalText);
        for (e = _.length, c = i.ps ? i.ps[1] + i.ascent : 0, t = 0; t < e; t += 1) (n = this.textSpans[t] || createNS("tspan")).textContent = _[t], 
        n.setAttribute("x", 0), n.setAttribute("y", c), n.style.display = "inherit", b.appendChild(n), 
        this.textSpans[t] = n, c += i.finalLineHeight;
        this.layerElement.appendChild(b);
      }
      for (;t < this.textSpans.length; ) this.textSpans[t].style.display = "none", t += 1;
      this._sizeChanged = !0;
    }, SVGTextElement.prototype.sourceRectAtTime = function(t) {
      if (this.prepareFrame(this.comp.renderedFrame - this.data.st), this.renderInnerContent(), 
      this._sizeChanged) {
        this._sizeChanged = !1;
        var e = this.layerElement.getBBox();
        this.bbox = {
          top: e.y,
          left: e.x,
          width: e.width,
          height: e.height
        };
      }
      return this.bbox;
    }, SVGTextElement.prototype.renderInnerContent = function() {
      if (!this.data.singleShape && (this.textAnimator.getMeasures(this.textProperty.currentData, this.lettersChangedFlag), 
      this.lettersChangedFlag || this.textAnimator.lettersChangedFlag)) {
        var t, e;
        this._sizeChanged = !0;
        var i, s, a = this.textAnimator.renderedLetters, r = this.textProperty.currentData.l;
        for (e = r.length, t = 0; t < e; t += 1) r[t].n || (i = a[t], s = this.textSpans[t], 
        i._mdf.m && s.setAttribute("transform", i.m), i._mdf.o && s.setAttribute("opacity", i.o), 
        i._mdf.sw && s.setAttribute("stroke-width", i.sw), i._mdf.sc && s.setAttribute("stroke", i.sc), 
        i._mdf.fc && s.setAttribute("fill", i.fc));
      }
    }, extendPrototype([ BaseElement, TransformElement, SVGBaseElement, IShapeElement, HierarchyElement, FrameElement, RenderableDOMElement ], SVGShapeElement), 
    SVGShapeElement.prototype.initSecondaryElement = function() {}, SVGShapeElement.prototype.identityMatrix = new u(), 
    SVGShapeElement.prototype.buildExpressionInterface = function() {}, SVGShapeElement.prototype.createContent = function() {
      this.searchShapes(this.shapesData, this.itemsData, this.prevViewData, this.layerElement, 0, [], !0), 
      this.filterUniqueShapes();
    }, 
    /*
This method searches for multiple shapes that affect a single element and one of them is animated
*/
    SVGShapeElement.prototype.filterUniqueShapes = function() {
      var t, e, i, s, a = this.shapes.length, r = this.stylesList.length, n = [], o = !1;
      for (i = 0; i < r; i += 1) {
        for (s = this.stylesList[i], o = !1, n.length = 0, t = 0; t < a; t += 1) -1 !== (e = this.shapes[t]).styles.indexOf(s) && (n.push(e), 
        o = e._isAnimated || o);
        n.length > 1 && o && this.setShapesAsAnimated(n);
      }
    }, SVGShapeElement.prototype.setShapesAsAnimated = function(t) {
      var e, i = t.length;
      for (e = 0; e < i; e += 1) t[e].setAsAnimated();
    }, SVGShapeElement.prototype.createStyleElement = function(t, e) {
      //TODO: prevent drawing of hidden styles
      var i, s = new SVGStyleData(t, e), a = s.pElem;
      return "st" === t.ty ? i = new SVGStrokeStyleData(this, t, s) : "fl" === t.ty ? i = new SVGFillStyleData(this, t, s) : "gf" !== t.ty && "gs" !== t.ty || (i = new ("gf" === t.ty ? SVGGradientFillStyleData : SVGGradientStrokeStyleData)(this, t, s), 
      this.globalData.defs.appendChild(i.gf), i.maskId && (this.globalData.defs.appendChild(i.ms), 
      this.globalData.defs.appendChild(i.of), a.setAttribute("mask", "url(#" + i.maskId + ")"))), 
      "st" !== t.ty && "gs" !== t.ty || (a.setAttribute("stroke-linecap", this.lcEnum[t.lc] || "round"), 
      a.setAttribute("stroke-linejoin", this.ljEnum[t.lj] || "round"), a.setAttribute("fill-opacity", "0"), 
      1 === t.lj && a.setAttribute("stroke-miterlimit", t.ml)), 2 === t.r && a.setAttribute("fill-rule", "evenodd"), 
      t.ln && a.setAttribute("id", t.ln), t.cl && a.setAttribute("class", t.cl), this.stylesList.push(s), 
      this.addToAnimatedContents(t, i), i;
    }, SVGShapeElement.prototype.createGroupElement = function(t) {
      var e = new ShapeGroupData();
      return t.ln && e.gr.setAttribute("id", t.ln), e;
    }, SVGShapeElement.prototype.createTransformElement = function(t, e) {
      var i = P.getTransformProperty(this, t, this), s = new SVGTransformData(i, i.o, e);
      return this.addToAnimatedContents(t, s), s;
    }, SVGShapeElement.prototype.createShapeElement = function(t, e, i) {
      var s = 4;
      "rc" === t.ty ? s = 5 : "el" === t.ty ? s = 6 : "sr" === t.ty && (s = 7);
      var a = new SVGShapeData(e, i, _.getShapeProp(this, t, s, this));
      return this.shapes.push(a), this.addShapeToModifiers(a), this.addToAnimatedContents(t, a), 
      a;
    }, SVGShapeElement.prototype.addToAnimatedContents = function(t, e) {
      for (var i = 0, s = this.animatedContents.length; i < s; ) {
        if (this.animatedContents[i].element === e) return;
        i += 1;
      }
      this.animatedContents.push({
        fn: B.createRenderFunction(t),
        element: e,
        data: t
      });
    }, SVGShapeElement.prototype.setElementStyles = function(t) {
      var e, i = t.styles, s = this.stylesList.length;
      for (e = 0; e < s; e += 1) this.stylesList[e].closed || i.push(this.stylesList[e]);
    }, SVGShapeElement.prototype.reloadShapes = function() {
      this._isFirstFrame = !0;
      var t, e = this.itemsData.length;
      for (t = 0; t < e; t += 1) this.prevViewData[t] = this.itemsData[t];
      for (this.searchShapes(this.shapesData, this.itemsData, this.prevViewData, this.layerElement, 0, [], !0), 
      this.filterUniqueShapes(), e = this.dynamicProperties.length, t = 0; t < e; t += 1) this.dynamicProperties[t].getValue();
      this.renderModifiers();
    }, SVGShapeElement.prototype.searchShapes = function(t, e, i, s, a, r, n) {
      var o, h, l, p, f, m, d = [].concat(r), c = t.length - 1, u = [], g = [];
      for (o = c; o >= 0; o -= 1) {
        if ((m = this.searchProcessedElement(t[o])) ? e[o] = i[m - 1] : t[o]._render = n, 
        "fl" == t[o].ty || "st" == t[o].ty || "gf" == t[o].ty || "gs" == t[o].ty) m ? e[o].style.closed = !1 : e[o] = this.createStyleElement(t[o], a), 
        t[o]._render && s.appendChild(e[o].style.pElem), u.push(e[o].style); else if ("gr" == t[o].ty) {
          if (m) for (l = e[o].it.length, h = 0; h < l; h += 1) e[o].prevViewData[h] = e[o].it[h]; else e[o] = this.createGroupElement(t[o]);
          this.searchShapes(t[o].it, e[o].it, e[o].prevViewData, e[o].gr, a + 1, d, n), t[o]._render && s.appendChild(e[o].gr);
        } else "tr" == t[o].ty ? (m || (e[o] = this.createTransformElement(t[o], s)), p = e[o].transform, 
        d.push(p)) : "sh" == t[o].ty || "rc" == t[o].ty || "el" == t[o].ty || "sr" == t[o].ty ? (m || (e[o] = this.createShapeElement(t[o], d, a)), 
        this.setElementStyles(e[o])) : "tm" == t[o].ty || "rd" == t[o].ty || "ms" == t[o].ty ? (m ? (f = e[o]).closed = !1 : ((f = k.getModifier(t[o].ty)).init(this, t[o]), 
        e[o] = f, this.shapeModifiers.push(f)), g.push(f)) : "rp" == t[o].ty && (m ? (f = e[o]).closed = !0 : (f = k.getModifier(t[o].ty), 
        e[o] = f, f.init(this, t, o, e), this.shapeModifiers.push(f), n = !1), g.push(f));
        this.addProcessedElement(t[o], o + 1);
      }
      for (c = u.length, o = 0; o < c; o += 1) u[o].closed = !0;
      for (c = g.length, o = 0; o < c; o += 1) g[o].closed = !0;
    }, SVGShapeElement.prototype.renderInnerContent = function() {
      this.renderModifiers();
      var t, e = this.stylesList.length;
      for (t = 0; t < e; t += 1) this.stylesList[t].reset();
      for (this.renderShape(), t = 0; t < e; t += 1) (this.stylesList[t]._mdf || this._isFirstFrame) && (this.stylesList[t].msElem && (this.stylesList[t].msElem.setAttribute("d", this.stylesList[t].d), 
      //Adding M0 0 fixes same mask bug on all browsers
      this.stylesList[t].d = "M0 0" + this.stylesList[t].d), this.stylesList[t].pElem.setAttribute("d", this.stylesList[t].d || "M0 0"));
    }, SVGShapeElement.prototype.renderShape = function() {
      var t, e, i = this.animatedContents.length;
      for (t = 0; t < i; t += 1) e = this.animatedContents[t], (this._isFirstFrame || e.element._isAnimated) && !0 !== e.data && e.fn(e.data, e.element, this._isFirstFrame);
    }, SVGShapeElement.prototype.destroy = function() {
      this.destroyBaseElement(), this.shapesData = null, this.itemsData = null;
    }, SVGTintFilter.prototype.renderFrame = function(t) {
      if (t || this.filterManager._mdf) {
        var e = this.filterManager.effectElements[0].p.v, i = this.filterManager.effectElements[1].p.v, s = this.filterManager.effectElements[2].p.v / 100;
        this.matrixFilter.setAttribute("values", i[0] - e[0] + " 0 0 0 " + e[0] + " " + (i[1] - e[1]) + " 0 0 0 " + e[1] + " " + (i[2] - e[2]) + " 0 0 0 " + e[2] + " 0 0 0 " + s + " 0");
      }
    }, SVGFillFilter.prototype.renderFrame = function(t) {
      if (t || this.filterManager._mdf) {
        var e = this.filterManager.effectElements[2].p.v, i = this.filterManager.effectElements[6].p.v;
        this.matrixFilter.setAttribute("values", "0 0 0 0 " + e[0] + " 0 0 0 0 " + e[1] + " 0 0 0 0 " + e[2] + " 0 0 0 " + i + " 0");
      }
    }, SVGStrokeEffect.prototype.initialize = function() {
      var t, e, i, a, r = this.elem.layerElement.children || this.elem.layerElement.childNodes;
      for (1 === this.filterManager.effectElements[1].p.v ? (a = this.elem.maskManager.masksProperties.length, 
      i = 0) : a = 1 + (i = this.filterManager.effectElements[0].p.v - 1), (e = createNS("g")).setAttribute("fill", "none"), 
      e.setAttribute("stroke-linecap", "round"), e.setAttribute("stroke-dashoffset", 1); i < a; i += 1) t = createNS("path"), 
      e.appendChild(t), this.paths.push({
        p: t,
        m: i
      });
      if (3 === this.filterManager.effectElements[10].p.v) {
        var n = createNS("mask"), o = "stms_" + randomString(10);
        n.setAttribute("id", o), n.setAttribute("mask-type", "alpha"), n.appendChild(e), 
        this.elem.globalData.defs.appendChild(n);
        var h = createNS("g");
        h.setAttribute("mask", "url(" + s + "#" + o + ")"), r[0] && h.appendChild(r[0]), 
        this.elem.layerElement.appendChild(h), this.masker = n, e.setAttribute("stroke", "#fff");
      } else if (1 === this.filterManager.effectElements[10].p.v || 2 === this.filterManager.effectElements[10].p.v) {
        if (2 === this.filterManager.effectElements[10].p.v) for (r = this.elem.layerElement.children || this.elem.layerElement.childNodes; r.length; ) this.elem.layerElement.removeChild(r[0]);
        this.elem.layerElement.appendChild(e), this.elem.layerElement.removeAttribute("mask"), 
        e.setAttribute("stroke", "#fff");
      }
      this.initialized = !0, this.pathMasker = e;
    }, SVGStrokeEffect.prototype.renderFrame = function(t) {
      this.initialized || this.initialize();
      var e, i, s, a = this.paths.length;
      for (e = 0; e < a; e += 1) if (-1 !== this.paths[e].m && (i = this.elem.maskManager.viewData[this.paths[e].m], 
      s = this.paths[e].p, (t || this.filterManager._mdf || i.prop._mdf) && s.setAttribute("d", i.lastPath), 
      t || this.filterManager.effectElements[9].p._mdf || this.filterManager.effectElements[4].p._mdf || this.filterManager.effectElements[7].p._mdf || this.filterManager.effectElements[8].p._mdf || i.prop._mdf)) {
        var r;
        if (0 !== this.filterManager.effectElements[7].p.v || 100 !== this.filterManager.effectElements[8].p.v) {
          var n = Math.min(this.filterManager.effectElements[7].p.v, this.filterManager.effectElements[8].p.v) / 100, o = Math.max(this.filterManager.effectElements[7].p.v, this.filterManager.effectElements[8].p.v) / 100, l = s.getTotalLength();
          r = "0 0 0 " + l * n + " ";
          var p, f = l * (o - n), m = 1 + 2 * this.filterManager.effectElements[4].p.v * this.filterManager.effectElements[9].p.v / 100, d = Math.floor(f / m);
          for (p = 0; p < d; p += 1) r += "1 " + 2 * this.filterManager.effectElements[4].p.v * this.filterManager.effectElements[9].p.v / 100 + " ";
          r += "0 " + 10 * l + " 0 0";
        } else r = "1 " + 2 * this.filterManager.effectElements[4].p.v * this.filterManager.effectElements[9].p.v / 100;
        s.setAttribute("stroke-dasharray", r);
      }
      if ((t || this.filterManager.effectElements[4].p._mdf) && this.pathMasker.setAttribute("stroke-width", 2 * this.filterManager.effectElements[4].p.v), 
      (t || this.filterManager.effectElements[6].p._mdf) && this.pathMasker.setAttribute("opacity", this.filterManager.effectElements[6].p.v), 
      (1 === this.filterManager.effectElements[10].p.v || 2 === this.filterManager.effectElements[10].p.v) && (t || this.filterManager.effectElements[3].p._mdf)) {
        var c = this.filterManager.effectElements[3].p.v;
        this.pathMasker.setAttribute("stroke", "rgb(" + h(255 * c[0]) + "," + h(255 * c[1]) + "," + h(255 * c[2]) + ")");
      }
    }, SVGTritoneFilter.prototype.renderFrame = function(t) {
      if (t || this.filterManager._mdf) {
        var e = this.filterManager.effectElements[0].p.v, i = this.filterManager.effectElements[1].p.v, s = this.filterManager.effectElements[2].p.v, a = s[0] + " " + i[0] + " " + e[0], r = s[1] + " " + i[1] + " " + e[1], n = s[2] + " " + i[2] + " " + e[2];
        this.feFuncR.setAttribute("tableValues", a), this.feFuncG.setAttribute("tableValues", r), 
        this.feFuncB.setAttribute("tableValues", n);
      }
    }, SVGProLevelsFilter.prototype.createFeFunc = function(t, e) {
      var i = createNS(t);
      return i.setAttribute("type", "table"), e.appendChild(i), i;
    }, SVGProLevelsFilter.prototype.getTableValue = function(t, e, i, s, a) {
      for (var r, n, o = 0, h = Math.min(t, e), l = Math.max(t, e), p = Array.call(null, {
        length: 256
      }), f = 0, m = a - s, d = e - t; o <= 256; ) n = (r = o / 256) <= h ? d < 0 ? a : s : r >= l ? d < 0 ? s : a : s + m * Math.pow((r - t) / d, 1 / i), 
      p[f++] = n, o += 256 / 255;
      return p.join(" ");
    }, SVGProLevelsFilter.prototype.renderFrame = function(t) {
      if (t || this.filterManager._mdf) {
        var e, i = this.filterManager.effectElements;
        this.feFuncRComposed && (t || i[3].p._mdf || i[4].p._mdf || i[5].p._mdf || i[6].p._mdf || i[7].p._mdf) && (e = this.getTableValue(i[3].p.v, i[4].p.v, i[5].p.v, i[6].p.v, i[7].p.v), 
        this.feFuncRComposed.setAttribute("tableValues", e), this.feFuncGComposed.setAttribute("tableValues", e), 
        this.feFuncBComposed.setAttribute("tableValues", e)), this.feFuncR && (t || i[10].p._mdf || i[11].p._mdf || i[12].p._mdf || i[13].p._mdf || i[14].p._mdf) && (e = this.getTableValue(i[10].p.v, i[11].p.v, i[12].p.v, i[13].p.v, i[14].p.v), 
        this.feFuncR.setAttribute("tableValues", e)), this.feFuncG && (t || i[17].p._mdf || i[18].p._mdf || i[19].p._mdf || i[20].p._mdf || i[21].p._mdf) && (e = this.getTableValue(i[17].p.v, i[18].p.v, i[19].p.v, i[20].p.v, i[21].p.v), 
        this.feFuncG.setAttribute("tableValues", e)), this.feFuncB && (t || i[24].p._mdf || i[25].p._mdf || i[26].p._mdf || i[27].p._mdf || i[28].p._mdf) && (e = this.getTableValue(i[24].p.v, i[25].p.v, i[26].p.v, i[27].p.v, i[28].p.v), 
        this.feFuncB.setAttribute("tableValues", e)), this.feFuncA && (t || i[31].p._mdf || i[32].p._mdf || i[33].p._mdf || i[34].p._mdf || i[35].p._mdf) && (e = this.getTableValue(i[31].p.v, i[32].p.v, i[33].p.v, i[34].p.v, i[35].p.v), 
        this.feFuncA.setAttribute("tableValues", e));
      }
    }, SVGDropShadowEffect.prototype.renderFrame = function(t) {
      if (t || this.filterManager._mdf) {
        if ((t || this.filterManager.effectElements[4].p._mdf) && this.feGaussianBlur.setAttribute("stdDeviation", this.filterManager.effectElements[4].p.v / 4), 
        t || this.filterManager.effectElements[0].p._mdf) {
          var e = this.filterManager.effectElements[0].p.v;
          this.feFlood.setAttribute("flood-color", d(Math.round(255 * e[0]), Math.round(255 * e[1]), Math.round(255 * e[2])));
        }
        if ((t || this.filterManager.effectElements[1].p._mdf) && this.feFlood.setAttribute("flood-opacity", this.filterManager.effectElements[1].p.v / 255), 
        t || this.filterManager.effectElements[2].p._mdf || this.filterManager.effectElements[3].p._mdf) {
          var i = this.filterManager.effectElements[3].p.v, s = (this.filterManager.effectElements[2].p.v - 90) * m, a = i * Math.cos(s), r = i * Math.sin(s);
          this.feOffset.setAttribute("dx", a), this.feOffset.setAttribute("dy", r);
        }
        /*if(forceRender || this.filterManager.effectElements[5].p._mdf){
            if(this.filterManager.effectElements[5].p.v === 1 && this.originalNodeAdded) {
                this.feMerge.removeChild(this.feMergeNode);
                this.originalNodeAdded = false;
            } else if(this.filterManager.effectElements[5].p.v === 0 && !this.originalNodeAdded) {
                this.feMerge.appendChild(this.feMergeNode);
                this.originalNodeAdded = true;
            }
        }*/      }
    };
    var z = [], O = 0;
    function SVGMatte3Effect(t, e, i) {
      this.initialized = !1, this.filterManager = e, this.filterElem = t, this.elem = i, 
      i.matteElement = createNS("g"), i.matteElement.appendChild(i.layerElement), i.matteElement.appendChild(i.transformedElement), 
      i.baseElement = i.matteElement;
    }
    function SVGEffects(t) {
      var e, i, a = t.data.ef ? t.data.ef.length : 0, r = randomString(10), n = C.createFilter(r), o = 0;
      for (this.filters = [], e = 0; e < a; e += 1) i = null, 20 === t.data.ef[e].ty ? (o += 1, 
      i = new SVGTintFilter(n, t.effectsManager.effectElements[e])) : 21 === t.data.ef[e].ty ? (o += 1, 
      i = new SVGFillFilter(n, t.effectsManager.effectElements[e])) : 22 === t.data.ef[e].ty ? i = new SVGStrokeEffect(t, t.effectsManager.effectElements[e]) : 23 === t.data.ef[e].ty ? (o += 1, 
      i = new SVGTritoneFilter(n, t.effectsManager.effectElements[e])) : 24 === t.data.ef[e].ty ? (o += 1, 
      i = new SVGProLevelsFilter(n, t.effectsManager.effectElements[e])) : 25 === t.data.ef[e].ty ? (o += 1, 
      i = new SVGDropShadowEffect(n, t.effectsManager.effectElements[e])) : 28 === t.data.ef[e].ty && (
      //count += 1;
      i = new SVGMatte3Effect(n, t.effectsManager.effectElements[e], t)), i && this.filters.push(i);
      o && (t.globalData.defs.appendChild(n), t.layerElement.setAttribute("filter", "url(" + s + "#" + r + ")")), 
      this.filters.length && t.addRenderableComponent(this);
    }
    SVGMatte3Effect.prototype.findSymbol = function(t) {
      for (var e = 0, i = z.length; e < i; ) {
        if (z[e] === t) return z[e];
        e += 1;
      }
      return null;
    }, SVGMatte3Effect.prototype.replaceInParent = function(t, e) {
      var i = t.layerElement.parentNode;
      if (i) {
        for (var s, a = i.children, r = 0, n = a.length; r < n && a[r] !== t.layerElement; ) r += 1;
        r <= n - 2 && (s = a[r + 1]);
        var o = createNS("use");
        o.setAttribute("href", "#" + e), s ? i.insertBefore(o, s) : i.appendChild(o);
      }
    }, SVGMatte3Effect.prototype.setElementAsMask = function(t, e) {
      if (!this.findSymbol(e)) {
        var i = "matte_" + randomString(5) + "_" + O++, s = createNS("mask");
        s.setAttribute("id", e.layerId), s.setAttribute("mask-type", "alpha"), z.push(e);
        var a = t.globalData.defs;
        a.appendChild(s);
        var r = createNS("symbol");
        r.setAttribute("id", i), this.replaceInParent(e, i), r.appendChild(e.layerElement), 
        a.appendChild(r);
        var n = createNS("use");
        n.setAttribute("href", "#" + i), s.appendChild(n), e.data.hd = !1, e.show();
      }
      t.setMatte(e.layerId);
    }, SVGMatte3Effect.prototype.initialize = function() {
      for (var t = this.filterManager.effectElements[0].p.v, e = 0, i = this.elem.comp.elements.length; e < i; ) this.elem.comp.elements[e].data.ind === t && this.setElementAsMask(this.elem, this.elem.comp.elements[e]), 
      e += 1;
      this.initialized = !0;
    }, SVGMatte3Effect.prototype.renderFrame = function() {
      this.initialized || this.initialize();
    }, SVGEffects.prototype.renderFrame = function(t) {
      var e, i = this.filters.length;
      for (e = 0; e < i; e += 1) this.filters[e].renderFrame(t);
    };
    var q = function() {
      var e = {}, i = [], s = 0, a = 0, r = 0, n = !0, o = !1;
      function removeElement(t) {
        for (var e = 0, s = t.target; e < a; ) i[e].animation === s && (i.splice(e, 1), 
        e -= 1, a -= 1, s.isPaused || subtractPlayingCount()), e += 1;
      }
      function registerAnimation(t, e) {
        if (!t) return null;
        for (var s = 0; s < a; ) {
          if (i[s].elem == t && null !== i[s].elem) return i[s].animation;
          s += 1;
        }
        var r = new j();
        return setupAnimation(r, t), r.setData(t, e), r;
      }
      function addPlayingCount() {
        r += 1, activate();
      }
      function subtractPlayingCount() {
        r -= 1;
      }
      function setupAnimation(t, e) {
        t.addEventListener("destroy", removeElement), t.addEventListener("_active", addPlayingCount), 
        t.addEventListener("_idle", subtractPlayingCount), i.push({
          elem: e,
          animation: t
        }), a += 1;
      }
      function resume(e) {
        var h, l = e - s;
        for (h = 0; h < a; h += 1) i[h].animation.advanceTime(l);
        s = e, r && !o ? t.requestAnimationFrame(resume) : n = !0;
      }
      function first(e) {
        s = e, t.requestAnimationFrame(resume);
      }
      function activate() {
        !o && r && n && (t.requestAnimationFrame(first), n = !1);
      }
      return e.registerAnimation = registerAnimation, e.loadAnimation = function(t) {
        var e = new j();
        return setupAnimation(e, null), e.setParams(t), e;
      }, e.setSpeed = function(t, e) {
        var s;
        for (s = 0; s < a; s += 1) i[s].animation.setSpeed(t, e);
      }, e.setDirection = function(t, e) {
        var s;
        for (s = 0; s < a; s += 1) i[s].animation.setDirection(t, e);
      }, e.play = function(t) {
        var e;
        for (e = 0; e < a; e += 1) i[e].animation.play(t);
      }, e.pause = function(t) {
        var e;
        for (e = 0; e < a; e += 1) i[e].animation.pause(t);
      }, e.stop = function(t) {
        var e;
        for (e = 0; e < a; e += 1) i[e].animation.stop(t);
      }, e.togglePause = function(t) {
        var e;
        for (e = 0; e < a; e += 1) i[e].animation.togglePause(t);
      }, e.searchAnimations = function(t, e, i) {
        var s, a = [].concat([].slice.call(document.getElementsByClassName("lottie")), [].slice.call(document.getElementsByClassName("bodymovin"))), r = a.length;
        for (s = 0; s < r; s += 1) i && a[s].setAttribute("data-bm-type", i), registerAnimation(a[s], t);
        if (e && 0 === r) {
          i || (i = "svg");
          var n = document.getElementsByTagName("body")[0];
          n.innerHTML = "";
          var o = createTag("div");
          o.style.width = "100%", o.style.height = "100%", o.setAttribute("data-bm-type", i), 
          n.appendChild(o), registerAnimation(o, t);
        }
      }, e.resize = function() {
        var t;
        for (t = 0; t < a; t += 1) i[t].animation.resize();
      }, 
      //moduleOb.start = start;
      e.goToAndStop = function(t, e, s) {
        var r;
        for (r = 0; r < a; r += 1) i[r].animation.goToAndStop(t, e, s);
      }, e.destroy = function(t) {
        var e;
        for (e = a - 1; e >= 0; e -= 1) i[e].animation.destroy(t);
      }, e.freeze = function() {
        o = !0;
      }, e.unfreeze = function() {
        o = !1, activate();
      }, e.getRegisteredAnimations = function() {
        var t, e = i.length, s = [];
        for (t = 0; t < e; t += 1) s.push(i[t].animation);
        return s;
      }, e;
    }(), j = function() {
      this._cbs = [], this.name = "", this.path = "", this.isLoaded = !1, this.currentFrame = 0, 
      this.currentRawFrame = 0, this.totalFrames = 0, this.frameRate = 0, this.frameMult = 0, 
      this.playSpeed = 1, this.playDirection = 1, this.pendingElements = 0, this.playCount = 0, 
      this.animationData = {}, this.assets = [], this.isPaused = !0, this.autoplay = !1, 
      this.loop = !0, this.renderer = null, this.animationID = randomString(10), this.assetsPath = "", 
      this.timeCompleted = 0, this.segmentPos = 0, this.subframeEnabled = r, this.segments = [], 
      this._idle = !0, this._completedLoop = !1, this.projectInterface = {};
    };
    function EffectsManager() {}
    extendPrototype([ BaseEvent ], j), j.prototype.setParams = function(t) {
      t.context && (this.context = t.context), (t.wrapper || t.container) && (this.wrapper = t.wrapper || t.container);
      var e = t.animType ? t.animType : t.renderer ? t.renderer : "svg";
      switch (e) {
       case "canvas":
        this.renderer = new CanvasRenderer(this, t.rendererSettings);
        break;

       case "svg":
        this.renderer = new SVGRenderer(this, t.rendererSettings);
        break;

       default:
        this.renderer = new HybridRenderer(this, t.rendererSettings);
      }
      this.renderer.setProjectInterface(this.projectInterface), this.animType = e, "" === t.loop || null === t.loop || (!1 === t.loop ? this.loop = !1 : !0 === t.loop ? this.loop = !0 : this.loop = parseInt(t.loop)), 
      this.autoplay = !("autoplay" in t) || t.autoplay, this.name = t.name ? t.name : "", 
      this.autoloadSegments = !t.hasOwnProperty("autoloadSegments") || t.autoloadSegments, 
      this.assetsPath = t.assetsPath, t.animationData ? this.configAnimation(t.animationData) : t.path && ("json" != t.path.substr(-4) && ("/" != t.path.substr(-1, 1) && (t.path += "/"), 
      t.path += "data.json"), -1 != t.path.lastIndexOf("\\") ? this.path = t.path.substr(0, t.path.lastIndexOf("\\") + 1) : this.path = t.path.substr(0, t.path.lastIndexOf("/") + 1), 
      this.fileName = t.path.substr(t.path.lastIndexOf("/") + 1), this.fileName = this.fileName.substr(0, this.fileName.lastIndexOf(".json")), 
      D.load(t.path, this.configAnimation.bind(this), function() {
        this.trigger("data_failed");
      }.bind(this)));
    }, j.prototype.setData = function(t, e) {
      var i = {
        wrapper: t,
        animationData: e ? "object" == typeof e ? e : JSON.parse(e) : null
      }, s = t.attributes;
      i.path = s.getNamedItem("data-animation-path") ? s.getNamedItem("data-animation-path").value : s.getNamedItem("data-bm-path") ? s.getNamedItem("data-bm-path").value : s.getNamedItem("bm-path") ? s.getNamedItem("bm-path").value : "", 
      i.animType = s.getNamedItem("data-anim-type") ? s.getNamedItem("data-anim-type").value : s.getNamedItem("data-bm-type") ? s.getNamedItem("data-bm-type").value : s.getNamedItem("bm-type") ? s.getNamedItem("bm-type").value : s.getNamedItem("data-bm-renderer") ? s.getNamedItem("data-bm-renderer").value : s.getNamedItem("bm-renderer") ? s.getNamedItem("bm-renderer").value : "canvas";
      var a = s.getNamedItem("data-anim-loop") ? s.getNamedItem("data-anim-loop").value : s.getNamedItem("data-bm-loop") ? s.getNamedItem("data-bm-loop").value : s.getNamedItem("bm-loop") ? s.getNamedItem("bm-loop").value : "";
      "" === a || (i.loop = "false" !== a && ("true" === a || parseInt(a)));
      var r = s.getNamedItem("data-anim-autoplay") ? s.getNamedItem("data-anim-autoplay").value : s.getNamedItem("data-bm-autoplay") ? s.getNamedItem("data-bm-autoplay").value : !s.getNamedItem("bm-autoplay") || s.getNamedItem("bm-autoplay").value;
      i.autoplay = "false" !== r, i.name = s.getNamedItem("data-name") ? s.getNamedItem("data-name").value : s.getNamedItem("data-bm-name") ? s.getNamedItem("data-bm-name").value : s.getNamedItem("bm-name") ? s.getNamedItem("bm-name").value : "", 
      "false" === (s.getNamedItem("data-anim-prerender") ? s.getNamedItem("data-anim-prerender").value : s.getNamedItem("data-bm-prerender") ? s.getNamedItem("data-bm-prerender").value : s.getNamedItem("bm-prerender") ? s.getNamedItem("bm-prerender").value : "") && (i.prerender = !1), 
      this.setParams(i);
    }, j.prototype.includeLayers = function(t) {
      t.op > this.animationData.op && (this.animationData.op = t.op, this.totalFrames = Math.floor(t.op - this.animationData.ip));
      var i, s, a = this.animationData.layers, r = a.length, n = t.layers, o = n.length;
      for (s = 0; s < o; s += 1) for (i = 0; i < r; ) {
        if (a[i].id == n[s].id) {
          a[i] = n[s];
          break;
        }
        i += 1;
      }
      if ((t.chars || t.fonts) && (this.renderer.globalData.fontManager.addChars(t.chars), 
      this.renderer.globalData.fontManager.addFonts(t.fonts, this.renderer.globalData.defs)), 
      t.assets) for (r = t.assets.length, i = 0; i < r; i += 1) this.animationData.assets.push(t.assets[i]);
      this.animationData.__complete = !1, v.completeData(this.animationData, this.renderer.globalData.fontManager), 
      this.renderer.includeLayers(t.layers), e && e.initExpressions(this), this.loadNextSegment();
    }, j.prototype.loadNextSegment = function() {
      var t = this.animationData.segments;
      if (!t || 0 === t.length || !this.autoloadSegments) return this.trigger("data_ready"), 
      void (this.timeCompleted = this.totalFrames);
      var e = t.shift();
      this.timeCompleted = e.time * this.frameRate;
      var i = this.path + this.fileName + "_" + this.segmentPos + ".json";
      this.segmentPos += 1, D.load(i, this.includeLayers.bind(this), function() {
        this.trigger("data_failed");
      }.bind(this));
    }, j.prototype.loadSegments = function() {
      this.animationData.segments || (this.timeCompleted = this.totalFrames), this.loadNextSegment();
    }, j.prototype.preloadImages = function() {
      this.imagePreloader = new M(), this.imagePreloader.setAssetsPath(this.assetsPath), 
      this.imagePreloader.setPath(this.path), this.imagePreloader.loadAssets(this.animationData.assets, function(t) {
        t || this.trigger("loaded_images");
      }.bind(this));
    }, j.prototype.configAnimation = function(t) {
      this.renderer && (this.animationData = t, this.totalFrames = Math.floor(this.animationData.op - this.animationData.ip), 
      this.renderer.configAnimation(t), t.assets || (t.assets = []), this.renderer.searchExtraCompositions(t.assets), 
      this.assets = this.animationData.assets, this.frameRate = this.animationData.fr, 
      this.firstFrame = Math.round(this.animationData.ip), this.frameMult = this.animationData.fr / 1e3, 
      this.trigger("config_ready"), this.preloadImages(), this.loadSegments(), this.updaFrameModifier(), 
      this.waitForFontsLoaded());
    }, j.prototype.completeData = function() {
      v.completeData(this.animationData, this.renderer.globalData.fontManager), this.checkLoaded();
    }, j.prototype.waitForFontsLoaded = function() {
      this.renderer && (this.renderer.globalData.fontManager.loaded ? this.completeData() : setTimeout(this.waitForFontsLoaded.bind(this), 20));
    }, j.prototype.addPendingElement = function() {
      this.pendingElements += 1;
    }, j.prototype.elementLoaded = function() {
      this.pendingElements -= 1, this.checkLoaded();
    }, j.prototype.checkLoaded = function() {
      0 === this.pendingElements && (e && e.initExpressions(this), this.renderer.initItems(), 
      setTimeout(function() {
        this.trigger("DOMLoaded");
      }.bind(this), 0), this.isLoaded = !0, this.gotoFrame(), this.autoplay && this.play());
    }, j.prototype.resize = function() {
      this.renderer.updateContainerSize();
    }, j.prototype.setSubframe = function(t) {
      this.subframeEnabled = !!t;
    }, j.prototype.gotoFrame = function() {
      this.currentFrame = this.subframeEnabled ? this.currentRawFrame : ~~this.currentRawFrame, 
      this.timeCompleted !== this.totalFrames && this.currentFrame > this.timeCompleted && (this.currentFrame = this.timeCompleted), 
      this.trigger("enterFrame"), this.renderFrame();
    }, j.prototype.renderFrame = function() {
      !1 !== this.isLoaded && this.renderer.renderFrame(this.currentFrame + this.firstFrame);
    }, j.prototype.play = function(t) {
      t && this.name != t || !0 === this.isPaused && (this.isPaused = !1, this._idle && (this._idle = !1, 
      this.trigger("_active")));
    }, j.prototype.pause = function(t) {
      t && this.name != t || !1 === this.isPaused && (this.isPaused = !0, this._idle = !0, 
      this.trigger("_idle"));
    }, j.prototype.togglePause = function(t) {
      t && this.name != t || (!0 === this.isPaused ? this.play() : this.pause());
    }, j.prototype.stop = function(t) {
      t && this.name != t || (this.pause(), this.playCount = 0, this._completedLoop = !1, 
      this.setCurrentRawFrameValue(0));
    }, j.prototype.goToAndStop = function(t, e, i) {
      i && this.name != i || (e ? this.setCurrentRawFrameValue(t) : this.setCurrentRawFrameValue(t * this.frameModifier), 
      this.pause());
    }, j.prototype.goToAndPlay = function(t, e, i) {
      this.goToAndStop(t, e, i), this.play();
    }, j.prototype.advanceTime = function(t) {
      if (!0 !== this.isPaused && !1 !== this.isLoaded) {
        var e = this.currentRawFrame + t * this.frameModifier, i = !1;
        // Checking if nextValue > totalFrames - 1 for addressing non looping and looping animations.
        // If animation won't loop, it should stop at totalFrames - 1. If it will loop it should complete the last frame and then loop.
        e >= this.totalFrames - 1 && this.frameModifier > 0 ? this.loop && this.playCount !== this.loop ? e >= this.totalFrames ? (this.playCount += 1, 
        this.checkSegments(e % this.totalFrames) || (this.setCurrentRawFrameValue(e % this.totalFrames), 
        this._completedLoop = !0, this.trigger("loopComplete"))) : this.setCurrentRawFrameValue(e) : this.checkSegments(e > this.totalFrames ? e % this.totalFrames : 0) || (i = !0, 
        e = this.totalFrames - 1) : e < 0 ? this.checkSegments(e % this.totalFrames) || (!this.loop || this.playCount-- <= 0 && !0 !== this.loop ? (i = !0, 
        e = 0) : (this.setCurrentRawFrameValue(this.totalFrames + e % this.totalFrames), 
        this._completedLoop ? this.trigger("loopComplete") : this._completedLoop = !0)) : this.setCurrentRawFrameValue(e), 
        i && (this.setCurrentRawFrameValue(e), this.pause(), this.trigger("complete"));
      }
    }, j.prototype.adjustSegment = function(t, e) {
      this.playCount = 0, t[1] < t[0] ? (this.frameModifier > 0 && (this.playSpeed < 0 ? this.setSpeed(-this.playSpeed) : this.setDirection(-1)), 
      this.timeCompleted = this.totalFrames = t[0] - t[1], this.firstFrame = t[1], this.setCurrentRawFrameValue(this.totalFrames - .001 - e)) : t[1] > t[0] && (this.frameModifier < 0 && (this.playSpeed < 0 ? this.setSpeed(-this.playSpeed) : this.setDirection(1)), 
      this.timeCompleted = this.totalFrames = t[1] - t[0], this.firstFrame = t[0], this.setCurrentRawFrameValue(.001 + e)), 
      this.trigger("segmentStart");
    }, j.prototype.setSegment = function(t, e) {
      var i = -1;
      this.isPaused && (this.currentRawFrame + this.firstFrame < t ? i = t : this.currentRawFrame + this.firstFrame > e && (i = e - t)), 
      this.firstFrame = t, this.timeCompleted = this.totalFrames = e - t, -1 !== i && this.goToAndStop(i, !0);
    }, j.prototype.playSegments = function(t, e) {
      if ("object" == typeof t[0]) {
        var i, s = t.length;
        for (i = 0; i < s; i += 1) this.segments.push(t[i]);
      } else this.segments.push(t);
      e && this.checkSegments(0), this.isPaused && this.play();
    }, j.prototype.resetSegments = function(t) {
      this.segments.length = 0, this.segments.push([ this.animationData.ip, this.animationData.op ]), 
      //this.segments.push([this.animationData.ip*this.frameRate,Math.floor(this.animationData.op - this.animationData.ip+this.animationData.ip*this.frameRate)]);
      t && this.checkSegments(0);
    }, j.prototype.checkSegments = function(t) {
      return !!this.segments.length && (this.adjustSegment(this.segments.shift(), t), 
      !0);
    }, j.prototype.destroy = function(t) {
      t && this.name != t || !this.renderer || (this.renderer.destroy(), this.trigger("destroy"), 
      this._cbs = null, this.onEnterFrame = this.onLoopComplete = this.onComplete = this.onSegmentStart = this.onDestroy = null, 
      this.renderer = null);
    }, j.prototype.setCurrentRawFrameValue = function(t) {
      this.currentRawFrame = t, this.gotoFrame();
    }, j.prototype.setSpeed = function(t) {
      this.playSpeed = t, this.updaFrameModifier();
    }, j.prototype.setDirection = function(t) {
      this.playDirection = t < 0 ? -1 : 1, this.updaFrameModifier();
    }, j.prototype.updaFrameModifier = function() {
      this.frameModifier = this.frameMult * this.playSpeed * this.playDirection;
    }, j.prototype.getPath = function() {
      return this.path;
    }, j.prototype.getAssetsPath = function(t) {
      var e = "";
      if (t.e) e = t.p; else if (this.assetsPath) {
        var i = t.p;
        -1 !== i.indexOf("images/") && (i = i.split("/")[1]), e = this.assetsPath + i;
      } else e = this.path, e += t.u ? t.u : "", e += t.p;
      return e;
    }, j.prototype.getAssetData = function(t) {
      for (var e = 0, i = this.assets.length; e < i; ) {
        if (t == this.assets[e].id) return this.assets[e];
        e += 1;
      }
    }, j.prototype.hide = function() {
      this.renderer.hide();
    }, j.prototype.show = function() {
      this.renderer.show();
    }, j.prototype.getDuration = function(t) {
      return t ? this.totalFrames : this.totalFrames / this.frameRate;
    }, j.prototype.trigger = function(t) {
      if (this._cbs && this._cbs[t]) switch (t) {
       case "enterFrame":
        this.triggerEvent(t, new BMEnterFrameEvent(t, this.currentFrame, this.totalFrames, this.frameMult));
        break;

       case "loopComplete":
        this.triggerEvent(t, new BMCompleteLoopEvent(t, this.loop, this.playCount, this.frameMult));
        break;

       case "complete":
        this.triggerEvent(t, new BMCompleteEvent(t, this.frameMult));
        break;

       case "segmentStart":
        this.triggerEvent(t, new BMSegmentStartEvent(t, this.firstFrame, this.totalFrames));
        break;

       case "destroy":
        this.triggerEvent(t, new BMDestroyEvent(t, this));
        break;

       default:
        this.triggerEvent(t);
      }
      "enterFrame" === t && this.onEnterFrame && this.onEnterFrame.call(this, new BMEnterFrameEvent(t, this.currentFrame, this.totalFrames, this.frameMult)), 
      "loopComplete" === t && this.onLoopComplete && this.onLoopComplete.call(this, new BMCompleteLoopEvent(t, this.loop, this.playCount, this.frameMult)), 
      "complete" === t && this.onComplete && this.onComplete.call(this, new BMCompleteEvent(t, this.frameMult)), 
      "segmentStart" === t && this.onSegmentStart && this.onSegmentStart.call(this, new BMSegmentStartEvent(t, this.firstFrame, this.totalFrames)), 
      "destroy" === t && this.onDestroy && this.onDestroy.call(this, new BMDestroyEvent(t, this));
    };
    var H = {};
    function searchAnimations() {
      q.searchAnimations();
    }
    H.play = q.play, H.pause = q.pause, H.setLocationHref = function(t) {
      s = t;
    }, H.togglePause = q.togglePause, H.setSpeed = q.setSpeed, H.setDirection = q.setDirection, 
    H.stop = q.stop, H.searchAnimations = searchAnimations, H.registerAnimation = q.registerAnimation, 
    H.loadAnimation = function(t) {
      return q.loadAnimation(t);
    }, H.setSubframeRendering = function(t) {
      r = t;
    }, H.resize = q.resize, 
    //lottiejs.start = start;
    H.goToAndStop = q.goToAndStop, H.destroy = q.destroy, H.setQuality = function(t) {
      if ("string" == typeof t) switch (t) {
       case "high":
        f = 200;
        break;

       case "medium":
        f = 50;
        break;

       case "low":
        f = 10;
      } else !isNaN(t) && t > 1 && (f = t);
    }, H.inBrowser = function() {
      return "undefined" != typeof navigator;
    }, H.installPlugin = function(t, i) {
      "expressions" === t && (e = i);
    }, H.freeze = q.freeze, H.unfreeze = q.unfreeze, H.getRegisteredAnimations = q.getRegisteredAnimations, 
    H.__getFactory = function(t) {
      switch (t) {
       case "propertyFactory":
        return b;

       case "shapePropertyFactory":
        return _;

       case "matrix":
        return u;
      }
    }, H.version = "5.2.1";
    var W = document.getElementsByTagName("script"), X = (W[W.length - 1] || {
      src: ""
    }).src.replace(/^[^\?]+\??/, "");
    !function(t) {
      for (var e = X.split("&"), i = 0; i < e.length; i++) {
        var s = e[i].split("=");
        if ("renderer" == decodeURIComponent(s[0])) return decodeURIComponent(s[1]);
      }
    }();
    var Y = setInterval(function() {
      "complete" === document.readyState && (clearInterval(Y), searchAnimations());
    }, 100);
    return H;
  }, t.exports ? t.exports = i(e) : (e.lottie = i(e), e.bodymovin = e.lottie));
});

class r extends s {
  constructor() {
    super(...arguments), 
    /**
         * This attribute lets you specify if the animation will start playing as soon as it is ready
         *
         */
    this.autoPlay = !0, 
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
    this.disabled = !1, 
    /**
         * This attribute lets you specify if the animation will loop
         */
    this.loop = !0;
  }
  animationDataChanged() {
    this.animation.destroy(), this.animation = null;
  }
  pathChanged() {
    this.animation.destroy(), this.animation = null;
  }
  /**
     * Pause the animation
     */  pause() {
    this.animation.pause();
  }
  /**
     * Start playing the animation
     */  play(t = 0, e = 0) {
    if (t || e) {
      e || (e = t, t = 0);
      const i = this.durationToFrames(t), s = this.durationToFrames(e);
      this.animation.playSegments([ i, s ]);
    } else this.animation.play();
  }
  /**
     * Set the progress of the animation to any point
     * @param progress: Value from 0 to 1 indicating the percentage of progress where the animation will start.
     */  setProgress(t) {
    const e = this.durationToFrames(t);
    this.animation.goToAndPlay(e, !0);
  }
  /**
     * Stop the animation
     */  stop() {
    this.animation.stop();
  }
  durationToFrames(t) {
    return Math.trunc(this.animationTotalFrames * t);
  }
  handleClick(t) {
    this.disabled || this.onClick.emit(t);
  }
  componentDidLoad() {
    this.setAnimation();
  }
  componentDidUpdate() {
    this.setAnimation();
  }
  componentDidUnload() {
    this.animation.destroy();
  }
  setAnimation() {
    this.animation ? this.animation.loop = this.loop : (this.animation = a.loadAnimation({
      animationData: this.animationData,
      autoplay: this.autoPlay,
      container: this.element.querySelector(":scope > div"),
      loop: this.loop,
      path: this.path,
      renderer: "svg"
    }), this.animationTotalFrames = this.animation.getDuration(!0), this.animation.addEventListener("DOMLoaded", this.animationDomLoadedHandler.bind(this)));
  }
  animationDomLoadedHandler(t) {
    this.animationLoad.emit(t);
  }
  render() {
    return t("div", null);
  }
  static get is() {
    return "gx-lottie";
  }
  static get properties() {
    return {
      animationData: {
        type: "Any",
        attr: "animation-data",
        watchCallbacks: [ "animationDataChanged" ]
      },
      autoPlay: {
        type: Boolean,
        attr: "auto-play"
      },
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
      },
      loop: {
        type: Boolean,
        attr: "loop"
      },
      path: {
        type: String,
        attr: "path",
        watchCallbacks: [ "pathChanged" ]
      },
      pause: {
        method: !0
      },
      play: {
        method: !0
      },
      setProgress: {
        method: !0
      },
      stop: {
        method: !0
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
    }, {
      name: "animationLoad",
      method: "animationLoad",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    } ];
  }
  static get style() {
    return "gx-lottie{display:block}gx-lottie>div{height:100%}";
  }
}

export { r as GxLottie };