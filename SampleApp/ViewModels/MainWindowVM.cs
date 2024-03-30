using StringBuilderDialog.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SampleApp.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public void OpenSQLServerStringConnection()
        {
            try
            {
                MSSQLServerDialog wnd = new MSSQLServerDialog();
                string connectionString = @"Data Source=TANE2\SQLEXPRESS;Initial Catalog=AdventureWorks2019;User ID=testuser;Password=testuser;Encrypt=False;Trust Server Certificate=True";

                wnd.SetConnectionString(connectionString);

                if (wnd.ShowDialog() == true)
                {
                    MessageBox.Show(wnd.GetConnectionString());
                }

            }
            catch
            {
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
