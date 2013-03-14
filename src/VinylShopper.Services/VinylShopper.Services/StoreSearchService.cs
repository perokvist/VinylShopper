using System;
using System.Collections.Generic;
using System.Linq;

namespace VinylShopper.Services
{
    public class StoreSearchService : IStoreSearchService
    {
        private readonly IEnumerable<ISearchProvider> _providers;

        public StoreSearchService(IEnumerable<ISearchProvider> providers)
        {
            _providers = providers;
        }

        public IEnumerable<Tuple<IStoreInfo, IEnumerable<ISearchResult>>> Search(string artist, string albumName, string label)
        {
            return _providers.Select(p => new Tuple<IStoreInfo, IEnumerable<ISearchResult>>(p ,p.Search(artist, albumName, label)));
        }  
    }
}