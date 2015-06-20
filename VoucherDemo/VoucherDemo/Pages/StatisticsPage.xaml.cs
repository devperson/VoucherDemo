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
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopAsync(true);
        }
    }
}
