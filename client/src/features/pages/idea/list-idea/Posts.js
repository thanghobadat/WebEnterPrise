import React, {useEffect, useState} from 'react';
import "./Posts.css";
import PostItem from "./PostItem";
import queryString from 'query-string';
import axios from 'axios';
function Posts() {
  const [loading, setloading] = useState(true);
  const [postList, setPostList] = useState([]);
  const[filters] = useState({
    pageSize: 10,
    pageIndex: 1,
  });
  const paramsString = queryString.stringify(filters);
  useEffect(() => {
    getPostList();
  }, []);
  const getPostList = async () => {
    await axios.get(`https://localhost:5001/api/Ideas/GetIdeaPaging?${paramsString}`).then(
      res => {
        setloading(false);
        setPostList(res.data.resultObj.items);
      }
    );
  };

  return (
    <div className="posts">
      {postList.map((post) => (
        <PostItem post={post} />
      ))}
    </div>
  );
}

export default Posts;
