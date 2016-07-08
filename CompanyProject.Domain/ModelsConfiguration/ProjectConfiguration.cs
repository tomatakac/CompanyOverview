using System.Data.Entity.ModelConfiguration;
using CompanyProject.Domain.Model;

namespace CompanyProject.Domain.ModelsConfiguration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            this.HasRequired(a => a.AppropriateCompany)
                           .WithMany(r => r.AppropriateProjects)
                           .HasForeignKey(u => u.FKCompanyId)
                           .WillCascadeOnDelete(true);
        }
    }
}
