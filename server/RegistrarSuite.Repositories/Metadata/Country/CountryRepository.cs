using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Data.Models.MetadataSchema;
using RegistrarSuite.Repositories.Generics;

namespace RegistrarSuite.Repositories.Metadata
{
    public class CountryRepository : GRepository<Country>, ICountryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CountryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
