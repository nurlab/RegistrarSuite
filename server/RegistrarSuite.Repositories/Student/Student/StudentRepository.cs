using System;
using System.Collections.Generic;
using System.Text;
using RegistrarSuite.Data.DataContext;
using RegistrarSuite.Repositories.Generics;

namespace RegistrarSuite.Repositories.Metadata
{
    public class StudentRepository : GRepository<Data.Models.StudentSchema.Student>, IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
