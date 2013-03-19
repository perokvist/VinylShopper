using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VinylShopper.Services;
using VinylShopper.Services.Contracts;
using VinylShopper.Services.Providers;

namespace VinylShopper.Api.Controllers
{
    [Authorize(Roles = "Shopper")]
    public class AlbumController : ApiController
    {
        private readonly IStoreSearchService _searchService;

        public AlbumController(IStoreSearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<ISearchResult>> Get(string term)
        {
            return await _searchService.SearchAlbumAsync(term);
        }
    }
}