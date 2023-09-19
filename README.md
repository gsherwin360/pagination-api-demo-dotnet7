# Pagination API Demo (.NET 7)

In this demo app, I have implemented pagination within .NET 7 Web API utilizing the `WeatherForecastController`. The controller is configured to manage an array of 22 weather-related summaries, serving as the foundation for our pagination demo.

Pagination is a crucial aspect of building scalable and responsive APIs, allowing you to deliver data in manageable chunks, which is important when dealing with large datasets. 

## Request Payload - PagingParams

To control pagination and sorting in the list of items, The `PagingParams` class representing the request payload. This class provides the following parameters:

- `PageNumber`: Specifies the current page number (default: 1).
- `PageSize`: Specifies the number of items per page, with a maximum limit of 50 (default: 10).
- `SearchText`: Allows searching for specific items based on a search query.
- `SortBy`: Defines the field by which items should be sorted.
- `SortDirection`: Specifies the sorting direction (e.g., asc or desc).

## Response Data Example

```json
{
  "currentPage": 1,
  "totalPages": 3,
  "pageSize": 10,
  "totalCount": 22,
  "data": [
    {
      "date": "2023-09-20",
      "temperatureC": 20,
      "temperatureF": 67,
      "summary": "Bracing"
    },
    // ... (Additional data entries)
  ]
}
```
