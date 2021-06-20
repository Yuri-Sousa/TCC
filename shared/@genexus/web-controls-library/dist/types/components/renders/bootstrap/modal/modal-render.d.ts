import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function ModalRender<T extends Constructor<{}>>(Base: T): {
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
} & T;
export {};
