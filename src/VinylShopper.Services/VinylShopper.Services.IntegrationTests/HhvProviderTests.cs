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
            s.SearchArtistAsync("jessie").Wait();
        }
    }
}
