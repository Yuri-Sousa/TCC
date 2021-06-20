import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function NavBarLinkRender<T extends Constructor<{}>>(Base: T): {
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
} & T;
export {};
