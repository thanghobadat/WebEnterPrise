import React from 'react';
import PropTypes from 'prop-types';
import './DepartmentList.scss';
import 'font-awesome/css/font-awesome.min.css';
DepartmentList.propTypes = {
  posts: PropTypes.array,
  
};

DepartmentList.defaultProps = {
  posts: [],
}
function DepartmentList(props) {
  const{posts} = props;
  return (
    <div className="users-container">
      <div className='title text-center'>Manager Department</div>
      <div className='users-table mt-3 mx-1'></div>
    <table id="customers">
      <tr>
        <th>Name</th>
        <th>Description</th>
        <th>Actions</th>
      </tr>
      {posts.map(department => {
        return(
          <tr key={department.id}>
            <td>{department.name}</td>
            <td>{department.description}</td>
            <td>
              <button className='btn-edit'><i className='fas fa-pencil-alt'></i></button>
              <button className='btn-delete'><i className='fas fa-trash'></i></button>
            </td>
          </tr>
        )
      })
      }

    </table>
    </div>
    
  );
}

export default DepartmentList;