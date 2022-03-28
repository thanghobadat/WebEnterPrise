import React from 'react';
import { Link } from 'react-router-dom';
import Posts from '../idea/list-idea/Posts';

const ViewIdeas = () => {
	return (
		<>
			<div class="inline-block m-4">
				<Link
					className="block bg-blue hover:bg-blue-dark font-bold py-2 px-4 rounded no-underline border-solid border-2 text-black"
					to="/staff/create-ideas"
				>
					Create Ideas
				</Link>
			</div>

			<Posts />
		</>
	);
};

export default ViewIdeas;
