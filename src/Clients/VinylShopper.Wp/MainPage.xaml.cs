using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using VinylShopper.Domain.ViewModels;

namespace VinylShopper.Wp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly MainVm _vm;

        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            //DataContext = App.ViewModel;
            Loaded += MainPage_Loaded;

            _vm = new MainVm();
            DataContext = _vm;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _searchTextBox.Focus();
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LaunchSearch();
            }
        }

        private void Button_Tap_1(object sender, GestureEventArgs e)
        {
            LaunchSearch();
        }

        private void LaunchSearch()
        {
            //App.ViewModel.Search(_searchTextBox.Text);
            _vm.Search();
        }
    }
}