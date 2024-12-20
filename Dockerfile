FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
EXPOSE 8080
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN cd blazor10.Web
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App/blazor10.Web
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "blazor10.dll"]