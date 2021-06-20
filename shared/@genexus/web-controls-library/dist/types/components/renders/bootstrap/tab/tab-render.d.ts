import '../../../../stencil.core';
declare type Constructor<T> = new (...args: any[]) => T;
export declare function TabRender<T extends Constructor<{}>>(Base: T): {
    new (...args: any[]): {
        element: HTMLElement;
        setSelectedTab(captionElement: HTMLElement): void;
        mapPageToCaptionSelection(captionElement: any, pageElement: HTMLElement): void;
        render(): JSX.Element;
        setCaptionSlotsClass(): void;
        getCaptionSlots(): Element[];
        setPageSlotsClass(): void;
        getPageSlots(): Element[];
    };
} & T;
export {};
