/** @format */

import React from 'react';
import './App.css';
import 'antd/dist/antd.css';
import {
	BrowserRouter,
	Switch,
	Route,
	Link,
	Router,
	Routes,
} from 'react-router-dom';
import { Layout, Menu, Breadcrumb } from 'antd';
import ListUser from './features/pages/user/list-user/list-user';
import FormCreate from './features/pages/user/create-user/form-create';
import CategoryList from './features/pages/category/list-category/CategoryList';
import DepartmentList from './features/pages/department/list-department/DepartmentList';
import Create from './features/pages/category/create-category/Create';
import Update from './features/pages/category/update-category/Update';
import CreateDepartment from './features/pages/department/create-department/CreateDepartment';
import UpdateDepartment from './features/pages/department/update-department/UpdateDepartment';
import ListStaffAndQA from './features/pages/department/assign/ListStaffAndQA';
import CreateIdeas from './features/pages/ideas/CreateIdeas';
import ViewIdeas from './features/pages/ideas/ViewIdeas';

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
						<Menu.Item key="5">
							<Link to="/viewIdeas">Ideas</Link>
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
							<Route path="/create-category" element={<Create />}></Route>
							<Route path="/update-category/:id" element={<Update />}></Route>
							<Route
								path="/list-department"
								element={<DepartmentList />}
							></Route>
							<Route
								path="/create-department"
								element={<CreateDepartment />}
							></Route>
							<Route
								path="/update-department/:id"
								element={<UpdateDepartment />}
							></Route>
							<Route
								path="/list-assign-staff-qa/:id"
								element={<ListStaffAndQA />}
							/>

							<Route path="/account-user" element={<ListUser />}></Route>
							<Route
								path="/create-account-user"
								element={<FormCreate />}
							></Route>

							<Route path="/viewIdeas" element={<ViewIdeas />} />
							<Route path="/createIdeas" element={<CreateIdeas />} />
						</Routes>
					</div>
				</Content>
				<Footer style={{ textAlign: 'center' }}>Footer</Footer>
			</Layout>
		</div>
	);
}

export default App;
