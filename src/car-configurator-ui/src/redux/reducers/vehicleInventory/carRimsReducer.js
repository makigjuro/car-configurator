import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carRimsReducer(state = initialState.carRims, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_RIMS:
      return action.carRims;
    default:
      return state;
  }
}
