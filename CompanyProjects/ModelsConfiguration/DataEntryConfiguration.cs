﻿using CompanyProjects.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjects.ModelsConfiguration
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
