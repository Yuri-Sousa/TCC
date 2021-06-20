import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
export declare class CanvasCell extends BaseComponent {
    element: HTMLElement;
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
