using FGVConsoleApp.Model;

namespace FGVConsoleApp.Seed
{
    public static class Faker
    {
        public static IReadOnlyCollection<Book> CriarConjuntoPadraoDeLivros()
        {
                    return new List<Book>
                    {
                        new Book(
                            title: "Java How to Program",
                            authorName: "Deitel & Deitel",
                            editionYear: 2007),

                        new Book(
                            title: "Patterns of Enterprise Application Architecture",
                            authorName: "Martin Fowler",
                            editionYear: 2002),

                        new Book(
                            title: "Head First Design Patterns",
                            authorName: "Elisabeth Freeman",
                            editionYear: 2004),

                        new Book(
                            title: "Internet & World Wide Web: How to Program",
                            authorName: "Deitel & Deitel",
                            editionYear: 2007)
                    };
                }
    }
}
