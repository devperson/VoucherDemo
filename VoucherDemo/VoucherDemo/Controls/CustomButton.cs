using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VoucherDemo.Controls
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
			this.FontSize = Device.OnPlatform (20, 25, 20);
            this.TextColor = Color.White;
        }
        public string Type { get; set; }
    }

    
}
