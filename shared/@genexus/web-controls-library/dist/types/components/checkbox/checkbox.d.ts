import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
import { EventEmitter } from "../../stencil.core";
declare const CheckBox_base: {
    new (...args: any[]): {
        element: HTMLElement;
        caption: string;
        cssClass: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        checked: boolean;
        nativeInput: HTMLInputElement;
        inputId: string;
        /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
        onChange: EventEmitter<any>;
        getNativeInputId(): string;
        getCssClasses(): string;
        getValueFromEvent(event: UIEvent): boolean;
        handleChange(event: UIEvent): void;
        checkedChanged(): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class CheckBox extends CheckBox_base {
    element: HTMLElement;
    /**
     * This attribute lets you specify how this element will behave when hidden.
     *
     * | Value        | Details                                                                     |
     * | ------------ | --------------------------------------------------------------------------- |
     * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
     * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
     */
    invisibleMode: "collapse" | "keep-space";
    /**
     * This attribute lets you specify if the element is disabled.
     * If disabled, it will not fire any user interaction related event
     * (for example, click event).
     */
    disabled: boolean;
    /**
     * Specifies the label of the checkbox.
     */
    caption: string;
    /**
     * Indicates that the control is selected by default.
     */
    checked: boolean;
    /**
     * A CSS class to set as the inner `input` element class.
     */
    cssClass: string;
    /**
     * The identifier of the control. Must be unique.
     */
    id: string;
    /**
     * The `change` event is emitted when a change to the element's value is committed by the user.
     */
    onChange: EventEmitter;
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId(): string;
    protected checkedChanged(): void;
}
export {};
