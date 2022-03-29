import React, { useEffect, useRef, useState } from 'react';
import { Form, Input, Button } from 'antd';
import './update.scss';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import { message } from 'antd';

const Update = () => {
	const { id } = useParams();
	const navigate = useNavigate();
	const formRef = useRef(null);
	const [name, setName] = useState('');
	const [description, setDescription] = useState('');

	const onFinish = (values) => {
		const { name, description } = values;
		updateCategoryById(parseInt(id), name, description);
	};

	const getCategoryById = async () => {
		const res = await axios.get(
			`https://localhost:5001/api/Categories/GetById?categoryId=${id}`
		);
		setName(res.data.resultObj.name);
		setDescription(res.data.resultObj.description);
		return res.data.resultObj;
	};

	const updateCategoryById = async (id, name, description) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		await axios.put(
			`https://localhost:5001/api/Categories/UpdateCategory`,
			{ id, name, description },
			config
		);
		navigate('/admin/list-category');
		message.success('Update category success !!');
	};

	useEffect(() => {
		getCategoryById();

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
