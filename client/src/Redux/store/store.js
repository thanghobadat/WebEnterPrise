/** @format */

import { configureStore } from '@reduxjs/toolkit';
import listUserSliceReducer from '../slices/userSlice';
import listIdeaSliceReducer from '../slices/ideaSlice';
import loginSliceReducer from '../slices/loginSlice';
import analyzeSliceReducer from '../slices/analyze';
const rootReducer = {
  listUser: listUserSliceReducer,
  listIdea: listIdeaSliceReducer,
  login: loginSliceReducer,
  analyze :  analyzeSliceReducer
};
export const store = configureStore({
  reducer: rootReducer,
});
