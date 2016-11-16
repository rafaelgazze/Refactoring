using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using Embratel_Vidyo.CDRApplication.Library.Application;

namespace Embratel_Vidyo.CDRApplication.Library.Http
{
    public class EmbratelHttpClient : HttpClient
    {
        private readonly string _uri = ConfigurationManager.AppSettings["WebApiAddress"];

        public EmbratelHttpClient()
        {
            BaseAddress = new Uri(_uri);
        }


        public HttpResponseMessage SendPost(string path, string json)
        {
            var message = PostAsync(path, new StringContent(json, Encoding.UTF8, "application/json")).Result;

            if (message.IsSuccessStatusCode)
                return message;

            throw new EmbratelException(message.Content.ReadAsStringAsync().ToString());
        }



    }

  
    
}
