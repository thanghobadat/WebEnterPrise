import React, {useEffect, useState} from 'react';
import "./Posts.css";
import queryString from 'query-string';
import axios from 'axios';
import { CaretDownFilled, CaretUpFilled, MessageTwoTone, EyeTwoTone } from '@ant-design/icons';
import LinesEllipsis from 'react-lines-ellipsis';
import { Link, useNavigate } from 'react-router-dom';
function Posts() {
  const [loading, setloading] = useState(true);
  const [postList, setPostList] = useState([]);
  const navigate = useNavigate();
  const [userId, setUserId] = useState();
  let user;
  useEffect(() => {
    user = JSON.parse(localStorage.getItem('user'));
    setUserId(user.id)
    getPostList();
  }, []);
  const getPostList = async () => {
    await axios.get(`https://localhost:5001/api/Ideas/GetAllIdeaUser?userId=${user.id}`).then(
      res => {
        setloading(false);
        setPostList(res.data.resultObj);
      }
    )
  }
  
  if (loading) {
    return <p>Data is loading...</p>;
  }
  const handleLike = async (id, userId, like, dislike ) => {
    const config = { headers: { 'Content-Type': 'application/json' } };
    const ideaId = id;
    if(like === false && dislike === false){
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
    else{
      return;
    }
    getPostList()
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
          dislike = true;
    }
    else{
      return;
    }
    getPostList()
	}
  
  const handleView = async (id) => {
    await axios.put(
			`https://localhost:5001/api/Ideas/CountViewIdea?id=${id}`
		)
		await axios.get(`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`)
    navigate(`/admin/idea/${id}`);
	}
  return (
    <div className="posts">
      {postList.map((post) => (
        <div className="post ListUser">
        <div className="post__left">
          <CaretUpFilled  style={{fontSize:'1.5rem', color: post.like === false ? 'color': 'green' }} onClick={() =>{handleLike(post.id, userId, post.like, post.dislike)}}/>
          {/* <span>{post.upvote}</span> */}
          <CaretDownFilled style={{fontSize:'1.5rem', color: post.dislike === false ? 'color': 'red'  }} onClick={() =>{handleDisLike(post.id, userId, post.like, post.dislike)}}/>
          
        </div>
        <div className="post__center">
          
        </div>
        <div className="post__right">
          
          <h1 className="post__info">
            Posted by {post.isAnonymously !== true ? post.userName : 'Anonymously'} {" "} at {post.createdAt.slice(0,10)}
            
            <a style={{ marginLeft: 12, fontSize:'1rem' }} onClick={() =>{handleView(post.id)}}><span class="label label-danger">More</span></a>
          </h1>
          <LinesEllipsis
            maxLine='10'
            ellipsis='...'
            basedOn='letters'
            text={post.content}
          >
          </LinesEllipsis> 
          <p className="post__info">
            
              {post.view} views{" "}
              | {post.likeAmount} like{" "} 
              | {post.dislikeAmount} dislike{" "}
          </p>
        </div>
      </div>
      ))}
      
    </div>
  );
}

export default Posts;
