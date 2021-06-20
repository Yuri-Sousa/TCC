import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
declare const FormField_base: {
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
            /**
             * The text to set as the label of the field.
             */
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
} & typeof BaseComponent;
export declare class FormField extends FormField_base {
    element: HTMLElement;
    /**
     * The text to set as the label of the field.
     */
    labelCaption: string;
    /**
     * The position where the label will be located, relative to the edit control. The supported values are:
     *
     * * `"top"`: The label is located above the edit control.
     * * `"right"`: The label is located at the right side of the edit control.
     * * `"bottom"`: The label is located below the edit control.
     * * `"left"`: The label is located at the left side of the edit control.
     * * `"float"`: The label is shown as a placeholder when the edit control's value is empty. When the value is not empty, the label floats and locates above the edit control.
     * * `"none"`: The label is rendered, but hidden.
     */
    labelPosition: "none" | "top" | "right" | "bottom" | "left" | "float";
}
export {};
