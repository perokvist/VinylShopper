using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VinylShopper.Services.Contracts;

namespace VinylShopper.Services.Providers
{
    public class HhvProvider : ISearchProvider
    {
        private readonly IWebFetcher _webFetcher;

        public HhvProvider(IWebFetcher webFetcher)
        {
            _webFetcher = webFetcher;
        }

        public async Task<IEnumerable<ISearchResult>> SearchAsync(string artist, string albumTitle, string label)
        {
            var uri = new Uri("http://www.hhv.de/shop/en/catalog/music/c:366/sort:R?term=" + artist);
            var result = await _webFetcher.GetStringAsync(uri);

            throw new NotImplementedException();
        }

        public string StoreName
        {
            get { return "HHV"; }
        }

        public System.Uri StoreLogo
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}