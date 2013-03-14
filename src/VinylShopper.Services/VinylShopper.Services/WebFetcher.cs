using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VinylShopper.Services
{   
    public class WebFetcher : IWebFetcher
    {
        public async Task<string> GetStringAsync(Uri uri)
        {
            var request = WebRequest.CreateHttp(uri);
            var response = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                .ConfigureAwait(false);

            var bytes = await response.GetResponseStream().ReadAllBytesAsync();
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
 
    }
}