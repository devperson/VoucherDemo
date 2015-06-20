using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xamarin.Forms;

using VoucherDemo.Droid.Renderers;
using VoucherDemo.Controls;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace VoucherDemo.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            
            Control.Layer.BorderColor = UIColor.FromRGB(79, 129, 189).CGColor;
            Control.Layer.BorderWidth = 2;
            Control.Layer.CornerRadius = 0;
        }
    }
}