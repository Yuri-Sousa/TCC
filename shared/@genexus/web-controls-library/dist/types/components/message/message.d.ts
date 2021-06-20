import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
declare const Message_base: {
    new (...args: any[]): {
        element: HTMLElement;
        showCloseButton: boolean;
        closeButtonText: string;
        type: string;
        duration: number;
        dismissing: boolean;
        wrapperClass(): {
            [x: string]: boolean;
            alert: boolean;
            "alert-dismissible": boolean;
            fade: boolean;
        };
        dismiss(): void;
        transitionEnd(): void;
        componentDidLoad(): void;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class Message extends Message_base {
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
     * Show a button for closing the meesage box
     */
    showCloseButton: boolean;
    /**
     * Text for the close button.
     */
    closeButtonText: string;
    /**
     * Type of the button:
     * * `info`: Information message
     * * `warning`: Warning Message
     * * `error`: Error message
     */
    type: "info" | "warning" | "error";
    /**
     * The time in miliseconds before the message is automatically dismissed.
     * If no duration is specified, the message will not be automatically dismissed.
     */
    duration: number;
    componentDidLoad(): void;
}
export {};
