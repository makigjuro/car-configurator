import * as ActionTypes from "../../actions/actionTypes";
import initialState from "../../initialState";

export function configReducer(state = initialState.config, action) {
  switch (action.type) {

    case ActionTypes.CONFIG_SET_CAR_BRAND:
      if(state.carBrandId === action.carBrandId){
        return state;
      }

      const newState = Object.assign({}, state);
      newState.carBrandId = action.carBrandId;
      return newState;
    case ActionTypes.CONFIG_SET_CAR_CONFIGURATION_ID:
      
    if(state.carConfigurationId === action.carConfigurationId){
        return state;
      }

      const newStateTwo = Object.assign({}, state);
      newStateTwo.carConfigurationId =  action.carConfigurationId;

      return newStateTwo;
    case ActionTypes.CONFIG_SET_STEP:
      if(state.currentStep === action.currentStep){
        return state;
      }

      const newStateThree = Object.assign({}, state);
      newStateThree.currentStep =  action.currentStep;

      return newStateThree;
    case ActionTypes.CONFIG_CHANGE_MODEL_ID:
      if(state.carModel?.carModelId === action.carModel?.carModelId){
        return state;
      }

      const newStateFour = Object.assign({}, state);
      newStateFour.carModel =  action.carModel;

      return newStateFour;
    case ActionTypes.CONFIG_CHANGE_ENGINE:
      const stt = Object.assign({}, state);
      stt.carEngine = action.carEngine;

      return stt;
    case ActionTypes.CONFIG_CHANGE_INTERIOR:
      const stt1 = Object.assign({}, state);
      stt1.carInterior = action.carInterior;

      return stt1;
    case ActionTypes.CONFIG_CHANGE_COLOR:
      const stt2 = Object.assign({}, state);
      stt2.carColor = action.carColor;

      return stt2;
    case ActionTypes.CONFIG_CHANGE_RIMS:
      const stt3 = Object.assign({}, state);
      stt3.carRims = action.carRims;

      return stt3;
    case ActionTypes.CONFIG_CHANGE_EXTRAS:

      let extraFound =state.carExtras.find(existingItem => 
        existingItem?.carItemId == action.carExtras.carItemId
      );

        if(!extraFound){
        const stt4 = Object.assign({}, state);

        stt4.carExtras.push(action.carExtras);
        return stt4;
  
      }

      return state;

    default:
      return state;
  }
}
