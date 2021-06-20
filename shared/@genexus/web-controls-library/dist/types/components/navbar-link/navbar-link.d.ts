import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const NavBarLink_base: {
    new (...args: any[]): {
        active: boolean;
        cssClass: string;
        disabled: boolean;
        element: HTMLElement;
        href: string;
        onClick: EventEmitter<any>;
        handleClick(event: UIEvent): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class NavBarLink extends NavBarLink_base {
    element: HTMLElement;
    /**
     * Indicates if the navbar item is the active one (for example, when the item represents the current page)
     */
    active: boolean;
    /**
     * A CSS class to set as the inner element class.
     */
    cssClass: string;
    /**
     * This attribute lets you specify if the navbar item is disabled.
     */
    disabled: boolean;
    /**
     * This attribute lets you specify the URL of the navbar item.
     */
    href: string;
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
     * Emitted when the element is clicked.
     */
    onClick: EventEmitter;
}
export {};
