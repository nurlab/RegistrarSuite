
export class FamilyMemberDto {
  id!: number;
  firstName!: string;
  lastName!: string;
  dateOfBirth!: Date;
  relationship!: number;
  nationality?: string;
}
