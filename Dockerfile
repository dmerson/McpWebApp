# Use the official .NET 9 SDK preview image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET 9 ASP.NET runtime preview image for the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "McpWebApp.dll"]