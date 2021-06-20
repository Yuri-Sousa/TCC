import { BaseComponent } from "../common/base-component";
// tslint:disable-next-line
import bodymovin from "lottie-web/build/player/lottie_light";
export class Lottie extends BaseComponent {
    constructor() {
        super(...arguments);
        /**
         * This attribute lets you specify if the animation will start playing as soon as it is ready
         *
         */
        this.autoPlay = true;
        /**
         * This attribute lets you specify how this element will behave when hidden.
         *
         * | Value        | Details                                                                     |
         * | ------------ | --------------------------------------------------------------------------- |
         * | `keep-space` | The element remains in the document flow, and it does occupy space.         |
         * | `collapse`   | The element is removed form the document flow, and it doesn't occupy space. |
         */
        this.invisibleMode = "collapse";
        /**
         * This attribute lets you specify if the element is disabled.
         * If disabled, it will not fire any user interaction related event
         * (for example, click event).
         */
        this.disabled = false;
        /**
         * This attribute lets you specify if the animation will loop
         */
        this.loop = true;
    }
    animationDataChanged() {
        this.animation.destroy();
        this.animation = null;
    }
    pathChanged() {
        this.animation.destroy();
        this.animation = null;
    }
    /**
     * Pause the animation
     */
    pause() {
        this.animation.pause();
    }
    /**
     * Start playing the animation
     */
    play(from = 0, to = 0) {
        if (from || to) {
            if (!to) {
                to = from;
                from = 0;
            }
            const fromFrame = this.durationToFrames(from);
            const toFrame = this.durationToFrames(to);
            this.animation.playSegments([fromFrame, toFrame]);
        }
        else {
            this.animation.play();
        }
    }
    /**
     * Set the progress of the animation to any point
     * @param progress: Value from 0 to 1 indicating the percentage of progress where the animation will start.
     */
    setProgress(progress) {
        const progressInFrames = this.durationToFrames(progress);
        this.animation.goToAndPlay(progressInFrames, true);
    }
    /**
     * Stop the animation
     */
    stop() {
        this.animation.stop();
    }
    durationToFrames(duration) {
        return Math.trunc(this.animationTotalFrames * duration);
    }
    handleClick(event) {
        if (this.disabled) {
            return;
        }
        this.onClick.emit(event);
    }
    componentDidLoad() {
        this.setAnimation();
    }
    componentDidUpdate() {
        this.setAnimation();
    }
    componentDidUnload() {
        this.animation.destroy();
    }
    setAnimation() {
        if (this.animation) {
            this.animation.loop = this.loop;
            return;
        }
        this.animation = bodymovin.loadAnimation({
            animationData: this.animationData,
            autoplay: this.autoPlay,
            container: this.element.querySelector(":scope > div"),
            loop: this.loop,
            path: this.path,
            renderer: "svg"
        });
        this.animationTotalFrames = this.animation.getDuration(true);
        this.animation.addEventListener("DOMLoaded", this.animationDomLoadedHandler.bind(this));
    }
    animationDomLoadedHandler(event) {
        this.animationLoad.emit(event);
    }
    render() {
        return h("div", null);
    }
    static get is() { return "gx-lottie"; }
    static get properties() { return {
        "animationData": {
            "type": "Any",
            "attr": "animation-data",
            "watchCallbacks": ["animationDataChanged"]
        },
        "autoPlay": {
            "type": Boolean,
            "attr": "auto-play"
        },
        "disabled": {
            "type": Boolean,
            "attr": "disabled"
        },
        "element": {
            "elementRef": true
        },
        "invisibleMode": {
            "type": String,
            "attr": "invisible-mode"
        },
        "loop": {
            "type": Boolean,
            "attr": "loop"
        },
        "path": {
            "type": String,
            "attr": "path",
            "watchCallbacks": ["pathChanged"]
        },
        "pause": {
            "method": true
        },
        "play": {
            "method": true
        },
        "setProgress": {
            "method": true
        },
        "stop": {
            "method": true
        }
    }; }
    static get events() { return [{
            "name": "onClick",
            "method": "onClick",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }, {
            "name": "animationLoad",
            "method": "animationLoad",
            "bubbles": true,
            "cancelable": true,
            "composed": true
        }]; }
    static get style() { return "/**style-placeholder:gx-lottie:**/"; }
}
