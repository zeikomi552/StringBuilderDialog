using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderDialog.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        #region DialogResult[DialogResult]プロパティ
        /// <summary>
        /// DialogResult[DialogResult]プロパティ用変数
        /// </summary>
        bool? _DialogResult = null;
        /// <summary>
        /// DialogResult[DialogResult]プロパティ
        /// </summary>
        public bool? DialogResult
        {
            get
            {
                return _DialogResult;
            }
            set
            {
                if (_DialogResult == null || !_DialogResult.Equals(value))
                {
                    _DialogResult = value;
                    NotifyPropertyChanged("DialogResult");
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
