import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carColorsReducer(state = initialState.carColors, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_COLORS:
      return action.carColors;
    default:
      return state;
  }
}
