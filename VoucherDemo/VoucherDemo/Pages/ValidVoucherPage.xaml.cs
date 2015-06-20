using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VoucherDemo.Pages
{
    public partial class ValidVoucherPage : BasePage
    {
        public ValidVoucherPage()
        {
            InitializeComponent();
        }

        private void Redeem_Clicked(object sender, EventArgs e)
        {
            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }
    }
}
