using System;
using Microsoft.Data.Sqlite;

namespace Bangazon_Financial.Data
{
    /*
    Class Name: BangazonWebConnection
    Author: Fletcher Watson
    Purpose of the class: This Class establishes a connection to our DB. Sql queries can then be performed against the database connected to Bangazon_Db_Path1.
    */

    public class BangazonWebConnection
    {
        private string _connectionString = $"Data Source = {Environment.GetEnvironmentVariable("Bangazon_Db_Path1")}";

        //Method Name: Execute
        //Purpose: This method opens a connection to the database for string querys to be executed.
        public void execute(string query, Action<SqliteDataReader> handler)
        {

            SqliteConnection dbcon = new SqliteConnection(_connectionString);

            dbcon.Open();
            SqliteCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            dbcmd.Dispose();
            dbcon.Close();
        }
    }
}
