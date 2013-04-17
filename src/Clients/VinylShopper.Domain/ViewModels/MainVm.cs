using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylShopper.Infrastructure;

namespace VinylShopper.Domain.ViewModels
{
    public class MainVm : VmBase
    {
        public async Task Search(string text)
        {
            var web = new Web<RootObject>();
            web.ConfigureAuthHeader(Constants.AuthHeader);
            string uriString = string.Format(Constants.ApiUri, text);
            var uri = new Uri(uriString);
            var rootObject = await web.GetFeedAsync(uri);

            ResultList = rootObject.Result.ToArray();
        }

        public IEnumerable<Result> ResultList { get; set; }

        public IEnumerable<string> SearchHistory { get; set; }
    }
}