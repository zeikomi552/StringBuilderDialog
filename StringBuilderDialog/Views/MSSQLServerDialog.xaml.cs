using Microsoft.Data.SqlClient;
using StringBuilderDialog.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Binding = System.Windows.Data.Binding;

namespace StringBuilderDialog.Views
{
    /// <summary>
    /// MSSQLServerDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class MSSQLServerDialog : Window
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MSSQLServerDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Titleの設定処理
        /// <summary>
        /// Titleの設定処理
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.Title = title;
        }
        #endregion

        #region Builderの設定処理
        /// <summary>
        /// Builderの設定処理
        /// </summary>
        /// <param name="connectionString">接続文字列(ConnectionString)</param>
        public void SetConnectionString(string connectionString)
        {
            var vm = this.DataContext as MSSQLServerDialogVM;

            if (vm != null)
            {
                vm.ConnectionStringBuilder.ConnectionString = connectionString;
            }
        }
        #endregion

        #region ConnectionStringの取得処理
        /// <summary>
        /// ConnectionStringの取得処理
        /// </summary>
        /// <returns>接続文字列(ConnectionString)</returns>
        public string GetConnectionString()
        {
            var vm = this.DataContext as MSSQLServerDialogVM;

            if (vm != null)
            {
                return vm.ConnectionStringBuilder.ConnectionString;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
