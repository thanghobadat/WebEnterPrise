/** @format */

import React from 'react';
import './App.css';
import 'antd/dist/antd.css';
import { Route, Link, Routes, Navigate, Outlet } from 'react-router-dom';
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
function App() {
	return (
		<div className="App">
			<Routes>
				<Route path="/login" element={<Login />}></Route>
				<Route path="/" element={<Navigate replace to="/login" />} />
				<Route path="/admin" element={<Admin />}>
					<Route
						path="/admin"
						element={<Navigate replace to="/admin/account-user" />}
					/>
					<Route path="view-idea" element={<ViewIdeas />} />

					<Route path="list-category" element={<CategoryList />}></Route>
					<Route path="list-department" element={<DepartmentList />}></Route>
					<Route path="create-category" element={<Create />}></Route>
					<Route path="idea/:id" element={<Post/>}></Route>
					<Route
						path="create-department"
						element={<CreateDepartment />}
					></Route>
					<Route
						path="list-assign-staff-qa/:id"
						element={<ListStaffAndQA />}
					></Route>
					<Route path="update-category/:id" element={<Update />}></Route>
					<Route
						path="update-department/:id"
						element={<UpdateDepartment />}
					></Route>
					<Route path="create-account-user" element={<FormCreate />}></Route>
					<Route path="account-user" element={<ListUser />}></Route>
				</Route>
				<Route path="/staff" element={<User />}>
					<Route
						path="/staff"
						element={<Navigate replace to="/staff/list-category" />}
					/>
					<Route path="list-category" element={<CategoryList />}></Route>
					<Route path="create-category" element={<Create />}></Route>
					<Route path="list-department" element={<DepartmentList />}></Route>
					<Route path="create-ideas" element={<CreateIdeas />}></Route>
					<Route path="view-idea" element={<ViewIdeas />} />
					<Route
						path="create-department"
						element={<CreateDepartment />}
					></Route>
				</Route>
			</Routes>
		</div>
	);
}
function Admin() {
	return (
		<div>
			<div class="navbar navMenu">
				<Link to="view-idea">Home</Link>
				<Link to="list-category">Category</Link>
				<Link to="list-department">Department</Link>
				<Link to="account-user">AccountUser</Link>
				<Link className="right" to="/login" onClick={() => Logout()}>
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
			<div class="navbar navMenu">
				<Link to="view-idea">Home</Link>
				<Link to="list-category">Category</Link>
				<Link className="right" to="/login" onClick={() => Logout()}>
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
			<div class="navbar">
			<Link to="view-idea">Home</Link>
				<Link to="list-category">Category</Link>
				<Link to="list-department">Department</Link>
				<Link className="right" to="/login" onClick={() => Logout()}>
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
