/** @format */

import { configureStore } from '@reduxjs/toolkit';
import listUserSliceReducer from '../slices/userSlice';
const rootReducer = {
  listUser: listUserSliceReducer,
};
export const store = configureStore({
  reducer: rootReducer,
});