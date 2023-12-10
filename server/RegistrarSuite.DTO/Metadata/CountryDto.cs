using RegistrarSuite.DTO.Common;

namespace RegistrarSuite.DTO.Metadata
{
    public class CountryDto
    {
        public string? ShortCode { get; set; }
        public string? ShortName { get; set; }
        public string? NativeName { get; set; }
        public string? Flag { get; set; }
        public string? CurrencyCode { get; set; }
        public string? CallingCode { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public decimal Population { get; set; }
    }

    public class CountryDrpDto : Dropdown
    {
        public string? ShortCode { get; set; }
        public string? NativeName { get; set; }
        public string? Flag { get; set; }
    }

}
