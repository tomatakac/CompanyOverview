using System.Data.Entity;
using CompanyProjects.Dal.Model;
using CompanyProjects.Dal.ModelsConfiguration;

namespace CompanyProjects.Dal.DataAccess
{
    class CompanyDataContext : DbContext
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
