using System.Collections.ObjectModel;

namespace VinylShopper.Domain.ViewModels
{
    public class ResultVm : VmBase
    {
        public ResultVm()
        {
            SearchResults = new ObservableCollection<ResultItemVm>();
        }

        public ObservableCollection<ResultItemVm> SearchResults { get; set; }

        public void Search(string term)
        {
            AppContext.Searcher.SearchAsync(term, HandleSearchResult);

        }

        private void HandleSearchResult(ResultItemVm obj)
        {
            SearchResults.Add(obj);
        }
    }
}