import '../../../../stencil.core';
declare type Constructor<T> = new (...args: any[]) => T;
export declare function NavBarRender<T extends Constructor<{}>>(Base: T): {
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
} & T;
export {};
