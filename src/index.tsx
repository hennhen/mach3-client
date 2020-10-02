import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import {
  AdminContextProvider,
  AlertContextProvider,
  MachineContextProvider,
  JobContextProvider
} from './context';

ReactDOM.render(
  <React.StrictMode>
    <AdminContextProvider>
      <AlertContextProvider>
        <MachineContextProvider>
          <JobContextProvider>
            <App />
          </JobContextProvider>
        </MachineContextProvider>
      </AlertContextProvider>
    </AdminContextProvider>
  </React.StrictMode>,
  document.getElementById('root')
);
