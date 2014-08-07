using System;
using EmployeeViewer.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace EmployeeViewer.Serialization

{
    [Serializable]
    public class Serializator
    {
        private static ObservableCollection<Employee> Employees { get; set; }
        private string _path;
        public Serializator(string path) { this._path = path; }
        public FileStream Serialize() 
        {
            Employees = MainWindow.Employees;

            using (FileStream fileStream = File.Create(_path))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, Employees);
                return fileStream;
                                
            }
        }
        public void UnSerialize()
        {

        }
    }
}
