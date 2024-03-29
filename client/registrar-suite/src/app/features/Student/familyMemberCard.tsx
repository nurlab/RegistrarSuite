/* eslint-disable prefer-const */
import React, { useEffect, useState } from 'react';
import { Button, Card, Form } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import { FamilyMemberBasicResponseDto } from 'src/@core/dto/FamilyMemberBasicResponseDto';
import {
  addNewFamilyMember,
  removeFamilyMember,
  rootSlice,
  updateFamilyMember,
} from '../Home/rootSlice';
import { FamilyMemberBasicDto } from 'src/@core/dto/FamilyMemberBasicDto';
import { RelationshipType } from 'src/@core/enum/RelationshipType';
import { RootState } from 'src/app/store';
import { UtilityService } from 'src/app/services/utilityService';
import { FamilyMemberService } from 'src/app/services/FamilyMemberService';
import { FamilyMemberDto } from 'src/@core/dto/FamilyMemberDto';

interface FamilyMemberCardProps {
  familyMember: FamilyMemberBasicResponseDto;
  studentId: number;
  reLoad: () => void;
  mode: string;
  showAddForm: boolean;
  toggleAddForm: () => void;
}
export const FamilyMemberCard = ({
  familyMember,
  studentId,
  reLoad,
  mode = '',
  showAddForm,
  toggleAddForm,
}: FamilyMemberCardProps) => {
  const dispatch = useDispatch();
  const _utilityService = new UtilityService();

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const [validated, setValidated] = useState(false);
  const _root = useSelector((state: RootState) => state.root);

  const [isEditing, setIsEditing] = useState(false);

  const initializeFormData = () => {
    return {
      firstName: familyMember.firstName || '',
      lastName: familyMember.lastName || '',
      dateOfBirth: familyMember.dateOfBirth || '',
      relationship: familyMember.relationship || 0,
      nationalityCode: '',
    };
  };
  const [formData, setFormData] = useState(initializeFormData);

  useEffect(() => {
    // Fetch nationality when the component mounts or familyMember.id changes
    getNationalityOfFamilyMember();
  }, [familyMember, studentId]);

  const getNationalityOfFamilyMember = async (): Promise<void> => {
    if (familyMember.id !== 0) {
      let result: FamilyMemberDto | null = null;
      const familyMemberService = new FamilyMemberService();

      try {
        result = await familyMemberService.getNationalityOfFamilyMember(
          familyMember.id,
          familyMember.id
        );

        if (result != null && result?.nationalityCode !== undefined) {
          setFormData({
            ...formData,
            nationalityCode: result?.nationalityCode,
          });
        }
      } catch (error) {
        console.error('Error fetching nationality:', error);
      }
    }
  };

  const handleEditClick = () => {
    getNationalityOfFamilyMember();
    setIsEditing(true);
  };

  const handleCancelEdit = () => {
    setIsEditing(false);
  };

  const handleRemove = async () => {
    try {
      if (familyMember.id != null) {
        dispatch(rootSlice.actions.removeFamilyMemberStart());
        const result = await removeFamilyMember(familyMember.id);
        if (result === false)
          dispatch(
            rootSlice.actions.removeFamilyMemberFailure(
              'Family Member Not removed'
            )
          );
        dispatch(rootSlice.actions.removeFamilyMemberSuccess(result));
      } else
        dispatch(
          rootSlice.actions.removeFamilyMemberFailure('Wrong Student Id')
        );
    } catch (error) {
      dispatch(rootSlice.actions.removeFamilyMemberFailure(error));
    }
    setIsEditing(false);
    reLoad();
  };
  const handleUpdateFamilyMember = async (
    event: React.FormEvent<HTMLFormElement>
  ) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(true);
    } else {
      try {
        dispatch(rootSlice.actions.updateFamilyMemberStart());
        let data = new FamilyMemberBasicResponseDto();
        data.firstName = formData.firstName;
        data.lastName = formData.lastName;
        data.dateOfBirth = formData.dateOfBirth;
        data.relationship = formData.relationship;
        let result: FamilyMemberBasicResponseDto | null;
        result = await updateFamilyMember(familyMember.id, data);
        if (result == null)
          dispatch(
            rootSlice.actions.updateFamilyMemberFailure(
              'Family Member Not Updated'
            )
          );

        const familyMemberService = new FamilyMemberService();
        await familyMemberService.updateNationalityOfFamilyMember(
          familyMember.id,
          formData.nationalityCode
        );

        dispatch(rootSlice.actions.updateFamilyMemberSuccess(result));
      } catch (error) {
        dispatch(rootSlice.actions.updateFamilyMemberFailure(error));
      }
      setIsEditing(false);
      reLoad();
      //      initializeFormData();
    }
  };

  const handleSaveNewFamily = async (
    event: React.FormEvent<HTMLFormElement>
  ) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(true);
    } else {
      try {
        dispatch(rootSlice.actions.addNewFamilyMemberStart());
        let data = new FamilyMemberBasicDto();
        data.firstName = formData.firstName;
        data.lastName = formData.lastName;
        data.dateOfBirth = formData.dateOfBirth;
        data.relationship = formData.relationship;
        let result: FamilyMemberBasicResponseDto | null;
        result = await addNewFamilyMember(studentId, data);
        if (result == null)
          dispatch(
            rootSlice.actions.addNewFamilyMemberFailure(
              'Family Member Not Saved'
            )
          );

        if (result?.id !== undefined && result?.id != null) {
          const familyMemberService = new FamilyMemberService();
          await familyMemberService.updateNationalityOfFamilyMember(
            result?.id,
            formData.nationalityCode
          );
        }
        dispatch(rootSlice.actions.addNewFamilyMemberSuccess(result));
      } catch (error) {
        dispatch(rootSlice.actions.addNewFamilyMemberFailure(error));
      }
      toggleAddForm();
      reLoad();
      //initializeFormData();
    }
  };
  const handleCancelAdd = () => {
    // isAdding = false;
    toggleAddForm();
  };

  return (
    <Card>
      <Card.Body>
        {mode === 'add' ? (
          <Form onSubmit={handleSaveNewFamily}>
            <Form.Group controlId="formFirstName">
              <Form.Label>First Name</Form.Label>
              <Form.Control
                type="text"
                placeholder="Enter first name"
                value={formData.firstName}
                onChange={(e) =>
                  setFormData({ ...formData, firstName: e.target.value })
                }
              />
            </Form.Group>
            <Form.Group controlId="formLastName">
              <Form.Label>Last Name</Form.Label>
              <Form.Control
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
                type="date"
                value={_utilityService.formatDate(formData.dateOfBirth)}
                onChange={(e) =>
                  setFormData({
                    ...formData,
                    dateOfBirth: e.target.value,
                  })
                }
              />
            </Form.Group>
            <Form.Group controlId="formRelationship">
              <Form.Label>Relationship</Form.Label>
              <Form.Select
                value={formData.relationship}
                onChange={(e) =>
                  setFormData({
                    ...formData,
                    relationship: parseInt(e.target.value),
                  })
                }
              >
                {RelationshipType.relationshipList.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.key}
                  </option>
                ))}
              </Form.Select>
            </Form.Group>

            <Form.Group controlId="formNationality">
              <Form.Label>Nationality</Form.Label>
              <Form.Select
                value={formData.nationalityCode}
                onChange={(e) =>
                  setFormData({
                    ...formData,
                    nationalityCode: e.target.value,
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

            <div className="py-3">
              <Button variant="primary" type="submit">
                Save Changes
              </Button>{' '}
              <Button variant="secondary" onClick={handleCancelAdd}>
                Cancel
              </Button>{' '}
            </div>
          </Form>
        ) : (
          ''
        )}
        {mode === 'edit' ? (
          isEditing ? (
            <Form onSubmit={handleUpdateFamilyMember}>
              <Form.Group controlId="formFirstName">
                <Form.Label>First Name</Form.Label>
                <Form.Control
                  type="text"
                  placeholder="Enter first name"
                  value={formData.firstName}
                  onChange={(e) =>
                    setFormData({ ...formData, firstName: e.target.value })
                  }
                />
              </Form.Group>
              <Form.Group controlId="formLastName">
                <Form.Label>Last Name</Form.Label>
                <Form.Control
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
                  type="date"
                  value={_utilityService.formatDate(formData.dateOfBirth)}
                  onChange={(e) =>
                    setFormData({
                      ...formData,
                      dateOfBirth: e.target.value,
                    })
                  }
                />
              </Form.Group>
              <Form.Group controlId="formRelationship">
                <Form.Label>Relationship</Form.Label>
                <Form.Select
                  value={formData.relationship}
                  onChange={(e) =>
                    setFormData({
                      ...formData,
                      relationship: parseInt(e.target.value),
                    })
                  }
                >
                  {RelationshipType.relationshipList.map((option) => (
                    <option key={option.value} value={option.value}>
                      {option.key}
                    </option>
                  ))}
                </Form.Select>
              </Form.Group>

              <Form.Group controlId="formNationality">
                <Form.Label>Nationality</Form.Label>
                <Form.Select
                  value={formData.nationalityCode}
                  onChange={(e) =>
                    setFormData({
                      ...formData,
                      nationalityCode: e.target.value,
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
              <div className="py-3">
                <Button variant="primary" type="submit">
                  Save Changes
                </Button>{' '}
                <Button variant="secondary" onClick={handleCancelEdit}>
                  Cancel
                </Button>{' '}
              </div>
            </Form>
          ) : (
            // Render family member card here
            <>
              <Card.Title>
                {familyMember.firstName} {familyMember.lastName}
              </Card.Title>
              <Card.Text>
                Date of Birth: {familyMember.dateOfBirth + ''}
              </Card.Text>
              <Button variant="primary" onClick={handleEditClick}>
                Edit
              </Button>{' '}
              <Button variant="danger" onClick={handleRemove}>
                Remove
              </Button>{' '}
            </>
          )
        ) : (
          ''
        )}
      </Card.Body>
    </Card>
  );
};

export default FamilyMemberCard;
