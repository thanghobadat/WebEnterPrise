import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Posts from '../idea/list-idea/Posts';
const ViewIdeas = () => {
	let user = JSON.parse(localStorage.getItem('user'));
	return (
		<div>
			{user.role === 'staff' ? (
				<div class="inline-block m-4">
					<Link
						className="block bg-blue hover:bg-blue-dark font-bold py-2 px-4 rounded no-underline border-solid border-2 text-black"
						to="/admin/create-idea"
					>
						Create Ideas
					</Link>
				</div>
			) : (
				<div class="inline-block m-4">
				</div>
			)}
			<Posts />
		</div>
	);
};

export default ViewIdeas;
