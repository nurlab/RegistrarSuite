import { homeSlice } from './features/Home/homeSlice';
import { configureStore } from "@reduxjs/toolkit";

export const store = configureStore({
  reducer: {
    studentList: homeSlice.reducer ,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
