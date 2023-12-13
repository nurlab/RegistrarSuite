import { configureStore } from "@reduxjs/toolkit";
import { rootSlice } from "./features/Home/rootSlice";

export const store = configureStore({
  reducer: {
    root: rootSlice.reducer,
    // studentList: rootSlice.reducer ,
    // familyMemberList: rootSlice.reducer ,
    // familyMemberBasicDto: rootSlice.reducer ,
    // familyMemberBasicResponseDto: rootSlice.reducer ,
    // role:rootSlice.reducer,
    // studentNationalityDto:rootSlice.reducer,
    // nationalityList:rootSlice.reducer
},
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
