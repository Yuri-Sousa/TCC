import '../../../../stencil.core';
declare type Constructor<T> = new (...args: any[]) => T;
export declare function MessageRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        element: HTMLElement;
        showCloseButton: boolean;
        closeButtonText: string;
        type: string;
        duration: number;
        dismissing: boolean;
        wrapperClass(): {
            [x: string]: boolean;
            alert: boolean;
            "alert-dismissible": boolean;
            fade: boolean;
        };
        dismiss(): void;
        transitionEnd(): void;
        componentDidLoad(): void;
        render(): JSX.Element;
    };
} & T;
export {};
