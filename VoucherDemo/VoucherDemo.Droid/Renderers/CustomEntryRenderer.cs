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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

using VoucherDemo.Droid.Renderers;
using VoucherDemo.Controls;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace VoucherDemo.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var editText = Control as EditText;
            editText.SetBackgroundResource(Resource.Drawable.textbox);
            editText.SetPadding(10, 5, 10, 5);
            editText.SetTextColor(Color.Black.ToAndroid());
        }
    }
}