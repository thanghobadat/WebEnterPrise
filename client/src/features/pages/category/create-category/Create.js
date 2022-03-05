import React from 'react';
import { Form, Input, Button } from 'antd';
import './create.css';
import axios from 'axios';
const Create = () => {
	const onFinish = (values) => {
		console.log('Success:', values);
		const {name, description } = values;
		Submit(name, description);
	};

	const onFinishFailed = (errorInfo) => {
		console.log('Failed:', errorInfo);
	};
	const Submit= async (name, description) => {
		const config = { headers: { 'Content-Type': 'application/json' } };

		const { data } = await axios.post(
			'http://192.168.98.192:5001/api/Departments/CreateDepartment',
			{ name, description },
			config
		)
	}
	return (
		<div className="create">
			<Form
				name="basic"
				labelCol={{ span: 8 }}
				wrapperCol={{ span: 16 }}
				initialValues={{ remember: true }}
				onFinish={onFinish}
				onFinishFailed={onFinishFailed}
				autoComplete="off"
			>
				<h1>Create a new category</h1>
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

export default Create;