using FGVConsoleApp.Exception;

namespace FGVConsoleApp.Model
{
    public interface IBooksOrderer
    {
        IReadOnlyCollection<Book> Order(IReadOnlyCollection<Book> books);
    }
}