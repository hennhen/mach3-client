import React, { useContext, useState } from 'react';
import { useHistory } from 'react-router-dom';
import {
  Container,
  Typography,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Button,
  Modal
} from '@material-ui/core';
import { AdminContext, MachineContext, AlertContext } from '../context';
import { post, patch } from '../hooks';
import { Form, Field } from '../components';

const Machines = () => {
  const [modal, setModal] = useState<React.ReactNode>(null);
  const { admin, setAdmin } = useContext(AdminContext);
  const { setMachine } = useContext(MachineContext);
  const { setAlert } = useContext(AlertContext);
  const history = useHistory();

  const submit = async ({
    name,
    location,
    ip_address
  }: {
    [key: string]: string;
  }) => {
    if (!admin) return;
    try {
      const data = await post('/admin/machine/', {
        name,
        location,
        ip_address
      });

      setAdmin({ ...admin, machines: [...admin.machines, data] });
      setModal(null);
    } catch (err) {
      setAlert({
        type: 'error',
        message: 'Your session has expired, please log in again.'
      });
    }
  };

  const edit = async (
    {
      name,
      location,
      ip_address
    }: {
      [key: string]: string;
    },
    identifier: string
  ) => {
    if (!admin) return;
    try {
      const data = await patch(`/admin/machine/${identifier}/`, {
        name,
        location,
        ip_address
      });

      const newMachines = admin.machines.map((machine) =>
        machine.identifier === identifier ? data : machine
      );

      setAdmin({ ...admin, machines: newMachines });
      setModal(null);
    } catch (err) {
      setAlert({
        type: 'error',
        message: 'Your session has expired, please log in again.'
      });
    }
  };

  const fields: Field[] = [
    {
      required: true,
      id: 'standard-required',
      label: 'Name',
      value: 'name'
    },
    {
      required: true,
      id: 'standard-required',
      label: 'Location',
      value: 'location'
    },
    {
      required: true,
      id: 'standard-required',
      label: 'IP Address',
      value: 'ip_address'
    }
  ];

  const contentNode =
    admin && admin.machines.length !== 0 ? (
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Location</TableCell>
            <TableCell>IP Address</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {admin.machines.map((machine, idx) => (
            <TableRow key={idx}>
              <TableCell>{machine.name}</TableCell>
              <TableCell>{machine.location}</TableCell>
              <TableCell>{machine.ip_address}</TableCell>
              <TableCell>
                <Button
                  variant='contained'
                  color='primary'
                  onClick={() => {
                    setMachine(machine);
                    history.push('/jobs');
                  }}
                >
                  Select
                </Button>
                <Button
                  variant='contained'
                  color='primary'
                  onClick={() => {
                    setModal(
                      <Form
                        fields={fields}
                        title='Edit the machine'
                        submit={(inputs) => edit(inputs, machine.identifier)}
                        defaultValues={machine}
                        modal
                      />
                    );
                  }}
                  style={{ marginLeft: 10 }}
                >
                  Edit
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    ) : (
      <Typography>No machines created yet.</Typography>
    );

  return (
    <Container>
      <Typography variant='h1'>Machines</Typography>
      {contentNode}
      <div style={{ marginTop: 12 }}>
        <Button
          variant='contained'
          color='primary'
          onClick={() => {
            setModal(
              <Form
                fields={fields}
                title='Create a Machine'
                submit={submit}
                modal
              />
            );
          }}
        >
          Create a new machine
        </Button>
      </div>
      {
        <Modal
          open={Boolean(modal)}
          onClose={() => {
            setModal(false);
          }}
        >
          <span>{modal}</span>
        </Modal>
      }
    </Container>
  );
};

export { Machines };
