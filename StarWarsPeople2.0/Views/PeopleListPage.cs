using System;
using System.Diagnostics;
using StarWarsPeople2.ViewModels;
using Xamarin.Forms;

namespace StarWarsPeople2.Views
{
    public class PeopleListPageCS : ContentPage
    {
        public PeopleListPageCS()
        {
            Title = "Staw Was People";
            var listView = new ListView();

            var viewModel = new PeopleViewModel();
            viewModel.GetPeople();
            listView.ItemsSource = viewModel.SWPeople;

            // Using ItemTapped
            listView.ItemTapped += async (sender, e) =>
            {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                Debug.WriteLine("Tapped: " + e.Item);
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            // If using ItemSelected
            //          listView.ItemSelected += (sender, e) => {
            //              if (e.SelectedItem == null) return;
            //              Debug.WriteLine("Selected: " + e.SelectedItem);
            //              ((ListView)sender).SelectedItem = null; // de-select the row
            //          };

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;

        }
    }
}
