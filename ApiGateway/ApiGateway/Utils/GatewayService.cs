using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using static System.Net.WebRequestMethods;

namespace ApiGateway.Utils
{
    public class GatewayService
    {
		#region Singleton
		private readonly static GatewayService _instance;
		public static GatewayService Current { get { return _instance; } }
		static GatewayService() { _instance = new GatewayService(); }
		private GatewayService()
		{
			//Implent here the initialization of your singleton
		}

		#endregion

		public string url_base = @"https://localhost:44311/";

		public object ParseRequest(RestSharp.Method httpRequest, string controller, string method, string[] parameters_names, string[] parameters_values)
		{
			var url = url_builder(controller, method, parameters_names, parameters_values);

            var client = new RestClient(url);
            var request = new RestRequest("", httpRequest);
            RestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<object>(response.Content);
        }

		private string url_builder(string controller, string method, string[] parameters_names, string[] parameters_values)
		{
			controller = controller.Replace("Controller", "");

            string parameters_joined = null;

			for(int i = 0; i < parameters_names.Length; i++)
			{
				if (i > 0) parameters_joined += "&";

				parameters_joined += parameters_names[i] + "=" + parameters_values[i];
            }

			return $"{url_base}/{controller}/{method}?{parameters_joined}";
		}
	}
}