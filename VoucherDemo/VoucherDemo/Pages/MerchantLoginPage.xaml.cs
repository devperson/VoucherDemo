using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VoucherDemo.Pages
{
    public partial class MerchantLoginPage : BasePage
    {
        public MerchantLoginPage()
        {
            InitializeComponent();   
            
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new VoucherNumberPage(), true);
        }
    }
}
