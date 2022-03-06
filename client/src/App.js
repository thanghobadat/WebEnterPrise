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

function App() {
  const { Header, Content, Footer } = Layout;
  return (
    <div className='App'>
      <Layout>
        <Header style={{ position: 'fixed', zIndex: 1, width: '100%' }}>
          <div className='logo' />
          <Menu theme='dark' mode='horizontal' defaultSelectedKeys={['2']}>
            <Menu.Item key='1'>
              <Link to='#'>Home</Link>
            </Menu.Item>
            <Menu.Item key='2'>
              <Link to='#'>Category</Link>
            </Menu.Item>
            <Menu.Item key='3'>
              <Link to='#'>Department</Link>
            </Menu.Item>
            <Menu.Item key='4'>
              <Link to='account-user'>AccountUser</Link>
            </Menu.Item>
          </Menu>
        </Header>
        <Content
          className='site-layout'
          style={{ padding: '0 50px', marginTop: 64 }}>
          <div
            className='site-layout-background'
            style={{ padding: 24, minHeight: 380 }}>
            <Routes>
              <Route path='/account-user' element={<ListUser />}></Route>
            </Routes>
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>Footer</Footer>
      </Layout>
    </div>
  );
}

export default App;
