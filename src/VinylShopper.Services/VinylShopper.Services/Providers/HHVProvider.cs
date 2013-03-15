using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
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

        public string StoreName
        {
            get { return "HHV"; }
        }

        public System.Uri StoreLogo
        {
            get { throw new System.NotImplementedException(); }
        }

        public async Task<IEnumerable<IStoreSearchResult>> SearchArtistAsync(string artist)
        {
            var uri = new Uri("http://www.hhv.de/shop/en/catalog/music/c:366/f:70,66,67,68,69/sort:R?term=" + artist);
            return await Search(uri);
        }
        
        public Task<IEnumerable<IStoreSearchResult>> SearchTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IStoreSearchResult>> SearchLabelAsync(string label)
        {
            throw new NotImplementedException();
        }

        private async Task<List<StoreSearchResult>> Search(Uri uri)
        {
            var result = await _webFetcher.GetStringAsync(uri);
            var html = new HtmlDocument();
            html.LoadHtml(result);
            var node = html.GetElementbyId("content");
            var nodes = node.ByClass("info_area");

            return nodes.Select(n => new StoreSearchResult
            {
                AlbumTitle = n.FirstTextByClass("subtitle"),
                Artist = n.FirstTextByClass("title"),
                Label = n.FirstTextByClass("label").Replace(",&nbsp;", string.Empty),
                Price = n.FirstTextByClass("price").Replace("&", string.Empty).Replace(";", string.Empty),
                Format = n.FirstTextByClass("category"),
                Pressing = n.FirstTextByClass("pressing")
            }).ToList();
        } 
    }
}