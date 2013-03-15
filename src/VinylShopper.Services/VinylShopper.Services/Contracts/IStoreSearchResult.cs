using System;

namespace VinylShopper.Services.Contracts
{
    public interface IStoreSearchResult
    {
        string Artist { get; }
        string AlbumTitle { get; }
        string Label { get; }
        string ReleaseDate { get; }
        string Price { get; }
        Uri AlbumCover { get; }
        Uri Url { get; }
    }
}