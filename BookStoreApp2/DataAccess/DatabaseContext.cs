using System.Data.SQLite;
using System.Data;
using Dapper;

namespace BookStoreApp2.DataAccess
{
    public class DatabaseContext
    {
        private const string ConnectionString = "Data Source=BookstoreDB.db;Version=3;";

        public IDbConnection Connection => new SQLiteConnection(ConnectionString);

        public void EnsureDatabaseCreated()
        {
            using (var connection = Connection)
            {
                connection.Open();
                string createBooksTable = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        BookID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Publisher TEXT NOT NULL,
                        Pages INTEGER NOT NULL,
                        Genre TEXT NOT NULL,
                        PublicationYear INTEGER NOT NULL,
                        Cost REAL NOT NULL,
                        Price REAL NOT NULL,
                        IsContinuation INTEGER NOT NULL
                    )";
                string createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL
                    )";
                connection.Execute(createBooksTable);
                connection.Execute(createUsersTable);
            }
        }
    }
}
