import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function CheckBoxRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        element: HTMLElement;
        caption: string;
        cssClass: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        checked: boolean;
        nativeInput: HTMLInputElement;
        inputId: string;
        onChange: EventEmitter<any>;
        getNativeInputId(): string;
        getCssClasses(): string;
        getValueFromEvent(event: UIEvent): boolean;
        handleChange(event: UIEvent): void;
        /**
         * Update the native input element when the value changes
         */
        checkedChanged(): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & T;
export {};
