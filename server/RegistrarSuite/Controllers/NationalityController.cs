using Microsoft.AspNetCore.Mvc;
using RegistrarSuite.DTO.Metadata;
using RegistrarSuite.Services.Metadata;

namespace RegistrarSuite.Controllers
{
    [Route("api/Nationality")]
    public class NationalityController : BaseController
    {
        private readonly ICountryService _countryService;

        public NationalityController(ICountryService countryService , IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _countryService = countryService;
        }

        // Gets all nationalities in the system
        // [GET] /api/Nationalities
        [HttpGet("Nationalities")]
        public async Task<List<CountryDto>> GetNationalities()
        {
            List<CountryDto> result = await _countryService.GetNationalities();
            return result;
        }
    }
}
