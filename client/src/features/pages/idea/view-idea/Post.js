import React, { useEffect, useState } from 'react';
import './Post.css';
import queryString from 'query-string';
import axios from 'axios';
import {
	CaretDownFilled,
	CaretUpFilled,
	MessageTwoTone,
	EyeTwoTone,
} from '@ant-design/icons';
import LinesEllipsis from 'react-lines-ellipsis';
import { useNavigate, useParams } from 'react-router-dom';
import { message } from 'antd';

function Post() {
	const { id } = useParams();
	const [loading, setloading] = useState(true);
	const [idea, setIdea] = useState([]);
	const [userId, setUserId] = useState();
	const [content, setContent] = useState('');
	const [anonymous, setAnonymous] = useState('');
	var retrievedObject = localStorage.getItem('user');
	var localStore = JSON.parse(retrievedObject);
	const userIdComment = localStore.id;

	let user;

	useEffect(() => {
		user = JSON.parse(localStorage.getItem('user'));
		getIdeaById();
	}, []);

	const getIdeaById = async () => {
		await axios
			.get(`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`)
			.then((res) => {
				setloading(false);
				setIdea(res.data.resultObj);
				setUserId(user.id);
			});
	};

	const handleLike = async (id, userId, like) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		if (like === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
				{ id, userId, number: 2 },
				config
			);
			console.log(userId);
		} else {
			return;
		}

		getIdeaById();
	};

	const handleDisLike = async (id, userId, dislike) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		if (dislike === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
				{ id, userId, number: 2 },
				config
			);
		} else {
			return;
		}
		getIdeaById();
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
	};

	return (
		<>
			<div className="posts">
				<div className="post User">
					<div className="post__left">
						<CaretUpFilled
							style={{ fontSize: '1.5rem' }}
							onClick={() => {
								handleLike(idea.id, userId, idea.like);
							}}
						/>

						<CaretDownFilled
							style={{ fontSize: '1.5rem' }}
							onClick={() => {
								handleDisLike(idea.id, userId, idea.dislike);
							}}
						/>
					</div>
					<div className="post__center"></div>
					<div className="post__right">
						<h1 className="post__info">
							Posted by{' '}
							{idea.isAnonymously !== true ? idea.userName : 'Anonymously'} at{' '}
							{idea.createdAt}
						</h1>
						<LinesEllipsis
							maxLine="10"
							ellipsis="..."
							basedOn="letters"
							text={idea.content}
						></LinesEllipsis>
						<div>
							<img src={idea.filePath} alt="" />
						</div>
						<p className="post__info">
							<MessageTwoTone style={{ marginTop: 10, fontSize: '1.5rem' }} />
							{idea.comments_count} Comments | {idea.view} views | {idea.like}{' '}
							like | {idea.dislike} dislike{' '}
						</p>
					</div>
				</div>
			</div>
			{/* Comment */}

			<div>
				<section className="rounded-b-lg px-4 mt-4 ">
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
					<div id="task-comments" className="pt-4">
						<div className="bg-white rounded-lg p-6 flex flex-col justify-center items-center md:items-start shadow-lg mb-4">
							<div className="flex flex-row justify-center mr-2">
								<img
									alt="avatar"
									width="48"
									height="48"
									className="rounded-full w-10 h-10 mr-4 shadow-lg mb-4"
									src="https://cdn1.iconfinder.com/data/icons/technology-devices-2/100/Profile-512.png"
								/>
								<h3 className="text-purple-600 font-semibold text-lg text-center md:text-left ">
									@Shanel
								</h3>
							</div>

							<p className="text-gray-600 text-lg text-center md:text-left ">
								Hi good morning will it be the entire house.{' '}
							</p>
						</div>

						<div className="bg-white rounded-lg p-3  flex flex-col justify-center items-center md:items-start shadow-lg mb-4">
							<div className="flex flex-row justify-center mr-2">
								<img
									alt="avatar"
									width="48"
									height="48"
									className="rounded-full w-10 h-10 mr-4 shadow-lg mb-4"
									src="https://cdn1.iconfinder.com/data/icons/technology-devices-2/100/Profile-512.png"
								/>
								<h3 className="text-purple-600 font-semibold text-lg text-center md:text-left ">
									@Tim Motti
								</h3>
							</div>

							<p className="text-gray-600 text-lg text-center md:text-left ">
								<span className="text-purple-600 font-semibold">@Shanel</span>{' '}
								Hello. Yes, the entire exterior, including the walls.{' '}
							</p>
						</div>
					</div>
				</section>
			</div>
		</>
	);
}

export default Post;
