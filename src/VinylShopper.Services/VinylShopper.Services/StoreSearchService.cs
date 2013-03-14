using System;
using System.Collections.Generic;
using System.Linq;
using VinylShopper.Services.Contracts;

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
             _providers.Select(async p => 
                new Tuple<IStoreInfo, IEnumerable<ISearchResult>>(p , await p.SearchAsync(artist, albumName, label)));
        
               throw new NotImplementedException(); 
        }  
    }
}