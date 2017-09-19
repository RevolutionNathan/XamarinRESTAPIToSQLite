using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using StarWarsPeople2.Models;
using Xamarin.Forms;
using System.Linq;

namespace StarWarsPeople2.Data
{
    public class SQLiteClient
    {
        private static readonly object locker = new object();
		readonly SQLiteConnection _connection;

		public SQLiteClient()
		{
			_connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<SWPeople>();
		}

		public IEnumerable <SWPeople> GetSWPeople()
		{
            lock (locker) {
                return _connection.Table<SWPeople>().ToList();
            }
			
		}

		public int Save(SWPeople person)
		{
			var existingPeople =  _connection.Table<SWPeople>().Where(x => x.name == person.name).FirstOrDefault();

			if (existingPeople == null)
			{
                lock (locker)
                {
					return _connection.Insert(person);

				}
			}
			else
			{
				person.ID = existingPeople.ID;
				return _connection.Update(person);
			}
			
		}

		public void SaveAll(IEnumerable<SWPeople> people)
		{
			foreach (var person in people)
			{
				Save(person);
			}
		}
    }
}