using System;
using System.Collections.Generic;
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
using EmployeeViewer.Model;

namespace EmployeeViewer
{
    /// <summary>
    /// Логика взаимодействия для EmployeeInfo.xaml
    /// </summary>
    public partial class EmployeeInfo : Window
    {
        Core core = new Core();

        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void SaveItem_Button_Click(object sender, RoutedEventArgs e)
        {
            core.SaveItem();
        }
    }
}
