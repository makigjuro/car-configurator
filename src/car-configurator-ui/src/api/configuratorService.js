import * as apiClient from "./apiClient";
import * as webSocketClient from "./webSocketClient";
import { joinUrlWithRoute } from "../utils/utils";

const uuidv4 = require("uuid");

const apiUrl = joinUrlWithRoute(apiClient.CONFIGURATOR_API_BASE_URL, "/api/cars/configurations");

export function getAllConfigs() {
  return apiClient.get(apiUrl);
}