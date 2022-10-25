import React from 'react';
import PropTypes from 'prop-types';
// Styles
import './Preview.css';
// Components
import Slideshow from '../Slideshow';
import {getCatalogPicture} from "../../api/vehicleInventoryService";

class Preview extends React.Component {
  get index() {
    return this.props?.models.findIndex(model => 
      model.carModelId === this.props.config?.carModel?.carModelId
    );
  };

  get items() {
    return this.props.models.map(model => ({
      alt: model.carName,
      url : getCatalogPicture(model.carModelId),
      scale: ['x'].includes(model.carModelId)
    }));
  };

  get selectedModel() {
    return this.props.models.find(model =>
      model.carModelId === this.props.config?.carModel?.carModelId
    );
  };

  get selectedType() {
    return this.selectedModel?.types?.find(type =>
      type.value === this.props.config.carEngine
    );
  };

  get specs() {
    return this.selectedType?.specs;
  };

  handleOnClickPrev = () => {
    const newIndex = this.index > 0
      ? this.index - 1
      : this.props.models.length - 1;
    this.props.onChangeModel(this.props.models?.[newIndex]?.key);
  };

  handleOnClickNext = () => {
    const newIndex = this.index < this.props.models.length - 1
      ? this.index + 1
      : 0;
    this.props.onChangeModel(this.props.models?.[newIndex]?.key);
  };

  render() {
    return (
      <div className="preview">
        <Slideshow
          items={this.items}
          index={this.index}
          showPrev={this.props.showAllModels}
          showNext={this.props.showAllModels}
          onClickPrev={this.handleOnClickPrev}
          onClickNext={this.handleOnClickNext}
        />
      </div>
    );
  };
};

Preview.propTypes = {
  config: PropTypes.object,
  models: PropTypes.array,
  showAllModels: PropTypes.bool,
  showSpecs: PropTypes.bool,
  onChangeModel: PropTypes.func
};

export default Preview;
