using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<ISearchResult>> SearchArtistAsync(string artist)
        {
            return await Search(p => p.SearchArtistAsync(artist));
        }
        
        public async Task<IEnumerable<ISearchResult>> SearchAlbumAsync(string album)
        {
            return await Search(p => p.SearchTitleAsync(album));
        }

        public async Task<IEnumerable<ISearchResult>> SearchLabelAsync(string label)
        {
            return await Search(p => p.SearchLabelAsync(label));
        }

        private Task<SearchResult[]> Search(Func<ISearchProvider, Task<IEnumerable<IStoreSearchResult>>> providerAction)
        {
            var tasks = _providers.Select(async p =>
                new SearchResult() { Store = p, Result = await providerAction(p) }
                );
            return Task.WhenAll(tasks);
        }  

    }
}