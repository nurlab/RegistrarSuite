using System;
using System.Collections.Generic;
using System.Text;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Repositories.Generics;

namespace RegistrarSuite.Repositories.Metadata
{
    public class CountryRepository : GRepository<Data.Models.MetadataSchema.Country>, ICountryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CountryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
