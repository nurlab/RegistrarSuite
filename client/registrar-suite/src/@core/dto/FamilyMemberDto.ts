import {RelationshipType} from './../enum/RelationshipType'
import {CountryDto} from './CountryDto'

export class FamilyMemberDto {
  id!: number;
  firstName!: string;
  lastName!: string;
  dateOfBirth!: Date;
  relationship!: RelationshipType;
  nationality?: CountryDto;
}
