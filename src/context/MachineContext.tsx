import React, { useState } from 'react';

export type Machine = {
  identifier: string;
  name: string;
  location: string;
  ip_address: string;
};

type MachineContextProps = {
  machine?: Machine;
  setMachine: (machine: Machine | undefined) => void;
};

export const MachineContext = React.createContext<MachineContextProps>({
  machine: undefined,
  setMachine: (machine) => {}
});

const MachineContextProvider = ({
  children
}: {
  children: React.ReactNode | React.ReactNode[];
}) => {
  const [machine, setMachine] = useState<Machine | undefined>(undefined);

  return (
    <MachineContext.Provider
      value={{ machine: machine, setMachine: setMachine }}
    >
      {children}
    </MachineContext.Provider>
  );
};

export { MachineContextProvider };
