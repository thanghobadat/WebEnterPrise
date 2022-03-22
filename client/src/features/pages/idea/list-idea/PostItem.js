import React from "react";
import "./PostItem.css";
import { Link } from "react-router-dom";
import {CaretUpOutlined, CaretDownOutlined} from "@ant-design/icons";
function PostItem(props) {
  const { post } = props;
  const title = post.title
//   const link = title.toLowerCase().replaceAll(" ", "-")
  
  return (
    <div className="post">
      <div className="post__left">
        <CaretUpOutlined />
        <span>{post.upvote}</span>
        <CaretDownOutlined />
      </div>
      <div className="post__center">
        
      </div>
      <div className="post__right">
        <div>
        {post.content}
        </div>
        <span className="post__info">
          submitted at {post.createdAt.slice(0,10)} by{" "}
          {post.userId}
          
        </span>
        <p className="post__info">
            {post.comments_count} comments{" "}
            | {post.view} views{" "}
            | {post.like} like{" "} 
            | {post.dislike} dislike{" "}
        </p>
      </div>
    </div>
  );
}

export default PostItem;