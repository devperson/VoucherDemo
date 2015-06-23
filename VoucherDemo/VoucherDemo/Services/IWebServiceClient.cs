using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoucherDemo.Models;

namespace VoucherDemo.Services
{
    public interface IWebServiceClient
    {
        //void PostObject<T>(string requestUrl, T obj, Action<ResponseBase> onCompleted = null);   
        void Login(int num, Action<bool> completed);
        void ValidateVoucher(int spId, int vaucher, Action<ResponseBase> completed);
        void Redeem(int spId, int vaucher, Action<RedeemResponse> completed);

        void GetRedeemed(int spId, Action<StatisticsResponse> completed);
        void GetPending(int spId, Action<StatisticsResponse> completed);
    }
}
