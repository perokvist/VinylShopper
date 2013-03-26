using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VinylShopper.Services.Providers;

namespace VinylShopper.Services.IntegrationTests
{
    public class ProviderTests
    {
        [Test]
        public void HhvSearchShouldParseResult()
        {
            var s = new HhvProvider(new WebFetcher());
            var r = s.SearchArtistAsync("jessie").Result.Take(25);

            var i = 0;
            foreach (var storeSearchResult in r)
            {
                Console.WriteLine(i + " " + storeSearchResult.Artist);
                Console.WriteLine(i + " " + storeSearchResult.Title);
                Console.WriteLine(i + " " + storeSearchResult.Label);
                Console.WriteLine(i + " " + storeSearchResult.Price);
                Console.WriteLine(i + " " + storeSearchResult.Cover);
                Console.WriteLine(i + " " + storeSearchResult.Url);
                Console.WriteLine("------ ");
                i++;
            }
        }

        [Test]
        public void RecordManiaSearchShouldParseResult()
        {
            var s = new RecordManiaProvider(new WebFetcher());
            var r = s.SearchArtistAsync("evans").Result.Take(25);
               
            var i = 0;
            foreach (var storeSearchResult in r)
            {
                Console.WriteLine(i + " " + storeSearchResult.Artist);
                Console.WriteLine(i + " " + storeSearchResult.Title);
                Console.WriteLine(i + " " + storeSearchResult.Label);
                Console.WriteLine(i + " " + storeSearchResult.Price);
                Console.WriteLine(i + " " + storeSearchResult.Cover);
                Console.WriteLine(i + " " + storeSearchResult.Url);
                Console.WriteLine("------ ");
                i++;
            }
        }
    }
}
