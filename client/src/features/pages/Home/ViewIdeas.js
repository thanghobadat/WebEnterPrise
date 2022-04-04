import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Posts from '../idea/list-idea/Posts';
const ViewIdeas = () => {
	let user= JSON.parse(localStorage.getItem('user'));
	return (
		<div>
		{ user.role === 'admin' ? 
			<Link to='/admin/create-idea'>create idea</Link> :
			<Link to='/staff/create-idea'>create idea</Link>
		}
			<Posts/>
		</div>
	);
};

export default ViewIdeas;
