import { useContext } from 'react';
import { AdminContext, AlertContext, Job } from '../context';
import { useHistory } from 'react-router-dom';
import axios from 'axios';

export const get = async (path: string) => {
  const response = await axios.get(path);

  const { status, data } = response.data;
  if (status !== 'success') throw new Error('Something went wrong.');

  return data;
};

export const post = async (path: string, content: any) => {
  const response = await axios.post(path, content);

  const { status, data } = response.data;
  if (status !== 'success') throw new Error('Something went wrong.');

  return data;
};

export const patch = async (path: string, content: any) => {
  const response = await axios.patch(path, content);

  const { status, data } = response.data;
  if (status !== 'success') throw new Error('Something went wrong.');

  return data;
};

const useAuth = () => {
  const { admin, setAdmin } = useContext(AdminContext);
  const { setAlert } = useContext(AlertContext);
  const history = useHistory();

  const storeToken = (token: string) => {
    axios.defaults.headers.common['Authorization'] = `token ${token}`;
    localStorage.setItem('token', token);
  };

  const storeUser = async ({
    user: { email },
    token
  }: {
    user: { email: string };
    token: string;
  }) => {
    storeToken(token);
    const machines = await get('/admin/machine');
    const jobs = await get('/admin/job');
    setAdmin({ email, machines, jobs });
    if (history) history.push('/machines');
  };

  const setAuth = async (token?: string) => {
    if (token) {
      try {
        storeToken(token);
        const data = await get('/auth/user');
        await storeUser({ user: data, token });
        return true;
      } catch (err) {
        console.log(err);
        setAlert({
          type: 'info',
          message: 'Your session has expired, please log in again.'
        });
      }
    }
    delete axios.defaults.headers.common['Authorization'];
    localStorage.removeItem('token');
    setAdmin(undefined);
    return false;
  };

  const login = async (email: string, password: string) => {
    try {
      const data = await post('/auth/login/', {
        email: email,
        password: password
      });
      await storeUser(data);
    } catch (err) {
      setAlert({
        type: 'error',
        message: err.message
      });
    }
  };

  const editJob = async (job: Job) => {
    if (!admin) return;
    try {
      const content: { [key: string]: string | string[] } = {
        ...job,
        machine: job.machine.identifier,
        user: job.user.identifier
      } as { [key: string]: string | string[] };

      if (!content.tool) content.tool = 'tool';
      if (!content.name) content.name = 'name';

      const data = await patch(`/admin/job/${job.identifier}/`, content);

      const newJobs = admin.jobs.map((newJob) =>
        newJob.identifier === job.identifier ? data : newJob
      );

      setAdmin({ ...admin, jobs: newJobs });
    } catch (err) {
      setAlert({
        type: 'error',
        message: 'Something went wrong.'
      });
    }
  };

  return { setAuth, login, editJob };
};

export { useAuth };
