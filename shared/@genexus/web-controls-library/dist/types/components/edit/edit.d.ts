import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const Edit_base: {
    new (...args: any[]): {
        element: HTMLElement;
        autocapitalize: string;
        autocomplete: string;
        autocorrect: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        multiline: boolean;
        placeholder: string;
        readonly: boolean;
        showTrigger: boolean;
        triggerText: string;
        type: string;
        value: string;
        nativeInput: HTMLInputElement;
        inputId: string;
        onChange: EventEmitter<any>;
        onInput: EventEmitter<any>;
        gxTriggerClick: EventEmitter<any>;
        getNativeInputId(): string;
        getCssClasses(): string;
        getTriggerCssClasses(): string;
        getValueFromEvent(event: UIEvent): string;
        handleChange(event: UIEvent): void;
        handleValueChanging(event: UIEvent): void;
        handleTriggerClick(event: UIEvent): void;
        valueChanged(): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class Edit extends Edit_base {
    element: HTMLElement;
    area: string;
    /**
     * Specifies the auto-capitalization behavior. Same as [autocapitalize](https://developer.apple.com/library/content/documentation/AppleApplications/Reference/SafariHTMLRef/Articles/Attributes.html#//apple_ref/doc/uid/TP40008058-autocapitalize)
     * attribute for `input` elements. Only supported by Safari and Chrome.
     */
    autocapitalize: "none" | "sentences" | "words" | "characters";
    /**
     * This attribute indicates whether the value of the control can be
     * automatically completed by the browser. Same as [autocomplete](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#attr-autocomplete)
     * attribute for `input` elements.
     */
    autocomplete: "on" | "off";
    /**
     * Used to control whether autocorrection should be enabled when the user
     * is entering/editing the text value. Sames as [autocorrect](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#attr-autocorrect)
     * attribute for `input` elements.
     */
    autocorrect: string;
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
     * Controls if the element accepts multiline text.
     */
    multiline: boolean;
    /**
     * A hint to the user of what can be entered in the control. Same as [placeholder](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#attr-placeholder)
     * attribute for `input` elements.
     */
    placeholder: string;
    /**
     * This attribute indicates that the user cannot modify the value of the control.
     * Same as [readonly](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input#attr-readonly)
     * attribute for `input` elements.
     */
    readonly: boolean;
    /**
     * If true, a trigger button is shown next to the edit field. The button can
     * be customized using `trigger-text` and `trigger-class` attributes,
     * or adding a child element with `slot="trigger-content"` attribute to
     * specify the content inside the trigger button.
     */
    showTrigger: boolean;
    /**
     * The text of the trigger button. If a text is specified and an image is
     * specified (through an element with `slot="trigger-content"`), the content
     * is ignored and the text is used instead.
     */
    triggerText: string;
    /**
     * The type of control to render. A subset of the types supported by the `input` element is supported:
     *
     * * `"date"`
     * * `"datetime-local"`
     * * `"email"`
     * * `"file"`
     * * `"number"`
     * * `"password"`
     * * `"search"`
     * * `"tel"`
     * * `"text"`
     * * `"url"`
     */
    type: "date" | "datetime-local" | "email" | "file" | "number" | "password" | "search" | "tel" | "text" | "url";
    /**
     * The initial value of the control.
     */
    value: string;
    /**
     * The `change` event is emitted when a change to the element's value is
     * committed by the user. Unlike the `input` event, the `change` event is not
     * necessarily fired for each change to an element's value but when the
     * control loses focus.
     */
    onChange: EventEmitter;
    /**
     * The `input` event is fired synchronously when the value is changed.
     */
    onInput: EventEmitter;
    /**
     * The `gxTriggerClick` event is fired when the trigger button is clicked.
     */
    gxTriggerClick: EventEmitter;
    /**
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId(): string;
    componentDidLoad(): void;
    protected valueChanged(): void;
    private toggleValueSetClass;
}
export {};
