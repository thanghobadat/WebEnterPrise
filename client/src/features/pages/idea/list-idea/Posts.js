import React, {useEffect, useState} from 'react';
import "./Posts.css";
import queryString from 'query-string';
import axios from 'axios';
import { CaretDownFilled, CaretUpFilled, MessageTwoTone, EyeTwoTone } from '@ant-design/icons';
import LinesEllipsis from 'react-lines-ellipsis';
import { useNavigate } from 'react-router-dom';
function Posts() {
  const [loading, setloading] = useState(true);
  const [postList, setPostList] = useState([]);
  const navigate = useNavigate();
  const [likeActive, setLikeActive] = useState(false);
  const [dislikeActive, setDislikeActive] = useState(false);
  
  useEffect(() => {
    getPostList();
  }, []);
  const getPostList = async () => {
    await axios.get(`https://localhost:5001/api/Ideas/GetAllIdea`).then(
      res => {
        setloading(false);
        setPostList(res.data.resultObj);
      }
    )
  }
  if (loading) {
    return <p>Data is loading...</p>;
  }
  const handleLike = async (id) => {
    if(likeActive === false){
      await axios.put(
        `https://localhost:5001/api/Ideas/LikeOrDislikeIdea?id=${id}&number=1`
      );
      setLikeActive(true);
      setDislikeActive(true);
    }else{
      return;
    }
    getPostList()
	}
  const handleDisLike = async (id) => {
		if(dislikeActive === false){
      await axios.put(
        `https://localhost:5001/api/Ideas/LikeOrDislikeIdea?id=${id}&number=-1`
      );
      setLikeActive(true);
      setDislikeActive(true);
    }else{
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
          <CaretUpFilled style={{fontSize:'1.5rem' }} onClick={() =>{handleLike(post.id)}}/>
          {/* <span>{post.upvote}</span> */}
          <CaretDownFilled style={{fontSize:'1.5rem' }} onClick={() =>{handleDisLike(post.id)}}/>
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
              | {post.like} like{" "} 
              | {post.dislike} dislike{" "}
          </p>
        </div>
      </div>
      ))}
    </div>
  );
}

export default Posts;
