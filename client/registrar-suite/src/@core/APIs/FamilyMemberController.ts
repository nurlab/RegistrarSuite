
import { BaseURL } from '../config';

export const FamilyMemberController = {
  UpdateFamilyMember: (id: number) => `${BaseURL}/api/FamilyMembers/${id}`,
  DeleteFamilyMember: (id: number) => `${BaseURL}/api/FamilyMembers/${id}`,
  GetNationalityOfFamilyMember: (familyMemberId: number, nationalityId: number) =>
    `${BaseURL}/api/FamilyMembers/${familyMemberId}/Nationality/${nationalityId}`,
  UpdateNationalityOfFamilyMember: (familyMemberId: number, nationalityId: number) =>
    `${BaseURL}/api/FamilyMembers/${familyMemberId}/Nationality/${nationalityId}`,
};