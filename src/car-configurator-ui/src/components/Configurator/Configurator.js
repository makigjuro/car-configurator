
import React, { useEffect, useState } from "react";
import './Configurator.css';
import Menu from '../Menu';
import Footer from '../Footer';
import Settings from '../Settings';
import Summary from '../Summary';
import Preview from '../Preview';
import InteriorPreview from '../InteriorPreview';
import { useSearchParams } from "react-router-dom";
import * as carActions from "../../redux/actions/vehicleInventoryActions";
import * as configActions from "../../redux/actions/carConfigurationActions";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { toast } from "react-toastify";
import {getCatalogItemPicture} from "../../api/vehicleInventoryService";

const Configurator = ({
  history,
  loadCarModels,
  carModels,
  config,
  setCarBrandId,
  setCarConfigId,
  setCurrentStep,
  changeModel,
  loadCarItemTypes,
  carItemTypes,
  loadCarEnginePowers,
  carEngines,
  loadCarColors,
  carColors,
  loadCarRims,
  carRims,
  loadCarInteriors,
  carInteriors,
  loadCarExtras,
  carExtras,
  changeConfigExtras,
  changeConfigEngine,
  changeConfigRims,
  changeConfigColor,
  changeConfigInterior  
}) => {

  const queryParams = new URLSearchParams(window.location.search)
  const carbrandId = queryParams.get("carbrandId")
  const carConfigurationId = queryParams.get("carConfigurationId")
  
  useEffect(() => {

    loadCarItemTypes();

    loadCarModels(carbrandId);
    setCarBrandId(carbrandId);
    setCarConfigId(carConfigurationId);

    if(carModels.length > 0){
      changeModel(carModels[0]);
    }
  }, []);

  let selectedModel = () => {
    return carModels.find(model =>
      model?.carModelId === config?.carModelId
    );
  }

  let findCarItemType = (typeName) => {
    var itemType = carItemTypes.find(model =>
      model?.typeName === typeName
    );

    return itemType.carItemTypeId;
  }

  let steps = [
      {
        name: "car",
        settings: [
          {
            label: "Select car",
            type: "text",
            prop: "carModel",
            options: carModels.map(model => ({
              value: model.carModelId,
              label: model.carName
            }))
          },
          {
            label: "Select Engine Power",
            type: "text",
            prop: "carEngine",
            options: carEngines.map(model => ({
              value: model.carItemId,
              label: model.itemName
            })),
            disclaimer_1: "All cars have Dual Motor All-Wheel Drive, adaptive air suspension, premium interior and sound.",
            disclaimer_2: "Tesla All-Wheel Drive has two independent motors that digitally control torque to the front and rear wheels—for far better handling and traction control. Your car can drive on either motor, so you don't need to worry about getting stuck on the road."
          }
        ]
      },
      {
        name: "exterior",
        settings: [
          {
            label: "Select color",
            type: "color",
            prop: "carColor",
            options: carColors.map(model => ({
              value: model.carItemId,
              label: model.itemName,
              src : getCatalogItemPicture(model.carItemId),
              itemPrice : model.itemPrice
            })),
          },
          {
            label: "Select wheels",
            type: "image",
            prop: "carRims",
            options: carRims.map(model => ({
              value: model.carItemId,
              label: model.itemName,
              src : getCatalogItemPicture(model.carItemId),
              itemPrice : model.itemPrice

            })),          
          }
        ]
      },
      {
        name: "interior",
        settings: [,
          {
            label: "Select premium interior",
            type: "text",
            prop: "carInterior",
            options: carInteriors.map(model => ({
              value: model.carItemId,
              label: model.itemName,
              src : getCatalogItemPicture(model.carItemId),
              itemPrice : model.itemPrice
            })),          
          },
          {
            label: "Select interior extras",
            type: "checkbox",
            prop: "carExtras",
            options: carExtras.map(model => ({
              value: model.carItemId,
              label: model.itemName,
              itemPrice : model.itemPrice
            })),          
          }
        ]
      },
      {
        name: "summary"
      }
  ];

  const totalPrice = () => {
    const basePrice = config?.carModel?.carPrice ?? 0;

    const motorPrice = config?.carEngine?.itemPrice ?? 0;
    const colorPrice = config?.carColor?.itemPrice ?? 0;
    const wheelsPrice = config?.carRims?.itemPrice ?? 0;
    const interiorPrice = config?.carInterior?.itemPrice ?? 0;

    var totalPrice = basePrice + motorPrice + colorPrice + wheelsPrice + interiorPrice;

    config?.carExtras?.forEach(element => {
      totalPrice += element?.itemPrice ?? 0
    })

    return totalPrice;
  };

  const goToStep = (step) => {
    setCurrentStep(step);
  };

  const goToPrevStep = () => {
    const newStep = config.currentStep > 0
    ? config.currentStep-1
    : config.currentStep;

    setCurrentStep(newStep);
  };

  const goToNextStep = () => {

    const newStep = config.currentStep < steps.length - 1
    ? config.currentStep+1
    : config.currentStep;

    setCurrentStep(newStep);

  };

  const orderCar = () => {

  };

  const handleChangeModel = (carModelId) => {
    let carModel = carModels.find(model =>
      model?.carModelId === carModelId
    );

    changeModel(carModel);
    

    loadCarEnginePowers(carModelId, findCarItemType("CarEnginePowerType"));
    loadCarColors(carModelId, findCarItemType("CarColorType"));
    loadCarRims(carModelId, findCarItemType("CarRimsType"));
    loadCarInteriors(carModelId, findCarItemType("CarInteriorType"));
    loadCarExtras(carModelId, findCarItemType("CarExtraType"));
  };

  const handleOnSelectOption = (prop, value) => {
    if (prop === "carModel") {
      handleChangeModel(value);
    }
    else if(prop === "carEngine"){
      var item = carEngines.find(model =>
        model?.carItemId === value
      );
  
      changeConfigEngine(item);
    }
    else if (prop === "carColor"){
      var item = carColors.find(model =>
        model?.carItemId === value
      );

      changeConfigColor(item);
    }
    else if (prop === "carRims"){
      var item = carRims.find(model =>
        model?.carItemId === value
      );

      changeConfigRims(item);
    }
    else if (prop === "carInterior") {
      var item = carInteriors.find(model =>
        model?.carItemId === value
      );

      changeConfigInterior(item);
    }
    else if (prop === "carExtras") {
      var item = carExtras.find(model =>
        model?.carItemId === value
      );

      changeConfigExtras(item);
    }
  };

  const isFirstStep = config.currentStep === 0;
  const isLastStep = config.currentStep === steps.length - 1;

    return (
      <div className="app">
        <Menu
          items={steps.map(step => step.name)}
          selectedItem={config.currentStep}
          onSelectItem={goToStep}
        />
        <main className="app-content">
          {
            steps[config.currentStep]?.name === "interior" ? (
              <InteriorPreview
                config={config.carInterior}
                carInteriors={carInteriors}
              />
            ) : (
              <Preview
                config={config}
                models={carModels}
                showAllModels={isFirstStep}
                showSpecs={!isLastStep}
                onChangeModel={handleChangeModel}
              />
            )
          }
          {
          isLastStep ? (
            <Summary
              config={config}
              models={carModels}
              totalPrice={totalPrice()}
            />
          ) : (
            <Settings
              config={config}
              settings={steps[config.currentStep].settings}
              onSelectOption={handleOnSelectOption}
            />
          )
        }
        </main>
        <Footer
          totalPrice={totalPrice()}
          disablePrev={isFirstStep}
          disableNext={isLastStep}
          onClickPrev={goToPrevStep}
          onClickNext={goToNextStep}
          onClickOrder={orderCar}
        />
      </div>
    );
};


Configurator.propTypes = {
  loadCarModels : PropTypes.func.isRequired,
  setCarBrandId : PropTypes.func.isRequired,
  setCarConfigId : PropTypes.func.isRequired,
  setCurrentStep : PropTypes.func.isRequired,
  changeModel : PropTypes.func.isRequired,
  carModels: PropTypes.array.isRequired,
  carEngines : PropTypes.array.isRequired,
  carColors : PropTypes.array.isRequired,
  carExtras : PropTypes.array.isRequired,
  carInteriors : PropTypes.array.isRequired,
  carRims : PropTypes.array.isRequired,

  loadCarEnginePowers : PropTypes.func.isRequired,
  loadCarColors : PropTypes.func.isRequired,
  loadCarExtras : PropTypes.func.isRequired,
  loadCarInteriors : PropTypes.func.isRequired,
  loadCarRims : PropTypes.func.isRequired,

  loadCarItemTypes : PropTypes.func.isRequired,
  carItemTypes : PropTypes.array.isRequired,
  config: PropTypes.object.isRequired,

  changeConfigExtras : PropTypes.func.isRequired,
  changeConfigEngine : PropTypes.func.isRequired,
  changeConfigRims : PropTypes.func.isRequired,
  changeConfigColor : PropTypes.func.isRequired,
  changeConfigInterior : PropTypes.func.isRequired
};


function mapStateToProps(state) {
  return {
    carModels : state.carModels,
    carEngines : state.carEngines,
    carColors : state.carColors,
    carExtras : state.carExtras,
    carInteriors : state.carInteriors,
    carRims : state.carRims,
    carItemTypes : state.carItemTypes,
    config : state.config
  };
}

const mapDispatchToProps = {
  loadCarItemTypes: carActions.loadCarItemTypes,

  loadCarModels: carActions.loadCarModels,
  loadCarEnginePowers : carActions.loadCarEnginePowers,
  loadCarColors: carActions.loadCarColors,
  loadCarRims: carActions.loadCarRims,
  loadCarInteriors : carActions.loadCarInteriors,
  loadCarExtras: carActions.loadCarExtras,

  setCarBrandId: configActions.setCarBrandId,
  setCarConfigId : configActions.setCarConfigId,
  setCurrentStep : configActions.setCurrentStep,
  
  changeModel : configActions.changeModel,
  changeConfigExtras : configActions.changeConfigExtras,
  changeConfigEngine : configActions.changeConfigEngine,
  changeConfigRims : configActions.changeConfigRims,
  changeConfigColor : configActions.changeConfigColor,
  changeConfigInterior : configActions.changeConfigInterior
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Configurator);



