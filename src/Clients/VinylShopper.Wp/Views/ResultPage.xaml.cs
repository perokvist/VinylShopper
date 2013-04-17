using Microsoft.Phone.Controls;
using VinylShopper.Domain;
using VinylShopper.Domain.ViewModels;

namespace VinylShopper.Wp.Views
{
    public partial class ResultPage : PhoneApplicationPage
    {
        private readonly ResultVm _vm;

        public ResultPage()
        {
            InitializeComponent();
            _vm = new ResultVm();
            DataContext = _vm;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var term = NavigationContext.QueryString["term"];

            _vm.Search(term);
        }
    }
}