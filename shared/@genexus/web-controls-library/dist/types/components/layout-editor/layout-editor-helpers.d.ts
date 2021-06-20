export declare function findParentCell(el: HTMLElement): HTMLElement;
export declare function getCellData(el: HTMLElement): ICellData;
export declare function getDropTargetData(el: HTMLElement): IDropTargetData;
export declare function isEmptyContainerDrop(el: HTMLElement): boolean;
export declare function getControlId(el: HTMLElement): string;
interface ICellData {
    cellId: string;
    dropArea: string;
    rowId: string;
}
interface IDropTargetData {
    nextRowId: string;
    placeholderType: string;
}
export {};
