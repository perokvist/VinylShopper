using VinylShopper.Domain.Search;

namespace VinylShopper.Domain
{
    public static class AppContext
    {
        private static Searcher _searcher;
        public static Searcher Searcher
        {
            get { return _searcher ?? (_searcher = new Searcher()); }
        }
    }
}