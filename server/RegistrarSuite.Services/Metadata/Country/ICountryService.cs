using RegistrarSuite.Core.Common;
using RegistrarSuite.Core.Interfaces;
using RegistrarSuite.DTO.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistrarSuite.Services.Metadata
{
    public interface ICountryService
    {
        Task<List<CountryDto>> GetNationalities();
    }
}
