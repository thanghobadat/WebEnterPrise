/** @format */

import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Table, Button, Row, Col, Modal, Form, Input } from 'antd';
import '../../../../assets/styles/_typeButton.scss';
import './list-user.scss';

import { getListUserApi } from '../../../../Redux/slices/userSlice';
const ListUser = () => {
  const { listUserApi } = useSelector((state) => state.listUser);
  const dispatch = useDispatch();
  const [data, setData] = useState(listUserApi);
  useEffect(() => {
    dispatch(getListUserApi());
    setData(listUserApi ? listUserApi : []);
  }, []);
  console.log(listUserApi);
  const columns = [
    {
      title: 'User Name',
      dataIndex: 'userName',
    },
    {
      title: 'Email',
      dataIndex: 'email',
    },
    {
      title: 'Phone Number',
      dataIndex: 'phoneNumber',
    },
    {
      title: 'Role',
      dataIndex: 'role',
    },
    {
      title: 'Department',
      dataIndex: 'department',
    },
    {
      title: 'Edit',
      key: 'edit',
      fixed: 'right',
      width: 100,
      render: () => (
        <Button size='large' className='ant-btn-warning'>
          Edit
        </Button>
      ),
    },
    {
      title: 'Delete',
      key: 'operation',
      fixed: 'right',
      width: 100,
      render: () => (
        <Button size='large' className='ant-btn-danger'>
          Delete
        </Button>
      ),
    },
  ];

  const [isModalVisible, setIsModalVisible] = useState(false);
  const layout = {
    labelCol: { span: 4 },
    wrapperCol: { span: 20 },
  };
  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleOk = () => {
    setIsModalVisible(false);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };
  const onFinish = (values) => {
    console.log(values);
  };

  return (
    <div class='container ListUser'>
      <Row className='ListUser__title'>
        <Col span={20}>
          <h2>List Account</h2>
        </Col>
        <Col span={4}>
          <Button type='primary' size='large' onClick={showModal}>
            Add
          </Button>
        </Col>
      </Row>
      <Table
        columns={columns}
        dataSource={data}
        size='middle'
        pagination={{ pageSize: 50 }}
        scroll={{ y: 240 }}
      />
      {/* Modal */}
      <Modal
        title='Basic Modal'
        visible={isModalVisible}
        onOk={handleOk}
        onCancel={handleCancel}>
        <Form {...layout} name='nest-messages' onFinish={onFinish}>
          <Form.Item name={['user', 'name']} label='Username'>
            <Input />
          </Form.Item>
          <Form.Item
            name={['user', 'email']}
            label='Email'
            rules={[{ type: 'email' }]}>
            <Input />
          </Form.Item>
          <Form.Item label='Password' name='password'>
            <Input.Password />
          </Form.Item>
          <Form.Item label='Phone' name='Phone'>
            <Input />
          </Form.Item>
          <Form.Item label='Date Time' name='Date Time'>
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};
export default ListUser;
