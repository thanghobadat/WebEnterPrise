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
        // console.log('.listUserApi ~ res', res.data.resultObj);
        return res;
      })
      .catch((e) => {
        console.log('e', e);
      });
    return res.data.resultObj;
  },
);
export const userSlice = createSlice({
  name: 'user',
  initialState: {
    listUserApi: [],
  },
  reducers: {},
  extraReducers: {
    [getListUserApi.pending]: (state, action) => {},
    [getListUserApi.rejected]: (state, action) => {},
    [getListUserApi.fulfilled]: (state, action) => {
      state.listUserApi = action.payload || [];
    },
  },
});

// Action creators are generated for each case reducer function
const { reducer } = userSlice;
export default reducer;
