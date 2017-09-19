using System;
using SQLite;

namespace StarWarsPeople2.Data
{
    public interface ISQLite
    {
		SQLiteConnection GetConnection();
	
    }
}
