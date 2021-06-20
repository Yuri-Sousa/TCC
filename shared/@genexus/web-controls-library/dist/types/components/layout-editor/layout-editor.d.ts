import '../../stencil.core';
import { EventEmitter } from "../../stencil.core";
export declare class LayoutEditor {
    element: HTMLElement;
    /**
     * The abstract form model object
     */
    model: any;
    /**
     * Array with the identifiers of the selected control's cells. If empty the whole layout-editor is marked as selected.
     */
    selectedCells: string[];
    /**
     * Fired when a control is moved inside the layout editor to a new location
     *
     * An object containing information of the move operation is sent in the `detail` property of the event object
     *
     * Regardless where the control was dropped, the detail object will contain information about the source row and the id of the dropped control:
     *
     * | Property         | Details                                                                                                          |
     * | ---------------- | ---------------------------------------------------------------------------------------------------------------- |
     * | `sourceCellId`   | Identifier of the source cell                                                                                    |
     * | `sourceRowId`    | Identifier of the source row                                                                                     |
     *
     * Depending on where the control was dropped, additional information will be provided and different properties will be set. There are four possible cases:
     *
     * 1. Dropped on an empty container or on a new row that will be the last row of a container
     * 2. Dropped on a new row of a non empty container
     * 3. Dropped on an existing empty cell
     * 4. Dropped on an existing row
     *
     *
     * ###### 1. Dropped on an empty container or on a new row that will be the last row of a container
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `containerId`     | Identifier of the container where the control was dropped                                                                                   |
     *
     * ###### 2. Dropped on a new row of a non empty container
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `beforeRowId`     | Identifier of the row next to the row where the control was dropped. An empty string if dropped in the last row or on an empty container.   |
     *
     * ###### 3. Dropped on an existing empty cell
     *
     * | Property      | Details                                                                                                          |
     * | ------------- | ---------------------------------------------------------------------------------------------------------------- |
     * | `targetCellId`| Identifier of the cell where the control was dropped |
     *
     *  ###### 4. Dropped on an existing row
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `beforeCellId`    | Identifier of the cell that, after the drop operation, ends located after the dropped control. An empty string if dropped as the last cell. |
     * | `targetRowId`     | Identifier of the row where the control was dropped                                                                                         |
     *
     */
    moveCompleted: EventEmitter;
    /**
     * Fired when a control (that wasn't already inside the layout editor) has been dropped on
     * a valid drop target (for example, a control from a toolbox or an object from the knowledge base navigator)
     *
     * ##### Dragging a control
     *
     * If a control is being dragged, the dataTransfer property of the event must have the following format:
     *
     * `"GX_DASHBOARD_ADDELEMENT,[GeneXus type of control]"`
     *
     * where:
     *
     * * `GX_DASHBOARD_ADDELEMENT` is the type of action
     * * `[GeneXus type of control]` is the type of control that's been added. This value can have any value and will be passed as part of the information sent as part of the event.
     *
     * ##### Dragging a KB object
     *
     * If a KB object is being dragged, the dataTransfer property of the event must contain the name of the KB object.
     *
     * ##### Dropped control information
     *
     * An object containing information of the add operation is sent in the `detail` property of the event object.
     *
     * If a KB object was dropped, the following properties are set:
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `kbObjectName`    | Name of the GeneXus object                                                                                                               |
     *
     * If control was dropped, the following properties are set.
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `elementType`     | The type of the control that's been added and was received as the `[GeneXus type of control]` in the dataTransfer of the drop operation     |
     *
     * Depending on where the control was dropped, additional information will be provided and different properties will be set. There are four possible cases:
     *
     * 1. Dropped on an empty container or in the last row of a container
     * 2. Dropped on a new row of a non empty container
     * 3. Dropped on an existing empty cell
     * 4. Dropped on an existing row
     *
     *
     * ###### 1. Dropped on an empty container or on a new row that will be the last row of a container
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `containerId`     | Identifier of the container where the control was dropped                                                                                   |
     *
     * ###### 2. Dropped on a new row of a non empty container
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `beforeRowId`     | Identifier of the row next to the row where the control was dropped. An empty string if dropped in the last row or on an empty container.   |
     *
     * ###### 3. Dropped on an existing empty cell
     *
     * | Property      | Details                                                                                                          |
     * | ------------- | ---------------------------------------------------------------------------------------------------------------- |
     * | `targetCellId`| Identifier of the cell where the control was dropped |
     *
     *  ###### 4. Dropped on an existing row
     *
     * | Property          | Details                                                                                                                                     |
     * | ----------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `beforeCelllId`   | Identifier of the cell that, after the drop operation, ends located after the dropped control. An empty string if dropped as the last cell. |
     * | `targetRowId`     | Identifier of the row where the control was dropped                                                                                         |
     *
     *
     */
    controlAdded: EventEmitter;
    /**
     * Fired when a control has been removed from the layout
     *
     * An object containing information of the add operation is sent in the `detail` property of the event object
     *
     * | Property           | Details                                                                                                                                     |
     * | ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- |
     * | `cellIds`          | Identifier of the removed cells |
     *
     */
    controlRemoved: EventEmitter;
    /**
     * Fired when the selection has been changed
     *
     * An object containing information of the select operation is sent in the `detail` property of the event object
     *
     * | Property       | Details                           |
     * | -------------- | --------------------------------- |
     * | `cellIds`      | Identifier of the selected cells  |
     *
     */
    controlSelected: EventEmitter;
    private drake;
    private dragulaOptions;
    private ignoreDragulaDrop;
    private ddDroppedEl;
    componentDidLoad(): void;
    componentWillUpdate(): void;
    private handleKeyDown;
    private handleDelete;
    private initDragAndDrop;
    private handleMoveElementDrop;
    private handleExternalElementOver;
    private handleExternalElementDrop;
    private getEventDataForDropAction;
    private getDropAreas;
    private restoreAfterDragDrop;
    componentDidUpdate(): void;
    componentDidUnload(): void;
    render(): JSX.Element;
    watchSelectedCells(): void;
    private handleClick;
    private handleSelection;
    private updateSelection;
}
