import { BaseComponent } from "../common/base-component";
import { ProgressBarRender } from "../renders/bootstrap/progress-bar/progress-bar-render";
export class ProgressBar extends ProgressBarRender(BaseComponent) {
    static get is() { return "gx-progress-bar"; }
    static get host() { return {
        "role": "progressbar"
    }; }
    static get properties() { return {
        "value": {
            "type": Number,
            "attr": "value"
        }
    }; }
    static get style() { return "/**style-placeholder:gx-progress-bar:**/"; }
}
