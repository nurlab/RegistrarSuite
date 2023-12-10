import { NationalityController } from "src/@core/APIs/NationalityController";
import { CountryDrpDto } from "src/@core/dto/CountryDto";

export class NationalityService {
    private readonly baseUrl: string;
  
    constructor(baseUrl: string) {
      this.baseUrl = baseUrl;
    }
  
    async getNationalities(): Promise<CountryDrpDto[]> {
      const response = await fetch(NationalityController.GetNationalities);
      return response.json();
    }
  }
  
  // Example usage:
  // const nationalityService = new NationalityService('http://your-api-base-url');
  // const nationalities = await nationalityService.getNationalities();
  // console.log(nationalities);