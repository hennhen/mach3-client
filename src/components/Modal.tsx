import React, { FC } from 'react';
import { Card, CardContent } from '@material-ui/core';

type ModalProps = {
  style?: object;
};

export const Modal: FC<ModalProps> = ({ children, style }) => {
  return (
    <div
      style={{
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        ...style
      }}
    >
      <Card>
        <CardContent>{children}</CardContent>
      </Card>
    </div>
  );
};
