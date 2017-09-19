using System;
using System.IO;
using Xamarin.Forms;
using SQLite;
using StarWarsPeople2.Data;

[assembly: Dependency(typeof(StarWarsPeople2.iOS.Data.SQLiteClient))]
namespace StarWarsPeople2.iOS.Data
{
    public class SQLiteClient: ISQLite
    {
        public SQLiteClient()
        {
            
        }

        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "StarWarsPeopleDatabase.db3"; 
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, sqliteFilename);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

            return new SQLiteConnection(path);
		}
    }
}