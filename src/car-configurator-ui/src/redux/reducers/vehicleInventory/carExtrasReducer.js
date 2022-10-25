import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carExtrasReducer(state = initialState.carExtras, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_EXTRAS:
      return action.carExtras;
    default:
      return state;
  }
}
