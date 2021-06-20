import '../../../../stencil.core';
declare type Constructor<T> = new (...args: any[]) => T;
export declare function FormFieldRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        element: HTMLElement;
        id: string;
        labelCaption: string;
        labelPosition: string;
        formFieldId: string;
        LABEL_WIDTH_BY_POSITION: {
            bottom: string;
            float: string;
            left: string;
            none: string;
            right: string;
            top: string;
        };
        INNER_CONTROL_WIDTH_BY_LABEL_POSITION: {
            bottom: string;
            float: string;
            left: string;
            none: string;
            right: string;
            top: string;
        };
        getLabelCssClass(): string;
        getInnerControlContainerClass(): any;
        shouldRenderLabelBefore(): boolean;
        componentDidLoad(): void;
        renderForRadio(renderLabelBefore: boolean): JSX.Element;
        render(): JSX.Element;
    };
} & T;
export {};
