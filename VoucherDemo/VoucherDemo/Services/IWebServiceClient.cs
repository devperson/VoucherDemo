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
        void PostObject<T>(string requestUrl, T obj, Action<ResponseBase> onCompleted = null);       
    }
}
