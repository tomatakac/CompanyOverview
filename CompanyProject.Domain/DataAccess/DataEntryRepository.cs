using System;
using System.Collections.Generic;
using System.Linq;
using CompanyProject.Domain.Model;

namespace CompanyProject.Domain.DataAccess
{
    public class DataEntryRepository : IDisposable
    {
        private CompanyDataContext _dataContext;
        readonly List<DataEntry> _dataEntry;
        public DataEntryRepository()
        {
            if (_dataEntry == null)
            {
                _dataEntry = new List<DataEntry>();
            }
            using (_dataContext = new CompanyDataContext())
            {
                _dataEntry = _dataContext.DataEntry.ToList(); 
            }
        }
        public List<DataEntry> GetDataEntry()
        {
            return new List<DataEntry>(_dataEntry);
        }
        public bool AddDataEntry(DataEntry dataEntryToAdd)
        {

            _dataEntry.Add(dataEntryToAdd);
            try
            {
                using (_dataContext = new CompanyDataContext())
                {
                    _dataContext.DataEntry.Add(dataEntryToAdd);
                    _dataContext.SaveChanges(); 
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool RemoveDataEntry(DataEntry dataEntryToAdd)
        {

            _dataEntry.Remove(dataEntryToAdd);
            try
            {
                using (_dataContext = new CompanyDataContext())
                {
                    _dataContext.DataEntry.Remove(dataEntryToAdd);
                    _dataContext.SaveChanges(); 
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool UpdateDataEntry(DataEntry CurrentGridSelectedItem)
        {
            using (_dataContext = new CompanyDataContext())
            {
                var query = (from r in _dataContext.DataEntry where r.DataEntryId == CurrentGridSelectedItem.DataEntryId select r);
                foreach (var q in query)
                {
                    q.CompanyId = CurrentGridSelectedItem.CompanyId;
                    q.CompanyTitle = CurrentGridSelectedItem.CompanyTitle;
                    q.DataProject = CurrentGridSelectedItem.DataProject;
                    q.Date = CurrentGridSelectedItem.Date;
                    q.ProjectId = CurrentGridSelectedItem.ProjectId;
                    q.ProjectTitle = CurrentGridSelectedItem.ProjectTitle;
                    q.TextInput = CurrentGridSelectedItem.TextInput;
                    q.TitleDataProject = CurrentGridSelectedItem.TitleDataProject;
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
        public bool UpdateDataEntryCompanyName(Company CurrentGridSelectedItem)
        {
            using (_dataContext = new CompanyDataContext())
            {
                var query = (from r in _dataContext.DataEntry where r.CompanyId == CurrentGridSelectedItem.CompanyId select r);

                foreach (var q in query)
                {
                    q.CompanyTitle = CurrentGridSelectedItem.TitleCompany;
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
        public bool UpdateDataEntryProjectName(Project CurrentGridSelectedItem)
        {
            using (_dataContext = new CompanyDataContext())
            {
                var query = (from r in _dataContext.DataEntry where r.ProjectId == CurrentGridSelectedItem.ProjectId select r);

                foreach (var q in query)
                {
                    q.ProjectTitle = CurrentGridSelectedItem.TitleProject;
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
