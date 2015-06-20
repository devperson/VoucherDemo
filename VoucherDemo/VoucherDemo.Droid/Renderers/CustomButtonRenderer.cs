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
using Android.Graphics.Drawables;
using Xamarin.Forms;
using VoucherDemo.Controls;
using VoucherDemo.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace VoucherDemo.Droid.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var elementButton = this.Element as CustomButton;
            if (elementButton.Type == "Orange")
                Control.SetBackgroundDrawable(CreateGradientColor("#FFFF9035", "#FFCB6E20", "#FFF6923F"));
            else Control.SetBackgroundDrawable(CreateGradientColor("#FF9CC646", "#FF769636", "#FF98B954"));
        }

        private GradientDrawable CreateGradientColor(string color1, string color2, string borderColor)
        {
            GradientDrawable gd = new GradientDrawable(
            GradientDrawable.Orientation.TopBottom,
            new int[] { Color.FromHex(color1).ToAndroid().ToArgb(), Color.FromHex(color2).ToAndroid().ToArgb() });
            gd.SetCornerRadius(0f);
            gd.SetStroke(5, Color.FromHex(borderColor).ToAndroid());
            return gd;
        }
    }

}