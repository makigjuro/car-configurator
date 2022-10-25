import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function carConfigurationsReducer(state = initialState.configs, action) {
  switch (action.type) {
    case ActionTypes.LOAD_CAR_CONFIGS:
      return action.configs;
    default:
      return state;
  }
}
