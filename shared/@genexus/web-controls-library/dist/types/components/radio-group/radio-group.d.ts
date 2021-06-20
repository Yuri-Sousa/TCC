import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
import { IHTMLRadioOptionElementEvent } from "../radio-option/radio-option";
export declare class RadioGroup extends BaseComponent {
    private radios;
    private didLoad;
    protected element: HTMLElement;
    /**
     * Specifies how the child `gx-radio-option` will be layed out.
     * It supports two values:
     *
     * * `horizontal`
     * * `vertical` (default)
     */
    direction: "horizontal" | "vertical";
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
     * The name that will be set to all the inner inputs of type radio
     */
    name: string;
    /**
     * The initial value of the control. Setting the value automatically selects
     * the corresponding radio option.
     */
    value: string;
    /**
     * The `change` event is emitted when a change to the element's value is
     * committed by the user.
     */
    onChange: EventEmitter;
    private getValueFromEvent;
    handleChange(event: UIEvent): void;
    disabledChanged(): void;
    valueChanged(): void;
    onRadioDidLoad(ev: IHTMLRadioOptionElementEvent): void;
    onRadioDidUnload(ev: IHTMLRadioOptionElementEvent): void;
    onRadioSelect(ev: IHTMLRadioOptionElementEvent): void;
    setDisabled(): void;
    componentDidLoad(): void;
    hostData(): {
        role: string;
    };
    render(): JSX.Element;
}
