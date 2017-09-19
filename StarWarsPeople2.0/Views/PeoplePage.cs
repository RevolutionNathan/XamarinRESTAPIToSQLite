using System;
using System.Threading.Tasks;
using StarWarsPeople2.ViewModels;
using Xamarin.Forms;

namespace StarWarsPeople2.Views
{
    public class PeoplePage : ContentPage
    {
		ListView _peopleListView;

		public PeoplePage()
		{
			this.Content = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

            Init();
		}

		private async Task Init()
		{
			_peopleListView = new ListView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

			};

			var cell = new DataTemplate(typeof(TextCell));
			cell.SetBinding(TextCell.TextProperty, "name");
            cell.SetBinding(TextCell.DetailProperty, new Binding(path: "birth_year"));
            cell.SetBinding(TextCell.DetailProperty, new Binding(path: "mass"));

			_peopleListView.ItemTemplate = cell;

			var viewModel = new PeopleViewModel();
			viewModel.GetPeople();
			_peopleListView.ItemsSource = viewModel.SWPeople;

            
			this.Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness
				(
					left: 0,
					right: 0,
					bottom: 0,
					top: Device.OnPlatform(iOS: 20, Android: 0, WinPhone: 0)
				),
				Children = { _peopleListView }
			};
		}
    }
}
