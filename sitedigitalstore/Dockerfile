FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY /. ./sitedigitalstore/
WORKDIR /app/sitedigitalstore
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/sitedigitalstore/out ./
ENTRYPOINT ["dotnet", "sitedigitalstore.dll"]