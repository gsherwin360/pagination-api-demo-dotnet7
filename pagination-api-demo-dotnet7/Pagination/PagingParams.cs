namespace pagination_api_demo_dotnet7.Pagination;

/// <summary>
/// Represents parameters for pagination and sorting in a list of items.
/// </summary>
public class PagingParams
{
    private const int MaxPageSize = 50;

    private int _pageSize = 10;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => this._pageSize;
        set => this._pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public string? SearchText { get; set; }

    public string? SortBy { get; set; }

    public string? SortDirection { get; set; }
}