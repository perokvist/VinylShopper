using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using VinylShopper.Services.Contracts;

namespace VinylShopper.Services.Providers
{
    public class RecordManiaProvider : ISearchProvider
    {
        private readonly IWebFetcher _webFetcher;

        public RecordManiaProvider(IWebFetcher webFetcher)
        {
            _webFetcher = webFetcher;
        }


        public async Task<IEnumerable<IStoreSearchResult>> SearchArtistAsync(string artist)
        {
            var uri = new Uri(string.Format("http://recordmania.net/index.php?query={0}&ref=search_records", artist));
            return await Search(uri);
        }

        public Task<IEnumerable<IStoreSearchResult>> SearchTitleAsync(string title)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IStoreSearchResult>> SearchLabelAsync(string label)
        {
            throw new System.NotImplementedException();
        }

        public string StoreName
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Uri StoreLogo
        {
            get { throw new System.NotImplementedException(); }
        }

        private async Task<List<StoreSearchResult>> Search(Uri uri)
        {
            var result = await _webFetcher.GetStringAsync(uri);
            var html = new HtmlDocument();
            html.LoadHtml(result);
            var node = html.GetElementbyId("searchresult");
            var nodes = node.ByClass("cover");

            return nodes.Select(n => new StoreSearchResult
            {
            }).ToList();
        }
    }
}