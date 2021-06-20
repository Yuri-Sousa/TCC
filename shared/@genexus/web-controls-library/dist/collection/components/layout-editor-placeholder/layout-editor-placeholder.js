export class LayoutEditorPlaceholder {
    render() {
        return h("slot", null);
    }
    static get is() { return "gx-layout-editor-placeholder"; }
    static get properties() { return {
        "element": {
            "elementRef": true
        }
    }; }
    static get style() { return "/**style-placeholder:gx-layout-editor-placeholder:**/"; }
}
