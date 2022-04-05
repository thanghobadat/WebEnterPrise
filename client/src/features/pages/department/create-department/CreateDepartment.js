import React from 'react';
import { Form, Input, Button } from 'antd';
import './create.scss';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { message } from 'antd';

const CreateDepartment = () => {
	const navigate = useNavigate();
	const onFinish = (values) => {
		const { name, description } = values;
		createDepartmentSubmit(name, description);
	};

	const createDepartmentSubmit = async (name, description) => {
		const config = { headers: { 'Content-Type': 'application/json' } };

		await axios.post(
			`https://localhost:5001/api/Departments/CreateDepartment`,
			{ name, description },
			config
		);
		navigate('/admin/list-department');
		message.success('Create department success !!');
	};
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
			>
				<h1>Create new department</h1>
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

export default CreateDepartment;