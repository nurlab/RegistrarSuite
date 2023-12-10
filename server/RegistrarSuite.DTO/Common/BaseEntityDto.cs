using RegistrarSuite.Core.Interfaces;
using System;


namespace RegistrarSuite.DTO.Common
{
    public class BaseEntityDto : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
