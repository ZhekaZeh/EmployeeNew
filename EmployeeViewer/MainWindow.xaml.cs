﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    public partial class MainWindow : Window
    {
        #region Private members

        private Core core;

        #endregion

        #region Properties

        public static ObservableCollection<Employee> Employees { get; set; }

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            core = new Core();
            //ViewModel = new MainWindowViewModel();
            Employees = new ObservableCollection<Employee>();
            //DataContext = this;
            MainDataGrid.ItemsSource = Employees;   
        }

        #endregion

        #region Private methods

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            EditItem();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds the item.
        /// </summary>
        public void AddItem()
        {
            var employeeInfo = new EmployeeInfo();
            employeeInfo.ShowDialog();

            var employee = employeeInfo.CurrentEmployee;
            if (employee != null)
                Employees.Add(employee);
        }

        /// <summary>
        /// Removes selected item
        /// </summary>
        public void RemoveItem()
        {
            if (MainDataGrid.SelectedIndex >= 0)
            {
                Employee employee = MainDataGrid.SelectedItem as Employee;
                Employees.Remove(employee);
            }
        }

        /// <summary>
        /// Edits selected item
        /// </summary>
        public void EditItem()
        {
            if (MainDataGrid.SelectedIndex >= 0)
            {
                Employee employee = MainDataGrid.SelectedItem as Employee;
                var employeeInfo = new EmployeeInfo();
                employeeInfo.DataContext = employee;
                employeeInfo.ShowDialog();
            }
        }

        #endregion

        private void SaveFile_Click_Button(object sender, RoutedEventArgs e)
        {
            core.SaveFile();
        }

        private void Edit_Double_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditItem();
        }

    }
}
