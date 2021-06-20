/*!
 * Built with http://stenciljs.com
 * 2018-07-24T13:38:32
 */
!function(e, t, i, o, l, s, n, a, d, r, c, m, b, u) {
  for (
  // create global namespace if it doesn't already exist
  (c = e.GxWebControls = e.GxWebControls || {}).components = d, (b = d.filter(function(e) {
    return e[2];
  }).map(function(e) {
    return e[0];
  })).length && (
  // auto hide components until they been fully hydrated
  // reusing the "x" and "i" variables from the args for funzies
  (m = t.createElement("style")).innerHTML = b.join() + "{visibility:hidden}.hydrated{visibility:inherit}", 
  m.setAttribute("data-styles", ""), t.head.insertBefore(m, t.head.firstChild)), function(e, t, i) {
    (e["s-apps"] = e["s-apps"] || []).push("GxWebControls"), i.componentOnReady || (i.componentOnReady = function() {
      /*tslint:disable*/
      var t = this;
      function executor(i) {
        if (t.nodeName.indexOf("-") > 0) {
          // loop through all the app namespaces
          for (
          // window hasn't loaded yet and there's a
          // good chance this is a custom element
          var o = e["s-apps"], l = 0, s = 0; s < o.length; s++) 
          // see if this app has "componentOnReady" setup
          if (e[o[s]].componentOnReady) {
            // this app's core has loaded call its "componentOnReady"
            if (e[o[s]].componentOnReady(t, i)) 
            // this component does belong to this app and would
            // have fired off the resolve fn
            // let's stop here, we're good
            return;
            l++;
          }
          if (l < o.length) 
          // not all apps are ready yet
          // add it to the queue to be figured out when they are
          return void (e["s-cr"] = e["s-cr"] || []).push([ t, i ]);
        }
        // not a recognized app component
                i(null);
      }
      // callback wasn't provided, let's return a promise
            return e.Promise ? new e.Promise(executor) : {
        then: executor
      };
      // promise may not have been polyfilled yet
        });
  }(e, 0, r), l = l || c.resourcesUrl, m = (
  // figure out the script element for this current script
  b = t.querySelectorAll("script")).length - 1; m >= 0 && !(u = b[m]).src && !u.hasAttribute("data-resources-url"); m--) ;
  // get the resource path attribute on this script element
    b = u.getAttribute("data-resources-url"), !l && b && (
  // the script element has a data-resources-url attribute, always use that
  l = b), !l && u.src && (l = (
  // we don't have an exact resourcesUrl, so let's
  // figure it out relative to this script's src and app's filesystem namespace
  b = u.src.split("/").slice(0, -1)).join("/") + (b.length ? "/" : "") + "gx-web-controls/"), 
  // request the core this browser needs
  // test for native support of custom elements and fetch
  // if either of those are not supported, then use the core w/ polyfills
  // also check if the page was build with ssr or not
  m = t.createElement("script"), function(e, t, i, o) {
    // fyi, dev mode has verbose if/return statements
    // but it minifies to a nice 'lil one-liner ;)
    return !(t.search.indexOf("core=esm") > 0) && (!(!(t.search.indexOf("core=es5") > 0 || "file:" === t.protocol) && e.customElements && e.customElements.define && e.fetch && e.CSS && e.CSS.supports && e.CSS.supports("color", "var(--c)") && "noModule" in i) || function(e) {
      try {
        return new Function('import("")'), !1;
      } catch (e) {}
      return !0;
    }());
  }(e, e.location, m) ? 
  // requires the es5/polyfilled core
  m.src = l + "gx-web-controls.ymjnjgiv.js" : (
  // let's do this!
  m.src = l + "gx-web-controls.6bkc5tqc.js", m.setAttribute("type", "module"), m.setAttribute("crossorigin", !0)), 
  m.setAttribute("data-resources-url", l), m.setAttribute("data-namespace", "gx-web-controls"), 
  t.head.appendChild(m);
}(window, document, 0, 0, 0, 0, 0, 0, [ [ "gx-button", "tyq6mq5i", 1, [ [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "imagePosition", 1, 0, "image-position", 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "size", 1, 0, 1, 2 ] ] ], [ "gx-canvas", "mdlnqmqa", 1, [ [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ] ] ], [ "gx-canvas-cell", "oxrqrytd", 1, [ [ "align", 1, 0, 1, 2 ], [ "element", 7 ], [ "overflowMode", 1, 0, "overflow-mode", 2 ], [ "valign", 1, 0, 1, 2 ] ] ], [ "gx-card", "vhgopzpp", 1, [ [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ] ] ], [ "gx-checkbox", "uoehdree", 1, [ [ "caption", 1, 0, 1, 2 ], [ "checked", 2, 0, 1, 3 ], [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "getNativeInputId", 6 ], [ "id", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ] ] ], [ "gx-edit", "2cz5rxkh", 1, [ [ "area", 1, 0, 1, 2 ], [ "autocapitalize", 1, 0, 1, 2 ], [ "autocomplete", 1, 0, 1, 2 ], [ "autocorrect", 1, 0, 1, 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "getNativeInputId", 6 ], [ "id", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "multiline", 1, 0, 1, 3 ], [ "placeholder", 1, 0, 1, 2 ], [ "readonly", 1, 0, 1, 3 ], [ "showTrigger", 1, 0, "show-trigger", 3 ], [ "triggerText", 1, 0, "trigger-text", 2 ], [ "type", 1, 0, 1, 2 ], [ "value", 2, 0, 1, 2 ] ] ], [ "gx-form-field", "tyq6mq5i", 1, [ [ "element", 7 ], [ "labelCaption", 1, 0, "label-caption", 2 ], [ "labelPosition", 1, 0, "label-position", 2 ] ] ], [ "gx-image", "tyq6mq5i", 1, [ [ "alt", 1, 0, 1, 2 ], [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "height", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "lowResolutionSrc", 1, 0, "low-resolution-src", 2 ], [ "src", 1, 0, 1, 2 ], [ "width", 1, 0, 1, 2 ] ] ], [ "gx-layout-editor", "tyq6mq5i", 1, [ [ "element", 7 ], [ "model", 1, 0, 1, 1 ], [ "selectedCells", 2 ] ] ], [ "gx-layout-editor-placeholder", "tyq6mq5i", 1, [ [ "element", 7 ] ] ], [ "gx-lottie", "yimxcbor", 1, [ [ "animationData", 1, 0, "animation-data", 1 ], [ "autoPlay", 1, 0, "auto-play", 3 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "loop", 1, 0, 1, 3 ], [ "path", 1, 0, 1, 2 ], [ "pause", 6 ], [ "play", 6 ], [ "setProgress", 6 ], [ "stop", 6 ] ] ], [ "gx-message", "vd6rmkkk", 1, [ [ "closeButtonText", 1, 0, "close-button-text", 2 ], [ "duration", 1, 0, 1, 4 ], [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "showCloseButton", 1, 0, "show-close-button", 3 ], [ "type", 1, 0, 1, 2 ] ] ], [ "gx-modal", "ks5kkgum", 1, [ [ "autoClose", 1, 0, "auto-close", 3 ], [ "closeButtonLabel", 1, 0, "close-button-label", 2 ], [ "element", 7 ], [ "opened", 2, 0, 1, 3 ] ] ], [ "gx-navbar", "nwdz4auz", 1, [ [ "caption", 1, 0, 1, 2 ], [ "cssClass", 1, 0, "css-class", 2 ], [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "toggleButtonLabel", 1, 0, "toggle-button-label", 2 ] ] ], [ "gx-navbar-link", "syt4hxm1", 1, [ [ "active", 1, 0, 1, 3 ], [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "href", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ] ] ], [ "gx-password-edit", "whbcoigk", 1, [ [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "getNativeInputId", 6 ], [ "id", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "placeholder", 1, 0, 1, 2 ], [ "readonly", 1, 0, 1, 3 ], [ "revealButtonTextOff", 1, 0, "reveal-button-text-off", 2 ], [ "revealButtonTextOn", 1, 0, "reveal-button-text-on", 2 ], [ "revealed", 5 ], [ "showRevealButton", 1, 0, "show-reveal-button", 3 ], [ "value", 2, 0, 1, 2 ] ], 0, [ [ "gxTriggerClick", "handleTriggerClick" ] ] ], [ "gx-progress-bar", "ewefx8mg", 1, [ [ "value", 1, 0, 1, 4 ] ] ], [ "gx-radio-group", "hpsndhas", 1, [ [ "direction", 1, 0, 1, 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "id", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "name", 1, 0, 1, 2 ], [ "value", 2, 0, 1, 2 ] ], 0, [ [ "gxRadioDidLoad", "onRadioDidLoad" ], [ "gxRadioDidUnload", "onRadioDidUnload" ], [ "gxSelect", "onRadioSelect" ] ] ], [ "gx-radio-option", "ldr6cxko", 1, [ [ "caption", 1, 0, 1, 2 ], [ "checked", 2, 0, 1, 3 ], [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "id", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "name", 1, 0, 1, 2 ], [ "value", 2, 0, 1, 2 ] ] ], [ "gx-select", "cdyrrqr2", 0, [ [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "getNativeInputId", 6 ], [ "id", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "options", 5 ], [ "readonly", 1, 0, 1, 3 ], [ "value", 2, 0, 1, 2 ] ], 0, [ [ "gxSelectDidLoad", "onSelectOptionDidLoad" ], [ "gxSelectDidUnload", "onSelectOptionDidUnload" ], [ "gxDisable", "onSelectOptionDisable" ], [ "onChange", "onSelectOptionChange" ], [ "gxSelect", "onSelectOptionSelect" ] ] ], [ "gx-select-option", "h5dbrbfw", 0, [ [ "cssClass", 1, 0, "css-class", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "selected", 2, 0, 1, 3 ], [ "value", 2, 0, 1, 2 ] ] ], [ "gx-tab", "wzotiahx", 1, [ [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ] ], 0, [ [ "onTabSelect", "tabClickHandler" ] ] ], [ "gx-tab-caption", "qawwyomd", 1, [ [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "selected", 1, 0, 1, 3 ] ] ], [ "gx-tab-page", "lo8ay1zp", 1, [ [ "element", 7 ] ] ], [ "gx-table", "tyq6mq5i", 1, [ [ "areasTemplate", 1, 0, "areas-template", 2 ], [ "columnsTemplate", 1, 0, "columns-template", 2 ], [ "disabled", 1, 0, 1, 3 ], [ "element", 7 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ], [ "rowsTemplate", 1, 0, "rows-template", 2 ] ] ], [ "gx-table-cell", "tyq6mq5i", 1, [ [ "align", 1, 0, 1, 2 ], [ "area", 1, 0, 1, 2 ], [ "element", 7 ], [ "overflowMode", 1, 0, "overflow-mode", 2 ], [ "valign", 1, 0, 1, 2 ] ] ], [ "gx-textblock", "tyq6mq5i", 1, [ [ "disabled", 1, 0, 1, 3 ], [ "href", 1, 0, 1, 2 ], [ "invisibleMode", 1, 0, "invisible-mode", 2 ] ] ] ], HTMLElement.prototype);