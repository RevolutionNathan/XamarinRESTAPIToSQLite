using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyChanged;
using StarWarsPeople2.Data;
using StarWarsPeople2.Models;
using StarWarsPeople2.Services;

namespace StarWarsPeople2.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PeopleViewModel
    {
		readonly SQLiteClient _db;

		public PeopleViewModel()
		{
			_db = new SQLiteClient();
		}

		public List<SWPeople> SWPeople { get; set; }

		public void GetPeople()
		{
			 GetLocalPeople();
			 GetRemotePeople();
			 GetLocalPeople();
		}

		private void GetLocalPeople()
		{
			var people = _db.GetSWPeople();
			this.SWPeople = people.OrderBy(Xamarin => Xamarin.name).ToList();
		}

		private async void GetRemotePeople()
		{
			var remoteClient = new DataService();
            var people = await remoteClient.GetPeopleAsync();
			_db.SaveAll(people);
		}
    }
}
