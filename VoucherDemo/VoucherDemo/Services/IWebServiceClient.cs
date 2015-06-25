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
        void Login(long num, Action<bool> completed);
        void ValidateVoucher(long spId, long vaucher, Action<ResponseBase> completed);
        void Redeem(long spId, long vaucher, Action<RedeemResponse> completed);

        void GetRedeemed(long spId, Action<StatisticsResponse> completed);
        void GetPending(long spId, Action<StatisticsResponse> completed);
    }
}
