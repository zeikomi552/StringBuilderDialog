using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StringBuilderDialog.Common.Helpers
{
    internal static class DialogResultHelper
    {
        /// <summary>
        /// ViewModelから制御するための依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogResultHelper),
                new PropertyMetadata((d, e) =>
                {
                    var window = d as Window;
                    if (window != null)
                    {
                        //ここ（コールバック）でWindowのDialogResultプロパティを設定（画面が閉じられる）
                        window.DialogResult = e.NewValue as bool?;
                    }
                }));

        /// <summary>
        /// Xamlから添付プロパティとして設定させるためのメソッド
        /// </summary>
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
