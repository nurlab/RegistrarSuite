import { NationalityController } from "src/@core/APIs/NationalityController";
import { CountryDto } from "src/@core/dto/CountryDto";

export class NationalityService {  
  
    async getNationalities(): Promise<CountryDto[]> {
      try {
        const response = await fetch(NationalityController.GetNationalities);
        const resjs = await response.json();
        return resjs;
      } catch (error) {
        console.error('Error:', error);
        throw error; // Rethrow the error or handle it appropriately
      }
    }
  }
  
  // Example usage:
  // const nationalityService = new NationalityService('http://your-api-base-url');
  // const nationalities = await nationalityService.getNationalities();
  // console.log(nationalities);