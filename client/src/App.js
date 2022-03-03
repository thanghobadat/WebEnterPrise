/** @format */

import React from 'react';
import './App.css';
import 'antd/dist/antd.css';
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
            <Menu.Item key='1'>Home</Menu.Item>
            <Menu.Item key='2'>Category</Menu.Item>
            <Menu.Item key='3'>Department</Menu.Item>
            <Menu.Item key='4'>Account User</Menu.Item>
          </Menu>
        </Header>
        <Content
          className='site-layout'
          style={{ padding: '0 50px', marginTop: 64 }}>
          <div
            className='site-layout-background'
            style={{ padding: 24, minHeight: 380 }}>
            <ListUser />
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>Footer</Footer>
      </Layout>
    </div>
  );
}

export default App;
