import * as ActionTypes from "../actions/actionTypes";

export function setCarBrandIdSuccess(carBrandId) {
  return { type: ActionTypes.CONFIG_SET_CAR_BRAND, carBrandId };
}

export function setCarBrandId(carBrandId) {
  return function(dispatch) {
    dispatch(setCarBrandIdSuccess(carBrandId));
  };
}

export function setCarConfigIdSuccess(carConfigurationId) {
    return { type: ActionTypes.CONFIG_SET_CAR_CONFIGURATION_ID, carConfigurationId };
}

export function setCarConfigId(carConfigurationId) {
    return function(dispatch) {
        dispatch(setCarConfigIdSuccess(carConfigurationId));
    };
}

export function setCurrentStepSuccess(currentStep) {
    return { type: ActionTypes.CONFIG_SET_STEP, currentStep };
}

export function setCurrentStep(currentStep) {
    return function(dispatch) {
        dispatch(setCurrentStepSuccess(currentStep));
    };
}

export function changeModelSuccess(carModel) {
    return { type: ActionTypes.CONFIG_CHANGE_MODEL_ID, carModel };
}

export function changeModel(carModel) {
    return function(dispatch) {
        dispatch(changeModelSuccess(carModel));
    };
}

export function changeConfigColorSuccess(carColor) {
    return { type: ActionTypes.CONFIG_CHANGE_COLOR, carColor };
}

export function changeConfigColor(carColor) {
    return function(dispatch) {
        dispatch(changeConfigColorSuccess(carColor));
    };
}

export function changeConfigRimsSuccess(carRims) {
    return { type: ActionTypes.CONFIG_CHANGE_RIMS, carRims };
}

export function changeConfigRims(carRims) {
    return function(dispatch) {
        dispatch(changeConfigRimsSuccess(carRims));
    };
}


export function changeConfigEngineSuccess(carEngine) {
    return { type: ActionTypes.CONFIG_CHANGE_ENGINE, carEngine };
}

export function changeConfigEngine(carEngine) {
    return function(dispatch) {
        dispatch(changeConfigEngineSuccess(carEngine));
    };
}

export function changeConfigInteriorSuccess(carInterior) {
    return { type: ActionTypes.CONFIG_CHANGE_INTERIOR, carInterior };
}

export function changeConfigInterior(carInterior) {
    return function(dispatch) {
        dispatch(changeConfigInteriorSuccess(carInterior));
    };
}


export function changeConfigExtrasSuccess(carExtras) {
    return { type: ActionTypes.CONFIG_CHANGE_EXTRAS, carExtras };
}

export function changeConfigExtras(carExtras) {
    return function(dispatch) {
        dispatch(changeConfigExtrasSuccess(carExtras));
    };
}