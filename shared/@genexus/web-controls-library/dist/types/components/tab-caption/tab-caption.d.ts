import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const TabCaption_base: {
    new (...args: any[]): {
        element: HTMLElement;
        disabled: boolean;
        selected: boolean;
        onTabSelect: EventEmitter<any>;
        render(): JSX.Element;
        clickHandler(event: UIEvent): void;
    };
} & typeof BaseComponent;
export declare class TabCaption extends TabCaption_base {
    element: HTMLElement;
    /**
     * This attribute lets you specify if the tab page is disabled
     *
     */
    disabled: false;
    /**
     * This attribute lets you specify if the tab page corresponding to this caption is selected
     *
     */
    selected: false;
    /**
     * Fired when the tab caption is selected
     *
     */
    onTabSelect: EventEmitter;
    componentWillLoad(): void;
    hostData(): {
        role: string;
    };
}
export {};
