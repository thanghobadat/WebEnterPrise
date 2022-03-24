/** @format */

import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './loginStyle.scss';
import { useDispatch } from 'react-redux';
import { Form, Input, Button, Row, message } from 'antd';
import { postLoginUserApi } from '../../../../Redux/slices/loginSlice';
const Login = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  let user;
  useEffect(() => {
    user = JSON.parse(localStorage.getItem('user'));
    user ? onFinish() : navigate(`/login`);
  }, []);
  const onFinish = (values) => {
    dispatch(postLoginUserApi(values));
    user = JSON.parse(localStorage.getItem('user'));
    if (user && user.role === 'admin') {
      message.success('Login Success!');
      return navigate(`/admin`);
    } else if (user && user.role === 'staff') {
      message.success('Login Success!');
      return navigate(`/user`);
    } else {
      message.error('Login Fail!');
    }
  };
  const onFinishFailed = (errorInfo) => {
    console.log('Failed:', errorInfo);
  };
  return (
    <Row className='Login'>
      <Form
        className='Login__form'
        name='basic'
        labelCol={{ span: 5 }}
        wrapperCol={{ span: 19 }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        autoComplete='off'>
        <Form.Item
          label='Username'
          name='userName'
          rules={[{ required: true, message: 'Please input your username!' }]}>
          <Input />
        </Form.Item>

        <Form.Item
          label='Password'
          name='password'
          rules={[{ required: true, message: 'Please input your password!' }]}>
          <Input.Password />
        </Form.Item>
        <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
          <Button type='primary' htmlType='submit'>
            Submit
          </Button>
        </Form.Item>
      </Form>
    </Row>
  );
};
export default Login;
