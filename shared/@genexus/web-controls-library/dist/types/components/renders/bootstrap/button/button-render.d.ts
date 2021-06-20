import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function ButtonRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        element: HTMLElement;
        disabled: boolean;
        onClick: EventEmitter<any>;
        size: string;
        cssClass: string;
        handleClick(event: UIEvent): void;
        render(): JSX.Element;
    };
} & T;
export {};
