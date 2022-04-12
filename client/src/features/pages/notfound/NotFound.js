import { Button } from 'antd'
import React from 'react'
import { Link, useNavigate } from 'react-router-dom'
import './notFoundStyle.scss'

export default function NotFound () {
	const user = JSON.parse(localStorage.getItem('user')); 
  const navigate = useNavigate();
  const onChangeLink = () => {
    if (user.role === 'admin') {
     return  navigate('/admin/view-idea')
    }else if (user.role === 'staff') {
     return  navigate('/staff/view-idea')
    }else if (user.role === 'QACoordinator') {
      return  navigate('/QACoordinator/view-idea')
    }else if (user.role === 'QAManager') {
      return  navigate('/QAManager/view-idea')
    }
  }
  return (
    <div>
      <img className='ImgNotfound' src='https://media3.giphy.com/media/ZeeUrTADWgFUc/giphy.gif' alt='404 Not Found' />
      <Button className='btnNotFound btn-warning'  onClick={onChangeLink}>Back to Home</Button>
    </div>
  )
}
