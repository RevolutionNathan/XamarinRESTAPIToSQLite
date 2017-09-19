using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using StarWarsPeople2.Models;
using StarWarsPeople2.ViewModels;
using Xamarin.Forms;

namespace StarWarsPeople2.Views
{
    public partial class PeopleListPage : ContentPage
    {
        public List<SWPeople> people { get; set; }

        public PeopleListPage()
        {
			var viewModel = new PeopleViewModel();
            people = viewModel.SWPeople;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            var viewModel = new PeopleViewModel();
            viewModel.GetPeople();
            listView.ItemsSource = viewModel.SWPeople;
            people = viewModel.SWPeople;

            //listView.ItemsSource = App.Database.GetItems();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            listView.ItemsSource = null;
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
