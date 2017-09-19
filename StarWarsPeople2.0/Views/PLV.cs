using System;
using System.Collections.Generic;
using StarWarsPeople2.ViewModels;
using Xamarin.Forms;

namespace StarWarsPeople2.Views
{
    public partial class PeopleListview : ContentPage
    {
        public PeopleListview()
        {
            InitializeComponent();
        }
		protected override void OnAppearing()
		{
			base.OnAppearing();

			var viewModel = new PeopleViewModel();
			viewModel.GetPeople();
			listView.ItemsSource = viewModel.SWPeople;

			//listView.ItemsSource = App.Database.GetItems();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			listView.ItemsSource = null;
		}

		async void OnAddItemClicked(object sender, EventArgs e)
		{
			//var todoItem = new TodoItem()
			//{
			//	ID = Guid.NewGuid().ToString()
			//};
			//var todoPage = new TodoItemPage(true);
			//todoPage.BindingContext = todoItem;
			//await Navigation.PushAsync(todoPage);
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//var todoItem = e.SelectedItem as TodoItem;
			//var todoPage = new TodoItemPage
			//{
			//	BindingContext = todoItem
			//};
			//await Navigation.PushAsync(todoPage);
		}
    }
}
