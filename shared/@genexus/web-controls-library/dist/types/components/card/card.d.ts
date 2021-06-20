import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
declare const Card_base: {
    new (...args: any[]): {
        element: HTMLElement;
        bodyClickHandler: any;
        popper: any;
        handleDropDownToggleClick(evt: any): void;
        componentDidUnload(): void;
        componentDidLoad(): void;
        componentDidUpdate(): void;
        toggleHeaderFooterVisibility(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class Card extends Card_base {
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
    componentDidLoad(): void;
    componentDidUpdate(): void;
    componentDidUnload(): void;
}
export {};
