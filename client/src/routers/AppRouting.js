import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Update from '../features/pages/category/update-category/Update';
import Create from '../features/pages/category/create-category/Create';
import DepartmentList from '../features/pages/department/list-department/DepartmentList';
import CategoryList from '../features/pages/category/list-category/CategoryList';
function AppRouting() {
  return (

    <Routes>
    <Route path="/list-department" element={<DepartmentList/>} />
    <Route path="/list-category" element={<CategoryList/>} />    
    <Route path="/update" element={<Update/>} />
    <Route path="/create" element={<Create/>} />
    </Routes>

  )
}

export default AppRouting