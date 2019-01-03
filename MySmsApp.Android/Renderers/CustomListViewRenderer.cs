using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySmsApp.Controls;
using MySmsApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace MySmsApp.Droid.Renderers
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        public CustomListViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                CustomListView view = (CustomListView)e.NewElement;
                Control.ItemLongClick += (s, args) =>
                {
                    Control.SetItemChecked(args.Position, true);
                    Java.Lang.Object item = Control.GetItemAtPosition(args.Position);
                    view.OnLongTapped(item.GetType().GetProperty("Instance").GetValue(item));
                };
            }
        }
    }
}