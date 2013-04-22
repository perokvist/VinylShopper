using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylShopper.Domain.Resources;
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
                        artists => callback(GetResult(artists.Result, ResourceProxy.GetLocalizedString("Artist"))), TaskScheduler.FromCurrentSynchronizationContext()),
                    web.GetFeedAsync(new Uri(string.Format(Constants.ApiAlbumUri, term))).ContinueWith(
                        albums => callback(GetResult(albums.Result, ResourceProxy.GetLocalizedString("Album"))), TaskScheduler.FromCurrentSynchronizationContext()),
                    web.GetFeedAsync(new Uri(string.Format(Constants.ApiLabelUri, term))).ContinueWith(
                        labels => callback(GetResult(labels.Result, ResourceProxy.GetLocalizedString("Label"))), TaskScheduler.FromCurrentSynchronizationContext())
                };

            await TaskEx.WhenAll(tasks);
        }

        private ResultItemVm GetResult(RootObject result, string title)
        {
            if (result == null)
                return null;
            var list = result.Result;
            list.ForEach(r => r.Store = result.Store);
            return new ResultItemVm
                {
                    ResultList = list,
                    Title = title
                };
        }

    }

    

}