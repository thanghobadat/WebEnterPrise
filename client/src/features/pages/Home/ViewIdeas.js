import React from 'react';
import { Link } from 'react-router-dom';
import Posts from '../idea/list-idea/Posts';
const ViewIdeas = () => {
	return (
		<>
			{' '}
			<Link to="/admin/create-ideas">ss</Link>
			<Posts/>
		</>
	);
};

export default ViewIdeas;
