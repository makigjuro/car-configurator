import React from 'react';
import PropTypes from 'prop-types';
// Styles
import './Option.css';

const types = ["text", "color", "image", "checkbox"];
 
const Option = ({
  value = '',
  label = '',
  src = '',
  type = '',
  price = '',
  active = false,
  onSelectOption = () => null
}) => {
  if (!types.includes(type)) return null;

  let classNames = `option ${type}-option`;
  if (active) {
    classNames += ' active';
  }

  const renderContent = () => {
    switch(type) {
      case "text":
        return (
          <>
            <span>{label}</span>
            {price ? <span className="price">{price}</span> : null}
          </>
        );
      case "image":
        return <img src={src} alt={label} title={label} />;
      case "color":
        return <div className={label.replaceAll(" ", "").toLowerCase()} title={label} />;
      case "checkbox":
          return (
            <>
              <span>{label}</span>
              {price ? <span className="price">{price}</span> : null}
            </>
          );
      default:
        return null;
    }
  }

  return (
    <div
      role="button"
      className={classNames}
      onClick={() => onSelectOption(value)}
    >
      {renderContent()}
    </div>
  );
};

Option.propTypes = {
  value: PropTypes.string,
  label: PropTypes.string,
  type: PropTypes.oneOf(types),
  price: PropTypes.string,
  active: PropTypes.bool,
  onSelectOption: PropTypes.func
};

export default Option;
