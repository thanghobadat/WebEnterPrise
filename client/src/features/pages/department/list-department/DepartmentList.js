import React, {useEffect, useState} from 'react';
import './DepartmentList.scss';
import queryString from 'query-string';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';
import { Button,Table,Col,Row,Modal, Spin, Alert } from "antd";
import { EditOutlined, DeleteOutlined, UserAddOutlined } from "@ant-design/icons";
function DepartmentList() {
  const [loading, setloading] = useState(true);
  const navigate = useNavigate();
  const [departmentList, setDepartmentList] = useState([]);
  const[filters] = useState({
    pageSize: 10,
    pageIndex: 1,
  });
  const paramsString = queryString.stringify(filters);
  useEffect(() => {
    getDepartmentList();
  }, []);
  const [departmentSearchList, setDepartmentSearchList] = useState([]);

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
          setDepartmentSearchList(
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
		title: "Actions",
		width: 300,
		render: (key) => {
		  return (
			<>
        <UserAddOutlined
        onClick={() => {
          handleAssign(key.id);
				}}
        style={{ color: "green", marginLeft: 12,  fontSize:'200%' }}
         />
			  <EditOutlined
				onClick={() => {
					handleUpdate(key.id);
				}}
        style={{  marginLeft: 12, fontSize:'200%' }}
			  />
			  <DeleteOutlined
				onClick={() => {
					onDeleteDepartment(key.id);
				}}
				style={{ color: "red", marginLeft: 12, fontSize:'200%'}}
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
    navigate(`/admin/update-department/${id}`);
    
	}
	
  const handleDelete = async (id) => {
		await axios.delete(
			`https://localhost:5001/api/Departments/DeleteDepartment?id=${id}`
		)
    getDepartmentList()
	}

  const handleAssign = async (id) => {
		navigate(`/admin/list-assign-staff-qa/${id}`);
	};

  function handleSearch(keyword) {
    if (keyword) {
        const newData = departmentSearchList.filter(function (item) {
          const department = item.name ? item.name.toUpperCase() : "".toUpperCase() ;
          const textData = keyword.toUpperCase();
          return department.indexOf(textData) > -1;
        });
        setDepartmentList(newData)
        console.log(newData)
      } else {
        setDepartmentList(departmentSearchList);
      }
}

// function handleSearch(keyword) {
//   if (keyword) {
//       const newData = accountSearchList.filter(function (item) {
//         const account = item.userName ? item.userName.toUpperCase() : "".toUpperCase() ;
//         const textData = keyword.toUpperCase();
//         return account.indexOf(textData) > -1;
//       });
//       setAccountList(newData)
//     } else {
//       setAccountList(accountSearchList);
//     }
// }

  return (
    <div className="container ListUser">
      <Row className='ListUser__title'>
        <Col span={10}>
          <h2>Manager Department</h2>
        </Col>
        <Col span={10}>
          <input type="text" onChange={e =>handleSearch(e.target.value)}></input>
        </Col>
        <Col span={4}>
          <Button type='primary' size='large'>
            <Link to='/admin/create-department'> Create</Link>
          </Button>
        </Col>
      </Row>
      <div>
      {loading ? (
        <Spin tip="Loading...">
        <Alert
          message="Alert message title"
          description="Further details about the context of this alert."
          type="info"
        />
      </Spin>
      ) : (
        <Table
          columns={columns}
          dataSource={departmentList}
          pagination={{ pageSize: 3 }}
          scroll={{ y: 240 }}
        />
      )}
    </div>
    </div>
    
  );
}

export default DepartmentList;