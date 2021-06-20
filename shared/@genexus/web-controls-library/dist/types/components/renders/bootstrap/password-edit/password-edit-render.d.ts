import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function PasswordEditRender<T extends Constructor<{}>>(Base: T): {
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
        /**
         * Update the native input element when the value changes
         */
        valueChanged(): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & T;
export {};
