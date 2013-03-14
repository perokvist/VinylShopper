using System;
using System.Collections.Generic;

namespace VinylShopper.Services
{
    public interface IStoreSearchService
    {
        IEnumerable<Tuple<IStoreInfo, IEnumerable<ISearchResult>>> Search(string artist, string albumName, string label);
    }
}