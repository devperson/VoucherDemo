using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VoucherDemo.Pages
{
    public partial class RedeemVoucherPage : BasePage
    {
        VoucherNumberPage _prevPage;
        public RedeemVoucherPage(VoucherNumberPage prevPage)
        {
            _prevPage = prevPage;
            InitializeComponent();
        }

        private void Redeem_Clicked(object sender, EventArgs e)
        {
            _prevPage.Redeem();
            this.Navigation.PopAsync(true);            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }
    }
}
