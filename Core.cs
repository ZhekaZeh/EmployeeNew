using EmployeeViewer.Serialization;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace EmployeeViewer.Model
{
    public class Core
    {
        #region Private members

        private static Core _instance;

        #endregion

        #region Properties

        public static Core Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Core();
                }

                return _instance;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Loads the file.
        /// </summary>
        public ObservableCollection<Employee> LoadFromFile()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Binary File (.dat) |*.dat";
            openFileDialog.ShowDialog();

            try
            {
                using (FileStream stream = File.Open(openFileDialog.FileName, FileMode.Open))
                {
                    byte[] fileBytes = new byte[stream.Length];
                    stream.Read(fileBytes, 0, fileBytes.Length);
                    return Serializator.Deserialize(fileBytes);
                }
            }

            //For the case when was clicked "Load File" button, but was pressed "Cancel" button after that
            catch (ArgumentException) { return null; } 

                

        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        public void SaveToFile(ObservableCollection<Employee> employees)
        {
            
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = "BinaryFile";
            saveFileDialog.Filter = "Binary File (.dat)|*.dat"; 
            saveFileDialog.ShowDialog();
            try
            {
                byte[] serializedEmployees = Serializator.Serialize(employees);

                using (FileStream fileStream = File.Create(saveFileDialog.FileName))
                {
                    fileStream.Write(serializedEmployees, 0, serializedEmployees.Length);
                }
            }
            catch (ArgumentException) { }
       
        }

        #endregion
    }
}
