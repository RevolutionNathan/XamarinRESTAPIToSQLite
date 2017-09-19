//using System;
//using StarWarsPeople2.Data;
//using StarWarsPeople2.Droid.Data;
//using Xamarin.Forms;
//using S


//[assembly: Dependency(typeof(StarWarsPeople2.Droid.Data.SQLiteClient))]
//namespace StarWarsPeople2.Droid.Data
//{
//    public class SQLiteClient:ISQLite
//    {
//		public SQLiteAsyncConnection GetConnection()
//		{
//			var sqliteFileName = "StarWarsPeopleDatabase.db3";
//			var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

//			var path = Path.Combine(documentsPath, sqliteFileName);

//			var platform = new SQLitePlatformAndroid();

//			var connectionWithLock = new SQLite.Net.SQLiteConnectionWithLock(
//				platform,
//				new SQLiteConnectionString(path, true)
//				);
//			var connection = new SQLiteAsyncConnection(() => connectionWithLock);
//			return connection;
//		}
//    }
//}
