import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
export declare class Image extends BaseComponent {
    /**
     * This attribute lets you specify the alternative text.
     */
    alt: string;
    /**
     * A CSS class to set as the inner element class.
     */
    cssClass: string;
    /**
     * This attribute lets you specify if the element is disabled.
     * If disabled, it will not fire any user interaction related event
     * (for example, click event).
     */
    disabled: boolean;
    /**
     * This attribute lets you specify the height.
     */
    height: string;
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
     * This attribute lets you specify the low resolution image SRC.
     */
    lowResolutionSrc: string;
    /**
     * This attribute lets you specify the SRC.
     */
    src: string;
    /**
     * This attribute lets you specify the width.
     */
    width: string;
    /**
     * Emitted when the element is clicked.
     */
    onClick: EventEmitter;
    handleClick(event: UIEvent): void;
    render(): JSX.Element;
}
