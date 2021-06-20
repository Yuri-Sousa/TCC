const imagePositionMap = {
    "Above Text": "above",
    "After Text": "after",
    "Before Text": "before",
    "Behind Text": "behind",
    "Below Text": "below"
};
export default function actionResolver({ action }) {
    return (h("gx-button", { "css-class": action["@class"], "data-gx-le-control-id": action["@id"], disabled: action["@enabled"] === "False", "image-position": imagePositionMap[action["@imagePosition"]] },
        action["@image"] && h("img", { slot: "main-image", src: action["@image"] }),
        action["@disabledImage"] && (h("img", { slot: "disabled-image", src: action["@disabledImage"] })),
        action["@caption"]));
}
