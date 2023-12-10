import {RelationshipType} from './../enum/RelationshipType'

export class FamilyMemberBasicResponseDto {
  id!: number;
  firstName!: string;
  lastName!: string;
  dateOfBirth!: Date;
  relationship!: RelationshipType;
}
