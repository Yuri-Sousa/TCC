import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function EditRender<T extends Constructor<{}>>(Base: T): {
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
        /**
         * Update the native input element when the value changes
         */
        valueChanged(): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & T;
export {};
