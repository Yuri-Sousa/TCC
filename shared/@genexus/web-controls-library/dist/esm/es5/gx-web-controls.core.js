/*!
 * GxWebControls: Core, ES5
 * Built with http://stenciljs.com
 */
function getScopeId(n, t) {
  return "sc-" + n._$tagNameMeta$_ + (t && t !== y ? "-" + t : "");
}

function getElementScopeId(n, t) {
  return n + (t ? "-h" : "-s");
}

function parseListenerData(n) {
  return {
    _$eventName$_: n[0],
    _$eventMethodName$_: n[1],
    _$eventDisabled$_: !!n[2],
    _$eventPassive$_: !!n[3],
    _$eventCapture$_: !!n[4]
  };
}

function parsePropertyValue(n, t) {
  // ensure this value is of the correct prop type
  // we're testing both formats of the "propType" value because
  // we could have either gotten the data from the attribute changed callback,
  // which wouldn't have Constructor data yet, and because this method is reused
  // within proxy where we don't have meta data, but only constructor data
  if (g(t) && "object" != typeof t && "function" != typeof t) {
    if (n === Boolean || 3 /* Boolean */ === n) 
    // per the HTML spec, any string value means it is a boolean true value
    // but we'll cheat here and say that the string "false" is the boolean false
    return "false" !== t && ("" === t || !!t);
    if (n === Number || 4 /* Number */ === n) 
    // force it to be a number
    return parseFloat(t);
    if (n === String || 2 /* String */ === n) 
    // could have been passed as a number or boolean
    // but we still want it as a string
    return t.toString();
  }
  // not sure exactly what type we want
  // so no need to change to a different type
    return t;
}

function propagateComponentLoaded(n, t, e, r) {
  // load events fire from bottom to top
  // the deepest elements load first then bubbles up
  var o = n._$ancestorHostElementMap$_.get(t);
  o && (
  // ok so this element already has a known ancestor host element
  // let's make sure we remove this element from its ancestor's
  // known list of child elements which are actively loading
  (r = o["s-ld"] || o.$activeLoading) && ((e = r.indexOf(t)) > -1 && 
  // yup, this element is in the list of child elements to wait on
  // remove it so we can work to get the length down to 0
  r.splice(e, 1), 
  // the ancestor's initLoad method will do the actual checks
  // to see if the ancestor is actually loaded or not
  // then let's call the ancestor's initLoad method if there's no length
  // (which actually ends up as this method again but for the ancestor)
  r.length || (o["s-init"] && o["s-init"](), 
  // $initLoad deprecated 2018-04-02
  o.$initLoad && o.$initLoad())), n._$ancestorHostElementMap$_.delete(t));
}

/**
 * Production h() function based on Preact by
 * Jason Miller (@developit)
 * Licensed under the MIT License
 * https://github.com/developit/preact/blob/master/LICENSE
 *
 * Modified for Stencil's compiler and vdom
 */ function h(n, t) {
  for (var e, r, o = null, i = !1, u = !1, f = arguments.length; f-- > 2; ) E.push(arguments[f]);
  for (;E.length > 0; ) {
    var c = E.pop();
    if (c && void 0 !== c.pop) for (f = c.length; f--; ) E.push(c[f]); else "boolean" == typeof c && (c = null), 
    (u = "function" != typeof n) && (null == c ? c = "" : "number" == typeof c ? c = String(c) : "string" != typeof c && (u = !1)), 
    u && i ? o[o.length - 1].vtext += c : null === o ? o = [ u ? {
      vtext: c
    } : c ] : o.push(u ? {
      vtext: c
    } : c), i = u;
  }
  if (null != t) {
    if (
    // normalize class / classname attributes
    t.className && (t.class = t.className), "object" == typeof t.class) {
      for (f in t.class) t.class[f] && E.push(f);
      t.class = E.join(" "), E.length = 0;
    }
    null != t.key && (e = t.key), null != t.name && (r = t.name);
  }
  return "function" == typeof n ? n(Object.assign({}, t, {
    children: o
  }), M) : {
    vtag: n,
    vchildren: o,
    vtext: void 0,
    vattrs: t,
    vkey: e,
    vname: r,
    _$elm$_: void 0,
    _$ishost$_: !1
  };
}

function VNodeToChild(n) {
  return {
    vtag: n.vtag,
    vchildren: n.vchildren,
    vtext: n.vtext,
    vattrs: n.vattrs,
    vkey: n.vkey,
    vname: n.vname
  };
}

function queueUpdate(n, t) {
  // only run patch if it isn't queued already
  n._$isQueuedForUpdate$_.has(t) || (n._$isQueuedForUpdate$_.set(t, !0), 
  // run the patch in the next tick
  // vdom diff and patch the host element for differences
  n._$isAppLoaded$_ ? 
  // app has already loaded
  // let's queue this work in the dom write phase
  n.queue.write(function() {
    return update(n, t);
  }) : 
  // app hasn't finished loading yet
  // so let's use next tick to do everything
  // as fast as possible
  n.queue.tick(function() {
    return update(n, t);
  }));
}

function update(n, t, e, r, o, i) {
  // everything is async, so somehow we could have already disconnected
  // this node, so be sure to do nothing if we've already disconnected
  if (
  // no longer queued for update
  n._$isQueuedForUpdate$_.delete(t), !n._$isDisconnectedMap$_.has(t)) {
    if (r = n._$instanceMap$_.get(t), e = !r) {
      if ((o = n._$ancestorHostElementMap$_.get(t)) && o.$rendered && (
      // $rendered deprecated 2018-04-02
      o["s-rn"] = !0), o && !o["s-rn"]) 
      // this is the intial load
      // this element has an ancestor host element
      // but the ancestor host element has NOT rendered yet
      // so let's just cool our jets and wait for the ancestor to render
      return (o["s-rc"] = o["s-rc"] || []).push(function() {
        // this will get fired off when the ancestor host element
        // finally gets around to rendering its lazy self
        update(n, t);
      }), void (
      // $onRender deprecated 2018-04-02
      o.$onRender = o["s-rc"]);
      // haven't created a component instance for this host element yet!
      // create the instance from the user's component class
      // https://www.youtube.com/watch?v=olLxrojmvMg
            r = function initComponentInstance(n, t, e, r, o, i, u) {
        try {
          r = new (
          // using the user's component class, let's create a new instance
          o = n._$getComponentMeta$_(t)._$componentConstructor$_)(), 
          // ok cool, we've got an host element now, and a actual instance
          // and there were no errors creating the instance
          // let's upgrade the data on the host element
          // and let the getters/setters do their jobs
          function proxyComponentInstance(n, t, e, r, o, i, u) {
            // define each of the members and initialize what their role is
            for (u in 
            // at this point we've got a specific node of a host element, and created a component class instance
            // and we've already created getters/setters on both the host element and component class prototypes
            // let's upgrade any data that might have been set on the host element already
            // and let's have the getters/setters kick in and do their jobs
            // let's automatically add a reference to the host element on the instance
            n._$hostElementMap$_.set(r, e), 
            // create the values object if it doesn't already exist
            // this will hold all of the internal getter/setter values
            n._$valuesMap$_.has(e) || n._$valuesMap$_.set(e, {}), 
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
            }, i) defineMember(n, i[u], e, r, u, o);
          }(n, o, t, r, e), 
          // add each of the event emitters which wire up instance methods
          // to fire off dom events from the host element
          function initEventEmitters(n, t, e) {
            if (t) {
              var r = n._$hostElementMap$_.get(e);
              t.forEach(function(t) {
                e[t.method] = {
                  emit: function(e) {
                    n._$emitEvent$_(r, t.name, {
                      bubbles: t.bubbles,
                      composed: t.composed,
                      cancelable: t.cancelable,
                      detail: e
                    });
                  }
                };
              });
            }
          }(n, o.events, r);
          try {
            if (
            // replay any event listeners on the instance that
            // were queued up between the time the element was
            // connected and before the instance was ready
            i = n._$queuedEvents$_.get(t)) {
              // events may have already fired before the instance was even ready
              // now that the instance is ready, let's replay all of the events that
              // we queued up earlier that were originally meant for the instance
              for (u = 0; u < i.length; u += 2) 
              // data was added in sets of two
              // first item the eventMethodName
              // second item is the event data
              // take a look at initElementListener()
              r[i[u]](i[u + 1]);
              n._$queuedEvents$_.delete(t);
            }
          } catch (e) {
            n._$onError$_(e, 2 /* QueueEventsError */ , t);
          }
        } catch (e) {
          // something done went wrong trying to create a component instance
          // create a dumby instance so other stuff can load
          // but chances are the app isn't fully working cuz this component has issues
          r = {}, n._$onError$_(e, 7 /* InitInstanceError */ , t, !0);
        }
        return n._$instanceMap$_.set(t, r), r;
      }(n, t, n._$hostSnapshotMap$_.get(t));
      // fire off the user's componentWillLoad method (if one was provided)
      // componentWillLoad only runs ONCE, after instance's element has been
      // assigned as the host element, but BEFORE render() has been called
      try {
        r.componentWillLoad && (i = r.componentWillLoad());
      } catch (e) {
        n._$onError$_(e, 3 /* WillLoadError */ , t);
      }
    } else 
    // already created an instance and this is an update
    // fire off the user's componentWillUpdate method (if one was provided)
    // componentWillUpdate runs BEFORE render() has been called
    // but only BEFORE an UPDATE and not before the intial render
    // get the returned promise (if one was provided)
    try {
      r.componentWillUpdate && (i = r.componentWillUpdate());
    } catch (e) {
      n._$onError$_(e, 5 /* WillUpdateError */ , t);
    }
    i && i.then ? 
    // looks like the user return a promise!
    // let's not actually kick off the render
    // until the user has resolved their promise
    i.then(function() {
      return renderUpdate(n, t, r, e);
    }) : 
    // user never returned a promise so there's
    // no need to wait on anything, let's do the render now my friend
    renderUpdate(n, t, r, e);
  }
}

function renderUpdate(n, t, e, r) {
  // if this component has a render function, let's fire
  // it off and generate a vnode for this
  (function render(n, t, e, r) {
    try {
      // if this component has a render function, let's fire
      // it off and generate the child vnodes for this host element
      // note that we do not create the host element cuz it already exists
      var o = t._$componentConstructor$_.host, i = t._$componentConstructor$_.encapsulation, u = "shadow" === i && n._$domApi$_._$$supportsShadowDom$_, f = void 0;
      if (u || (
      // not using, or can't use shadow dom
      // set the root element, which will be the shadow root when enabled
      f = e), !e["s-rn"]) {
        // attach the styles this component needs, if any
        // this fn figures out if the styles should go in a
        // shadow root or if they should be global
        n._$attachStyles$_(n, n._$domApi$_, t, e);
        // if no render function
        var c = e["s-sc"];
        c && (n._$domApi$_._$$addClass$_(e, getElementScopeId(c, !0)), r.render || n._$domApi$_._$$addClass$_(e, getElementScopeId(c)));
      }
      if (r.render || r.hostData || o) {
        // tell the platform we're actively rendering
        // if a value is changed within a render() then
        // this tells the platform not to queue the change
        n._$activeRender$_ = !0;
        var a, s = r.render && r.render();
        // user component provided a "hostData()" method
        // the returned data/attributes are used on the host element
        a = r.hostData && r.hostData(), 
        // tell the platform we're done rendering
        // now any changes will again queue
        n._$activeRender$_ = !1;
        // looks like we've got child nodes to render into this host element
        // or we need to update the css class/attrs on the host element
        // if we haven't already created a vnode, then we give the renderer the actual element
        // if this is a re-render, then give the renderer the last vnode we already created
        var l = n._$vnodeMap$_.get(e) || {};
        l._$elm$_ = f;
        var p = h(null, a, s);
        // each patch always gets a new vnode
        // the host element itself isn't patched because it already exists
        // kick off the actual render and any DOM updates
        n._$vnodeMap$_.set(e, n.render(e, l, p, u, i));
      }
      // update styles!
            n._$customStyle$_ && n._$customStyle$_._$updateHost$_(e), 
      // it's official, this element has rendered
      e["s-rn"] = !0, e.$onRender && (
      // $onRender deprecated 2018-04-02
      e["s-rc"] = e.$onRender), e["s-rc"] && (
      // ok, so turns out there are some child host elements
      // waiting on this parent element to load
      // let's fire off all update callbacks waiting
      e["s-rc"].forEach(function(n) {
        return n();
      }), e["s-rc"] = null);
    } catch (t) {
      n._$activeRender$_ = !1, n._$onError$_(t, 8 /* RenderError */ , e, !0);
    }
  })(n, n._$getComponentMeta$_(t), t, e);
  try {
    r ? 
    // so this was the initial load i guess
    t["s-init"]() : (
    // fire off the user's componentDidUpdate method (if one was provided)
    // componentDidUpdate runs AFTER render() has been called
    // but only AFTER an UPDATE and not after the intial render
    e.componentDidUpdate && e.componentDidUpdate(), callNodeRefs(n._$vnodeMap$_.get(t)));
  } catch (e) {
    // derp
    n._$onError$_(e, 6 /* DidUpdateError */ , t, !0);
  }
}

function defineMember(n, t, e, r, o, i, u, f) {
  if (t.type || t.state) {
    var c = n._$valuesMap$_.get(e);
    t.state || (!t.attr || void 0 !== c[o] && "" !== c[o] || 
    // check the prop value from the host element attribute
    (u = i && i._$$attributes$_) && g(f = u[t.attr]) && (
    // looks like we've got an attribute value
    // let's set it to our internal values
    c[o] = parsePropertyValue(t.type, f)), 
    // client-side
    // within the browser, the element's prototype
    // already has its getter/setter set, but on the
    // server the prototype is shared causing issues
    // so instead the server's elm has the getter/setter
    // directly on the actual element instance, not its prototype
    // so on the browser we can use "hasOwnProperty"
    e.hasOwnProperty(o) && (
    // @Prop or @Prop({mutable:true})
    // property values on the host element should override
    // any default values on the component instance
    void 0 === c[o] && (c[o] = parsePropertyValue(t.type, e[o])), 
    // for the client only, let's delete its "own" property
    // this way our already assigned getter/setter on the prototype kicks in
    // the very special case is to NOT do this for "mode"
    "mode" !== o && delete e[o])), r.hasOwnProperty(o) && void 0 === c[o] && (
    // @Prop() or @Prop({mutable:true}) or @State()
    // we haven't yet got a value from the above checks so let's
    // read any "own" property instance values already set
    // to our internal value as the source of getter data
    // we're about to define a property and it'll overwrite this "own" property
    c[o] = r[o]), t.watchCallbacks && (c[P + o] = t.watchCallbacks.slice()), 
    // add getter/setter to the component instance
    // these will be pointed to the internal data set from the above checks
    definePropertyGetterSetter(r, o, function getComponentProp(t) {
      // component instance prop/state getter
      // get the property value directly from our internal values
      return (t = n._$valuesMap$_.get(n._$hostElementMap$_.get(this))) && t[o];
    }, function setComponentProp(e, r) {
      // component instance prop/state setter (cannot be arrow fn)
      (r = n._$hostElementMap$_.get(this)) && (t.state || t.mutable) && setValue(n, r, o, e);
    });
  } else t.elementRef ? 
  // @Element()
  // add a getter to the element reference using
  // the member name the component meta provided
  definePropertyValue(r, o, e) : t.method && 
  // @Method()
  // add a property "value" on the host element
  // which we'll bind to the instance's method
  definePropertyValue(e, o, r[o].bind(r));
}

function setValue(n, t, e, r, o, i, u) {
  (
  // get the internal values object, which should always come from the host element instance
  // create the _values object if it doesn't already exist
  o = n._$valuesMap$_.get(t)) || n._$valuesMap$_.set(t, o = {});
  var f = o[e];
  // check our new property value against our internal value
    if (r !== f && (
  // gadzooks! the property's value has changed!!
  // set our new value!
  // https://youtu.be/dFtLONl4cNc?t=22
  o[e] = r, i = n._$instanceMap$_.get(t))) {
    if (
    // get an array of method names of watch functions to call
    u = o[P + e]) 
    // this instance is watching for when this property changed
    for (var c = 0; c < u.length; c++) try {
      // fire off each of the watch methods that are watching this property
      i[u[c]].call(i, r, f, e);
    } catch (n) {
      console.error(n);
    }
    !n._$activeRender$_ && t["s-rn"] && 
    // looks like this value actually changed, so we've got work to do!
    // but only if we've already rendered, otherwise just chill out
    // queue that we need to do an update, but don't worry about queuing
    // up millions cuz this function ensures it only runs once
    queueUpdate(n, t);
  }
}

function definePropertyValue(n, t, e) {
  // minification shortcut
  Object.defineProperty(n, t, {
    configurable: !0,
    value: e
  });
}

function definePropertyGetterSetter(n, t, e, r) {
  // minification shortcut
  Object.defineProperty(n, t, {
    configurable: !0,
    get: e,
    set: r
  });
}

function setAccessor(n, t, e, r, o, i, u) {
  if ("class" !== e || i) if ("style" === e) {
    // update style attribute, css properties and values
    for (var f in r) o && null != o[f] || (/-/.test(f) ? t.style._$removeProperty$_(f) : t.style[f] = "");
    for (var f in o) r && o[f] === r[f] || (/-/.test(f) ? t.style.setProperty(f, o[f]) : t.style[f] = o[f]);
  } else if ("o" !== e[0] || "n" !== e[1] || !/[A-Z]/.test(e[2]) || e in t) if ("list" !== e && "type" !== e && !i && (e in t || -1 !== [ "object", "function" ].indexOf(typeof o) && null !== o)) {
    // Properties
    // - list and type are attributes that get applied as values on the element
    // - all svgs get values as attributes not props
    // - check if elm contains name or if the value is array, object, or function
    var c = n._$getComponentMeta$_(t);
    c && c._$membersMeta$_ && c._$membersMeta$_[e] ? 
    // we know for a fact that this element is a known component
    // and this component has this member name as a property,
    // let's set the known @Prop on this element
    // set it directly as property on the element
    setProperty(t, e, o) : "ref" !== e && (
    // this member name is a property on this element, but it's not a component
    // this is a native property like "value" or something
    // also we can ignore the "ref" member name at this point
    setProperty(t, e, null == o ? "" : o), null != o && !1 !== o || n._$domApi$_._$$removeAttribute$_(t, e));
  } else null != o && "key" !== e ? 
  // Element Attributes
  function updateAttribute(n, t, e, r) {
    void 0 === r && (r = "boolean" == typeof e);
    var o = t !== (t = t.replace(/^xlink\:?/, ""));
    null == e || r && (!e || "false" === e) ? o ? n.removeAttributeNS(k, C(t)) : n.removeAttribute(t) : "function" != typeof e && (e = r ? "" : e.toString(), 
    o ? n.setAttributeNS(k, C(t), e) : n.setAttribute(t, e));
  }(t, e, o) : (i || n._$domApi$_._$$hasAttribute$_(t, e) && (null == o || !1 === o)) && 
  // remove svg attribute
  n._$domApi$_._$$removeAttribute$_(t, e); else 
  // Event Handlers
  // so if the member name starts with "on" and the 3rd characters is
  // a capital letter, and it's not already a member on the element,
  // then we're assuming it's an event listener
  // standard event
  // the JSX attribute could have been "onMouseOver" and the
  // member name "onmouseover" is on the element's prototype
  // so let's add the listener "mouseover", which is all lowercased
  e = C(e) in t ? C(e.substring(2)) : C(e[2]) + e.substring(3), o ? o !== r && 
  // add listener
  n._$domApi$_._$$addEventListener$_(t, e, o) : 
  // remove listener
  n._$domApi$_._$$removeEventListener$_(t, e); else 
  // Class
  if (r !== o) {
    var a = parseClassList(r), s = parseClassList(o), l = a.filter(function(n) {
      return !s.includes(n);
    }), p = parseClassList(t.className).filter(function(n) {
      return !l.includes(n);
    }), d = s.filter(function(n) {
      return !a.includes(n) && !p.includes(n);
    });
    p.push.apply(p, d), t.className = p.join(" ");
  }
}

function parseClassList(n) {
  return null == n || "" === n ? [] : n.trim().split(/\s+/);
}

/**
 * Attempt to set a DOM property to the given value.
 * IE & FF throw for certain property-value combinations.
 */ function setProperty(n, t, e) {
  try {
    n[t] = e;
  } catch (n) {}
}

function updateElement(n, t, e, r, o) {
  // if the element passed in is a shadow root, which is a document fragment
  // then we want to be adding attrs/props to the shadow root's "host" element
  // if it's not a shadow root, then we add attrs/props to the same element
  var i = 11 /* DocumentFragment */ === e._$elm$_.nodeType && e._$elm$_.host ? e._$elm$_.host : e._$elm$_, u = t && t.vattrs || m, f = e.vattrs || m;
  // remove attributes no longer present on the vnode by setting them to undefined
  for (o in u) f && null != f[o] || null == u[o] || setAccessor(n, i, o, u[o], void 0, r, e._$ishost$_);
  // add new & update changed attributes
    for (o in f) o in u && f[o] === ("value" === o || "checked" === o ? i[o] : u[o]) || setAccessor(n, i, o, u[o], f[o], r, e._$ishost$_);
}

function createRendererPatch(n, t) {
  // createRenderer() is only created once per app
  // the patch() function which createRenderer() returned is the function
  // which gets called numerous times by each component
  function createElm(o, c, a, s, l, p, d, v, h) {
    if (v = c.vchildren[a], e || (
    // remember for later we need to check to relocate nodes
    i = !0, "slot" === v.vtag && (r && 
    // scoped css needs to add its scoped id to the parent element
    t._$$addClass$_(s, r + "-s"), v.vchildren ? 
    // slot element has fallback content
    // still create an element that "mocks" the slot element
    v._$isSlotFallback$_ = !0 : 
    // slot element does not have fallback content
    // create an html comment we'll use to always reference
    // where actual slot content should sit next to
    v._$isSlotReference$_ = !0)), g(v.vtext)) 
    // create text node
    v._$elm$_ = t._$$createTextNode$_(v.vtext); else if (v._$isSlotReference$_) 
    // create a slot reference html text node
    v._$elm$_ = t._$$createTextNode$_(""); else {
      if (
      // create element
      p = v._$elm$_ = N || "svg" === v.vtag ? t._$$createElementNS$_("http://www.w3.org/2000/svg", v.vtag) : t._$$createElement$_(v._$isSlotFallback$_ ? "slot-fb" : v.vtag), 
      N = "svg" === v.vtag || "foreignObject" !== v.vtag && N, 
      // add css classes, attrs, props, listeners, etc.
      updateElement(n, null, v, N), g(r) && p["s-si"] !== r && 
      // if there is a scopeId and this is the initial render
      // then let's add the scopeId as an attribute
      t._$$addClass$_(p, p["s-si"] = r), v.vchildren) for (l = 0; l < v.vchildren.length; ++l) 
      // create the node
      // return node could have been null
      (d = createElm(o, v, l, p)) && 
      // append our new node
      t._$$appendChild$_(p, d);
      "svg" === v.vtag && (
      // Only reset the SVG context when we're exiting SVG element
      N = !1);
    }
    return v._$elm$_["s-hn"] = u, (v._$isSlotFallback$_ || v._$isSlotReference$_) && (
    // remember the content reference comment
    v._$elm$_["s-sr"] = !0, 
    // remember the content reference comment
    v._$elm$_["s-cr"] = f, 
    // remember the slot name, or empty string for default slot
    v._$elm$_["s-sn"] = v.vname || "", (
    // check if we've got an old vnode for this slot
    h = o && o.vchildren && o.vchildren[a]) && h.vtag === v.vtag && o._$elm$_ && 
    // we've got an old slot vnode and the wrapper is being replaced
    // so let's move the old slot content back to it's original location
    putBackInOriginalLocation(o._$elm$_)), v._$elm$_;
  }
  function putBackInOriginalLocation(e, r, o, f) {
    n._$tmpDisconnected$_ = !0;
    var c = t._$$childNodes$_(e);
    for (o = c.length - 1; o >= 0; o--) (f = c[o])["s-hn"] !== u && f["s-ol"] && (
    // this child node in the old element is from another component
    // remove this node from the old slot's parent
    t._$$remove$_(f), 
    // and relocate it back to it's original location
    t._$$insertBefore$_(parentReferenceNode(f), f, referenceNode(f)), 
    // remove the old original location comment entirely
    // later on the patch function will know what to do
    // and move this to the correct spot in need be
    t._$$remove$_(f["s-ol"]), f["s-ol"] = null, i = !0), r && putBackInOriginalLocation(f, r);
    n._$tmpDisconnected$_ = !1;
  }
  function addVnodes(n, e, r, o, i, f, c, a) {
    // $defaultHolder deprecated 2018-04-02
    var s = n["s-cr"] || n.$defaultHolder;
    for ((c = s && t._$$parentNode$_(s) || n).shadowRoot && t._$$tagName$_(c) === u && (c = c.shadowRoot); i <= f; ++i) o[i] && (a = g(o[i].vtext) ? t._$$createTextNode$_(o[i].vtext) : createElm(null, r, i, n)) && (o[i]._$elm$_ = a, 
    t._$$insertBefore$_(c, a, referenceNode(e)));
  }
  function removeVnodes(n, e, r, i) {
    for (;e <= r; ++e) g(n[e]) && (i = n[e]._$elm$_, 
    // we're removing this element
    // so it's possible we need to show slot fallback content now
    o = !0, i["s-ol"] ? 
    // remove the original location comment
    t._$$remove$_(i["s-ol"]) : 
    // it's possible that child nodes of the node
    // that's being removed are slot nodes
    putBackInOriginalLocation(i, !0), 
    // remove the vnode's element from the dom
    t._$$remove$_(i));
  }
  function isSameVnode(n, t) {
    // compare if two vnode to see if they're "technically" the same
    // need to have the same element tag, and same key to be the same
    return n.vtag === t.vtag && n.vkey === t.vkey && ("slot" !== n.vtag || n.vname === t.vname);
  }
  function referenceNode(n) {
    return n && n["s-ol"] ? n["s-ol"] : n;
  }
  function parentReferenceNode(n) {
    return t._$$parentNode$_(n["s-ol"] ? n["s-ol"] : n);
  }
  var e, r, o, i, u, f, c = [];
  return function patch(a, s, l, p, d, v, h, y, m, b, C, w) {
    if (
    // patchVNode() is synchronous
    // so it is safe to set these variables and internally
    // the same patch() call will reference the same data
    u = t._$$tagName$_(a), f = a["s-cr"], e = p, 
    // get the scopeId
    r = a["s-sc"], 
    // always reset
    i = o = !1, 
    // synchronous patch
    function patchVNode(e, r, o) {
      var i = r._$elm$_ = e._$elm$_, u = e.vchildren, f = r.vchildren;
      // test if we're rendering an svg element, or still rendering nodes inside of one
      // only add this to the when the compiler sees we're using an svg somewhere
      N = r._$elm$_ && g(t._$$parentElement$_(r._$elm$_)) && void 0 !== r._$elm$_.ownerSVGElement, 
      N = "svg" === r.vtag || "foreignObject" !== r.vtag && N, g(r.vtext) ? (o = i["s-cr"] || i.$defaultHolder /* $defaultHolder deprecated 2018-04-02 */) ? 
      // this element has slotted content
      t._$$setTextContent$_(t._$$parentNode$_(o), r.vtext) : e.vtext !== r.vtext && 
      // update the text content for the text only vnode
      // and also only if the text is different than before
      t._$$setTextContent$_(i, r.vtext) : (
      // element node
      "slot" !== r.vtag && 
      // either this is the first render of an element OR it's an update
      // AND we already know it's possible it could have changed
      // this updates the element's css classes, attrs, props, listeners, etc.
      updateElement(n, e, r, N), g(u) && g(f) ? 
      // looks like there's child vnodes for both the old and new vnodes
      function updateChildren(n, e, r, o, i, u, f, c) {
        for (var a = 0, s = 0, l = e.length - 1, p = e[0], d = e[l], v = o.length - 1, h = o[0], y = o[v]; a <= l && s <= v; ) if (null == p) 
        // Vnode might have been moved left
        p = e[++a]; else if (null == d) d = e[--l]; else if (null == h) h = o[++s]; else if (null == y) y = o[--v]; else if (isSameVnode(p, h)) patchVNode(p, h), 
        p = e[++a], h = o[++s]; else if (isSameVnode(d, y)) patchVNode(d, y), d = e[--l], 
        y = o[--v]; else if (isSameVnode(p, y)) 
        // Vnode moved right
        "slot" !== p.vtag && "slot" !== y.vtag || putBackInOriginalLocation(t._$$parentNode$_(p._$elm$_)), 
        patchVNode(p, y), t._$$insertBefore$_(n, p._$elm$_, t._$$nextSibling$_(d._$elm$_)), 
        p = e[++a], y = o[--v]; else if (isSameVnode(d, h)) 
        // Vnode moved left
        "slot" !== p.vtag && "slot" !== y.vtag || putBackInOriginalLocation(t._$$parentNode$_(d._$elm$_)), 
        patchVNode(d, h), t._$$insertBefore$_(n, d._$elm$_, p._$elm$_), d = e[--l], h = o[++s]; else {
          for (
          // createKeyToOldIdx
          i = null, u = a; u <= l; ++u) if (e[u] && g(e[u].vkey) && e[u].vkey === h.vkey) {
            i = u;
            break;
          }
          g(i) ? ((c = e[i]).vtag !== h.vtag ? f = createElm(e && e[s], r, i, n) : (patchVNode(c, h), 
          e[i] = void 0, f = c._$elm$_), h = o[++s]) : (
          // new element
          f = createElm(e && e[s], r, s, n), h = o[++s]), f && t._$$insertBefore$_(parentReferenceNode(p._$elm$_), f, referenceNode(p._$elm$_));
        }
        a > l ? addVnodes(n, null == o[v + 1] ? null : o[v + 1]._$elm$_, r, o, s, v) : s > v && removeVnodes(e, a, l);
      }(i, u, r, f) : g(f) ? (
      // no old child vnodes, but there are new child vnodes to add
      g(e.vtext) && 
      // the old vnode was text, so be sure to clear it out
      t._$$setTextContent$_(i, ""), 
      // add the new vnode children
      addVnodes(i, null, r, f, 0, f.length - 1)) : g(u) && 
      // no new child vnodes, but there are old child vnodes to remove
      removeVnodes(u, 0, u.length - 1)), 
      // reset svgMode when svg node is fully patched
      N && "svg" === r.vtag && (N = !1);
    }(s, l), i) {
      for (function relocateSlotContent(n, e, r, i, u, f, a, s, l, p) {
        for (u = 0, f = (e = t._$$childNodes$_(n)).length; u < f; u++) {
          if ((r = e[u])["s-sr"] && (i = r["s-cr"])) for (
          // first got the content reference comment node
          // then we got it's parent, which is where all the host content is in now
          s = t._$$childNodes$_(t._$$parentNode$_(i)), l = r["s-sn"], a = s.length - 1; a >= 0; a--) (i = s[a])["s-cn"] || i["s-nr"] || i["s-hn"] === r["s-hn"] || ((3 /* TextNode */ === (
          // let's do some relocating to its new home
          // but never relocate a content reference node
          // that is suppose to always represent the original content location
          p = t._$$nodeType$_(i)) || 8 /* CommentNode */ === p) && "" === l || 1 /* ElementNode */ === p && null === t._$$getAttribute$_(i, "slot") && "" === l || 1 /* ElementNode */ === p && t._$$getAttribute$_(i, "slot") === l) && (
          // it's possible we've already decided to relocate this node
          c.some(function(n) {
            return n._$nodeToRelocate$_ === i;
          }) || (
          // made some changes to slots
          // let's make sure we also double check
          // fallbacks are correctly hidden or shown
          o = !0, i["s-sn"] = l, 
          // add to our list of nodes to relocate
          c.push({
            _$slotRefNode$_: r,
            _$nodeToRelocate$_: i
          })));
          1 /* ElementNode */ === t._$$nodeType$_(r) && relocateSlotContent(r);
        }
      }
      // internal variables to be reused per patch() call
      (l._$elm$_), h = 0; h < c.length; h++) (y = c[h])._$nodeToRelocate$_["s-ol"] || (
      // add a reference node marking this node's original location
      // keep a reference to this node for later lookups
      (m = t._$$createTextNode$_(""))["s-nr"] = y._$nodeToRelocate$_, t._$$insertBefore$_(t._$$parentNode$_(y._$nodeToRelocate$_), y._$nodeToRelocate$_["s-ol"] = m, y._$nodeToRelocate$_));
      // while we're moving nodes around existing nodes, temporarily disable
      // the disconnectCallback from working
            for (n._$tmpDisconnected$_ = !0, h = 0; h < c.length; h++) {
        for (y = c[h], 
        // by default we're just going to insert it directly
        // after the slot reference node
        C = t._$$parentNode$_(y._$slotRefNode$_), w = t._$$nextSibling$_(y._$slotRefNode$_), 
        m = y._$nodeToRelocate$_["s-ol"]; m = t._$$previousSibling$_(m); ) if ((b = m["s-nr"]) && b && b["s-sn"] === y._$nodeToRelocate$_["s-sn"] && C === t._$$parentNode$_(b) && (b = t._$$nextSibling$_(b)) && b && !b["s-nr"]) {
          w = b;
          break;
        }
        (!w && C !== t._$$parentNode$_(y._$nodeToRelocate$_) || t._$$nextSibling$_(y._$nodeToRelocate$_) !== w) && y._$nodeToRelocate$_ !== w && (
        // remove the node from the dom
        t._$$remove$_(y._$nodeToRelocate$_), 
        // add it back to the dom but in its new home
        t._$$insertBefore$_(C, y._$nodeToRelocate$_, w));
      }
      // done moving nodes around
      // allow the disconnect callback to work again
            n._$tmpDisconnected$_ = !1;
    }
    // return our new vnode
    return o && function updateFallbackSlotVisibility(n, e, r, o, i, u, f, c) {
      for (o = 0, i = (r = t._$$childNodes$_(n)).length; o < i; o++) if (e = r[o], 1 /* ElementNode */ === t._$$nodeType$_(e)) {
        if (e["s-sr"]) for (
        // this is a slot fallback node
        // get the slot name for this slot reference node
        f = e["s-sn"], 
        // by default always show a fallback slot node
        // then hide it if there are other slots in the light dom
        e.hidden = !1, u = 0; u < i; u++) if (r[u]["s-hn"] !== e["s-hn"]) if (
        // this sibling node is from a different component
        c = t._$$nodeType$_(r[u]), "" !== f) {
          // this is a named fallback slot node
          if (1 /* ElementNode */ === c && f === t._$$getAttribute$_(r[u], "slot")) {
            e.hidden = !0;
            break;
          }
        } else 
        // this is a default fallback slot node
        // any element or text node (with content)
        // should hide the default fallback slot node
        if (1 /* ElementNode */ === c || 3 /* TextNode */ === c && "" !== t._$$getTextContent$_(r[u]).trim()) {
          e.hidden = !0;
          break;
        }
        // keep drilling down
                updateFallbackSlotVisibility(e);
      }
    }(l._$elm$_), 
    // always reset
    c.length = 0, l;
  };
}

function callNodeRefs(n, t) {
  n && (n.vattrs && n.vattrs.ref && n.vattrs.ref(t ? null : n._$elm$_), n.vchildren && n.vchildren.forEach(function(n) {
    callNodeRefs(n, t);
  }));
}

function initHostElement(n, t, e, r) {
  // let's wire up our functions to the host element's prototype
  // we can also inject our platform into each one that needs that api
  // note: these cannot be arrow functions cuz "this" is important here hombre
  e.connectedCallback = function() {
    // coolsville, our host element has just hit the DOM
    (function connectedCallback(n, t, e) {
      // initialize our event listeners on the host element
      // we do this now so that we can listening to events that may
      // have fired even before the instance is ready
      n._$hasListenersMap$_.has(e) || (
      // it's possible we've already connected
      // then disconnected
      // and the same element is reconnected again
      n._$hasListenersMap$_.set(e, !0), function initElementListeners(n, t) {
        // so the element was just connected, which means it's in the DOM
        // however, the component instance hasn't been created yet
        // but what if an event it should be listening to get emitted right now??
        // let's add our listeners right now to our element, and if it happens
        // to receive events between now and the instance being created let's
        // queue up all of the event data and fire it off on the instance when it's ready
        var e = n._$getComponentMeta$_(t);
        e._$listenersMeta$_ && 
        // we've got listens
        e._$listenersMeta$_.forEach(function(e) {
          // go through each listener
          e._$eventDisabled$_ || 
          // only add ones that are not already disabled
          n._$domApi$_._$$addEventListener$_(t, e._$eventName$_, function createListenerCallback(n, t, e, r) {
            // create the function that gets called when the element receives
            // an event which it should be listening for
            return function(o) {
              // get the instance if it exists
              (r = n._$instanceMap$_.get(t)) ? 
              // instance is ready, let's call it's member method for this event
              r[e](o) : (
              // instance is not ready!!
              // let's queue up this event data and replay it later
              // when the instance is ready
              (r = n._$queuedEvents$_.get(t) || []).push(e, o), n._$queuedEvents$_.set(t, r));
            };
          }(n, t, e._$eventMethodName$_), e._$eventCapture$_, e._$eventPassive$_);
        });
      }(n, e)), 
      // this element just connected, which may be re-connecting
      // ensure we remove it from our map of disconnected
      n._$isDisconnectedMap$_.delete(e), n._$hasConnectedMap$_.has(e) || (
      // first time we've connected
      n._$hasConnectedMap$_.set(e, !0), e["s-id"] || (
      // assign a unique id to this host element
      // it's possible this was already given an element id
      e["s-id"] = n._$nextId$_()), 
      // register this component as an actively
      // loading child to its parent component
      function registerWithParentComponent(n, t, e) {
        for (
        // find the first ancestor host element (if there is one) and register
        // this element as one of the actively loading child elements for its ancestor
        e = t; e = n._$domApi$_._$$parentElement$_(e); ) 
        // climb up the ancestors looking for the first registered component
        if (n._$isDefinedComponent$_(e)) {
          // we found this elements the first ancestor host element
          // if the ancestor already loaded then do nothing, it's too late
          n._$hasLoadedMap$_.has(t) || (
          // keep a reference to this element's ancestor host element
          // elm._ancestorHostElement = ancestorHostElement;
          n._$ancestorHostElementMap$_.set(t, e), 
          // ensure there is an array to contain a reference to each of the child elements
          // and set this element as one of the ancestor's child elements it should wait on
          e.$activeLoading && (
          // $activeLoading deprecated 2018-04-02
          e["s-ld"] = e.$activeLoading), (e["s-ld"] = e["s-ld"] || []).push(t));
          break;
        }
      }(n, e), 
      // add to the queue to load the bundle
      // it's important to have an async tick in here so we can
      // ensure the "mode" attribute has been added to the element
      // place in high priority since it's not much work and we need
      // to know as fast as possible, but still an async tick in between
      n.queue.tick(function() {
        // start loading this component mode's bundle
        // if it's already loaded then the callback will be synchronous
        n._$hostSnapshotMap$_.set(e, function initHostSnapshot(n, t, e, r, o) {
          // the host element has connected to the dom
          // and we've waited a tick to make sure all frameworks
          // have finished adding attributes and child nodes to the host
          // before we go all out and hydrate this beast
          // let's first take a snapshot of its original layout before render
          return e.mode || (
          // looks like mode wasn't set as a property directly yet
          // first check if there's an attribute
          // next check the app's global
          e.mode = n._$$getMode$_(e)), 
          // if the slot polyfill is required we'll need to put some nodes
          // in here to act as original content anchors as we move nodes around
          // host element has been connected to the DOM
          e["s-cr"] || n._$$getAttribute$_(e, d) || n._$$supportsShadowDom$_ && 1 /* ShadowDom */ === t._$encapsulationMeta$_ || (
          // only required when we're NOT using native shadow dom (slot)
          // or this browser doesn't support native shadow dom
          // and this host element was NOT created with SSR
          // let's pick out the inner content for slot projection
          // create a node to represent where the original
          // content was first placed, which is useful later on
          e["s-cr"] = n._$$createTextNode$_(""), e["s-cr"]["s-cn"] = !0, n._$$insertBefore$_(e, e["s-cr"], n._$$childNodes$_(e)[0])), 
          n._$$supportsShadowDom$_ || 1 /* ShadowDom */ !== t._$encapsulationMeta$_ || (e.shadowRoot = e), 
          // create a host snapshot object we'll
          // use to store all host data about to be read later
          r = {
            _$$id$_: e["s-id"],
            _$$attributes$_: {}
          }, 
          // loop through and gather up all the original attributes on the host
          // this is useful later when we're creating the component instance
          t._$membersMeta$_ && Object.keys(t._$membersMeta$_).forEach(function(i) {
            (o = t._$membersMeta$_[i]._$attribName$_) && (r._$$attributes$_[o] = n._$$getAttribute$_(e, o));
          }), r;
        }(n._$domApi$_, t, e)), n._$requestBundle$_(t, e);
      }));
    })(n, t, this);
  }, e.attributeChangedCallback = function(n, e, r) {
    // the browser has just informed us that an attribute
    // on the host element has changed
    (function attributeChangedCallback(n, t, e, r, o, i, u) {
      // only react if the attribute values actually changed
      if (n && r !== o) 
      // using the known component meta data
      // look up to see if we have a property wired up to this attribute name
      for (i in n) 
      // normalize the attribute name w/ lower case
      if ((u = n[i])._$attribName$_ && C(u._$attribName$_) === C(e)) {
        // cool we've got a prop using this attribute name, the value will
        // be a string, so let's convert it to the correct type the app wants
        t[i] = parsePropertyValue(u._$propType$_, o);
        break;
      }
    })(t._$membersMeta$_, this, n, e, r);
  }, e.disconnectedCallback = function() {
    // the element has left the builing
    (function disconnectedCallback(n, t) {
      // only disconnect if we're not temporarily disconnected
      // tmpDisconnected will happen when slot nodes are being relocated
      if (!n._$tmpDisconnected$_ && function isDisconnected(n, t) {
        for (;t; ) {
          if (!n._$$parentNode$_(t)) return 9 /* DocumentNode */ !== n._$$nodeType$_(t);
          t = n._$$parentNode$_(t);
        }
      }(n._$domApi$_, t)) {
        // ok, let's officially destroy this thing
        // set this to true so that any of our pending async stuff
        // doesn't continue since we already decided to destroy this node
        // elm._hasDestroyed = true;
        n._$isDisconnectedMap$_.set(t, !0), 
        // double check that we've informed the ancestor host elements
        // that they're good to go and loaded (cuz this one is on its way out)
        propagateComponentLoaded(n, t), 
        // since we're disconnecting, call all of the JSX ref's with null
        callNodeRefs(n._$vnodeMap$_.get(t), !0), 
        // detatch any event listeners that may have been added
        // because we're not passing an exact event name it'll
        // remove all of this element's event, which is good
        n._$domApi$_._$$removeEventListener$_(t), n._$hasListenersMap$_.delete(t);
        // call instance componentDidUnload
        // if we've created an instance for this
        var e = n._$instanceMap$_.get(t);
        e && 
        // call the user's componentDidUnload if there is one
        e.componentDidUnload && e.componentDidUnload(), 
        // clear CSS var-shim tracking
        n._$customStyle$_ && n._$customStyle$_._$removeHost$_(t), 
        // clear any references to other elements
        // more than likely we've already deleted these references
        // but let's double check there pal
        [ n._$ancestorHostElementMap$_, n._$onReadyCallbacksMap$_, n._$hostSnapshotMap$_ ].forEach(function(n) {
          return n.delete(t);
        });
      }
    })(n, this);
  }, e["s-init"] = function() {
    (function initComponentLoaded(n, t, e, r, o) {
      // all is good, this component has been told it's time to finish loading
      // it's possible that we've already decided to destroy this element
      // check if this element has any actively loading child elements
      if (!n._$hasLoadedMap$_.has(t) && (r = n._$instanceMap$_.get(t)) && !n._$isDisconnectedMap$_.has(t) && (!t["s-ld"] || !t["s-ld"].length)) {
        // cool, so at this point this element isn't already being destroyed
        // and it does not have any child elements that are still loading
        // ensure we remove any child references cuz it doesn't matter at this point
        delete t["s-ld"], 
        // sweet, this particular element is good to go
        // all of this element's children have loaded (if any)
        // elm._hasLoaded = true;
        n._$hasLoadedMap$_.set(t, !0);
        try {
          // fire off the ref if it exists
          callNodeRefs(n._$vnodeMap$_.get(t)), 
          // fire off the user's elm.componentOnReady() callbacks that were
          // put directly on the element (well before anything was ready)
          (o = n._$onReadyCallbacksMap$_.get(t)) && (o.forEach(function(n) {
            return n(t);
          }), n._$onReadyCallbacksMap$_.delete(t)), 
          // fire off the user's componentDidLoad method (if one was provided)
          // componentDidLoad only runs ONCE, after the instance's element has been
          // assigned as the host element, and AFTER render() has been called
          // we'll also fire this method off on the element, just to
          r.componentDidLoad && r.componentDidLoad();
        } catch (e) {
          n._$onError$_(e, 4 /* DidLoadError */ , t);
        }
        // add the css class that this element has officially hydrated
                n._$domApi$_._$$addClass$_(t, e), 
        // ( •_•)
        // ( •_•)>⌐■-■
        // (⌐■_■)
        // load events fire from bottom to top
        // the deepest elements load first then bubbles up
        propagateComponentLoaded(n, t);
      }
    })(n, this, r);
  }, e.forceUpdate = function() {
    queueUpdate(n, this);
  }, 
  // add getters/setters to the host element members
  // these would come from the @Prop and @Method decorators that
  // should create the public API to this component
  function proxyHostElementPrototype(n, t, e) {
    t && Object.keys(t).forEach(function(r) {
      // add getters/setters
      var o = t[r], i = o._$memberType$_;
      1 /* Prop */ === i || 2 /* PropMutable */ === i ? 
      // @Prop() or @Prop({ mutable: true })
      definePropertyGetterSetter(e, r, function getHostElementProp() {
        // host element getter (cannot be arrow fn)
        // yup, ugly, srynotsry
        return (n._$valuesMap$_.get(this) || {})[r];
      }, function setHostElementProp(t) {
        // host element setter (cannot be arrow fn)
        setValue(n, this, r, parsePropertyValue(o._$propType$_, t));
      }) : 6 /* Method */ === i && 
      // @Method()
      // add a placeholder noop value on the host element's prototype
      // incase this method gets called before setup
      definePropertyValue(e, r, w);
    });
  }(n, t._$membersMeta$_, e);
}

function proxyProp(n, t, e, r) {
  return function() {
    var o = arguments;
    return function loadComponent(n, t, e) {
      var r = t[e], o = n._$$doc$_.body;
      return o ? (r || (r = o.querySelector(e)), r || (r = t[e] = n._$$createElement$_(e), 
      n._$$appendChild$_(o, r)), r.componentOnReady()) : Promise.resolve();
    }(n, t, e).then(function(n) {
      return n[r].apply(n, o);
    });
  };
}

function createPlatformMain(n, t, e, r, o, i) {
  var u = {
    html: {}
  }, f = {}, c = e[n] = e[n] || {}, a = function createDomApi(n, t, e) {
    // using the $ prefix so that closure is
    // cool with property renaming each of these
    n.ael || (n.ael = function(n, t, e, r) {
      return n.addEventListener(t, e, r);
    }, n.rel = function(n, t, e, r) {
      return n.removeEventListener(t, e, r);
    });
    var r = new WeakMap(), o = {
      _$$doc$_: e,
      _$$supportsEventOptions$_: !1,
      _$$nodeType$_: function(n) {
        return n.nodeType;
      },
      _$$createElement$_: function(n) {
        return e.createElement(n);
      },
      _$$createElementNS$_: function(n, t) {
        return e.createElementNS(n, t);
      },
      _$$createTextNode$_: function(n) {
        return e.createTextNode(n);
      },
      _$$createComment$_: function(n) {
        return e.createComment(n);
      },
      _$$insertBefore$_: function(n, t, e) {
        return n.insertBefore(t, e);
      },
      // https://developer.mozilla.org/en-US/docs/Web/API/ChildNode/remove
      // and it's polyfilled in es5 builds
      _$$remove$_: function(n) {
        return n.remove();
      },
      _$$appendChild$_: function(n, t) {
        return n.appendChild(t);
      },
      _$$addClass$_: function(n, t) {
        return n.classList.add(t);
      },
      _$$childNodes$_: function(n) {
        return n.childNodes;
      },
      _$$parentNode$_: function(n) {
        return n.parentNode;
      },
      _$$nextSibling$_: function(n) {
        return n.nextSibling;
      },
      _$$previousSibling$_: function(n) {
        return n.previousSibling;
      },
      _$$tagName$_: function(n) {
        return C(n.nodeName);
      },
      _$$getTextContent$_: function(n) {
        return n.textContent;
      },
      _$$setTextContent$_: function(n, t) {
        return n.textContent = t;
      },
      _$$getAttribute$_: function(n, t) {
        return n.getAttribute(t);
      },
      _$$setAttribute$_: function(n, t, e) {
        return n.setAttribute(t, e);
      },
      _$$setAttributeNS$_: function(n, t, e, r) {
        return n.setAttributeNS(t, e, r);
      },
      _$$removeAttribute$_: function(n, t) {
        return n.removeAttribute(t);
      },
      _$$hasAttribute$_: function(n, t) {
        return n.hasAttribute(t);
      },
      _$$getMode$_: function(t) {
        return t.getAttribute("mode") || (n.Context || {}).mode;
      },
      _$$elementRef$_: function(n, r) {
        return "child" === r ? n.firstElementChild : "parent" === r ? o._$$parentElement$_(n) : "body" === r ? e.body : "document" === r ? e : "window" === r ? t : n;
      },
      _$$addEventListener$_: function(t, e, i, u, f, c, a, s) {
        // remember the original name before we possibly change it
        var l = e, p = t, d = r.get(t);
        if (d && d[l] && 
        // removed any existing listeners for this event for the assigner element
        // this element already has this listener, so let's unregister it now
        d[l](), "string" == typeof c ? 
        // attachTo is a string, and is probably something like
        // "parent", "window", or "document"
        // and the eventName would be like "mouseover" or "mousemove"
        p = o._$$elementRef$_(t, c) : "object" == typeof c ? 
        // we were passed in an actual element to attach to
        p = c : (
        // depending on the event name, we could actually be attaching
        // this element to something like the document or window
        s = e.split(":")).length > 1 && (
        // document:mousemove
        // parent:touchend
        // body:keyup.enter
        p = o._$$elementRef$_(t, s[0]), e = s[1]), p) {
          var v = i;
          // test to see if we're looking for an exact keycode
                    (s = e.split(".")).length > 1 && (
          // looks like this listener is also looking for a keycode
          // keyup.enter
          e = s[0], v = function(n) {
            // wrap the user's event listener with our own check to test
            // if this keyboard event has the keycode they're looking for
            n.keyCode === b[s[1]] && i(n);
          }), 
          // create the actual event listener options to use
          // this browser may not support event options
          a = o._$$supportsEventOptions$_ ? {
            capture: !!u,
            passive: !!f
          } : !!u, 
          // ok, good to go, let's add the actual listener to the dom element
          n.ael(p, e, v, a), d || 
          // we don't already have a collection, let's create it
          r.set(t, d = {}), 
          // add the unregister listener to this element's collection
          d[l] = function() {
            // looks like it's time to say goodbye
            p && n.rel(p, e, v, a), d[l] = null;
          };
        }
      },
      _$$removeEventListener$_: function(n, t) {
        // get the unregister listener functions for this element
        var e = r.get(n);
        e && (
        // this element has unregister listeners
        t ? 
        // passed in one specific event name to remove
        e[t] && e[t]() : 
        // remove all event listeners
        Object.keys(e).forEach(function(n) {
          e[n] && e[n]();
        }));
      }
    };
    "function" != typeof t.CustomEvent && (
    // CustomEvent polyfill
    t.CustomEvent = function(n, t, r) {
      return (r = e.createEvent("CustomEvent")).initCustomEvent(n, t.bubbles, t.cancelable, t.detail), 
      r;
    }, t.CustomEvent.prototype = t.Event.prototype), o._$$dispatchEvent$_ = function(n, e, r) {
      return n && n.dispatchEvent(new t.CustomEvent(e, r));
    };
    // test if this browser supports event options or not
    try {
      t.addEventListener("e", null, Object.defineProperty({}, "passive", {
        get: function() {
          return o._$$supportsEventOptions$_ = !0;
        }
      }));
    } catch (n) {}
    return o._$$parentElement$_ = function(n, t) {
      // if the parent node is a document fragment (shadow root)
      // then use the "host" property on it
      // otherwise use the parent node
      return (t = o._$$parentNode$_(n)) && 11 /* DocumentFragment */ === o._$$nodeType$_(t) ? t.host : t;
    }, o;
  }(c, e, r);
  // set App Context
  t.isServer = t.isPrerender = !(t.isClient = !0), t.window = e, t.location = e.location, 
  t.document = r, t.resourcesUrl = t.publicPath = o, t.enableListener = function(n, t, e, r, o) {
    return function enableEventListener(n, t, e, r, o, i) {
      if (t) {
        // cool, we've got an instance, it's get the element it's on
        var u = n._$hostElementMap$_.get(t), f = n._$getComponentMeta$_(u);
        if (f && f._$listenersMeta$_) 
        // alrighty, so this cmp has listener meta
        if (r) {
          // we want to enable this event
          // find which listen meta we're talking about
          var c = f._$listenersMeta$_.find(function(n) {
            return n._$eventName$_ === e;
          });
          c && 
          // found the listen meta, so let's add the listener
          n._$domApi$_._$$addEventListener$_(u, e, function(n) {
            return t[c._$eventMethodName$_](n);
          }, c._$eventCapture$_, void 0 === i ? c._$eventPassive$_ : !!i, o);
        } else 
        // we're disabling the event listener
        // so let's just remove it entirely
        n._$domApi$_._$$removeEventListener$_(u, e);
      }
    }(p, n, t, e, r, o);
  }, t.emit = function(n, e, r) {
    return a._$$dispatchEvent$_(n, t.eventNameFn ? t.eventNameFn(e) : e, r);
  }, 
  // add the h() fn to the app's global namespace
  c.h = h, c.Context = t;
  // keep a global set of tags we've already defined
  // DEPRECATED $definedCmps 2018-05-22
  var s = e["s-defined"] = e.$definedCmps = e["s-defined"] || e.$definedCmps || {}, l = 0, p = {
    _$domApi$_: a,
    _$defineComponent$_: function defineComponent(n, t) {
      if (!e.customElements.get(n._$tagNameMeta$_)) {
        // define the custom element
        // initialize the members on the host element prototype
        // keep a ref to the metadata with the tag as the key
        initHostElement(p, u[n._$tagNameMeta$_] = n, t.prototype, i);
        // add which attributes should be observed
        var r = t.observedAttributes = [];
        // at this point the membersMeta only includes attributes which should
        // be observed, it does not include all props yet, so it's safe to
        // loop through all of the props (attrs) and observed them
                for (var o in n._$membersMeta$_) n._$membersMeta$_[o]._$attribName$_ && r.push(
        // add this attribute to our array of attributes we need to observe
        n._$membersMeta$_[o]._$attribName$_);
        e.customElements.define(n._$tagNameMeta$_, t);
      }
    },
    _$emitEvent$_: t.emit,
    _$getComponentMeta$_: function(n) {
      return u[a._$$tagName$_(n)];
    },
    _$getContextItem$_: function(n) {
      return t[n];
    },
    isClient: !0,
    _$isDefinedComponent$_: function(n) {
      return !(!s[a._$$tagName$_(n)] && !p._$getComponentMeta$_(n));
    },
    _$nextId$_: function() {
      return n + l++;
    },
    _$onError$_: function(n, t, e) {
      return console.error(n, t, e && e.tagName);
    },
    _$propConnect$_: function(n) {
      return function proxyController(n, t, e) {
        return {
          create: proxyProp(n, t, e, "create"),
          componentOnReady: proxyProp(n, t, e, "componentOnReady")
        };
      }(a, f, n);
    },
    queue: t.queue = function createQueueClient(n, t) {
      function consume(n) {
        for (var t = 0; t < n.length; t++) try {
          n[t](e());
        } catch (n) {
          console.error(n);
        }
        n.length = 0;
      }
      function consumeTimeout(n, t) {
        for (var r, o = 0; o < n.length && (r = e()) < t; ) try {
          n[o++](r);
        } catch (n) {
          console.error(n);
        }
        o === n.length ? n.length = 0 : 0 !== o && n.splice(0, o);
      }
      function flush() {
        c++, 
        // always force a bunch of medium callbacks to run, but still have
        // a throttle on how many can run in a certain time
        // DOM READS!!!
        consume(i);
        var t = e() + 7 * Math.ceil(c * (1 / 22));
        // DOM WRITES!!!
                consumeTimeout(u, t), consumeTimeout(f, t), u.length > 0 && (f.push.apply(f, u), 
        u.length = 0), (a = i.length + u.length + f.length > 0) ? 
        // still more to do yet, but we've run out of time
        // let's let this thing cool off and try again in the next tick
        n.raf(flush) : c = 0;
      }
      var e = function() {
        return t.performance.now();
      }, r = Promise.resolve(), o = [], i = [], u = [], f = [], c = 0, a = !1;
      return n.raf || (n.raf = t.requestAnimationFrame.bind(t)), {
        tick: function(n) {
          // queue high priority work to happen in next tick
          // uses Promise.resolve() for next tick
          o.push(n), 1 === o.length && r.then(function() {
            return consume(o);
          });
        },
        read: function(t) {
          // queue dom reads
          i.push(t), a || (a = !0, n.raf(flush));
        },
        write: function(t) {
          // queue dom writes
          u.push(t), a || (a = !0, n.raf(flush));
        }
      };
    }(c, e),
    _$requestBundle$_: function requestBundle(n, t, e) {
      if (n._$componentConstructor$_) 
      // we're already all loaded up :)
      queueUpdate(p, t); else {
        // using a 3rd party bundler to import modules
        // at this point the cmpMeta will already have a
        // static function as a the bundleIds that returns the module
        var r = {
          mode: t.mode,
          scoped: 2 /* ScopedCss */ === n._$encapsulationMeta$_ || 1 /* ShadowDom */ === n._$encapsulationMeta$_ && !a._$$supportsShadowDom$_
        };
        n._$bundleIds$_(r).then(function(e) {
          // async loading of the module is done
          try {
            // get the component constructor from the module
            // initialize this component constructor's styles
            // it is possible for the same component to have difficult styles applied in the same app
            n._$componentConstructor$_ = e, function initStyleTemplate(n, t, e, r, o) {
              if (r) {
                // we got a style mode for this component, let's create an id for this style
                var i = t._$tagNameMeta$_ + (o || y);
                t[i] || (
                // ie11's template polyfill doesn't fully do the trick and there's still issues
                // so instead of trying to clone templates with styles in them, we'll just
                // keep a map of the style text as a string to create <style> elements for es5 builds
                t[i] = r);
              }
            }(0, n, n._$encapsulationMeta$_, e.style, e.styleMode);
          } catch (t) {
            // oh man, something's up
            console.error(t), 
            // provide a bogus component constructor
            // so the rest of the app acts as normal
            n._$componentConstructor$_ = function componentConstructor() {};
          }
          // bundle all loaded up, let's continue
                    queueUpdate(p, t);
        });
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
  // internal id increment for unique ids
    // create the renderer that will be used
  p.render = createRendererPatch(p, a);
  // setup the root element which is the mighty <html> tag
  // the <html> has the final say of when the app has loaded
  var d = a._$$doc$_.documentElement;
  return d["s-ld"] = [], d["s-rn"] = !0, 
  // this will fire when all components have finished loaded
  d["s-init"] = function() {
    p._$hasLoadedMap$_.set(d, c.loaded = p._$isAppLoaded$_ = !0), a._$$dispatchEvent$_(e, "appload", {
      detail: {
        namespace: n
      }
    });
  }, p._$attachStyles$_ = function(n, t, e, r) {
    (function attachStyles(n, t, e, r) {
      // first see if we've got a style for a specific mode
      // either this host element should use scoped css
      // or it wants to use shadow dom but the browser doesn't support it
      // create a scope id which is useful for scoped css
      // and add the scope attribute to the host
      var o = 2 /* ScopedCss */ === e._$encapsulationMeta$_ || 1 /* ShadowDom */ === e._$encapsulationMeta$_ && !n._$domApi$_._$$supportsShadowDom$_, i = e._$tagNameMeta$_ + r.mode, u = e[i];
      // create the style id w/ the host element's mode
            if (o && (r["s-sc"] = getScopeId(e, r.mode)), u || (
      // doesn't look like there's a style template with the mode
      // create the style id using the default style mode and try again
      u = e[i = e._$tagNameMeta$_ + y], o && (r["s-sc"] = getScopeId(e))), u) {
        // cool, we found a style template element for this component
        var f = t._$$doc$_.head;
        // if this browser supports shadow dom, then let's climb up
        // the dom and see if we're within a shadow dom
                if (t._$$supportsShadowDom$_) if (1 /* ShadowDom */ === e._$encapsulationMeta$_) 
        // we already know we're in a shadow dom
        // so shadow root is the container for these styles
        f = r.shadowRoot; else for (
        // climb up the dom and see if we're in a shadow dom
        var c = r; c = t._$$parentNode$_(c); ) if (c.host && c.host.shadowRoot) {
          // looks like we are in shadow dom, let's use
          // this shadow root as the container for these styles
          f = c.host.shadowRoot;
          break;
        }
        // if this container element already has these styles
        // then there's no need to apply them again
        // create an object to keep track if we'ready applied this component style
                var a = n._$componentAppliedStyles$_.get(f);
        // check if we haven't applied these styles to this container yet
        if (a || n._$componentAppliedStyles$_.set(f, a = {}), !a[i]) {
          var s = void 0;
          if (
          // es5 builds are not usig <template> because of ie11 issues
          // instead the "template" is just the style text as a string
          // create a new style element and add as innerHTML
          n._$customStyle$_ ? s = n._$customStyle$_._$createHostStyle$_(r, i, u) : ((s = t._$$createElement$_("style")).innerHTML = u, 
          // remember we don't need to do this again for this element
          a[i] = !0), s) {
            var l = f.querySelectorAll("[data-styles]");
            t._$$insertBefore$_(f, s, l.length && l[l.length - 1].nextSibling || f.firstChild);
          }
        }
      }
    })(n, t, e, r);
  }, 
  // create the componentOnReady fn
  function initCoreComponentOnReady(n, t, e, r, o, i) {
    if (
    // add componentOnReady() to the App object
    // this also is used to know that the App's core is ready
    t.componentOnReady = function(t, e) {
      if (!t.nodeName.includes("-")) return e(null), !1;
      var r = n._$getComponentMeta$_(t);
      if (r) if (n._$hasLoadedMap$_.has(t)) 
      // element has already loaded, pass the resolve the element component
      // so we know that the resolve knows it this element is an app component
      e(t); else {
        // element hasn't loaded yet
        // add this resolve specifically to this elements on ready queue
        var o = n._$onReadyCallbacksMap$_.get(t) || [];
        o.push(e), n._$onReadyCallbacksMap$_.set(t, o);
      }
      // return a boolean if this app recognized this element or not
            return !!r;
    }, o) {
      // we've got some componentOnReadys in the queue before the app was ready
      for (i = o.length - 1; i >= 0; i--) 
      // go through each element and see if this app recongizes it
      t.componentOnReady(o[i][0], o[i][1]) && 
      // turns out this element belongs to this app
      // remove the resolve from the queue so in the end
      // all that's left in the queue are elements not apart of any apps
      o.splice(i, 1);
      for (i = 0; i < r.length; i++) if (!e[r[i]].componentOnReady) 
      // there is at least 1 apps that isn't ready yet
      // so let's stop here cuz there's still app cores loading
      return;
      // if we got to this point then that means all of the apps are ready
      // and they would have removed any of their elements from queuedComponentOnReadys
      // so let's do the cleanup of the  remaining queuedComponentOnReadys
            for (i = 0; i < o.length; i++) 
      // resolve any queued componentsOnReadys that are left over
      // since these elements were not apart of any apps
      // call the resolve fn, but pass null so it's know this wasn't a known app component
      o[i][1](null);
      o.length = 0;
    }
  }(p, c, e, e["s-apps"], e["s-cr"]), 
  // notify that the app has initialized and the core script is ready
  // but note that the components have not fully loaded yet
  c.initialized = !0, p;
}

function defineCustomElement(n, t, e) {
  void 0 === e && (e = {}), t = Array.isArray(t) ? t : [ t ];
  var r = n.document, o = e.hydratedCssClass || "hydrated", i = t.filter(function(n) {
    return n[2];
  }).map(function(n) {
    return n[0];
  });
  if (i.length) {
    // auto hide components until they been fully hydrated
    // reusing the "x" and "i" variables from the args for funzies
    var u = r.createElement("style");
    u.innerHTML = i.join() + "{visibility:hidden}." + o + "{visibility:inherit}", u.setAttribute("data-styles", ""), 
    r.head.insertBefore(u, r.head.firstChild);
  }
  var f = e.namespace || "GxWebControls";
  V || (V = !0, function createComponentOnReadyPrototype(n, t, e) {
    (n["s-apps"] = n["s-apps"] || []).push(t), e.componentOnReady || (e.componentOnReady = function componentOnReady() {
      function executor(e) {
        if (t.nodeName.indexOf("-") > 0) {
          // loop through all the app namespaces
          for (
          // window hasn't loaded yet and there's a
          // good chance this is a custom element
          var r = n["s-apps"], o = 0, i = 0; i < r.length; i++) 
          // see if this app has "componentOnReady" setup
          if (n[r[i]].componentOnReady) {
            // this app's core has loaded call its "componentOnReady"
            if (n[r[i]].componentOnReady(t, e)) 
            // this component does belong to this app and would
            // have fired off the resolve fn
            // let's stop here, we're good
            return;
            o++;
          }
          if (o < r.length) 
          // not all apps are ready yet
          // add it to the queue to be figured out when they are
          return void (n["s-cr"] = n["s-cr"] || []).push([ t, e ]);
        }
        // not a recognized app component
                e(null);
      }
      // callback wasn't provided, let's return a promise
            /*tslint:disable*/
      var t = this;
      return n.Promise ? new n.Promise(executor) : {
        then: executor
      };
      // promise may not have been polyfilled yet
        });
  }
  /**
 * SSR Attribute Names
 */ (n, f, n.HTMLElement.prototype)), applyPolyfills(n, function() {
    if (!S[f]) {
      var i = {}, u = e.resourcesUrl || "./";
      p(f, i, n, r, u, o), 
      // create a platform for this namespace
      S[f] = createPlatformMain(f, i, n, r, u, o);
    }
    // polyfills have been applied if need be
        t.forEach(function(t) {
      var e;
      !function isNative(n) {
        return /\{\s*\[native code\]\s*\}/.test("" + n);
      }(n.customElements.define) ? (
      // using polyfilled custom elements
      e = function(t) {
        return n.HTMLElement.call(this, t);
      }).prototype = Object.create(n.HTMLElement.prototype, {
        constructor: {
          value: e,
          configurable: !0
        }
      }) : e = new Function("w", "return class extends w.HTMLElement{}")(n), 
      // convert the static constructor data to cmp metadata
      // define the component as a custom element
      S[f]._$defineComponent$_(function parseComponentLoader(n, t, e) {
        // tag name will always be lower case
        var r = {
          _$tagNameMeta$_: n[0],
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
                r._$bundleIds$_ = n[1];
        // parse member meta
        // this data only includes props that are attributes that need to be observed
        // it does not include all of the props yet
        var o = n[3];
        if (o) for (t = 0; t < o.length; t++) e = o[t], r._$membersMeta$_[e[0]] = {
          _$memberType$_: e[1],
          _$reflectToAttrib$_: !!e[2],
          _$attribName$_: "string" == typeof e[3] ? e[3] : e[3] ? e[0] : 0,
          _$propType$_: e[4]
        };
        // encapsulation
                return r._$encapsulationMeta$_ = n[4], n[5] && (
        // parse listener meta
        r._$listenersMeta$_ = n[5].map(parseListenerData)), r;
      }(t), e);
    });
  });
}

this && this._$__extends$_ || (Object.setPrototypeOf || Array);

var p = function() {};

function applyPolyfills(p, d) {
  /*!
    es6-promise - a tiny implementation of Promises/A+.
    Copyright (c) 2014 Yehuda Katz, Tom Dale, Stefan Penner and contributors (Conversion to ES6 API by Jake Archibald)
    Licensed under MIT license
    See https://raw.githubusercontent.com/stefanpenner/es6-promise/master/LICENSE
    v4.2.4+314e4831
    */
  p._$ES6Promise$_ = function() {
    function t() {
      var n = setTimeout;
      return function() {
        return n(r, 1);
      };
    }
    function r() {
      for (var n = 0; n < m; n += 2) (0, S[n])(S[n + 1]), S[n] = void 0, S[n + 1] = void 0;
      m = 0;
    }
    function e(n, t) {
      var e = this, r = new this.constructor(o);
      void 0 === r[A] && _(r);
      var i = e._$_state$_;
      if (i) {
        var u = arguments[i - 1];
        C(function() {
          return v(i, r, u, e._$_result$_);
        });
      } else l(e, r, n, t);
      return r;
    }
    function n(n) {
      if (n && "object" == typeof n && n.constructor === this) return n;
      var t = new this(o);
      return u(t, n), t;
    }
    function o() {}
    function i(n) {
      try {
        return n.then;
      } catch (n) {
        return L.error = n, L;
      }
    }
    function s(t, r, o) {
      r.constructor === t.constructor && o === e && r.constructor.resolve === n ? function(n, t) {
        t._$_state$_ === O ? a(n, t._$_result$_) : t._$_state$_ === $ ? f(n, t._$_result$_) : l(t, void 0, function(t) {
          return u(n, t);
        }, function(t) {
          return f(n, t);
        });
      }(t, r) : o === L ? (f(t, L.error), L.error = null) : void 0 === o ? a(t, r) : "function" == typeof o ? function(n, t, e) {
        C(function(n) {
          var r = !1, o = function(n, t, e, r) {
            try {
              n.call(t, e, r);
            } catch (n) {
              return n;
            }
          }(e, t, function(e) {
            r || (r = !0, t !== e ? u(n, e) : a(n, e));
          }, function(t) {
            r || (r = !0, f(n, t));
          }, n._$_label$_);
          !r && o && (r = !0, f(n, o));
        }, n);
      }(t, r, o) : a(t, r);
    }
    function u(n, t) {
      if (n === t) f(n, new TypeError("cannot resolve promise w/ itself")); else {
        var e = typeof t;
        null === t || "object" !== e && "function" !== e ? a(n, t) : s(n, t, i(t));
      }
    }
    function c(n) {
      n._$_onerror$_ && n._$_onerror$_(n._$_result$_), h(n);
    }
    function a(n, t) {
      n._$_state$_ === j && (n._$_result$_ = t, n._$_state$_ = O, 0 !== n._$_subscribers$_.length && C(h, n));
    }
    function f(n, t) {
      n._$_state$_ === j && (n._$_state$_ = $, n._$_result$_ = t, C(c, n));
    }
    function l(n, t, e, r) {
      var o = n._$_subscribers$_, i = o.length;
      n._$_onerror$_ = null, o[i] = t, o[i + O] = e, o[i + $] = r, 0 === i && n._$_state$_ && C(h, n);
    }
    function h(n) {
      var t = n._$_subscribers$_, e = n._$_state$_;
      if (0 !== t.length) {
        for (var r, o, i = n._$_result$_, u = 0; u < t.length; u += 3) r = t[u], o = t[u + e], 
        r ? v(e, r, o, i) : o(i);
        n._$_subscribers$_.length = 0;
      }
    }
    function v(n, t, e, r) {
      var o = "function" == typeof e, i = void 0, c = void 0, s = void 0, l = void 0;
      if (o) {
        try {
          i = e(r);
        } catch (n) {
          L.error = n, i = L;
        }
        if (i === L ? (l = !0, c = i.error, i.error = null) : s = !0, t === i) return void f(t, new TypeError("Cannot return same promise"));
      } else i = r, s = !0;
      t._$_state$_ === j && (o && s ? u(t, i) : l ? f(t, c) : n === O ? a(t, i) : n === $ && f(t, i));
    }
    function _(n) {
      n[A] = x++, n._$_state$_ = void 0, n._$_result$_ = void 0, n._$_subscribers$_ = [];
    }
    var d, y = Array.isArray ? Array.isArray : function(n) {
      return "[object Array]" === Object.prototype.toString.call(n);
    }, m = 0, b = void 0, g = void 0, C = function(n, t) {
      S[m] = n, S[m + 1] = t, 2 === (m += 2) && (g ? g(r) : V());
    }, w = (d = void 0 !== p ? p : void 0) || {}, E = w._$MutationObserver$_ || w._$WebKitMutationObserver$_;
    w = "undefined" == typeof self;
    var M, P, k, N = "undefined" != typeof Uint8ClampedArray && "undefined" != typeof importScripts && "undefined" != typeof MessageChannel, S = Array(1e3), V = void 0;
    V = E ? (M = 0, P = new E(r), k = document.createTextNode(""), P.observe(k, {
      characterData: !0
    }), function() {
      k.data = M = ++M % 2;
    }) : N ? function() {
      var n = new MessageChannel();
      return n._$port1$_.onmessage = r, function() {
        return n._$port2$_.postMessage(0);
      };
    }() : void 0 === d && "function" == typeof require ? function() {
      try {
        var n = Function("return this")()._$require$_("vertx");
        return void 0 !== (b = n._$runOnLoop$_ || n._$runOnContext$_) ? function() {
          b(r);
        } : t();
      } catch (n) {
        return t();
      }
    }() : t();
    var A = Math.random().toString(36).substring(2), j = void 0, O = 1, $ = 2, L = {
      error: null
    }, x = 0, T = function() {
      function t(n, t) {
        this._$_instanceConstructor$_ = n, this._$promise$_ = new n(o), this._$promise$_[A] || _(this._$promise$_), 
        y(t) ? (this._$_remaining$_ = this.length = t.length, this._$_result$_ = Array(this.length), 
        0 === this.length ? a(this._$promise$_, this._$_result$_) : (this.length = this.length || 0, 
        this._$_enumerate$_(t), 0 === this._$_remaining$_ && a(this._$promise$_, this._$_result$_))) : f(this._$promise$_, Error("Array Methods must be provided an Array"));
      }
      return t.prototype._$_enumerate$_ = function(n) {
        for (var t = 0; this._$_state$_ === j && t < n.length; t++) this._$_eachEntry$_(n[t], t);
      }, t.prototype._$_eachEntry$_ = function(t, r) {
        var u = this._$_instanceConstructor$_, f = u.resolve;
        f === n ? (f = i(t)) === e && t._$_state$_ !== j ? this._$_settledAt$_(t._$_state$_, r, t._$_result$_) : "function" != typeof f ? (this._$_remaining$_--, 
        this._$_result$_[r] = t) : u === R ? (s(u = new u(o), t, f), this._$_willSettleAt$_(u, r)) : this._$_willSettleAt$_(new u(function(n) {
          return n(t);
        }), r) : this._$_willSettleAt$_(f(t), r);
      }, t.prototype._$_settledAt$_ = function(n, t, e) {
        var r = this._$promise$_;
        r._$_state$_ === j && (this._$_remaining$_--, n === $ ? f(r, e) : this._$_result$_[t] = e), 
        0 === this._$_remaining$_ && a(r, this._$_result$_);
      }, t.prototype._$_willSettleAt$_ = function(n, t) {
        var e = this;
        l(n, void 0, function(n) {
          return e._$_settledAt$_(O, t, n);
        }, function(n) {
          return e._$_settledAt$_($, t, n);
        });
      }, t;
    }(), R = function() {
      function t(n) {
        if (this[A] = x++, this._$_result$_ = this._$_state$_ = void 0, this._$_subscribers$_ = [], 
        o !== n) {
          if ("function" != typeof n) throw new TypeError("Must pass a resolver fn as 1st arg");
          if (!(this instanceof t)) throw new TypeError("Failed to construct 'Promise': Use the 'new' operator.");
          !function(n, t) {
            try {
              t(function(t) {
                u(n, t);
              }, function(t) {
                f(n, t);
              });
            } catch (t) {
              f(n, t);
            }
          }(this, n);
        }
      }
      return t.prototype.catch = function(n) {
        return this.then(null, n);
      }, t.prototype._$finally$_ = function(n) {
        var t = this.constructor;
        return this.then(function(e) {
          return t.resolve(n()).then(function() {
            return e;
          });
        }, function(e) {
          return t.resolve(n()).then(function() {
            throw e;
          });
        });
      }, t;
    }();
    return R.prototype.then = e, R.all = function(n) {
      return new T(this, n)._$promise$_;
    }, R.race = function(n) {
      var t = this;
      return y(n) ? new t(function(e, r) {
        for (var o = n.length, i = 0; i < o; i++) t.resolve(n[i]).then(e, r);
      }) : new t(function(n, t) {
        return t(new TypeError("Must pass array to race"));
      });
    }, R.resolve = n, R.reject = function(n) {
      var t = new this(o);
      return f(t, n), t;
    }, R._$_setScheduler$_ = function(n) {
      g = n;
    }, R._$_setAsap$_ = function(n) {
      C = n;
    }, R._$_asap$_ = C, R._$polyfill$_ = function() {
      var n = void 0;
      if ("undefined" != typeof global) n = global; else if ("undefined" != typeof self) n = self; else try {
        n = Function("return this")();
      } catch (n) {
        throw Error("polyfill failed");
      }
      var t = n.Promise;
      if (t) {
        var e = null;
        try {
          e = Object.prototype.toString.call(t.resolve());
        } catch (n) {}
        if ("[object Promise]" === e && !t._$cast$_) return;
      }
      n.Promise = R;
    }, R.Promise = R, R._$polyfill$_(), R;
  }();
  var y = [];
  p.customElements && (!p.Element || p.Element.prototype.closest && p.Element.prototype.matches && p.Element.prototype.remove) || y.push(import("./polyfills/dom.js")), 
  "function" == typeof Object.assign && Object.entries || y.push(import("./polyfills/object.js")), 
  Array.prototype.find && Array.prototype.includes || y.push(import("./polyfills/array.js")), 
  String.prototype.startsWith && String.prototype.endsWith || y.push(import("./polyfills/string.js")), 
  p.fetch || y.push(import("./polyfills/fetch.js")), Promise.all(y).then(function(n) {
    n.forEach(function(n) {
      n.applyPolyfill(p, p.document);
    }), d();
  });
}

var d = "ssrv", y = "$", m = {}, b = {
  enter: 13,
  escape: 27,
  space: 32,
  tab: 9,
  left: 37,
  up: 38,
  right: 39,
  down: 40
}, g = function(n) {
  return null != n;
}, C = function(n) {
  return n.toLowerCase();
}, w = function() {}, E = [], M = {
  forEach: function(n, t) {
    n.forEach(function(n) {
      return t(VNodeToChild(n));
    });
  },
  map: function(n, t) {
    return n.map(function(n) {
      return function childToVNode(n) {
        return {
          vtag: n.vtag,
          vchildren: n.vchildren,
          vtext: n.vtext,
          vattrs: n.vattrs,
          vkey: n.vkey,
          vname: n.vname
        };
      }(t(VNodeToChild(n)));
    });
  }
}, P = "wc-", k = "http://www.w3.org/1999/xlink", N = !1, S = {}, V = !1;

export { defineCustomElement, h };