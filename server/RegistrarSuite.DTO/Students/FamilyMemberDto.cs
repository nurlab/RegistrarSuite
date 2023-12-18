using RegistrarSuite.DTO.Common;
using RegistrarSuite.Core.Enums;
using RegistrarSuite.DTO.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarSuite.DTO.Students
{
    public class FamilyMemberDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public RelationshipType Relationship { get; set; }
        public string NationalityCode { get; set; }

    }    
    public class FamilyMemberBasicDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required RelationshipType Relationship { get; set; }
    }
    public class FamilyMemberBasicResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public RelationshipType Relationship { get; set; }
    }

}
