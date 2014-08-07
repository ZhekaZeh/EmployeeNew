﻿using System.Windows;
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    public partial class EmployeeInfo : Window
    {
        public Employee CurrentEmployee { get; set; }

        public EmployeeInfo()
        {
            InitializeComponent();
            CurrentEmployee = new Employee();
            if (CurrentEmployee != null)
            DataContext = CurrentEmployee;
        }
        
        private void SaveItem_Button_Click(object sender, RoutedEventArgs e)
        {
            //core.SaveItem();
            CurrentEmployee = new Employee();
            
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = default(Employee); // must be fixed
        }
    }
}
