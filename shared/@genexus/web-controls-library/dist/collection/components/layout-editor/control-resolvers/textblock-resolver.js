export default function textblockResolver({ textblock }) {
    return (h("gx-textblock", { "data-gx-le-control-id": textblock["@id"] }, textblock["@caption"]));
}
