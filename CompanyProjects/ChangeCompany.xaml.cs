﻿using CompanyProjects.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CompanyProject.Domain.Model;

namespace CompanyProjects
{
    /// <summary>
    /// Interaction logic for ChangeCompany.xaml
    /// </summary>
    public partial class ChangeCompany : Window
    {
        public ChangeCompany(Company GridSelectedItem)
        {
            InitializeComponent();

            var variable = new ChangeCompanyViewModel(GridSelectedItem);
            this.DataContext = variable; // ovde se daje DataContext

            if (variable.CloseAction == null)
                variable.CloseAction = new Action(() => this.Close());
        }
    }
}
