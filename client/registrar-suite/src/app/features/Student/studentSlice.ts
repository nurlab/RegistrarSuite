import { createSlice } from "@reduxjs/toolkit";
import { FamilyMemberBasicResponseDto } from "src/@core/dto/FamilyMemberBasicResponseDto";
import { StudentService } from "src/app/services/studentService";

export const fetchFamilyMemberList = async (id: number) => {
  const studentService = new StudentService();
  const familyMemberList = await studentService.getFamilyMembers(id);
  return familyMemberList;
};
  
  const initialState = {
    familyMemberList: [] as FamilyMemberBasicResponseDto[],
    loading: false,
    error: null as string | null,
  };
  
  export const studentSlice = createSlice({
    name: 'familyMemberList',
    initialState,
    reducers: {
      getAllfamilyMembersStart: (state) => {
        state.loading = true;
        state.error = null;
      },
      getfamilyMembersSuccess: (state, action) => {
        state.loading = false;
        state.familyMemberList = action.payload;
      },
      getAllfamilyMembersFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
    },
  });