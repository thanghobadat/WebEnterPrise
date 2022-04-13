import React, { useEffect, useState } from 'react';
import './Post.css';
import axios from 'axios';
import LinesEllipsis from 'react-lines-ellipsis';
import { useNavigate, useParams } from 'react-router-dom';
import { message } from 'antd';

function Post() {
	const { id } = useParams();
	const [loading, setloading] = useState(true);
	const navigate = useNavigate();
	const [idea, setIdea] = useState([]);
	const [userId, setUserId] = useState();
	const [content, setContent] = useState('');
	const [anonymous, setAnonymous] = useState('');
	var retrievedObject = localStorage.getItem('user');
	var localStore = JSON.parse(retrievedObject);
	const userIdComment = localStore.id;
	const [ideaComment, setIdeaComment] = useState([]);

	let user = JSON.parse(localStorage.getItem('user'));

	useEffect(() => {
		setUserId(user.id);
		getIdeaById();
		getCommentById();
	}, [content]);

	const getIdeaById = async () => {
		await axios
			.get(`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`)
			.then((res) => {
				setloading(false);
				setIdea(res.data.resultObj);
			});
	};

	
	const formatDate = (createdAt) => {
		const options = { year: 'numeric', month: 'long', day: 'numeric' };
		return new Date(createdAt).toLocaleDateString(undefined, options);
	};

	const addCommentSubmit = async (e) => {
		e.preventDefault();
		const config = { headers: { 'Content-Type': 'application/json' } };
		const ideasID = parseInt(id);
		await axios.post(
			`https://localhost:5001/api/Ideas/AddNewComment`,
			{
				content,
				isAnonymous: JSON.parse(anonymous.toLowerCase()),
				ideaId: ideasID,
				userId: userIdComment,
			},
			config
		);
		message.success('Add comment successfully !!');
		setContent('');
		setAnonymous('');
	};

	const getCommentById = async () => {
		try {
			const res = await axios.get(
				`https://localhost:5001/api/Ideas/GetAllComment?id=${id}`
			);

			setIdeaComment(res.data.resultObj);
		} catch (error) {
			console.log('Failed to fetch department list', error.message);
		}
	};
	const handleAssign = async (id) => {
		if (user.role === "admin") {
			return navigate(`/admin/assign-category-to-idea/${id}`);
		}else if (user.role === "QACoordinator") {
			return navigate(`/QACoordinator/assign-category-to-idea/${id}`);
		}else if (user.role === "QAManager") {
			return navigate(`/QAManager/assign-category-to-idea/${id}`);
		}
	};
	return (
		<>
			<div className="posts">
				<div className="post User">
					<div className="post__center"></div>
					<div className="post__right">
						<h1 className="post__info">
							Posted by
							{idea.isAnonymously !== true ? idea.userName : 'Anonymously'} at: {formatDate(idea.createdAt)} 
							<span style={{marginLeft: '10px'}}>
							- {idea.categories}
							</span>
							{user.role ==='QAManager' ? <button onClick={() => {handleAssign(idea.id);}} style={{marginLeft: '10px'}}>
								Assign Category to Idea
							</button> : <></>}
						</h1>
						<LinesEllipsis
							maxLine="10"
							ellipsis="..."
							basedOn="letters"
							text={idea.content}
						></LinesEllipsis>
						
						<p className="post__info">
							{idea.view} views | {idea.likeAmount}
							like | {idea.dislikeAmount} dislike
						</p>
						<div style={{visibility: !idea.filePath  ? 'hidden' : 'visible'}}>
						<a href={`https://localhost:5001/api/Ideas/DownloadFile?fileName=${idea.filePath}`} download>Click to download</a>
					</div>
					</div>
				</div>
			</div>
			{/* Comment */}
			{user.role === 'staff' ? 	<section className="rounded-b-lg px-4 mt-4 ">
					<div className="flex mx-auto items-center justify-center shadow-lg mx-8 mb-2 max-w-lg">
						<form
							className="w-full max-w-xl bg-white rounded-lg px-4 pt-2"
							encType="multipart/form-data"
							onSubmit={addCommentSubmit}
						>
							<div className="flex flex-wrap -mx-3 mb-6">
								<h2 className="px-4 pt-3 pb-2 text-gray-800 text-lg">
									Add a new comment
								</h2>
								<div className="w-full md:w-full px-3 mb-2 mt-2">
									<textarea
										className="bg-gray-100 rounded border border-gray-400 leading-normal resize-none w-full h-20 py-2 px-3 font-medium placeholder-gray-700 focus:outline-none focus:bg-white"
										name="body"
										placeholder="Your content comment"
										required
										value={content}
										onChange={(e) => setContent(e.target.value)}
									></textarea>
								</div>
								<div className="w-full md:w-full flex items-start md:w-full px-3">
									<div className="flex items-start w-1/2 text-gray-700 px-2 mr-auto">
										<select
											name="anonymously"
											required
											value={anonymous}
											onChange={(e) => setAnonymous(e.target.value)}
											className="text-xs flex items-center md:text-sm p-1 text-gray-900 focus:outline-none focus:border-blue-700 border rounded border-gray-200"
										>
											<option value="">Choose anonymously</option>
											<option value="true">True</option>
											<option value="false">False</option>
										</select>
									</div>
									<div className="-mr-1">
										<input
											type="submit"
											className="bg-white text-gray-700 font-medium py-1 px-4 border border-gray-400 rounded-lg tracking-wide mr-1 hover:bg-gray-100"
											value="Post Comment"
										/>
									</div>
								</div>
							</div>
						</form>
					</div>
					<div id="task-comments" className="pt-4 pb-4">
						{ideaComment.map((comment) => (
							<div className="bg-white rounded-lg p-6 flex flex-col justify-center items-center md:items-start shadow-lg mb-4">
								<div className="flex flex-row justify-center mr-2">
									<img
										alt="avatar"
										width="48"
										height="48"
										className="rounded-full w-10 h-10 mr-4 shadow-lg mb-4"
										src="https://cdn1.iconfinder.com/data/icons/technology-devices-2/100/Profile-512.png"
									/>
									{comment.isAnonymously === false ? (
										<h3 className="font-semibold text-lg text-center md:text-left ">
											{comment.name}
										</h3>
									) : (
										<h3 className="font-semibold text-lg text-center md:text-left ">
											Anonymous User
										</h3>
									)}
								</div>
								<p className="text-gray-600 text-lg text-center md:text-left ">
									Content: {comment?.content}
								</p>
							</div>
						))}
					</div>
				</section>:<></> }<div>
			
			</div>
		</>
	);
}

export default Post;
