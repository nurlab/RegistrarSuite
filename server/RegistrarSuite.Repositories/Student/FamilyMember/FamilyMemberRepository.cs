using System;
using System.Collections.Generic;
using System.Text;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Repositories.Generics;

namespace RegistrarSuite.Repositories.Metadata
{
    public class FamilyMemberRepository : GRepository<Data.Models.StudentSchema.FamilyMember>, IFamilyMemberRepository
    {
        private readonly AppDbContext _appDbContext;
        public FamilyMemberRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
