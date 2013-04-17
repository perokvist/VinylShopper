using System.Collections.Generic;

namespace VinylShopper.Domain.ViewModels
{
    public class ResultItemVm
    {
        public string Title { get; set; }
        public IEnumerable<Result> ResultList { get; set; }
    }
}