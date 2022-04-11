/** @format */

import { createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { createAsyncThunk } from '@reduxjs/toolkit';

export const getAnalyzeApi = createAsyncThunk(
  'user/getAnalyzeApi',
  async () => {
    const res = await axios
      .get(`https://localhost:5001/api/Ideas/AnalyzeIdeaByAcademicYear`)
      .then((res) => {
        // console.log('e', res);
        return res;
      })
      .catch((e) => {
        console.log('e', e);
      });
    return res.data.resultObj;
  },
);
export const analyzeSlice = createSlice({
  name: 'analyze',
  initialState: {
    listAnalyzeApi: [],
    loading: false,
  },
  reducers: {},
  extraReducers: {
    [getAnalyzeApi.pending]: (state, action) => {},
    [getAnalyzeApi.rejected]: (state, action) => {},
    [getAnalyzeApi.fulfilled]: (state, action) => {
      state.listAnalyzeApi = action.payload;
      console.log(action.payload)
    },
  },
});

// Action creators are generated for each case reducer function
const { reducer } = analyzeSlice;
export default reducer;
