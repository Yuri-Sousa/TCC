import { BaseComponent } from "../common/base-component";
import { FormFieldRender } from "../renders/bootstrap/form-field/form-field-render";
export class FormField extends FormFieldRender(BaseComponent) {
    static get is() { return "gx-form-field"; }
    static get properties() { return {
        "element": {
            "elementRef": true
        },
        "labelCaption": {
            "type": String,
            "attr": "label-caption"
        },
        "labelPosition": {
            "type": String,
            "attr": "label-position"
        }
    }; }
    static get style() { return "/**style-placeholder:gx-form-field:**/"; }
}
