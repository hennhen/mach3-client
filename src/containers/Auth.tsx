import React from 'react';
import { useAuth } from '../hooks';
import { Form, Field } from '../components';

const Auth = () => {
  const { login } = useAuth();

  const submit = ({ email, password }: { [key: string]: string }) => {
    login(email, password);
  };

  const fields: Field[] = [];

  fields.push({
    required: true,
    id: 'standard-required',
    label: 'Email',
    value: 'email'
  });
  fields.push({
    required: true,
    id: 'standard-password-input',
    label: 'Password',
    type: 'password',
    autoComplete: 'current-password',
    value: 'password'
  });

  return (
    <>
      <Form submit={submit} title='Admin Login' fields={fields} />
    </>
  );
};

export { Auth };
