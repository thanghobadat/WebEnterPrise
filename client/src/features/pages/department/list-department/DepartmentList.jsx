import React, {useEffect, useState} from 'react';
import './DepartmentList.scss';
import 'font-awesome/css/font-awesome.min.css';
import { useNavigate } from 'react-router-dom';
import queryString from 'query-string';
import Pagination from '../../../../components/Pagination';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';

function DepartmentList() {
  const navigate = useNavigate();
  const [departmentList, setDepartmentList] = useState([]);
  const [pagination, setPagination] = useState({
    pageIndex: 1,
    pageSize: 4,
    totalRecords: 4,
  })
  const[filters, setFilters] = useState({
    pageSize: 4,
    pageIndex: 1,
  });

  useEffect(() =>{
    async function getDepartmentList(){
      try{
        const paramsString = queryString.stringify(filters);
        const res = await axios.get(`https://localhost:5001/api/Departments/GetDepartmentPaging?${paramsString}`);
        console.log(res);
        const data = res.data.resultObj;
        setDepartmentList(res.data.resultObj.items);
        setPagination({
          pageIndex: data.pageIndex,
          pageSize: data.pageSize,
          totalRecords : data.totalRecords,
        })
      }
      catch(error){
        console.log('Failed to fetch department list', error.message);
      }
    }
    console.log('Department list effect');
    getDepartmentList();
  }, [filters]);

  function handlePageChange(newPage){
    console.log('New page: ', newPage);
    setFilters({
      ...filters,
      pageIndex: newPage,
    })
  }

  const handleUpdate = async (id) => {
		const  res  = await axios.get(`https://localhost:5001/api/Departments/GetDepartmentById?id=${id}`)
    console.log(res);
    navigate(`/admin/update-department?id=${id}`);
	}

  const handleDelete = async (id) => {
    
		const  res  = await axios.delete(
			`https://localhost:5001/api/Departments/DeleteDepartment?id=${id}`
			
		)
    console.log(res);
    navigate('/admin/list-department');
	}

  function handleCreate(){
    navigate('/admin/create-department')
  }

  return (
    <div className="users-container">
      <div className='title text-center'>
        Manager Department
        <Button  onClick={() => handleCreate()} variant="primary">Add</Button>
        </div>
      <div className='users-table mt-3 mx-1'></div>
    <table id="customers">
      <tr>
        <th>Name</th>
        <th>Description</th>
        <th>Actions</th>
      </tr>
      {departmentList.map(department => {
        return(
          <tr key={department.id}>
            <td>{department.name}</td>
            <td>{department.description}</td>
            <td>
              <Button onClick={() => handleUpdate(department.id)} variant="warning">Edit</Button>
              
              <Button onClick={() => handleDelete(department.id)} onPageChange={handlePageChange} variant="danger">Delete</Button>
            </td>
          </tr>
        )
      })
      }

    </table>
      <Pagination
        pagination={pagination}
        onPageChange={handlePageChange}
      />
    </div>
    
  );
}

export default DepartmentList;