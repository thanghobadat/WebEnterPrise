/** @format */

import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';

export const postLoginUserApi = createAsyncThunk(
  'user/postLoginUserApi',
  async (payload) => {
    await axios
      .post(`https://localhost:5001/api/Users/Authenticate`, {
        userName: payload.username,
        password: payload.password,
        rememberMe: false,
      })
      .then((res) => {
        // console.log('.listUserApi ~ res', res.data.resultObj);
        localStorage.setItem('user', JSON.stringify(res.data.resultObj));
        return res;
      })
      .catch((e) => {
        console.log('e', e);
      });
  },
);

export const loginSlice = createSlice({
  name: 'login',
  initialState: {
    userAccount: {},
    loading: false,
  },
  reducers: {},
  extraReducers: {
    [postLoginUserApi.pending]: (state, action) => {
      state.loading = true;
    },
    [postLoginUserApi.rejected]: (state, action) => {
      state.loading = true;
    },
    [postLoginUserApi.fulfilled]: (state, action) => {
      state.loading = false;
      console.log(action.payload);
    },
  },
});

// Action creators are generated for each case reducer function
const { reducer } = loginSlice;
export default reducer;
