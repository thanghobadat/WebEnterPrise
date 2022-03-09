/** @format */

import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Table, Button, Row, Col, Modal, Form, Input, Select } from 'antd';
import '../../../../assets/styles/_typeButton.scss';
import './list-user.scss';

import {
  getListUserApi,
  postRegisterUserApi,
  putChangePasswordUserApi,
} from '../../../../Redux/slices/userSlice';
import { Link } from 'react-router-dom';
const ListUser = () => {
  const { listUserApi } = useSelector((state) => state.listUser);
  const dispatch = useDispatch();
  const [formUser, setFormUser] = useState({
    id: '',
    newPassword: '',
  });

  const { Option } = Select;
  useEffect(() => {
    dispatch(getListUserApi());
  }, []);
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
      title: 'Change password',
      key: 'id',
      fixed: 'right',
      width: 200,
      render: (key) => (
        <Button
          size='large'
          className='ant-btn-warning'
          onClick={() => {
            showModal(key);
            setFormUser({
              id: key.id,
            });
          }}>
          Change password
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
    labelCol: { span: 5 },
    wrapperCol: { span: 19 },
  };
  const showModal = (id) => {
    console.log(id);
    setIsModalVisible(true);
  };
  const handleOnChange = (e) => {
    if (e.target) {
      setFormUser({ ...formUser, [e.target.name]: e.target.value });
      console.log(e.target.value);
    } else {
      setFormUser({ ...formUser });
    }
  };

  const handleOk = () => {
    dispatch(putChangePasswordUserApi({ ...formUser }));
    setIsModalVisible(false);
    console.log(formUser);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };

  return (
    <div className='container ListUser'>
      <Row className='ListUser__title'>
        <Col span={20}>
          <h2>List Account</h2>
        </Col>
        <Col span={4}>
          <Button type='primary' size='large'>
            <Link to='/create-account-user'> Add</Link>
          </Button>
        </Col>
      </Row>
      <Table
        columns={columns}
        dataSource={listUserApi}
        size='middle'
        pagination={{ pageSize: 50 }}
        scroll={{ y: 240 }}
      />
      {/* Modal */}
      <Modal
        title='Add account user'
        visible={isModalVisible}
        onOk={handleOk}
        onCancel={handleCancel}>
        <Form {...layout} name='nest-messages'>
          <Form.Item label='New Password'>
            <Input
              name='newPassword'
              onChange={(e) => handleOnChange(e)}
              value={formUser.newPassword}
              placeholder='Enter new password'
            />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};
export default ListUser;
