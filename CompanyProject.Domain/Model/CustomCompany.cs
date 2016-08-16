using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.Domain.Model
{
    public class CustomCompany : ICompany
    {
        public IList<Project> AppropriateProjects()
        {
            throw new NotImplementedException();
        }

        public int CompanyId { get; set; }
        public string TitleCompany { get; set; }
    }
}
