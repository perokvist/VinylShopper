using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using VinylShopper.Services.Contracts;

namespace VinylShopper.Api.Controllers
{
    [Authorize(Roles = "Shopper")]
    public class LabelController : ApiController
    {
        private readonly IStoreSearchService _searchService;

        public LabelController(IStoreSearchService searchService)
        {
            _searchService = searchService;
        }

        public Task<IEnumerable<ISearchResult>> Get(string term)
        {
            return _searchService.SearchLabelAsync(term);
        }
    }
}