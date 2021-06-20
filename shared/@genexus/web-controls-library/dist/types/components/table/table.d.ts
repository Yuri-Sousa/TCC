import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
export declare class Table extends BaseComponent {
    element: HTMLElement;
    /**
     * This attribute lets you specify how this element will behave when hidden.
     *
     * | Value        | Details                                                                     |
     * | ------------ | --------------------------------------------------------------------------- |
     * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
     * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
     */
    invisibleMode: "collapse" | "keep-space";
    /**
     * This attribute lets you specify if the element is disabled.
     * If disabled, it will not fire any user interaction related event
     * (for example, click event).
     */
    disabled: boolean;
    /**
     * Like the `grid-templates-areas` CSS property, this attribute defines a grid
     * template by referencing the names of the areas which are specified with the
     * cells [area attribute](../table-cell/readme.md#area). Repeating the name of
     * an area causes the content to span those cells. A period signifies an
     * empty cell. The syntax itself provides a visualization of the structure of
     * the grid.
     */
    areasTemplate: string;
    /**
     * Like the `grid-templates-columns` CSS property, this attribute defines
     * the columns of the grid with a space-separated list of values. The values
     * represent the width of column.
     */
    columnsTemplate: string;
    /**
     * Like the `grid-templates-rows` CSS property, this attribute defines the
     * rows of the grid with a space-separated list of values. The values
     * represent the height of each row.
     */
    rowsTemplate: string;
    /**
     * Emitted when the element is clicked.
     */
    onClick: EventEmitter;
    handleClick(event: UIEvent): void;
    render(): JSX.Element;
}
