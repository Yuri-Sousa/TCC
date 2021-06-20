import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const PasswordEdit_base: {
    new (...args: any[]): {
        element: HTMLElement;
        cssClass: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        placeholder: string;
        readonly: boolean;
        revealButtonTextOn: string;
        revealButtonTextOff: string;
        showRevealButton: boolean;
        value: string;
        onChange: EventEmitter<any>;
        onInput: EventEmitter<any>;
        innerEdit: any;
        revealed: boolean;
        getNativeInputId(): any;
        getValueFromEvent(event: UIEvent): string;
        handleChange(event: UIEvent): void;
        handleInput(event: UIEvent): void;
        handleTriggerClick(): void;
        valueChanged(): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class PasswordEdit extends PasswordEdit_base {
    element: HTMLElement;
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
     * Text of the reveal button to offer revealing the password.
     */
    revealButtonTextOn: string;
    /**
     * Text of the reveal button to offer hiding the password.
     */
    revealButtonTextOff: string;
    /**
     * If true, a reveal password button is shown next to the password input.
     * Pressing the reveal button toggles the password mask, allowing the user to
     * view the password text.
     */
    showRevealButton: boolean;
    /**
     * The initial value of the control.
     */
    value: string;
    protected revealed: boolean;
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
     * Returns the id of the inner `input` element (if set).
     */
    getNativeInputId(): any;
    protected valueChanged(): void;
    protected handleTriggerClick(): void;
}
export {};
