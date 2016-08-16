using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CompanyProject.Domain.Interfaces;
using CompanyProject.Domain.Model;
using Ninject;

namespace CompanyProjects
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            //ComposeObjects();
            //Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel();
            container.Bind<ICompany>().To<CustomCompany>().InTransientScope();
            container.Bind<CompanyProjectComponent>().ToSelf().InSingletonScope();
            container.Get<CompanyProjectComponent>();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<Loging>();
        }
    }
}
