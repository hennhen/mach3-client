import React from 'react';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';

type BackArrowProps = {
  onClick: () => void;
};

export const BackArrow = ({ onClick }: BackArrowProps) => (
  <div style={{ padding: '10px 0' }}>
    <ArrowBackIcon
      fontSize='large'
      color='primary'
      style={{ cursor: 'pointer' }}
      onClick={onClick}
    />
  </div>
);
