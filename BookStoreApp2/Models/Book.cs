namespace BookStoreApp2.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public bool IsContinuation { get; set; }

        public Book() { }

        public Book(string title, string author, string publisher, int pages, string genre, int publicationYear, decimal cost, decimal price, bool isContinuation)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Pages = pages;
            Genre = genre;
            PublicationYear = publicationYear;
            Cost = cost;
            Price = price;
            IsContinuation = isContinuation;
        }
    }
}
