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

        public async Task<IEnumerable<IStoreSearchResult>> SearchTitleAsync(string title)
        {
            var uri = new Uri(string.Format("http://recordmania.net/index.php?query={0}&ref=search_records", title));
            return await Search(uri);
        }

        public async Task<IEnumerable<IStoreSearchResult>> SearchLabelAsync(string label)
        {
            var uri = new Uri(string.Format("http://recordmania.net/index.php?query={0}&ref=search_records", label));
            return await Search(uri);
        }

        public string StoreName
        {
            get { return "RecordMania"; }
        }

        public System.Uri StoreLogo
        {
            get { return new Uri("http://recordmania.net/imgs/rmlogo.gif"); }
        }

        private async Task<List<StoreSearchResult>> Search(Uri uri)
        {
            var result = await _webFetcher.GetStringAsync(uri);
            var html = new HtmlDocument();
            html.LoadHtml(result);
            var node = html.GetElementbyId("searchresult");
            var nodes = node.ById("info_display");

            return nodes.Select(n => new StoreSearchResult
                                                     {
                                                         Artist = GetArtist(n),
                                                         Title = n.FirstTextById("record"),
                                                         Label = GetLabel(n),
                                                         Pressing = GetPressing(n),
                                                         Cover = GetCover(n),
                                                         Url = GetUrl(n)
                                                     }
            ).ToList();
        }

        private static string GetArtist(HtmlNode n)
        {
            var artistNodes = new List<HtmlNode>();
            artistNodes.AddRange(n.ById("artist"));
            artistNodes.AddRange(n.ById("smallartist"));
            return 
                artistNodes.Where(an => an != null).Select(
                    an => an.ChildNodes.First().InnerText).First();
        }

        private static Uri GetCover(HtmlNode n)
        {
            var node = n.ChildNodes.First().ChildNodes.FirstOrDefault();
            return node == null ? null : ("http://www.recordmania.net/" + node.AttributeValue("src")).ToUri();
        }

        private static Uri GetUrl(HtmlNode n)
        {
            var artistNodes = new List<HtmlNode>();
            artistNodes.AddRange(n.ById("artist"));
            artistNodes.AddRange(n.ById("smallartist"));
            var url = 
                artistNodes.Where(an => an != null).Select(
                    an => an.ChildNodes.First().AttributeValue("href")).FirstOrDefault();

            return url != null ? ("http://www.recordmania.net/" + url).ToUri() : null;
        }

        private static string GetLabel(HtmlNode n)
        {
            return n.FirstTextById("label").Split(new[] { " - " }, StringSplitOptions.None)[0];
        }

        private static string GetPressing(HtmlNode n)
        {
            var split = n.FirstTextById("label").Split(new[] {" - "}, StringSplitOptions.None);
            return split.Count() > 1 ? split[1] : string.Empty;
        }
    }
}