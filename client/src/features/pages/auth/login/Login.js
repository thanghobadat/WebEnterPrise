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
  const onFinish = (values) => {
    dispatch(postLoginUserApi(values));
    message.success('This is a success message');
    {
      localStorage.getItem('user') ? navigate(`/admin`) : navigate(`/login`);
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
        labelCol={{ span: 4 }}
        wrapperCol={{ span: 20 }}
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
