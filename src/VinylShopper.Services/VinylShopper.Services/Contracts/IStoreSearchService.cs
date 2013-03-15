using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinylShopper.Services.Contracts
{
    public interface IStoreSearchService
    {
        Task<IEnumerable<ISearchResult>> SearchArtistAsync(string artist);
        Task<IEnumerable<ISearchResult>> SearchAlbumAsync(string album);
        Task<IEnumerable<ISearchResult>> SearchLabelAsync(string label);
    }
}