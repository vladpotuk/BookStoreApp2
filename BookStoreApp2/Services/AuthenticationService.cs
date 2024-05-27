using System.Data;
using Dapper;
using BookStoreApp2.DataAccess;
using BookStoreApp2.Models;

namespace BookStoreApp2.Services
{
    public class AuthenticationService
    {
        private readonly DatabaseContext _dbContext;

        public AuthenticationService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Authenticate(string username, string password)
        {
            using (var connection = _dbContext.Connection)
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                int count = connection.ExecuteScalar<int>(query, new { Username = username, Password = password });
                return count > 0;
            }
        }

        public void Register(User user)
        {
            using (var connection = _dbContext.Connection)
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                connection.Execute(query, user);
            }
        }
    }
}
