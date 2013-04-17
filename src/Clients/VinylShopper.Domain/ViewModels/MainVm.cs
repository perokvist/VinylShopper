using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylShopper.Infrastructure;

namespace VinylShopper.Domain.ViewModels
{
    public class MainVm : VmBase
    {
        public string SearchTerm { get; set; }

        public async Task Search()
        {
            var web = new Web<RootObject>();
            web.ConfigureAuthHeader(Constants.AuthHeader);
            string uriString = string.Format(Constants.ApiUri, SearchTerm);
            var uri = new Uri(uriString);
            var rootObject = await web.GetFeedAsync(uri);


        }

        public IEnumerable<string> SearchHistory { get; set; }
    }
}