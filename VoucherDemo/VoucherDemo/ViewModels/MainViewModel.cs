using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoucherDemo.Services;
using Xamarin.Forms;

namespace VoucherDemo.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public string ApiUrl = "https://cbs.cakefundraising.com";
        public MainViewModel()
        {            
        }

        

        public long Sp_ID { get; set; }

        private IWebServiceClient _service;
        public IWebServiceClient WebService
        {
            get
            {
                if (_service == null)
                {
                    _service = DependencyService.Get<IWebServiceClient>();
                }
                return _service;
            }
        }

        private int _redeem;
        public int Redeemed
        {
            get { return _redeem; }
            set
            {
                if (value != _redeem)
                {
                    _redeem = value;
                    this.RaisePropertyChanged(p => p.Redeemed);
                }
            }
        }

        private int _pending;
        public int Pending
        {
            get { return _pending; }
            set
            {
                if (value != _pending)
                {
                    _pending = value;
                    this.RaisePropertyChanged(p => p.Pending);
                }
            }
        }

        public void GetStatistics()
        {
           
        }
    }
}
