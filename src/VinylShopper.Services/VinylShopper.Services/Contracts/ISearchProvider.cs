using System;
using System.Collections.Generic;

namespace VinylShopper.Services
{
    public interface ISearchProvider : IStoreInfo
    {
        IEnumerable<ISearchResult> Search(string artist, string albumTitle, string label);
    }
    
    public interface IStoreInfo
    {
        string StoreName { get; }
        Uri StoreLogo { get; } 
    }
}