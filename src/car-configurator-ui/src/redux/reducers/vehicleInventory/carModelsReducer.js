import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carModelsReducer(state = initialState.carModels, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_MODELS:
      return action.carModels;
    default:
      return state;
  }
}
