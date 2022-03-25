// import React, {useEffect} from "react";
// import "./PostItem.css";
// import { Link } from "react-router-dom";
// import { CaretUpFilled, CaretDownFilled } from "@ant-design/icons";
// import LinesEllipsis from 'react-lines-ellipsis';
// import axios from "axios";
// import Posts from "./Posts";
// function PostItem(props) {
//   const { post } = props;
//   const handleLike = async (id) => {
// 		await axios.put(
// 			`https://localhost:5001/api/Ideas/LikeOrDislikeIdea?id=${id}&number=1`
// 		)
// 	}
//   return (
//     <div className="post ListUser">
//       <div className="post__left">
//         <CaretUpFilled onClick={() =>{handleLike(post.id)}}/>
//         <span>{post.upvote}</span>
//         <CaretDownFilled />
//       </div>
//       <div className="post__center">
        
//       </div>
//       <div className="post__right">
        
//         <h1 className="post__info">
//           submitted at {post.createdAt.slice(0,10)} by{" "}
//           {post.isAnonymously !== true ? post.userId : 'Anonymously'}
//           <a style={{  marginLeft: 12, fontSize:'1.5rem' }} href="/"><span class="label label-danger">Read full</span></a>
//         </h1>
//         <LinesEllipsis
//           maxLine='3'
//           ellipsis='...'
//           basedOn='letters'
//           text={post.content}
//         >
//         </LinesEllipsis> 
//         <p className="post__info">
//             {post.comments_count} comments{" "}
//             | {post.view} views{" "}
//             | {post.like} like{" "} 
//             | {post.dislike} dislike{" "}
//         </p>
//       </div>
//     </div>
//   );
// }

// export default PostItem;