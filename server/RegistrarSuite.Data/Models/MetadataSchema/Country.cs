using RegistrarSuite.Data.BaseModeling;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace RegistrarSuite.Data.Models.MetadataSchema
{
    [Table("Countries", Schema="Metadata")]
    public  class Country : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
