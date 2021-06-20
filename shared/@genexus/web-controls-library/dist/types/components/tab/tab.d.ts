import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const Tab_base: {
    new (...args: any[]): {
        element: HTMLElement;
        setSelectedTab(captionElement: HTMLElement): void;
        mapPageToCaptionSelection(captionElement: any, pageElement: HTMLElement): void;
        render(): JSX.Element;
        setCaptionSlotsClass(): void;
        getCaptionSlots(): Element[];
        setPageSlotsClass(): void;
        getPageSlots(): Element[];
    };
} & typeof BaseComponent;
export declare class Tab extends Tab_base {
    element: HTMLElement;
    private lastSelectedTab;
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
     * Fired when the active tab is changed
     *
     */
    onTabChange: EventEmitter;
    tabClickHandler(event: CustomEvent): void;
    setSelectedTab(captionElement: HTMLElement): void;
    componentDidLoad(): void;
    componentDidUpdate(): void;
    componentDidUnload(): void;
    private linkTabs;
}
export {};
