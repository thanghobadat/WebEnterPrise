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
function Post() {
	const { id } = useParams();
	const [loading, setloading] = useState(true);
	const [idea, setIdea] = useState([]);
	const [likeActive, setLikeActive] = useState(false);
	const [dislikeActive, setDislikeActive] = useState(false);

	useEffect(() => {
		getIdeaById();
	}, []);
	const getIdeaById = async () => {
		await axios
			.get(`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`)
			.then((res) => {
				setloading(false);
				setIdea(res.data.resultObj);
				console.log(res.data.resultObj);
			});
	};
	const handleLike = async (id) => {
		if (likeActive === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea?id=${id}&number=1`
			);
			setLikeActive(true);
			setDislikeActive(true);
		} else {
			return;
		}
		getIdeaById();
	};
	const handleDisLike = async (id) => {
		if (dislikeActive === false) {
			await axios.put(
				`https://localhost:5001/api/Ideas/LikeOrDislikeIdea?id=${id}&number=-1`
			);
			setLikeActive(true);
			setDislikeActive(true);
		} else {
			return;
		}
		getIdeaById();
	};

	return (
		<div className="posts">
			<div className="post User">
				<div className="post__left">
					<CaretUpFilled
						style={{ fontSize: '1.5rem' }}
						onClick={() => {
							handleLike(idea.id);
						}}
					/>

					<CaretDownFilled
						style={{ fontSize: '1.5rem' }}
						onClick={() => {
							handleDisLike(idea.id);
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
						<img src={idea.filePath} />
					</div>
					<p className="post__info">
						<MessageTwoTone style={{ marginTop: 10, fontSize: '1.5rem' }} />
						{idea.comments_count} Comments | {idea.view} views | {idea.like}{' '}
						like | {idea.dislike} dislike{' '}
					</p>
				</div>
			</div>
		</div>
	);
}

export default Post;
