import React, { useEffect, useState } from 'react';
import './CategoryList.scss';
import 'font-awesome/css/font-awesome.min.css';
import queryString from 'query-string';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate, Link } from 'react-router-dom';
import { Button, Table, Col, Row, Modal } from 'antd';
import { useParams } from 'react-router-dom';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';
import Update from '../update-category/Update';

function CategoryList() {
	const [loading, setloading] = useState(true);
	const navigate = useNavigate();
	const { id } = useParams();
	const [categoryList, setCategoryList] = useState([]);
	const [filters] = useState({
		pageSize: 10,
		pageIndex: 1,
	});
	const paramsString = queryString.stringify(filters);
	useEffect(() => {
		getCategoryList();
	}, []);

	const getCategoryList = async () => {
		await axios
			.get(
				`https://localhost:5001/api/Categories/GetCategoryPaging?${paramsString}`
			)
			.then((res) => {
				setloading(false);
				setCategoryList(
					res.data.resultObj.items.map((row, index) => ({
						key: index,
						name: row.name,
						description: row.description,
						id: row.id,
					}))
				);
			});
	};

	const columns = [
		{
			title: 'Name',
			dataIndex: 'name',
			width: 300,
		},
		{
			title: 'Description',
			dataIndex: 'description',
			width: 300,
		},
		{
			key: '5',
			title: 'Actions',
			width: 300,
			render: (key) => {
				return (
					<>
						<EditOutlined
							onClick={() => {
								handleUpdate(key.id);
							}}
						/>
						<DeleteOutlined
							onClick={() => {
								onDeleteCategory(key.id);
							}}
							style={{ color: 'red', marginLeft: 12 }}
						/>
					</>
				);
			},
		},
	];

	const onDeleteCategory = (id) => {
		Modal.confirm({
			title: 'Are you sure, you want to delete this category record?',
			okText: 'Yes',
			okType: 'danger',
			onOk: () => {
				handleDelete(id);
			},
		});
	};

	const handleDelete = async (id) => {
		await axios.delete(
			`https://localhost:5001/api/Categories/DeleteCategory?id=${id}`
		);
		getCategoryList();
	};

	const handleUpdate = async (id) => {
		navigate(`/admin/update-category/${id}`);
	};

	return (
		<div className="container ListUser">
			<Row className="ListUser__title">
				<Col span={20}>
					<h2>Manager Category</h2>
				</Col>
				<Col span={4}>
					<Button type="primary" size="large">
						<Link to="/admin/create-category"> Create</Link>
					</Button>
				</Col>
			</Row>
			<div>
				{loading ? (
					'Loading'
				) : (
					<Table
						columns={columns}
						dataSource={categoryList}
						pagination={{ pageSize: 10 }}
						scroll={{ y: 240 }}
					/>
				)}
			</div>
		</div>
	);
}

export default CategoryList;
