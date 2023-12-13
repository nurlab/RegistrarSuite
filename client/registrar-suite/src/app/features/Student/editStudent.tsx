import React, { useEffect, useState } from 'react';
import { Modal, Button, Form, Container, Row, Col } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { StudentBasicDto } from 'src/@core/dto/StudentBasicDto';
import { StudentDto } from 'src/@core/dto/StudentDto';
import { StudentService } from 'src/app/services/studentService';
import { RootState } from 'src/app/store';
import { FamilyMemberBasicResponseDto } from 'src/@core/dto/FamilyMemberBasicResponseDto';
import {
  fetchFamilyMemberList,
  getAllNationalities,
  getStudentNationality,
  rootSlice,
} from '../Home/rootSlice';
import { FamilyMemberCard } from './familyMemberCard';
import { CountryDto } from 'src/@core/dto/CountryDto';

interface EditStudentProps {
  showModal: boolean;
  student: StudentDto;
  handleClose: () => void;
}

const EditStudent: React.FC<EditStudentProps> = ({
  showModal,
  student,
  handleClose,
}) => {
  const dispatch = useDispatch();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [validated, setValidated] = useState(false);
  const _root = useSelector((state: RootState) => state.root);
  const [formData, setFormData] = useState({
    id: 0,
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    nationality: '',
  });

  // const [selectedStudentId, setSelectedStudentId] = useState<number | null>(
  //   null
  // );
  const [showAddForm, setShowAddForm] = useState(false);

  // eslint-disable-next-line react-hooks/exhaustive-deps
  const reLoadFamilyMembers = async () => {
    if (student != null) {
      try {
        dispatch(rootSlice.actions.getAllfamilyMembersStart());
        const familyMemberBasicResponseDto:
          | FamilyMemberBasicResponseDto[]
          | null = await fetchFamilyMemberList(student.id);
        dispatch(
          rootSlice.actions.getfamilyMembersSuccess(
            familyMemberBasicResponseDto
          )
        );
      } catch (error) {
        dispatch(rootSlice.actions.getAllfamilyMembersFailure(error));
      }
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      if (showModal && student !== null) {
        const nationalityList: CountryDto[] | null =
          await getAllNationalities();

        const result = await getStudentNationality(student.id);

        dispatch(rootSlice.actions.getAllNationalitiesSuccess(nationalityList));

        setFormData({
          id: student.id,
          firstName: student.firstName,
          lastName: student.lastName,
          dateOfBirth: student.dateOfBirth, // Remove toString() if not needed
          nationality: result?.nationalityCode ?? '',
        });

        await reLoadFamilyMembers();
      }
    };
    fetchData();
  }, [dispatch, showModal, student]);

  const handleCloseHere = () => {
    handleClose();
  };
  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(true);
    } else {
      const studentBasic: StudentBasicDto = {
        firstName: formData.firstName,
        lastName: formData.lastName,
        dateOfBirth: formData.dateOfBirth,
      };
      const nationality = formData.nationality;

      const studentService = new StudentService();
      if (student?.id !== undefined) {
        await studentService.updateStudent(student?.id, studentBasic);
        await studentService.updateStudentNationality(student?.id, nationality);
      }

      handleCloseHere();
    }
  };
  const handleAddClick = () => {
    setShowAddForm(!showAddForm);
  };

  const toggleAddForm = () => {
    setShowAddForm(!showAddForm);
  };

  return (
    <Modal show={showModal} onHide={handleCloseHere} size="xl">
      <Modal.Header closeButton>
        <Modal.Title>Edit Student</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Container className="py-3">
          <Row className=" mb-2 border-bottom pb-2">
            <Col>
              <h3> Student Details </h3>
              <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formFirstName">
                  <Form.Label>First Name</Form.Label>
                  <Form.Control
                    type="text"
                    placeholder="Enter first name"
                    name="firstName"
                    value={formData.firstName}
                    onChange={handleInputChange}
                  />
                </Form.Group>

                <Form.Group controlId="formLastName">
                  <Form.Label>Last Name</Form.Label>
                  <Form.Control
                    required
                    type="text"
                    placeholder="Enter last name"
                    name="lastName"
                    value={formData.lastName}
                    onChange={handleInputChange}
                  />
                </Form.Group>

                <Form.Group controlId="formDateOfBirth">
                  <Form.Label>Date of Birth</Form.Label>
                  <Form.Control
                    required
                    type="date"
                    name="dateOfBirth"
                    value={formData.dateOfBirth}
                    onChange={handleInputChange}
                  />
                </Form.Group>

                <Form.Group controlId="formNationality">
                  <Form.Label>Nationality</Form.Label>
                  <Form.Select
                    required
                    value={formData.nationality}
                    onChange={(e) =>
                      setFormData({
                        ...formData,
                        nationality: e.target.value,
                      })
                    }
                  >
                    {_root.nationalityList?.map((option) => (
                      <option key={option.code} value={option.code}>
                        {option.name}
                      </option>
                    ))}
                  </Form.Select>
                </Form.Group>

                <Modal.Footer>
                  <Button variant="primary" type="submit">
                    Save Changes
                  </Button>
                  <Button variant="secondary" onClick={handleCloseHere}>
                    Close
                  </Button>{' '}
                </Modal.Footer>
              </Form>
            </Col>
            <Col className="overflow-auto" style={{ maxHeight: '400px' }}>
              <h5 className="sticky-top bg-white p-2">Family Members</h5>
              <Button variant="info" onClick={handleAddClick}>
                Add Family Member
              </Button>{' '}
              {showAddForm && (
                <Col className="py-3">
                  <FamilyMemberCard
                    familyMember={{
                      id: 0, // Provide a unique id for the new family member
                      firstName: '',
                      lastName: '',
                      dateOfBirth: '',
                      relationship: 0,
                    }}
                    studentId={student?.id}
                    reLoad={() => reLoadFamilyMembers()}
                    mode="add"
                    showAddForm={showAddForm}
                    toggleAddForm={() => toggleAddForm()}
                  />
                </Col>
              )}
              {_root.familyMemberList?.map((familyMember) => (
                <Col key={familyMember.id} className="py-3">
                  <FamilyMemberCard
                    familyMember={familyMember}
                    studentId={student?.id}
                    reLoad={() => reLoadFamilyMembers()}
                    mode="edit"
                    showAddForm={showAddForm}
                    toggleAddForm={() => toggleAddForm()}
                  />
                </Col>
              ))}
            </Col>
          </Row>
        </Container>
      </Modal.Body>
    </Modal>
  );
};

export default EditStudent;
