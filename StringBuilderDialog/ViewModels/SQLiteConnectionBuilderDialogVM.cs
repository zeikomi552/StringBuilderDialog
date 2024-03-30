using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StringBuilderDialog.ViewModels
{
    internal class SQLiteConnectionBuilderDialogVM: ViewModelBase
    {
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

        #region 初期化処理
        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Init()
        {
            try
            {
                PropertyInfo[] props = typeof(SQLiteConnectionBuilderDialogVM).GetProperties();
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

        #region ファイルを選択する
        /// <summary>
        /// ファイルを選択する
        /// </summary>
        public void OpenFile()
        {
            try
            {
                // ダイアログのインスタンスを生成
                var dialog = new OpenFileDialog();

                // ファイルの種類を設定
                dialog.Filter = "全てのファイル (*.*)|*.*";

                // ダイアログを表示する
                if (dialog.ShowDialog() == true)
                {
                    // 選択されたファイル名 (ファイルパス) をセット
                    this.DataSource = dialog.FileName;
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
                var connection = new SqliteConnection($"{this.ConnectionStringBuilder.ConnectionString}");
                {
                    connection.Open();
                    connection.Close();

                    StringBuilder msg = new StringBuilder();
                    msg.AppendLine("成功しました");
                    MessageBox.Show(msg.ToString(), "確認", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch (Exception e)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine("接続に失敗しました。");
                msg.AppendLine();
                msg.AppendLine(e.Message);

                MessageBox.Show(msg.ToString(), "確認", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region 接続文字列生成[ConnectionStringBuilder]プロパティ
        /// <summary>
        /// 接続文字列生成[ConnectionStringBuilder]プロパティ用変数
        /// </summary>
        SqliteConnectionStringBuilder _ConnectionStringBuilder = new SqliteConnectionStringBuilder();
        /// <summary>
        /// 接続文字列生成[ConnectionStringBuilder]プロパティ
        /// </summary>
        public SqliteConnectionStringBuilder ConnectionStringBuilder
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


    }
}
