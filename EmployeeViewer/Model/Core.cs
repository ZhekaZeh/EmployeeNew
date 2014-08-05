using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeViewer.Model
{
    class Core
    {
        public void LoadFile() { }
        public void SaveFile() { }

        public void AddItem()
        {
            EmployeeInfo employeeInfo = new EmployeeInfo();
            employeeInfo.ShowDialog();
        }
        public void SaveItem()
        {
            MessageBox.Show("Hello");
        }

        public void RemoveItem() { }
        public void EditItem() { }
    }
}
