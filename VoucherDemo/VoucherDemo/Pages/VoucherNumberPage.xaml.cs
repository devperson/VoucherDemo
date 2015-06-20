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
            this.Navigation.PushAsync(new ValidVoucherPage(), true);
        }

        private void Scan_Clicked(object sender, EventArgs e)
        {

        }

        private void Stat_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new StatisticsPage());
        }
    }
}
