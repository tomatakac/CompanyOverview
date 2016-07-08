using System.Data.Entity.ModelConfiguration;
using CompanyProjects.Dal.Model;

namespace CompanyProjects.Dal.ModelsConfiguration
{
    class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        internal ProjectConfiguration()
        {
            this.HasRequired(a => a.AppropriateCompany)
                           .WithMany(r => r.AppropriateProjects)
                           .HasForeignKey(u => u.FKCompanyId)
                           .WillCascadeOnDelete(true);
        }
    }
}
