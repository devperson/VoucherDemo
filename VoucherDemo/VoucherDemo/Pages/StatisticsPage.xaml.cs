using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VoucherDemo.Pages
{
    public partial class StatisticsPage : BasePage
    {
        public StatisticsPage()
        {
            InitializeComponent();
            lbl1.FontSize = Device.OnPlatform(15, 18, 15);
            lbl2.FontSize = Device.OnPlatform(15, 18, 15);

            this.BindingContext = App.MainVm;

            activity.IsVisible = true;
            App.MainVm.WebService.GetRedeemed(App.MainVm.Sp_ID, (res) =>
            {
                App.MainVm.Redeemed = res.count;

                App.MainVm.WebService.GetPending(App.MainVm.Sp_ID, (res2) =>
                {
                    App.MainVm.Pending = res2.count;

                    activity.IsVisible = false;
                });
            });
           
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }
    }
}
