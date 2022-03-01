import React, { useEffect, useState } from 'react';
import './App.css';
import Header from './features/layout/header/Header';
//import axios from 'axios';
//import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import DepartmentList from './components/Departments/DepartmentList';
import Pagination from './components/Departments/Pagination';
//import { Table } from "antd";

// function App() {


//   useEffect(() => {
//     var axios = require('axios');
//     var qs = require('qs');
//     var data = qs.stringify({
//       'id': '6' 
//     });
//     var config = {
//       method: 'get',
//       url: 'http://192.168.0.112:5001/api/Departments/GetDepartmentPaging?PageIndex=1&PageSize=2',
//       headers: { 
//         'Content-Type': 'application/x-www-form-urlencoded'
//       },
//       data : data
//   };

//   axios(config)
//     .then(function (response) {
//       console.log(JSON.stringify(response.data));
//     })
//     .catch(function (error) {
//       console.log(error);
//   });

//   })

//   const [allDepartments, setAllDepartments] = useState([]);
//   useEffect(() =>{
//     async function getData(){
//       const res = await axios.get('http://192.168.10.28:5001/api/Departments/GetDepartmentPaging?PageIndex=1&PageSize=2');
//       return res;
//     }
//     getData().then((res) => setAllDepartments(res.data));
//     getData().then((res) => console.log(res.data));
//     getData().catch((err) => console.log(err));
//   });




//   return (
//     // <Router>
//     //   <div className='page-container'>
//     //     <Routes>
//     //       <Route path= '/' element={<DepartmentsPage allDepartments={allDepartments}/>}/>
//     //     </Routes>
//     //   </div>
//     // </Router>
    
    
//   );
// }

// export default App;

function App(){
  const [departmentList, setDepartmentList] = useState([]);
  const [pagination, setPagination] = useState({
    pageIndex: 1,
    pageSize: 1,
    totalRecords: 3,
  })

  useEffect(() =>{
    async function fetchDepartmentList(){
      try{
        const requestUrl = 'http://192.168.98.192:5001/api/Departments/GetDepartmentPaging?PageIndex=1&PageSize=3';
        //http://js-post-api.herokuapp.com/api/posts?_limit=10&_page=1
        //http://192.168.10.28:5001/api/Departments/GetDepartmentPaging?PageIndex=1&PageSize=2
        const response = await fetch(requestUrl);
        const responseJSON = await response.json();
        console.log({responseJSON});
        const {resultObj} = responseJSON;
        setDepartmentList(resultObj.items);
      }
      catch(error){
        console.log('Failed to fetch department list', error.message);
      }
      }
    
    console.log('Department list effect');
    fetchDepartmentList();
  }, []);

  function handlePageChange(newPage){
    console.log('New page:', newPage )
  }
  return(
    <div className='app'>
      
      <DepartmentList posts={departmentList}/>
      {/* <Pagination
        pagination={pagination}
        onPageChange={handlePageChange}
      /> */}
    </div>
  )
}
export default App;
