import React, { useContext, FC } from 'react';
import { Redirect, Route, RouteComponentProps } from 'react-router-dom';
import { AdminContext } from '../context';
import { Header } from './Header';

type PrivateRouteProps = {
  component: FC<RouteComponentProps>;
  path?: string;
};

const PrivateRoute = ({ component: Component, ...rest }: PrivateRouteProps) => {
  const { admin } = useContext(AdminContext);

  return (
    <Route
      {...rest}
      render={(props) =>
        admin ? (
          <>
            <Header company={admin.email} />
            <Component {...props} />
          </>
        ) : (
          <Redirect to={{ pathname: '/' }} />
        )
      }
    />
  );
};

export { PrivateRoute };
