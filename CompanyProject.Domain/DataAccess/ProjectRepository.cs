using System;
using System.Collections.Generic;
using System.Linq;
using CompanyProject.Domain.Model;

namespace CompanyProject.Domain.DataAccess
{
    public class ProjectRepository : IDisposable
    {
        private CompanyDataContext _dataContext;
        private CompanyRepository compRepo = new CompanyRepository();

        readonly List<Project> _project;

        public ProjectRepository()
        {
            if (_project == null)
            {
                _project = new List<Project>();
            }
            //_project = _dataContext.Project.ToList();
            _project = _dataContext.Project.Include("AppropriateCompany").ToList();
        }
        public List<Project> GetProjects()
        {
            return new List<Project>(_project);
        }
        public Project GetProject(int id)
        {
            using (_dataContext = new CompanyDataContext())
            {
                return _dataContext.Project.FirstOrDefault(i => i.ProjectId == id); 
            }
        }
        public bool AddProject(Project projectToAdd, Company CompanySelectedValue)
        {
            _project.Add(projectToAdd);
            try
            {
                using (_dataContext = new CompanyDataContext())
                {
                    _dataContext.Project.Add(projectToAdd);
                    _dataContext.SaveChanges(); 
                }
            }
            catch
            {
                return false;
            }
            //try
            //{
            //    _dataContext.Entry(CompanySelectedValue).State = EntityState.Modified;
            //    _dataContext.SaveChanges();
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}

            //_dataContext.Entry(projectToAdd).Property(i=>i.AppropriateCompany);
            //_dataContext.Entry(oz).Collection(i => i.MaticneStavkeOtpremnice).Load();

            return true;
        }
        public bool UpdateProject(Project projectToChange)
        {
            using (_dataContext = new CompanyDataContext())
            {
                var query = (from r in _dataContext.Project where r.ProjectId == projectToChange.ProjectId select r);
                foreach (var q in query)
                {
                    q.TitleProject = projectToChange.TitleProject;
                    q.TextProject = projectToChange.TextProject;
                    q.StartDate = projectToChange.StartDate;
                    q.EndDate = projectToChange.EndDate;
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

        public IQueryable<Project> GetProjectBasedOnCompanyId(int companyId)
        {
            using (_dataContext = new CompanyDataContext())
            {
                IQueryable<Project> var = _dataContext.Project.Where(q => q.FKCompanyId == companyId).Select(q => q);

                return var; 
            }
        }

        public void Dispose()
        {
            ((IDisposable)_dataContext).Dispose();
        }
    }
}