using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VinylShopper.Domain.ViewModels;
using VinylShopper.Infrastructure;

namespace VinylShopper.Domain.Search
{
    public class Searcher
    {
        public async Task SearchAsync(string term, Action<ResultItemVm> callback)
        {
            var web = new Web<RootObject>();
            web.ConfigureAuthHeader(Constants.AuthHeader);
            var tasks = new List<Task>
                {
                    web.GetFeedAsync(new Uri(string.Format(Constants.ApiArtistUri, term))).ContinueWith(
                        artists => callback(GetResult(artists.Result, "Artist")), TaskScheduler.FromCurrentSynchronizationContext()),
                    web.GetFeedAsync(new Uri(string.Format(Constants.ApiAlbumUri, term))).ContinueWith(
                        albums => callback(GetResult(albums.Result, "Album")), TaskScheduler.FromCurrentSynchronizationContext()),
                    web.GetFeedAsync(new Uri(string.Format(Constants.ApiLabelUri, term))).ContinueWith(
                        labels => callback(GetResult(labels.Result, "Label")), TaskScheduler.FromCurrentSynchronizationContext())
                };

            await TaskEx.WhenAll(tasks);
        }

        private ResultItemVm GetResult(RootObject result, string title)
        {
            return new ResultItemVm
                {
                    ResultList = result.Result,
                    Title = title
                };
        }

    }

}