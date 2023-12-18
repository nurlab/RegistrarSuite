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

        public void SetCreateProperties(BaseEntity entity)
        {
            entity.CreatedBy = 1; // Replace with actual user ID
            entity.UpdatedBy = null; // Replace with actual user ID
            entity.CreatedOn = DateTime.UtcNow; // Use UTC for consistency
            entity.UpdatedOn = null;
            entity.IsActive = true;
            entity.IsDeleted = false;
        }
        public void SetUpdateProperties(BaseEntity entity)
        {
            entity.UpdatedBy = 1; // Replace with actual user ID
            entity.UpdatedOn = DateTime.UtcNow; // Use UTC for consistency
            entity.IsActive = true;
            entity.IsDeleted = false;
        }

    }

}