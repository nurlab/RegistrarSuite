using System.Collections.Generic;

namespace RegistrarSuite.Data.ThirdPartyInfo
{
    public class CountryInfoApi
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string Version { get; set; }
        public string Access { get; set; }
        public Dictionary<string, CountryInfo> Data { get; set; }
    }

    public class CountryInfo
    {
        public string Country { get; set; }
        public string Region { get; set; }
    }


}
