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
	const [userId, setUserId] = useState();
	const [checkfile, setCheckfile] = useState();
	let user;
	useEffect(() => {
		user = JSON.parse(localStorage.getItem('user'));
    	setUserId(user.id)
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
	const handleLike = async (id, userId, like, dislike ) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		const ideaId = id;
		if(like === false && dislike === false ){
		  await axios.put(
			`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
			{ ideaId, 
			  userId,
			  number: 2
			  },
				config,
		  );
		  like = true;
		}
		else if(like === false && dislike === true ){
		  await axios.put(
			`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
			{ ideaId, 
			  userId,
			  number: 1
			  },
				config,
		  );
		  getIdeaById();   
		} 
		}
	  const handleDisLike = async (id, userId, like, dislike ) => {
		const config = { headers: { 'Content-Type': 'application/json' } };
		const ideaId = id;
		if(like === false && dislike === false){
		  await axios.put(
			`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
			{ ideaId, 
			  userId,
			  number: -2
			  },
				config,
		  );
		  getIdeaById();
			  
		}
		else if(like === true && dislike === false){
		  await axios.put(
			`https://localhost:5001/api/Ideas/LikeOrDislikeIdea`,
			{ ideaId, 
			  userId,
			  number: -1
			  },
				config,
		  );
		  getIdeaById();
			  
		}
		}
	const formatDate = (createdAt) => {
		const options = { year: "numeric", month: "long", day: "numeric" }
		return new Date(createdAt).toLocaleDateString(undefined, options)
	  }
	  const getFile = async () => {
		await axios.get(`https://localhost:5001/api/Ideas/DownloadFile?fileName=${idea.filePath}`)
	  };
	return (
		<div className="posts">
			<div className="post User">
				<div className="post__left">
				<CaretUpFilled  
					style={{fontSize:'1.5rem', color: idea.like === false ? 'black': 'green' }} 
					onClick={() =>{handleLike(idea.id, userId, idea.like, idea.dislike)}}/>

					<CaretDownFilled
						style={{fontSize:'1.5rem', color: idea.dislike === false ? 'black': 'red'  }} 
						onClick={() =>{handleDisLike(idea.id, userId, idea.like, idea.dislike)}}
					/>
				</div>
				<div className="post__center"></div>
				<div className="post__right">
					<h1 className="post__info">
						Posted by{' '}
						{idea.isAnonymously !== true ? idea.userName : 'Anonymously'} at{' '}
						{formatDate(idea.createdAt)}{' '}
						{!idea.filePath  ? checkfile: 'with attachments'}
					</h1>
					
					<LinesEllipsis
						maxLine="10"
						ellipsis="..."
						basedOn="letters"
						text={idea.content}
					></LinesEllipsis>
					<div style={{visibility: !idea.filePath  ? 'hidden' : 'visible'}}>
						<a href={`https://localhost:5001/api/Ideas/DownloadFile?fileName=${idea.filePath}`} download>Click to download</a>
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
