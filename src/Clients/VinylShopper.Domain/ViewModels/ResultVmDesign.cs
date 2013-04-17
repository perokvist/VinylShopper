using System.Collections.ObjectModel;

namespace VinylShopper.Domain.ViewModels
{
    public class ResultVmDesign : ResultVm
    {
        public ResultVmDesign()
        {
            SearchResults.Add(new ResultItemVm()
                {
                    Title = "artist",
                    ResultList = new[] { new Result() { Artist = "artist artist", Title = "title" } }
                });
            SearchResults.Add(new ResultItemVm()
            {
                Title = "label",
                ResultList = new[] { new Result() { Artist = "label artist", Title = "title" } }
            });
        }
    }
}