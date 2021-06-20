import controlResolver from "../layout-editor-control-resolver";
export default function flexTableResolver({ table }, context) {
    const modelRows = table.row
        ? Array.isArray(table.row) ? table.row : [table.row]
        : [];
    const isEmptyTable = modelRows.length === 0;
    const nonEmptyRows = modelRows.filter(r => (Array.isArray(r.cell) && r.cell.length) || r.cell);
    const rows = nonEmptyRows.map(row => {
        const rowCells = Array.isArray(row.cell) ? row.cell : [row.cell];
        const renderedCells = rowCells.map(cell => {
            return renderCell(cell, row["@id"], context, table["@flexDirection"]);
        });
        return renderedCells;
    });
    return (h("div", { "data-gx-le-control-id": table["@id"], style: getTableStyle(table), "data-gx-le-container": true, "data-gx-le-container-empty": isEmptyTable.toString(), "data-gx-le-flex-table": true, "data-gx-le-flex-table-direction": table["@flexDirection"].toLowerCase() }, [...rows]));
}
function getTableStyle(table) {
    return {
        "align-items": table["@alignItems"],
        display: "flex",
        "flex-direction": table["@flexDirection"],
        "flex-wrap": table["@flexWrap"],
        "justify-content": table["@justifyContent"]
    };
}
function renderCell(cell, rowId, context, direction) {
    const editorCellStyle = {
        "align-self": cell["@alignSelf"],
        "flex-grow": cell["@flexGrow"],
        "flex-shrink": cell["@flexShrink"],
        height: cell["@flexHeight"],
        "max-height": cell["@maxHeight"],
        "max-width": cell["@maxWidth"],
        "min-height": cell["@minHeight"],
        "min-width": cell["@minWidth"],
        width: cell["@flexWidth"]
    };
    return (h("div", { tabindex: "0", key: cell["@id"], "data-gx-flex-cell": true, "data-gx-le-drop-area": direction === "Column" ? "vertical" : "horizontal", "data-gx-le-cell-id": cell["@id"], "data-gx-le-row-id": rowId, style: editorCellStyle, "data-gx-le-selected": context.selectedCells
            .includes(cell["@id"])
            .toString() }, controlResolver(cell, context)));
}
