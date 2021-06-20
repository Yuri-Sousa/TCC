export default function defaultResolver(control) {
    return (h("div", { "data-gx-le-control-obj": JSON.stringify(control) }, "Unable to render control: Missing render"));
}
