import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
declare const ProgressBar_base: {
    new (...args: any[]): {
        value: number;
        render(): JSX.Element;
    };
} & typeof BaseComponent;
export declare class ProgressBar extends ProgressBar_base {
    /**
     * Sets the progress value.
     *
     */
    value: number;
}
export {};
