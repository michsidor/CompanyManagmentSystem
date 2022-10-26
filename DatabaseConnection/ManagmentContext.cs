using System;
using Managment.Models;
using Microsoft.EntityFrameworkCore;

namespace Managment
{
    public class ManagmentContext : DbContext
    {
        public  DbSet<EmployeeBasicData> EmployeeBasicDataSet { get; set; }
        public  DbSet<EmployeeExtensionData> EmployeeExtensionDataSet { get; set; }
        public  DbSet<ProjectsData> ProjectsDataSet { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=ManagmentOfficial;User=sa; Password=strongPassword123");
        }
    }
}

