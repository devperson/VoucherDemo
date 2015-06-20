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

        /// <summary>
        /// Method provides register object service call.
        /// </summary>    
        public async void PostObject<T>(string requestUrl, T obj, Action<ResponseBase> onCompleted = null)
        {
            var asyncResult = await ExecuteServiceMethod<ResponseBase>(requestUrl, Method.POST, content =>
            {
                var response = JsonConvert.DeserializeObject<ResponseBase>(content);
                return response;
            }, obj);
            if (onCompleted != null)
                onCompleted(asyncResult);
        }

       
        /// <summary>
        /// Helper method for sending http commands.
        /// </summary>        
        private Task<T> ExecuteServiceMethod<T>(string resource, Method method, Func<string, T> deserialiser, object requestObject = null) where T : ResponseBase
        {
            var restRequest = new RestRequest(resource, method);
            if (requestObject != null)
            {
                restRequest.RequestFormat = DataFormat.Json;
                var json = JsonConvert.SerializeObject(requestObject);
                restRequest.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);                
            }

            return Task.Run<T>(() =>
            {
                T response = Activator.CreateInstance<T>();
                var errorResponse = new ErrorResponseModel();
                try
					{
                    var restResponse = Client.Execute(restRequest);
                    this.CheckServer(restResponse.Content);
                    if (!string.IsNullOrEmpty(restResponse.Content))
                    {
                        response = deserialiser(restResponse.Content);
                        if (restResponse.Content.Contains("ExceptionMessage") || restResponse.Content.Contains("Message"))
                            errorResponse = JsonConvert.DeserializeObject<ErrorResponseModel>(restResponse.Content);
                    }
                    else
                    {
                        errorResponse.ExceptionMessage = "There seems to be internet connection problem.";
                        response.Success = false;
                    }
                    if (errorResponse != null && errorResponse.HasErrorMessage)
                    {
                        response.Success = false;
                        response.Error = errorResponse.ErrorMessage;
                    }
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Error = "Server is down please try later.";
                }
                return response;
            });
        }

        /// <summary>
        /// Helper method for validating service result.
        /// </summary>        
        private void CheckServer(string responsString)
        {
            string htmlContent = "<!DOCTYPE";
            if (responsString.Contains(htmlContent))
                throw new Exception("Server is down please try later.");
        }
    }
}