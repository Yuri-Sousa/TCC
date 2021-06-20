import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
export declare class TableCell extends BaseComponent {
    element: HTMLElement;
    /**
     * Like the `grid-area` CSS property, this attribute gives a name to the item,
     * so it can be used from the [areas-template attributes](../table/readme.md#areas-template)
     * of the gx-table element.
     */
    area: string;
    /**
     * Defines the horizontal aligmnent of the content of the cell.
     */
    align: "left" | "right" | "center";
    /**
     * This attribute defines how the control behaves when the content overflows.
     *
     * | Value    | Details                                                     |
     * | -------- | ----------------------------------------------------------- |
     * | `scroll` | The overflowin content is hidden, but scrollbars are shown  |
     * | `clip`   | The overflowing content is hidden, without scrollbars       |
     *
     */
    overflowMode: "scroll" | "clip";
    /**
     * Defines the vertical aligmnent of the content of the cell.
     */
    valign: "top" | "bottom" | "medium";
    render(): JSX.Element;
}
