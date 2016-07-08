using System.Data.Entity;
using CompanyProject.Domain.Model;
using CompanyProject.Domain.ModelsConfiguration;

namespace CompanyProject.Domain.DataAccess
{
    public class CompanyDataContext : DbContext
    {
        public CompanyDataContext() : base ("CompanyDataConnection")
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<DataEntry> DataEntry { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            //modelBuilder.Configurations.Add(new MeetingConfiguration());
        }

    }
}
