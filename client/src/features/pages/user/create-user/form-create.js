/** @format */

import React from 'react';
import { useDispatch } from 'react-redux';
import { Form, Input, Button, Select, Row, Col, message } from 'antd';
import validatorForm from '../validation';
import './formUser.scss';
import { postRegisterUserApi } from '../../../../Redux/slices/userSlice';
import { Link, useNavigate } from 'react-router-dom';
const FormCreate = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { Option } = Select;
  const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 20 },
  };
  const onFinish = (values) => {
    dispatch(postRegisterUserApi(values));
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
          rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item
          label='Password'
          name='password'
          rules={[{ required: true }]}>
          <Input.Password />
        </Form.Item>
        <Form.Item
          name='email'
          label='Email'
          rules={[{ required: true }, { type: 'email' }]}>
          <Input />
        </Form.Item>
        <Form.Item name='phoneNumber' label='Phone Number'>
          <Input />
        </Form.Item>
        <Form.Item label='Department' name='department'>
          <Select style={{ width: 120 }}>
            <Option value='1'>Support</Option>
            <Option value='2'>Academic</Option>
          </Select>
        </Form.Item>
        <Form.Item label='Role' name='role'>
          <Input />
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
