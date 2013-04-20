using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
            await AppContext.Searcher.SearchAsync(term, HandleSearchResult);
        }

        private void HandleSearchResult(ResultItemVm obj)
        {
            SearchResults.Add(obj);
        }
    }
}