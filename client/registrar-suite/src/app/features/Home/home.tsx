import { useDispatch, useSelector } from 'react-redux';
import { RootState } from 'src/app/store';
import { fetchStudentList, homeSlice } from '../Home/homeSlice';
import { useEffect } from 'react';
import { Table } from 'react-bootstrap';

export function Home() {
  const dispatch = useDispatch();
  const _homeslice = useSelector((state: RootState) => state.studentList);

  useEffect(() => {
    const fetchData = async () => {
      try {
        // Dispatch an action to signal the start of data fetching
        dispatch(homeSlice.actions.getAllStudentsStart());

        // Fetch students
        const students = await fetchStudentList();

        // Dispatch an action to update the state with the fetched data
        dispatch(homeSlice.actions.getAllStudentsSuccess(students));
      } catch (error) {
        // Dispatch an action to handle errors
        dispatch(homeSlice.actions.getAllStudentsFailure(error));
      }
    };

    // Call the fetchData function when the component mounts
    fetchData();
  }, [dispatch]);
  return (
    <div>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Birth Date</th>
          </tr>
        </thead>
        <tbody>
          {_homeslice.studentList.map((student, index) => (
            <tr>
              <td>{index + 1}</td>
              <td>{student.firstName}</td>
              <td>{student.lastName}</td>
              <td>{student.dateOfBirth.toString()}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
}
