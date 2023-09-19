using pagination_api_demo_dotnet7.Extension;
using System.Globalization;

namespace pagination_api_demo_dotnet7.Pagination;

/// <summary>
/// Represents a sorted list of items based on specified sorting criteria.
/// </summary>
public class SortList<T> : List<T>
{
    public SortList(IQueryable<T> items)
    {
        this.AddRange(items);
    }

    public static Task<SortList<T>> CreateAsync(IQueryable<T> source, PagingParams pagingParams)
    {
        var items = source;

        if (pagingParams.SortDirection != null)
        {
            var sortDirection = pagingParams.SortDirection.ToLowerInvariant();

            if (sortDirection == "asc")
            {
                items = items.OrderByString(pagingParams.SortBy).AsQueryable();
            }
            else if (sortDirection   == "desc")
            {
                items = items.OrderByStringDescending(pagingParams.SortBy).AsQueryable();
            }
        }
        else
        {
            items = items.OrderBy(x => x.GetType().GetProperty(pagingParams.SortBy)).AsQueryable();
        }

        return Task.FromResult(new SortList<T>(items));
    }
}