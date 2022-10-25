import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carItemTypesReducer(state = initialState.carItemTypes, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_ITEM_TYPES:
      return action.carItemTypes;
    default:
      return state;
  }
}
