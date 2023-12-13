/* eslint-disable prefer-const */
import { useState } from 'react';
import { Button, Form, Modal, Table, Pagination } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from 'src/app/store';
import { addStudent, fetchStudentList, rootSlice } from '../Home/rootSlice';
import { useEffect } from 'react';
import { StudentDto } from 'src/@core/dto/StudentDto';
import EditStudent from '../Student/editStudent';
import { StudentBasicDto } from 'src/@core/dto/StudentBasicDto';
import { UtilityService } from 'src/app/services/utilityService';

export function Home() {
  const dispatch = useDispatch();
  const _utilityService = new UtilityService();
  const _root = useSelector((state: RootState) => state.root);
  const [showEditStudentModal, setShowEditStudentModal] = useState(false);
  const [showAddStudentModal, setShowAddStudentModal] = useState(false);

  const [selectedStudent, setSelectedStudent] = useState<StudentDto | null>(
    null
  );
  const itemsPerPage = 7; // Adjust as needed
  const [currentPage, setCurrentPage] = useState(1);
  const [searchQuery, setSearchQuery] = useState('');
  const [validated, setValidated] = useState(false);

  const initializeFormData = () => {
    return {
      firstName: '',
      lastName: '',
      dateOfBirth: '',
    };
  };
  const [formData, setFormData] = useState(initializeFormData);
  const handleEditClick = (student: StudentDto) => {
    setShowEditStudentModal(true);
    setSelectedStudent(student);
  };
  const handleAddClick = () => {
    setShowAddStudentModal(true);
  };
  const handleModalClose = async () => {
    try {
      setSelectedStudent(null);
      setShowEditStudentModal(false);
      setShowAddStudentModal(false);
      setFormData(initializeFormData);
      dispatch(rootSlice.actions.clearfamilyMembers());
      const students = await fetchStudentList();
      dispatch(rootSlice.actions.getAllStudentsSuccess(students));
    } catch (error) {
      console.error('Error fetching updated student list:', error);
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        dispatch(rootSlice.actions.getAllStudentsStart());
        const students: StudentDto[] = await fetchStudentList();
        dispatch(rootSlice.actions.getAllStudentsSuccess(students));
      } catch (error) {
        dispatch(rootSlice.actions.getAllStudentsFailure(error));
      }
    };
    fetchData();
  }, [dispatch]);

  const handleSaveChanges = async (event: React.FormEvent<HTMLFormElement>) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(true);
    } else {
      addStudentAndCloseModal();
    }
  };

  const addStudentAndCloseModal = async () => {
    let data = new StudentBasicDto();
    data.firstName = formData.firstName;
    data.lastName = formData.lastName;
    data.dateOfBirth = formData.dateOfBirth;

    let result: StudentBasicDto | null;
    result = await addStudent(data);

    if (result == null) {
      dispatch(
        rootSlice.actions.addStudentFailure('Family Member Not Updated')
      );
    }
    dispatch(rootSlice.actions.addStudentSuccess());
    setShowAddStudentModal(false);
    handleModalClose();
  };

  // Filter the student list based on the search query
  const filteredStudentList =
    _root.studentList && _root.studentList.length > 0
      ? _root.studentList.filter(
          (student) =>
            student.firstName
              .toLowerCase()
              .includes(searchQuery.toLowerCase()) ||
            student.lastName.toLowerCase().includes(searchQuery.toLowerCase())
        )
      : [];

  // Pagination Logic
  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = filteredStudentList.slice(
    indexOfFirstItem,
    indexOfLastItem
  );

  // Change page
  const paginate = (pageNumber: number) => setCurrentPage(pageNumber);

  return (
    <>
      <div>
        {' '}
        <Button variant="primary" onClick={() => handleAddClick()}>
          Add Student
        </Button>
        <hr className="my-3" />
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
            {filteredStudentList.length > 0 ? (
              currentItems.map((student, index) => (
                <tr
                  key={index}
                  onClick={
                    _root.role === 'Admin'
                      ? () => handleEditClick(student)
                      : undefined
                  }
                  style={{
                    cursor: _root.role === 'Admin' ? 'pointer' : 'default',
                  }}
                >
                  <td>{student.id}</td>
                  <td>{student.firstName}</td>
                  <td>{student.lastName}</td>
                  <td>
                    {_utilityService.convertToReadable(student.dateOfBirth)}
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={4}>No records yet</td>
              </tr>
            )}
          </tbody>
        </Table>
        {/* Pagination */}
        <hr className="my-3" />
        <Pagination>
          {Array.from(
            { length: Math.ceil(filteredStudentList.length / itemsPerPage) },
            (_, index) => (
              <Pagination.Item
                key={index + 1}
                active={index + 1 === currentPage}
                onClick={() => paginate(index + 1)}
              >
                {index + 1}
              </Pagination.Item>
            )
          )}
        </Pagination>
        {/* Modal for editing */}
        {selectedStudent !== null && (
          <EditStudent
            showModal={showEditStudentModal}
            student={selectedStudent}
            handleClose={handleModalClose}
          />
        )}
      </div>

      <Modal show={showAddStudentModal} onHide={handleModalClose}>
        <Modal.Header closeButton>
          <Modal.Title>Add Student</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form noValidate validated={validated} onSubmit={handleSaveChanges}>
            <Form.Group controlId="formFirstName">
              <Form.Label>First Name</Form.Label>
              <Form.Control
                required
                type="text"
                placeholder="Enter first name"
                value={formData.firstName}
                onChange={(e) =>
                  setFormData((prevFormData) => ({
                    ...prevFormData,
                    firstName: e.target.value,
                  }))
                }
              />
            </Form.Group>
            <Form.Group controlId="formLastName">
              <Form.Label>Last Name</Form.Label>
              <Form.Control
                required
                type="text"
                placeholder="Enter last name"
                value={formData.lastName}
                onChange={(e) =>
                  setFormData({ ...formData, lastName: e.target.value })
                }
              />
            </Form.Group>
            <Form.Group controlId="formDateOfBirth">
              <Form.Label>Date of Birth</Form.Label>
              <Form.Control
                required
                type="date"
                value={formData.dateOfBirth}
                onChange={(e) =>
                  setFormData({
                    ...formData,
                    dateOfBirth: e.target.value,
                  })
                }
              />
            </Form.Group>
            <div className="py-3">
              <Button variant="primary" type="submit">
                Save Changes
              </Button>{' '}
              <Button variant="secondary" onClick={handleModalClose}>
                Cancel
              </Button>{' '}
            </div>
          </Form>
        </Modal.Body>
      </Modal>
    </>
  );
}
