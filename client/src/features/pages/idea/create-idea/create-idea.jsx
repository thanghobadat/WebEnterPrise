import React from 'react';
import { Form, Input, Button } from 'antd';
import './create-idea.scss';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
const CreateIdea = () => {
	const navigate = useNavigate();
	const onFinish = (values) => {
		console.log('Success:', values);
		const {content, userId, IsAnonymously } = values;
		Submit(content, userId, IsAnonymously);
	};

	const onFinishFailed = (errorInfo) => {
		console.log('Failed:', errorInfo);
	};
	const Submit= async (content, userId, IsAnonymously) => {
		const config = { headers: { 'Content-Type': 'application/json' } };

		const { data } = await axios.post(
			`https://localhost:5001/api/Ideas/CreateIdea`,
			{ content, userId, IsAnonymously },
			config
		)
		
		navigate('/list-idea');
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
				<h1>Create a new idea</h1>
				<Form.Item
					label="Content"
					name="content"
					rules={[{ required: true, message: 'Please input content!' }]}
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

export default CreateIdea;