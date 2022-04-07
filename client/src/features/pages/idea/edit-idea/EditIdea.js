import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { message } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';

const EditIdea = () => {
	var retrievedObject = localStorage.getItem('user');
	var localStore = JSON.parse(retrievedObject);
	const userId = localStore.id;
	const { id } = useParams();
	const navigate = useNavigate();
	const [content, setContent] = useState('');
	const [fileNew, setFileNew] = useState(null);
	const getIdeaById = async () => {
		const res = await axios.get(
			`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`
		);

		setContent(res.data.resultObj.content);
		return res.data.resultObj;
	};

	useEffect(() => {
		getIdeaById();
	}, []);

	const editIdeasSubmit = async (userData) => {
		const config = { headers: { 'Content-Type': 'multipart/form-data' } };
		await axios.put(
			`https://localhost:5001/api/Ideas/UpdateIdea`,
			userData,
			config
		);
	};

	const uploadImagesChange = (e) => {
		if (e.target.name === 'avatar') {
			console.log(e.target.files[0]);
			setFileNew(e.target.files[0]);
		} else {
			return;
		}
	};

	const uploadIdeasSubmit = (e) => {
		e.preventDefault();

		const formData = new FormData();
		formData.append('Id', parseInt(id));
		formData.append('Content', content);
		formData.append('File', fileNew);

		editIdeasSubmit(formData);
		setTimeout(() => {
			localStore.role === 'admin'
				? navigate('/admin/view-idea')
				: navigate('/staff/view-idea');
		}, 1000);
		message.success('Update ideas success !!');
	};

	return (
		<div className="w-full">
			<div className="bg-gradient-to-b from-blue-800 to-blue-600 h-96"></div>
			<div className="max-w-5xl mx-auto px-6 sm:px-6 lg:px-8 mb-12">
				<div className="bg-white w-full shadow rounded p-8 sm:p-12 -mt-72">
					<p className="text-3xl font-bold leading-7 text-center">Edit ideas</p>
					<form encType="multipart/form-data" onSubmit={uploadIdeasSubmit}>
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
									onChange={(e) => setContent(e.target.value)}
									className="h-40 text-base leading-none text-gray-900 p-3 focus:oultine-none focus:border-blue-700 mt-4 bg-gray-100 border rounded border-gray-200"
								></textarea>
							</div>
						</div>
						<div className="md:flex items-center mt-8">
							<div className="w-full flex flex-col">
								<label className="font-semibold leading-none">
									Upload supporting documents ideas (If empty, the old file will
									be kept)
								</label>
								<input
									type="file"
									name="avatar"
									accept="image/*"
									onChange={uploadImagesChange}
									className="leading-none text-gray-900 p-3 focus:outline-none focus:border-blue-700 mt-4 bg-gray-100 border rounded border-gray-200"
								/>
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

export default EditIdea;
