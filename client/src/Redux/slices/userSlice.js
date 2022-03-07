/** @format */

import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';

export const getListUserApi = createAsyncThunk(
  'user/getListUserApi',
  async () => {
    const res = await axios
      .get(`${global.config.var_env}/api/Users/GetAllAccount`)
      .then((res) => {
        console.log('.listUserApi ~ res', res.data.resultObj);
        return res;
      })
      .catch((e) => {
        console.log('e', e);
      });
    return res.data.resultObj;
  },
);
export const postRegisterUserApi = createAsyncThunk(
  'user/postRegisterUserApi',
  async (payload) => {
    await axios
      .post(`${global.config.var_env}/api/Users/Register`, {
        userName: payload.userName,
        email: payload.email,
        role: payload.role,
        phoneNumber: payload.phoneNumber,
        department: payload.department,
        password: payload.password,
      })
      .then((res) => {
        // console.log('.listUserApi ~ res', res.data.resultObj);
        return res;
      })
      .catch((e) => {
        console.log('e', e);
      });
  },
);
export const putChangePasswordUserApi = createAsyncThunk(
  'user/putChangePasswordUserApi',
  async (payload) => {
    await axios
      .put(`${global.config.var_env}/api/Users/ChangePassword`, {
        id: payload.id,
        newPassword: payload.newPassword,
      })
      .then((res) => {
        // console.log('.listUserApi ~ res', res.data.resultObj);
        return res;
      })
      .catch((e) => {
        console.log('e', e);
      });
  },
);
export const userSlice = createSlice({
  name: 'user',
  initialState: {
    listUserApi: [],
    loading: false,
  },
  reducers: {},
  extraReducers: {
    [getListUserApi.pending]: (state, action) => {},
    [getListUserApi.rejected]: (state, action) => {},
    [getListUserApi.fulfilled]: (state, action) => {
      state.listUserApi = action.payload;
    },
    [postRegisterUserApi.pending]: (state, action) => {
      state.loading = true;
    },
  },
});

// Action creators are generated for each case reducer function
const { reducer } = userSlice;
export default reducer;