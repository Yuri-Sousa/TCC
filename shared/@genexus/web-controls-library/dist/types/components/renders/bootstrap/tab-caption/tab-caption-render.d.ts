import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function TabCaptionRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        element: HTMLElement;
        disabled: boolean;
        selected: boolean;
        onTabSelect: EventEmitter<any>;
        render(): JSX.Element;
        clickHandler(event: UIEvent): void;
    };
} & T;
export {};
