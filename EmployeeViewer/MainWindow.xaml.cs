using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    /// <summary>
    ///NO RUSSIAN IN THE CODE!
    /// </summary>
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
        }

        #endregion

        #region Private methods

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

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

        #endregion
    }
}
