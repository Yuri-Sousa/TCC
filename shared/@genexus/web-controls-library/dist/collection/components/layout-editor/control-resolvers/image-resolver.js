export default function imageResolver({ image }) {
    return (h("gx-image", { alt: image["@controlName"], "data-gx-le-control-id": image["@id"], src: image["@image"], "css-class": image["@class"] }));
}
