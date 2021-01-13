import { FETCH_ALL, CREATE, UPDATE, DELETE } from '../constants/actionTypes';

export default (contacts = [], action) => {
  switch (action.type) {
    case FETCH_ALL:
      return action.payload;    
    case CREATE:
      return [...contacts, action.payload];
    case UPDATE:
      return contacts.map((contact) => (contact._id === action.payload._id ? action.payload : contact));
    case DELETE:
      return contacts.filter((contact) => contact._id !== action.payload);
    default:
      return contacts;
  }
};

