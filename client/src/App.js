/** @format */

import React from 'react';
import './App.css';
import 'antd/dist/antd.css';
import {
  BrowserRouter,
  Switch,
  Route,
  Link,
  Routes,
  Navigate,
  Outlet,
} from 'react-router-dom';
import ListUser from './features/pages/user/list-user/list-user';
import FormCreate from './features/pages/user/create-user/form-create';
import CategoryList from './features/pages/category/list-category/CategoryList';
import DepartmentList from './features/pages/department/list-department/DepartmentList';
import Create from './features/pages/category/create-category/Create';
import Update from './features/pages/category/update-category/Update';
import Login from './features/pages/auth/login/Login';
function App() {
  return (
    <div className='App'>
      <Routes>
        <Route path='/login' element={<Login />}></Route>
        <Route path='/' element={<Navigate replace to='/admin' />} />
        <Route path='/admin' element={<Admin />}>
          <Route path='list-category' element={<CategoryList />}></Route>
          <Route path='list-department' element={<DepartmentList />}></Route>
          <Route path='create-category' element={<Create />}></Route>
          <Route path='update-category/:id' element={<Update />}></Route>
          <Route path='create-account-user' element={<FormCreate />}></Route>
          <Route path='account-user' element={<ListUser />}></Route>
        </Route>
        <Route path='/user' element={<User />}></Route>
      </Routes>
    </div>
  );
}
function Admin() {
  return (
    <div>
      <div class='navbar navMenu'>
        <Link to='#'>Home</Link>
        <Link to='list-category'>Category</Link>
        <Link to='list-department'>Department</Link>
        <Link to='account-user'>AccountUser</Link>
        <Link className='right' to='/login'>
          Log out
        </Link>
      </div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
function User() {
  return (
    <div>
      <div class='navbar'>
        <Link to='#'>Home</Link>
        <Link to='/list-category'>Category</Link>
        <Link to='/list-department'>Department</Link>
      </div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
export default App;
