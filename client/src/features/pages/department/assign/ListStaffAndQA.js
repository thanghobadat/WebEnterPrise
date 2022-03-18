import React, { useState, useEffect } from 'react';
import { Table, Button, Row, Col, Modal, Form, Input, Select } from 'antd';
import axios from 'axios';

const ListStaffAndQA = () => {
	const [listUser, setListUser] = useState([]);

	useEffect(() => {
		getDepartmentList();
	}, []);

	const getDepartmentList = async () => {
		try {
			const res = await axios.get(
				`https://localhost:5001/api/Users/GetAccountStaffAndQACoor`
			);
			const data = res.data.resultObj;

			setListUser(...listUser, data);
		} catch (error) {
			console.log('Failed to fetch department list', error.message);
		}
	};

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
					size="large"
					className="ant-btn-warning"
					onClick={() => {
						assignHandler(key.id);
					}}
				>
					Assign this user
				</Button>
			),
		},
	];

	const assignHandler = (id) => {
		console.log('====================================');
		console.log(id);
		console.log('====================================');
	};

	return (
		<div className="container ListUser">
			<Row className="ListUser__title">
				<Col span={20}>
					<h2>List Staff and QA </h2>
				</Col>
			</Row>
			<Table
				columns={columns}
				dataSource={listUser}
				size="middle"
				pagination={{ pageSize: 50 }}
				scroll={{ y: 240 }}
				rowKey={(obj) => obj.id}
			/>
		</div>
	);
};

export default ListStaffAndQA;
