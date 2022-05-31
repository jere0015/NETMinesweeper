# Build code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# copy game engine code
WORKDIR /Code/MineSweeper.Game/
COPY MineSweeper.Game .

# copy game server csproj
WORKDIR /Code/MineSweeper.API.Game/
COPY MineSweeper.API.Game/*.csproj .

# do restore
RUN dotnet restore

# copy game server code
COPY MineSweeper.API.Game .

# publish
RUN dotnet publish -c release -o Build

# Run image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS asp
WORKDIR /Code/MineSweeper.API.Game/Build/
COPY --from=build /Code/MineSweeper.API.Game/Build/ .
ENTRYPOINT ["dotnet", "MineSweeper.API.Game.dll"]