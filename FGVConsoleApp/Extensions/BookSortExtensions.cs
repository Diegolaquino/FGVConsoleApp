using FGVConsoleApp.Model;
using System.Linq.Expressions;

namespace FGVConsoleApp.Extensions
{
    public static class BookSortExpressions
    {
        public static readonly IReadOnlyDictionary<string, Expression<Func<Book, object>>> Map =
            new Dictionary<string, Expression<Func<Book, object>>>(StringComparer.OrdinalIgnoreCase)
            {
                { "Title", b => b.Title },
                { "AuthorName", b => b.AuthorName },
                { "EditionYear", b => b.EditionYear }
            };
    }
}
