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
            var uri = new Uri("http://www.hhv.de/shop/en/catalog/music/c:366/sort:R?term=" + artist);
            var result = await _webFetcher.GetStringAsync(uri);

            var h = new HtmlAgilityPack.HtmlDocument();
            h.LoadHtml(result);
            var node = h.GetElementbyId("content");
            var nodes = GetNodesByClass(node, "info_area");
                
            throw new NotImplementedException();
        
        }

        private IEnumerable<HtmlNode> GetNodesByClass(HtmlNode node, string className)
        {
            var result = node.ChildNodes.SelectMany(SelectChildren)
                .Where(n => n.Attributes.Any(a => a.Name == "class" && a.Value == className));
            return result;
        }

        private IEnumerable<HtmlNode> SelectChildren(HtmlNode node)
        {
            return node.ChildNodes
                .SelectMany(SelectChildren);
        }

        public Task<IEnumerable<IStoreSearchResult>> SearchTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IStoreSearchResult>> SearchLabelAsync(string label)
        {
            throw new NotImplementedException();
        }
    }
}