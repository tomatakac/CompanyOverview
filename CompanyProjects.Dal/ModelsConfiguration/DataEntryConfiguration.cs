using System.Data.Entity.ModelConfiguration;
using CompanyProjects.Dal.Model;

namespace CompanyProjects.Dal.ModelsConfiguration
{
    class DataEntryConfiguration : EntityTypeConfiguration<DataEntry>
    {
        internal DataEntryConfiguration()
        {
            //this.HasRequired(a => a.AppropriateCompany)
            //               .WithMany(r => r.AppropriateDataEntries)
            //               .HasForeignKey(u => u.FKCompanyId)
            //               .WillCascadeOnDelete(true);
        }
    }
}
