using Microsoft.AspNetCore.Mvc;
using RegistrarSuite.DTO.Metadata;
using RegistrarSuite.DTO.Students;
using RegistrarSuite.Services.Metadata;
using RegistrarSuite.Services.Students;

namespace RegistrarSuite.Controllers
{
    [Route("api/FamilyMembers")]
    public class NationalityController : BaseController
    {
        private readonly ICountryService _countryService;

        public NationalityController(ICountryService countryService , IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _countryService = countryService;
        }

        // Gets all nationalities in the system
        // [GET] /api/Nationalities
        [HttpGet]
        public async Task<List<CountryDrpDto>> GetNationalities()
        {
            List<CountryDrpDto> result = await _countryService.GetNationalities();
            return result;
        }
    }
}
