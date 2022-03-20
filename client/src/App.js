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
<<<<<<< HEAD
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
=======
import Posts from './features/pages/idea/list-idea/Posts';
import CreateDepartment from './features/pages/department/create-department/CreateDepartment';
import UpdateDepartment from './features/pages/department/update-department/UpdateDepartment';
function App() {
	const { Header, Content, Footer } = Layout;
	return (
		<div className="App">
			<Layout>
				<Header style={{ position: 'fixed', zIndex: 1, width: '100%' }}>
					<div className="logo" />
					<Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
						<Menu.Item key="1">
							<Link to="#">Home</Link>
						</Menu.Item>
						<Menu.Item key="2">
							<Link to="/list-category">Category</Link>
						</Menu.Item>
						<Menu.Item key="3">
							<Link to="/list-department">Department</Link>
						</Menu.Item>
						<Menu.Item key="4">
							<Link to="account-user">AccountUser</Link>
						</Menu.Item>
					</Menu>
				</Header>
				<Content
					className="site-layout"
					style={{ padding: '0 50px', marginTop: 64 }}
				>
					<div
						className="site-layout-background"
						style={{ padding: 24, minHeight: 380 }}
					>
						<Routes>
							<Route path="/list-category" element={<CategoryList />}></Route>
							<Route
								path="/list-department"
								element={<DepartmentList />}
							></Route>
							<Route path="/create-category" element={<Create />}></Route>
							<Route path='/create-department' element={<CreateDepartment />}></Route>
							<Route path="/update-category/:id" element={<Update />}></Route>
							<Route path='/update-department:id' element={<UpdateDepartment/>}></Route>
							<Route path="/account-user" element={<ListUser />}></Route>
							<Route path="/list-idea" element={<Posts />}></Route>
							<Route
								path="/create-account-user"
								element={<FormCreate />}
							></Route>
						</Routes>
					</div>
				</Content>
				<Footer style={{ textAlign: 'center' }}>Footer</Footer>
			</Layout>
		</div>
	);
>>>>>>> c670e4c (Upload file)
}
export default App;
