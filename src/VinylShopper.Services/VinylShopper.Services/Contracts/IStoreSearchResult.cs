using System;

namespace VinylShopper.Services.Contracts
{
    public interface IStoreSearchResult
    {
        string Artist { get; }
        string Title { get; }
        string Label { get; }
        string ReleaseDate { get; }
        string Price { get; }
        string Format { get; }
        string Pressing { get; }
        Uri Cover { get; }
        Uri Url { get; }
    }
}