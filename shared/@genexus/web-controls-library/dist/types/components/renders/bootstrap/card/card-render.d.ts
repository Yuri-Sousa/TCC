import '../../../../stencil.core';
declare type Constructor<T> = new (...args: any[]) => T;
export declare function CardRender<T extends Constructor<{}>>(Base: T): {
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
} & T;
export {};
