const labelPositionMap = {
    Left: "left",
    "Platform Default": "left",
    Top: "top"
};
export default function dataResolver({ data }) {
    return (h("gx-form-field", { "label-caption": data["@labelCaption"], "label-position": labelPositionMap[data["@labelPosition"]], "data-gx-le-control-id": data["@id"] },
        h("gx-edit", { value: data["@controlName"], area: "field", disabled: data["@enabled"] === "False", readonly: true })));
}
