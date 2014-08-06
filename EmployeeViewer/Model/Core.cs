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
        public void LoadFile()
        {
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        public void SaveFile()
        {
        }

        #endregion
    }
}
