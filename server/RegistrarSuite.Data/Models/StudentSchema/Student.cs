using RegistrarSuite.Data.Models.MetadataSchema;
using RegistrarSuite.Data.BaseModeling;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrarSuite.Data.Models.StudentSchema
{
    [Table("Students", Schema = "Student")]
    public class Student : BaseEntity
    {
        public Student()
        {
            FamilyMembers = new HashSet<FamilyMember>();
        }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public required string? NationalityCode { get; set; }

        public virtual ICollection<FamilyMember>? FamilyMembers { get; set; }

    }
}