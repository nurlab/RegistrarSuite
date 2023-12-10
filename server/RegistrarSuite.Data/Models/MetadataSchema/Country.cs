using RegistrarSuite.Data.BaseModeling;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RegistrarSuite.Data.Models.MetadataSchema
{
    [Table("Countries", Schema="Metadata")]
    public  class Country : BaseEntity
    {

        public string ShortCode { get; set; }
        public string ShortName { get; set; }
        public string NativeName { get; set; }
        public string Flag { get; set; }
        public string CurrencyCode { get; set; }
        public string CallingCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal Population { get; set; }

    }
}
