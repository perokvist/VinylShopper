using System.Collections.Generic;

namespace VinylShopper.Services.Contracts
{
    public interface ISearchResult
    {
        IStoreInfo Store { get; }
        IEnumerable<IStoreSearchResult> Result { get; }
    }
}