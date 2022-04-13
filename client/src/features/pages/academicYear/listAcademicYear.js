import React, { useEffect, useState } from 'react';
import 'font-awesome/css/font-awesome.min.css';
import queryString from 'query-string';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Link } from 'react-router-dom';
import { Button, Table, Col, Row} from 'antd';
import moment from 'moment';
import '../department/list-department/DepartmentList.scss';
import './academicStyle.scss';


function ListAcademicYear() {
	const [loading, setloading] = useState(true);
	const [academicList, setAcademicList] = useState([]);
	const [filters] = useState({
		pageSize: 10,
		pageIndex: 1,
	});

	const paramsString = queryString.stringify(filters);
	useEffect(() => {
		getAcademicList();
	}, []);

	const getAcademicList = async () => {
		await axios
			.get(
				`https://localhost:5001/api/Academic/GetAcademicYearPaging?${paramsString}`
			)
			.then((res) => {
				setloading(false);
				setAcademicList(
					res.data.resultObj.items.map((row, index) => ({
						key: index,
						name: row.name,
						startDate: moment(row.startDate).format('LLLL'),
						endDate: moment(row.endDate).format('LLLL'),
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
			title: 'Start day',
			dataIndex: 'startDate',
			width: 300,
		},
		{
			title: 'End day',
			dataIndex: 'endDate',
			width: 300,
		},
	];

	return (
		<div className="container ListUser">
			<Row className="List__Academic">
				<Col span={20}>
					<h2>Manager academic year</h2>
				</Col>
				<Col span={4}>
					<Button type="primary" size="large">
						<Link to="/admin/create-academic">Create</Link>
					</Button>
				</Col>
			</Row>
			<div>
				{loading ? (
					'Loading'
				) : (
					<Table
						columns={columns}
						dataSource={academicList}
						pagination={{ pageSize: 10 }}
						scroll={{ y: 240 }}
					/>
				)}
			</div>
		</div>
	);
}

export default ListAcademicYear;
