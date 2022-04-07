import React, { useEffect, useState } from 'react';
import './Posts.css';
import queryString from 'query-string';
import axios from 'axios';
import { CaretDownFilled, CaretUpFilled } from '@ant-design/icons';
import LinesEllipsis from 'react-lines-ellipsis';
import { useNavigate } from 'react-router-dom';
import Pagination from '../../../../components/Pagination';
import fileDownload from 'js-file-download';

function Posts() {
	const [loading, setloading] = useState(true);
	const [postList, setPostList] = useState([]);
	const navigate = useNavigate();
	const [userId, setUserId] = useState();
	const [count, setCount] = useState(0);
	const [numberFilters, setNumberFilters] = useState(0);
	const [pagination, setPagination] = useState({
		pageIndex: 1,
		pageSize: 5,
	});

	const [filters, setFilters] = useState({
		pageIndex: 1,
		pageSize: 3,
	});

	const paramsString = queryString.stringify(filters);

	let user;

	useEffect(() => {
		user = JSON.parse(localStorage.getItem('user'));
		setUserId(user.id);
		getPostList();
	}, [filters, numberFilters]);

	const getPostList = async () => {
		if (count === 0) {
			await axios
				.get(
					`https://localhost:5001/api/Ideas/GetAllIdeaUser?userId=${user.id}&Number=${numberFilters}&${paramsString}`
				)
				.then((res) => {
					setloading(false);
					const data = res.data.resultObj;
					setPostList(data.items);
					setCount(count + 1);
				});
		} else {
			await axios
				.get(
					`https://localhost:5001/api/Ideas/GetAllIdeaUser?userId=${userId}&Number=${numberFilters}&${paramsString}`
				)
				.then((res) => {
					setloading(false);
					const data = res.data.resultObj;
					setPostList(data.items);
					setCount(count + 1);
					setPagination({
						pageIndex: data.pageIndex,
						pageSize: data.pageSize,
						totalRecords: data.totalRecords,
					});
				});
		}
	};

	if (loading) {
		return <p>Data is loading...</p>;
	}

	function handlePageChange(newPage) {
		console.log('New page: ', newPage);
		setFilters({
			...filters,
			pageIndex: newPage,
		});
	}

	const handleLike = async (id, userId, like, dislike) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		const ideaId = id;
		if (like === false && dislike === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
				{ ideaId, userId, number: 2 },
				config
			);
			like = true;
		} else if (like === false && dislike === true) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
				{ ideaId, userId, number: 1 },
				config
			);
			getPostList();
		}
	};

	const handleDisLike = async (id, userId, like, dislike) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		const ideaId = id;
		if (like === false && dislike === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
				{ ideaId, userId, number: -2 },
				config
			);
			getPostList();
		} else if (like === true && dislike === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
				{ ideaId, userId, number: -1 },
				config
			);
			getPostList();
		}
	};

	const handleView = async (id) => {
		await axios.put(`https://localhost:5001/api/Ideas/CountViewIdea?id=${id}`);
		await axios.get(`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`);
		navigate(`/admin/idea/${id}`);
	};

	const downloadFileHandler = async (filePath, filename) => {
		try {
			const url = `https://localhost:5001/api/Ideas/DownloadFile?fileName=${filePath}`;
			axios
				.get(url, {
					responseType: 'blob',
				})
				.then((res) => {
					fileDownload(res.data, filename);
				});
		} catch (error) {
			console.log('Failed to fetch department list', error.message);
		}
	};

	return (
		<div className="posts">
			<div className="flex items-center">
				<label className="ml-4 font-semibold leading-none">
					Popular ideas by
				</label>
				<select
					name="method"
					id="method"
					value={numberFilters}
					onChange={(e) => setNumberFilters(e.target.value)}
					className="ml-4 block bg-blue hover:bg-blue-dark py-2 px-4 rounded no-underline border-solid border-2 text-black"
				>
					<option value="0">Please filters</option>
					<option value="1">View</option>
					<option value="2">Vote</option>
				</select>
			</div>
			{postList.map((post) => (
				<div className="post ListUser">
					<div className="post__left">
						<CaretUpFilled
							style={{
								fontSize: '1.5rem',
								color: post.like === false ? 'black' : 'green',
							}}
							onClick={() => {
								handleLike(post.id, userId, post.like, post.dislike);
							}}
						/>
						<span>{post.upVote}</span>
						<CaretDownFilled
							style={{
								fontSize: '1.5rem',
								color: post.dislike === false ? 'black' : 'red',
							}}
							onClick={() => {
								handleDisLike(post.id, userId, post.like, post.dislike);
							}}
						/>
					</div>
					<div className="post__center"></div>
					<div className="post__right">
						<h1 className="post__info">
							Posted by{' '}
							{post.isAnonymously !== true ? post.userName : 'Anonymously'} at{' '}
							{post.createdAt.slice(0, 10)}
							<a
								style={{ marginLeft: 12, fontSize: '1rem' }}
								onClick={() => {
									navigate(`/staff/edit-idea/${post.id}`);
								}}
							>
								<span class="label label-danger">Edit idea</span>
							</a>
						</h1>
						<LinesEllipsis
							maxLine="10"
							ellipsis="..."
							basedOn="letters"
							text={post.content}
						></LinesEllipsis>
						<p className="post__info">
							{post.view} views | {post.likeAmount} like | {post.dislikeAmount}{' '}
							dislike{' '}
						</p>
						<button
							className="post__info"
							onClick={() => {
								downloadFileHandler(post.filePath, 'fileDownload.zip');
							}}
							download
						>
							Download files
						</button>
						<a
							style={{ marginLeft: 12, fontSize: '1rem' }}
							onClick={() => {
								handleView(post.id);
							}}
						>
							<span class="label label-danger">See more</span>
						</a>
					</div>
				</div>
			))}
			<Pagination pagination={pagination} onPageChange={handlePageChange} />
		</div>
	);
}

export default Posts;
