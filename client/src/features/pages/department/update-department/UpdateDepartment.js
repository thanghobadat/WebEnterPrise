import React, { useEffect, useRef, useState } from 'react';
import { Form, Input, Button } from 'antd';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import { message } from 'antd';

const UpdateDepartment = () => {
	const { id } = useParams();
	const navigate = useNavigate();
	const formRef = useRef(null);
	const [name, setName] = useState('');
	const [description, setDescription] = useState('');

	const onFinish = (values) => {
		const { name, description } = values;
		updateCategoryById(parseInt(id), name, description);
	};

	const getDepartmentById = async () => {
		const res = await axios.get(
			`https://localhost:5001/api/Departments/GetDepartmentById?id=${id}`
		);
		setName(res.data.resultObj.name);
		setDescription(res.data.resultObj.description);
		return res.data.resultObj;
	};

	const updateCategoryById = async (id, name, description) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		await axios.put(
			`https://localhost:5001/api/Departments/UpdateDepartment`,
			{ id, name, description },
			config
		);
		navigate('/admin/list-department');
		message.success('Update department success !!');
	};

	useEffect(() => {
		getDepartmentById();

		formRef?.current?.setFieldsValue({
			name: name,
			description: description,
		});
	});

	return (
		<div className="create">
			<Form
				name="basic"
				labelCol={{ span: 8 }}
				wrapperCol={{ span: 16 }}
				initialValues={{ remember: true }}
				onFinish={onFinish}
				autoComplete="off"
				className="form"
				ref={formRef}
			>
				<h1>Update department</h1>
				<Form.Item
					label="Name"
					name="name"
					rules={[{ required: true, message: 'Please input name!' }]}
				>
					<Input />
				</Form.Item>

				<Form.Item
					label="Description"
					name="description"
					rules={[{ required: true, message: 'Please input description!' }]}
				>
					<Input />
				</Form.Item>
				<Form.Item wrapperCol={{ offset: 8, span: 16 }}>
					<Button type="primary" htmlType="submit">
						Submit
					</Button>
				</Form.Item>
			</Form>
		</div>
	);
};

export default UpdateDepartment;
