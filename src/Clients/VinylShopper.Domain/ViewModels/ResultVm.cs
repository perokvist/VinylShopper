using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VinylShopper.Domain.Resources;

namespace VinylShopper.Domain.ViewModels
{
    public class ResultVm : VmBase
    {
        public ResultVm()
        {
            SearchResults = new ObservableCollection<ResultItemVm>();
        }

        public ObservableCollection<ResultItemVm> SearchResults { get; set; }

        public async Task Search(string term)
        {
            SearchTerm = term;
            SetBusy(ResourceProxy.GetLocalizedString("BusyTextSearching"));
            await AppContext.Searcher.SearchAsync(term, HandleSearchResult);
            ClearBusy();
        }

        public string SearchTerm { get; set; }

        private void HandleSearchResult(ResultItemVm obj)
        {
            if (obj == null) return;
            SearchResults.Add(obj);
        }

        //public ObservableCollection<SampleDataGroup> Groups { get; set; }
    }
}