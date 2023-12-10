import {RelationshipType} from './../enum/RelationshipType'


export class FamilyMemberBasicDto {
  firstName!: string;
  lastName!: string;
  dateOfBirth!: Date;
  relationship!: RelationshipType;
}
