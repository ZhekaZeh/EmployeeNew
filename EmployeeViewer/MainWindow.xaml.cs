using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    public partial class MainWindow : Window
    {

        #region Properties

        public ObservableCollection<Employee> Employees { get; set; }

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            //ViewModel = new MainWindowViewModel();
            Employees = new ObservableCollection<Employee>();
            DataContext = this;
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

        #endregion

    }
}
