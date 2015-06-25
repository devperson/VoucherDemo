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
            errContent.IsVisible = false;
            long num = 0;
            if (long.TryParse(txt.Text, out num))
            {
                activity.IsVisible = true;
                App.MainVm.WebService.Login(num, (result) =>
                {
                    activity.IsVisible = false;
                    if (result)
                    {
                        App.MainVm.Sp_ID = num;
                        txt.Text = "";
                        this.Navigation.PushAsync(new VoucherNumberPage(), true);
                    }
                    else
                    {
                        errContent.IsVisible = true;
                        errlbl.Text = "Merchant number is inccorect or you have internet connection problem.";
                    }
                });
            }
            else
            {
                errContent.IsVisible = true;
                errlbl.Text = "Please type numeric value.";
            }
        }
    }
}
