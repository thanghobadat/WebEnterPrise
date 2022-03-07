import React, {useEffect, useState} from 'react';
import './CategoryList.scss';
import 'font-awesome/css/font-awesome.min.css';
import { useNavigate } from 'react-router-dom';
import queryString from 'query-string';
import Pagination from '../../../../components/Pagination';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';

function CategoryList() {
  const navigate = useNavigate();
  const [categoryList, setCategoryList] = useState([]);
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
    async function getCategoryList(){
      try{
        const paramsString = queryString.stringify(filters);
        const res = await axios.get(`${global.config.var_env}/api/Categories/GetCategoryPaging?${paramsString}`);
        console.log(res);
        const data = res.data.resultObj;
        setCategoryList(res.data.resultObj.items);
        setPagination({
          pageIndex: data.pageIndex,
          pageSize: data.pageSize,
          totalRecords : data.totalRecords,
        });
      }
      catch(error){
        console.log('Failed to fetch category list', error.message);
      }
      }
    
    // console.log('Category list effect');
    getCategoryList();
  }, [filters]);

  function handlePageChange(newPage){
    console.log('New page: ', newPage);
    setFilters({
      ...filters,
      pageIndex: newPage,
    })
  }

  const handleUpdate = async (id) => {
		// const  res  = await axios.get(`${global.config.var_env}/api/Categories/GetById?categoryId=${id}`)
    // console.log(res);
    navigate(`/update-category?id=:id`);
	};

  function handleCreate(){
    navigate('/create-category')
  }
  
  return (
    <div className="users-container">
      <div className='title text-center'>
        Manager Category
        <Button  onClick={() => handleCreate()} variant="primary">Add</Button>
        </div>
      <div className='users-table mt-3 mx-1'></div>
    <table id="customers">
      <tr>
        <th>Name</th>
        <th>Description</th>
        <th>Actions</th>
      </tr>
      {categoryList.map(category => {
        return(
          <tr key={category.id}>
            <td>{category.name}</td>
            <td>{category.description}</td>
            <td>
              <Button className='btn-edit' onClick={() => handleUpdate(category.id)} variant="warning">Edit</Button>
              
              <Button className='btn-delete' variant="danger">Delete</Button>
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

export default CategoryList;