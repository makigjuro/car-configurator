import * as ActionTypes from "../actions/actionTypes";
import * as vehicleInventoryApi from "../../api/vehicleInventoryService";

export function loadCarBrandsSuccess(carBrands) {
  return { type: ActionTypes.LOAD_CAR_BRANDS, carBrands };
}

export function loadCarBrands() {
  return function(dispatch) {
    return vehicleInventoryApi.getCarBrands().then(response => {
      dispatch(loadCarBrandsSuccess(response));

      if(response.length > 0){
        dispatch(loadCarModels(response[0].carBrandId))
      }
    });
  };
}

export function loadCarModelsSuccess(carModels) {
    return { type: ActionTypes.LOAD_CAR_MODELS, carModels };
}
  
export function loadCarModels(carBrandId) {

    if(carBrandId && carBrandId != ""){
      return function(dispatch) {
        return vehicleInventoryApi.getCarModels(carBrandId).then(response => {
          dispatch(loadCarModelsSuccess(response));
        });
      };
    }
}

export function loadCarItemTypesSuccess(carItemTypes) {
  return { type: ActionTypes.LOAD_CAR_ITEM_TYPES, carItemTypes };
}

export function loadCarItemTypes() {
  return function(dispatch) {
    return vehicleInventoryApi.getCarItemTypes().then(response => {
      dispatch(loadCarItemTypesSuccess(response));
    });
  };
}


export function loadCarEnginePowersSuccess(carEngines) {
  return { type: ActionTypes.LOAD_CAR_ENGINES, carEngines };
}

export function loadCarEnginePowers(carModelId, carItemTypeId) {

  if(carModelId && carModelId != "" && carItemTypeId && carItemTypeId != ""){
    return function(dispatch) {
      return vehicleInventoryApi.getCarItems(carModelId, carItemTypeId).then(response => {
        dispatch(loadCarEnginePowersSuccess(response));
      });
    };
  }
}

export function loadCarColorsSuccess(carColors) {
  return { type: ActionTypes.LOAD_CAR_COLORS, carColors };
}

export function loadCarColors(carModelId, carItemTypeId) {
  if(carModelId && carModelId != "" && carItemTypeId && carItemTypeId != ""){
    return function(dispatch) {
      return vehicleInventoryApi.getCarItems(carModelId, carItemTypeId).then(response => {
        dispatch(loadCarColorsSuccess(response));
      });
    };
  }
}


export function loadCarRimsSuccess(carRims) {
  return { type: ActionTypes.LOAD_CAR_RIMS, carRims };
}

export function loadCarRims(carModelId, carItemTypeId) {
  if(carModelId && carModelId != "" && carItemTypeId && carItemTypeId != ""){
    return function(dispatch) {
      return vehicleInventoryApi.getCarItems(carModelId, carItemTypeId).then(response => {
        dispatch(loadCarRimsSuccess(response));
      });
    };
  }
}

export function loadCarInteriorsSuccess(carInteriors) {
  return { type: ActionTypes.LOAD_CAR_INTERIORS, carInteriors };
}

export function loadCarInteriors(carModelId, carItemTypeId) {
  if(carModelId && carModelId != "" && carItemTypeId && carItemTypeId != ""){
    return function(dispatch) {
      return vehicleInventoryApi.getCarItems(carModelId, carItemTypeId).then(response => {
        dispatch(loadCarInteriorsSuccess(response));
      });
    };
  }
}


export function loadCarExtrasSuccess(carExtras) {
  return { type: ActionTypes.LOAD_CAR_EXTRAS, carExtras };
}

export function loadCarExtras(carModelId, carItemTypeId) {
  if(carModelId && carModelId != "" && carItemTypeId && carItemTypeId != ""){
    return function(dispatch) {
      return vehicleInventoryApi.getCarItems(carModelId, carItemTypeId).then(response => {
        dispatch(loadCarExtrasSuccess(response));
      });
    };
  }
}

