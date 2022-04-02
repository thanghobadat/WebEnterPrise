/** @format */

import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './loginStyle.scss';
import { useDispatch } from 'react-redux';
import { Form, Input, Button, Row, message, Modal, Spin, Checkbox } from 'antd';
import { UserOutlined, LockOutlined, AuditOutlined } from '@ant-design/icons';
import { postLoginUserApi } from '../../../../Redux/slices/loginSlice';
import FormItem from 'antd/lib/form/FormItem';
const term =
  'Welcome to The Register. The Register is a news organisation owned and operated by Situation Publishing that allows users who have created an account with us (“Members”) to post comments on contributions/articles and to receive newsletters through email subscriptions.';
const Login = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const [visible, setVisible] = React.useState(false);
  const [confirmLoading, setConfirmLoading] = React.useState(false);
  const [modalText, setModalText] = React.useState(term);
  const [acceptTerm, setAcceptTerm] = React.useState(false);
  let user;
  const onFinish = (values) => {
    console.log(values);
    dispatch(postLoginUserApi(values));
    user = JSON.parse(localStorage.getItem('user'));
    if (user && user.role === 'admin' && acceptTerm === true) {
      message.success('Login Success!');
      return navigate(`/admin`);
    } else if (user && user.role === 'staff' && acceptTerm === true) {
      message.success('Login Success!');
      return navigate(`/staff`);
    } else if (user && acceptTerm === false) {
      message.error('Read and Accept Terms & Conditions Agreement!');
    } else {
      message.error('Login Fail!');
    }
  };
  const showModal = () => {
    setVisible(true);
  };

  const handleOk = () => {
    setModalText(<Spin />);
    setConfirmLoading(true);
    setAcceptTerm(true);
    setTimeout(() => {
      setVisible(false);
      setConfirmLoading(false);
    }, 1500);
  };

  const handleCancel = () => {
    setVisible(false);
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
        <FormItem className='term'>
          <AuditOutlined />
          <u onClick={showModal}>Terms & Conditions Agreement</u>
          <Modal
            title='Terms & Conditions Agreement'
            visible={visible}
            onOk={handleOk}
            confirmLoading={confirmLoading}
            onCancel={handleCancel}>
            <p>{modalText}</p>
          </Modal>
        </FormItem>
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
