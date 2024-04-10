namespace UM.Application.Common.DTOs
{
    public class PaginatedList<T>(IReadOnlyCollection<T> items, int totalCount, int pageIndex, int pageSize)
    {
        public int PageIndex { get; } = pageIndex;
        public int TotalPages { get; } = (int)Math.Ceiling(totalCount / (double)pageSize);
        public int TotalCount { get; } = totalCount;
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public IReadOnlyCollection<T> Items { get; } = items;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var count = await source.CountAsync(cancellationToken);

            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
