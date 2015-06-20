using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VoucherDemo.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
