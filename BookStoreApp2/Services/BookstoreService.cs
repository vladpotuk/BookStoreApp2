using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BookStoreApp2.DataAccess;
using BookStoreApp2.Models;

namespace BookStoreApp2.Services
{
    public class BookstoreService
    {
        private readonly DatabaseContext _dbContext;

        public BookstoreService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            using (var connection = _dbContext.Connection)
            {
                string query = @"
                    INSERT INTO Books (Title, Author, Publisher, Pages, Genre, PublicationYear, Cost, Price, IsContinuation)
                    VALUES (@Title, @Author, @Publisher, @Pages, @Genre, @PublicationYear, @Cost, @Price, @IsContinuation)";
                connection.Execute(query, book);
            }
        }

        public void RemoveBook(string title)
        {
            using (var connection = _dbContext.Connection)
            {
                string query = "DELETE FROM Books WHERE Title = @Title";
                connection.Execute(query, new { Title = title });
            }
        }

        public void UpdateBook(string title, Book updatedBook)
        {
            using (var connection = _dbContext.Connection)
            {
                string query = @"
                    UPDATE Books 
                    SET Author = @Author, Publisher = @Publisher, Pages = @Pages, Genre = @Genre, 
                        PublicationYear = @PublicationYear, Cost = @Cost, Price = @Price, IsContinuation = @IsContinuation
                    WHERE Title = @Title";
                connection.Execute(query, new
                {
                    updatedBook.Author,
                    updatedBook.Publisher,
                    updatedBook.Pages,
                    updatedBook.Genre,
                    updatedBook.PublicationYear,
                    updatedBook.Cost,
                    updatedBook.Price,
                    updatedBook.IsContinuation,
                    Title = title
                });
            }
        }

        public List<Book> SearchBooksByTitle(string title)
        {
            using (var connection = _dbContext.Connection)
            {
                string query = "SELECT * FROM Books WHERE Title LIKE '%' || @Title || '%'";
                return connection.Query<Book>(query, new { Title = title }).ToList();
            }
        }
    }
}
