import React, { useContext, useState } from 'react';
import { useHistory, Redirect } from 'react-router-dom';
import {
  Container,
  Typography,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Button,
  Modal as MUIModal
} from '@material-ui/core';
import {
  AdminContext,
  MachineContext,
  JobContext,
  Job,
  AlertContext
} from '../context';
import { useAuth } from '../hooks';
import {
  RedButton,
  GreenButton,
  Modal,
  Form,
  Field,
  BackArrow
} from '../components';

const Jobs = () => {
  const [modal, setModal] = useState<React.ReactNode>(null);
  const { machine, setMachine } = useContext(MachineContext);
  const { admin } = useContext(AdminContext);
  const { setJob } = useContext(JobContext);
  const history = useHistory();
  const { editJob } = useAuth();

  if (!machine) return <Redirect to='/machines' />;
  if (!admin) return <Redirect to='/' />;

  const edit = async (job: Job) => {
    editJob(job);
    setModal(undefined);
  };

  const jobsTable = (jobs: Job[], actions?: (job: Job) => React.ReactNode) => {
    return (
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Company</TableCell>
            <TableCell>Material</TableCell>
            <TableCell>Tool</TableCell>
            <TableCell>GCode</TableCell>
            <TableCell>Status</TableCell>
            {actions ? <TableCell>Actions</TableCell> : null}
          </TableRow>
        </TableHead>
        <TableBody>
          {jobs.map((job, idx) => (
            <TableRow key={idx}>
              <TableCell>{job.name}</TableCell>
              <TableCell>{job.user.company_name}</TableCell>
              <TableCell>{job.material}</TableCell>
              <TableCell>{job.tool}</TableCell>
              <TableCell>
                {job.gcode_array ? (
                  <Button
                    onClick={() => {
                      setModal(
                        <Modal style={{ maxHeight: 300, overflowY: 'auto' }}>
                          {job.gcode_array.map((gcode) => (
                            <Typography>{gcode}</Typography>
                          ))}
                        </Modal>
                      );
                    }}
                  >
                    Preview
                  </Button>
                ) : (
                  'None'
                )}
              </TableCell>
              <TableCell>{job.status}</TableCell>
              {actions ? <TableCell>{actions(job)}</TableCell> : null}
            </TableRow>
          ))}
        </TableBody>
      </Table>
    );
  };

  const jobs = admin.jobs.filter(
    (job) => job.machine && job.machine.identifier === machine.identifier
  );

  const fields: Field[] = [
    {
      required: true,
      label: 'Name',
      value: 'name'
    },
    {
      required: true,
      label: 'Material',
      value: 'material'
    },
    {
      required: true,
      label: 'Tool',
      value: 'tool'
    },
    {
      label: 'GCode',
      value: 'gcode_array'
    }
  ];

  const contentNode =
    jobs.length !== 0 ? (
      jobsTable(jobs, (job) => {
        let ButtonType: any;
        switch (job.status) {
          case 'Pending':
            ButtonType = GreenButton;
            break;
          case 'Started':
            ButtonType = RedButton;
            break;
          default:
            ButtonType = Button;
        }
        return (
          <>
            <ButtonType
              variant='contained'
              color='primary'
              onClick={() => {
                setJob(job);
                edit({ ...job, status: 'Started' });
                history.push('/dashboard');
              }}
              disabled={job.status === 'Complete' || !job.gcode_array}
            >
              {job.status === 'Pending' ? 'Start' : job.status}
            </ButtonType>
            <Button
              variant='contained'
              color='primary'
              onClick={() => {
                setModal(
                  <Form
                    fields={fields}
                    title='Edit the job'
                    submit={(inputs) => {
                      const newJob = {
                        ...job,
                        name: inputs.name,
                        material: inputs.material,
                        tool: inputs.tool,
                        gcode_array: inputs.gcode_array.split(',')
                      };
                      return edit(newJob);
                    }}
                    defaultValues={{
                      ...job,
                      gcode_array:
                        (job.gcode_array && job.gcode_array.join(',')) || '',
                      machine: '',
                      user: ''
                    }}
                    modal
                  />
                );
              }}
              style={{ marginLeft: 10 }}
            >
              Edit
            </Button>
          </>
        );
      })
    ) : (
      <Typography>No jobs added to this machine yet.</Typography>
    );

  return (
    <Container>
      <Typography variant='h1'>Machine: {machine.name}</Typography>
      <Typography variant='h2'>Jobs</Typography>
      <BackArrow
        onClick={() => {
          setMachine(undefined);
          history.push('/machines');
        }}
      />
      {contentNode}
      <div style={{ marginTop: 12 }}>
        <Button
          variant='contained'
          color='primary'
          onClick={() => {
            setModal(
              <Modal>
                {jobsTable(
                  admin.jobs.filter(
                    (job) =>
                      !job.machine ||
                      job.machine.identifier !== machine.identifier
                  ),
                  (job) => (
                    <Button
                      variant='contained'
                      color='primary'
                      onClick={() => {
                        edit({ ...job, machine: machine });
                      }}
                    >
                      Add Job
                    </Button>
                  )
                )}
              </Modal>
            );
          }}
        >
          Add jobs to machine
        </Button>
      </div>
      {
        <MUIModal
          open={Boolean(modal)}
          onClose={() => {
            setModal(false);
          }}
        >
          <span>{modal}</span>
        </MUIModal>
      }
    </Container>
  );
};

export { Jobs };
