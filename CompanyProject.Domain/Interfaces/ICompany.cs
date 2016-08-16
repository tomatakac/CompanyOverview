using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.Model;

namespace CompanyProject.Domain.Interfaces
{
    public interface ICompany
    {
        IList<Project> AppropriateProjects();
        int CompanyId { get; set; }
        string TitleCompany { get; set; }
    }
}
