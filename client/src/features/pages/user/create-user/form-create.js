/** @format */

import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Form, Input, Button, Select, Row, Col, message } from 'antd';
import validatorForm from '../validation';
import './formUser.scss';
import { postRegisterUserApi } from '../../../../Redux/slices/userSlice';
import { Link, useNavigate } from 'react-router-dom';
const FormCreate = () => {
  const [form] = Form.useForm();
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const rgPass = /^(?=.*[0-9])(?=.*[!@#$%^&*])[A-Z][a-zA-Z0-9!@#$%^&*]{7,15}$/;
  const rgPhone = /^[0][0-9]{2}[0-9]{3}[0-9]{4}$/;
  const { Option } = Select;
  const layout = {
    labelCol: { span: 5 },
    wrapperCol: { span: 19 },
  };
  const onFinish = (values) => {
    dispatch(postRegisterUserApi(values))
    message.success('This is a success message');
    navigate(`/admin/account-user`);
  };

  const onFinishFailed = (errorInfo) => {
    console.log('Failed:', errorInfo);
  };

  return (
    <div className='formCreate'>
      <h2>Form Create User</h2>
      <Form
        name='basic'
        form={form}
        {...layout}
        initialValues={{
          remember: true,
        }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        autoComplete='off'
        validateMessages={validatorForm}>
        <Form.Item
          label='Username'
          name='userName'
          rules={[
            {
              required: true,
            },
          ]}>
          <Input placeholder='username' />
        </Form.Item>
        <Form.Item
          label='Password'
          name='password'
          rules={[
            { required: true },
            { type: 'regexp' },
            {
              pattern: new RegExp(rgPass),
              mess: 'include first uppercase letter, lowercase letter, number, special character',
            },
          ]}>
          <Input.Password placeholder='password' />
        </Form.Item>
        <Form.Item
          name='email'
          label='Email'
          rules={[{ required: true }, { type: 'email' }]}>
          <Input placeholder='email' />
        </Form.Item>
        <Form.Item
          name='phoneNumber'
          label='Phone Number'
          rules={[
            { required: true },
            { type: 'regexp' },
            {
              pattern: new RegExp(rgPhone),
              mess: 'must have number, length 10 character! Ex: 0999999999',
            },
          ]}>
          <Input placeholder='phone number' />
        </Form.Item>
        <Form.Item label='Department' name='department' rules={[ { required: true },]}>
          <Select defaultValue=''>
            <Option value=''>Choose Department</Option>
            <Option value='1'>Support</Option>
            <Option value='2'>Academic</Option>
          </Select>
        </Form.Item>
        <Form.Item label='Role' name='role' rules={[ { required: true },]}>
          <Select defaultValue=''>
            <Option value=''>Choose Role</Option>
            <Option value='staff'>Staff</Option>
            <Option value='user'>User</Option>
          </Select>
        </Form.Item>
        <Form.Item className='groupBtn'>
          <Row className='groupBtn__center'>
            <Col span={5} offset={7}>
              <Button type='primary' htmlType='submit'>
                Submit
              </Button>
            </Col>
            <Col span={12}>
              <Button type='danger' htmlType='submit'>
                <Link to='/admin/account-user'>Cancel</Link>
              </Button>
            </Col>
          </Row>
        </Form.Item>
      </Form>
    </div>
  );
};

export default FormCreate;
