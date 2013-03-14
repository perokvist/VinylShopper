using System.Collections.Generic;
using System.Threading.Tasks;

namespace VinylShopper.Services.Contracts
{
    public interface ISearchProvider : IStoreInfo
    {
        Task<IEnumerable<ISearchResult>> SearchAsync(string artist, string albumTitle, string label);
    }
}