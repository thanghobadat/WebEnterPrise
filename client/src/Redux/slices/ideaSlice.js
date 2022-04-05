/** @format */

import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';
export const postRegisterUserApi = createAsyncThunk(
  'user/postRegisterUserApi',
  async (payload) => {
    await axios
      .post(`https://localhost:5001/api/Ideas/CreateIdea`, {
        Content: payload.content,
        UserId: payload.userId,
        isAnonymously: payload.isAnonymously,
        file: payload.file,
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
export const ideaSlice = createSlice({
  name: 'idea',
  initialState: {
    listIdeaApi: [],
    loading: false,
  },
  reducers: {},
  extraReducers: {},
});

// Action creators are generated for each case reducer function
const { reducer } = ideaSlice;
export default reducer;
