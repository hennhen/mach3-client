import React, { useContext } from 'react';
import { useHistory, Redirect } from 'react-router-dom';
import {
  Container,
  Typography,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Button
} from '@material-ui/core';
import ArrowBackIcon from '@material-ui/icons/ArrowBack';
import { AdminContext, MachineContext, JobContext } from '../context';

const Jobs = () => {
  const { machine, setMachine } = useContext(MachineContext);
  const { admin } = useContext(AdminContext);
  const { setJob } = useContext(JobContext);
  const history = useHistory();

  if (!machine) return <Redirect to='/machines' />;
  if (!admin) return <Redirect to='/' />;

  const jobs = admin.jobs.filter(
    (job) => job.machine && job.machine.identifier === machine.identifier
  );

  const contentNode =
    jobs.length !== 0 ? (
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Material</TableCell>
            <TableCell>Status</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {jobs.map((job, idx) => (
            <TableRow key={idx}>
              <TableCell>{job.name}</TableCell>
              <TableCell>{job.material}</TableCell>
              <TableCell>
                <Button
                  variant='contained'
                  color='primary'
                  onClick={() => {
                    setJob(job);
                    history.push('/dashboard');
                  }}
                  disabled={job.status === 'Complete'}
                >
                  {job.status === 'Pending' ? 'Start' : job.status}
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    ) : (
      <Typography>No jobs created yet.</Typography>
    );

  return (
    <Container>
      <Typography variant='h1'>Machine: {machine.name}</Typography>
      <Typography variant='h2'>Jobs</Typography>
      <div style={{ padding: '10px 0' }}>
        <ArrowBackIcon
          fontSize='large'
          color='primary'
          style={{ cursor: 'pointer' }}
          onClick={() => {
            setMachine(undefined);
            history.push('/machines');
          }}
        />
      </div>
      {contentNode}
    </Container>
  );
};

export { Jobs };
