import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import * as carActions from "../../redux/actions/vehicleInventoryActions";
import Settings from '../Settings';
import './HomePage.css';
import {createSearchParams, useNavigate} from 'react-router-dom';
import { MdNavigateBefore, MdNavigateNext } from 'react-icons/md';
import { v4 as uuidv4 } from 'uuid';

const HomePage = ({
  loadCarBrands,
  carBrands,
  loadCarItemTypes
}) => {
  useEffect(() => {
    loadCarBrands();
    loadCarItemTypes();
  }, []);
  const navigate = useNavigate();

  let firstCarBrandId  = null;

  if(carBrands && carBrands.length > 0){
    firstCarBrandId = carBrands[0].carBrandId;
  }

  let config = { carBrandId : firstCarBrandId, carConfigurationId :uuidv4() };

  let settingsVal = (carBrands) => {
    return [
      {
        label: "Select Car Manufacturer",
        type: "text",
        prop: "carBrandId",
        options: carBrands.map(model => ({
          value: model.carBrandId,
          label: model.brandName
        }))
      }
      // ,{
      //   label: "Select type",
      //   type: "text",
      //   prop: "car_type",
      //   options: this.selectedModel?.types ?? [],
      //   disclaimer_1: "All cars have Dual Motor All-Wheel Drive, adaptive air suspension, premium interior and sound.",
      //   disclaimer_2: "Tesla All-Wheel Drive has two independent motors that digitally control torque to the front and rear wheels—for far better handling and traction control. Your car can drive on either motor, so you don't need to worry about getting stuck on the road."
      // }
    ]
  }

  let handleChangeBrand = (model) => {
    config.carBrandId = model;
  };
  
  let handleOnSelectOption = (prop, value) => {
    if (prop === "carBrand") {
      this.handleChangeModel(value);
    }
    else {
      this.setState(prevState => ({
        config: {
          ...prevState.config,
          [prop]: value
        }
      }));
    }
  };

  let onClickNext = () =>{
    const params = { carbrandId: config.carBrandId, carConfigurationId : config.carConfigurationId };

    navigate({
      pathname: '/configurator',
      search: `?${createSearchParams(params)}`,
    });
  };

  return (
      <div className="app">
        <div className="menu-container">
          <a width="50px" height="50px" href="/" className="logo">
            <img className='image-home' src={`${process.env.PUBLIC_URL}/tesla_logo_icon.png`} alt="Tesla" />
          </a>
        </div>
        <main className="app-content">

        {
          carBrands.length > 0 ? (
            <Settings
              config={config}
              settings={settingsVal(carBrands)}
              onSelectOption={handleOnSelectOption}
            />
          ) : (<></>)
        }


        </main>
        <div className="footer">
        <div>
        </div>
        <div>
        </div>
        <div>
          <button onClick={onClickNext}>
            <span>Start New Configuration</span>
            <MdNavigateNext />
          </button>
        </div>
  </div>

      </div>
  );
};


HomePage.propTypes = {
  loadCarBrands: PropTypes.func.isRequired,
  carBrands: PropTypes.array.isRequired,
  loadCarItemTypes :PropTypes.func.isRequired};

function mapStateToProps(state) {
  return {
    carBrands: state.carBrands
  };
}

const mapDispatchToProps = {
  loadCarBrands: carActions.loadCarBrands,
  loadCarItemTypes: carActions.loadCarItemTypes
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HomePage);
