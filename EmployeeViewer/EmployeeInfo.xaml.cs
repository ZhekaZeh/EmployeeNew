using System.Windows;
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
            DataContext = CurrentEmployee;
        }
        
        private void SaveItem_Button_Click(object sender, RoutedEventArgs e)
        {
            //core.SaveItem();
            DataContext = CurrentEmployee;
        }

        private void Closed_Button_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
