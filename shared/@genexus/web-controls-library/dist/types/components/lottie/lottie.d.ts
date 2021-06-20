import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
import { BaseComponent } from "../common/base-component";
export declare class Lottie extends BaseComponent {
    private animation;
    private animationTotalFrames;
    element: HTMLElement;
    /**
     * This attribute lets you specify a Lottie animation object
     *
     */
    animationData: any;
    /**
     * This attribute lets you specify if the animation will start playing as soon as it is ready
     *
     */
    autoPlay: boolean;
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
     * This attribute lets you specify if the element is disabled.
     * If disabled, it will not fire any user interaction related event
     * (for example, click event).
     */
    disabled: boolean;
    /**
     * This attribute lets you specify if the animation will loop
     */
    loop: boolean;
    /**
     * This attribute lets you specify  the relative path to the animation object. (`animationData` and `path` are mutually exclusive)
     */
    path: string;
    /**
     * Emitted when the element is clicked.
     */
    onClick: EventEmitter;
    /**
     * Emitted when the animation is loaded in the DOM.
     */
    animationLoad: EventEmitter;
    animationDataChanged(): void;
    pathChanged(): void;
    /**
     * Pause the animation
     */
    pause(): void;
    /**
     * Start playing the animation
     */
    play(from?: number, to?: number): void;
    /**
     * Set the progress of the animation to any point
     * @param progress: Value from 0 to 1 indicating the percentage of progress where the animation will start.
     */
    setProgress(progress: number): void;
    /**
     * Stop the animation
     */
    stop(): void;
    private durationToFrames;
    handleClick(event: UIEvent): void;
    componentDidLoad(): void;
    componentDidUpdate(): void;
    componentDidUnload(): void;
    setAnimation(): void;
    private animationDomLoadedHandler;
    render(): JSX.Element;
}
