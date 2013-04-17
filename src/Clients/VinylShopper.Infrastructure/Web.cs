using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VinylShopper.Infrastructure
{
    public class Web<T>
    {
        private string _authHeader;

        public async Task<T> GetFeedAsync(Uri uri)
        {
            var request = WebRequest.CreateHttp(uri);

            if (!string.IsNullOrWhiteSpace(_authHeader))
            {
                request.Headers["Authorization"] = _authHeader;
            }

            try
            {
                WebResponse response = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

                var result = await DeserializeResponse(response);

                var rootObject = new JsonParser().Parse<T>(result);
                return rootObject;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return default(T);
            }
        }

        private async Task<string> DeserializeResponse(WebResponse response)
        {
            string result;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = await reader.ReadToEndAsync();
            }
            return result;

        }

        public void ConfigureAuthHeader(string authHeader)
        {
            _authHeader = authHeader;
        }


    }
}
