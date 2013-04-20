using System.Diagnostics;
using VinylShopper.Domain.ViewModels;
using VinylShopper.Win.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace VinylShopper.Win
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class GroupedItemsPage : VinylShopper.Win.Common.LayoutAwarePage
    {
        private ResultVm _vm;

        public GroupedItemsPage()
        {
            this.InitializeComponent();
            _vm = new ResultVm();
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
        protected override async void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var sampleDataGroups = SampleDataSource.GetGroups("AllGroups");

            var searchText = (String) navigationParameter;
            await _vm.Search(searchText);

            var realDataGroups = CreateDataGroups();
            RealDataSource.SetGroups(realDataGroups);

            this.DefaultViewModel["Groups"] = realDataGroups;
        }

        private IEnumerable<SampleDataGroup> CreateDataGroups()
        {
            return _vm.SearchResults.Select(CreateGroup).ToList();
        }

        private SampleDataGroup CreateGroup(ResultItemVm result)
        {
            var group = new SampleDataGroup(result.Title,
                                            result.Title, null, null, null);
            
            result.ResultList
                .Select(x => CreateItem(x, group))
                .ForEach(d => group.Items.Add(d));

            return group;
        }

        private static SampleDataItem CreateItem(Result x, SampleDataGroup group)
        {
            var uniqueId = Guid.NewGuid().ToString();
            Debug.WriteLine(string.Format("generating item with id: {0}", uniqueId));
            return new SampleDataItem(uniqueId, 
                x.Title, 
                x.Label, 
                x.Cover, 
                x.ReleaseDate == null ? string.Empty : x.ReleaseDate.ToString(), 
                x.Artist,
                group);
        }

        /// <summary>
        /// Invoked when a group header is clicked.
        /// </summary>
        /// <param name="sender">The Button used as a group header for the selected group.</param>
        /// <param name="e">Event data that describes how the click was initiated.</param>
        void Header_Click(object sender, RoutedEventArgs e)
        {
            // Determine what group the Button instance represents
            var group = (sender as FrameworkElement).DataContext;

            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            this.Frame.Navigate(typeof(GroupDetailPage), ((SampleDataGroup)group).UniqueId);
        }

        /// <summary>
        /// Invoked when an item within a group is clicked.
        /// </summary>
        /// <param name="sender">The GridView (or ListView when the application is snapped)
        /// displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the appropriate destination page, configuring the new page
            // by passing required information as a navigation parameter
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }
    }

    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var t in list)
            {
                action(t);
            }
        }
    }
}
