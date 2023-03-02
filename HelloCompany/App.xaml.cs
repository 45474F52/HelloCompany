using HelloCompany.Model.DataBase;
using System.Windows;

namespace HelloCompany
{
    public partial class App : Application
    {
        #region Singleton DBContext
        private static volatile DataBaseContext _dbContext;
        private static readonly object _syncRoot1 = new object();
        public static DataBaseContext DBContext
        {
            get
            {
                if (_dbContext == null)
                {
                    lock (_syncRoot1)
                    {
                        if (_dbContext == null)
                        {
                            _dbContext = new DataBaseContext();
                        }
                    }
                }

                return _dbContext;
            }
        }
        #endregion Singleton DBContext
    }
}