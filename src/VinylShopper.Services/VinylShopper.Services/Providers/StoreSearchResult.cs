using System;
using VinylShopper.Services.Contracts;

namespace VinylShopper.Services.Providers
{
    public class StoreSearchResult : IStoreSearchResult
    {
        public string Artist { get; set; }

        public string Title { get; set; }

        public string Label { get; set; }

        public string ReleaseDate { get; set; }

        public string Price { get; set; }

        public Uri Cover { get; set; }

        public Uri Url { get; set; }

        public string Format { get; set; }

        public string Pressing { get; set; }
    }
}