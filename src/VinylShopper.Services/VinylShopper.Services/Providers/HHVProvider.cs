using System.Collections.Generic;
using VinylShopper.Services.Contracts;

namespace VinylShopper.Services.Providers
{
    public class HhvProvider : ISearchProvider
    {
        public IEnumerable<ISearchResult> Search(string artist, string albumTitle, string label)
        {
            throw new System.NotImplementedException();
        }

        public string StoreName
        {
            get { return "HHV"; }
        }

        public System.Uri StoreLogo
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}