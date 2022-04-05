/** @format */

import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  Table,
  Button,
  Row,
  Col,
  Modal,
  Form,
  Input,
  Spin,
  message,
} from 'antd';
import { ExclamationCircleOutlined } from '@ant-design/icons';
import validatorForm from '../validation';
import '../../../../assets/styles/_typeButton.scss';
import './list-user.scss';

import {
  deleteUserApi,
  getListUserApi,
  putChangePasswordUserApi,
} from '../../../../Redux/slices/userSlice';
import { Link } from 'react-router-dom';
const ListUser = () => {
  const { listUserApi } = useSelector((state) => state.listUser);
  const dispatch = useDispatch();
  const rgPass = /^(?=.*[0-9])(?=.*[!@#$%^&*])[A-Z][a-zA-Z0-9!@#$%^&*]{7,15}$/;
  const { confirm } = Modal;
  const [formUser, setFormUser] = useState({
    id: '',
    newPassword: '',
    confirmPassword: '',
  });
  useEffect(() => {
    dispatch(getListUserApi());
  }, [dispatch, listUserApi]);
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
            showModal();
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
      render: (key) => (
        <Button
          size='large'
          className='ant-btn-danger'
          onClick={() => showDeleteConfirm(key.id)}>
          Delete
        </Button>
      ),
    },
  ];

  const [isModalVisible, setIsModalVisible] = useState(false);
  const layout = {
    labelCol: { span: 6 },
    wrapperCol: { span: 18 },
  };
  const showModal = () => {
    setIsModalVisible(true);
  };
  const handleOnChange = (e) => {
    if (e.target) {
      setFormUser({ ...formUser, [e.target.name]: e.target.value });
    } else {
      setFormUser({ ...formUser });
    }
  };
  const handleOk = () => {
    console.log(formUser.confirmPassword === formUser.newPassword);
    if (formUser.confirmPassword === formUser.newPassword) {
      dispatch(putChangePasswordUserApi({ ...formUser }));
      message.success('Change password is success!');
      setIsModalVisible(false);
    } else {
      message.error('Confirm password not success!');
    }
  };
  const handleCancel = () => {
    setIsModalVisible(false);
  };
  const showDeleteConfirm = (id) => {
    confirm({
      title: 'Are you sure delete this user?',
      icon: <ExclamationCircleOutlined />,
      okText: 'Yes',
      okType: 'danger',
      cancelText: 'No',
      onOk() {
        dispatch(deleteUserApi(id));
      },
      onCancel() {
        console.log('Cancel');
      },
    });
  };
  return (
    <div className='container ListUser'>
      <Row className='ListUser__title'>
        <Col span={20}>
          <h2>List Account</h2>
        </Col>
        <Col span={4}>
          <Button type='primary' size='large'>
            <Link to='/admin/create-account-user'> Add</Link>
          </Button>
        </Col>
      </Row>
      <Table
        columns={columns}
        dataSource={listUserApi || <Spin />}
        size='middle'
      />
      {/* Modal Change Pass*/}
      <Modal
        title='Add account user'
        visible={isModalVisible}
        onOk={handleOk}
        onCancel={handleCancel}>
        <Form {...layout} name='nest-messages' validateMessages={validatorForm}>
          <Form.Item
            label='New Password'
            name='newPassword'
            rules={[
              { required: true },
              { type: 'regexp' },
              {
                pattern: new RegExp(rgPass),
                mess: 'include first uppercase letter, lowercase letter, number, special character',
              },
            ]}>
            <Input.Password
              name='newPassword'
              onChange={(e) => handleOnChange(e)}
              value={formUser.newPassword}
              placeholder='Enter new password'
            />
          </Form.Item>
          <Form.Item label='Confirm Password'>
            <Input.Password
              name='confirmPassword'
              onChange={(e) => handleOnChange(e)}
              value={formUser.confirmPassword}
              placeholder='Enter new password'
            />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};
export default ListUser;
