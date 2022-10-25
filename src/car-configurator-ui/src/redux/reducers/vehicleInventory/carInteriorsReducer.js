import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carInteriorsReducer(state = initialState.carInteriors, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_INTERIORS:
      return action.carInteriors;
    default:
      return state;
  }
}
