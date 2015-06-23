using LaserList.VoucherDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VoucherDemo.Pages
{
    public partial class VoucherNumberPage : BasePage
    {
        public VoucherNumberPage()
        {
            InitializeComponent();            
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            int vaucher = 0;
            errContent.IsVisible = false;            
            if (int.TryParse(txtVoucher.Text.Trim(), out vaucher))
            {
                activity.IsVisible = true;
                App.MainVm.WebService.ValidateVoucher(App.MainVm.Sp_ID, vaucher, (res) =>
                {
                    activity.IsVisible = false;
                    if (res.allowed)
                    {
                        this.Navigation.PushAsync(new RedeemVoucherPage(this), true);
                    }
                    else
                    {
                        errContent.IsVisible = true;
                        lblText.Text = res.message;                
                    }
                });                
            }
            else
            {
                errContent.IsVisible = true;
                lblText.Text = "Please type numeric value.";                
            }
        }

        private async void Scan_Clicked(object sender, EventArgs e)
        {
            var scanner = DependencyService.Get<IQRCodeService>();
            var result = await scanner.Scan();
            txtVoucher.Text = result;
        }

        private void Stat_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new StatisticsPage());
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }

        public void Redeem()
        {
            activity.IsVisible = true;
            errContent.IsVisible = false;
            App.MainVm.WebService.Redeem(App.MainVm.Sp_ID, int.Parse(txtVoucher.Text.Trim()), (res) =>
            {
                activity.IsVisible = false;
                errContent.IsVisible = true;
                if (res.redeemed)
                    lblText.Text = "Vaucher successfully redeemed.";
                else                                 
                    lblText.Text = res.message;

                //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                //{
                //    Device.BeginInvokeOnMainThread(() =>
                //    {
                //        errContent.IsVisible = false;
                //    });                    
                //    return false;
                //});                
            });
        }
    }
}
