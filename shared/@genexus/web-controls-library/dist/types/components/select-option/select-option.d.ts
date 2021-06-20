import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
export declare class SelectOption extends BaseComponent {
    /**
     * Indicates that the control is selected by default.
     */
    selected: boolean;
    /**
     * A CSS class to set as the inner `input` element class.
     */
    cssClass: string;
    /**
     * This attribute lets you specify if the element is disabled.
     * If disabled, it will not fire any user interaction related event
     * (for example, click event).
     */
    disabled: boolean;
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
     * Emitted when the option is selected.
     */
    gxSelect: EventEmitter;
    /**
     * Emitted when the option is disabled.
     */
    gxDisable: EventEmitter;
    /**
     * Emitted when the option loads.
     */
    gxSelectDidLoad: EventEmitter;
    /**
     * Emitted when the option unloads.
     */
    gxSelectDidUnload: EventEmitter;
    protected selectedChanged(isSelected: boolean): void;
    protected disabledChanged(isDisabled: boolean): void;
    protected valueChanged(): void;
    componentDidLoad(): void;
    componentDidUnload(): void;
    hostData(): {
        "aria-hidden": string;
        hidden: boolean;
    };
    render(): JSX.Element;
}
export interface IHTMLSelectOptionElementEvent extends CustomEvent {
    target: any;
}
