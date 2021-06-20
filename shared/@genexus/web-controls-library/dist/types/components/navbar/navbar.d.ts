import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
declare const NavBar_base: {
    new (...args: any[]): {
        id: string;
        caption: string;
        cssClass: string;
        element: HTMLElement;
        toggleButtonLabel: string;
        navBarId: string;
        expanded: boolean;
        transitioning: boolean;
        toggleCollapseHandler(event: UIEvent): void;
        expand(target: HTMLElement): void;
        collapse(target: HTMLElement): void;
        handleTransitionEnd(event: UIEvent): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class NavBar extends NavBar_base {
    element: HTMLElement;
    /**
     * This attribute lets you specify an optional title for the navigation bar
     *
     * | Value        | Details                                                                     |
     * | ------------ | --------------------------------------------------------------------------- |
     * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
     * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
     */
    caption: string;
    /**
     * This attribute lets you specify the label for the toggle button. Important for accessibility.
     */
    toggleButtonLabel: string;
    /**
     * A CSS class to set as the inner element class.
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
}
export {};
