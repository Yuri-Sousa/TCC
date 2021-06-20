export function ProgressBarRender(Base) {
    return class extends Base {
        render() {
            return (h("div", { class: "progress" },
                h("div", { class: "progress-bar progress-bar-striped progress-bar-animated bg-primary", style: { width: this.value + "%" }, "aria-valuenow": this.value, "aria-valuemin": "0", "aria-valuemax": "100" },
                    h("slot", null))));
        }
    };
}
