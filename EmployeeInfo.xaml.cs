using System.Windows;
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    public partial class EmployeeInfo : Window
    {
        #region Properties

        public Employee CurrentEmployee { get; set; }

        #endregion

        #region Constructor

        public EmployeeInfo()
        {
            InitializeComponent();
            CurrentEmployee = new Employee();
            if (CurrentEmployee != null)
                DataContext = CurrentEmployee;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// SaveButton's Click event is handled by this event handler
        /// </summary>
        private void SaveItem_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// ClearButton's Click event is handled by this event handler
        /// </summary>
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = default(Employee);
            CurrentEmployee = null;
        }

        /// <summary>
        /// CancelButton's Click event is handled by this event handler
        /// </summary>
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
    }
}
