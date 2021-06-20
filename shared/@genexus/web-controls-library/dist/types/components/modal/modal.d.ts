import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
declare const Modal_base: {
    new (...args: any[]): {
        element: HTMLElement;
        autoClose: boolean;
        closeButtonLabel: string;
        id: string;
        opened: boolean;
        onClose: EventEmitter<any>;
        onOpen: EventEmitter<any>;
        headerId: string;
        bootstrapModal: any;
        componentDidLoad(): void;
        render(): JSX.Element;
        open(): void;
        close(): void;
        getModalElement(): Element;
        getActionCssClasses(currentCssClasses: any, ...newClasses: any[]): string;
    };
} & typeof BaseComponent;
export declare class Modal extends Modal_base {
    element: HTMLElement;
    /**
     * This attribute lets you specify if the modal dialog is automatically closed when an action is clicked.
     */
    autoClose: boolean;
    /**
     * This attribute lets you specify the label for the close button. Important for accessibility.
     */
    closeButtonLabel: string;
    /**
     * This attribute lets you specify if the modal dialog is opened or closed.
     */
    opened: boolean;
    /**
     * Fired when the modal dialog is closed
     */
    onClose: EventEmitter;
    /**
     * Fired when the modal dialog is opened
     */
    onOpen: EventEmitter;
    openedHandler(newValue: boolean, oldValue?: boolean): void;
}
export {};
