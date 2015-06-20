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
using VoucherDemo.Pages;
using VoucherDemo.Droid.Renderers;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(BasePage), typeof(BasePageRenderer))]
namespace VoucherDemo.Droid.Renderers
{
    public class BasePageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
        {
            base.OnElementChanged(e);
            this.SetBackgroundDrawable(CreateGradientColor());
        }

        private GradientDrawable CreateGradientColor()
        {
            GradientDrawable gd = new GradientDrawable(
            GradientDrawable.Orientation.TopBottom,
            new int[] { Color.FromHex("#FFEEF5FF").ToAndroid().ToArgb(), Color.FromHex("#FFBEDBFF").ToAndroid().ToArgb() });
            gd.SetCornerRadius(0f);
            
            return gd;
        }
    }
}