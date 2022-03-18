import React, { useEffect, useState } from 'react';
import './CategoryList.scss';
import 'font-awesome/css/font-awesome.min.css';
import { useNavigate } from 'react-router-dom';
import queryString from 'query-string';
import Pagination from '../../../../components/Pagination';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import { message } from 'antd';

function CategoryList() {
	const navigate = useNavigate();
	const [categoryList, setCategoryList] = useState([]);
	const [deleteSucceed, setDeleteSucceed] = useState('');
	const [pagination, setPagination] = useState({
		pageIndex: 1,
		pageSize: 4,
		totalRecords: 4,
	});
	const [filters, setFilters] = useState({
		pageSize: 4,
		pageIndex: 1,
	});

	useEffect(() => {
		async function getCategoryList() {
			try {
				const paramsString = queryString.stringify(filters);
				const res = await axios.get(
					`https://localhost:5001/api/Categories/GetCategoryPaging?${paramsString}`
				);
				const data = res.data.resultObj;
				setCategoryList(res.data.resultObj.items);
				setPagination({
					pageIndex: data.pageIndex,
					pageSize: data.pageSize,
					totalRecords: data.totalRecords,
				});
			} catch (error) {
				console.log('Failed to fetch category list', error.message);
			}
		}

		getCategoryList();
	}, [filters, deleteSucceed]);

	function handlePageChange(newPage) {
		setFilters({
			...filters,
			pageIndex: newPage,
		});
	}

	const handleUpdate = async (id) => {
		navigate(`/update-category/${id}`);
	};

	function handleCreate() {
		navigate('/create-category');
	}

	const handleDelete = async (id) => {
		const res = await axios.delete(
			`https://localhost:5001/api/Categories/DeleteCategory?id=${id}`
		);
		setDeleteSucceed(res.data.isSuccessed);
		message.success('Delete category success !!');
	};

	return (
		<div className="users-container">
			<div className="title text-center">Manager Category</div>

			<div className="users-table mt-3 mb-3">
				<Button onClick={() => handleCreate()} variant="primary">
					Create category
				</Button>
			</div>
			<table id="customers">
				<tr>
					<th>Name</th>
					<th>Description</th>
					<th>Actions</th>
				</tr>
				{categoryList.map((category) => {
					return (
						<tr key={category.id}>
							<td>{category.name}</td>
							<td>{category.description}</td>
							<td>
								<Button
									className="btn-edit btn_update"
									onClick={() => handleUpdate(category.id)}
									variant="warning"
								>
									Update
								</Button>

								<Button
									className="btn-delete"
									variant="danger"
									onClick={() => handleDelete(category.id)}
								>
									Delete
								</Button>
							</td>
						</tr>
					);
				})}
			</table>
			<Pagination pagination={pagination} onPageChange={handlePageChange} />
		</div>
	);
}

export default CategoryList;
