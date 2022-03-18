import React, { useState, useEffect } from 'react';
import { Table, Button, Row, Col } from 'antd';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import { message } from 'antd';

const ListStaffAndQA = () => {
	const [listUser, setListUser] = useState([]);
	const { id } = useParams();
	const navigate = useNavigate();

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

	useEffect(() => {
		getDepartmentList();
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
			title: 'Role',
			dataIndex: 'role',
		},
		{
			title: 'Department',
			dataIndex: 'department',
		},
		{
			title: 'Assign',
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

	const assignHandler = async (userId) => {
		await axios.put(
			`https://localhost:5001/api/Departments/AssignDepartment?id=${id}&userId=${userId}`
		);
		navigate('/list-department');
		message.success('Assign department to user success !!');
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
