/*! document-register-element, 1.7.0
https://github.com/WebReflection/document-register-element
(C) Andrea Giammarchi - @WebReflection - Mit Style License */
if (!window['s-ce1']) {
window['s-ce1'] = true;
(function(e,t){"use strict";function Ht(){var e=wt.splice(0,wt.length);Et=0;while(e.length)e.shift().call(null,e.shift())}function Bt(e,t){for(var n=0,r=e.length;n<r;n++)Jt(e[n],t)}function jt(e){for(var t=0,n=e.length,r;t<n;t++)r=e[t],Pt(r,A[It(r)])}function Ft(e){return function(t){ut(t)&&(Jt(t,e),O.length&&Bt(t.querySelectorAll(O),e))}}function It(e){var t=ht.call(e,"is"),n=e.nodeName.toUpperCase(),r=_.call(L,t?N+t.toUpperCase():T+n);return t&&-1<r&&!qt(n,t)?-1:r}function qt(e,t){return-1<O.indexOf(e+'[is="'+t+'"]')}function Rt(e){var t=e.currentTarget,n=e.attrChange,r=e.attrName,i=e.target,s=e[y]||2,o=e[w]||3;kt&&(!i||i===t)&&t[h]&&r!=="style"&&(e.prevValue!==e.newValue||e.newValue===""&&(n===s||n===o))&&t[h](r,n===s?null:e.prevValue,n===o?null:e.newValue)}function Ut(e){var t=Ft(e);return function(e){wt.push(t,e.target),Et&&clearTimeout(Et),Et=setTimeout(Ht,1)}}function zt(e){Ct&&(Ct=!1,e.currentTarget.removeEventListener(S,zt)),O.length&&Bt((e.target||n).querySelectorAll(O),e.detail===l?l:a),st&&Vt()}function Wt(e,t){var n=this;vt.call(n,e,t),Lt.call(n,{target:n})}function Xt(e,t){nt(e,t),Mt?Mt.observe(e,yt):(Nt&&(e.setAttribute=Wt,e[o]=Ot(e),e[u](x,Lt)),e[u](E,Rt)),e[m]&&kt&&(e.created=!0,e[m](),e.created=!1)}function Vt(){for(var e,t=0,n=at.length;t<n;t++)e=at[t],M.contains(e)||(n--,at.splice(t--,1),Jt(e,l))}function $t(e){throw new Error("A "+e+" type is already registered")}function Jt(e,t){var n,r=It(e),i;-1<r&&(Dt(e,A[r]),r=0,t===a&&!e[a]?(e[l]=!1,e[a]=!0,i="connected",r=1,st&&_.call(at,e)<0&&at.push(e)):t===l&&!e[l]&&(e[a]=!1,e[l]=!0,i="disconnected",r=1),r&&(n=e[t+f]||e[i+f])&&n.call(e))}function Kt(){}function Qt(e,t,r){var i=r&&r[c]||"",o=t.prototype,u=tt(o),a=t.observedAttributes||j,f={prototype:u};ot(u,m,{value:function(){if(Q)Q=!1;else if(!this[W]){this[W]=!0,new t(this),o[m]&&o[m].call(this);var e=G[Z.get(t)];(!V||e.create.length>1)&&Zt(this)}}}),ot(u,h,{value:function(e){-1<_.call(a,e)&&o[h].apply(this,arguments)}}),o[d]&&ot(u,p,{value:o[d]}),o[v]&&ot(u,g,{value:o[v]}),i&&(f[c]=i),e=e.toUpperCase(),G[e]={constructor:t,create:i?[i,et(e)]:[e]},Z.set(t,e),n[s](e.toLowerCase(),f),en(e),Y[e].r()}function Gt(e){var t=G[e.toUpperCase()];return t&&t.constructor}function Yt(e){return typeof e=="string"?e:e&&e.is||""}function Zt(e){var t=e[h],n=t?e.attributes:j,r=n.length,i;while(r--)i=n[r],t.call(e,i.name||i.nodeName,null,i.value||i.nodeValue)}function en(e){return e=e.toUpperCase(),e in Y||(Y[e]={},Y[e].p=new K(function(t){Y[e].r=t})),Y[e].p}function tn(){X&&delete e.customElements,B(e,"customElements",{configurable:!0,value:new Kt}),B(e,"CustomElementRegistry",{configurable:!0,value:Kt});for(var t=function(t){var r=e[t];if(r){e[t]=function(t){var i,s;return t||(t=this),t[W]||(Q=!0,i=G[Z.get(t.constructor)],s=V&&i.create.length===1,t=s?Reflect.construct(r,j,i.constructor):n.createElement.apply(n,i.create),t[W]=!0,Q=!1,s||Zt(t)),t},e[t].prototype=r.prototype;try{r.prototype.constructor=e[t]}catch(i){z=!0,B(r,W,{value:e[t]})}}},r=i.get(/^HTML[A-Z]*[a-z]/),o=r.length;o--;t(r[o]));n.createElement=function(e,t){var n=Yt(t);return n?gt.call(this,e,et(n)):gt.call(this,e)},St||(Tt=!0,n[s](""))}var n=e.document,r=e.Object,i=function(e){var t=/^[A-Z]+[a-z]/,n=function(e){var t=[],n;for(n in s)e.test(n)&&t.push(n);return t},i=function(e,t){t=t.toLowerCase(),t in s||(s[e]=(s[e]||[]).concat(t),s[t]=s[t.toUpperCase()]=e)},s=(r.create||r)(null),o={},u,a,f,l;for(a in e)for(l in e[a]){f=e[a][l],s[l]=f;for(u=0;u<f.length;u++)s[f[u].toLowerCase()]=s[f[u].toUpperCase()]=l}return o.get=function(r){return typeof r=="string"?s[r]||(t.test(r)?[]:""):n(r)},o.set=function(n,r){return t.test(n)?i(n,r):i(r,n),o},o}({collections:{HTMLAllCollection:["all"],HTMLCollection:["forms"],HTMLFormControlsCollection:["elements"],HTMLOptionsCollection:["options"]},elements:{Element:["element"],HTMLAnchorElement:["a"],HTMLAppletElement:["applet"],HTMLAreaElement:["area"],HTMLAttachmentElement:["attachment"],HTMLAudioElement:["audio"],HTMLBRElement:["br"],HTMLBaseElement:["base"],HTMLBodyElement:["body"],HTMLButtonElement:["button"],HTMLCanvasElement:["canvas"],HTMLContentElement:["content"],HTMLDListElement:["dl"],HTMLDataElement:["data"],HTMLDataListElement:["datalist"],HTMLDetailsElement:["details"],HTMLDialogElement:["dialog"],HTMLDirectoryElement:["dir"],HTMLDivElement:["div"],HTMLDocument:["document"],HTMLElement:["element","abbr","address","article","aside","b","bdi","bdo","cite","code","command","dd","dfn","dt","em","figcaption","figure","footer","header","i","kbd","mark","nav","noscript","rp","rt","ruby","s","samp","section","small","strong","sub","summary","sup","u","var","wbr"],HTMLEmbedElement:["embed"],HTMLFieldSetElement:["fieldset"],HTMLFontElement:["font"],HTMLFormElement:["form"],HTMLFrameElement:["frame"],HTMLFrameSetElement:["frameset"],HTMLHRElement:["hr"],HTMLHeadElement:["head"],HTMLHeadingElement:["h1","h2","h3","h4","h5","h6"],HTMLHtmlElement:["html"],HTMLIFrameElement:["iframe"],HTMLImageElement:["img"],HTMLInputElement:["input"],HTMLKeygenElement:["keygen"],HTMLLIElement:["li"],HTMLLabelElement:["label"],HTMLLegendElement:["legend"],HTMLLinkElement:["link"],HTMLMapElement:["map"],HTMLMarqueeElement:["marquee"],HTMLMediaElement:["media"],HTMLMenuElement:["menu"],HTMLMenuItemElement:["menuitem"],HTMLMetaElement:["meta"],HTMLMeterElement:["meter"],HTMLModElement:["del","ins"],HTMLOListElement:["ol"],HTMLObjectElement:["object"],HTMLOptGroupElement:["optgroup"],HTMLOptionElement:["option"],HTMLOutputElement:["output"],HTMLParagraphElement:["p"],HTMLParamElement:["param"],HTMLPictureElement:["picture"],HTMLPreElement:["pre"],HTMLProgressElement:["progress"],HTMLQuoteElement:["blockquote","q","quote"],HTMLScriptElement:["script"],HTMLSelectElement:["select"],HTMLShadowElement:["shadow"],HTMLSlotElement:["slot"],HTMLSourceElement:["source"],HTMLSpanElement:["span"],HTMLStyleElement:["style"],HTMLTableCaptionElement:["caption"],HTMLTableCellElement:["td","th"],HTMLTableColElement:["col","colgroup"],HTMLTableElement:["table"],HTMLTableRowElement:["tr"],HTMLTableSectionElement:["thead","tbody","tfoot"],HTMLTemplateElement:["template"],HTMLTextAreaElement:["textarea"],HTMLTimeElement:["time"],HTMLTitleElement:["title"],HTMLTrackElement:["track"],HTMLUListElement:["ul"],HTMLUnknownElement:["unknown","vhgroupv","vkeygen"],HTMLVideoElement:["video"]},nodes:{Attr:["node"],Audio:["audio"],CDATASection:["node"],CharacterData:["node"],Comment:["#comment"],Document:["#document"],DocumentFragment:["#document-fragment"],DocumentType:["node"],HTMLDocument:["#document"],Image:["img"],Option:["option"],ProcessingInstruction:["node"],ShadowRoot:["#shadow-root"],Text:["#text"],XMLDocument:["xml"]}});typeof t!="object"&&(t={type:t||"auto"});var s="registerElement",o="__"+s+(e.Math.random()*1e5>>0),u="addEventListener",a="attached",f="Callback",l="detached",c="extends",h="attributeChanged"+f,p=a+f,d="connected"+f,v="disconnected"+f,m="created"+f,g=l+f,y="ADDITION",b="MODIFICATION",w="REMOVAL",E="DOMAttrModified",S="DOMContentLoaded",x="DOMSubtreeModified",T="<",N="=",C=/^[A-Z][A-Z0-9]*(?:-[A-Z0-9]+)+$/,k=["ANNOTATION-XML","COLOR-PROFILE","FONT-FACE","FONT-FACE-SRC","FONT-FACE-URI","FONT-FACE-FORMAT","FONT-FACE-NAME","MISSING-GLYPH"],L=[],A=[],O="",M=n.documentElement,_=L.indexOf||function(e){for(var t=this.length;t--&&this[t]!==e;);return t},D=r.prototype,P=D.hasOwnProperty,H=D.isPrototypeOf,B=r.defineProperty,j=[],F=r.getOwnPropertyDescriptor,I=r.getOwnPropertyNames,q=r.getPrototypeOf,R=r.setPrototypeOf,U=!!r.__proto__,z=!1,W="__dreCEv1",X=e.customElements,V=!/^force/.test(t.type)&&!!(X&&X.define&&X.get&&X.whenDefined),$=r.create||r,J=e.Map||function(){var t=[],n=[],r;return{get:function(e){return n[_.call(t,e)]},set:function(e,i){r=_.call(t,e),r<0?n[t.push(e)-1]=i:n[r]=i}}},K=e.Promise||function(e){function i(e){n=!0;while(t.length)t.shift()(e)}var t=[],n=!1,r={"catch":function(){return r},then:function(e){return t.push(e),n&&setTimeout(i,1),r}};return e(i),r},Q=!1,G=$(null),Y=$(null),Z=new J,et=function(e){return e.toLowerCase()},tt=r.create||function sn(e){return e?(sn.prototype=e,new sn):this},nt=R||(U?function(e,t){return e.__proto__=t,e}:I&&F?function(){function e(e,t){for(var n,r=I(t),i=0,s=r.length;i<s;i++)n=r[i],P.call(e,n)||B(e,n,F(t,n))}return function(t,n){do e(t,n);while((n=q(n))&&!H.call(n,t));return t}}():function(e,t){for(var n in t)e[n]=t[n];return e}),rt=e.MutationObserver||e.WebKitMutationObserver,it=(e.HTMLElement||e.Element||e.Node).prototype,st=!H.call(it,M),ot=st?function(e,t,n){return e[t]=n.value,e}:B,ut=st?function(e){return e.nodeType===1}:function(e){return H.call(it,e)},at=st&&[],ft=it.attachShadow,lt=it.cloneNode,ct=it.dispatchEvent,ht=it.getAttribute,pt=it.hasAttribute,dt=it.removeAttribute,vt=it.setAttribute,mt=n.createElement,gt=mt,yt=rt&&{attributes:!0,characterData:!0,attributeOldValue:!0},bt=rt||function(e){Nt=!1,M.removeEventListener(E,bt)},wt,Et=0,St=s in n&&!/^force-all/.test(t.type),xt=!0,Tt=!1,Nt=!0,Ct=!0,kt=!0,Lt,At,Ot,Mt,_t,Dt,Pt;St||(R||U?(Dt=function(e,t){H.call(t,e)||Xt(e,t)},Pt=Xt):(Dt=function(e,t){e[o]||(e[o]=r(!0),Xt(e,t))},Pt=Dt),st?(Nt=!1,function(){var e=F(it,u),t=e.value,n=function(e){var t=new CustomEvent(E,{bubbles:!0});t.attrName=e,t.prevValue=ht.call(this,e),t.newValue=null,t[w]=t.attrChange=2,dt.call(this,e),ct.call(this,t)},r=function(e,t){var n=pt.call(this,e),r=n&&ht.call(this,e),i=new CustomEvent(E,{bubbles:!0});vt.call(this,e,t),i.attrName=e,i.prevValue=n?r:null,i.newValue=t,n?i[b]=i.attrChange=1:i[y]=i.attrChange=0,ct.call(this,i)},i=function(e){var t=e.currentTarget,n=t[o],r=e.propertyName,i;n.hasOwnProperty(r)&&(n=n[r],i=new CustomEvent(E,{bubbles:!0}),i.attrName=n.name,i.prevValue=n.value||null,i.newValue=n.value=t[r]||null,i.prevValue==null?i[y]=i.attrChange=0:i[b]=i.attrChange=1,ct.call(t,i))};e.value=function(e,s,u){e===E&&this[h]&&this.setAttribute!==r&&(this[o]={className:{name:"class",value:this.className}},this.setAttribute=r,this.removeAttribute=n,t.call(this,"propertychange",i)),t.call(this,e,s,u)},B(it,u,e)}()):rt||(M[u](E,bt),M.setAttribute(o,1),M.removeAttribute(o),Nt&&(Lt=function(e){var t=this,n,r,i;if(t===e.target){n=t[o],t[o]=r=Ot(t);for(i in r){if(!(i in n))return At(0,t,i,n[i],r[i],y);if(r[i]!==n[i])return At(1,t,i,n[i],r[i],b)}for(i in n)if(!(i in r))return At(2,t,i,n[i],r[i],w)}},At=function(e,t,n,r,i,s){var o={attrChange:e,currentTarget:t,attrName:n,prevValue:r,newValue:i};o[s]=e,Rt(o)},Ot=function(e){for(var t,n,r={},i=e.attributes,s=0,o=i.length;s<o;s++)t=i[s],n=t.name,n!=="setAttribute"&&(r[n]=t.value);return r})),n[s]=function(t,r){p=t.toUpperCase(),xt&&(xt=!1,rt?(Mt=function(e,t){function n(e,t){for(var n=0,r=e.length;n<r;t(e[n++]));}return new rt(function(r){for(var i,s,o,u=0,a=r.length;u<a;u++)i=r[u],i.type==="childList"?(n(i.addedNodes,e),n(i.removedNodes,t)):(s=i.target,kt&&s[h]&&i.attributeName!=="style"&&(o=ht.call(s,i.attributeName),o!==i.oldValue&&s[h](i.attributeName,i.oldValue,o)))})}(Ft(a),Ft(l)),_t=function(e){return Mt.observe(e,{childList:!0,subtree:!0}),e},_t(n),ft&&(it.attachShadow=function(){return _t(ft.apply(this,arguments))})):(wt=[],n[u]("DOMNodeInserted",Ut(a)),n[u]("DOMNodeRemoved",Ut(l))),n[u](S,zt),n[u]("readystatechange",zt),it.cloneNode=function(e){var t=lt.call(this,!!e),n=It(t);return-1<n&&Pt(t,A[n]),e&&O.length&&jt(t.querySelectorAll(O)),t});if(Tt)return Tt=!1;-2<_.call(L,N+p)+_.call(L,T+p)&&$t(t);if(!C.test(p)||-1<_.call(k,p))throw new Error("The type "+t+" is invalid");var i=function(){return o?n.createElement(f,p):n.createElement(f)},s=r||D,o=P.call(s,c),f=o?r[c].toUpperCase():p,p,d;return o&&-1<_.call(L,T+f)&&$t(f),d=L.push((o?N:T)+p)-1,O=O.concat(O.length?",":"",o?f+'[is="'+t.toLowerCase()+'"]':f),i.prototype=A[d]=P.call(s,"prototype")?s.prototype:tt(it),O.length&&Bt(n.querySelectorAll(O),a),i},n.createElement=gt=function(e,t){var r=Yt(t),i=r?mt.call(n,e,et(r)):mt.call(n,e),s=""+e,o=_.call(L,(r?N:T)+(r||s).toUpperCase()),u=-1<o;return r&&(i.setAttribute("is",r=r.toLowerCase()),u&&(u=qt(s.toUpperCase(),r))),kt=!n.createElement.innerHTMLHelper,u&&Pt(i,A[o]),i}),Kt.prototype={constructor:Kt,define:V?function(e,t,n){if(n)Qt(e,t,n);else{var r=e.toUpperCase();G[r]={constructor:t,create:[r]},Z.set(t,r),X.define(e,t)}}:Qt,get:V?function(e){return X.get(e)||Gt(e)}:Gt,whenDefined:V?function(e){return K.race([X.whenDefined(e),en(e)])}:en};if(!X||/^force/.test(t.type))tn();else if(!t.noBuiltIn)try{(function(t,r,i){r[c]="a",t.prototype=tt(HTMLAnchorElement.prototype),t.prototype.constructor=t,e.customElements.define(i,t,r);if(ht.call(n.createElement("a",{is:i}),"is")!==i||V&&ht.call(new t,"is")!==i)throw r})(function on(){return Reflect.construct(HTMLAnchorElement,[],on)},{},"document-register-element-a")}catch(nn){tn()}if(!t.noBuiltIn)try{mt.call(n,"a","a")}catch(rn){et=function(e){return{is:e.toLowerCase()}}}})(window);
}

/*!
Element.closest and Element.matches
https://github.com/jonathantneal/closest
Creative Commons Zero v1.0 Universal
*/
(function(a){"function"!==typeof a.matches&&(a.matches=a.msMatchesSelector||a.mozMatchesSelector||a.webkitMatchesSelector||function(a){a=(this.document||this.ownerDocument).querySelectorAll(a);for(var b=0;a[b]&&a[b]!==this;)++b;return!!a[b]});"function"!==typeof a.closest&&(a.closest=function(a){for(var b=this;b&&1===b.nodeType;){if(b.matches(a))return b;b=b.parentNode}return null})})(window.Element.prototype);
/*!
Element.remove()
https://developer.mozilla.org/en-US/docs/Web/API/ChildNode/remove
*/
(function(b){b.forEach(function(a){a.hasOwnProperty("remove")||Object.defineProperty(a,"remove",{configurable:!0,enumerable:!0,writable:!0,value:function(){null!==this.parentNode&&this.parentNode.removeChild(this)}})})})([Element.prototype,CharacterData.prototype,DocumentType.prototype]);
/*!
Array.prototype.find
*/
Array.prototype.find||Object.defineProperty(Array.prototype,"find",{writable:!0,configurable:!0,value:function(c,e){if(null==this)throw new TypeError('"this" is null or not defined');var b=Object(this),f=b.length>>>0;if("function"!==typeof c)throw new TypeError("predicate must be a function");for(var a=0;a<f;){var d=b[a];if(c.call(e,d,a,b))return d;a++}}});
/*!
Array.from
*/
Array.from||(Array.from=function(){var l=Object.prototype.toString,h=function(c){return"function"===typeof c||"[object Function]"===l.call(c)},m=Math.pow(2,53)-1;return function(c){var k=Object(c);if(null==c)throw new TypeError("Array.from requires an array-like object - not null or undefined");var d=1<arguments.length?arguments[1]:void 0,f;if("undefined"!==typeof d){if(!h(d))throw new TypeError("Array.from: when provided, the second argument must be a function");2<arguments.length&&(f=arguments[2])}var a=
Number(k.length);a=isNaN(a)?0:0!==a&&isFinite(a)?(0<a?1:-1)*Math.floor(Math.abs(a)):a;a=Math.min(Math.max(a,0),m);for(var g=h(this)?Object(new this(a)):Array(a),b=0,e;b<a;)e=k[b],g[b]=d?"undefined"===typeof f?d(e,b):d.call(f,e,b):e,b+=1;g.length=a;return g}}());
/*!
Array.prototype.includes
*/
Array.prototype.includes||Object.defineProperty(Array.prototype,"includes",{writable:!0,configurable:!0,value:function(r,e){if(null==this)throw new TypeError('"this" is null or not defined');var t=Object(this),n=t.length>>>0;if(0===n)return!1;var i,o,a=0|e,u=Math.max(0<=a?a:n-Math.abs(a),0);for(;u<n;){if((i=t[u])===(o=r)||"number"==typeof i&&"number"==typeof o&&isNaN(i)&&isNaN(o))return!0;u++}return!1}});
/*!
Object.assign
*/
"function"!=typeof Object.assign&&Object.defineProperty(Object,"assign",{value:function(d,f){if(null==d)throw new TypeError("Cannot convert undefined or null to object");for(var e=Object(d),b=1;b<arguments.length;b++){var a=arguments[b];if(null!=a)for(var c in a)Object.prototype.hasOwnProperty.call(a,c)&&(e[c]=a[c])}return e},writable:!0,configurable:!0});
/*!
Object.entries
*/
Object.entries||(Object.entries=function(c){for(var b=Object.keys(c),a=b.length,d=Array(a);a--;)d[a]=[b[a],c[b[a]]];return d});
/*!
String.prototype.endsWith
*/
String.prototype.endsWith||Object.defineProperty(String.prototype,"endsWith",{writable:!0,configurable:!0,value:function(b,a){if(void 0===a||a>this.length)a=this.length;return this.substring(a-b.length,a)===b}});
/*!
String.prototype.includes
*/
String.prototype.includes||(String.prototype.includes=function(b,a){"number"!==typeof a&&(a=0);return a+b.length>this.length?!1:-1!==this.indexOf(b,a)});
/*!
String.prototype.startsWith
*/
String.prototype.startsWith||Object.defineProperty(String.prototype,"startsWith",{writable:!0,configurable:!0,value:function(b,a){return this.substr(!a||0>a?0:+a,b.length)===b}});
/*!
es6-promise - a tiny implementation of Promises/A+.
Copyright (c) 2014 Yehuda Katz, Tom Dale, Stefan Penner and contributors (Conversion to ES6 API by Jake Archibald)
Licensed under MIT license
See https://raw.githubusercontent.com/stefanpenner/es6-promise/master/LICENSE
v4.2.4+314e4831
*/
(window.ES6Promise=function(){function t(){var t=setTimeout;return function(){return t(r,1)}}function r(){for(var t=0;t<y;t+=2)(0,C[t])(C[t+1]),C[t]=void 0,C[t+1]=void 0;y=0}function e(t,r){var e=this,n=new this.constructor(o);void 0===n[O]&&_(n);var i=e._state;if(i){var s=arguments[i-1];g(function(){return v(i,n,s,e._result)})}else l(e,n,t,r);return n}function n(t){if(t&&"object"==typeof t&&t.constructor===this)return t;var r=new this(o);return u(r,t),r}function o(){}function i(t){try{return t.then}catch(t){return q.error=t,q}}function s(t,r,o){r.constructor===t.constructor&&o===e&&r.constructor.resolve===n?function(t,r){r._state===x?a(t,r._result):r._state===F?f(t,r._result):l(r,void 0,function(r){return u(t,r)},function(r){return f(t,r)})}(t,r):o===q?(f(t,q.error),q.error=null):void 0===o?a(t,r):"function"==typeof o?function(t,r,e){g(function(t){var n=!1,o=function(t,r,e,n){try{t.call(r,e,n)}catch(t){return t}}(e,r,function(e){n||(n=!0,r!==e?u(t,e):a(t,e))},function(r){n||(n=!0,f(t,r))},t._label);!n&&o&&(n=!0,f(t,o))},t)}(t,r,o):a(t,r)}function u(t,r){if(t===r)f(t,new TypeError("cannot resolve promise w/ itself"));else{var e=typeof r;null===r||"object"!==e&&"function"!==e?a(t,r):s(t,r,i(r))}}function c(t){t._onerror&&t._onerror(t._result),h(t)}function a(t,r){t._state===P&&(t._result=r,t._state=x,0!==t._subscribers.length&&g(h,t))}function f(t,r){t._state===P&&(t._state=F,t._result=r,g(c,t))}function l(t,r,e,n){var o=t._subscribers,i=o.length;t._onerror=null,o[i]=r,o[i+x]=e,o[i+F]=n,0===i&&t._state&&g(h,t)}function h(t){var r=t._subscribers,e=t._state;if(0!==r.length){for(var n,o,i=t._result,s=0;s<r.length;s+=3)n=r[s],o=r[s+e],n?v(e,n,o,i):o(i);t._subscribers.length=0}}function v(t,r,e,n){var o="function"==typeof e,i=void 0,s=void 0,c=void 0,l=void 0;if(o){try{i=e(n)}catch(t){q.error=t,i=q}if(i===q?(l=!0,s=i.error,i.error=null):c=!0,r===i)return void f(r,new TypeError("Cannot return same promise"))}else i=n,c=!0;r._state===P&&(o&&c?u(r,i):l?f(r,s):t===x?a(r,i):t===F&&f(r,i))}function _(t){t[O]=U++,t._state=void 0,t._result=void 0,t._subscribers=[]}var p,d=Array.isArray?Array.isArray:function(t){return"[object Array]"===Object.prototype.toString.call(t)},y=0,w=void 0,m=void 0,g=function(t,e){C[y]=t,C[y+1]=e,2===(y+=2)&&(m?m(r):T())},b=(p="undefined"!=typeof window?window:void 0)||{},A=b.MutationObserver||b.WebKitMutationObserver;b="undefined"==typeof self;var E,S,M,j="undefined"!=typeof Uint8ClampedArray&&"undefined"!=typeof importScripts&&"undefined"!=typeof MessageChannel,C=Array(1e3),T=void 0;T=A?(E=0,S=new A(r),M=document.createTextNode(""),S.observe(M,{characterData:!0}),function(){M.data=E=++E%2}):j?function(){var t=new MessageChannel;return t.port1.onmessage=r,function(){return t.port2.postMessage(0)}}():void 0===p&&"function"==typeof require?function(){try{var e=Function("return this")().require("vertx");return void 0!==(w=e.runOnLoop||e.runOnContext)?function(){w(r)}:t()}catch(r){return t()}}():t();var O=Math.random().toString(36).substring(2),P=void 0,x=1,F=2,q={error:null},U=0,D=function(){function t(t,r){this._instanceConstructor=t,this.promise=new t(o),this.promise[O]||_(this.promise),d(r)?(this._remaining=this.length=r.length,this._result=Array(this.length),0===this.length?a(this.promise,this._result):(this.length=this.length||0,this._enumerate(r),0===this._remaining&&a(this.promise,this._result))):f(this.promise,Error("Array Methods must be provided an Array"))}return t.prototype._enumerate=function(t){for(var r=0;this._state===P&&r<t.length;r++)this._eachEntry(t[r],r)},t.prototype._eachEntry=function(t,r){var u=this._instanceConstructor,c=u.resolve;c===n?(c=i(t))===e&&t._state!==P?this._settledAt(t._state,r,t._result):"function"!=typeof c?(this._remaining--,this._result[r]=t):u===K?(s(u=new u(o),t,c),this._willSettleAt(u,r)):this._willSettleAt(new u(function(r){return r(t)}),r):this._willSettleAt(c(t),r)},t.prototype._settledAt=function(t,r,e){var n=this.promise;n._state===P&&(this._remaining--,t===F?f(n,e):this._result[r]=e),0===this._remaining&&a(n,this._result)},t.prototype._willSettleAt=function(t,r){var e=this;l(t,void 0,function(t){return e._settledAt(x,r,t)},function(t){return e._settledAt(F,r,t)})},t}(),K=function(){function t(r){if(this[O]=U++,this._result=this._state=void 0,this._subscribers=[],o!==r){if("function"!=typeof r)throw new TypeError("Must pass a resolver fn as 1st arg");if(!(this instanceof t))throw new TypeError("Failed to construct 'Promise': Use the 'new' operator.");!function(t,r){try{r(function(r){u(t,r)},function(r){f(t,r)})}catch(r){f(t,r)}}(this,r)}}return t.prototype.catch=function(t){return this.then(null,t)},t.prototype.finally=function(t){var r=this.constructor;return this.then(function(e){return r.resolve(t()).then(function(){return e})},function(e){return r.resolve(t()).then(function(){throw e})})},t}();return K.prototype.then=e,K.all=function(t){return new D(this,t).promise},K.race=function(t){var r=this;return d(t)?new r(function(e,n){for(var o=t.length,i=0;i<o;i++)r.resolve(t[i]).then(e,n)}):new r(function(t,r){return r(new TypeError("Must pass array to race"))})},K.resolve=n,K.reject=function(t){var r=new this(o);return f(r,t),r},K._setScheduler=function(t){m=t},K._setAsap=function(t){g=t},K._asap=g,K.polyfill=function(){var t=void 0;if("undefined"!=typeof global)t=global;else if("undefined"!=typeof self)t=self;else try{t=Function("return this")()}catch(t){throw Error("polyfill failed")}var r=t.Promise;if(r){var e=null;try{e=Object.prototype.toString.call(r.resolve())}catch(t){}if("[object Promise]"===e&&!r.cast)return}t.Promise=K},K.Promise=K,K.polyfill(),K}());
/*!
whatwg-fetch, 2.0.3
https://github.com/github/fetch
Copyright (c) 2014-2016 GitHub, Inc. - MIT License
*/
(function(e){function l(a){"string"!==typeof a&&(a=String(a));if(/[^a-z0-9\-#$%&'*+.\^_`|~]/i.test(a))throw new TypeError("Invalid character in header field name");return a.toLowerCase()}function q(a){"string"!==typeof a&&(a=String(a));return a}function n(a){var b={next:function(){var b=a.shift();return{done:void 0===b,value:b}}};g.iterable&&(b[Symbol.iterator]=function(){return b});return b}function d(a){this.map={};a instanceof d?a.forEach(function(a,c){this.append(c,a)},this):Array.isArray(a)?
a.forEach(function(a){this.append(a[0],a[1])},this):a&&Object.getOwnPropertyNames(a).forEach(function(b){this.append(b,a[b])},this)}function p(a){if(a.bodyUsed)return Promise.reject(new TypeError("Already read"));a.bodyUsed=!0}function r(a){return new Promise(function(b,c){a.onload=function(){b(a.result)};a.onerror=function(){c(a.error)}})}function w(a){var b=new FileReader,c=r(b);b.readAsArrayBuffer(a);return c}function x(a){a=new Uint8Array(a);for(var b=Array(a.length),c=0;c<a.length;c++)b[c]=String.fromCharCode(a[c]);
return b.join("")}function t(a){if(a.slice)return a.slice(0);var b=new Uint8Array(a.byteLength);b.set(new Uint8Array(a));return b.buffer}function u(){this.bodyUsed=!1;this._initBody=function(a){if(this._bodyInit=a)if("string"===typeof a)this._bodyText=a;else if(g.blob&&Blob.prototype.isPrototypeOf(a))this._bodyBlob=a;else if(g.formData&&FormData.prototype.isPrototypeOf(a))this._bodyFormData=a;else if(g.searchParams&&URLSearchParams.prototype.isPrototypeOf(a))this._bodyText=a.toString();else if(g.arrayBuffer&&
g.blob&&y(a))this._bodyArrayBuffer=t(a.buffer),this._bodyInit=new Blob([this._bodyArrayBuffer]);else if(g.arrayBuffer&&(ArrayBuffer.prototype.isPrototypeOf(a)||z(a)))this._bodyArrayBuffer=t(a);else throw Error("unsupported BodyInit type");else this._bodyText="";this.headers.get("content-type")||("string"===typeof a?this.headers.set("content-type","text/plain;charset=UTF-8"):this._bodyBlob&&this._bodyBlob.type?this.headers.set("content-type",this._bodyBlob.type):g.searchParams&&URLSearchParams.prototype.isPrototypeOf(a)&&
this.headers.set("content-type","application/x-www-form-urlencoded;charset=UTF-8"))};g.blob&&(this.blob=function(){var a=p(this);if(a)return a;if(this._bodyBlob)return Promise.resolve(this._bodyBlob);if(this._bodyArrayBuffer)return Promise.resolve(new Blob([this._bodyArrayBuffer]));if(this._bodyFormData)throw Error("could not read FormData body as blob");return Promise.resolve(new Blob([this._bodyText]))},this.arrayBuffer=function(){return this._bodyArrayBuffer?p(this)||Promise.resolve(this._bodyArrayBuffer):
this.blob().then(w)});this.text=function(){var a=p(this);if(a)return a;if(this._bodyBlob){a=this._bodyBlob;var b=new FileReader,c=r(b);b.readAsText(a);return c}if(this._bodyArrayBuffer)return Promise.resolve(x(this._bodyArrayBuffer));if(this._bodyFormData)throw Error("could not read FormData body as text");return Promise.resolve(this._bodyText)};g.formData&&(this.formData=function(){return this.text().then(A)});this.json=function(){return this.text().then(JSON.parse)};return this}function k(a,b){b=
b||{};var c=b.body;if(a instanceof k){if(a.bodyUsed)throw new TypeError("Already read");this.url=a.url;this.credentials=a.credentials;b.headers||(this.headers=new d(a.headers));this.method=a.method;this.mode=a.mode;c||null==a._bodyInit||(c=a._bodyInit,a.bodyUsed=!0)}else this.url=String(a);this.credentials=b.credentials||this.credentials||"omit";if(b.headers||!this.headers)this.headers=new d(b.headers);var v=b.method||this.method||"GET",g=v.toUpperCase();this.method=-1<B.indexOf(g)?g:v;this.mode=
b.mode||this.mode||null;this.referrer=null;if(("GET"===this.method||"HEAD"===this.method)&&c)throw new TypeError("Body not allowed for GET or HEAD requests");this._initBody(c)}function A(a){var b=new FormData;a.trim().split("&").forEach(function(a){if(a){var c=a.split("=");a=c.shift().replace(/\+/g," ");c=c.join("=").replace(/\+/g," ");b.append(decodeURIComponent(a),decodeURIComponent(c))}});return b}function C(a){var b=new d;a.replace(/\r?\n[\t ]+/g," ").split(/\r?\n/).forEach(function(a){var c=
a.split(":");if(a=c.shift().trim())c=c.join(":").trim(),b.append(a,c)});return b}function h(a,b){b||(b={});this.type="default";this.status=void 0===b.status?200:b.status;this.ok=200<=this.status&&300>this.status;this.statusText="statusText"in b?b.statusText:"OK";this.headers=new d(b.headers);this.url=b.url||"";this._initBody(a)}if(!e.fetch){var D="Symbol"in e&&"iterator"in Symbol,m;if(m="FileReader"in e&&"Blob"in e)try{new Blob,m=!0}catch(a){m=!1}var g={searchParams:"URLSearchParams"in e,iterable:D,
blob:m,formData:"FormData"in e,arrayBuffer:"ArrayBuffer"in e};if(g.arrayBuffer){var E="[object Int8Array];[object Uint8Array];[object Uint8ClampedArray];[object Int16Array];[object Uint16Array];[object Int32Array];[object Uint32Array];[object Float32Array];[object Float64Array]".split(";");var y=function(a){return a&&DataView.prototype.isPrototypeOf(a)};var z=ArrayBuffer.isView||function(a){return a&&-1<E.indexOf(Object.prototype.toString.call(a))}}d.prototype.append=function(a,b){a=l(a);b=q(b);var c=
this.map[a];this.map[a]=c?c+","+b:b};d.prototype["delete"]=function(a){delete this.map[l(a)]};d.prototype.get=function(a){a=l(a);return this.has(a)?this.map[a]:null};d.prototype.has=function(a){return this.map.hasOwnProperty(l(a))};d.prototype.set=function(a,b){this.map[l(a)]=q(b)};d.prototype.forEach=function(a,b){for(var c in this.map)this.map.hasOwnProperty(c)&&a.call(b,this.map[c],c,this)};d.prototype.keys=function(){var a=[];this.forEach(function(b,c){a.push(c)});return n(a)};d.prototype.values=
function(){var a=[];this.forEach(function(b){a.push(b)});return n(a)};d.prototype.entries=function(){var a=[];this.forEach(function(b,c){a.push([c,b])});return n(a)};g.iterable&&(d.prototype[Symbol.iterator]=d.prototype.entries);var B="DELETE GET HEAD OPTIONS POST PUT".split(" ");k.prototype.clone=function(){return new k(this,{body:this._bodyInit})};u.call(k.prototype);u.call(h.prototype);h.prototype.clone=function(){return new h(this._bodyInit,{status:this.status,statusText:this.statusText,headers:new d(this.headers),
url:this.url})};h.error=function(){var a=new h(null,{status:0,statusText:""});a.type="error";return a};var F=[301,302,303,307,308];h.redirect=function(a,b){if(-1===F.indexOf(b))throw new RangeError("Invalid status code");return new h(null,{status:b,headers:{location:a}})};e.Headers=d;e.Request=k;e.Response=h;e.fetch=function(a,b){return new Promise(function(c,d){var e=new k(a,b),f=new XMLHttpRequest;f.onload=function(){var a={status:f.status,statusText:f.statusText,headers:C(f.getAllResponseHeaders()||
"")};a.url="responseURL"in f?f.responseURL:a.headers.get("X-Request-URL");c(new h("response"in f?f.response:f.responseText,a))};f.onerror=function(){d(new TypeError("Network request failed"))};f.ontimeout=function(){d(new TypeError("Network request failed"))};f.open(e.method,e.url,!0);"include"===e.credentials?f.withCredentials=!0:"omit"===e.credentials&&(f.withCredentials=!1);"responseType"in f&&g.blob&&(f.responseType="blob");e.headers.forEach(function(a,b){f.setRequestHeader(b,a)});f.send("undefined"===
typeof e._bodyInit?null:e._bodyInit)})};e.fetch.polyfill=!0}})("undefined"!==typeof self?self:window);
/*! Built with http://stenciljs.com */
(function(Context,namespace,hydratedCssClass,resourcesUrl,s){"use strict";
s=document.querySelector("script[data-namespace='gx-web-controls']");if(s){resourcesUrl=s.getAttribute('data-resources-url');}
this && this._$__extends$_ || (Object.setPrototypeOf || {
  __proto__: []
} instanceof Array && function(e, n) {
  e.__proto__ = n;
} || function(e, n) {
  for (var t in n) n.hasOwnProperty(t) && (e[t] = n[t]);
}), function(e, n, t, r) {
  "use strict";
  /**
     * SSR Attribute Names
     */  function getScopeId(e, n) {
    return "sc-" + e._$tagNameMeta$_ + (n && n !== u ? "-" + n : "");
  }
  function getElementScopeId(e, n) {
    return e + (n ? "-h" : "-s");
  }
  function initStyleTemplate(e, n, t, r, o) {
    if (r) {
      // we got a style mode for this component, let's create an id for this style
      var i = n._$tagNameMeta$_ + (o || u);
      n[i] || (
      // ie11's template polyfill doesn't fully do the trick and there's still issues
      // so instead of trying to clone templates with styles in them, we'll just
      // keep a map of the style text as a string to create <style> elements for es5 builds
      n[i] = r);
    }
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
  function parsePropertyValue(e, n) {
    // ensure this value is of the correct prop type
    // we're testing both formats of the "propType" value because
    // we could have either gotten the data from the attribute changed callback,
    // which wouldn't have Constructor data yet, and because this method is reused
    // within proxy where we don't have meta data, but only constructor data
    if (f(n) && "object" != typeof n && "function" != typeof n) {
      if (e === Boolean || 3 /* Boolean */ === e) 
      // per the HTML spec, any string value means it is a boolean true value
      // but we'll cheat here and say that the string "false" is the boolean false
      return "false" !== n && ("" === n || !!n);
      if (e === Number || 4 /* Number */ === e) 
      // force it to be a number
      return parseFloat(n);
      if (e === String || 2 /* String */ === e) 
      // could have been passed as a number or boolean
      // but we still want it as a string
      return n.toString();
    }
    // not sure exactly what type we want
    // so no need to change to a different type
        return n;
  }
  function propagateComponentLoaded(e, n, t, r) {
    // load events fire from bottom to top
    // the deepest elements load first then bubbles up
    var o = e._$ancestorHostElementMap$_.get(n);
    o && (
    // ok so this element already has a known ancestor host element
    // let's make sure we remove this element from its ancestor's
    // known list of child elements which are actively loading
    (r = o["s-ld"] || o.$activeLoading) && ((t = r.indexOf(n)) > -1 && 
    // yup, this element is in the list of child elements to wait on
    // remove it so we can work to get the length down to 0
    r.splice(t, 1), 
    // the ancestor's initLoad method will do the actual checks
    // to see if the ancestor is actually loaded or not
    // then let's call the ancestor's initLoad method if there's no length
    // (which actually ends up as this method again but for the ancestor)
    r.length || (o["s-init"] && o["s-init"](), 
    // $initLoad deprecated 2018-04-02
    o.$initLoad && o.$initLoad())), e._$ancestorHostElementMap$_.delete(n));
  }
  /**
     * Production h() function based on Preact by
     * Jason Miller (@developit)
     * Licensed under the MIT License
     * https://github.com/developit/preact/blob/master/LICENSE
     *
     * Modified for Stencil's compiler and vdom
     */  function h(e, n) {
    for (var t, r, o = null, i = !1, u = !1, a = arguments.length; a-- > 2; ) p.push(arguments[a]);
    for (;p.length > 0; ) {
      var c = p.pop();
      if (c && void 0 !== c.pop) for (a = c.length; a--; ) p.push(c[a]); else "boolean" == typeof c && (c = null), 
      (u = "function" != typeof e) && (null == c ? c = "" : "number" == typeof c ? c = String(c) : "string" != typeof c && (u = !1)), 
      u && i ? o[o.length - 1].vtext += c : null === o ? o = [ u ? {
        vtext: c
      } : c ] : o.push(u ? {
        vtext: c
      } : c), i = u;
    }
    if (null != n) {
      if (
      // normalize class / classname attributes
      n.className && (n.class = n.className), "object" == typeof n.class) {
        for (a in n.class) n.class[a] && p.push(a);
        n.class = p.join(" "), p.length = 0;
      }
      null != n.key && (t = n.key), null != n.name && (r = n.name);
    }
    return "function" == typeof e ? e(Object.assign({}, n, {
      children: o
    }), d) : {
      vtag: e,
      vchildren: o,
      vtext: void 0,
      vattrs: n,
      vkey: t,
      vname: r,
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
  function queueUpdate(e, n) {
    // only run patch if it isn't queued already
    e._$isQueuedForUpdate$_.has(n) || (e._$isQueuedForUpdate$_.set(n, !0), 
    // run the patch in the next tick
    // vdom diff and patch the host element for differences
    e._$isAppLoaded$_ ? 
    // app has already loaded
    // let's queue this work in the dom write phase
    e.queue.write(function() {
      return update(e, n);
    }) : 
    // app hasn't finished loading yet
    // so let's use next tick to do everything
    // as fast as possible
    e.queue.tick(function() {
      return update(e, n);
    }));
  }
  function update(e, n, t, r, o, i) {
    // everything is async, so somehow we could have already disconnected
    // this node, so be sure to do nothing if we've already disconnected
    if (
    // no longer queued for update
    e._$isQueuedForUpdate$_.delete(n), !e._$isDisconnectedMap$_.has(n)) {
      if (r = e._$instanceMap$_.get(n), t = !r) {
        if ((o = e._$ancestorHostElementMap$_.get(n)) && o.$rendered && (
        // $rendered deprecated 2018-04-02
        o["s-rn"] = !0), o && !o["s-rn"]) 
        // this is the intial load
        // this element has an ancestor host element
        // but the ancestor host element has NOT rendered yet
        // so let's just cool our jets and wait for the ancestor to render
        return (o["s-rc"] = o["s-rc"] || []).push(function() {
          // this will get fired off when the ancestor host element
          // finally gets around to rendering its lazy self
          update(e, n);
        }), void (
        // $onRender deprecated 2018-04-02
        o.$onRender = o["s-rc"]);
        // haven't created a component instance for this host element yet!
        // create the instance from the user's component class
        // https://www.youtube.com/watch?v=olLxrojmvMg
                r = function initComponentInstance(e, n, t, r, o, i, u) {
          try {
            r = new (
            // using the user's component class, let's create a new instance
            o = e._$getComponentMeta$_(n)._$componentConstructor$_)(), 
            // ok cool, we've got an host element now, and a actual instance
            // and there were no errors creating the instance
            // let's upgrade the data on the host element
            // and let the getters/setters do their jobs
            function proxyComponentInstance(e, n, t, r, o, i, u) {
              // define each of the members and initialize what their role is
              for (u in 
              // at this point we've got a specific node of a host element, and created a component class instance
              // and we've already created getters/setters on both the host element and component class prototypes
              // let's upgrade any data that might have been set on the host element already
              // and let's have the getters/setters kick in and do their jobs
              // let's automatically add a reference to the host element on the instance
              e._$hostElementMap$_.set(r, t), 
              // create the values object if it doesn't already exist
              // this will hold all of the internal getter/setter values
              e._$valuesMap$_.has(t) || e._$valuesMap$_.set(t, {}), 
              // always set mode
              (
              // get the properties from the constructor
              // and add default "mode" and "color" properties
              i = Object.assign({
                color: {
                  type: String
                }
              }, n.properties)).mode = {
                type: String
              }, i) defineMember(e, i[u], t, r, u, o);
            }(e, o, n, r, t), 
            // add each of the event emitters which wire up instance methods
            // to fire off dom events from the host element
            function initEventEmitters(e, n, t) {
              if (n) {
                var r = e._$hostElementMap$_.get(t);
                n.forEach(function(n) {
                  t[n.method] = {
                    emit: function(t) {
                      e._$emitEvent$_(r, n.name, {
                        bubbles: n.bubbles,
                        composed: n.composed,
                        cancelable: n.cancelable,
                        detail: t
                      });
                    }
                  };
                });
              }
            }(e, o.events, r);
            try {
              if (
              // replay any event listeners on the instance that
              // were queued up between the time the element was
              // connected and before the instance was ready
              i = e._$queuedEvents$_.get(n)) {
                // events may have already fired before the instance was even ready
                // now that the instance is ready, let's replay all of the events that
                // we queued up earlier that were originally meant for the instance
                for (u = 0; u < i.length; u += 2) 
                // data was added in sets of two
                // first item the eventMethodName
                // second item is the event data
                // take a look at initElementListener()
                r[i[u]](i[u + 1]);
                e._$queuedEvents$_.delete(n);
              }
            } catch (t) {
              e._$onError$_(t, 2 /* QueueEventsError */ , n);
            }
          } catch (t) {
            // something done went wrong trying to create a component instance
            // create a dumby instance so other stuff can load
            // but chances are the app isn't fully working cuz this component has issues
            r = {}, e._$onError$_(t, 7 /* InitInstanceError */ , n, !0);
          }
          return e._$instanceMap$_.set(n, r), r;
        }(e, n, e._$hostSnapshotMap$_.get(n));
        // fire off the user's componentWillLoad method (if one was provided)
        // componentWillLoad only runs ONCE, after instance's element has been
        // assigned as the host element, but BEFORE render() has been called
        try {
          r.componentWillLoad && (i = r.componentWillLoad());
        } catch (t) {
          e._$onError$_(t, 3 /* WillLoadError */ , n);
        }
      } else 
      // already created an instance and this is an update
      // fire off the user's componentWillUpdate method (if one was provided)
      // componentWillUpdate runs BEFORE render() has been called
      // but only BEFORE an UPDATE and not before the intial render
      // get the returned promise (if one was provided)
      try {
        r.componentWillUpdate && (i = r.componentWillUpdate());
      } catch (t) {
        e._$onError$_(t, 5 /* WillUpdateError */ , n);
      }
      i && i.then ? 
      // looks like the user return a promise!
      // let's not actually kick off the render
      // until the user has resolved their promise
      i.then(function() {
        return renderUpdate(e, n, r, t);
      }) : 
      // user never returned a promise so there's
      // no need to wait on anything, let's do the render now my friend
      renderUpdate(e, n, r, t);
    }
  }
  function renderUpdate(e, n, t, r) {
    // if this component has a render function, let's fire
    // it off and generate a vnode for this
    (function render(e, n, t, r) {
      try {
        // if this component has a render function, let's fire
        // it off and generate the child vnodes for this host element
        // note that we do not create the host element cuz it already exists
        var o = n._$componentConstructor$_.host, i = n._$componentConstructor$_.encapsulation, u = "shadow" === i && e._$domApi$_._$$supportsShadowDom$_, a = void 0;
        if (u || (
        // not using, or can't use shadow dom
        // set the root element, which will be the shadow root when enabled
        a = t), !t["s-rn"]) {
          // attach the styles this component needs, if any
          // this fn figures out if the styles should go in a
          // shadow root or if they should be global
          e._$attachStyles$_(e, e._$domApi$_, n, t);
          // if no render function
          var c = t["s-sc"];
          c && (e._$domApi$_._$$addClass$_(t, getElementScopeId(c, !0)), r.render || e._$domApi$_._$$addClass$_(t, getElementScopeId(c)));
        }
        if (r.render || r.hostData || o) {
          // tell the platform we're actively rendering
          // if a value is changed within a render() then
          // this tells the platform not to queue the change
          e._$activeRender$_ = !0;
          var f, l = r.render && r.render();
          // user component provided a "hostData()" method
          // the returned data/attributes are used on the host element
          f = r.hostData && r.hostData(), 
          // tell the platform we're done rendering
          // now any changes will again queue
          e._$activeRender$_ = !1;
          // looks like we've got child nodes to render into this host element
          // or we need to update the css class/attrs on the host element
          // if we haven't already created a vnode, then we give the renderer the actual element
          // if this is a re-render, then give the renderer the last vnode we already created
          var s = e._$vnodeMap$_.get(t) || {};
          s._$elm$_ = a;
          var p = h(null, f, l);
          // each patch always gets a new vnode
          // the host element itself isn't patched because it already exists
          // kick off the actual render and any DOM updates
          e._$vnodeMap$_.set(t, e.render(t, s, p, u, i));
        }
        // update styles!
                e._$customStyle$_ && e._$customStyle$_._$updateHost$_(t), 
        // it's official, this element has rendered
        t["s-rn"] = !0, t.$onRender && (
        // $onRender deprecated 2018-04-02
        t["s-rc"] = t.$onRender), t["s-rc"] && (
        // ok, so turns out there are some child host elements
        // waiting on this parent element to load
        // let's fire off all update callbacks waiting
        t["s-rc"].forEach(function(e) {
          return e();
        }), t["s-rc"] = null);
      } catch (n) {
        e._$activeRender$_ = !1, e._$onError$_(n, 8 /* RenderError */ , t, !0);
      }
    })(e, e._$getComponentMeta$_(n), n, t);
    try {
      r ? 
      // so this was the initial load i guess
      n["s-init"]() : (
      // fire off the user's componentDidUpdate method (if one was provided)
      // componentDidUpdate runs AFTER render() has been called
      // but only AFTER an UPDATE and not after the intial render
      t.componentDidUpdate && t.componentDidUpdate(), callNodeRefs(e._$vnodeMap$_.get(n)));
    } catch (t) {
      // derp
      e._$onError$_(t, 6 /* DidUpdateError */ , n, !0);
    }
  }
  function defineMember(e, n, t, r, o, i, u, a) {
    if (n.type || n.state) {
      var c = e._$valuesMap$_.get(t);
      n.state || (!n.attr || void 0 !== c[o] && "" !== c[o] || 
      // check the prop value from the host element attribute
      (u = i && i._$$attributes$_) && f(a = u[n.attr]) && (
      // looks like we've got an attribute value
      // let's set it to our internal values
      c[o] = parsePropertyValue(n.type, a)), 
      // client-side
      // within the browser, the element's prototype
      // already has its getter/setter set, but on the
      // server the prototype is shared causing issues
      // so instead the server's elm has the getter/setter
      // directly on the actual element instance, not its prototype
      // so on the browser we can use "hasOwnProperty"
      t.hasOwnProperty(o) && (
      // @Prop or @Prop({mutable:true})
      // property values on the host element should override
      // any default values on the component instance
      void 0 === c[o] && (c[o] = parsePropertyValue(n.type, t[o])), 
      // for the client only, let's delete its "own" property
      // this way our already assigned getter/setter on the prototype kicks in
      // the very special case is to NOT do this for "mode"
      "mode" !== o && delete t[o])), r.hasOwnProperty(o) && void 0 === c[o] && (
      // @Prop() or @Prop({mutable:true}) or @State()
      // we haven't yet got a value from the above checks so let's
      // read any "own" property instance values already set
      // to our internal value as the source of getter data
      // we're about to define a property and it'll overwrite this "own" property
      c[o] = r[o]), n.watchCallbacks && (c[v + o] = n.watchCallbacks.slice()), 
      // add getter/setter to the component instance
      // these will be pointed to the internal data set from the above checks
      definePropertyGetterSetter(r, o, function getComponentProp(n) {
        // component instance prop/state getter
        // get the property value directly from our internal values
        return (n = e._$valuesMap$_.get(e._$hostElementMap$_.get(this))) && n[o];
      }, function setComponentProp(t, r) {
        // component instance prop/state setter (cannot be arrow fn)
        (r = e._$hostElementMap$_.get(this)) && (n.state || n.mutable) && setValue(e, r, o, t);
      });
    } else n.elementRef ? 
    // @Element()
    // add a getter to the element reference using
    // the member name the component meta provided
    definePropertyValue(r, o, t) : n.method && 
    // @Method()
    // add a property "value" on the host element
    // which we'll bind to the instance's method
    definePropertyValue(t, o, r[o].bind(r));
  }
  function setValue(e, n, t, r, o, i, u) {
    (
    // get the internal values object, which should always come from the host element instance
    // create the _values object if it doesn't already exist
    o = e._$valuesMap$_.get(n)) || e._$valuesMap$_.set(n, o = {});
    var a = o[t];
    // check our new property value against our internal value
        if (r !== a && (
    // gadzooks! the property's value has changed!!
    // set our new value!
    // https://youtu.be/dFtLONl4cNc?t=22
    o[t] = r, i = e._$instanceMap$_.get(n))) {
      if (
      // get an array of method names of watch functions to call
      u = o[v + t]) 
      // this instance is watching for when this property changed
      for (var c = 0; c < u.length; c++) try {
        // fire off each of the watch methods that are watching this property
        i[u[c]].call(i, r, a, t);
      } catch (e) {
        console.error(e);
      }
      !e._$activeRender$_ && n["s-rn"] && 
      // looks like this value actually changed, so we've got work to do!
      // but only if we've already rendered, otherwise just chill out
      // queue that we need to do an update, but don't worry about queuing
      // up millions cuz this function ensures it only runs once
      queueUpdate(e, n);
    }
  }
  function definePropertyValue(e, n, t) {
    // minification shortcut
    Object.defineProperty(e, n, {
      configurable: !0,
      value: t
    });
  }
  function definePropertyGetterSetter(e, n, t, r) {
    // minification shortcut
    Object.defineProperty(e, n, {
      configurable: !0,
      get: t,
      set: r
    });
  }
  function setAccessor(e, n, t, r, o, i, u) {
    if ("class" !== t || i) if ("style" === t) {
      // update style attribute, css properties and values
      for (var a in r) o && null != o[a] || (/-/.test(a) ? n.style._$removeProperty$_(a) : n.style[a] = "");
      for (var a in o) r && o[a] === r[a] || (/-/.test(a) ? n.style.setProperty(a, o[a]) : n.style[a] = o[a]);
    } else if ("o" !== t[0] || "n" !== t[1] || !/[A-Z]/.test(t[2]) || t in n) if ("list" !== t && "type" !== t && !i && (t in n || -1 !== [ "object", "function" ].indexOf(typeof o) && null !== o)) {
      // Properties
      // - list and type are attributes that get applied as values on the element
      // - all svgs get values as attributes not props
      // - check if elm contains name or if the value is array, object, or function
      var c = e._$getComponentMeta$_(n);
      c && c._$membersMeta$_ && c._$membersMeta$_[t] ? 
      // we know for a fact that this element is a known component
      // and this component has this member name as a property,
      // let's set the known @Prop on this element
      // set it directly as property on the element
      setProperty(n, t, o) : "ref" !== t && (
      // this member name is a property on this element, but it's not a component
      // this is a native property like "value" or something
      // also we can ignore the "ref" member name at this point
      setProperty(n, t, null == o ? "" : o), null != o && !1 !== o || e._$domApi$_._$$removeAttribute$_(n, t));
    } else null != o && "key" !== t ? 
    // Element Attributes
    function updateAttribute(e, n, t, r) {
      void 0 === r && (r = "boolean" == typeof t);
      var o = n !== (n = n.replace(/^xlink\:?/, ""));
      null == t || r && (!t || "false" === t) ? o ? e.removeAttributeNS(m, l(n)) : e.removeAttribute(n) : "function" != typeof t && (t = r ? "" : t.toString(), 
      o ? e.setAttributeNS(m, l(n), t) : e.setAttribute(n, t));
    }(n, t, o) : (i || e._$domApi$_._$$hasAttribute$_(n, t) && (null == o || !1 === o)) && 
    // remove svg attribute
    e._$domApi$_._$$removeAttribute$_(n, t); else 
    // Event Handlers
    // so if the member name starts with "on" and the 3rd characters is
    // a capital letter, and it's not already a member on the element,
    // then we're assuming it's an event listener
    // standard event
    // the JSX attribute could have been "onMouseOver" and the
    // member name "onmouseover" is on the element's prototype
    // so let's add the listener "mouseover", which is all lowercased
    t = l(t) in n ? l(t.substring(2)) : l(t[2]) + t.substring(3), o ? o !== r && 
    // add listener
    e._$domApi$_._$$addEventListener$_(n, t, o) : 
    // remove listener
    e._$domApi$_._$$removeEventListener$_(n, t); else 
    // Class
    if (r !== o) {
      var f = parseClassList(r), s = parseClassList(o), p = f.filter(function(e) {
        return !s.includes(e);
      }), d = parseClassList(n.className).filter(function(e) {
        return !p.includes(e);
      }), v = s.filter(function(e) {
        return !f.includes(e) && !d.includes(e);
      });
      d.push.apply(d, v), n.className = d.join(" ");
    }
  }
  function parseClassList(e) {
    return null == e || "" === e ? [] : e.trim().split(/\s+/);
  }
  /**
     * Attempt to set a DOM property to the given value.
     * IE & FF throw for certain property-value combinations.
     */  function setProperty(e, n, t) {
    try {
      e[n] = t;
    } catch (e) {}
  }
  function updateElement(e, n, t, r, o) {
    // if the element passed in is a shadow root, which is a document fragment
    // then we want to be adding attrs/props to the shadow root's "host" element
    // if it's not a shadow root, then we add attrs/props to the same element
    var i = 11 /* DocumentFragment */ === t._$elm$_.nodeType && t._$elm$_.host ? t._$elm$_.host : t._$elm$_, u = n && n.vattrs || a, c = t.vattrs || a;
    // remove attributes no longer present on the vnode by setting them to undefined
    for (o in u) c && null != c[o] || null == u[o] || setAccessor(e, i, o, u[o], void 0, r, t._$ishost$_);
    // add new & update changed attributes
        for (o in c) o in u && c[o] === ("value" === o || "checked" === o ? i[o] : u[o]) || setAccessor(e, i, o, u[o], c[o], r, t._$ishost$_);
  }
  function createRendererPatch(e, n) {
    // createRenderer() is only created once per app
    // the patch() function which createRenderer() returned is the function
    // which gets called numerous times by each component
    function createElm(o, c, l, s, p, d, v, m, h) {
      if (m = c.vchildren[l], t || (
      // remember for later we need to check to relocate nodes
      i = !0, "slot" === m.vtag && (r && 
      // scoped css needs to add its scoped id to the parent element
      n._$$addClass$_(s, r + "-s"), m.vchildren ? 
      // slot element has fallback content
      // still create an element that "mocks" the slot element
      m._$isSlotFallback$_ = !0 : 
      // slot element does not have fallback content
      // create an html comment we'll use to always reference
      // where actual slot content should sit next to
      m._$isSlotReference$_ = !0)), f(m.vtext)) 
      // create text node
      m._$elm$_ = n._$$createTextNode$_(m.vtext); else if (m._$isSlotReference$_) 
      // create a slot reference html text node
      m._$elm$_ = n._$$createTextNode$_(""); else {
        if (
        // create element
        d = m._$elm$_ = y || "svg" === m.vtag ? n._$$createElementNS$_("http://www.w3.org/2000/svg", m.vtag) : n._$$createElement$_(m._$isSlotFallback$_ ? "slot-fb" : m.vtag), 
        y = "svg" === m.vtag || "foreignObject" !== m.vtag && y, 
        // add css classes, attrs, props, listeners, etc.
        updateElement(e, null, m, y), f(r) && d["s-si"] !== r && 
        // if there is a scopeId and this is the initial render
        // then let's add the scopeId as an attribute
        n._$$addClass$_(d, d["s-si"] = r), m.vchildren) for (p = 0; p < m.vchildren.length; ++p) 
        // create the node
        // return node could have been null
        (v = createElm(o, m, p, d)) && 
        // append our new node
        n._$$appendChild$_(d, v);
        "svg" === m.vtag && (
        // Only reset the SVG context when we're exiting SVG element
        y = !1);
      }
      return m._$elm$_["s-hn"] = u, (m._$isSlotFallback$_ || m._$isSlotReference$_) && (
      // remember the content reference comment
      m._$elm$_["s-sr"] = !0, 
      // remember the content reference comment
      m._$elm$_["s-cr"] = a, 
      // remember the slot name, or empty string for default slot
      m._$elm$_["s-sn"] = m.vname || "", (
      // check if we've got an old vnode for this slot
      h = o && o.vchildren && o.vchildren[l]) && h.vtag === m.vtag && o._$elm$_ && 
      // we've got an old slot vnode and the wrapper is being replaced
      // so let's move the old slot content back to it's original location
      putBackInOriginalLocation(o._$elm$_)), m._$elm$_;
    }
    function putBackInOriginalLocation(t, r, o, a) {
      e._$tmpDisconnected$_ = !0;
      var c = n._$$childNodes$_(t);
      for (o = c.length - 1; o >= 0; o--) (a = c[o])["s-hn"] !== u && a["s-ol"] && (
      // this child node in the old element is from another component
      // remove this node from the old slot's parent
      n._$$remove$_(a), 
      // and relocate it back to it's original location
      n._$$insertBefore$_(parentReferenceNode(a), a, referenceNode(a)), 
      // remove the old original location comment entirely
      // later on the patch function will know what to do
      // and move this to the correct spot in need be
      n._$$remove$_(a["s-ol"]), a["s-ol"] = null, i = !0), r && putBackInOriginalLocation(a, r);
      e._$tmpDisconnected$_ = !1;
    }
    function addVnodes(e, t, r, o, i, a, c, l) {
      // $defaultHolder deprecated 2018-04-02
      var s = e["s-cr"] || e.$defaultHolder;
      for ((c = s && n._$$parentNode$_(s) || e).shadowRoot && n._$$tagName$_(c) === u && (c = c.shadowRoot); i <= a; ++i) o[i] && (l = f(o[i].vtext) ? n._$$createTextNode$_(o[i].vtext) : createElm(null, r, i, e)) && (o[i]._$elm$_ = l, 
      n._$$insertBefore$_(c, l, referenceNode(t)));
    }
    function removeVnodes(e, t, r, i) {
      for (;t <= r; ++t) f(e[t]) && (i = e[t]._$elm$_, 
      // we're removing this element
      // so it's possible we need to show slot fallback content now
      o = !0, i["s-ol"] ? 
      // remove the original location comment
      n._$$remove$_(i["s-ol"]) : 
      // it's possible that child nodes of the node
      // that's being removed are slot nodes
      putBackInOriginalLocation(i, !0), 
      // remove the vnode's element from the dom
      n._$$remove$_(i));
    }
    function isSameVnode(e, n) {
      // compare if two vnode to see if they're "technically" the same
      // need to have the same element tag, and same key to be the same
      return e.vtag === n.vtag && e.vkey === n.vkey && ("slot" !== e.vtag || e.vname === n.vname);
    }
    function referenceNode(e) {
      return e && e["s-ol"] ? e["s-ol"] : e;
    }
    function parentReferenceNode(e) {
      return n._$$parentNode$_(e["s-ol"] ? e["s-ol"] : e);
    }
    var t, r, o, i, u, a, c = [];
    return function patch(l, s, p, d, v, m, h, g, b, S, C, k) {
      if (
      // patchVNode() is synchronous
      // so it is safe to set these variables and internally
      // the same patch() call will reference the same data
      u = n._$$tagName$_(l), a = l["s-cr"], t = d, 
      // get the scopeId
      r = l["s-sc"], 
      // always reset
      i = o = !1, 
      // synchronous patch
      function patchVNode(t, r, o) {
        var i = r._$elm$_ = t._$elm$_, u = t.vchildren, a = r.vchildren;
        // test if we're rendering an svg element, or still rendering nodes inside of one
        // only add this to the when the compiler sees we're using an svg somewhere
        y = r._$elm$_ && f(n._$$parentElement$_(r._$elm$_)) && void 0 !== r._$elm$_.ownerSVGElement, 
        y = "svg" === r.vtag || "foreignObject" !== r.vtag && y, f(r.vtext) ? (o = i["s-cr"] || i.$defaultHolder /* $defaultHolder deprecated 2018-04-02 */) ? 
        // this element has slotted content
        n._$$setTextContent$_(n._$$parentNode$_(o), r.vtext) : t.vtext !== r.vtext && 
        // update the text content for the text only vnode
        // and also only if the text is different than before
        n._$$setTextContent$_(i, r.vtext) : (
        // element node
        "slot" !== r.vtag && 
        // either this is the first render of an element OR it's an update
        // AND we already know it's possible it could have changed
        // this updates the element's css classes, attrs, props, listeners, etc.
        updateElement(e, t, r, y), f(u) && f(a) ? 
        // looks like there's child vnodes for both the old and new vnodes
        function updateChildren(e, t, r, o, i, u, a, c) {
          for (var l = 0, s = 0, p = t.length - 1, d = t[0], v = t[p], m = o.length - 1, h = o[0], y = o[m]; l <= p && s <= m; ) if (null == d) 
          // Vnode might have been moved left
          d = t[++l]; else if (null == v) v = t[--p]; else if (null == h) h = o[++s]; else if (null == y) y = o[--m]; else if (isSameVnode(d, h)) patchVNode(d, h), 
          d = t[++l], h = o[++s]; else if (isSameVnode(v, y)) patchVNode(v, y), v = t[--p], 
          y = o[--m]; else if (isSameVnode(d, y)) 
          // Vnode moved right
          "slot" !== d.vtag && "slot" !== y.vtag || putBackInOriginalLocation(n._$$parentNode$_(d._$elm$_)), 
          patchVNode(d, y), n._$$insertBefore$_(e, d._$elm$_, n._$$nextSibling$_(v._$elm$_)), 
          d = t[++l], y = o[--m]; else if (isSameVnode(v, h)) 
          // Vnode moved left
          "slot" !== d.vtag && "slot" !== y.vtag || putBackInOriginalLocation(n._$$parentNode$_(v._$elm$_)), 
          patchVNode(v, h), n._$$insertBefore$_(e, v._$elm$_, d._$elm$_), v = t[--p], h = o[++s]; else {
            for (
            // createKeyToOldIdx
            i = null, u = l; u <= p; ++u) if (t[u] && f(t[u].vkey) && t[u].vkey === h.vkey) {
              i = u;
              break;
            }
            f(i) ? ((c = t[i]).vtag !== h.vtag ? a = createElm(t && t[s], r, i, e) : (patchVNode(c, h), 
            t[i] = void 0, a = c._$elm$_), h = o[++s]) : (
            // new element
            a = createElm(t && t[s], r, s, e), h = o[++s]), a && n._$$insertBefore$_(parentReferenceNode(d._$elm$_), a, referenceNode(d._$elm$_));
          }
          l > p ? addVnodes(e, null == o[m + 1] ? null : o[m + 1]._$elm$_, r, o, s, m) : s > m && removeVnodes(t, l, p);
        }(i, u, r, a) : f(a) ? (
        // no old child vnodes, but there are new child vnodes to add
        f(t.vtext) && 
        // the old vnode was text, so be sure to clear it out
        n._$$setTextContent$_(i, ""), 
        // add the new vnode children
        addVnodes(i, null, r, a, 0, a.length - 1)) : f(u) && 
        // no new child vnodes, but there are old child vnodes to remove
        removeVnodes(u, 0, u.length - 1)), 
        // reset svgMode when svg node is fully patched
        y && "svg" === r.vtag && (y = !1);
      }(s, p), i) {
        for (function relocateSlotContent(e, t, r, i, u, a, f, l, s, p) {
          for (u = 0, a = (t = n._$$childNodes$_(e)).length; u < a; u++) {
            if ((r = t[u])["s-sr"] && (i = r["s-cr"])) for (
            // first got the content reference comment node
            // then we got it's parent, which is where all the host content is in now
            l = n._$$childNodes$_(n._$$parentNode$_(i)), s = r["s-sn"], f = l.length - 1; f >= 0; f--) (i = l[f])["s-cn"] || i["s-nr"] || i["s-hn"] === r["s-hn"] || ((3 /* TextNode */ === (
            // let's do some relocating to its new home
            // but never relocate a content reference node
            // that is suppose to always represent the original content location
            p = n._$$nodeType$_(i)) || 8 /* CommentNode */ === p) && "" === s || 1 /* ElementNode */ === p && null === n._$$getAttribute$_(i, "slot") && "" === s || 1 /* ElementNode */ === p && n._$$getAttribute$_(i, "slot") === s) && (
            // it's possible we've already decided to relocate this node
            c.some(function(e) {
              return e._$nodeToRelocate$_ === i;
            }) || (
            // made some changes to slots
            // let's make sure we also double check
            // fallbacks are correctly hidden or shown
            o = !0, i["s-sn"] = s, 
            // add to our list of nodes to relocate
            c.push({
              _$slotRefNode$_: r,
              _$nodeToRelocate$_: i
            })));
            1 /* ElementNode */ === n._$$nodeType$_(r) && relocateSlotContent(r);
          }
        }
        // internal variables to be reused per patch() call
        (p._$elm$_), h = 0; h < c.length; h++) (g = c[h])._$nodeToRelocate$_["s-ol"] || (
        // add a reference node marking this node's original location
        // keep a reference to this node for later lookups
        (b = n._$$createTextNode$_(""))["s-nr"] = g._$nodeToRelocate$_, n._$$insertBefore$_(n._$$parentNode$_(g._$nodeToRelocate$_), g._$nodeToRelocate$_["s-ol"] = b, g._$nodeToRelocate$_));
        // while we're moving nodes around existing nodes, temporarily disable
        // the disconnectCallback from working
                for (e._$tmpDisconnected$_ = !0, h = 0; h < c.length; h++) {
          for (g = c[h], 
          // by default we're just going to insert it directly
          // after the slot reference node
          C = n._$$parentNode$_(g._$slotRefNode$_), k = n._$$nextSibling$_(g._$slotRefNode$_), 
          b = g._$nodeToRelocate$_["s-ol"]; b = n._$$previousSibling$_(b); ) if ((S = b["s-nr"]) && S && S["s-sn"] === g._$nodeToRelocate$_["s-sn"] && C === n._$$parentNode$_(S) && (S = n._$$nextSibling$_(S)) && S && !S["s-nr"]) {
            k = S;
            break;
          }
          (!k && C !== n._$$parentNode$_(g._$nodeToRelocate$_) || n._$$nextSibling$_(g._$nodeToRelocate$_) !== k) && g._$nodeToRelocate$_ !== k && (
          // remove the node from the dom
          n._$$remove$_(g._$nodeToRelocate$_), 
          // add it back to the dom but in its new home
          n._$$insertBefore$_(C, g._$nodeToRelocate$_, k));
        }
        // done moving nodes around
        // allow the disconnect callback to work again
                e._$tmpDisconnected$_ = !1;
      }
      // return our new vnode
      return o && function updateFallbackSlotVisibility(e, t, r, o, i, u, a, c) {
        for (o = 0, i = (r = n._$$childNodes$_(e)).length; o < i; o++) if (t = r[o], 1 /* ElementNode */ === n._$$nodeType$_(t)) {
          if (t["s-sr"]) for (
          // this is a slot fallback node
          // get the slot name for this slot reference node
          a = t["s-sn"], 
          // by default always show a fallback slot node
          // then hide it if there are other slots in the light dom
          t.hidden = !1, u = 0; u < i; u++) if (r[u]["s-hn"] !== t["s-hn"]) if (
          // this sibling node is from a different component
          c = n._$$nodeType$_(r[u]), "" !== a) {
            // this is a named fallback slot node
            if (1 /* ElementNode */ === c && a === n._$$getAttribute$_(r[u], "slot")) {
              t.hidden = !0;
              break;
            }
          } else 
          // this is a default fallback slot node
          // any element or text node (with content)
          // should hide the default fallback slot node
          if (1 /* ElementNode */ === c || 3 /* TextNode */ === c && "" !== n._$$getTextContent$_(r[u]).trim()) {
            t.hidden = !0;
            break;
          }
          // keep drilling down
                    updateFallbackSlotVisibility(t);
        }
      }(p._$elm$_), 
      // always reset
      c.length = 0, p;
    };
  }
  function callNodeRefs(e, n) {
    e && (e.vattrs && e.vattrs.ref && e.vattrs.ref(n ? null : e._$elm$_), e.vchildren && e.vchildren.forEach(function(e) {
      callNodeRefs(e, n);
    }));
  }
  function addChildSsrVNodes(e, n, t, r, o) {
    var u, a, c, f, l = e._$$nodeType$_(n);
    if (o && 1 /* ElementNode */ === l) {
      (a = e._$$getAttribute$_(n, i)) && (
      // split the start comment's data with a period
      c = a.split("."))[0] === r && (
      // cool, this element is a child to the parent vnode
      (f = {}).vtag = e._$$tagName$_(f._$elm$_ = n), 
      // this is a new child vnode
      // so ensure its parent vnode has the vchildren array
      t.vchildren || (t.vchildren = []), 
      // add our child vnode to a specific index of the vnode's children
      t.vchildren[c[1]] = f, 
      // this is now the new parent vnode for all the next child checks
      t = f, 
      // if there's a trailing period, then it means there aren't any
      // more nested elements, but maybe nested text nodes
      // either way, don't keep walking down the tree after this next call
      o = "" !== c[2]);
      // keep drilling down through the elements
            for (var s = 0; s < n.childNodes.length; s++) addChildSsrVNodes(e, n.childNodes[s], t, r, o);
    } else 3 /* TextNode */ === l && (u = n.previousSibling) && 8 /* CommentNode */ === e._$$nodeType$_(u) && "s" === (
    // split the start comment's data with a period
    c = e._$$getTextContent$_(u).split("."))[0] && c[1] === r && (
    // cool, this is a text node and it's got a start comment
    (f = {
      vtext: e._$$getTextContent$_(n)
    })._$elm$_ = n, 
    // this is a new child vnode
    // so ensure its parent vnode has the vchildren array
    t.vchildren || (t.vchildren = []), 
    // add our child vnode to a specific index of the vnode's children
    t.vchildren[c[2]] = f);
  }
  function initHostElement(e, n, t, r) {
    // let's wire up our functions to the host element's prototype
    // we can also inject our platform into each one that needs that api
    // note: these cannot be arrow functions cuz "this" is important here hombre
    t.connectedCallback = function() {
      // coolsville, our host element has just hit the DOM
      (function connectedCallback(e, n, t) {
        // initialize our event listeners on the host element
        // we do this now so that we can listening to events that may
        // have fired even before the instance is ready
        e._$hasListenersMap$_.has(t) || (
        // it's possible we've already connected
        // then disconnected
        // and the same element is reconnected again
        e._$hasListenersMap$_.set(t, !0), function initElementListeners(e, n) {
          // so the element was just connected, which means it's in the DOM
          // however, the component instance hasn't been created yet
          // but what if an event it should be listening to get emitted right now??
          // let's add our listeners right now to our element, and if it happens
          // to receive events between now and the instance being created let's
          // queue up all of the event data and fire it off on the instance when it's ready
          var t = e._$getComponentMeta$_(n);
          t._$listenersMeta$_ && 
          // we've got listens
          t._$listenersMeta$_.forEach(function(t) {
            // go through each listener
            t._$eventDisabled$_ || 
            // only add ones that are not already disabled
            e._$domApi$_._$$addEventListener$_(n, t._$eventName$_, function createListenerCallback(e, n, t, r) {
              // create the function that gets called when the element receives
              // an event which it should be listening for
              return function(o) {
                // get the instance if it exists
                (r = e._$instanceMap$_.get(n)) ? 
                // instance is ready, let's call it's member method for this event
                r[t](o) : (
                // instance is not ready!!
                // let's queue up this event data and replay it later
                // when the instance is ready
                (r = e._$queuedEvents$_.get(n) || []).push(t, o), e._$queuedEvents$_.set(n, r));
              };
            }(e, n, t._$eventMethodName$_), t._$eventCapture$_, t._$eventPassive$_);
          });
        }(e, t)), 
        // this element just connected, which may be re-connecting
        // ensure we remove it from our map of disconnected
        e._$isDisconnectedMap$_.delete(t), e._$hasConnectedMap$_.has(t) || (
        // first time we've connected
        e._$hasConnectedMap$_.set(t, !0), t["s-id"] || (
        // assign a unique id to this host element
        // it's possible this was already given an element id
        t["s-id"] = e._$nextId$_()), 
        // register this component as an actively
        // loading child to its parent component
        function registerWithParentComponent(e, n, t) {
          for (
          // find the first ancestor host element (if there is one) and register
          // this element as one of the actively loading child elements for its ancestor
          t = n; t = e._$domApi$_._$$parentElement$_(t); ) 
          // climb up the ancestors looking for the first registered component
          if (e._$isDefinedComponent$_(t)) {
            // we found this elements the first ancestor host element
            // if the ancestor already loaded then do nothing, it's too late
            e._$hasLoadedMap$_.has(n) || (
            // keep a reference to this element's ancestor host element
            // elm._ancestorHostElement = ancestorHostElement;
            e._$ancestorHostElementMap$_.set(n, t), 
            // ensure there is an array to contain a reference to each of the child elements
            // and set this element as one of the ancestor's child elements it should wait on
            t.$activeLoading && (
            // $activeLoading deprecated 2018-04-02
            t["s-ld"] = t.$activeLoading), (t["s-ld"] = t["s-ld"] || []).push(n));
            break;
          }
        }(e, t), 
        // add to the queue to load the bundle
        // it's important to have an async tick in here so we can
        // ensure the "mode" attribute has been added to the element
        // place in high priority since it's not much work and we need
        // to know as fast as possible, but still an async tick in between
        e.queue.tick(function() {
          // start loading this component mode's bundle
          // if it's already loaded then the callback will be synchronous
          e._$hostSnapshotMap$_.set(t, function initHostSnapshot(e, n, t, r, i) {
            // the host element has connected to the dom
            // and we've waited a tick to make sure all frameworks
            // have finished adding attributes and child nodes to the host
            // before we go all out and hydrate this beast
            // let's first take a snapshot of its original layout before render
            return t.mode || (
            // looks like mode wasn't set as a property directly yet
            // first check if there's an attribute
            // next check the app's global
            t.mode = e._$$getMode$_(t)), 
            // if the slot polyfill is required we'll need to put some nodes
            // in here to act as original content anchors as we move nodes around
            // host element has been connected to the DOM
            t["s-cr"] || e._$$getAttribute$_(t, o) || e._$$supportsShadowDom$_ && 1 /* ShadowDom */ === n._$encapsulationMeta$_ || (
            // only required when we're NOT using native shadow dom (slot)
            // or this browser doesn't support native shadow dom
            // and this host element was NOT created with SSR
            // let's pick out the inner content for slot projection
            // create a node to represent where the original
            // content was first placed, which is useful later on
            t["s-cr"] = e._$$createTextNode$_(""), t["s-cr"]["s-cn"] = !0, e._$$insertBefore$_(t, t["s-cr"], e._$$childNodes$_(t)[0])), 
            e._$$supportsShadowDom$_ || 1 /* ShadowDom */ !== n._$encapsulationMeta$_ || (t.shadowRoot = t), 
            // create a host snapshot object we'll
            // use to store all host data about to be read later
            r = {
              _$$id$_: t["s-id"],
              _$$attributes$_: {}
            }, 
            // loop through and gather up all the original attributes on the host
            // this is useful later when we're creating the component instance
            n._$membersMeta$_ && Object.keys(n._$membersMeta$_).forEach(function(o) {
              (i = n._$membersMeta$_[o]._$attribName$_) && (r._$$attributes$_[i] = e._$$getAttribute$_(t, i));
            }), r;
          }(e._$domApi$_, n, t)), e._$requestBundle$_(n, t);
        }));
      })(e, n, this);
    }, t.attributeChangedCallback = function(e, t, r) {
      // the browser has just informed us that an attribute
      // on the host element has changed
      (function attributeChangedCallback(e, n, t, r, o, i, u) {
        // only react if the attribute values actually changed
        if (e && r !== o) 
        // using the known component meta data
        // look up to see if we have a property wired up to this attribute name
        for (i in e) 
        // normalize the attribute name w/ lower case
        if ((u = e[i])._$attribName$_ && l(u._$attribName$_) === l(t)) {
          // cool we've got a prop using this attribute name, the value will
          // be a string, so let's convert it to the correct type the app wants
          n[i] = parsePropertyValue(u._$propType$_, o);
          break;
        }
      })(n._$membersMeta$_, this, e, t, r);
    }, t.disconnectedCallback = function() {
      // the element has left the builing
      (function disconnectedCallback(e, n) {
        // only disconnect if we're not temporarily disconnected
        // tmpDisconnected will happen when slot nodes are being relocated
        if (!e._$tmpDisconnected$_ && function isDisconnected(e, n) {
          for (;n; ) {
            if (!e._$$parentNode$_(n)) return 9 /* DocumentNode */ !== e._$$nodeType$_(n);
            n = e._$$parentNode$_(n);
          }
        }(e._$domApi$_, n)) {
          // ok, let's officially destroy this thing
          // set this to true so that any of our pending async stuff
          // doesn't continue since we already decided to destroy this node
          // elm._hasDestroyed = true;
          e._$isDisconnectedMap$_.set(n, !0), 
          // double check that we've informed the ancestor host elements
          // that they're good to go and loaded (cuz this one is on its way out)
          propagateComponentLoaded(e, n), 
          // since we're disconnecting, call all of the JSX ref's with null
          callNodeRefs(e._$vnodeMap$_.get(n), !0), 
          // detatch any event listeners that may have been added
          // because we're not passing an exact event name it'll
          // remove all of this element's event, which is good
          e._$domApi$_._$$removeEventListener$_(n), e._$hasListenersMap$_.delete(n);
          // call instance componentDidUnload
          // if we've created an instance for this
          var t = e._$instanceMap$_.get(n);
          t && 
          // call the user's componentDidUnload if there is one
          t.componentDidUnload && t.componentDidUnload(), 
          // clear CSS var-shim tracking
          e._$customStyle$_ && e._$customStyle$_._$removeHost$_(n), 
          // clear any references to other elements
          // more than likely we've already deleted these references
          // but let's double check there pal
          [ e._$ancestorHostElementMap$_, e._$onReadyCallbacksMap$_, e._$hostSnapshotMap$_ ].forEach(function(e) {
            return e.delete(n);
          });
        }
      })(e, this);
    }, t["s-init"] = function() {
      (function initComponentLoaded(e, n, t, r, o) {
        if (function allChildrenHaveConnected(e, n) {
          // Note: in IE11 <svg> does not have the "children" property
          for (var t = 0; t < n.childNodes.length; t++) if (1 /* ElementNode */ === n.childNodes[t].nodeType) {
            if (e._$getComponentMeta$_(n.childNodes[t]) && !e._$hasConnectedMap$_.has(n.childNodes[t])) 
            // this is a defined componnent
            // but it hasn't connected yet
            return !1;
            if (!allChildrenHaveConnected(e, n.childNodes[t])) 
            // one of the defined child components hasn't connected yet
            return !1;
          }
          // everything has connected, we're good
                    return !0;
        }(e, n) && !e._$hasLoadedMap$_.has(n) && (r = e._$instanceMap$_.get(n)) && !e._$isDisconnectedMap$_.has(n) && (!n["s-ld"] || !n["s-ld"].length)) {
          // cool, so at this point this element isn't already being destroyed
          // and it does not have any child elements that are still loading
          // ensure we remove any child references cuz it doesn't matter at this point
          delete n["s-ld"], 
          // sweet, this particular element is good to go
          // all of this element's children have loaded (if any)
          // elm._hasLoaded = true;
          e._$hasLoadedMap$_.set(n, !0);
          try {
            // fire off the ref if it exists
            callNodeRefs(e._$vnodeMap$_.get(n)), 
            // fire off the user's elm.componentOnReady() callbacks that were
            // put directly on the element (well before anything was ready)
            (o = e._$onReadyCallbacksMap$_.get(n)) && (o.forEach(function(e) {
              return e(n);
            }), e._$onReadyCallbacksMap$_.delete(n)), 
            // fire off the user's componentDidLoad method (if one was provided)
            // componentDidLoad only runs ONCE, after the instance's element has been
            // assigned as the host element, and AFTER render() has been called
            // we'll also fire this method off on the element, just to
            r.componentDidLoad && r.componentDidLoad();
          } catch (t) {
            e._$onError$_(t, 4 /* DidLoadError */ , n);
          }
          // add the css class that this element has officially hydrated
                    e._$domApi$_._$$addClass$_(n, t), 
          // ( •_•)
          // ( •_•)>⌐■-■
          // (⌐■_■)
          // load events fire from bottom to top
          // the deepest elements load first then bubbles up
          propagateComponentLoaded(e, n);
        }
        // all is good, this component has been told it's time to finish loading
        // it's possible that we've already decided to destroy this element
        // check if this element has any actively loading child elements
            })(e, this, r);
    }, t.forceUpdate = function() {
      queueUpdate(e, this);
    }, 
    // add getters/setters to the host element members
    // these would come from the @Prop and @Method decorators that
    // should create the public API to this component
    function proxyHostElementPrototype(e, n, t) {
      n && Object.keys(n).forEach(function(r) {
        // add getters/setters
        var o = n[r], i = o._$memberType$_;
        1 /* Prop */ === i || 2 /* PropMutable */ === i ? 
        // @Prop() or @Prop({ mutable: true })
        definePropertyGetterSetter(t, r, function getHostElementProp() {
          // host element getter (cannot be arrow fn)
          // yup, ugly, srynotsry
          return (e._$valuesMap$_.get(this) || {})[r];
        }, function setHostElementProp(n) {
          // host element setter (cannot be arrow fn)
          setValue(e, this, r, parsePropertyValue(o._$propType$_, n));
        }) : 6 /* Method */ === i && 
        // @Method()
        // add a placeholder noop value on the host element's prototype
        // incase this method gets called before setup
        definePropertyValue(t, r, s);
      });
    }(e, n._$membersMeta$_, t);
  }
  function proxyProp(e, n, t, r) {
    return function() {
      var o = arguments;
      return function loadComponent(e, n, t) {
        var r = n[t], o = e._$$doc$_.body;
        return o ? (r || (r = o.querySelector(t)), r || (r = n[t] = e._$$createElement$_(t), 
        e._$$appendChild$_(o, r)), r.componentOnReady()) : Promise.resolve();
      }(e, n, t).then(function(e) {
        return e[r].apply(e, o);
      });
    };
  }
  function findRegex(e, n, t) {
    e.lastIndex = 0;
    var r = n.substring(t).match(e);
    if (r) {
      var o = t + r.index;
      return {
        start: o,
        end: o + r[0].length
      };
    }
    return null;
  }
  function compileVar(e, n, t) {
    var r = function parseVar(e, n) {
      var t = findRegex(L, e, n);
      if (!t) return null;
      var r = function findVarEndIndex(e, n) {
        for (var t = 0, r = n; r < e.length; r++) {
          var o = e[r];
          if ("(" === o) t++; else if (")" === o && --t <= 0) return r + 1;
        }
        return r;
      }(e, t.start), o = e.substring(t.end, r - 1).split(","), i = o[0], u = o.slice(1);
      return {
        start: t.start,
        end: r,
        _$propName$_: i.trim(),
        _$fallback$_: u.length > 0 ? u.join(",").trim() : void 0
      };
    }(e, t);
    if (!r) return n.push(e.substring(t, e.length)), e.length;
    var o = r._$propName$_, i = null != r._$fallback$_ ? compileTemplate(r._$fallback$_) : void 0;
    return n.push(e.substring(t, r.start), function(e) {
      return function resolveVar(e, n, t) {
        return e[n] ? e[n] : t ? executeTemplate(t, e) : "";
      }(e, o, i);
    }), r.end;
  }
  function executeTemplate(e, n) {
    for (var t = "", r = 0; r < e.length; r++) {
      var o = e[r];
      t += "string" == typeof o ? o : o(n);
    }
    return t;
  }
  function findEndValue(e, n) {
    for (var t = !1, r = !1, o = n; o < e.length; o++) {
      var i = e[o];
      if (t) r && '"' === i && (t = !1), r || "'" !== i || (t = !1); else if ('"' === i) t = !0, 
      r = !0; else if ("'" === i) t = !0, r = !1; else {
        if (";" === i) return o + 1;
        if ("}" === i) return o;
      }
    }
    return o;
  }
  function compileTemplate(e) {
    var n = 0;
    e = function removeCustomAssigns(e) {
      for (var n = "", t = 0; ;) {
        var r = findRegex(M, e, t), o = r ? r.start : e.length;
        if (n += e.substring(t, o), !r) break;
        t = findEndValue(e, o);
      }
      return n;
    }(e = e.replace(x, "")).replace($, "").replace(N, "");
    for (var t = []; n < e.length; ) n = compileVar(e, t, n);
    return t;
  }
  function resolveValues(e) {
    var n = {};
    e.forEach(function(e) {
      e._$declarations$_.forEach(function(e) {
        n[e._$prop$_] = e.value;
      });
    });
    for (var t = {}, r = Object.entries(n), o = function(e) {
      var n = !1;
      if (r.forEach(function(e) {
        var r = e[0], o = executeTemplate(e[1], t);
        o !== t[r] && (t[r] = o, n = !0);
      }), !n) return "break";
    }, i = 0; i < 10 && "break" !== o(); i++) ;
    return t;
  }
  function normalizeValue(e) {
    var n = (e = e.replace(/\s+/gim, " ").trim()).endsWith(P);
    return n && (e = e.substr(0, e.length - P.length).trim()), {
      value: e,
      _$important$_: n
    };
  }
  function getSelectorsForScopes(e) {
    var n = [];
    return e.forEach(function(e) {
      n.push.apply(n, e._$selectors$_);
    }), n;
  }
  function parseCSS(e) {
    var n = 
    // given a string of css, return a simple rule tree
    /**
     * @param {string} text
     * @return {StyleNode}
     */
    function parse(e) {
      // add selectors/cssText to node tree
      /**
     * @param {StyleNode} node
     * @param {string} text
     * @return {StyleNode}
     */
      return function parseCss(e, n) {
        var t = n.substring(e.start, e.end - 1);
        if (e.parsedCssText = e.cssText = t.trim(), e.parent) {
          var r = e.previous ? e.previous.end : e.parent.start;
          // TODO(sorvell): ad hoc; make selector include only after last ;
          // helps with mixin syntax
          t = (t = (t = 
          /**
     * conversion of sort unicode escapes with spaces like `\33 ` (and longer) into
     * expanded form that doesn't require trailing space `\000033`
     * @param {string} s
     * @return {string}
     */
          function _expandUnicodeEscapes(e) {
            return e.replace(/\\([0-9a-f]{1,6})\s/gi, function() {
              for (var e = arguments[1], n = 6 - e.length; n--; ) e = "0" + e;
              return "\\" + e;
            });
          }
          /** @enum {number} */ (t = n.substring(r, e.start - 1))).replace(k._$multipleSpaces$_, " ")).substring(t.lastIndexOf(";") + 1);
          var o = e.parsedSelector = e.selector = t.trim();
          e.atRule = 0 === o.indexOf(w), 
          // note, support a subset of rule types...
          e.atRule ? 0 === o.indexOf(V) ? e.type = b._$MEDIA_RULE$_ : o.match(k._$keyframesRule$_) && (e.type = b._$KEYFRAMES_RULE$_, 
          e.keyframesName = e.selector.split(k._$multipleSpaces$_).pop()) : 0 === o.indexOf(E) ? e.type = b._$MIXIN_RULE$_ : e.type = b._$STYLE_RULE$_;
        }
        var i = e.rules;
        if (i) for (var u = 0, a = i.length, c = void 0; u < a && (c = i[u]); u++) parseCss(c, n);
        return e;
      }(
      // super simple {...} lexer that returns a node tree
      /**
     * @param {string} text
     * @return {StyleNode}
     */
      function lex(e) {
        var n = new g();
        n.start = 0, n.end = e.length;
        for (var t = n, r = 0, o = e.length; r < o; r++) if (e[r] === S) {
          t.rules || (t.rules = []);
          var i = t, u = i.rules[i.rules.length - 1] || null;
          (t = new g()).start = r + 1, t.parent = i, t.previous = u, i.rules.push(t);
        } else e[r] === C && (t.end = r + 1, t = t.parent || n);
        return n;
      }(e = 
      // remove stuff we don't care about that may hinder parsing
      /**
     * @param {string} cssText
     * @return {string}
     */
      function clean(e) {
        return e.replace(k._$comments$_, "").replace(k._$port$_, "");
      }(e)), e);
    }(e), t = compileTemplate(e);
    return {
      _$original$_: e,
      _$template$_: t,
      _$selectors$_: function getSelectors(e, n) {
        if (void 0 === n && (n = 0), !e.rules) return [];
        var t = [];
        return e.rules.filter(function(e) {
          return e.type === b._$STYLE_RULE$_;
        }).forEach(function(e) {
          var r = function getDeclarations(e) {
            for (var n, t = []; n = T.exec(e.trim()); ) {
              var r = normalizeValue(n[2]), o = r.value, i = r._$important$_;
              t.push({
                _$prop$_: n[1].trim(),
                value: compileTemplate(o),
                _$important$_: i
              });
            }
            return t;
          }(e.cssText);
          r.length > 0 && e.parsedSelector.split(",").forEach(function(e) {
            e = e.trim(), t.push({
              selector: e,
              _$declarations$_: r,
              _$specificity$_: 1,
              _$nu$_: n
            });
          }), n++;
        }), t;
      }(n),
      _$isDynamic$_: t.length > 1
    };
  }
  function addGlobalStyle(e, n) {
    var t = parseCSS(n.innerHTML);
    t._$styleEl$_ = n, e.push(t);
  }
  function replaceScope(e, n, t) {
    return e = replaceAll(e, "\\[" + getElementScopeId(n, !0) + "\\]", "[" + getElementScopeId(t, !0) + "]"), 
    e = replaceAll(e, "\\[" + n + "\\]", "[" + t + "]"), replaceAll(e, "\\[" + getElementScopeId(n) + "\\]", "[" + getElementScopeId(t) + "]");
  }
  function replaceAll(e, n, t) {
    return e.replace(new RegExp(n, "g"), t);
  }
  function addGlobalLink(e, n, t) {
    var r = t.href;
    return fetch(r).then(function(e) {
      return e.text();
    }).then(function(o) {
      if (function hasCssVariables(e) {
        return e.indexOf("var(") > -1 || R.test(e);
      }
      // This regexp find all url() usages with relative urls
      (o) && t.parentNode) {
        (function hasRelativeUrls(e) {
          return B.lastIndex = 0, B.test(e);
        })(o) && (o = function fixRelativeUrls(e, n) {
          // get the basepath from the original import url
          var t = n.replace(/[^\/]*$/, "");
          // replace the relative url, with the new relative url
                    return e.replace(B, function(e, n) {
            // rhe new relative path is the base path + uri
            // TODO: normalize relative URL
            var r = t + n;
            return e.replace(n, r);
          });
        }(o, r));
        var i = e.createElement("style");
        i.innerHTML = o, addGlobalStyle(n, i), t.parentNode.insertBefore(i, t), t.remove();
      }
    }).catch(function(e) {
      console.error(e);
    });
  }
  // This regexp tries to determine when a variable is declared, for example:
  //
  // .my-el { --highlight-color: green; }
  //
  // but we don't want to trigger when a classname uses "--" or a pseudo-class is
  // used. We assume that the only characters that can preceed a variable
  // declaration are "{", from an opening block, ";" from a preceeding rule, or a
  // space. This prevents the regexp from matching a word in a selector, since
  // they would need to start with a "." or "#". (We assume element names don't
  // start with "--").
    var o = "ssrv", i = "ssrc", u = "$", a = {}, c = {
    enter: 13,
    escape: 27,
    space: 32,
    tab: 9,
    left: 37,
    up: 38,
    right: 39,
    down: 40
  }, f = function(e) {
    return null != e;
  }, l = function(e) {
    return e.toLowerCase();
  }, s = function() {}, p = [], d = {
    forEach: function(e, n) {
      e.forEach(function(e) {
        return n(VNodeToChild(e));
      });
    },
    map: function(e, n) {
      return e.map(function(e) {
        return function childToVNode(e) {
          return {
            vtag: e.vtag,
            vchildren: e.vchildren,
            vtext: e.vtext,
            vattrs: e.vattrs,
            vkey: e.vkey,
            vname: e.vname
          };
        }(n(VNodeToChild(e)));
      });
    }
  }, v = "wc-", m = "http://www.w3.org/1999/xlink", y = !1, g = function g() {
    this.start = 0, this.end = 0, this.previous = null, this.parent = null, this.rules = null, 
    this.parsedCssText = "", this.cssText = "", this.atRule = !1, this.type = 0, this.keyframesName = "", 
    this.selector = "", this.parsedSelector = "";
  }, b = {
    _$STYLE_RULE$_: 1,
    _$KEYFRAMES_RULE$_: 7,
    _$MEDIA_RULE$_: 4,
    _$MIXIN_RULE$_: 1e3
  }, S = "{", C = "}", k = {
    _$comments$_: /\/\*[^*]*\*+([^\/*][^*]*\*+)*\//gim,
    _$port$_: /@import[^;]*;/gim,
    _$customProp$_: /(?:^[^;\-\s}]+)?--[^;{}]*?:[^{};]*?(?:[;\n]|$)/gim,
    _$mixinProp$_: /(?:^[^;\-\s}]+)?--[^;{}]*?:[^{};]*?{[^}]*?}(?:[;\n]|$)?/gim,
    _$mixinApply$_: /@apply\s*\(?[^);]*\)?\s*(?:[;\n]|$)?/gim,
    _$varApply$_: /[^;:]*?:[^;]*?var\([^;]*\)(?:[;\n]|$)?/gim,
    _$keyframesRule$_: /^@[^\s]*keyframes/,
    _$multipleSpaces$_: /\s+/g
  }, E = "--", V = "@media", w = "@", L = /\bvar\(/, M = /\B--[\w-]+\s*:/, x = /\/\*[^*]*\*+([^\/*][^*]*\*+)*\//gim, N = /^[\t ]+\n/gm, $ = /[^{}]*{\s*}/gm, P = "!important", T = /(?:^|[;\s{]\s*)(--[\w-]*?)\s*:\s*(?:((?:'(?:\\'|.)*?'|"(?:\\"|.)*?"|\([^)]*?\)|[^};{])+)|\{([^}]*)\}(?:(?=[;\s}])|$))/gm, R = /[\s;{]--[-a-zA-Z0-9]+\s*:/m, B = /url[\s]*\([\s]*['"]?(?![http|\/])([^\'\"\)]*)[\s]*['"]?\)[\s]*/gim, O = /** @class */ function() {
    function CustomStyle(e, n) {
      this._$win$_ = e, this._$doc$_ = n, this._$count$_ = 0, this._$hostStyleMap$_ = new WeakMap(), 
      this._$hostScopeMap$_ = new WeakMap(), this._$globalScopes$_ = [], this._$scopesMap$_ = new Map();
    }
    return CustomStyle.prototype._$init$_ = function() {
      var e = this;
      return new Promise(function(n) {
        e._$win$_.requestAnimationFrame(function() {
          (function loadDocument(e, n) {
            return function loadDocumentLinks(e, n) {
              for (var t = [], r = e.querySelectorAll('link[rel="stylesheet"][href]'), o = 0; o < r.length; o++) t.push(addGlobalLink(e, n, r[o]));
              return Promise.all(t);
            }(e, n).then(function() {
              (function loadDocumentStyles(e, n) {
                for (var t = e.querySelectorAll("style"), r = 0; r < t.length; r++) addGlobalStyle(n, t[r]);
              })(e, n);
            });
          })(e._$doc$_, e._$globalScopes$_).then(function() {
            return n();
          });
        });
      });
    }, CustomStyle.prototype._$addLink$_ = function(e) {
      var n = this;
      return addGlobalLink(this._$doc$_, this._$globalScopes$_, e).then(function() {
        n._$updateGlobal$_();
      });
    }, CustomStyle.prototype._$addGlobalStyle$_ = function(e) {
      addGlobalStyle(this._$globalScopes$_, e), this._$updateGlobal$_();
    }, CustomStyle.prototype._$createHostStyle$_ = function(e, n, t) {
      if (this._$hostScopeMap$_.has(e)) return null;
      var r = e["s-sc"], o = this._$registerHostTemplate$_(t, n, r), i = o._$isDynamic$_ && o._$cssScopeId$_;
      if (!i && o._$styleEl$_) return null;
      var u = this._$doc$_.createElement("style");
      if (i) {
        var a = o._$cssScopeId$_ + "-" + this._$count$_;
        e["s-sc"] = a, this._$hostStyleMap$_.set(e, u), this._$hostScopeMap$_.set(e, function reScope(e, n) {
          var t = e._$template$_.map(function(t) {
            return "string" == typeof t ? replaceScope(t, e._$cssScopeId$_, n) : t;
          }), r = e._$selectors$_.map(function(t) {
            return Object.assign({}, t, {
              selector: replaceScope(t.selector, e._$cssScopeId$_, n)
            });
          });
          return Object.assign({}, e, {
            _$template$_: t,
            _$selectors$_: r,
            _$cssScopeId$_: n
          });
        }(o, a)), this._$count$_++;
      } else o._$styleEl$_ = u, o._$isDynamic$_ || (u.innerHTML = executeTemplate(o._$template$_, {})), 
      this._$globalScopes$_.push(o), this._$updateGlobal$_(), this._$hostScopeMap$_.set(e, o);
      return u;
    }, CustomStyle.prototype._$removeHost$_ = function(e) {
      var n = this._$hostStyleMap$_.get(e);
      n && n.remove(), this._$hostStyleMap$_.delete(e), this._$hostScopeMap$_.delete(e);
    }, CustomStyle.prototype._$updateHost$_ = function(e) {
      var n = this._$hostScopeMap$_.get(e);
      if (n && n._$isDynamic$_ && n._$cssScopeId$_) {
        var t = this._$hostStyleMap$_.get(e);
        if (t) {
          var r = resolveValues(function getActiveSelectors(e, n, t) {
            // sort selectors by specifity
            return function sortSelectors(e) {
              return e.sort(function(e, n) {
                return e._$specificity$_ === n._$specificity$_ ? e._$nu$_ - n._$nu$_ : e._$specificity$_ - n._$specificity$_;
              }), e;
            }(getSelectorsForScopes(t.concat(function getScopesForElement(e, n) {
              for (var t = []; n; ) {
                var r = e.get(n);
                r && t.push(r), n = n.parentElement;
              }
              return t;
            }(n, e))).filter(function(n) {
              return function matches(e, n) {
                return e.matches(n);
              }(e, n.selector);
            }));
          }(e, this._$hostScopeMap$_, this._$globalScopes$_));
          t.innerHTML = executeTemplate(n._$template$_, r);
        }
      }
    }, CustomStyle.prototype._$updateGlobal$_ = function() {
      (function updateGlobalScopes(e) {
        var n = resolveValues(getSelectorsForScopes(e));
        e.forEach(function(e) {
          e._$isDynamic$_ && (e._$styleEl$_.innerHTML = executeTemplate(e._$template$_, n));
        });
      })(this._$globalScopes$_);
    }, CustomStyle.prototype._$registerHostTemplate$_ = function(e, n, t) {
      var r = this._$scopesMap$_.get(n);
      return r || ((r = parseCSS(e))._$cssScopeId$_ = t, this._$scopesMap$_.set(n, r)), 
      r;
    }, CustomStyle;
  }(), A = void 0;
  !function supportsCssVars(e) {
    return !!(e.CSS && e.CSS.supports && e.CSS.supports("color", "var(--c)"));
  }(e) && (A = new O(e, n)), function createPlatformMainLegacy(e, n, t, r, i, a, f) {
    function defineComponent(e, n) {
      if (!t.customElements.get(e._$tagNameMeta$_)) {
        // keep a map of all the defined components
        b[e._$tagNameMeta$_] = !0, 
        // initialize the members on the host element prototype
        // keep a ref to the metadata with the tag as the key
        initHostElement(C, s[e._$tagNameMeta$_] = e, n.prototype, a);
        // add which attributes should be observed
        var r = [];
        // at this point the membersMeta only includes attributes which should
        // be observed, it does not include all props yet, so it's safe to
        // loop through all of the props (attrs) and observed them
                for (var o in e._$membersMeta$_) e._$membersMeta$_[o]._$attribName$_ && r.push(
        // add this attribute to our array of attributes we need to observe
        e._$membersMeta$_[o]._$attribName$_);
        // set the array of all the attributes to keep an eye on
        // https://www.youtube.com/watch?v=RBs21CFBALI
                n.observedAttributes = r, 
        // define the custom element
        t.customElements.define(e._$tagNameMeta$_, n);
      }
    }
    function getLoadedBundle(e, n) {
      return null == e ? null : d.get(e.replace(/^\.\//, ""));
    }
    function isLoadedBundle(e) {
      return "exports" === e || "require" === e || !!getLoadedBundle(e);
    }
    function execBundleCallback(e, n, t) {
      var r = {};
      try {
        t.apply(null, n.map(function(e) {
          return "exports" === e ? r : "require" === e ? userRequire : getLoadedBundle(e);
        }));
      } catch (e) {
        console.error(e);
      }
      // If name is undefined then this callback was fired by component callback
            void 0 !== e && (d.set(e, r), 
      // If name contains chunk then this callback was associated with a dependent bundle loading
      // let's add a reference to the constructors on each components metadata
      // each key in moduleImports is a PascalCased tag name
      e && !e.endsWith(".js") && Object.keys(r).forEach(function(e) {
        for (var n = e.replace(/-/g, "").toLowerCase(), t = Object.keys(s), o = 0; o < t.length; o++) if (t[o].replace(/-/g, "").toLowerCase() === n) {
          var i = s[t[o]];
          i && (
          // get the component constructor from the module
          i._$componentConstructor$_ = r[e], initStyleTemplate(0, i, i._$encapsulationMeta$_, i._$componentConstructor$_.style, i._$componentConstructor$_.styleMode));
          break;
        }
      }));
    }
    function userRequire(e, n) {
      loadBundle(void 0, e, n);
    }
    /**
         * Check to see if any items in the bundle queue can be executed
         */    
    /**
         * This function is called anytime a JS file is loaded
         */
    function loadBundle(e, n, t) {
      var r = n.filter(function(e) {
        return !isLoadedBundle(e);
      });
      r.forEach(function(e) {
        requestUrl(i + e.replace(".js", ".es5.js"));
      }), p.push([ e, n, t ]), 
      // If any dependents are not yet met then queue the bundle execution
      0 === r.length && function checkQueue() {
        for (var e = p.length - 1; e >= 0; e--) {
          var n = p[e], t = n[0], r = n[1], o = n[2];
          r.every(isLoadedBundle) && !isLoadedBundle(t) && (p.splice(e, 1), execBundleCallback(t, r, o));
        }
      }();
    }
    function requestComponentBundle(e, n, t) {
      // create the url we'll be requesting
      // always use the es5/jsonp callback module
      var r = 2 /* ScopedCss */ === e._$encapsulationMeta$_ || 1 /* ShadowDom */ === e._$encapsulationMeta$_ && !g._$$supportsShadowDom$_;
      requestUrl(i + n + (r ? ".sc" : "") + ".es5.js");
    }
    // Use JSONP to load in bundles
        function requestUrl(e) {
      function onScriptComplete() {
        clearTimeout(n), t.onerror = t.onload = null, g._$$remove$_(t), 
        // remove from our list of active requests
        v.delete(e);
      }
      var n, t;
      v.has(e) || (
      // we're not already actively requesting this url
      // let's kick off the bundle request and
      // remember that we're now actively requesting this url
      v.add(e), (
      // create a sript element to add to the document.head
      t = g._$$createElement$_("script")).charset = "utf-8", t.async = !0, t.src = e, 
      // create a fallback timeout if something goes wrong
      n = setTimeout(onScriptComplete, 12e4), 
      // add script completed listener to this script element
      t.onerror = t.onload = onScriptComplete, 
      // inject a script tag in the head
      // kick off the actual request
      g._$$appendChild$_(g._$$doc$_.head, t));
    }
    var s = {
      html: {}
    }, p = [], d = new Map(), v = new Set(), m = {}, y = t[e] = t[e] || {}, g = function createDomApi(e, n, t) {
      // using the $ prefix so that closure is
      // cool with property renaming each of these
      e.ael || (e.ael = function(e, n, t, r) {
        return e.addEventListener(n, t, r);
      }, e.rel = function(e, n, t, r) {
        return e.removeEventListener(n, t, r);
      });
      var r = new WeakMap(), o = {
        _$$doc$_: t,
        _$$supportsEventOptions$_: !1,
        _$$nodeType$_: function(e) {
          return e.nodeType;
        },
        _$$createElement$_: function(e) {
          return t.createElement(e);
        },
        _$$createElementNS$_: function(e, n) {
          return t.createElementNS(e, n);
        },
        _$$createTextNode$_: function(e) {
          return t.createTextNode(e);
        },
        _$$createComment$_: function(e) {
          return t.createComment(e);
        },
        _$$insertBefore$_: function(e, n, t) {
          return e.insertBefore(n, t);
        },
        // https://developer.mozilla.org/en-US/docs/Web/API/ChildNode/remove
        // and it's polyfilled in es5 builds
        _$$remove$_: function(e) {
          return e.remove();
        },
        _$$appendChild$_: function(e, n) {
          return e.appendChild(n);
        },
        _$$addClass$_: function(e, n) {
          return e.classList.add(n);
        },
        _$$childNodes$_: function(e) {
          return e.childNodes;
        },
        _$$parentNode$_: function(e) {
          return e.parentNode;
        },
        _$$nextSibling$_: function(e) {
          return e.nextSibling;
        },
        _$$previousSibling$_: function(e) {
          return e.previousSibling;
        },
        _$$tagName$_: function(e) {
          return l(e.nodeName);
        },
        _$$getTextContent$_: function(e) {
          return e.textContent;
        },
        _$$setTextContent$_: function(e, n) {
          return e.textContent = n;
        },
        _$$getAttribute$_: function(e, n) {
          return e.getAttribute(n);
        },
        _$$setAttribute$_: function(e, n, t) {
          return e.setAttribute(n, t);
        },
        _$$setAttributeNS$_: function(e, n, t, r) {
          return e.setAttributeNS(n, t, r);
        },
        _$$removeAttribute$_: function(e, n) {
          return e.removeAttribute(n);
        },
        _$$hasAttribute$_: function(e, n) {
          return e.hasAttribute(n);
        },
        _$$getMode$_: function(n) {
          return n.getAttribute("mode") || (e.Context || {}).mode;
        },
        _$$elementRef$_: function(e, r) {
          return "child" === r ? e.firstElementChild : "parent" === r ? o._$$parentElement$_(e) : "body" === r ? t.body : "document" === r ? t : "window" === r ? n : e;
        },
        _$$addEventListener$_: function(n, t, i, u, a, f, l, s) {
          // remember the original name before we possibly change it
          var p = t, d = n, v = r.get(n);
          if (v && v[p] && 
          // removed any existing listeners for this event for the assigner element
          // this element already has this listener, so let's unregister it now
          v[p](), "string" == typeof f ? 
          // attachTo is a string, and is probably something like
          // "parent", "window", or "document"
          // and the eventName would be like "mouseover" or "mousemove"
          d = o._$$elementRef$_(n, f) : "object" == typeof f ? 
          // we were passed in an actual element to attach to
          d = f : (
          // depending on the event name, we could actually be attaching
          // this element to something like the document or window
          s = t.split(":")).length > 1 && (
          // document:mousemove
          // parent:touchend
          // body:keyup.enter
          d = o._$$elementRef$_(n, s[0]), t = s[1]), d) {
            var m = i;
            // test to see if we're looking for an exact keycode
                        (s = t.split(".")).length > 1 && (
            // looks like this listener is also looking for a keycode
            // keyup.enter
            t = s[0], m = function(e) {
              // wrap the user's event listener with our own check to test
              // if this keyboard event has the keycode they're looking for
              e.keyCode === c[s[1]] && i(e);
            }), 
            // create the actual event listener options to use
            // this browser may not support event options
            l = o._$$supportsEventOptions$_ ? {
              capture: !!u,
              passive: !!a
            } : !!u, 
            // ok, good to go, let's add the actual listener to the dom element
            e.ael(d, t, m, l), v || 
            // we don't already have a collection, let's create it
            r.set(n, v = {}), 
            // add the unregister listener to this element's collection
            v[p] = function() {
              // looks like it's time to say goodbye
              d && e.rel(d, t, m, l), v[p] = null;
            };
          }
        },
        _$$removeEventListener$_: function(e, n) {
          // get the unregister listener functions for this element
          var t = r.get(e);
          t && (
          // this element has unregister listeners
          n ? 
          // passed in one specific event name to remove
          t[n] && t[n]() : 
          // remove all event listeners
          Object.keys(t).forEach(function(e) {
            t[e] && t[e]();
          }));
        }
      };
      "function" != typeof n.CustomEvent && (
      // CustomEvent polyfill
      n.CustomEvent = function(e, n, r) {
        return (r = t.createEvent("CustomEvent")).initCustomEvent(e, n.bubbles, n.cancelable, n.detail), 
        r;
      }, n.CustomEvent.prototype = n.Event.prototype), o._$$dispatchEvent$_ = function(e, t, r) {
        return e && e.dispatchEvent(new n.CustomEvent(t, r));
      };
      // test if this browser supports event options or not
      try {
        n.addEventListener("e", null, Object.defineProperty({}, "passive", {
          get: function() {
            return o._$$supportsEventOptions$_ = !0;
          }
        }));
      } catch (e) {}
      return o._$$parentElement$_ = function(e, n) {
        // if the parent node is a document fragment (shadow root)
        // then use the "host" property on it
        // otherwise use the parent node
        return (n = o._$$parentNode$_(e)) && 11 /* DocumentFragment */ === o._$$nodeType$_(n) ? n.host : n;
      }, o;
    }(y, t, r);
    // set App Context
    n.isServer = n.isPrerender = !(n.isClient = !0), n.window = t, n.location = t.location, 
    n.document = r, n.resourcesUrl = n.publicPath = i, n.enableListener = function(e, n, t, r, o) {
      return function enableEventListener(e, n, t, r, o, i) {
        if (n) {
          // cool, we've got an instance, it's get the element it's on
          var u = e._$hostElementMap$_.get(n), a = e._$getComponentMeta$_(u);
          if (a && a._$listenersMeta$_) 
          // alrighty, so this cmp has listener meta
          if (r) {
            // we want to enable this event
            // find which listen meta we're talking about
            var c = a._$listenersMeta$_.find(function(e) {
              return e._$eventName$_ === t;
            });
            c && 
            // found the listen meta, so let's add the listener
            e._$domApi$_._$$addEventListener$_(u, t, function(e) {
              return n[c._$eventMethodName$_](e);
            }, c._$eventCapture$_, void 0 === i ? c._$eventPassive$_ : !!i, o);
          } else 
          // we're disabling the event listener
          // so let's just remove it entirely
          e._$domApi$_._$$removeEventListener$_(u, t);
        }
      }(C, e, n, t, r, o);
    }, n.emit = function(e, t, r) {
      return g._$$dispatchEvent$_(e, n.eventNameFn ? n.eventNameFn(t) : t, r);
    }, 
    // add the h() fn to the app's global namespace
    y.h = h, y.Context = n;
    // keep a global set of tags we've already defined
    // DEPRECATED $definedCmps 2018-05-22
    var b = t["s-defined"] = t.$definedCmps = t["s-defined"] || t.$definedCmps || {}, S = 0, C = {
      _$domApi$_: g,
      _$defineComponent$_: defineComponent,
      _$emitEvent$_: n.emit,
      _$customStyle$_: f,
      _$getComponentMeta$_: function(e) {
        return s[g._$$tagName$_(e)];
      },
      _$getContextItem$_: function(e) {
        return n[e];
      },
      isClient: !0,
      _$isDefinedComponent$_: function(e) {
        return !(!b[g._$$tagName$_(e)] && !C._$getComponentMeta$_(e));
      },
      _$onError$_: function(e, n, t) {
        return console.error(e, n, t && t.tagName);
      },
      _$nextId$_: function() {
        return e + S++;
      },
      _$propConnect$_: function(e) {
        return function proxyController(e, n, t) {
          return {
            create: proxyProp(e, n, t, "create"),
            componentOnReady: proxyProp(e, n, t, "componentOnReady")
          };
        }(g, m, e);
      },
      queue: n.queue = function createQueueClient(e, n) {
        function consume(e) {
          for (var n = 0; n < e.length; n++) try {
            e[n](t());
          } catch (e) {
            console.error(e);
          }
          e.length = 0;
        }
        function consumeTimeout(e, n) {
          for (var r, o = 0; o < e.length && (r = t()) < n; ) try {
            e[o++](r);
          } catch (e) {
            console.error(e);
          }
          o === e.length ? e.length = 0 : 0 !== o && e.splice(0, o);
        }
        function flush() {
          c++, 
          // always force a bunch of medium callbacks to run, but still have
          // a throttle on how many can run in a certain time
          // DOM READS!!!
          consume(i);
          var n = t() + 7 * Math.ceil(c * (1 / 22));
          // DOM WRITES!!!
                    consumeTimeout(u, n), consumeTimeout(a, n), u.length > 0 && (a.push.apply(a, u), 
          u.length = 0), (f = i.length + u.length + a.length > 0) ? 
          // still more to do yet, but we've run out of time
          // let's let this thing cool off and try again in the next tick
          e.raf(flush) : c = 0;
        }
        var t = function() {
          return n.performance.now();
        }, r = Promise.resolve(), o = [], i = [], u = [], a = [], c = 0, f = !1;
        return e.raf || (e.raf = n.requestAnimationFrame.bind(n)), {
          tick: function(e) {
            // queue high priority work to happen in next tick
            // uses Promise.resolve() for next tick
            o.push(e), 1 === o.length && r.then(function() {
              return consume(o);
            });
          },
          read: function(n) {
            // queue dom reads
            i.push(n), f || (f = !0, e.raf(flush));
          },
          write: function(n) {
            // queue dom writes
            u.push(n), f || (f = !0, e.raf(flush));
          }
        };
      }(y, t),
      _$requestBundle$_: 
      // This is executed by the component's connected callback.
      function requestBundle(e, n, t) {
        var r = "string" == typeof e._$bundleIds$_ ? e._$bundleIds$_ : e._$bundleIds$_[n.mode];
        getLoadedBundle(r) ? 
        // sweet, we've already loaded this bundle
        queueUpdate(C, n) : (
        // never seen this bundle before, let's start the request
        // and add it to the callbacks to fire when it has loaded
        p.push([ void 0, [ r ], function() {
          queueUpdate(C, n);
        } ]), 
        // when to request the bundle depends is we're using the css shim or not
        f && E ? 
        // add this to the loadBundleQueue to run when css is ready
        E.push(function() {
          return requestComponentBundle(e, r);
        }) : 
        // not using css shim, so no need to wait on css shim to finish
        // figure out which bundle to request and kick it off
        requestComponentBundle(e, r));
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
    C.render = createRendererPatch(C, g);
    // setup the root element which is the mighty <html> tag
    // the <html> has the final say of when the app has loaded
    var k = g._$$doc$_.documentElement;
    k["s-ld"] = [], k["s-rn"] = !0, 
    // this will fire when all components have finished loaded
    k["s-init"] = function() {
      C._$hasLoadedMap$_.set(k, y.loaded = C._$isAppLoaded$_ = !0), g._$$dispatchEvent$_(t, "appload", {
        detail: {
          namespace: e
        }
      });
    }, 
    // if the HTML was generated from SSR
    // then let's walk the tree and generate vnodes out of the data
    function createVNodesFromSsr(e, n, t) {
      var r, i, u, a, c, f, l = t.querySelectorAll("[" + o + "]"), s = l.length;
      if (s > 0) for (e._$hasLoadedMap$_.set(t, !0), a = 0; a < s; a++) for (r = l[a], 
      i = n._$$getAttribute$_(r, o), (u = {}).vtag = n._$$tagName$_(u._$elm$_ = r), e._$vnodeMap$_.set(r, u), 
      c = 0, f = r.childNodes.length; c < f; c++) addChildSsrVNodes(n, r.childNodes[c], u, i, !0);
    }(C, g, k), y.loadBundle = loadBundle;
    var E = [];
    f && f._$init$_().then(function() {
      // loaded all the css, let's run all the request bundle callbacks
      for (;E.length; ) E.shift()();
      // set to null to we know we're loaded
            E = null;
    }), C._$attachStyles$_ = function(e, n, t, r) {
      (function attachStyles(e, n, t, r) {
        // first see if we've got a style for a specific mode
        // either this host element should use scoped css
        // or it wants to use shadow dom but the browser doesn't support it
        // create a scope id which is useful for scoped css
        // and add the scope attribute to the host
        var o = 2 /* ScopedCss */ === t._$encapsulationMeta$_ || 1 /* ShadowDom */ === t._$encapsulationMeta$_ && !e._$domApi$_._$$supportsShadowDom$_, i = t._$tagNameMeta$_ + r.mode, a = t[i];
        // create the style id w/ the host element's mode
                if (o && (r["s-sc"] = getScopeId(t, r.mode)), a || (
        // doesn't look like there's a style template with the mode
        // create the style id using the default style mode and try again
        a = t[i = t._$tagNameMeta$_ + u], o && (r["s-sc"] = getScopeId(t))), a) {
          // cool, we found a style template element for this component
          var c = n._$$doc$_.head;
          // if this browser supports shadow dom, then let's climb up
          // the dom and see if we're within a shadow dom
                    if (n._$$supportsShadowDom$_) if (1 /* ShadowDom */ === t._$encapsulationMeta$_) 
          // we already know we're in a shadow dom
          // so shadow root is the container for these styles
          c = r.shadowRoot; else for (
          // climb up the dom and see if we're in a shadow dom
          var f = r; f = n._$$parentNode$_(f); ) if (f.host && f.host.shadowRoot) {
            // looks like we are in shadow dom, let's use
            // this shadow root as the container for these styles
            c = f.host.shadowRoot;
            break;
          }
          // if this container element already has these styles
          // then there's no need to apply them again
          // create an object to keep track if we'ready applied this component style
                    var l = e._$componentAppliedStyles$_.get(c);
          // check if we haven't applied these styles to this container yet
          if (l || e._$componentAppliedStyles$_.set(c, l = {}), !l[i]) {
            var s = void 0;
            if (
            // es5 builds are not usig <template> because of ie11 issues
            // instead the "template" is just the style text as a string
            // create a new style element and add as innerHTML
            e._$customStyle$_ ? s = e._$customStyle$_._$createHostStyle$_(r, i, a) : ((s = n._$$createElement$_("style")).innerHTML = a, 
            // remember we don't need to do this again for this element
            l[i] = !0), s) {
              var p = c.querySelectorAll("[data-styles]");
              n._$$insertBefore$_(c, s, p.length && p[p.length - 1].nextSibling || c.firstChild);
            }
          }
        }
      })(e, n, t, r);
    }, 
    // register all the components now that everything's ready
    (y.components || []).map(function(e) {
      var n = function parseComponentLoader(e, n, t) {
        // tag name will always be lower case
        var r = {
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
                r._$bundleIds$_ = e[1];
        // parse member meta
        // this data only includes props that are attributes that need to be observed
        // it does not include all of the props yet
        var o = e[3];
        if (o) for (n = 0; n < o.length; n++) t = o[n], r._$membersMeta$_[t[0]] = {
          _$memberType$_: t[1],
          _$reflectToAttrib$_: !!t[2],
          _$attribName$_: "string" == typeof t[3] ? t[3] : t[3] ? t[0] : 0,
          _$propType$_: t[4]
        };
        // encapsulation
                return r._$encapsulationMeta$_ = e[4], e[5] && (
        // parse listener meta
        r._$listenersMeta$_ = e[5].map(parseListenerData)), r;
      }(e);
      return s[n._$tagNameMeta$_] = n;
    }).forEach(function(e) {
      // es5 way of extending HTMLElement
      function HostElement(e) {
        return HTMLElement.call(this, e);
      }
      HostElement.prototype = Object.create(HTMLElement.prototype, {
        constructor: {
          value: HostElement,
          configurable: !0
        }
      }), defineComponent(e, HostElement);
    }), 
    // create the componentOnReady fn
    function initCoreComponentOnReady(e, n, t, r, o, i) {
      if (
      // add componentOnReady() to the App object
      // this also is used to know that the App's core is ready
      n.componentOnReady = function(n, t) {
        if (!n.nodeName.includes("-")) return t(null), !1;
        var r = e._$getComponentMeta$_(n);
        if (r) if (e._$hasLoadedMap$_.has(n)) 
        // element has already loaded, pass the resolve the element component
        // so we know that the resolve knows it this element is an app component
        t(n); else {
          // element hasn't loaded yet
          // add this resolve specifically to this elements on ready queue
          var o = e._$onReadyCallbacksMap$_.get(n) || [];
          o.push(t), e._$onReadyCallbacksMap$_.set(n, o);
        }
        // return a boolean if this app recognized this element or not
                return !!r;
      }, o) {
        // we've got some componentOnReadys in the queue before the app was ready
        for (i = o.length - 1; i >= 0; i--) 
        // go through each element and see if this app recongizes it
        n.componentOnReady(o[i][0], o[i][1]) && 
        // turns out this element belongs to this app
        // remove the resolve from the queue so in the end
        // all that's left in the queue are elements not apart of any apps
        o.splice(i, 1);
        for (i = 0; i < r.length; i++) if (!t[r[i]].componentOnReady) 
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
    }(C, y, t, t["s-apps"], t["s-cr"]), 
    // notify that the app has initialized and the core script is ready
    // but note that the components have not fully loaded yet
    y.initialized = !0;
  }
  /*
    Extremely simple css parser. Intended to be not more than what we need
    and definitely not necessarily correct =).
    */
  /** @unrestricted */ (r, t, e, n, resourcesUrl, hydratedCssClass, A);
}(window, document, Context, namespace);
})({},"GxWebControls","hydrated");