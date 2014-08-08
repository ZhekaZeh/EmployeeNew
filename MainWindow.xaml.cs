﻿using System.Collections.ObjectModel;
using System.Windows;
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    public partial class MainWindow : Window
    {
        #region Properties
        
        private static ObservableCollection<Employee> Employees { get; set; }

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>();            
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

        private void DoubleClick_On_Item(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditItem();
        }

        private void SaveFile_Click_Button(object sender, RoutedEventArgs e)
        {
            Core.Instance.SaveToFile(Employees);
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            Employees = Core.Instance.LoadFromFile();
            MainDataGrid.ItemsSource = Employees;
        }


        #endregion

        #region Public methods

        /// <summary>
        /// Adds the item.
        /// </summary>
        public void AddItem()
        {
            var employeeInfo = new EmployeeInfo();

            if (employeeInfo.ShowDialog() == true & employeeInfo.CurrentEmployee != null)
            {
                var employee = employeeInfo.CurrentEmployee;
                Employees.Add(employeeInfo.CurrentEmployee);
            };            
        }

        /// <summary>
        /// Removes selected item.
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
        /// Edits selected item.
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



    }
}
