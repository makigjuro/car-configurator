import React from 'react';
import PropTypes from 'prop-types';
import { formatPrice } from '../../utils/utils';
// Styles
import './Summary.css';

const Summary = ({
  config = null,
  models = null,
  totalPrice = 0
}) => {
  const selectedModel = models?.find(model => model?.key === config?.model);

  return (
    <div className="summary">
      <h1>Your {selectedModel?.carName}</h1>
      <p className="summary-edd">Estimated delivery: 5-9 weeks</p>
      <div className="summary-content">
        <p>Summary</p>
        <ul>
          <li>
            <span>{selectedModel?.carName} {config?.carEngine.itemName}</span>
            <span>{formatPrice(selectedModel?.carPrice)} + {formatPrice(config?.carEngine.itemPrice)}</span>
          </li>
          <li>
            <span>{config.carColor?.itemName}</span>
            <span>{formatPrice(config.carColor?.itemPrice)}</span>
          </li>
          <li>
            <span>{config.carRims?.itemName}</span>
            <span>{formatPrice(config.carRims?.itemPrice)}</span>
          </li>
          <li>
            <span>{config.carInterior?.itemName}</span>
            <span>{formatPrice(config.carInterior?.itemPrice)}</span>
          </li>
          {
            config.carExtras?.map(carExtra => (
              <li>
              <span>{carExtra?.itemName}</span>
              <span>{formatPrice(carExtra?.itemPrice)}</span>
              </li>
            ))
          }
        </ul>
        <p>
          <span>Total price</span>
          <span>{formatPrice(totalPrice)}</span>
        </p>
      </div>
    </div>
  );
};

Summary.propTypes = {
  config: PropTypes.object,
  models: PropTypes.array,
  totalPrice: PropTypes.number
};

export default Summary;
