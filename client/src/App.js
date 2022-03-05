import React, { useEffect, useState } from 'react';
import './App.css';
import Header from './features/layout/header/Header';
import DepartmentList from './features/pages/department/list-department/DepartmentList';
import Pagination from './components/Pagination';
import queryString from 'query-string';
import DepartmentFiltersForm from './components/Departments/DepartmentFiltersForm/index';
import AppRouting from './routers/AppRouting';



function App(){
  
  return(
    
    <AppRouting>
    </AppRouting>

    
  )
}
export default App;
