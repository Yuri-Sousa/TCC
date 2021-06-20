/*! Built with http://stenciljs.com */
(function(Context,namespace,hydratedCssClass,resourcesUrl,s){"use strict";
s=document.querySelector("script[data-namespace='gx-web-controls']");if(s){resourcesUrl=s.getAttribute('data-resources-url');}
(function(e, t, n, o) {
  "use strict";
  /**
 * SSR Attribute Names
 */  function getScopeId(e, t) {
    return "sc-" + e._$tagNameMeta$_ + (t && t !== c ? "-" + t : "");
  }
  function getElementScopeId(e, t) {
    return e + (t ? "-h" : "-s");
  }
  function parseListenerData(e) {
    return {
      _$eventName$_: e[0],
      _$eventMethodName$_: e[1],
      _$eventDisabled$_: !!e[2],
      _$eventPassive$_: !!e[3],
      _$eventCapture$_: !!e[4]
    };
  }
  function parsePropertyValue(e, t) {
    // ensure this value is of the correct prop type
    // we're testing both formats of the "propType" value because
    // we could have either gotten the data from the attribute changed callback,
    // which wouldn't have Constructor data yet, and because this method is reused
    // within proxy where we don't have meta data, but only constructor data
    if (l(t) && "object" != typeof t && "function" != typeof t) {
      if (e === Boolean || 3 /* Boolean */ === e) 
      // per the HTML spec, any string value means it is a boolean true value
      // but we'll cheat here and say that the string "false" is the boolean false
      return "false" !== t && ("" === t || !!t);
      if (e === Number || 4 /* Number */ === e) 
      // force it to be a number
      return parseFloat(t);
      if (e === String || 2 /* String */ === e) 
      // could have been passed as a number or boolean
      // but we still want it as a string
      return t.toString();
    }
    // not sure exactly what type we want
    // so no need to change to a different type
        return t;
  }
  function propagateComponentLoaded(e, t, n, o) {
    // load events fire from bottom to top
    // the deepest elements load first then bubbles up
    const r = e._$ancestorHostElementMap$_.get(t);
    r && (
    // ok so this element already has a known ancestor host element
    // let's make sure we remove this element from its ancestor's
    // known list of child elements which are actively loading
    (o = r["s-ld"] || r.$activeLoading) && ((n = o.indexOf(t)) > -1 && 
    // yup, this element is in the list of child elements to wait on
    // remove it so we can work to get the length down to 0
    o.splice(n, 1), 
    // the ancestor's initLoad method will do the actual checks
    // to see if the ancestor is actually loaded or not
    // then let's call the ancestor's initLoad method if there's no length
    // (which actually ends up as this method again but for the ancestor)
    o.length || (r["s-init"] && r["s-init"](), 
    // $initLoad deprecated 2018-04-02
    r.$initLoad && r.$initLoad())), e._$ancestorHostElementMap$_.delete(t));
  }
  /**
 * Production h() function based on Preact by
 * Jason Miller (@developit)
 * Licensed under the MIT License
 * https://github.com/developit/preact/blob/master/LICENSE
 *
 * Modified for Stencil's compiler and vdom
 */  function h(e, t) {
    let n, o, r = null, i = !1, c = !1;
    for (var a = arguments.length; a-- > 2; ) p.push(arguments[a]);
    for (;p.length > 0; ) {
      let t = p.pop();
      if (t && void 0 !== t.pop) for (a = t.length; a--; ) p.push(t[a]); else "boolean" == typeof t && (t = null), 
      (c = "function" != typeof e) && (null == t ? t = "" : "number" == typeof t ? t = String(t) : "string" != typeof t && (c = !1)), 
      c && i ? r[r.length - 1].vtext += t : null === r ? r = [ c ? {
        vtext: t
      } : t ] : r.push(c ? {
        vtext: t
      } : t), i = c;
    }
    if (null != t) {
      if (
      // normalize class / classname attributes
      t.className && (t.class = t.className), "object" == typeof t.class) {
        for (a in t.class) t.class[a] && p.push(a);
        t.class = p.join(" "), p.length = 0;
      }
      null != t.key && (n = t.key), null != t.name && (o = t.name);
    }
    return "function" == typeof e ? e(Object.assign({}, t, {
      children: r
    }), d) : {
      vtag: e,
      vchildren: r,
      vtext: void 0,
      vattrs: t,
      vkey: n,
      vname: o,
      _$elm$_: void 0,
      _$ishost$_: !1
    };
  }
  function VNodeToChild(e) {
    return {
      vtag: e.vtag,
      vchildren: e.vchildren,
      vtext: e.vtext,
      vattrs: e.vattrs,
      vkey: e.vkey,
      vname: e.vname
    };
  }
  function queueUpdate(e, t) {
    // only run patch if it isn't queued already
    e._$isQueuedForUpdate$_.has(t) || (e._$isQueuedForUpdate$_.set(t, !0), 
    // run the patch in the next tick
    // vdom diff and patch the host element for differences
    e._$isAppLoaded$_ ? 
    // app has already loaded
    // let's queue this work in the dom write phase
    e.queue.write(() => update(e, t)) : 
    // app hasn't finished loading yet
    // so let's use next tick to do everything
    // as fast as possible
    e.queue.tick(() => update(e, t)));
  }
  function update(e, t, n, o, r, i) {
    // everything is async, so somehow we could have already disconnected
    // this node, so be sure to do nothing if we've already disconnected
    if (
    // no longer queued for update
    e._$isQueuedForUpdate$_.delete(t), !e._$isDisconnectedMap$_.has(t)) {
      if (o = e._$instanceMap$_.get(t), n = !o) {
        if ((r = e._$ancestorHostElementMap$_.get(t)) && r.$rendered && (
        // $rendered deprecated 2018-04-02
        r["s-rn"] = !0), r && !r["s-rn"]) 
        // this is the intial load
        // this element has an ancestor host element
        // but the ancestor host element has NOT rendered yet
        // so let's just cool our jets and wait for the ancestor to render
        return (r["s-rc"] = r["s-rc"] || []).push(() => {
          // this will get fired off when the ancestor host element
          // finally gets around to rendering its lazy self
          update(e, t);
        }), void (
        // $onRender deprecated 2018-04-02
        r.$onRender = r["s-rc"]);
        // haven't created a component instance for this host element yet!
        // create the instance from the user's component class
        // https://www.youtube.com/watch?v=olLxrojmvMg
                o = function initComponentInstance(e, t, n, o, r, i, c) {
          try {
            o = new (
            // using the user's component class, let's create a new instance
            r = e._$getComponentMeta$_(t)._$componentConstructor$_)(), 
            // ok cool, we've got an host element now, and a actual instance
            // and there were no errors creating the instance
            // let's upgrade the data on the host element
            // and let the getters/setters do their jobs
            function proxyComponentInstance(e, t, n, o, r, i, c) {
              // define each of the members and initialize what their role is
              for (c in 
              // at this point we've got a specific node of a host element, and created a component class instance
              // and we've already created getters/setters on both the host element and component class prototypes
              // let's upgrade any data that might have been set on the host element already
              // and let's have the getters/setters kick in and do their jobs
              // let's automatically add a reference to the host element on the instance
              e._$hostElementMap$_.set(o, n), 
              // create the values object if it doesn't already exist
              // this will hold all of the internal getter/setter values
              e._$valuesMap$_.has(n) || e._$valuesMap$_.set(n, {}), 
              // always set mode
              (
              // get the properties from the constructor
              // and add default "mode" and "color" properties
              i = Object.assign({
                color: {
                  type: String
                }
              }, t.properties)).mode = {
                type: String
              }, i) defineMember(e, i[c], n, o, c, r);
            }(e, r, t, o, n), 
            // add each of the event emitters which wire up instance methods
            // to fire off dom events from the host element
            function initEventEmitters(e, t, n) {
              if (t) {
                const o = e._$hostElementMap$_.get(n);
                t.forEach(t => {
                  n[t.method] = {
                    emit: n => {
                      e._$emitEvent$_(o, t.name, {
                        bubbles: t.bubbles,
                        composed: t.composed,
                        cancelable: t.cancelable,
                        detail: n
                      });
                    }
                  };
                });
              }
            }(e, r.events, o);
            try {
              if (
              // replay any event listeners on the instance that
              // were queued up between the time the element was
              // connected and before the instance was ready
              i = e._$queuedEvents$_.get(t)) {
                // events may have already fired before the instance was even ready
                // now that the instance is ready, let's replay all of the events that
                // we queued up earlier that were originally meant for the instance
                for (c = 0; c < i.length; c += 2) 
                // data was added in sets of two
                // first item the eventMethodName
                // second item is the event data
                // take a look at initElementListener()
                o[i[c]](i[c + 1]);
                e._$queuedEvents$_.delete(t);
              }
            } catch (n) {
              e._$onError$_(n, 2 /* QueueEventsError */ , t);
            }
          } catch (n) {
            // something done went wrong trying to create a component instance
            // create a dumby instance so other stuff can load
            // but chances are the app isn't fully working cuz this component has issues
            o = {}, e._$onError$_(n, 7 /* InitInstanceError */ , t, !0);
          }
          return e._$instanceMap$_.set(t, o), o;
        }(e, t, e._$hostSnapshotMap$_.get(t));
        // fire off the user's componentWillLoad method (if one was provided)
        // componentWillLoad only runs ONCE, after instance's element has been
        // assigned as the host element, but BEFORE render() has been called
        try {
          o.componentWillLoad && (i = o.componentWillLoad());
        } catch (n) {
          e._$onError$_(n, 3 /* WillLoadError */ , t);
        }
      } else 
      // already created an instance and this is an update
      // fire off the user's componentWillUpdate method (if one was provided)
      // componentWillUpdate runs BEFORE render() has been called
      // but only BEFORE an UPDATE and not before the intial render
      // get the returned promise (if one was provided)
      try {
        o.componentWillUpdate && (i = o.componentWillUpdate());
      } catch (n) {
        e._$onError$_(n, 5 /* WillUpdateError */ , t);
      }
      i && i.then ? 
      // looks like the user return a promise!
      // let's not actually kick off the render
      // until the user has resolved their promise
      i.then(() => renderUpdate(e, t, o, n)) : 
      // user never returned a promise so there's
      // no need to wait on anything, let's do the render now my friend
      renderUpdate(e, t, o, n);
    }
  }
  function renderUpdate(e, t, n, o) {
    // if this component has a render function, let's fire
    // it off and generate a vnode for this
    (function render(e, t, n, o) {
      try {
        // if this component has a render function, let's fire
        // it off and generate the child vnodes for this host element
        // note that we do not create the host element cuz it already exists
        const r = t._$componentConstructor$_.host, i = t._$componentConstructor$_.encapsulation, c = "shadow" === i && e._$domApi$_._$$supportsShadowDom$_;
        let a, s;
        if (c || (
        // not using, or can't use shadow dom
        // set the root element, which will be the shadow root when enabled
        s = n), !n["s-rn"]) {
          // attach the styles this component needs, if any
          // this fn figures out if the styles should go in a
          // shadow root or if they should be global
          e._$attachStyles$_(e, e._$domApi$_, t, n);
          // if no render function
          const r = n["s-sc"];
          r && (e._$domApi$_._$$addClass$_(n, getElementScopeId(r, !0)), o.render || e._$domApi$_._$$addClass$_(n, getElementScopeId(r)));
        }
        if (o.render || o.hostData || r || a) {
          // tell the platform we're actively rendering
          // if a value is changed within a render() then
          // this tells the platform not to queue the change
          e._$activeRender$_ = !0;
          const t = o.render && o.render();
          let r;
          // user component provided a "hostData()" method
          // the returned data/attributes are used on the host element
          r = o.hostData && o.hostData(), 
          // tell the platform we're done rendering
          // now any changes will again queue
          e._$activeRender$_ = !1;
          // looks like we've got child nodes to render into this host element
          // or we need to update the css class/attrs on the host element
          // if we haven't already created a vnode, then we give the renderer the actual element
          // if this is a re-render, then give the renderer the last vnode we already created
          const a = e._$vnodeMap$_.get(n) || {};
          a._$elm$_ = s;
          const l = h(null, r, t);
          // each patch always gets a new vnode
          // the host element itself isn't patched because it already exists
          // kick off the actual render and any DOM updates
          e._$vnodeMap$_.set(n, e.render(n, a, l, c, i));
        }
        // update styles!
                // it's official, this element has rendered
        n["s-rn"] = !0, n.$onRender && (
        // $onRender deprecated 2018-04-02
        n["s-rc"] = n.$onRender), n["s-rc"] && (
        // ok, so turns out there are some child host elements
        // waiting on this parent element to load
        // let's fire off all update callbacks waiting
        n["s-rc"].forEach(e => e()), n["s-rc"] = null);
      } catch (t) {
        e._$activeRender$_ = !1, e._$onError$_(t, 8 /* RenderError */ , n, !0);
      }
    })(e, e._$getComponentMeta$_(t), t, n);
    try {
      o ? 
      // so this was the initial load i guess
      t["s-init"]() : (
      // fire off the user's componentDidUpdate method (if one was provided)
      // componentDidUpdate runs AFTER render() has been called
      // but only AFTER an UPDATE and not after the intial render
      n.componentDidUpdate && n.componentDidUpdate(), callNodeRefs(e._$vnodeMap$_.get(t)));
    } catch (n) {
      // derp
      e._$onError$_(n, 6 /* DidUpdateError */ , t, !0);
    }
  }
  function defineMember(e, t, n, o, r, i, c, a) {
    if (t.type || t.state) {
      const s = e._$valuesMap$_.get(n);
      t.state || (!t.attr || void 0 !== s[r] && "" !== s[r] || 
      // check the prop value from the host element attribute
      (c = i && i._$$attributes$_) && l(a = c[t.attr]) && (
      // looks like we've got an attribute value
      // let's set it to our internal values
      s[r] = parsePropertyValue(t.type, a)), 
      // client-side
      // within the browser, the element's prototype
      // already has its getter/setter set, but on the
      // server the prototype is shared causing issues
      // so instead the server's elm has the getter/setter
      // directly on the actual element instance, not its prototype
      // so on the browser we can use "hasOwnProperty"
      n.hasOwnProperty(r) && (
      // @Prop or @Prop({mutable:true})
      // property values on the host element should override
      // any default values on the component instance
      void 0 === s[r] && (s[r] = parsePropertyValue(t.type, n[r])), 
      // for the client only, let's delete its "own" property
      // this way our already assigned getter/setter on the prototype kicks in
      // the very special case is to NOT do this for "mode"
      "mode" !== r && delete n[r])), o.hasOwnProperty(r) && void 0 === s[r] && (
      // @Prop() or @Prop({mutable:true}) or @State()
      // we haven't yet got a value from the above checks so let's
      // read any "own" property instance values already set
      // to our internal value as the source of getter data
      // we're about to define a property and it'll overwrite this "own" property
      s[r] = o[r]), t.watchCallbacks && (s[m + r] = t.watchCallbacks.slice()), 
      // add getter/setter to the component instance
      // these will be pointed to the internal data set from the above checks
      definePropertyGetterSetter(o, r, function getComponentProp(t) {
        // component instance prop/state getter
        // get the property value directly from our internal values
        return (t = e._$valuesMap$_.get(e._$hostElementMap$_.get(this))) && t[r];
      }, function setComponentProp(n, o) {
        // component instance prop/state setter (cannot be arrow fn)
        (o = e._$hostElementMap$_.get(this)) && (t.state || t.mutable) && setValue(e, o, r, n);
      });
    } else t.elementRef ? 
    // @Element()
    // add a getter to the element reference using
    // the member name the component meta provided
    definePropertyValue(o, r, n) : t.method && 
    // @Method()
    // add a property "value" on the host element
    // which we'll bind to the instance's method
    definePropertyValue(n, r, o[r].bind(o));
  }
  function setValue(e, t, n, o, r, i, c) {
    (
    // get the internal values object, which should always come from the host element instance
    // create the _values object if it doesn't already exist
    r = e._$valuesMap$_.get(t)) || e._$valuesMap$_.set(t, r = {});
    const a = r[n];
    // check our new property value against our internal value
        if (o !== a && (
    // gadzooks! the property's value has changed!!
    // set our new value!
    // https://youtu.be/dFtLONl4cNc?t=22
    r[n] = o, i = e._$instanceMap$_.get(t))) {
      if (
      // get an array of method names of watch functions to call
      c = r[m + n]) 
      // this instance is watching for when this property changed
      for (let e = 0; e < c.length; e++) try {
        // fire off each of the watch methods that are watching this property
        i[c[e]].call(i, o, a, n);
      } catch (e) {
        console.error(e);
      }
      !e._$activeRender$_ && t["s-rn"] && 
      // looks like this value actually changed, so we've got work to do!
      // but only if we've already rendered, otherwise just chill out
      // queue that we need to do an update, but don't worry about queuing
      // up millions cuz this function ensures it only runs once
      queueUpdate(e, t);
    }
  }
  function definePropertyValue(e, t, n) {
    // minification shortcut
    Object.defineProperty(e, t, {
      configurable: !0,
      value: n
    });
  }
  function definePropertyGetterSetter(e, t, n, o) {
    // minification shortcut
    Object.defineProperty(e, t, {
      configurable: !0,
      get: n,
      set: o
    });
  }
  function setAccessor(e, t, n, o, r, i, c) {
    if ("class" !== n || i) if ("style" === n) {
      // update style attribute, css properties and values
      for (const e in o) r && null != r[e] || (/-/.test(e) ? t.style._$removeProperty$_(e) : t.style[e] = "");
      for (const e in r) o && r[e] === o[e] || (/-/.test(e) ? t.style.setProperty(e, r[e]) : t.style[e] = r[e]);
    } else if ("o" !== n[0] || "n" !== n[1] || !/[A-Z]/.test(n[2]) || n in t) if ("list" !== n && "type" !== n && !i && (n in t || -1 !== [ "object", "function" ].indexOf(typeof r) && null !== r)) {
      // Properties
      // - list and type are attributes that get applied as values on the element
      // - all svgs get values as attributes not props
      // - check if elm contains name or if the value is array, object, or function
      const o = e._$getComponentMeta$_(t);
      o && o._$membersMeta$_ && o._$membersMeta$_[n] ? 
      // we know for a fact that this element is a known component
      // and this component has this member name as a property,
      // let's set the known @Prop on this element
      // set it directly as property on the element
      setProperty(t, n, r) : "ref" !== n && (
      // this member name is a property on this element, but it's not a component
      // this is a native property like "value" or something
      // also we can ignore the "ref" member name at this point
      setProperty(t, n, null == r ? "" : r), null != r && !1 !== r || e._$domApi$_._$$removeAttribute$_(t, n));
    } else null != r && "key" !== n ? 
    // Element Attributes
    function updateAttribute(e, t, n, o = "boolean" == typeof n) {
      const r = t !== (t = t.replace(/^xlink\:?/, ""));
      null == n || o && (!n || "false" === n) ? r ? e.removeAttributeNS(y, f(t)) : e.removeAttribute(t) : "function" != typeof n && (n = o ? "" : n.toString(), 
      r ? e.setAttributeNS(y, f(t), n) : e.setAttribute(t, n));
    }(t, n, r) : (i || e._$domApi$_._$$hasAttribute$_(t, n) && (null == r || !1 === r)) && 
    // remove svg attribute
    e._$domApi$_._$$removeAttribute$_(t, n); else 
    // Event Handlers
    // so if the member name starts with "on" and the 3rd characters is
    // a capital letter, and it's not already a member on the element,
    // then we're assuming it's an event listener
    // standard event
    // the JSX attribute could have been "onMouseOver" and the
    // member name "onmouseover" is on the element's prototype
    // so let's add the listener "mouseover", which is all lowercased
    n = f(n) in t ? f(n.substring(2)) : f(n[2]) + n.substring(3), r ? r !== o && 
    // add listener
    e._$domApi$_._$$addEventListener$_(t, n, r) : 
    // remove listener
    e._$domApi$_._$$removeEventListener$_(t, n); else 
    // Class
    if (o !== r) {
      const e = parseClassList(o), n = parseClassList(r), i = e.filter(e => !n.includes(e)), c = parseClassList(t.className).filter(e => !i.includes(e)), a = n.filter(t => !e.includes(t) && !c.includes(t));
      c.push(...a), t.className = c.join(" ");
    }
  }
  function parseClassList(e) {
    return null == e || "" === e ? [] : e.trim().split(/\s+/);
  }
  /**
 * Attempt to set a DOM property to the given value.
 * IE & FF throw for certain property-value combinations.
 */  function setProperty(e, t, n) {
    try {
      e[t] = n;
    } catch (e) {}
  }
  function updateElement(e, t, n, o, r) {
    // if the element passed in is a shadow root, which is a document fragment
    // then we want to be adding attrs/props to the shadow root's "host" element
    // if it's not a shadow root, then we add attrs/props to the same element
    const i = 11 /* DocumentFragment */ === n._$elm$_.nodeType && n._$elm$_.host ? n._$elm$_.host : n._$elm$_, c = t && t.vattrs || a, s = n.vattrs || a;
    // remove attributes no longer present on the vnode by setting them to undefined
    for (r in c) s && null != s[r] || null == c[r] || setAccessor(e, i, r, c[r], void 0, o, n._$ishost$_);
    // add new & update changed attributes
        for (r in s) r in c && s[r] === ("value" === r || "checked" === r ? i[r] : c[r]) || setAccessor(e, i, r, c[r], s[r], o, n._$ishost$_);
  }
  function createRendererPatch(e, t) {
    // createRenderer() is only created once per app
    // the patch() function which createRenderer() returned is the function
    // which gets called numerous times by each component
    function createElm(n, i, f, u, p, d, m, h, y) {
      if (h = i.vchildren[f], o || (
      // remember for later we need to check to relocate nodes
      c = !0, "slot" === h.vtag && (r && 
      // scoped css needs to add its scoped id to the parent element
      t._$$addClass$_(u, r + "-s"), h.vchildren ? 
      // slot element has fallback content
      // still create an element that "mocks" the slot element
      h._$isSlotFallback$_ = !0 : 
      // slot element does not have fallback content
      // create an html comment we'll use to always reference
      // where actual slot content should sit next to
      h._$isSlotReference$_ = !0)), l(h.vtext)) 
      // create text node
      h._$elm$_ = t._$$createTextNode$_(h.vtext); else if (h._$isSlotReference$_) 
      // create a slot reference html text node
      h._$elm$_ = t._$$createTextNode$_(""); else {
        if (
        // create element
        d = h._$elm$_ = v || "svg" === h.vtag ? t._$$createElementNS$_("http://www.w3.org/2000/svg", h.vtag) : t._$$createElement$_(h._$isSlotFallback$_ ? "slot-fb" : h.vtag), 
        v = "svg" === h.vtag || "foreignObject" !== h.vtag && v, 
        // add css classes, attrs, props, listeners, etc.
        updateElement(e, null, h, v), l(r) && d["s-si"] !== r && 
        // if there is a scopeId and this is the initial render
        // then let's add the scopeId as an attribute
        t._$$addClass$_(d, d["s-si"] = r), h.vchildren) for (p = 0; p < h.vchildren.length; ++p) 
        // create the node
        // return node could have been null
        (m = createElm(n, h, p, d)) && 
        // append our new node
        t._$$appendChild$_(d, m);
        "svg" === h.vtag && (
        // Only reset the SVG context when we're exiting SVG element
        v = !1);
      }
      return h._$elm$_["s-hn"] = a, (h._$isSlotFallback$_ || h._$isSlotReference$_) && (
      // remember the content reference comment
      h._$elm$_["s-sr"] = !0, 
      // remember the content reference comment
      h._$elm$_["s-cr"] = s, 
      // remember the slot name, or empty string for default slot
      h._$elm$_["s-sn"] = h.vname || "", (
      // check if we've got an old vnode for this slot
      y = n && n.vchildren && n.vchildren[f]) && y.vtag === h.vtag && n._$elm$_ && 
      // we've got an old slot vnode and the wrapper is being replaced
      // so let's move the old slot content back to it's original location
      putBackInOriginalLocation(n._$elm$_)), h._$elm$_;
    }
    function putBackInOriginalLocation(n, o, r, i) {
      e._$tmpDisconnected$_ = !0;
      const s = t._$$childNodes$_(n);
      for (r = s.length - 1; r >= 0; r--) (i = s[r])["s-hn"] !== a && i["s-ol"] && (
      // this child node in the old element is from another component
      // remove this node from the old slot's parent
      t._$$remove$_(i), 
      // and relocate it back to it's original location
      t._$$insertBefore$_(parentReferenceNode(i), i, referenceNode(i)), 
      // remove the old original location comment entirely
      // later on the patch function will know what to do
      // and move this to the correct spot in need be
      t._$$remove$_(i["s-ol"]), i["s-ol"] = null, c = !0), o && putBackInOriginalLocation(i, o);
      e._$tmpDisconnected$_ = !1;
    }
    function addVnodes(e, n, o, r, i, c, s, f) {
      // $defaultHolder deprecated 2018-04-02
      const u = e["s-cr"] || e.$defaultHolder;
      for ((s = u && t._$$parentNode$_(u) || e).shadowRoot && t._$$tagName$_(s) === a && (s = s.shadowRoot); i <= c; ++i) r[i] && (f = l(r[i].vtext) ? t._$$createTextNode$_(r[i].vtext) : createElm(null, o, i, e)) && (r[i]._$elm$_ = f, 
      t._$$insertBefore$_(s, f, referenceNode(n)));
    }
    function removeVnodes(e, n, o, r) {
      for (;n <= o; ++n) l(e[n]) && (r = e[n]._$elm$_, 
      // we're removing this element
      // so it's possible we need to show slot fallback content now
      i = !0, r["s-ol"] ? 
      // remove the original location comment
      t._$$remove$_(r["s-ol"]) : 
      // it's possible that child nodes of the node
      // that's being removed are slot nodes
      putBackInOriginalLocation(r, !0), 
      // remove the vnode's element from the dom
      t._$$remove$_(r));
    }
    function isSameVnode(e, t) {
      // compare if two vnode to see if they're "technically" the same
      // need to have the same element tag, and same key to be the same
      return e.vtag === t.vtag && e.vkey === t.vkey && ("slot" !== e.vtag || e.vname === t.vname);
    }
    function referenceNode(e) {
      return e && e["s-ol"] ? e["s-ol"] : e;
    }
    function parentReferenceNode(e) {
      return t._$$parentNode$_(e["s-ol"] ? e["s-ol"] : e);
    }
    const n = [];
    // internal variables to be reused per patch() call
    let o, r, i, c, a, s;
    return function patch(f, u, p, d, m, h, y, b, g, C, k, N) {
      if (
      // patchVNode() is synchronous
      // so it is safe to set these variables and internally
      // the same patch() call will reference the same data
      a = t._$$tagName$_(f), s = f["s-cr"], o = d, 
      // get the scopeId
      r = f["s-sc"], 
      // always reset
      c = i = !1, 
      // synchronous patch
      function patchVNode(n, o, r) {
        const i = o._$elm$_ = n._$elm$_, c = n.vchildren, a = o.vchildren;
        // test if we're rendering an svg element, or still rendering nodes inside of one
        // only add this to the when the compiler sees we're using an svg somewhere
        v = o._$elm$_ && l(t._$$parentElement$_(o._$elm$_)) && void 0 !== o._$elm$_.ownerSVGElement, 
        v = "svg" === o.vtag || "foreignObject" !== o.vtag && v, l(o.vtext) ? (r = i["s-cr"] || i.$defaultHolder /* $defaultHolder deprecated 2018-04-02 */) ? 
        // this element has slotted content
        t._$$setTextContent$_(t._$$parentNode$_(r), o.vtext) : n.vtext !== o.vtext && 
        // update the text content for the text only vnode
        // and also only if the text is different than before
        t._$$setTextContent$_(i, o.vtext) : (
        // element node
        "slot" !== o.vtag && 
        // either this is the first render of an element OR it's an update
        // AND we already know it's possible it could have changed
        // this updates the element's css classes, attrs, props, listeners, etc.
        updateElement(e, n, o, v), l(c) && l(a) ? 
        // looks like there's child vnodes for both the old and new vnodes
        function updateChildren(e, n, o, r, i, c, a, s) {
          let f = 0, u = 0, p = n.length - 1, d = n[0], m = n[p], h = r.length - 1, y = r[0], v = r[h];
          for (;f <= p && u <= h; ) if (null == d) 
          // Vnode might have been moved left
          d = n[++f]; else if (null == m) m = n[--p]; else if (null == y) y = r[++u]; else if (null == v) v = r[--h]; else if (isSameVnode(d, y)) patchVNode(d, y), 
          d = n[++f], y = r[++u]; else if (isSameVnode(m, v)) patchVNode(m, v), m = n[--p], 
          v = r[--h]; else if (isSameVnode(d, v)) 
          // Vnode moved right
          "slot" !== d.vtag && "slot" !== v.vtag || putBackInOriginalLocation(t._$$parentNode$_(d._$elm$_)), 
          patchVNode(d, v), t._$$insertBefore$_(e, d._$elm$_, t._$$nextSibling$_(m._$elm$_)), 
          d = n[++f], v = r[--h]; else if (isSameVnode(m, y)) 
          // Vnode moved left
          "slot" !== d.vtag && "slot" !== v.vtag || putBackInOriginalLocation(t._$$parentNode$_(m._$elm$_)), 
          patchVNode(m, y), t._$$insertBefore$_(e, m._$elm$_, d._$elm$_), m = n[--p], y = r[++u]; else {
            for (
            // createKeyToOldIdx
            i = null, c = f; c <= p; ++c) if (n[c] && l(n[c].vkey) && n[c].vkey === y.vkey) {
              i = c;
              break;
            }
            l(i) ? ((s = n[i]).vtag !== y.vtag ? a = createElm(n && n[u], o, i, e) : (patchVNode(s, y), 
            n[i] = void 0, a = s._$elm$_), y = r[++u]) : (
            // new element
            a = createElm(n && n[u], o, u, e), y = r[++u]), a && t._$$insertBefore$_(parentReferenceNode(d._$elm$_), a, referenceNode(d._$elm$_));
          }
          f > p ? addVnodes(e, null == r[h + 1] ? null : r[h + 1]._$elm$_, o, r, u, h) : u > h && removeVnodes(n, f, p);
        }(i, c, o, a) : l(a) ? (
        // no old child vnodes, but there are new child vnodes to add
        l(n.vtext) && 
        // the old vnode was text, so be sure to clear it out
        t._$$setTextContent$_(i, ""), 
        // add the new vnode children
        addVnodes(i, null, o, a, 0, a.length - 1)) : l(c) && 
        // no new child vnodes, but there are old child vnodes to remove
        removeVnodes(c, 0, c.length - 1)), 
        // reset svgMode when svg node is fully patched
        v && "svg" === o.vtag && (v = !1);
      }(u, p), c) {
        for (function relocateSlotContent(e, o, r, c, a, s, l, f, u, p) {
          for (a = 0, s = (o = t._$$childNodes$_(e)).length; a < s; a++) {
            if ((r = o[a])["s-sr"] && (c = r["s-cr"])) for (
            // first got the content reference comment node
            // then we got it's parent, which is where all the host content is in now
            f = t._$$childNodes$_(t._$$parentNode$_(c)), u = r["s-sn"], l = f.length - 1; l >= 0; l--) (c = f[l])["s-cn"] || c["s-nr"] || c["s-hn"] === r["s-hn"] || ((3 /* TextNode */ === (
            // let's do some relocating to its new home
            // but never relocate a content reference node
            // that is suppose to always represent the original content location
            p = t._$$nodeType$_(c)) || 8 /* CommentNode */ === p) && "" === u || 1 /* ElementNode */ === p && null === t._$$getAttribute$_(c, "slot") && "" === u || 1 /* ElementNode */ === p && t._$$getAttribute$_(c, "slot") === u) && (
            // it's possible we've already decided to relocate this node
            n.some(e => e._$nodeToRelocate$_ === c) || (
            // made some changes to slots
            // let's make sure we also double check
            // fallbacks are correctly hidden or shown
            i = !0, c["s-sn"] = u, 
            // add to our list of nodes to relocate
            n.push({
              _$slotRefNode$_: r,
              _$nodeToRelocate$_: c
            })));
            1 /* ElementNode */ === t._$$nodeType$_(r) && relocateSlotContent(r);
          }
        }(p._$elm$_), y = 0; y < n.length; y++) (b = n[y])._$nodeToRelocate$_["s-ol"] || (
        // add a reference node marking this node's original location
        // keep a reference to this node for later lookups
        (g = t._$$createTextNode$_(""))["s-nr"] = b._$nodeToRelocate$_, t._$$insertBefore$_(t._$$parentNode$_(b._$nodeToRelocate$_), b._$nodeToRelocate$_["s-ol"] = g, b._$nodeToRelocate$_));
        // while we're moving nodes around existing nodes, temporarily disable
        // the disconnectCallback from working
                for (e._$tmpDisconnected$_ = !0, y = 0; y < n.length; y++) {
          for (b = n[y], 
          // by default we're just going to insert it directly
          // after the slot reference node
          k = t._$$parentNode$_(b._$slotRefNode$_), N = t._$$nextSibling$_(b._$slotRefNode$_), 
          g = b._$nodeToRelocate$_["s-ol"]; g = t._$$previousSibling$_(g); ) if ((C = g["s-nr"]) && C && C["s-sn"] === b._$nodeToRelocate$_["s-sn"] && k === t._$$parentNode$_(C) && (C = t._$$nextSibling$_(C)) && C && !C["s-nr"]) {
            N = C;
            break;
          }
          (!N && k !== t._$$parentNode$_(b._$nodeToRelocate$_) || t._$$nextSibling$_(b._$nodeToRelocate$_) !== N) && b._$nodeToRelocate$_ !== N && (
          // remove the node from the dom
          t._$$remove$_(b._$nodeToRelocate$_), 
          // add it back to the dom but in its new home
          t._$$insertBefore$_(k, b._$nodeToRelocate$_, N));
        }
        // done moving nodes around
        // allow the disconnect callback to work again
                e._$tmpDisconnected$_ = !1;
      }
      // return our new vnode
      return i && function updateFallbackSlotVisibility(e, n, o, r, i, c, a, s) {
        for (r = 0, i = (o = t._$$childNodes$_(e)).length; r < i; r++) if (n = o[r], 1 /* ElementNode */ === t._$$nodeType$_(n)) {
          if (n["s-sr"]) for (
          // this is a slot fallback node
          // get the slot name for this slot reference node
          a = n["s-sn"], 
          // by default always show a fallback slot node
          // then hide it if there are other slots in the light dom
          n.hidden = !1, c = 0; c < i; c++) if (o[c]["s-hn"] !== n["s-hn"]) if (
          // this sibling node is from a different component
          s = t._$$nodeType$_(o[c]), "" !== a) {
            // this is a named fallback slot node
            if (1 /* ElementNode */ === s && a === t._$$getAttribute$_(o[c], "slot")) {
              n.hidden = !0;
              break;
            }
          } else 
          // this is a default fallback slot node
          // any element or text node (with content)
          // should hide the default fallback slot node
          if (1 /* ElementNode */ === s || 3 /* TextNode */ === s && "" !== t._$$getTextContent$_(o[c]).trim()) {
            n.hidden = !0;
            break;
          }
          // keep drilling down
                    updateFallbackSlotVisibility(n);
        }
      }(p._$elm$_), 
      // always reset
      n.length = 0, p;
    };
  }
  function callNodeRefs(e, t) {
    e && (e.vattrs && e.vattrs.ref && e.vattrs.ref(t ? null : e._$elm$_), e.vchildren && e.vchildren.forEach(e => {
      callNodeRefs(e, t);
    }));
  }
  function addChildSsrVNodes(e, t, n, o, r) {
    const c = e._$$nodeType$_(t);
    let a, s, l, f;
    if (r && 1 /* ElementNode */ === c) {
      (s = e._$$getAttribute$_(t, i)) && (
      // split the start comment's data with a period
      l = s.split("."))[0] === o && (
      // cool, this element is a child to the parent vnode
      (f = {}).vtag = e._$$tagName$_(f._$elm$_ = t), 
      // this is a new child vnode
      // so ensure its parent vnode has the vchildren array
      n.vchildren || (n.vchildren = []), 
      // add our child vnode to a specific index of the vnode's children
      n.vchildren[l[1]] = f, 
      // this is now the new parent vnode for all the next child checks
      n = f, 
      // if there's a trailing period, then it means there aren't any
      // more nested elements, but maybe nested text nodes
      // either way, don't keep walking down the tree after this next call
      r = "" !== l[2]);
      // keep drilling down through the elements
            for (let i = 0; i < t.childNodes.length; i++) addChildSsrVNodes(e, t.childNodes[i], n, o, r);
    } else 3 /* TextNode */ === c && (a = t.previousSibling) && 8 /* CommentNode */ === e._$$nodeType$_(a) && "s" === (
    // split the start comment's data with a period
    l = e._$$getTextContent$_(a).split("."))[0] && l[1] === o && (
    // cool, this is a text node and it's got a start comment
    (f = {
      vtext: e._$$getTextContent$_(t)
    })._$elm$_ = t, 
    // this is a new child vnode
    // so ensure its parent vnode has the vchildren array
    n.vchildren || (n.vchildren = []), 
    // add our child vnode to a specific index of the vnode's children
    n.vchildren[l[2]] = f);
  }
  function initHostElement(e, t, n, o) {
    // let's wire up our functions to the host element's prototype
    // we can also inject our platform into each one that needs that api
    // note: these cannot be arrow functions cuz "this" is important here hombre
    n.connectedCallback = function() {
      // coolsville, our host element has just hit the DOM
      (function connectedCallback(e, t, n) {
        // initialize our event listeners on the host element
        // we do this now so that we can listening to events that may
        // have fired even before the instance is ready
        e._$hasListenersMap$_.has(n) || (
        // it's possible we've already connected
        // then disconnected
        // and the same element is reconnected again
        e._$hasListenersMap$_.set(n, !0), function initElementListeners(e, t) {
          // so the element was just connected, which means it's in the DOM
          // however, the component instance hasn't been created yet
          // but what if an event it should be listening to get emitted right now??
          // let's add our listeners right now to our element, and if it happens
          // to receive events between now and the instance being created let's
          // queue up all of the event data and fire it off on the instance when it's ready
          const n = e._$getComponentMeta$_(t);
          n._$listenersMeta$_ && 
          // we've got listens
          n._$listenersMeta$_.forEach(n => {
            // go through each listener
            n._$eventDisabled$_ || 
            // only add ones that are not already disabled
            e._$domApi$_._$$addEventListener$_(t, n._$eventName$_, function createListenerCallback(e, t, n, o) {
              // create the function that gets called when the element receives
              // an event which it should be listening for
              return r => {
                // get the instance if it exists
                (o = e._$instanceMap$_.get(t)) ? 
                // instance is ready, let's call it's member method for this event
                o[n](r) : (
                // instance is not ready!!
                // let's queue up this event data and replay it later
                // when the instance is ready
                (o = e._$queuedEvents$_.get(t) || []).push(n, r), e._$queuedEvents$_.set(t, o));
              };
            }(e, t, n._$eventMethodName$_), n._$eventCapture$_, n._$eventPassive$_);
          });
        }(e, n)), 
        // this element just connected, which may be re-connecting
        // ensure we remove it from our map of disconnected
        e._$isDisconnectedMap$_.delete(n), e._$hasConnectedMap$_.has(n) || (
        // first time we've connected
        e._$hasConnectedMap$_.set(n, !0), n["s-id"] || (
        // assign a unique id to this host element
        // it's possible this was already given an element id
        n["s-id"] = e._$nextId$_()), 
        // register this component as an actively
        // loading child to its parent component
        function registerWithParentComponent(e, t, n) {
          for (
          // find the first ancestor host element (if there is one) and register
          // this element as one of the actively loading child elements for its ancestor
          n = t; n = e._$domApi$_._$$parentElement$_(n); ) 
          // climb up the ancestors looking for the first registered component
          if (e._$isDefinedComponent$_(n)) {
            // we found this elements the first ancestor host element
            // if the ancestor already loaded then do nothing, it's too late
            e._$hasLoadedMap$_.has(t) || (
            // keep a reference to this element's ancestor host element
            // elm._ancestorHostElement = ancestorHostElement;
            e._$ancestorHostElementMap$_.set(t, n), 
            // ensure there is an array to contain a reference to each of the child elements
            // and set this element as one of the ancestor's child elements it should wait on
            n.$activeLoading && (
            // $activeLoading deprecated 2018-04-02
            n["s-ld"] = n.$activeLoading), (n["s-ld"] = n["s-ld"] || []).push(t));
            break;
          }
        }(e, n), 
        // add to the queue to load the bundle
        // it's important to have an async tick in here so we can
        // ensure the "mode" attribute has been added to the element
        // place in high priority since it's not much work and we need
        // to know as fast as possible, but still an async tick in between
        e.queue.tick(() => {
          // start loading this component mode's bundle
          // if it's already loaded then the callback will be synchronous
          e._$hostSnapshotMap$_.set(n, function initHostSnapshot(e, t, n, o, i) {
            // the host element has connected to the dom
            // and we've waited a tick to make sure all frameworks
            // have finished adding attributes and child nodes to the host
            // before we go all out and hydrate this beast
            // let's first take a snapshot of its original layout before render
            return n.mode || (
            // looks like mode wasn't set as a property directly yet
            // first check if there's an attribute
            // next check the app's global
            n.mode = e._$$getMode$_(n)), 
            // if the slot polyfill is required we'll need to put some nodes
            // in here to act as original content anchors as we move nodes around
            // host element has been connected to the DOM
            n["s-cr"] || e._$$getAttribute$_(n, r) || e._$$supportsShadowDom$_ && 1 /* ShadowDom */ === t._$encapsulationMeta$_ || (
            // only required when we're NOT using native shadow dom (slot)
            // or this browser doesn't support native shadow dom
            // and this host element was NOT created with SSR
            // let's pick out the inner content for slot projection
            // create a node to represent where the original
            // content was first placed, which is useful later on
            n["s-cr"] = e._$$createTextNode$_(""), n["s-cr"]["s-cn"] = !0, e._$$insertBefore$_(n, n["s-cr"], e._$$childNodes$_(n)[0])), 
            e._$$supportsShadowDom$_ || 1 /* ShadowDom */ !== t._$encapsulationMeta$_ || (n.shadowRoot = n), 
            // create a host snapshot object we'll
            // use to store all host data about to be read later
            o = {
              _$$id$_: n["s-id"],
              _$$attributes$_: {}
            }, 
            // loop through and gather up all the original attributes on the host
            // this is useful later when we're creating the component instance
            t._$membersMeta$_ && Object.keys(t._$membersMeta$_).forEach(r => {
              (i = t._$membersMeta$_[r]._$attribName$_) && (o._$$attributes$_[i] = e._$$getAttribute$_(n, i));
            }), o;
          }(e._$domApi$_, t, n)), e._$requestBundle$_(t, n);
        }));
      })(e, t, this);
    }, n.attributeChangedCallback = function(e, n, o) {
      // the browser has just informed us that an attribute
      // on the host element has changed
      (function attributeChangedCallback(e, t, n, o, r, i, c) {
        // only react if the attribute values actually changed
        if (e && o !== r) 
        // using the known component meta data
        // look up to see if we have a property wired up to this attribute name
        for (i in e) 
        // normalize the attribute name w/ lower case
        if ((c = e[i])._$attribName$_ && f(c._$attribName$_) === f(n)) {
          // cool we've got a prop using this attribute name, the value will
          // be a string, so let's convert it to the correct type the app wants
          t[i] = parsePropertyValue(c._$propType$_, r);
          break;
        }
      })(t._$membersMeta$_, this, e, n, o);
    }, n.disconnectedCallback = function() {
      // the element has left the builing
      (function disconnectedCallback(e, t) {
        // only disconnect if we're not temporarily disconnected
        // tmpDisconnected will happen when slot nodes are being relocated
        if (!e._$tmpDisconnected$_ && function isDisconnected(e, t) {
          for (;t; ) {
            if (!e._$$parentNode$_(t)) return 9 /* DocumentNode */ !== e._$$nodeType$_(t);
            t = e._$$parentNode$_(t);
          }
        }(e._$domApi$_, t)) {
          // ok, let's officially destroy this thing
          // set this to true so that any of our pending async stuff
          // doesn't continue since we already decided to destroy this node
          // elm._hasDestroyed = true;
          e._$isDisconnectedMap$_.set(t, !0), 
          // double check that we've informed the ancestor host elements
          // that they're good to go and loaded (cuz this one is on its way out)
          propagateComponentLoaded(e, t), 
          // since we're disconnecting, call all of the JSX ref's with null
          callNodeRefs(e._$vnodeMap$_.get(t), !0), 
          // detatch any event listeners that may have been added
          // because we're not passing an exact event name it'll
          // remove all of this element's event, which is good
          e._$domApi$_._$$removeEventListener$_(t), e._$hasListenersMap$_.delete(t);
          {
            // call instance componentDidUnload
            // if we've created an instance for this
            const n = e._$instanceMap$_.get(t);
            n && 
            // call the user's componentDidUnload if there is one
            n.componentDidUnload && n.componentDidUnload();
          }
          // clear CSS var-shim tracking
                    // clear any references to other elements
          // more than likely we've already deleted these references
          // but let's double check there pal
          [ e._$ancestorHostElementMap$_, e._$onReadyCallbacksMap$_, e._$hostSnapshotMap$_ ].forEach(e => e.delete(t));
        }
      })(e, this);
    }, n["s-init"] = function() {
      (function initComponentLoaded(e, t, n, o, r) {
        // all is good, this component has been told it's time to finish loading
        // it's possible that we've already decided to destroy this element
        // check if this element has any actively loading child elements
        if (!e._$hasLoadedMap$_.has(t) && (o = e._$instanceMap$_.get(t)) && !e._$isDisconnectedMap$_.has(t) && (!t["s-ld"] || !t["s-ld"].length)) {
          // cool, so at this point this element isn't already being destroyed
          // and it does not have any child elements that are still loading
          // ensure we remove any child references cuz it doesn't matter at this point
          delete t["s-ld"], 
          // sweet, this particular element is good to go
          // all of this element's children have loaded (if any)
          // elm._hasLoaded = true;
          e._$hasLoadedMap$_.set(t, !0);
          try {
            // fire off the ref if it exists
            callNodeRefs(e._$vnodeMap$_.get(t)), 
            // fire off the user's elm.componentOnReady() callbacks that were
            // put directly on the element (well before anything was ready)
            (r = e._$onReadyCallbacksMap$_.get(t)) && (r.forEach(e => e(t)), e._$onReadyCallbacksMap$_.delete(t)), 
            // fire off the user's componentDidLoad method (if one was provided)
            // componentDidLoad only runs ONCE, after the instance's element has been
            // assigned as the host element, and AFTER render() has been called
            // we'll also fire this method off on the element, just to
            o.componentDidLoad && o.componentDidLoad();
          } catch (n) {
            e._$onError$_(n, 4 /* DidLoadError */ , t);
          }
          // add the css class that this element has officially hydrated
                    e._$domApi$_._$$addClass$_(t, n), 
          // ( •_•)
          // ( •_•)>⌐■-■
          // (⌐■_■)
          // load events fire from bottom to top
          // the deepest elements load first then bubbles up
          propagateComponentLoaded(e, t);
        }
      })(e, this, o);
    }, n.forceUpdate = function() {
      queueUpdate(e, this);
    }, 
    // add getters/setters to the host element members
    // these would come from the @Prop and @Method decorators that
    // should create the public API to this component
    function proxyHostElementPrototype(e, t, n) {
      t && Object.keys(t).forEach(o => {
        // add getters/setters
        const r = t[o], i = r._$memberType$_;
        1 /* Prop */ === i || 2 /* PropMutable */ === i ? 
        // @Prop() or @Prop({ mutable: true })
        definePropertyGetterSetter(n, o, function getHostElementProp() {
          // host element getter (cannot be arrow fn)
          // yup, ugly, srynotsry
          return (e._$valuesMap$_.get(this) || {})[o];
        }, function setHostElementProp(t) {
          // host element setter (cannot be arrow fn)
          setValue(e, this, o, parsePropertyValue(r._$propType$_, t));
        }) : 6 /* Method */ === i && 
        // @Method()
        // add a placeholder noop value on the host element's prototype
        // incase this method gets called before setup
        definePropertyValue(n, o, u);
      });
    }(e, t._$membersMeta$_, n);
  }
  function proxyProp(e, t, n, o) {
    return function() {
      const r = arguments;
      return function loadComponent(e, t, n) {
        let o = t[n];
        const r = e._$$doc$_.body;
        return r ? (o || (o = r.querySelector(n)), o || (o = t[n] = e._$$createElement$_(n), 
        e._$$appendChild$_(r, o)), o.componentOnReady()) : Promise.resolve();
      }(e, t, n).then(e => e[o].apply(e, r));
    };
  }
  const r = "ssrv", i = "ssrc", c = "$", a = {}, s = {
    enter: 13,
    escape: 27,
    space: 32,
    tab: 9,
    left: 37,
    up: 38,
    right: 39,
    down: 40
  }, l = e => null != e, f = e => e.toLowerCase(), u = () => {}, p = [], d = {
    forEach: (e, t) => {
      e.forEach(e => t(VNodeToChild(e)));
    },
    map: (e, t) => e.map(e => (function childToVNode(e) {
      return {
        vtag: e.vtag,
        vchildren: e.vchildren,
        vtext: e.vtext,
        vattrs: e.vattrs,
        vkey: e.vkey,
        vname: e.vname
      };
    })(t(VNodeToChild(e))))
  }, m = "wc-", y = "http://www.w3.org/1999/xlink";
  let v = !1;
  // esm build which uses es module imports and dynamic imports
  (function createPlatformMain(e, t, n, o, i, a) {
    function defineComponent(e, t) {
      if (!n.customElements.get(e._$tagNameMeta$_)) {
        // define the custom element
        // initialize the members on the host element prototype
        // keep a ref to the metadata with the tag as the key
        initHostElement(v, l[e._$tagNameMeta$_] = e, t.prototype, a);
        {
          // add which attributes should be observed
          const n = t.observedAttributes = [];
          // at this point the membersMeta only includes attributes which should
          // be observed, it does not include all props yet, so it's safe to
          // loop through all of the props (attrs) and observed them
                    for (const t in e._$membersMeta$_) e._$membersMeta$_[t]._$attribName$_ && n.push(
          // add this attribute to our array of attributes we need to observe
          e._$membersMeta$_[t]._$attribName$_);
        }
        n.customElements.define(e._$tagNameMeta$_, t);
      }
    }
    const l = {
      html: {}
    }, u = {}, p = n[e] = n[e] || {}, d = function createDomApi(e, t, n) {
      // using the $ prefix so that closure is
      // cool with property renaming each of these
      e.ael || (e.ael = ((e, t, n, o) => e.addEventListener(t, n, o)), e.rel = ((e, t, n, o) => e.removeEventListener(t, n, o)));
      const o = new WeakMap(), r = {
        _$$doc$_: n,
        _$$supportsEventOptions$_: !1,
        _$$nodeType$_: e => e.nodeType,
        _$$createElement$_: e => n.createElement(e),
        _$$createElementNS$_: (e, t) => n.createElementNS(e, t),
        _$$createTextNode$_: e => n.createTextNode(e),
        _$$createComment$_: e => n.createComment(e),
        _$$insertBefore$_: (e, t, n) => e.insertBefore(t, n),
        // https://developer.mozilla.org/en-US/docs/Web/API/ChildNode/remove
        // and it's polyfilled in es5 builds
        _$$remove$_: e => e.remove(),
        _$$appendChild$_: (e, t) => e.appendChild(t),
        _$$addClass$_: (e, t) => e.classList.add(t),
        _$$childNodes$_: e => e.childNodes,
        _$$parentNode$_: e => e.parentNode,
        _$$nextSibling$_: e => e.nextSibling,
        _$$previousSibling$_: e => e.previousSibling,
        _$$tagName$_: e => f(e.nodeName),
        _$$getTextContent$_: e => e.textContent,
        _$$setTextContent$_: (e, t) => e.textContent = t,
        _$$getAttribute$_: (e, t) => e.getAttribute(t),
        _$$setAttribute$_: (e, t, n) => e.setAttribute(t, n),
        _$$setAttributeNS$_: (e, t, n, o) => e.setAttributeNS(t, n, o),
        _$$removeAttribute$_: (e, t) => e.removeAttribute(t),
        _$$hasAttribute$_: (e, t) => e.hasAttribute(t),
        _$$getMode$_: t => t.getAttribute("mode") || (e.Context || {}).mode,
        _$$elementRef$_: (e, o) => "child" === o ? e.firstElementChild : "parent" === o ? r._$$parentElement$_(e) : "body" === o ? n.body : "document" === o ? n : "window" === o ? t : e,
        _$$addEventListener$_: (t, n, i, c, a, l, f, u) => {
          // remember the original name before we possibly change it
          const p = n;
          let d = t, m = o.get(t);
          // get the existing unregister listeners for
          // this element from the unregister listeners weakmap
                    if (m && m[p] && 
          // removed any existing listeners for this event for the assigner element
          // this element already has this listener, so let's unregister it now
          m[p](), "string" == typeof l ? 
          // attachTo is a string, and is probably something like
          // "parent", "window", or "document"
          // and the eventName would be like "mouseover" or "mousemove"
          d = r._$$elementRef$_(t, l) : "object" == typeof l ? 
          // we were passed in an actual element to attach to
          d = l : (
          // depending on the event name, we could actually be attaching
          // this element to something like the document or window
          u = n.split(":")).length > 1 && (
          // document:mousemove
          // parent:touchend
          // body:keyup.enter
          d = r._$$elementRef$_(t, u[0]), n = u[1]), !d) 
          // somehow we're referencing an element that doesn't exist
          // let's not continue
          return;
          let h = i;
          // test to see if we're looking for an exact keycode
                    (u = n.split(".")).length > 1 && (
          // looks like this listener is also looking for a keycode
          // keyup.enter
          n = u[0], h = (e => {
            // wrap the user's event listener with our own check to test
            // if this keyboard event has the keycode they're looking for
            e.keyCode === s[u[1]] && i(e);
          })), 
          // create the actual event listener options to use
          // this browser may not support event options
          f = r._$$supportsEventOptions$_ ? {
            capture: !!c,
            passive: !!a
          } : !!c, 
          // ok, good to go, let's add the actual listener to the dom element
          e.ael(d, n, h, f), m || 
          // we don't already have a collection, let's create it
          o.set(t, m = {}), 
          // add the unregister listener to this element's collection
          m[p] = (() => {
            // looks like it's time to say goodbye
            d && e.rel(d, n, h, f), m[p] = null;
          });
        },
        _$$removeEventListener$_: (e, t) => {
          // get the unregister listener functions for this element
          const n = o.get(e);
          n && (
          // this element has unregister listeners
          t ? 
          // passed in one specific event name to remove
          n[t] && n[t]() : 
          // remove all event listeners
          Object.keys(n).forEach(e => {
            n[e] && n[e]();
          }));
        },
        _$$dispatchEvent$_: (e, n, o) => e && e.dispatchEvent(new t.CustomEvent(n, o))
      };
      // test if this browser supports event options or not
      try {
        t.addEventListener("e", null, Object.defineProperty({}, "passive", {
          get: () => r._$$supportsEventOptions$_ = !0
        }));
      } catch (e) {}
      return r._$$parentElement$_ = ((e, t) => 
      // if the parent node is a document fragment (shadow root)
      // then use the "host" property on it
      // otherwise use the parent node
      (t = r._$$parentNode$_(e)) && 11 /* DocumentFragment */ === r._$$nodeType$_(t) ? t.host : t), 
      r;
    }(p, n, o);
    // set App Context
    t.isServer = t.isPrerender = !(t.isClient = !0), t.window = n, t.location = n.location, 
    t.document = o, t.resourcesUrl = t.publicPath = i, t.enableListener = ((e, t, n, o, r) => (function enableEventListener(e, t, n, o, r, i) {
      if (t) {
        // cool, we've got an instance, it's get the element it's on
        const c = e._$hostElementMap$_.get(t), a = e._$getComponentMeta$_(c);
        if (a && a._$listenersMeta$_) 
        // alrighty, so this cmp has listener meta
        if (o) {
          // we want to enable this event
          // find which listen meta we're talking about
          const o = a._$listenersMeta$_.find(e => e._$eventName$_ === n);
          o && 
          // found the listen meta, so let's add the listener
          e._$domApi$_._$$addEventListener$_(c, n, e => t[o._$eventMethodName$_](e), o._$eventCapture$_, void 0 === i ? o._$eventPassive$_ : !!i, r);
        } else 
        // we're disabling the event listener
        // so let's just remove it entirely
        e._$domApi$_._$$removeEventListener$_(c, n);
      }
    })(v, e, t, n, o, r)), t.emit = ((e, n, o) => d._$$dispatchEvent$_(e, t.eventNameFn ? t.eventNameFn(n) : n, o)), 
    // add the h() fn to the app's global namespace
    p.h = h, p.Context = t;
    // keep a global set of tags we've already defined
    // DEPRECATED $definedCmps 2018-05-22
    const m = n["s-defined"] = n.$definedCmps = n["s-defined"] || n.$definedCmps || {};
    // internal id increment for unique ids
        let y = 0;
    // create the platform api which is used throughout common core code
        const v = {
      _$domApi$_: d,
      _$defineComponent$_: defineComponent,
      _$emitEvent$_: t.emit,
      _$getComponentMeta$_: e => l[d._$$tagName$_(e)],
      _$getContextItem$_: e => t[e],
      isClient: !0,
      _$isDefinedComponent$_: e => !(!m[d._$$tagName$_(e)] && !v._$getComponentMeta$_(e)),
      _$nextId$_: () => e + y++,
      _$onError$_: (e, t, n) => console.error(e, t, n && n.tagName),
      _$propConnect$_: e => (function proxyController(e, t, n) {
        return {
          create: proxyProp(e, t, n, "create"),
          componentOnReady: proxyProp(e, t, n, "componentOnReady")
        };
      })(d, u, e),
      queue: t.queue = function createQueueClient(e, t) {
        function consume(e) {
          for (let t = 0; t < e.length; t++) try {
            e[t](n());
          } catch (e) {
            console.error(e);
          }
          e.length = 0;
        }
        function consumeTimeout(e, t) {
          let o, r = 0;
          for (;r < e.length && (o = n()) < t; ) try {
            e[r++](o);
          } catch (e) {
            console.error(e);
          }
          r === e.length ? e.length = 0 : 0 !== r && e.splice(0, r);
        }
        function flush() {
          s++, 
          // always force a bunch of medium callbacks to run, but still have
          // a throttle on how many can run in a certain time
          // DOM READS!!!
          consume(i);
          const t = n() + 7 * Math.ceil(s * (1 / 22));
          // DOM WRITES!!!
                    consumeTimeout(c, t), consumeTimeout(a, t), c.length > 0 && (a.push(...c), 
          c.length = 0), (l = i.length + c.length + a.length > 0) ? 
          // still more to do yet, but we've run out of time
          // let's let this thing cool off and try again in the next tick
          e.raf(flush) : s = 0;
        }
        const n = () => t.performance.now(), o = Promise.resolve(), r = [], i = [], c = [], a = [];
        let s = 0, l = !1;
        return e.raf || (e.raf = t.requestAnimationFrame.bind(t)), {
          tick(e) {
            // queue high priority work to happen in next tick
            // uses Promise.resolve() for next tick
            r.push(e), 1 === r.length && o.then(() => consume(r));
          },
          read(t) {
            // queue dom reads
            i.push(t), l || (l = !0, e.raf(flush));
          },
          write(t) {
            // queue dom writes
            c.push(t), l || (l = !0, e.raf(flush));
          }
        };
      }(p, n),
      _$requestBundle$_: function requestBundle(e, t, n) {
        if (e._$componentConstructor$_) 
        // we're already all loaded up :)
        queueUpdate(v, t); else {
          // self loading module using built-in browser's import()
          // this is when not using a 3rd party bundler
          // and components are able to lazy load themselves
          // through standardized browser APIs
          const n = "string" == typeof e._$bundleIds$_ ? e._$bundleIds$_ : e._$bundleIds$_[t.mode], o = 2 /* ScopedCss */ === e._$encapsulationMeta$_ || 1 /* ShadowDom */ === e._$encapsulationMeta$_ && !d._$$supportsShadowDom$_;
          let r = i + n + (o ? ".sc" : "") + ".js";
          // dynamic es module import() => woot!
          import(r).then(n => {
            // async loading of the module is done
            try {
              // get the component constructor from the module
              // initialize this component constructor's styles
              // it is possible for the same component to have difficult styles applied in the same app
              e._$componentConstructor$_ = n[(e => f(e).split("-").map(e => e.charAt(0).toUpperCase() + e.slice(1)).join(""))(e._$tagNameMeta$_)], 
              function initStyleTemplate(e, t, n, o, r) {
                if (o) {
                  // we got a style mode for this component, let's create an id for this style
                  const n = t._$tagNameMeta$_ + (r || c);
                  if (!t[n]) {
                    // use <template> elements to clone styles
                    // create the template element which will hold the styles
                    // adding it to the dom via <template> so that we can
                    // clone this for each potential shadow root that will need these styles
                    // otherwise it'll be cloned and added to document.body.head
                    // but that's for the renderer to figure out later
                    const r = e._$$createElement$_("template");
                    // keep a reference to this template element within the
                    // Constructor using the style mode id as the key
                                        t[n] = r, 
                    // prod mode, no style id data attributes
                    r.innerHTML = `<style>${o}</style>`, 
                    // add our new template element to the head
                    // so it can be cloned later
                    e._$$appendChild$_(e._$$doc$_.head, r);
                  }
                }
              }(d, e, e._$encapsulationMeta$_, e._$componentConstructor$_.style, e._$componentConstructor$_.styleMode);
            } catch (t) {
              // oh man, something's up
              console.error(t), 
              // provide a bogus component constructor
              // so the rest of the app acts as normal
              e._$componentConstructor$_ = class {};
            }
            // bundle all loaded up, let's continue
                        queueUpdate(v, t);
          }).catch(e => console.error(e, r));
        }
      },
      _$ancestorHostElementMap$_: new WeakMap(),
      _$componentAppliedStyles$_: new WeakMap(),
      _$hasConnectedMap$_: new WeakMap(),
      _$hasListenersMap$_: new WeakMap(),
      _$hasLoadedMap$_: new WeakMap(),
      _$hostElementMap$_: new WeakMap(),
      _$hostSnapshotMap$_: new WeakMap(),
      _$instanceMap$_: new WeakMap(),
      _$isDisconnectedMap$_: new WeakMap(),
      _$isQueuedForUpdate$_: new WeakMap(),
      _$onReadyCallbacksMap$_: new WeakMap(),
      _$queuedEvents$_: new WeakMap(),
      _$vnodeMap$_: new WeakMap(),
      _$valuesMap$_: new WeakMap()
    };
    // create the renderer that will be used
        v.render = createRendererPatch(v, d);
    // setup the root element which is the mighty <html> tag
    // the <html> has the final say of when the app has loaded
    const b = d._$$doc$_.documentElement;
    b["s-ld"] = [], b["s-rn"] = !0, 
    // this will fire when all components have finished loaded
    b["s-init"] = (() => {
      v._$hasLoadedMap$_.set(b, p.loaded = v._$isAppLoaded$_ = !0), d._$$dispatchEvent$_(n, "appload", {
        detail: {
          namespace: e
        }
      });
    }), 
    // if the HTML was generated from SSR
    // then let's walk the tree and generate vnodes out of the data
    function createVNodesFromSsr(e, t, n) {
      const o = n.querySelectorAll(`[${r}]`), i = o.length;
      let c, a, s, l, f, u;
      if (i > 0) for (e._$hasLoadedMap$_.set(n, !0), l = 0; l < i; l++) for (c = o[l], 
      a = t._$$getAttribute$_(c, r), (s = {}).vtag = t._$$tagName$_(s._$elm$_ = c), e._$vnodeMap$_.set(c, s), 
      f = 0, u = c.childNodes.length; f < u; f++) addChildSsrVNodes(t, c.childNodes[f], s, a, !0);
    }(v, d, b), v._$attachStyles$_ = ((e, t, n, o) => {
      (function attachStyles(e, t, n, o) {
        // first see if we've got a style for a specific mode
        // either this host element should use scoped css
        // or it wants to use shadow dom but the browser doesn't support it
        // create a scope id which is useful for scoped css
        // and add the scope attribute to the host
        const r = 2 /* ScopedCss */ === n._$encapsulationMeta$_ || 1 /* ShadowDom */ === n._$encapsulationMeta$_ && !e._$domApi$_._$$supportsShadowDom$_;
        // create the style id w/ the host element's mode
                let i = n._$tagNameMeta$_ + o.mode, a = n[i];
        if (r && (o["s-sc"] = getScopeId(n, o.mode)), a || (
        // doesn't look like there's a style template with the mode
        // create the style id using the default style mode and try again
        a = n[i = n._$tagNameMeta$_ + c], r && (o["s-sc"] = getScopeId(n))), a) {
          // cool, we found a style template element for this component
          let r = t._$$doc$_.head;
          // if this browser supports shadow dom, then let's climb up
          // the dom and see if we're within a shadow dom
                    if (t._$$supportsShadowDom$_) if (1 /* ShadowDom */ === n._$encapsulationMeta$_) 
          // we already know we're in a shadow dom
          // so shadow root is the container for these styles
          r = o.shadowRoot; else {
            // climb up the dom and see if we're in a shadow dom
            let e = o;
            for (;e = t._$$parentNode$_(e); ) if (e.host && e.host.shadowRoot) {
              // looks like we are in shadow dom, let's use
              // this shadow root as the container for these styles
              r = e.host.shadowRoot;
              break;
            }
          }
          // if this container element already has these styles
          // then there's no need to apply them again
          // create an object to keep track if we'ready applied this component style
                    let c = e._$componentAppliedStyles$_.get(r);
          // check if we haven't applied these styles to this container yet
          if (c || e._$componentAppliedStyles$_.set(r, c = {}), !c[i]) {
            let e;
            {
              // this browser supports the <template> element
              // and all its native content.cloneNode() goodness
              // clone the template element to create a new <style> element
              e = a.content.cloneNode(!0), 
              // remember we don't need to do this again for this element
              c[i] = !0;
              // let's make sure we put the styles below the <style data-styles> element
              // so any visibility css overrides the default
              const n = r.querySelectorAll("[data-styles]");
              t._$$insertBefore$_(r, e, n.length && n[n.length - 1].nextSibling || r.firstChild);
            }
          }
        }
      })(e, t, n, o);
    }), 
    // register all the components now that everything's ready
    // standard es2017 class extends HTMLElement
    (p.components || []).map(e => {
      const t = function parseComponentLoader(e, t, n) {
        // tag name will always be lower case
        const o = {
          _$tagNameMeta$_: e[0],
          _$membersMeta$_: {
            // every component defaults to always have
            // the mode and color properties
            // but only color should observe any attribute changes
            color: {
              _$attribName$_: "color"
            }
          }
        };
        // map of the bundle ids
        // can contain modes, and array of esm and es5 bundle ids
                o._$bundleIds$_ = e[1];
        // parse member meta
        // this data only includes props that are attributes that need to be observed
        // it does not include all of the props yet
        const r = e[3];
        if (r) for (t = 0; t < r.length; t++) n = r[t], o._$membersMeta$_[n[0]] = {
          _$memberType$_: n[1],
          _$reflectToAttrib$_: !!n[2],
          _$attribName$_: "string" == typeof n[3] ? n[3] : n[3] ? n[0] : 0,
          _$propType$_: n[4]
        };
        // encapsulation
                return o._$encapsulationMeta$_ = e[4], e[5] && (
        // parse listener meta
        o._$listenersMeta$_ = e[5].map(parseListenerData)), o;
      }(e);
      return l[t._$tagNameMeta$_] = t;
    }).forEach(e => defineComponent(e, class extends HTMLElement {})), 
    // create the componentOnReady fn
    function initCoreComponentOnReady(e, t, n, o, r, i) {
      if (
      // add componentOnReady() to the App object
      // this also is used to know that the App's core is ready
      t.componentOnReady = ((t, n) => {
        if (!t.nodeName.includes("-")) return n(null), !1;
        const o = e._$getComponentMeta$_(t);
        if (o) if (e._$hasLoadedMap$_.has(t)) 
        // element has already loaded, pass the resolve the element component
        // so we know that the resolve knows it this element is an app component
        n(t); else {
          // element hasn't loaded yet
          // add this resolve specifically to this elements on ready queue
          const o = e._$onReadyCallbacksMap$_.get(t) || [];
          o.push(n), e._$onReadyCallbacksMap$_.set(t, o);
        }
        // return a boolean if this app recognized this element or not
                return !!o;
      }), r) {
        // we've got some componentOnReadys in the queue before the app was ready
        for (i = r.length - 1; i >= 0; i--) 
        // go through each element and see if this app recongizes it
        t.componentOnReady(r[i][0], r[i][1]) && 
        // turns out this element belongs to this app
        // remove the resolve from the queue so in the end
        // all that's left in the queue are elements not apart of any apps
        r.splice(i, 1);
        for (i = 0; i < o.length; i++) if (!n[o[i]].componentOnReady) 
        // there is at least 1 apps that isn't ready yet
        // so let's stop here cuz there's still app cores loading
        return;
        // if we got to this point then that means all of the apps are ready
        // and they would have removed any of their elements from queuedComponentOnReadys
        // so let's do the cleanup of the  remaining queuedComponentOnReadys
                for (i = 0; i < r.length; i++) 
        // resolve any queued componentsOnReadys that are left over
        // since these elements were not apart of any apps
        // call the resolve fn, but pass null so it's know this wasn't a known app component
        r[i][1](null);
        r.length = 0;
      }
    }(v, p, n, n["s-apps"], n["s-cr"]), 
    // notify that the app has initialized and the core script is ready
    // but note that the components have not fully loaded yet
    p.initialized = !0;
  })(o, n, e, t, resourcesUrl, hydratedCssClass);
})(window, document, Context, namespace);
})({},"GxWebControls","hydrated");