import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
import { EventEmitter } from "../../stencil.core";
declare const Button_base: {
    new (...args: any[]): {
        element: HTMLElement;
        disabled: boolean;
        onClick: EventEmitter<any>;
        size: string;
        cssClass: string;
        handleClick(event: UIEvent): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class Button extends Button_base {
    element: HTMLElement;
    /**
     * A CSS class to set as the inner `input` element class.
     */
    cssClass: string;
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
     * (for example, click event). If a disabled image has been specified,
     * it will be shown, hiding the base image (if specified).
     */
    disabled: boolean;
    /**
     * This attribute lets you specify the relative location of the image to the text.
     *
     * | Value    | Details                                                 |
     * | -------- | ------------------------------------------------------- |
     * | `above`  | The image is located above the text.                    |
     * | `before` | The image is located before the text, in the same line. |
     * | `after`  | The image is located after the text, in the same line.  |
     * | `below`  | The image is located below the text.                    |
     * | `behind` | The image is located behind the text.                   |
     */
    imagePosition: "above" | "before" | "after" | "below" | "behind";
    /**
     * This attribute lets you specify the size of the button.
     *
     * | Value    | Details                                                 |
     * | -------- | ------------------------------------------------------- |
     * | `large`  | Large sized button.                                     |
     * | `normal` | Standard sized button.                                  |
     * | `small`  | Small sized button.                                     |
     */
    size: "large" | "normal" | "small";
    /**
     * Emitted when the element is clicked.
     */
    onClick: EventEmitter;
    hostData(): {
        role: string;
    };
}
export {};
