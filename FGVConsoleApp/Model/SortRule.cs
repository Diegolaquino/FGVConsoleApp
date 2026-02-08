namespace FGVConsoleApp.Model
{
    public class SortRule
    {
        public string PropertyName { get; }
        public SortDirection Direction { get; }

        public SortRule(string propertyName, SortDirection direction)
        {
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            Direction = direction;
        }

    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
