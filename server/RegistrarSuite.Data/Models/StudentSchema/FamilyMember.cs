using RegistrarSuite.Data.Models.MetadataSchema;
using RegistrarSuite.Data.BaseModeling;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrarSuite.Core.Enums;

namespace RegistrarSuite.Data.Models.StudentSchema
{
    [Table("FamilyMembers", Schema = "Student")]
    public class FamilyMember : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public required RelationshipType Relationship { get; set; }

        public int? NationalityId { get; set; }
        public virtual Country? Nationality { get; set; }

        public int? StudentId { get; set; }
        public virtual Student? Student { get; set; }

    }
}
