/*! Built with http://stenciljs.com */
/*! Built with http://stenciljs.com */
const {h: e} = window.GxWebControls;

import { a as t } from "./chunk-e6709a3b.js";

class a extends t {
  constructor() {
    super(...arguments), 
    /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
    this.disabled = !1;
  }
  selectedChanged(e) {
    e && this.gxSelect.emit({
      select: this
    });
  }
  disabledChanged(e) {
    e && this.gxDisable.emit({
      select: this
    });
  }
  valueChanged() {
    this.onChange.emit({
      select: this
    });
  }
  componentDidLoad() {
    this.gxSelectDidLoad.emit({
      select: this
    });
  }
  componentDidUnload() {
    this.gxSelectDidUnload.emit({
      select: this
    });
  }
  hostData() {
    return {
      "aria-hidden": "true",
      hidden: !0
    };
  }
  render() {
    return e("slot", null);
  }
  static get is() {
    return "gx-select-option";
  }
  static get properties() {
    return {
      cssClass: {
        type: String,
        attr: "css-class"
      },
      disabled: {
        type: Boolean,
        attr: "disabled",
        watchCallbacks: [ "disabledChanged" ]
      },
      selected: {
        type: Boolean,
        attr: "selected",
        mutable: !0,
        watchCallbacks: [ "selectedChanged" ]
      },
      value: {
        type: String,
        attr: "value",
        mutable: !0,
        watchCallbacks: [ "valueChanged" ]
      }
    };
  }
  static get events() {
    return [ {
      name: "onChange",
      method: "onChange",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    }, {
      name: "gxSelect",
      method: "gxSelect",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    }, {
      name: "gxDisable",
      method: "gxDisable",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    }, {
      name: "gxSelectDidLoad",
      method: "gxSelectDidLoad",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    }, {
      name: "gxSelectDidUnload",
      method: "gxSelectDidUnload",
      bubbles: !0,
      cancelable: !0,
      composed: !0
    } ];
  }
}

export { a as GxSelectOption };