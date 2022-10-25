import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carBrandsReducer(state = initialState.carBrands, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_BRANDS:
      return action.carBrands;
    default:
      return state;
  }
}
