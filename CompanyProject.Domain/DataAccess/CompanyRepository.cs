using System;
using System.Collections.Generic;
using System.Linq;
using CompanyProject.Domain.Model;

namespace CompanyProject.Domain.DataAccess
{
    public class CompanyRepository : IDisposable
    {
        private CompanyDataContext _dataContext;
        readonly List<Company> _company;

        public CompanyRepository()
        {
            if (_company == null)
            {
                _company = new List<Company>();
            }
            using (_dataContext = new CompanyDataContext())
            {
                _company = _dataContext.Company.Include("AppropriateProjects").ToList(); 
            }
        }

        public List<Company> GetCompanies()
        {
            return new List<Company>(_company);
        }
        public bool AddCompany(Company companyToAdd)
        {

            _company.Add(companyToAdd);
            
            try
            {
                using(_dataContext = new CompanyDataContext())
                {
                    _dataContext.Company.Add(companyToAdd);
                    _dataContext.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool UpdateCompany(int id, Project proj)
        {
            //Company comp = GetCompany(id);
            using (_dataContext = new CompanyDataContext())
            {
                var query = (from r in _dataContext.Company where r.CompanyId == id select r);
                foreach (var q in query)
                {
                    q.AppropriateProjects.Add(proj);
                }

                //db.Entry(comp).Collection(i => i.AppropriateProjects).Load();
                //comp.AppropriateProjects.Add(proj);
                try
                {
                    //db.Entry(comp).State = EntityState.Modified;
                    _dataContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                } 
            }
            return true;
        }

        public Company GetCompany(int id)
        {
            return _company.FirstOrDefault(i => i.CompanyId == id);
        }

        public bool UpdateComponent(Company currentGridSelectedItem)
        {
            using (_dataContext = new CompanyDataContext())
            {
                var query = (from r in _dataContext.Company where r.CompanyId == currentGridSelectedItem.CompanyId select r);

                foreach (var q in query)
                {
                    q.TitleCompany = currentGridSelectedItem.TitleCompany;
                }
                try
                {
                    _dataContext.SaveChanges();
                }
                catch
                {
                    return false;
                } 
            }

            return true;

        }

        public void Dispose()
        {
            ((IDisposable)_dataContext).Dispose();
        }
    }
}
