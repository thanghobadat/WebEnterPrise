import React, { useState } from 'react';
import { Form, Input, Button, DatePicker, Space } from 'antd';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { message } from 'antd';

const CreateAcademicYear = () => {
	const navigate = useNavigate();
	const [startDay, setStartDay] = useState('');
	const [endDay, setEndDay] = useState('');

	function onChangeStartDay(value, dateString) {
		setStartDay(dateString);
	}

	function onChangeEndDay(value, dateString) {
		setEndDay(dateString);
	}

	const createAcademicSubmit = async (name, startDay, endDay) => {
		const config = { headers: { 'Content-Type': 'application/json' } };

		const { data } = await axios.post(
			`https://localhost:5001/api/Academic/CreateAcademicYear`,
			{
				name: name,
				startDate: new Date(startDay).toISOString(),
				endDate: new Date(endDay).toISOString(),
			},
			config
		);
		if (data.isSuccessed === false) {
			message.error(data.message);
		} else {
			navigate('/admin/list-academic');
			message.success('Create academic year success !!');
		}
	};

	const onFinish = (values) => {
		createAcademicSubmit(values.name, startDay, endDay);
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
				<h1>Create academic year</h1>
				<Form.Item
					label="Name"
					name="name"
					rules={[{ required: true, message: 'Please input name!' }]}
				>
					<Input />
				</Form.Item>
				<Form.Item
					label="Start day"
					name="startDay"
					rules={[
						{ required: true, message: 'Please choose start date time!' },
					]}
				>
					<DatePicker showTime onChange={onChangeStartDay} />
				</Form.Item>

				<Form.Item
					label="End day"
					name="date"
					rules={[{ required: true, message: 'Please choose end date time!' }]}
				>
					<DatePicker showTime onChange={onChangeEndDay} />
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

export default CreateAcademicYear;
