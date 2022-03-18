import React, {useEffect, useState} from 'react';
import './DepartmentList.scss';
import 'font-awesome/css/font-awesome.min.css';

import queryString from 'query-string';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useNavigate, Link } from 'react-router-dom';
import { Button,Table,Col,Row,Modal } from "antd";
import { useParams } from 'react-router-dom';
import { EditOutlined, DeleteOutlined } from "@ant-design/icons";
function DepartmentList() {
  const [loading, setloading] = useState(true);
  const navigate = useNavigate();
  const { id } = useParams();
  const [departmentList, setDepartmentList] = useState([]);
  const[filters] = useState({
    pageSize: 10,
    pageIndex: 1,
  });
  const paramsString = queryString.stringify(filters);
  useEffect(() => {
    getDepartmentList();
  }, []);

    const getDepartmentList = async () => {
      await axios.get(`https://localhost:5001/api/Departments/GetDepartmentPaging?${paramsString}`).then(
        res => {
          setloading(false);
          setDepartmentList(
            res.data.resultObj.items.map((row, index) => ({
            key: index,
            name: row.name,
            description: row.description,
            id: row.id,
            }))
          );
        }
      );
    };
  
    const columns = [
      {
        title: "Name",
        dataIndex: "name",
        width: 300
      },
      {
        title: "Description",
        dataIndex: "description",
        width: 300
      },
      {
		key: "5",
		title: "Actions",
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
					onDeleteDepartment(key.id);
				}}
				style={{ color: "red", marginLeft: 12 }}
			  />
			</>
		  );
		}
	}
];

	const onDeleteDepartment = (id) => {
		Modal.confirm({
		  title: "Are you sure, you want to delete this department record?",
		  okText: "Yes",
		  okType: "danger",
		  onOk: () => {
			handleDelete(id);
		  },
		});
	  };  
  const handleUpdate = async (id) => {
		const  res  = await axios.get(`https://localhost:5001/api/Departments/GetDepartmentById?id=${id}`)
    console.log(res);
    navigate(`/admin/update-department?id=${id}`);
	}
	
  const handleDelete = async (id) => {
		await axios.delete(
			`https://localhost:5001/api/Departments/DeleteDepartment?id=${id}`
		)
    navigate('/admin/list-department');
	}

  function handleCreate(){
    navigate('/admin/create-department')
  }

  return (
    <div className="container ListUser">
      <Row className='ListUser__title'>
        <Col span={20}>
          <h2>Manager Department</h2>
        </Col>
        <Col span={4}>
          <Button type='primary' size='large'>
            <Link to='/create-department'> Add</Link>
          </Button>
        </Col>
      </Row>
      <div>
      {loading ? (
        "Loading"
      ) : (
        <Table
          columns={columns}
          dataSource={departmentList}
          pagination={{ pageSize: 10 }}
          scroll={{ y: 240 }}
        />
      )}
    </div>
    </div>
    
  );
}

export default DepartmentList;