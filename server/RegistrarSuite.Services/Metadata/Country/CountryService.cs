using AutoMapper;
using Microsoft.Extensions.Logging;
using NLog;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.DTO.Metadata;
using RegistrarSuite.Repositories.Metadata;
using RegistrarSuite.Repositories.UOW;


namespace RegistrarSuite.Services.Metadata
{
    public class CountryService : ICountryService
    {

        private readonly IUnitOfWork<AppDbContext> _unitOfWork;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CountryService(IMapper mapper,
            IUnitOfWork<AppDbContext> unitOfWork , ICountryRepository countryRepository
            )
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<List<CountryDto>> GetNationalities()
        {
            try
            {
                var countryList = await _countryRepository.GetAllAsync();

                if (countryList != null)
                {
                    List<CountryDto> countryDrpListDto = _mapper.Map<List<CountryDto>>(countryList);
                    return countryDrpListDto;
                }
                else
                {
                    _logger.Error($"No Country found in system");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"Error in row '{ex}'");
                throw;
            }
}
    }
}
