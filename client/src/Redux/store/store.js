/** @format */

import { configureStore } from '@reduxjs/toolkit';
import listUserSliceReducer from '../slices/userSlice';
import listIdeaSliceReducer from '../slices/ideaSlice';
import loginSliceReducer from '../slices/loginSlice';
const rootReducer = {
  listUser: listUserSliceReducer,
  listIdea: listIdeaSliceReducer,
  login: loginSliceReducer,
};
export const store = configureStore({
  reducer: rootReducer,
});
