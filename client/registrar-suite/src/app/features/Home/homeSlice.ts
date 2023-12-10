import { createSlice } from "@reduxjs/toolkit";
import { StudentBasicDto } from "src/@core/dto/StudentBasicDto";
import { StudentService } from "src/app/services/studentService";

export const fetchStudentList = async () => {
    const studentService = new StudentService();
    const studentList = await studentService.getAllStudents();
    return studentList;
  };
  
  const initialState = {
    studentList: [] as StudentBasicDto[],
    loading: false,
    error: null as string | null,
  };
  
  export const homeSlice = createSlice({
    name: 'studentList',
    initialState,
    reducers: {
      getAllStudentsStart: (state) => {
        state.loading = true;
        state.error = null;
      },
      getAllStudentsSuccess: (state, action) => {
        state.loading = false;
        state.studentList = action.payload;
      },
      getAllStudentsFailure: (state, action) => {
        state.loading = false;
        state.error = action.payload;
      },
    },
  });