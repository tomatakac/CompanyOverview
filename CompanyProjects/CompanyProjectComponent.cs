using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain.Interfaces;
using CompanyProjects.ViewModel;

namespace CompanyProjects
{
    public class CompanyProjectComponent
    {         
        public CompanyProjectComponent(ICompany company)
        {
            _company = company;
            _mainWindowViewModel = new MainViewModel();
            var mainWindow = new MainWindow {DataContext = _mainWindowViewModel };
            _loginViewModel = new LoginViewModel();
            var loginWindow = new Loging {DataContext = _loginViewModel};
            loginWindow.ShowDialog();
        }

        private ICompany _company;
        private MainViewModel _mainWindowViewModel;
        private LoginViewModel _loginViewModel;
    }
}
