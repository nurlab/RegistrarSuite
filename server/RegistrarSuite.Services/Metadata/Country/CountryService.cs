using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Data.Models.StudentSchema;
using RegistrarSuite.DTO.Metadata;
using RegistrarSuite.DTO.Students;
using RegistrarSuite.Repositories.Metadata;
using RegistrarSuite.Repositories.UOW;


namespace RegistrarSuite.Services.Metadata
{
    public class CountryService : ICountryService
    {

        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper, ILogger logger,
            IUnitOfWork<AppDbContext> unitOfWork , ICountryRepository countryRepository
            )
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<CountryDrpDto>> GetNationalities()
        {
            try
            {
                var countryList = await _countryRepository.GetAllAsync();

                if (countryList != null)
                {
                    List<CountryDrpDto> countryDrpListDto = _mapper.Map<List<CountryDrpDto>>(countryList);
                    return countryDrpListDto;
                }
                else
                {
                    _logger.LogError($"No Country found in system");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in row '{ex}'");
                throw;
            }

        }
    }
}
