import { FamilyMemberController } from "src/@core/APIs/FamilyMemberController";
import { FamilyMemberBasicDto } from "src/@core/dto/FamilyMemberBasicDto";
import { FamilyMemberBasicResponseDto } from "src/@core/dto/FamilyMemberBasicResponseDto";
import { FamilyMemberDto } from "src/@core/dto/FamilyMemberDto";



export class FamilyMemberService {
  private readonly baseUrl: string;

  constructor(baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async updateFamilyMember(id: number, familyMemberBasicDto: FamilyMemberBasicDto): Promise<FamilyMemberBasicResponseDto | null> {
    const response = await fetch(FamilyMemberController.UpdateFamilyMember(id), {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(familyMemberBasicDto),
    });

    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }

  async deleteFamilyMember(id: number): Promise<boolean> {
    const response = await fetch(FamilyMemberController.DeleteFamilyMember(id), {
      method: 'DELETE',
    });

    return response.ok;
  }

  async getNationalityOfFamilyMember(familyMemberId: number, nationalityId: number): Promise<FamilyMemberDto | null> {
    const response = await fetch(FamilyMemberController.GetNationalityOfFamilyMember(familyMemberId, nationalityId));
    
    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }

  async updateNationalityOfFamilyMember(familyMemberId: number, nationalityId: number): Promise<FamilyMemberDto | null> {
    const response = await fetch(FamilyMemberController.UpdateNationalityOfFamilyMember(familyMemberId, nationalityId), {
      method: 'PUT',
    });

    if (response.ok) {
      return response.json();
    } else {
      return null;
    }
  }
}

// Example usage:
// const familyMemberService = new FamilyMemberService('http://your-api-base-url');
// const updatedFamilyMember = await familyMemberService.updateFamilyMember(1, familyMemberBasicDto);
// console.log(updatedFamilyMember);
