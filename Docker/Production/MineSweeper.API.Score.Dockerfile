# Build code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build


# copy game engine code
WORKDIR /MineSweeper.Game/
COPY MineSweeper.Game .

# copy api csproj
WORKDIR /MineSweeper.API.Score/
COPY MineSweeper.API.Score/*.csproj .

# do restore
RUN dotnet restore

COPY MineSweeper.API.Score .

# publish
RUN dotnet publish -c release -o Build

# Run image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS asp
WORKDIR MineSweeper.API.Score/Build/
COPY --from=build MineSweeper.API.Score/Build/ .
ENTRYPOINT ["dotnet", "MineSweeper.API.Score.dll"]