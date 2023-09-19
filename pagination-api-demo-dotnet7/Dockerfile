#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["pagination-api-demo-dotnet7/pagination-api-demo-dotnet7.csproj", "pagination-api-demo-dotnet7/"]
RUN dotnet restore "pagination-api-demo-dotnet7/pagination-api-demo-dotnet7.csproj"
COPY . .
WORKDIR "/src/pagination-api-demo-dotnet7"
RUN dotnet build "pagination-api-demo-dotnet7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pagination-api-demo-dotnet7.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pagination-api-demo-dotnet7.dll"]