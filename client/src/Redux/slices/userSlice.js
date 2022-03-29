/** @format */

import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';

export const getListUserApi = createAsyncThunk(
  'user/getListUserApi',
  async () => {
    const res = await axios
      .get(`https://localhost:5001/api/Users/GetAllAccount`)
      .then((res) => {
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
  async (payload, rejectWithValue) => {
    await axios
      .post(`https://localhost:5001/api/Users/Register`, {
        userName: payload.userName,
        email: payload.email,
        role: payload.role,
        phoneNumber: payload.phoneNumber,
        departmentId: parseInt(payload.department),
        password: payload.password,
      })
      .then((res) => {
        console.log('res', res);
        return res;
      })
      .catch((error) => {
        return rejectWithValue(error);
      });
  },
);
export const putChangePasswordUserApi = createAsyncThunk(
  'user/putChangePasswordUserApi',
  async (payload) => {
    await axios
      .put(`https://localhost:5001/api/Users/ChangePassword`, {
        id: payload.id,
        newPassword: payload.newPassword,
      })
      .then((res) => {
        // console.log('.listUserApi ~ res', res.data.resultObj);
        return res;
      })
      .catch((e) => {
        console.log('e', e);
        return e;
      });
  },
);
export const deleteUserApi = createAsyncThunk(
  'user/putChangePasswordUserApi',
  async (payload) => {
    await axios
      .delete(`https://localhost:5001/api/Users/DeleteAccount`, {
        id: payload,
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
    errorMss: '',
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
    [postRegisterUserApi.rejected]: (state, action) => {
      console.log(action);
      state.errorMss = action.message;
    },
    [postRegisterUserApi.fulfilled]: (state, action) => {},
  },
});

// Action creators are generated for each case reducer function
const { reducer } = userSlice;
export default reducer;
