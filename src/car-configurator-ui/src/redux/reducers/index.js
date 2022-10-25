import { combineReducers } from "redux";
import { carBrandsReducer as carBrands } from "../reducers/vehicleInventory/carBrandsReducer";
import { carModelsReducer as carModels } from "../reducers/vehicleInventory/carModelsReducer";
import { carColorsReducer as carColors } from "../reducers/vehicleInventory/carColorsReducer";
import { carEnginesReducer as carEngines } from "../reducers/vehicleInventory/carEnginesReducer";
import { carExtrasReducer as carExtras } from "../reducers/vehicleInventory/carExtrasReducer";
import { carInteriorsReducer as carInteriors } from "../reducers/vehicleInventory/carInteriorsReducer";
import { carRimsReducer as carRims } from "../reducers/vehicleInventory/carRimsReducer";

import { carItemTypesReducer as carItemTypes } from "../reducers/vehicleInventory/carItemTypesReducer";

import { configReducer as config } from "../reducers/configurator/configReducer";

const rootReducer = combineReducers({
    carBrands,
    carModels,
    carItemTypes,
    config,
    carColors,
    carEngines,
    carExtras,
    carInteriors,
    carRims
});

export default rootReducer;
