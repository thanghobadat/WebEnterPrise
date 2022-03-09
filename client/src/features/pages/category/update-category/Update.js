import React, { useEffect } from 'react';
import { Form, Input, Button } from 'antd';
import '../create-category/create.css';
import axios from 'axios';
import { useParams } from 'react-router-dom';

const Update = () => {
	const { id } = useParams();
	const onFinish = (values) => {
		const { name, description } = values;
		updateCatetoryById(parseInt(id), name, description);
	};

	const onFinishFailed = (errorInfo) => {
		console.log('Failed:', errorInfo);
	};

	const getCatetoryById = async () => {
		const res = await axios.get(
			`https://localhost:5001/api/Categories/GetById?categoryId=${id}`
		);
		return res.data.resultObj;
	};

	const updateCatetoryById = async (id, name, description) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		const res = await axios.put(
			`https://localhost:5001/api/Categories/UpdateCategory`,
			{ id, name, description },
			config
		);
		return res.data;
	};

	useEffect(() => {
		getCatetoryById();
	}, []);

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
				<h1>Update category</h1>
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

export default Update;