# Pagination API Demo (.NET 7)
In this demo app, I've implemented pagination within .NET 7 Web API utilizing the `WeatherForecastController`. The controller is configured to manage an array of 22 weather-related summaries, serving as the foundation for our pagination demo.

Pagination is a crucial aspect of building scalable and responsive APIs, allowing you to deliver data in manageable chunks, which is important when dealing with large datasets. 

## Key Features
- **Pagination:** Efficiently manage large datasets by paginating results.
- **Sorting:** Sort items based on specified criteria.
- **Searching:** Search for specific items using a search query.

## Query Parameters
Include these parameters in your request URL to utilize the pagination, sorting, and searching features:
- `PageNumber`: Specifies the current page number (default: 1).
- `PageSize`: Specifies the number of items per page, with a maximum limit of 50 (default: 10).
- `SearchText`: Allows searching for specific items based on a search query.
- `SortBy`: Defines the field by which items should be sorted.
- `SortDirection`: Specifies the sorting direction (e.g., asc or desc).
  
Example request URL: `http://localhost:5114/WeatherForecast?PageNumber=1&PageSize=1&SearchText=sunny&SortBy=summary&SortDirection=desc`

## Sample JSON Response
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

## Development Prerequisites
Before diving into development with this project, ensure you have the following prerequisites:
- **Development Environment:** Either Visual Studio 2022 (IDE) or Visual Studio Code (Source-code editor)
- **.NET 7:** Required framework version for building and running the project

## Getting Started
To run the API locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the project in your preferred development environment.
3. Build and run the project.
4. Access the API documentation via [Swagger](http://localhost:5114/swagger/index.html) in your web browser while the API is running.
