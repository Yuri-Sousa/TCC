import '../../../../stencil.core';
import { EventEmitter } from "../../../../stencil.core";
declare type Constructor<T> = new (...args: any[]) => T;
export declare function SelectRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        options: any[];
        element: HTMLElement;
        cssClass: string;
        disabled: boolean;
        id: string;
        invisibleMode: string;
        readonly: boolean;
        value: string;
        nativeSelect: HTMLSelectElement;
        selectId: string;
        onChange: EventEmitter<any>;
        getNativeInputId(): string;
        getCssClasses(): string;
        getReadonlyTextContent(): any;
        getValueFromEvent(event: UIEvent): string;
        handleChange(event: UIEvent): void;
        componentDidUnload(): void;
        render(): JSX.Element;
    };
} & T;
export {};
