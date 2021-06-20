import '../../stencil.core';
import { BaseComponent } from "../common/base-component";
export declare class TabPage extends BaseComponent {
    element: HTMLElement;
    componentWillLoad(): void;
    hostData(): {
        role: string;
        tabindex: number;
    };
    render(): JSX.Element;
}
