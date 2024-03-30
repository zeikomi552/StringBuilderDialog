using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StringBuilderDialog.ViewModels
{
    internal class MSSQLServerDialogVM : ViewModelBase
    {
        #region 接続文字列生成[ConnectionStringBuilder]プロパティ
        /// <summary>
        /// 接続文字列生成[ConnectionStringBuilder]プロパティ用変数
        /// </summary>
        SqlConnectionStringBuilder _ConnectionStringBuilder = new SqlConnectionStringBuilder();
        /// <summary>
        /// 接続文字列生成[ConnectionStringBuilder]プロパティ
        /// </summary>
        public SqlConnectionStringBuilder ConnectionStringBuilder
        {
            get
            {
                return _ConnectionStringBuilder;
            }
            set
            {
                if (_ConnectionStringBuilder == null || !_ConnectionStringBuilder.Equals(value))
                {
                    _ConnectionStringBuilder = value;
                    NotifyPropertyChanged("ConnectionStringBuilder");
                }
            }
        }
        #endregion

        #region ユーザーID[UserID]プロパティ
        /// <summary>
        /// ユーザーID[UserID]プロパティ
        /// </summary>
        public string UserID
        {
            get
            {
                return _ConnectionStringBuilder.UserID;
            }
            set
            {
                if (_ConnectionStringBuilder.UserID == null || !_ConnectionStringBuilder.UserID.Equals(value))
                {
                    _ConnectionStringBuilder.UserID = value;
                    NotifyPropertyChanged("UserID");
                }
            }
        }
        #endregion

        #region パスワード[Password]プロパティ
        /// <summary>
        /// パスワード[Password]プロパティ
        /// </summary>
        public string Password
        {
            get
            {
                return _ConnectionStringBuilder.Password;
            }
            set
            {
                if (_ConnectionStringBuilder.Password == null || !_ConnectionStringBuilder.Password.Equals(value))
                {
                    _ConnectionStringBuilder.Password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }
        #endregion

        #region データソース[DataSource]プロパティ
        /// <summary>
        /// データソース[DataSource]プロパティ用変数
        /// </summary>
        string _DataSource = string.Empty;
        /// <summary>
        /// データソース[DataSource]プロパティ
        /// </summary>
        public string DataSource
        {
            get
            {
                return _ConnectionStringBuilder.DataSource;
            }
            set
            {
                if (_ConnectionStringBuilder.DataSource == null || !_ConnectionStringBuilder.DataSource.Equals(value))
                {
                    _ConnectionStringBuilder.DataSource = value;
                    NotifyPropertyChanged("DataSource");
                }
            }
        }
        #endregion

        #region データベース[InitialCatalog]プロパティ
        /// <summary>
        /// データベース[InitialCatalog]プロパティ用変数
        /// </summary>
        string _InitialCatalog = string.Empty;
        /// <summary>
        /// データベース[InitialCatalog]プロパティ
        /// </summary>
        public string InitialCatalog
        {
            get
            {
                return _ConnectionStringBuilder.InitialCatalog;
            }
            set
            {
                if (_ConnectionStringBuilder.InitialCatalog == null || !_ConnectionStringBuilder.InitialCatalog.Equals(value))
                {
                    _ConnectionStringBuilder.InitialCatalog = value;
                    NotifyPropertyChanged("InitialCatalog");
                }
            }
        }
        #endregion

        #region IntegratedSecurity[IntegratedSecurity]プロパティ
        /// <summary>
        /// IntegratedSecurity[IntegratedSecurity]プロパティ
        /// </summary>
        public bool IntegratedSecurity
        {
            get
            {
                return _ConnectionStringBuilder.IntegratedSecurity;
            }
            set
            {
                if (!_ConnectionStringBuilder.IntegratedSecurity.Equals(value))
                {
                    _ConnectionStringBuilder.IntegratedSecurity = value;
                    NotifyPropertyChanged("IntegratedSecurity");
                }
            }
        }
        #endregion

        #region 暗号化[Encrypt]プロパティ
        /// <summary>
        /// 暗号化[Encrypt]プロパティ
        /// </summary>
        public bool Encrypt
        {
            get
            {
                return _ConnectionStringBuilder.Encrypt;
            }
            set
            {
                if (!_ConnectionStringBuilder.Encrypt.Equals(value))
                {
                    _ConnectionStringBuilder.Encrypt = value;
                    NotifyPropertyChanged("Encrypt");
                }
            }
        }
        #endregion

        #region サーバーを常に信頼する[TrustServerCertificate]プロパティ
        /// <summary>
        /// サーバーを常に信頼する[TrustServerCertificate]プロパティ
        /// </summary>
        public bool TrustServerCertificate
        {
            get
            {
                return _ConnectionStringBuilder.TrustServerCertificate;
            }
            set
            {
                if (!_ConnectionStringBuilder.TrustServerCertificate.Equals(value))
                {
                    _ConnectionStringBuilder.TrustServerCertificate = value;
                    NotifyPropertyChanged("TrustServerCertificate");
                }
            }
        }
        #endregion

        #region 初期化処理
        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init()
        {
            try
            {
                PropertyInfo[] props = typeof(MSSQLServerDialogVM).GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    NotifyPropertyChanged(prop.Name);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region OKボタンが押された
        /// <summary>
        /// OKボタンが押された
        /// </summary>
        public void OnOK()
        {
            this.DialogResult = true;
        }
        #endregion

        #region キャンセルボタンが押された
        /// <summary>
        /// キャンセルボタンが押された
        /// </summary>
        public void OnCancel()
        {
            this.DialogResult = false;
        }
        #endregion

        #region 接続確認
        /// <summary>
        /// 接続確認
        /// </summary>
        public void Connect()
        {
            try
            {
                string constr = this.ConnectionStringBuilder.ConnectionString;

                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    con.Close();

                    StringBuilder msg = new StringBuilder();
                    msg.AppendLine("成功しました");
                    MessageBox.Show(msg.ToString(), "確認", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception e)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine("接続に失敗しました。");
                msg.AppendLine();
                msg.AppendLine(e.Message);

                MessageBox.Show(msg.ToString(), "確認", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion


    }
}
