namespace FGVConsoleApp.Model
{
    public class Book
    {
        public string Title { get; }
        public string AuthorName { get; }
        public int EditionYear { get; }

        public Book(string title, string authorName, int editionYear)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
            EditionYear = editionYear <= 0 ? throw new ArgumentNullException(nameof(authorName)) : editionYear;
        }
    }
}