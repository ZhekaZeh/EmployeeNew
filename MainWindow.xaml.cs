using System.Collections.ObjectModel;
using System.Windows;
using EmployeeViewer.Model;
using log4net;

namespace EmployeeViewer
{
    public partial class MainWindow : Window
    {
        #region Properties
        
        private static ObservableCollection<Employee> Employees { get; set; }

        #endregion

        #region Public fields

        public static readonly ILog log = LogManager.GetLogger(typeof(MainWindow));

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>();            
            MainDataGrid.ItemsSource = Employees;
            log4net.Config.XmlConfigurator.Configure();
        }

        #endregion

        #region Private methods

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
            log.Info("Add item");
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem();
            log.Info("Remove item");
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
            log.Info("Save to file");
        }

        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            Employees = Core.Instance.LoadFromFile();
            MainDataGrid.ItemsSource = Employees;
            log.Info("Load from file");
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
            }
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
