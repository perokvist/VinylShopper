using System;
using System.Collections.Generic;
using VinylShopper.Win.Common;
using VinylShopper.Win.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace VinylShopper.Win.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class SearchPage : VinylShopper.Win.Common.LayoutAwarePage
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            RealDataSource.Reset();
            ClearPageCache();
        }

        private void ClearPageCache()
        {
            var cacheSize = Frame.CacheSize;
            Frame.CacheSize = 0;
            Frame.CacheSize = cacheSize;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            string searchText = _textBox.Text;
            if (string.IsNullOrWhiteSpace(searchText))
                return;

            Frame.Navigate(typeof (GroupedItemsPage), searchText);
        }
    }
}
