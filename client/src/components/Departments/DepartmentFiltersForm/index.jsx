import React, {useState, useRef} from 'react';
import PropTypes from 'prop-types';

DepartmentFiltersForm.propTypes = {
    onSubmit: PropTypes.func
};
DepartmentFiltersForm.defaultProps = {
    onSubmit: null,
};

function DepartmentFiltersForm(props) {
    const{onSubmit} = props;
    const[searchTerm, setSearchTerm] = useState('');
    const typingTimeoutRef = useRef(null);

    function handleSearchTermChange(e){
        const value = e.target.value;
        setSearchTerm(value);
        if(!onSubmit) return;
        
        if(typingTimeoutRef.current){
            clearTimeout(typingTimeoutRef.current);
        }

        typingTimeoutRef.current = setTimeout(() => {
            const formValues = {
                searchTerm: value,
            };
            onSubmit(formValues);
        }, 300);
        
    }
    return (
        <form>
            <input
            type='text'
            value={searchTerm}
            onChange={handleSearchTermChange}
            />
            
        </form>
    );
}

export default DepartmentFiltersForm;