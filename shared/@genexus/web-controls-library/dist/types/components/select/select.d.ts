import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
import { IHTMLSelectOptionElementEvent } from "../select-option/select-option";
declare const Select_base: {
    new (...args: any[]): {
        options: any[];
        element: HTMLElement;
        cssClass: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        readonly: boolean;
        value: string;
        nativeSelect: HTMLSelectElement;
        selectId: string;
        onChange: EventEmitter<any>;
        getNativeInputId(): string;
        /**
         * A CSS class to set as the inner `input` element class.
         */
        getCssClasses(): string;
        getReadonlyTextContent(): any;
        getValueFromEvent(event: UIEvent): string;
        handleChange(event: UIEvent): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class Select extends Select_base {
    protected options: any[];
    private didLoad;
    protected element: HTMLElement;
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
     * This attribute indicates that the user cannot modify the value of the control.
     * Same as [readonly](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#attr-readonly)
     * attribute for `input` elements.
     */
    readonly: boolean;
    /**
     * The initial value of the control. Setting the value automatically selects
     * the corresponding option.
     */
    value: string;
    /**
     * The `change` event is emitted when a change to the element's value is
     * committed by the user.
     */
    onChange: EventEmitter;
    private getChildOptions;
    valueChanged(): void;
    onSelectOptionDidLoad(ev: IHTMLSelectOptionElementEvent): void;
    onSelectOptionDidUnload(): void;
    onSelectOptionDisable(): void;
    onSelectOptionChange(): void;
    onSelectOptionSelect(ev: IHTMLSelectOptionElementEvent): void;
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId(): string;
    setDisabled(): void;
    componentDidLoad(): void;
    hostData(): {
        role: string;
    };
}
export {};
