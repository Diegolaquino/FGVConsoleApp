namespace FGVConsoleApp.Service
{
    using FGVConsoleApp.Exception;
    using FGVConsoleApp.Extensions;
    using FGVConsoleApp.Model;
    using System.Linq;
    using System.Linq.Expressions;

    public class BooksOrderer : IBooksOrderer
    {
        private readonly IReadOnlyCollection<SortRule> _rules;

        public BooksOrderer(IReadOnlyCollection<SortRule> rules)
        {
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }

        public IReadOnlyCollection<Book> Order(IReadOnlyCollection<Book> books)
        {
            if (books == null || books.Count == 0)
                throw new OrdenacaoException("Conjunto de livros vazio ou nulo.");

            IOrderedEnumerable<Book>? ordered = null;

            foreach (var rule in _rules)
            {
                if (!BookSortExpressions.Map.TryGetValue(rule.PropertyName, out var expression))
                    throw new OrdenacaoException($"Propriedade inválida para ordenação: {rule.PropertyName}");

                ordered = ordered == null ? ApplyOrdering(books, expression, rule.Direction) : ApplyOrdering(ordered, expression, rule.Direction);
            }

            return ordered!.ToList();
        }

        private static IOrderedEnumerable<Book> ApplyOrdering(
            IEnumerable<Book> source,
            Expression<Func<Book, object>> expression,
            SortDirection direction)
        {
            if (source is IOrderedEnumerable<Book> ordered)
            {
                return direction == SortDirection.Ascending
                    ? ordered.ThenBy(expression.Compile())
                    : ordered.ThenByDescending(expression.Compile());
            }

            return direction == SortDirection.Ascending
                ? source.OrderBy(expression.Compile())
                : source.OrderByDescending(expression.Compile());
        }
    }
}
