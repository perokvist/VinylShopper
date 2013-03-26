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
        private const string Artist = "http://www.hhv.de/shop/en/catalog/all/attribute:artist/f:70,66,67/sort:R?term=";
        private const string Title = "http://www.hhv.de/shop/en/catalog/all/attribute:album/f:70,66,67/sort:R?term=";
        private const string Label = "http://www.hhv.de/shop/en/catalog/all/attribute:lable/f:70,66,67/sort:R?term=";


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
            get { return new Uri("http://www.hhv.de/assets/logos/hhv-b96bab0e4a7306d9e70ce4426870e3ca.png"); }
        }

        public async Task<IEnumerable<IStoreSearchResult>> SearchArtistAsync(string artist)
        {
            return await Search(new Uri(Artist + artist));
        }
        
        public async Task<IEnumerable<IStoreSearchResult>> SearchTitleAsync(string title)
        {
            return await Search(new Uri(Title + title));
        }

        public async Task<IEnumerable<IStoreSearchResult>> SearchLabelAsync(string label)
        {
            return await Search(new Uri(Label + label));
        }

        private async Task<List<StoreSearchResult>> Search(Uri uri)
        {
            var result = await _webFetcher.GetStringAsync(uri);
            var html = new HtmlDocument();
            html.LoadHtml(result);
            var contentNode = html.GetElementbyId("content");
            var nodes = contentNode.ByClass("info_area");
            
            return nodes.AsParallel()
                .AsOrdered()
                .Select(n => new StoreSearchResult
            {
                Title = n.FirstTextByClass("subtitle").Decode(),
                Artist = n.FirstTextByClass("title").Decode(),
                Label = n.FirstTextByClass("label").Empty(",&nbsp;").Decode(),
                Price = n.FirstTextByClass("price").Empty("&", ";").Decode(),
                Format = n.FirstTextByClass("category").Decode(),
                Pressing = n.FirstTextByClass("pressing").Decode(),
                Url = n.ParentNode.FirstAttributeByClass("overlay", "href").ToUri()
            }
            .Tap(r => r.Cover = n.ParentNode.ByAlt(r.Title).FirstOrDefault().AttributeValue("data-original").ToUri()))
            .ToList();
        } 
    }
}