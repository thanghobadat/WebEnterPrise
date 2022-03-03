/** @format */

import React from 'react';
import { Table, Button } from 'antd';

import './list-user.scss';
const ListUser = () => {
  const columns = [
    {
      title: 'Name',
      dataIndex: 'name',
    },
    {
      title: 'Age',
      dataIndex: 'age',
    },
    {
      title: 'Address',
      dataIndex: 'address',
    },
    {
      title: 'Edit',
      dataIndex: 'edit',
    },
    {
      title: 'Delete',
      dataIndex: 'delete',
    },
  ];
  const data = [
    {
      key: '1',
      name: 'John Brown',
      age: 32,
      address: 'New York No. 1 Lake Park',
      edit: <Button size='large'>Edit</Button>,
      delete: <Button size='large'>Delete</Button>,
    },
    {
      key: '2',
      name: 'Jim Green',
      age: 42,
      address: 'London No. 1 Lake Park',
      edit: <Button size='large'>Edit</Button>,
      delete: <Button size='large'>Delete</Button>,
    },
  ];
  return (
    <div class='container ListUser'>
      <h2>List Account</h2>
      <Table columns={columns} dataSource={data} size='middle' />
    </div>
  );
};
export default ListUser;
