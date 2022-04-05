/** @format */

import React from 'react';
import { useNavigate } from 'react-router-dom';
import './loginStyle.scss';
import { useDispatch } from 'react-redux';
import { Form, Input, Button, Row, message, Spin} from 'antd';
import { UserOutlined, LockOutlined } from '@ant-design/icons';
import { postLoginUserApi } from '../../../../Redux/slices/loginSlice';

const Login = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  let user;
  const onFinish = (values) => {
    dispatch(postLoginUserApi(values));
    user = JSON.parse(localStorage.getItem('user'));
    if (user && user.role === 'admin') {
      message.success('Login Success!');
      return navigate(`/admin`);
    } else if (user && user.role === 'staff') {
      message.success('Login Success!');
      return navigate(`/staff`);
    }
  };
  return (
    <Row className='Login'>
      <Form
        name='normal_login'
        className='login-form Login__form'
        initialValues={{
          remember: true,
        }}
        onFinish={onFinish}>
        <Form.Item
          name='username'
          rules={[
            {
              required: true,
              message: 'Please input your Username!',
            },
          ]}>
          <Input
            prefix={<UserOutlined className='site-form-item-icon' />}
            placeholder='Username'
          />
        </Form.Item>
        <Form.Item
          name='password'
          rules={[
            {
              required: true,
              message: 'Please input your Password!',
            },
          ]}>
          <Input
            prefix={<LockOutlined className='site-form-item-icon' />}
            type='password'
            placeholder='Password'
          />
        </Form.Item>
        <Form.Item>
          <Button
            type='primary'
            htmlType='submit'
            className='login-form-button Login__btn'>
            Log in
          </Button>
        </Form.Item>
      </Form>
    </Row>
  );
};
export default Login;
