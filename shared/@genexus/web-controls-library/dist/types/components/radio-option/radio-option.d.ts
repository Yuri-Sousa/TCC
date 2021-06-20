import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const RadioOption_base: {
    new (...args: any[]): {
        checkedTmr: any;
        didLoad: boolean;
        element: HTMLElement;
        caption: string;
        checked: boolean;
        cssClass: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        name: string;
        value: string;
        nativeInput: HTMLInputElement;
        inputId: string;
        onChange: EventEmitter<any>;
        gxSelect: EventEmitter<any>;
        getNativeInputId(): string;
        getCssClasses(): string;
        getInnerControlContainerClass(): string;
        handleClick(): void;
        handleChange(event: UIEvent): void;
        checkedChanged(isChecked: boolean): void;
        disabledChanged(isDisabled: boolean): void;
        componentDidLoad(): void; /**
         * Emitted when the radio loads.
         */
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class RadioOption extends RadioOption_base {
    element: HTMLElement;
    /**
     * Specifies the label of the radio.
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
     * The identifier of the control. Must be unique.
     */
    id: string;
    /**
     * The name of the inner input of type radio
     */
    name: string;
    /**
     * The initial value of the control.
     */
    value: string;
    /**
     * The `change` event is emitted when a change to the element's value is
     * committed by the user.
     */
    onChange: EventEmitter;
    /**
     * Emitted when the radio button is selected.
     */
    gxSelect: EventEmitter;
    /**
     * Emitted when the radio loads.
     */
    gxRadioDidLoad: EventEmitter;
    /**
     * Emitted when the radio unloads.
     */
    gxRadioDidUnload: EventEmitter;
    protected checkedChanged(isChecked: boolean): void;
    disabledChanged(isDisabled: boolean): void;
    componentDidLoad(): void;
    componentDidUnload(): void;
}
export interface IHTMLRadioOptionElementEvent extends CustomEvent {
    target: any;
}
export {};
