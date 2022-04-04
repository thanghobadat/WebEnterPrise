import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Posts from '../idea/list-idea/Posts';
const ViewIdeas = () => {
	let user= JSON.parse(localStorage.getItem('user'));
	return (
		<div>
		{ user.role === 'admin' ? 
			<Link style={{marginLeft: '45%', fontSize: '1.5rem'}} to='/admin/create-idea'>Create Idea</Link> :
			<Link style={{marginLeft: '45%', fontSize: '1.5rem'}} to='/staff/create-idea'>Create Idea</Link>
		}
			<Posts/>
		</div>
	);
};

export default ViewIdeas;
