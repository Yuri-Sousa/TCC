// tslint:disable-next-line
import Bootstrap from "bootstrap.native/dist/bootstrap-native-v4";
const BODY_SLOT_NAME = "body";
const PRIMARY_ACTION_SLOT_NAME = "primary-action";
const SECONDARY_ACTION_SLOT_NAME = "secondary-action";
export function ModalRender(Base) {
    return class extends Base {
        componentDidLoad() {
            const modalElement = this.getModalElement();
            modalElement.addEventListener("show.bs.modal", e => {
                this.onOpen.emit(e);
                this.opened = true;
            });
            modalElement.addEventListener("hide.bs.modal", e => {
                this.onClose.emit(e);
                this.opened = false;
            });
            this.bootstrapModal = new Bootstrap.Modal(modalElement, {
                show: this.opened
            });
            if (this.autoClose) {
                const actions = Array.from(this.element.querySelectorAll(`[slot='${PRIMARY_ACTION_SLOT_NAME}'], [slot='${SECONDARY_ACTION_SLOT_NAME}']`));
                actions.forEach(action => action.addEventListener("click", () => this.close()));
            }
        }
        render() {
            const primaryActions = Array.from(this.element.querySelectorAll(`[slot='${PRIMARY_ACTION_SLOT_NAME}']`));
            primaryActions.forEach(action => (action.cssClass = this.getActionCssClasses(action.cssClass, "btn-primary")));
            const secondaryActions = Array.from(this.element.querySelectorAll(`[slot='${SECONDARY_ACTION_SLOT_NAME}']`));
            secondaryActions.forEach(action => (action.cssClass = this.getActionCssClasses(action.cssClass, "btn-secondary")));
            const hasFooterActions = primaryActions.length || secondaryActions.length;
            if (!this.headerId) {
                this.headerId = this.id
                    ? `${this.id}__modal`
                    : `gx-modal-auto-id-${autoId++}`;
            }
            return (h("div", { class: "modal fade", tabindex: "-1", role: "dialog", "aria-labelledby": this.headerId, "aria-hidden": "true" },
                h("div", { class: "modal-dialog", role: "document" },
                    h("div", { class: "modal-content" },
                        h("div", { class: "modal-header" },
                            h("h5", { class: "modal-title", id: this.headerId },
                                h("slot", { name: "header" })),
                            h("button", { type: "button", class: "close", "data-dismiss": "modal", "aria-label": this.closeButtonLabel },
                                h("span", { "aria-hidden": "true" }, "\u00D7"))),
                        h("div", { class: "modal-body" },
                            h("slot", { name: BODY_SLOT_NAME })),
                        hasFooterActions ? (h("div", { class: "modal-footer" },
                            h("slot", { name: PRIMARY_ACTION_SLOT_NAME }),
                            h("slot", { name: SECONDARY_ACTION_SLOT_NAME }))) : null))));
        }
        open() {
            this.bootstrapModal.show();
        }
        close() {
            this.bootstrapModal.hide();
        }
        getModalElement() {
            return this.element.querySelector(".modal");
        }
        getActionCssClasses(currentCssClasses, ...newClasses) {
            return (currentCssClasses || "")
                .split(" ")
                .concat(...newClasses)
                .join(" ");
        }
    };
}
let autoId = 0;
