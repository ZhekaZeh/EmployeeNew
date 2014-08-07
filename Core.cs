using EmployeeViewer.Serialization;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace EmployeeViewer.Model
{
    public class Core
    {
        #region Private members

        private static Core _instance;

        private Serializator serializator;

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
        public void LoadFromFile()
        {
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        public void SaveToFile(ObservableCollection<Employee> employees)
        {
            
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.FileName = "BinaryFile"; 
            saveFileDialog.Filter = "Text documents (.dat)|*.dat"; 
            saveFileDialog.ShowDialog();

            byte[] serializedEmployyes = Serializator.Serialize(employees);

            using (FileStream fileStream = File.Create(saveFileDialog.FileName))
            {
                fileStream.Write(serializedEmployyes,0,serializedEmployyes.Length);
            }            
        }

        #endregion
    }
}
