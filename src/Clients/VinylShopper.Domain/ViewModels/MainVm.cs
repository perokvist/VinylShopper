using System.Collections.Generic;

namespace VinylShopper.Domain.ViewModels
{
    public class MainVm : VmBase
    {
        public string SearchTerm { get; set; }

        public void Search()
        {
            
        }

        public IEnumerable<string> SearchHistory { get; set; }
    }
}