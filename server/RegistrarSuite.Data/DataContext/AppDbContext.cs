using Microsoft.EntityFrameworkCore;
using RegistrarSuite.Data.Models.MetadataSchema;
using RegistrarSuite.Data.Models.StudentSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarSuite.Data.DataContext
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
