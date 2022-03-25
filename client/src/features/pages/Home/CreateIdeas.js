import React, { useState } from 'react';
import axios from 'axios';
import { message } from 'antd';
import { useNavigate } from 'react-router-dom';

const CreateIdeas = () => {
	var retrievedObject = localStorage.getItem('user');
	var localStore = JSON.parse(retrievedObject);
	const userId = localStore.id;
	const navigate = useNavigate();
	const [ideas, setIdeas] = useState({
		content: '',
		anonymously: '',
	});

	const { content, anonymously } = ideas;

	const [avatar, setAvatar] = useState(null);

	const createIdeasSubmit = async (userData) => {
		const config = { headers: { 'Content-Type': 'multipart/form-data' } };

		await axios.post(
			`https://localhost:5001/api/Ideas/CreateIdea`,
			userData,
			config
		);
	};

	const registerSubmit = (e) => {
		e.preventDefault();

		const formData = new FormData();
		formData.append('Content', content);
		formData.append('UserId', userId);
		formData.append('IsAnonymously', anonymously);
		formData.append('File', avatar);
		createIdeasSubmit(formData);
		navigate('/admin/view-idea');
		message.success('Upload ideas success !!');
	};

	const addDataForm = (e) => {
		if (e.target.name === 'avatar') {
			setAvatar(e.target.files[0]);
		} else {
			setIdeas({ ...ideas, [e.target.name]: e.target.value });
		}
	};

	return (
		<div className="w-full">
			<div className="bg-gradient-to-b from-blue-800 to-blue-600 h-96"></div>
			<div className="max-w-5xl mx-auto px-6 sm:px-6 lg:px-8 mb-12">
				<div className="bg-white w-full shadow rounded p-8 sm:p-12 -mt-72">
					<p className="text-3xl font-bold leading-7 text-center">
						Upload Ideas
					</p>
					<form encType="multipart/form-data" onSubmit={registerSubmit}>
						<div>
							<div className="w-full flex flex-col mt-8">
								<label className="font-semibold leading-none">
									Content finaldate ideas
								</label>
								<textarea
									type="text"
									required
									name="content"
									value={content}
									onChange={addDataForm}
									className="h-40 text-base leading-none text-gray-900 p-3 focus:oultine-none focus:border-blue-700 mt-4 bg-gray-100 border rounded border-gray-200"
								></textarea>
							</div>
						</div>
						<div className="md:flex items-center mt-8">
							<div className="w-full flex flex-col">
								<label className="font-semibold leading-none">
									Upload supporting documents ideas
								</label>
								<input
									type="file"
									required
									name="avatar"
									accept="image/*"
									onChange={addDataForm}
									className="leading-none text-gray-900 p-3 focus:outline-none focus:border-blue-700 mt-4 bg-gray-100 border rounded border-gray-200"
								/>
							</div>
						</div>

						<div className="md:flex items-center mt-8">
							<div className="w-full flex flex-col">
								<label className="font-semibold leading-none">
									Is anonymously
								</label>
								<select
									name="anonymously"
									required
									value={anonymously}
									onChange={addDataForm}
									className="leading-none text-gray-900 p-3 focus:outline-none focus:border-blue-700 mt-4 bg-gray-100 border rounded border-gray-200"
								>
									<option value="">Please choose anonymously</option>
									<option value="true">True</option>
									<option value="false">False</option>
								</select>
							</div>
						</div>

						<div className="md:flex items-center mt-8">
							<div className="w-full flex items-center">
								<input type="checkbox" name="vehicle1" value="Bike" required />
								<label for="vehicle1" className="ml-2">
									Terms and Conditions
								</label>
								<br />
							</div>
						</div>

						<div className="flex items-center justify-center w-full">
							<button
								type="submit"
								className="mt-9 font-semibold leading-none text-white py-4 px-10 bg-blue-700 rounded hover:bg-blue-600 focus:ring-2 focus:ring-offset-2 focus:ring-blue-700 focus:outline-none"
							>
								Submit
							</button>
						</div>
					</form>
				</div>
			</div>
		</div>
	);
};

export default CreateIdeas;
