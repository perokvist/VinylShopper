using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylShopper.Infrastructure;

namespace VinylShopper.Domain.ViewModels
{
    public class MainVm : VmBase
    {
        public async Task Search(string text)
        {
        }

        public IEnumerable<Result> ResultList { get; set; }

        public IEnumerable<string> SearchHistory { get; set; }
    }
}