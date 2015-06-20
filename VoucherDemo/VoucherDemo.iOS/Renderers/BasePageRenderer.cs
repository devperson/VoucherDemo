using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xamarin.Forms;
using VoucherDemo.Pages;
using VoucherDemo.Droid.Renderers;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;


[assembly: ExportRenderer(typeof(BasePage), typeof(BasePageRenderer))]
namespace VoucherDemo.Droid.Renderers
{
    public class BasePageRenderer : PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.View.Layer.InsertSublayer(CreateGradientColor(), 0);
        }

        private CAGradientLayer CreateGradientColor()
        {
            var gradient = new CAGradientLayer();
            gradient.Frame = this.View.Bounds;
            gradient.Colors = new CoreGraphics.CGColor[] { Color.FromHex("#FFEEF5FF").ToCGColor(), Color.FromHex("#FFBEDBFF").ToCGColor() };
            //[view.layer insertSublayer:gradient atIndex:0];

            return gradient;
        }
    }
}