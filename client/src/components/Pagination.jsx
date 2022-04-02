import React from 'react';
import PropTypes from 'prop-types';

Pagination.propTypes = {
    pagination: PropTypes.object.isRequired,
    onPageChange: PropTypes.func,
};
Pagination.defaultProps = {
    onPageChange: null,
}

    
function Pagination(props) {
    const{pagination, onPageChange} = props;
    
    const{pageIndex, pageSize, totalRecords} = pagination;
    const totalPages = Math.ceil(totalRecords / pageSize);
    function handlePageChange(newPage){
        if(onPageChange){
            onPageChange(newPage)
        }
    }
    return (
        <div className='title text-center'>
            <button
            disabled={pageIndex <= 1}
            onClick={() => handlePageChange(pageIndex - 1)}
            >Prev</button>
            <button
            disabled={pageIndex >= totalPages}
            onClick={() => handlePageChange(pageIndex + 1)}
            >Next</button>
        </div>
    );
}

export default Pagination;