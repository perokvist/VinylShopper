using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinylShopper.Services.Contracts
{
    public interface ISearchProvider : IStoreInfo
    {
        Task<IEnumerable<IStoreSearchResult>> SearchArtistAsync(string artist);
        Task<IEnumerable<IStoreSearchResult>> SearchTitleAsync(string title);
        Task<IEnumerable<IStoreSearchResult>> SearchLabelAsync(string label);
    }
}