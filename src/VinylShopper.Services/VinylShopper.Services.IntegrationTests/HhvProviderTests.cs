using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VinylShopper.Services.Providers;

namespace VinylShopper.Services.IntegrationTests
{
    public class HhvProviderTests
    {
        [Test]
        public void SearchShouldParseResult()
        {
            var s = new HhvProvider(new WebFetcher());
            var r = s.SearchArtistAsync("jessie").Result.Take(25);

            var i = 0;
            foreach (var storeSearchResult in r)
            {
                Console.WriteLine(i + " " + storeSearchResult.Artist);
                Console.WriteLine(i + " " + storeSearchResult.AlbumTitle);
                Console.WriteLine(i + " " + storeSearchResult.Label);
                Console.WriteLine(i + " " + storeSearchResult.Price);
                i++;
            }
        }
    }
}
