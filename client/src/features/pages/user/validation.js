/** @format */
const validatorForm = {
  required: 'Please input ${label} !',
  types: {
    email: '${label} is not a valid email! Ex: example@gmail.com',
    number: '${label} is not a valid number!',
    phoneNumber: '${label} is not a valid phone!',
  },
  number: {
    range: '${label} must be between ${min} and ${max}',
  },
  phone: {
    range: '${label} must be between ${min} and ${max}',
  },
};

export default validatorForm;
