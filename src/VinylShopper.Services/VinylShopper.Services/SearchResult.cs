using System.Collections.Generic;
using VinylShopper.Services.Contracts;

namespace VinylShopper.Services
{
    public class SearchResult : ISearchResult
    {
        public IStoreInfo Store { get; set; }

        public IEnumerable<IStoreSearchResult> Result { get; set; }
    }
}