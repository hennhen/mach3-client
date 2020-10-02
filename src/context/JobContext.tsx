import React, { useState } from 'react';
import { Machine } from './MachineContext';

export type User = {
  identifier: string;
  company_name: string;
};

export type Job = {
  identifier: string;
  name: string;
  gcode_array: string[];
  status: 'Pending' | 'Started' | 'Complete';
  material: string;
  tool: string;
  machine: Machine;
  user: User;
};

type JobContextProps = {
  job?: Job;
  setJob: (job: Job | undefined) => void;
};

export const JobContext = React.createContext<JobContextProps>({
  job: undefined,
  setJob: (job) => {}
});

const JobContextProvider = ({
  children
}: {
  children: React.ReactNode | React.ReactNode[];
}) => {
  const [job, setJob] = useState<Job | undefined>(undefined);

  return (
    <JobContext.Provider value={{ job: job, setJob: setJob }}>
      {children}
    </JobContext.Provider>
  );
};

export { JobContextProvider };
