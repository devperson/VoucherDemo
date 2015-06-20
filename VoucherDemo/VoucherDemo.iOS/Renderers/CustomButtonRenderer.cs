using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xamarin.Forms;
using VoucherDemo.Controls;
using VoucherDemo.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using CoreGraphics;


[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace VoucherDemo.iOS.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            var elementButton = this.Element as CustomButton;
            if (elementButton.Type == "Orange")
                Control.Layer.InsertSublayer(CreateGradientColor("#FFFF9035", "#FFCB6E20", "#FFF6923F", Control.Bounds), 0);
            else Control.Layer.InsertSublayer(CreateGradientColor("#FF9CC646", "#FF769636", "#FF98B954", Control.Bounds), 0);
        }

        private CAGradientLayer CreateGradientColor(string color1, string color2, string borderColor, CGRect bounds)
        {
            var gradient = new CAGradientLayer();
            gradient.Frame = bounds;
            gradient.Colors = new CoreGraphics.CGColor[] { Color.FromHex(color1).ToCGColor(), Color.FromHex(color2).ToCGColor() };
            gradient.BorderColor = Color.FromHex(borderColor).ToCGColor();
            gradient.BorderWidth = 2;
            return gradient;
        }
    }

}