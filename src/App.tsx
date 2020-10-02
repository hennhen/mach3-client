import React, { useContext, useEffect, useState } from 'react';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';
import axios from 'axios';
import { Auth, Dashboard, Machines, Jobs } from './containers';
import { AdminContext, AlertContext } from './context';
import { PrivateRoute } from './components';
import { useAuth } from './hooks';
import { Snackbar } from '@material-ui/core';
import { Alert } from '@material-ui/lab';

axios.defaults.baseURL = 'https://cloudmill-core.herokuapp.com/api';

const App = () => {
  const { admin } = useContext(AdminContext);
  const { alert, setAlert } = useContext(AlertContext);
  const { setAuth } = useAuth();
  const [redirect, setRedirect] = useState<React.ReactNode>(null);

  useEffect(() => {
    const auth = async () => {
      const response = await setAuth(localStorage.token);
      if (response) setRedirect(<Redirect to='/jobs' />);
    };

    auth();
  }, []);

  useEffect(() => {
    if (!admin) setRedirect(null);
  }, [admin]);

  const routes = (
    <>
      {alert && (
        <Snackbar
          open={true}
          autoHideDuration={5000}
          anchorOrigin={{
            vertical: 'top',
            horizontal: 'center'
          }}
          onClose={() => {
            setAlert(undefined);
          }}
        >
          <Alert
            severity={alert.type}
            variant='filled'
            onClose={() => {
              setAlert(undefined);
            }}
          >
            {alert.message}
          </Alert>
        </Snackbar>
      )}
      <Switch>
        <PrivateRoute path='/dashboard' component={Dashboard} />
        <PrivateRoute path='/jobs' component={Jobs} />
        <PrivateRoute path='/machines' component={Machines} />
        <Route path='/'>{redirect || <Auth />}</Route>
      </Switch>
    </>
  );

  return <BrowserRouter>{routes}</BrowserRouter>;
};

export default App;
