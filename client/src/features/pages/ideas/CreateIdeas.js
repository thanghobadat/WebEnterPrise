import React from 'react';
import axios from 'axios';
import './createIdeas.css';
import { Form, Input, Button, Checkbox, Upload } from 'antd';

import { UploadOutlined, InboxOutlined } from '@ant-design/icons';
const CreateIdeas = () => {
	const userId = '7c1da15f-9a9b-41da-e1b7-08da080580bf';
	const [user, setUser] = React.useState({
		content: '',
		password: '',
	});

	const { content, password } = user;

	const [avatar, setAvatar] = React.useState('');

	const registerSubmit = (e) => {
		e.preventDefault();

		const formData = new FormData();
		formData.set('content', content);
		formData.set('UserId', userId);
		formData.set('password', password);
		formData.set('avatar', avatar);
		console.log(Object.fromEntries(formData));
		createIdeasSubmit(formData);
		// message.success('Create  success !!');
	};

	const createIdeasSubmit = async (userData) => {
		const config = { headers: { 'Content-Type': 'multipart/form-data' } };

		const res = await axios.post(
			`https://localhost:5001/api/Ideas/CreateIdea`,
			userData,
			config
		);
		return res;
	};

	const addDataForm = (e) => {
		if (e.target.name === 'avatar') {
			const reader = new FileReader();

			reader.onload = () => {
				if (reader.readyState === 2) {
					setAvatar(reader.result);
				}
			};

			reader.readAsDataURL(e.target.files[0]);
		} else {
			setUser({ ...user, [e.target.name]: e.target.value });
		}
	};

	const onFinish = (values) => {
		console.log('Success:', values);
	};

	const onFinishFailed = (errorInfo) => {
		console.log('Failed:', errorInfo);
	};

	const normFile = (e) => {
		console.log('Upload event:', e);

		if (Array.isArray(e)) {
			return e;
		}

		return e && e.fileList;
	};

	return (
		// <form
		// 	className="min-w-screen min-h-screen flex items-center justify-center px-5 pt-3"
		// 	encType="multipart/form-data"
		// 	onSubmit={registerSubmit}
		// >
		// 	<div className="bg-gray-100 text-gray-500 rounded-3xl shadow-xl w-full overflow-hidden">
		// 		<div className="md:flex w-full">
		// 			<div className="w-full md:w-1/2 py-10 px-5 md:px-10">
		// 				<div className="text-center mb-10">
		// 					<h1 className="font-bold text-3xl text-gray-900">REGISTER</h1>
		// 					<p>Enter your information to register</p>
		// 				</div>
		// 				<div>
		// 					<div className="flex -mx-3">
		// 						<div className="w-full px-3 mb-5">
		// 							<label htmlFor="" className="text-xs font-semibold px-1">
		// 								Password
		// 							</label>
		// 							<div className="flex">
		// 								<div className="w-10 z-10 pl-1 text-center pointer-events-none flex items-center justify-center">
		// 									<i className="mdi mdi-email-outline text-gray-400 text-lg"></i>
		// 								</div>
		// 								<input
		// 									type="password"
		// 									placeholder="Please enter your Email"
		// 									className="w-full -ml-10 pl-10 pr-3 py-2 rounded-lg border-2 border-gray-200 outline-none focus:border-indigo-500"
		// 									required
		// 									name="password"
		// 									value={password}
		// 									onChange={addDataForm}
		// 								/>
		// 							</div>
		// 						</div>
		// 						<div className="w-full px-3 mb-5">
		// 							<label htmlFor="" className="text-xs font-semibold px-1">
		// 								content
		// 							</label>
		// 							<div className="flex">
		// 								<div className="w-10 z-10 pl-1 text-center pointer-events-none flex items-center justify-center">
		// 									<i className="mdi mdi-email-outline text-gray-400 text-lg"></i>
		// 								</div>
		// 								<input
		// 									type="content"
		// 									placeholder="Please enter your content"
		// 									className="w-full -ml-10 pl-10 pr-3 py-2 rounded-lg border-2 border-gray-200 outline-none focus:border-indigo-500"
		// 									required
		// 									name="content"
		// 									value={content}
		// 									onChange={addDataForm}
		// 								/>
		// 							</div>
		// 						</div>
		// 					</div>

		// 					<input
		// 						type="file"
		// 						name="avatar"
		// 						accept=".doc,.docx,pptx,image/*,pdf"
		// 						multiple
		// 						onChange={addDataForm}
		// 						className="mt-1 p-2 focus:ring-indigo-500 focus:border-indigo-500 block w-full shadow-sm sm:text-sm border-gray-300 rounded-md"
		// 					/>

		// 					<div className="flex -mx-3">
		// 						<div className="w-full px-3 mb-5">
		// 							<button
		// 								type="submit"
		// 								value="Register"
		// 								className="block w-full max-w-xs mx-auto bg-indigo-500 hover:bg-indigo-700 focus:bg-indigo-700 text-white rounded-lg px-3 py-3 font-semibold"
		// 							>
		// 								REGISTER
		// 							</button>
		// 						</div>
		// 					</div>
		// 				</div>
		// 			</div>
		// 		</div>
		// 	</div>
		// </form>

		<div className="wrapper">
			<div className="title">Upload Ideas</div>
			<div className="form">
				<div className="inputfield ">
					<label className="ok">Content</label>
					<textarea className="textarea" />
				</div>
				<div className="inputfield ">
					<label className="not">First Name</label>
					<input
						type="file"
						name="avatar"
						accept=".doc,.docx,pptx,image/*,pdf"
						multiple
						onChange={addDataForm}
						class="input"
					/>
				</div>

				<div className="inputfield terms">
					<label className="check">
						<input type="checkbox" />
						<span className="checkmark"></span>
					</label>
					<p className="text_agree">Agreed to terms and conditions</p>
				</div>
				<div className="inputfield">
					<input type="submit" value="Submit" className="btn" />
				</div>
			</div>
		</div>
	);
};

export default CreateIdeas;
