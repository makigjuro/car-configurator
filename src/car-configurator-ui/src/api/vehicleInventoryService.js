import * as apiClient from "./apiClient";
import * as webSocketClient from "./webSocketClient";
import { joinUrlWithRoute } from "../utils/utils";

const uuidv4 = require("uuid");

const vehicleInventoryApiUrl = joinUrlWithRoute(apiClient.VEHICLE_API_BASE_URL, "/api/");

export function getCarBrands() {
  const url = joinUrlWithRoute(vehicleInventoryApiUrl, "brands");

  return apiClient.get(url);
}

export function getCarModels(carBrandId) {
  const url = joinUrlWithRoute(vehicleInventoryApiUrl, "cars");

  return apiClient.get(url + "?brandId="+carBrandId);
}
  
export function getCarItems(carModelId, carItemTypeId) {
  const url = joinUrlWithRoute(vehicleInventoryApiUrl, "cars/items");

  return apiClient.get(url + "?carModelId="+carModelId + "&carItemTypeId=" + carItemTypeId);
}

export function getCarItemTypes() {
  const url = joinUrlWithRoute(vehicleInventoryApiUrl, "cars/items/types");

  return apiClient.get(url);
}

export function getCatalogPicture(carModelId) {
  return joinUrlWithRoute(vehicleInventoryApiUrl, "catalog/models/" + carModelId + "/pic");
}

export function getCatalogItemPicture(carItemId) {
  return joinUrlWithRoute(vehicleInventoryApiUrl, "catalog/items/" + carItemId + "/pic");
}
