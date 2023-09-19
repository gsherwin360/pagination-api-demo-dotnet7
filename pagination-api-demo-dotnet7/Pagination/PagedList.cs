namespace pagination_api_demo_dotnet7.Pagination;

/// <summary>
/// Represents a paginated list of items with information about the current page and total pages.
/// </summary>
public class PagedList<T>
{
    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public IEnumerable<T> Data { get; set; }

    public PagedList(IEnumerable<T> data, int count, int pageNumber, int pageSize)
    {
        this.CurrentPage = pageNumber;
        this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        this.PageSize = pageSize;
        this.TotalCount = count;
        this.Data = data;
    }

    public static Task<PagedList<T>> CreateAsync(IEnumerable<T>? source, int pageNumber, int pageSize)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var count = source.Count();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        return Task.FromResult(new PagedList<T>(items, count, pageNumber, pageSize));
    }
}
