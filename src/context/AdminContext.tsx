import React, { useState } from 'react';
import { Machine } from './MachineContext';
import { Job } from './JobContext';

type Admin = {
  email: string;
  machines: Machine[];
  jobs: Job[];
};

type AdminContextProps = {
  admin?: Admin;
  setAdmin: (admin: Admin | undefined) => void;
};

export const AdminContext = React.createContext<AdminContextProps>({
  admin: undefined,
  setAdmin: (admin) => {}
});

const AdminContextProvider = ({
  children
}: {
  children: React.ReactNode | React.ReactNode[];
}) => {
  const [admin, setAdmin] = useState<Admin | undefined>(undefined);

  return (
    <AdminContext.Provider value={{ admin: admin, setAdmin: setAdmin }}>
      {children}
    </AdminContext.Provider>
  );
};

export { AdminContextProvider };
