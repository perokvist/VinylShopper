using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Treefort.WebApi.Security;
using VinylShopper.Services.Contracts;
namespace VinylShopper.Api.Controllers
{
    [Authorize(Roles = "Shopper")]
    public class ArtistController : ApiController
    {
        private readonly IStoreSearchService _searchService;

        public ArtistController(IStoreSearchService searchService)
        {
            _searchService = searchService;
        }

        public Task<IEnumerable<ISearchResult>> Get(string term)
        {
            return _searchService.SearchArtistAsync(term);
        }
    }
}