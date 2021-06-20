import '../../../../stencil.core';
declare type Constructor<T> = new (...args: any[]) => T;
export declare function ProgressBarRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        value: number;
        render(): JSX.Element;
    };
} & T;
export {};
