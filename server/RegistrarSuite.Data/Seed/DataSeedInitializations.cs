using Newtonsoft.Json;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Data.Models.MetadataSchema;
using RegistrarSuite.Data.ThirdPartyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarSuite.Data.Seed
{
    public class DataSeedInitializations
    {
        private static AppDbContext? _appDbContext;
        public static void Seed(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.EnsureCreated();
            SeedCountries();
        }

        private static void SeedCountries()
        {
            if(_appDbContext != null)
            {
                List<Country> allcountry = _appDbContext.Countries.ToList();
                if (allcountry == null || allcountry.Count() == 0)
                {
                    HttpClient http = new HttpClient();
                    var data = http.GetAsync("https://api.first.org/data/v1/countries").Result.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<CountryInfoApi>(data);
                    foreach (var country in model.Data)
                    {
                        _appDbContext.Countries.Add(new Country()
                        {
                            IsDeleted = false,
                            IsActive = true,
                            CreatedOn = DateTime.Now,
                            Code = country.Key,
                            Name = country.Value.Country
                        });
                    }
                    _appDbContext.SaveChanges();
                }
            }
            

        }
    }
    
}
