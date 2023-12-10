using System;
using System.Collections.Generic;
using System.Text;
using RegistrarSuite.Repositories.Generics;

namespace RegistrarSuite.Repositories.Metadata
{
    public interface ICountryRepository : IGRepository<Data.Models.MetadataSchema.Country>
    {
    }
}
