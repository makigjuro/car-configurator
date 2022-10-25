import React from 'react';
import PropTypes from 'prop-types';
import { formatPrice } from '../../utils/utils';
// Styles
import './Footer.css';
// Icons
import { MdNavigateBefore, MdNavigateNext } from 'react-icons/md';

 
const Footer = ({
  totalPrice = 0,
  disablePrev = true,
  disableNext = true,
  onClickPrev = () => null,
  onClickNext = () => null,
  onClickOrder = () => null
}) => (
  <div className="footer">
    <div>
      <button
        onClick={onClickPrev}
        disabled={disablePrev}
      >
        <MdNavigateBefore />
        <span>Prev</span>
      </button>
    </div>
    <div>
      <span>{formatPrice(totalPrice, '-')}</span>
    </div>
    <div>
      {
        disableNext ?  
        <button onClick={onClickOrder}>
          <span>Order</span>
          <MdNavigateNext />
        </button> :
        <button onClick={onClickNext}>
          <span>Next</span>
          <MdNavigateNext />
        </button> 
      }
    </div>
  </div>
);

Footer.propTypes = {
  totalPrice: PropTypes.number,
  disablePrev: PropTypes.bool,
  disableNext: PropTypes.bool,
  onClickPrev: PropTypes.func,
  onClickNext: PropTypes.func
};

export default Footer;
