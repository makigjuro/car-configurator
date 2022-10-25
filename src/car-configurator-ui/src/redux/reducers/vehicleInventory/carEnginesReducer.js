import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carEnginesReducer(state = initialState.carEngines, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_ENGINES:
      return action.carEngines;
    default:
      return state;
  }
}
