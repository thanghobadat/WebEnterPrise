import React, { useEffect, useState } from 'react';
import 'font-awesome/css/font-awesome.min.css';
import queryString from 'query-string';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate, Link } from 'react-router-dom';
import { Button, Table, Col, Row, Modal, message } from 'antd';
import { useParams } from 'react-router-dom';

function AssignCategorytoIdea() {
	const [loading, setloading] = useState(true);
	const navigate = useNavigate();
	const [ideaId, setIdeaId] = useState();
	const [arrayCategoryId, setArrayCategoryId] = useState([]);
	const { id } = useParams();
	const [categoryList, setCategoryList] = useState([]);
	const [filters] = useState({
		pageSize: 10,
		pageIndex: 1,
	});
	const paramsString = queryString.stringify(filters);
	useEffect(() => {
		getCategoryList();
		getIdeaById();
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
						cateId: row.id,
					}))
				);
			});
	};

	const getIdeaById = async () => {
		await axios
			.get(`https://localhost:5001/api/Ideas/GetIdeaById?id=${id}`)
			.then((res) => {
				setloading(false);
				setIdeaId(res.data.resultObj.id);
			});
	};

	const assignCategorytoIdea = async (cateId) => {
		const categoryId = cateId;
		await axios.put(
			`https://localhost:5001/api/Ideas/AddCategoryToIdea`,
			{ ideaId, categoryId }
		)
		message.success('Assign category to idea success !!');
		navigate(`/admin/idea/${id}`)

	}
	const columns = [
		{
			title: 'Category',
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
			title: 'Action',
			width: 300,
			render: (key) => {
				return (
					<>
						<Button
							size='large'
							className='ant-btn-warning'
							onClick={() => assignCategorytoIdea(key.cateId)}>
							Assign
						</Button>
					</>
				);
			},
		},
	];


	return (
		<div className="container ListUser">
			<Row className="ListUser__title">
				<Col span={20}>
					<h2>Assign category to idea</h2>
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

export default AssignCategorytoIdea;
