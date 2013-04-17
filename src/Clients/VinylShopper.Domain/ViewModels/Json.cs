using System.Collections.Generic;

namespace VinylShopper.Domain.ViewModels
{
    public class Store
    {
        public string StoreName { get; set; }
        public string StoreLogo { get; set; }
    }

    public class Result
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Label { get; set; }
        public object ReleaseDate { get; set; }
        public string Price { get; set; }
        public string Cover { get; set; }
        public string Url { get; set; }
        public string Format { get; set; }
        public string Pressing { get; set; }
    }

    public class RootObject
    {
        public Store Store { get; set; }
        public List<Result> Result { get; set; }
    }
}