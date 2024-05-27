using System;
using BookStoreApp2.DataAccess;
using BookStoreApp2.Models;
using BookStoreApp2.Services;

class Program
{
    static void Main(string[] args)
    {
        var dbContext = new DatabaseContext();
        dbContext.EnsureDatabaseCreated();

        var bookstoreService = new BookstoreService(dbContext);
        var authService = new AuthenticationService(dbContext);

        var newBook = new Book
        {
            Title = "Example Book",
            Author = "John Doe",
            Publisher = "Example Publisher",
            Pages = 200,
            Genre = "Example Genre",
            PublicationYear = 2024,
            Cost = 10.50m,
            Price = 20.00m,
            IsContinuation = false
        };
        bookstoreService.AddBook(newBook);

        var searchedBooks = bookstoreService.SearchBooksByTitle("Example Book");
        foreach (var book in searchedBooks)
        {
            Console.WriteLine($"Found book: {book.Title} by {book.Author}");
        }

        string username = "admin";
        string password = "password";

        if (!authService.Authenticate(username, password))
        {
            var newUser = new User(username, password);
            authService.Register(newUser);
            Console.WriteLine("New user registered.");
        }

        if (authService.Authenticate(username, password))
        {
            Console.WriteLine("Authentication successful!");
        }
        else
        {
            Console.WriteLine("Authentication failed.");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
