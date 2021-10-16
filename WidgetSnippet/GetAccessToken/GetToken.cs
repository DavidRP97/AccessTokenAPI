using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;
using RestSharp.Serialization.Json;
using WidgetSnippet.GetAccessToken.Interfaces;
using System.Net;

namespace WidgetSnippet.GetAccessToken
{
    public class GetToken : IGetToken
    {
        private string _refresh;
        private string _access;

        public string refresh { get => _refresh; set => _refresh = value; }
        public string access { get => _access; set => _access = value; }

        public string GetRefreshAndAccess(string id, string password)
        {
            var client = new RestClient("https://sandbox.belvo.co/api/token/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Host", "sandbox.belvo.com");
            var body = @"{" + "\n" +
            $@"    ""id"": ""{id}"" ," + "\n" +
            $@"    ""password"": ""{password}""," + "\n" +
            @"    ""scopes"": ""read_institutions,write_links,read_links""" + "\n" +
            @"  }";
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return response.Content;

        }
    }
}
