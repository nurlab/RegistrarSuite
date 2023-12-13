import { FamilyMemberController } from "src/@core/APIs/FamilyMemberController";
import { FamilyMemberBasicDto } from "src/@core/dto/FamilyMemberBasicDto";
import { FamilyMemberBasicResponseDto } from "src/@core/dto/FamilyMemberBasicResponseDto";
import { FamilyMemberDto } from "src/@core/dto/FamilyMemberDto";



export class FamilyMemberService {

  async updateFamilyMember(id: number, familyMemberBasicDto: FamilyMemberBasicDto): Promise<FamilyMemberBasicResponseDto | null> {
    try {
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
        // Handle non-successful response (e.g., logging, throwing an error)
        console.error(`Failed to update family member. Status: ${response.status}`);
        return null;
      }
    } catch (error) {
      // Handle any network-related or unexpected errors during the fetch
      console.error('An error occurred during the updateFamilyMember API call:', error);
      return null;
    }
  }
  

  async deleteFamilyMember(id: number): Promise<boolean> {
    try {
      const response = await fetch(FamilyMemberController.DeleteFamilyMember(id), {
        method: 'DELETE',
      });
  
      return response.ok;
    } catch (error) {
      console.error('An error occurred during the deleteFamilyMember API call:', error);
      return false;
    }
  }
  
  async getNationalityOfFamilyMember(familyMemberId: number, nationalityId: number): Promise<FamilyMemberDto | null> {
    try {
      const response = await fetch(FamilyMemberController.GetNationalityOfFamilyMember(familyMemberId, nationalityId));
  
      if (response.ok) {
        return response.json();
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the getNationalityOfFamilyMember API call:', error);
      return null;
    }
  }
  
  async updateNationalityOfFamilyMember(familyMemberId: number, nationalityCode: string): Promise<FamilyMemberDto | null> {
    try {
      const response = await fetch(FamilyMemberController.UpdateNationalityOfFamilyMember(familyMemberId, nationalityCode), {
        method: 'PUT',
      });
  
      if (response.ok) {
        return response.json();
      } else {
        return null;
      }
    } catch (error) {
      console.error('An error occurred during the updateNationalityOfFamilyMember API call:', error);
      return null;
    }
  }
  
}

// Example usage:
// const familyMemberService = new FamilyMemberService('http://your-api-base-url');
// const updatedFamilyMember = await familyMemberService.updateFamilyMember(1, familyMemberBasicDto);
// console.log(updatedFamilyMember);
