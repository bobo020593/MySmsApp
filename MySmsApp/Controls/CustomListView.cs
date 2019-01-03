using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MySmsApp.Controls
{
    public class CustomListView : ListView
    {
        public static readonly BindableProperty LongTappedProperty =
        BindableProperty.CreateAttached("LongTapped", typeof(ICommand), typeof(CustomListView), null, BindingMode.TwoWay);

        public void OnLongTapped(object v)
        {
            (GetValue(LongTappedProperty) as ICommand)?.Execute(v);
        }

    }
}
