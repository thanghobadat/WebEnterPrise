import React from 'react';
import Button from 'react-bootstrap/Button';
import { useNavigate } from 'react-router-dom';

const ViewIdeas = () => {
	const navigate = useNavigate();

	function handleCreate() {
		navigate('/createIdeas');
	}
    
	return (
		<div>
			ViewIdeas
			<Button onClick={() => handleCreate()} variant="primary">
				Create category
			</Button>
		</div>
	);
};

export default ViewIdeas;
