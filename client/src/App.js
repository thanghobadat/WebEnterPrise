/** @format */

import React from 'react';
import './App.css';
import 'antd/dist/antd.css';
import {
  Route,
  Link,
  Routes,
  Navigate,
  Outlet,
  useLocation,
} from 'react-router-dom';
import ListUser from './features/pages/user/list-user/list-user';
import FormCreate from './features/pages/user/create-user/form-create';
import CategoryList from './features/pages/category/list-category/CategoryList';
import DepartmentList from './features/pages/department/list-department/DepartmentList';
import Create from './features/pages/category/create-category/Create';
import CreateDepartment from './features/pages/department/create-department/CreateDepartment';
import Update from './features/pages/category/update-category/Update';
import UpdateDepartment from './features/pages/department/update-department/UpdateDepartment';
import Login from './features/pages/auth/login/Login';
import ListStaffAndQA from './features/pages/department/assign/ListStaffAndQA';
import ViewIdeas from './features/pages/Home/ViewIdeas';
import CreateIdeas from './features/pages/Home/CreateIdeas';
import Post from './features/pages/idea/view-idea/Post';
import ListAcademicYear from './features/pages/academicYear/listAcademicYear';
import CreateAcademicYear from './features/pages/academicYear/CreateAcademicYear';
import EditIdea from './features/pages/idea/edit-idea/EditIdea';
import Analyze from './features/pages/analyze/analyze';
import AssignCategorytoIdea from './features/pages/idea/assign-category-to-idea/AssignCategorytoIdea';
import NotFound from './features/pages/notfound/NotFound';
function App() {
  const user = JSON.parse(localStorage.getItem('user'));
  let location = useLocation();
  return (
    <div className='App'>
      <Routes>
        <Route path='*' element={<NotFound />} />
        <Route path='/login' element={<Login />}></Route>
        <Route path='/' element={<Navigate replace to='/login' />} />
        {user?.role === 'admin' && (
          <Route path='/admin' element={<Admin />}>
            <Route
              path='/admin'
              element={
                <Navigate
                  state={{ from: location }}
                  replace
                  to='/admin/view-idea'
                />
              }
            />
            <Route path='view-idea' element={<ViewIdeas />} />
            <Route path='list-department' element={<DepartmentList />}></Route>
            <Route path='idea/:id' element={<Post />}></Route>
            <Route
              path='create-department'
              element={<CreateDepartment />}></Route>
            <Route
              path='list-assign-staff-qa/:id'
              element={<ListStaffAndQA />}></Route>
            <Route
              path='update-department/:id'
              element={<UpdateDepartment />}></Route>
            <Route path='create-account-user' element={<FormCreate />}></Route>
            <Route path='account-user' element={<ListUser />}></Route>
            <Route path='list-academic' element={<ListAcademicYear />}></Route>
            <Route
              path='create-academic'
              element={<CreateAcademicYear />}></Route>
          </Route>
        )}
        {user?.role === 'staff' && (
          <Route path='/staff' element={<Staff />}>
            <Route
              path='/staff'
              element={
                <Navigate
                  state={{ from: location }}
                  replace
                  to='/staff/view-idea'
                />
              }
            />
            <Route path='view-idea' element={<ViewIdeas />} />
            <Route path='create-idea' element={<CreateIdeas />} />
            <Route path='idea/:id' element={<Post />}></Route>
            <Route path='edit-idea/:id' element={<EditIdea />} />
          </Route>
        )}
        {user?.role === 'QACoordinator' && (
          <Route path='/QACoordinator' element={<QACoordinator />}>
            <Route
              path='/QACoordinator'
              element={
                <Navigate
                  state={{ from: location }}
                  replace
                  to='/QACoordinator/view-idea'
                />
              }
            />
            <Route
              path='assign-category-to-idea/:id'
              element={<AssignCategorytoIdea />}></Route>
            <Route path='view-idea' element={<ViewIdeas />} />
            <Route path='idea/:id' element={<Post />}></Route>
            <Route path='analyze' element={<Analyze />}></Route>
          </Route>
        )}
        {user?.role === 'QAManager' && (
          <Route path='/QAManager' element={<QAManager />}>
            <Route
              path='/QAManager'
              element={
                <Navigate
                  state={{ from: location }}
                  replace
                  to='/QAManager/view-idea'
                />
              }
						/>
						<Route path="list-category" element={<CategoryList />}></Route>
            <Route
              path='assign-category-to-idea/:id'
              element={<AssignCategorytoIdea />}></Route>
            <Route path='view-idea' element={<ViewIdeas />} />
            <Route path='idea/:id' element={<Post />}></Route>
            <Route path='analyze' element={<Analyze />}></Route>
            <Route path='create-category' element={<Create />}></Route>
            <Route
              path='assign-category-to-idea/:id'
              element={<AssignCategorytoIdea />}></Route>
						<Route path='update-category/:id' element={<Update />}></Route>
						<Route path="analyze" element={<Analyze />}></Route>
          </Route>
        )}
      </Routes>
    </div>
  );
}
function Admin() {
  return (
    <div>
      <div class='navbar navMenu'>
        <Link to='view-idea'>Home</Link>
        <Link to='list-academic'>Academic year</Link>
        <Link to='list-department'>Department</Link>
        <Link to='account-user'>AccountUser</Link>
        <Link className='right' to='/login' onClick={() => Logout()}>
          Log out
        </Link>
      </div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
function QACoordinator() {
  return (
    <div>
      <div class='navbar navMenu'>
				<Link to='view-idea'>Home</Link>
				<Link to="analyze">Analyze</Link>
				
        <Link className='right' to='/login' onClick={() => Logout()}>
          Log out
        </Link>
      </div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
function QAManager() {
  return (
    <div>
      <div class='navbar navMenu'>
				<Link to='view-idea'>Home</Link>
				<Link to="list-category">Category</Link>
				<Link to="analyze">Analyze</Link>
        <Link className='right' to='/login' onClick={() => Logout()}>
          Log out
        </Link>
      </div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
function Staff() {
  return (
    <div>
      <div class='navbar'>
        <Link to='view-idea'>Home</Link>
        <Link className='right' to='/login' onClick={() => Logout()}>
          Log out
        </Link>
      </div>
      <main>
        <Outlet />
      </main>
    </div>
  );
}
const Logout = () => {
  localStorage.removeItem('user');
};
export default App;
