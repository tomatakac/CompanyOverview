using System.Data.Entity.ModelConfiguration;
using CompanyProject.Domain.Model;

namespace CompanyProject.Domain.ModelsConfiguration
{
    public class DataEntryConfiguration : EntityTypeConfiguration<DataEntry>
    {
        public DataEntryConfiguration()
        {
            //this.HasRequired(a => a.AppropriateCompany)
            //               .WithMany(r => r.AppropriateDataEntries)
            //               .HasForeignKey(u => u.FKCompanyId)
            //               .WillCascadeOnDelete(true);
        }
    }
}
