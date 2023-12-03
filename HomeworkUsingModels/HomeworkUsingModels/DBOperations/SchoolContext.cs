using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using HomeworkUsingModels.Entities;

namespace HomeworkUsingModels.DBOperations
{
    public partial class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SchoolDb");
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
    }
}
