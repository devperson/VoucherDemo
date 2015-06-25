//using ObjCRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VoucherDemo.Services;
using VoucherDemo.Models;
using VoucherDemo;


[assembly: Xamarin.Forms.Dependency(typeof(DriverApp.PCL.WebService))]
namespace DriverApp.PCL
{
    /// <summary>
    /// This class provides functions for accessing data service.
    /// </summary>
    public class WebService : IWebServiceClient
    {
        private RestClient client;        
        protected RestClient Client
        {
            get
            {
                return client;
            }
        }
        public WebService()
		{
			var url = App.MainVm.ApiUrl;
            client = new RestClient(url); 
			client.AddDefaultHeader("Accept", "application/json");
		}

        public async void Login(long num, Action<bool> completed)
        {
            var restRequest = new RestRequest(string.Format("/api/v1/sponsors/{0}/exists", num), Method.GET);            

            var boolVal = await Task.Run<bool>(() =>
            {                
                try
                {
                    var restResponse = Client.Execute(restRequest);                    
                    if (!string.IsNullOrEmpty(restResponse.Content))
                    {
                        return JsonConvert.DeserializeObject<bool>(restResponse.Content);
                    }                    
                }
                catch (Exception ex)
                {
                    return false;
                }
                return false;
            });

            if (completed != null)
                completed(boolVal);            
        }

        public async void ValidateVoucher(long spId, long vaucher, Action<ResponseBase> completed)
        {
            var asyncResult = await ExecuteServiceMethod<ResponseBase>(string.Format("/api/v1/vouchers/{0}/status?sp={1}", vaucher, spId), Method.GET, content =>
            {
                var response = JsonConvert.DeserializeObject<ResponseBase>(content);
                return response;
            });
            if (completed != null)
                completed(asyncResult);
        }

        public async void Redeem(long spId, long vaucher, Action<RedeemResponse> completed)
        {
            var asyncResult = await ExecuteServiceMethod<RedeemResponse>(string.Format("/api/v1/vouchers/{0}/redeem?sp={1}", vaucher, spId), Method.PATCH, content =>
            {
                var response = JsonConvert.DeserializeObject<RedeemResponse>(content);
                return response;
            });
            if (completed != null)
                completed(asyncResult);
        }

        public async void GetRedeemed(long spId, Action<StatisticsResponse> completed)
        {
            var asyncResult = await ExecuteServiceMethod<StatisticsResponse>(string.Format("/api/v1/sponsors/{0}/redeemed_vouchers", spId), Method.GET, content =>
            {
                var response = JsonConvert.DeserializeObject<StatisticsResponse>(content);
                return response;
            });
            if (completed != null)
                completed(asyncResult);
        }

        public async void GetPending(long spId, Action<StatisticsResponse> completed)
        {
            var asyncResult = await ExecuteServiceMethod<StatisticsResponse>(string.Format("/api/v1/sponsors/{0}/pending_vouchers", spId), Method.GET, content =>
            {
                var response = JsonConvert.DeserializeObject<StatisticsResponse>(content);
                return response;
            });
            if (completed != null)
                completed(asyncResult);
        }

        /// <summary>
        /// Method provides register object service call.
        /// </summary>    
        //public async void PostObject<T>(string requestUrl, T obj, Action<ResponseBase> onCompleted = null)
        //{
        //    var asyncResult = await ExecuteServiceMethod<ResponseBase>(requestUrl, Method.POST, content =>
        //    {
        //        var response = JsonConvert.DeserializeObject<ResponseBase>(content);
        //        return response;
        //    }, obj);
        //    if (onCompleted != null)
        //        onCompleted(asyncResult);
        //}


        private Task<T> ExecuteServiceMethod<T>(string resource, Method method, Func<string, T> deserialiser) where T : ResponseBase
        {
            var restRequest = new RestRequest(resource, method);
            //if (requestObject != null)
            //{
            //    restRequest.RequestFormat = DataFormat.Json;
            //    var json = JsonConvert.SerializeObject(requestObject);
            //    restRequest.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            //}

            return Task.Run<T>(() =>
            {
                T response = Activator.CreateInstance<T>();                
                try
                {
                    var restResponse = Client.Execute(restRequest);

                    if (!this.HasHtmlString(restResponse.Content))
                        response.message = "There seems to be problem with internet connection.";                    
                    
                    if (!string.IsNullOrEmpty(restResponse.Content))
                    {
                        response = deserialiser(restResponse.Content);                        
                    }
                    else
                    {
                        response.message = "There seems to be problem with internet connection.";          
                    }
                }
                catch (Exception ex)
                {
                    response.message = "Server is down please try later.";          
                }
                return response;
            });
        }

        /// <summary>
        /// Helper method for validating service result.
        /// </summary>        
        private bool HasHtmlString(string responsString)
        {
            string htmlContent = "<!DOCTYPE";
            if (responsString.Contains(htmlContent))
                return true;
            return false;
        }

       
    }
}