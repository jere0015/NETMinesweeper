# Build code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# copy game engine code
WORKDIR /Code/MineSweeper.Game/
COPY MineSweeper.Game .

# copy game server csproj
WORKDIR /Code/MineSweeper.Game.Server/
COPY MineSweeper.Game.Server/*.csproj .

# do restore
RUN dotnet restore

# copy game server code
COPY MineSweeper.Game.Server .

# publish
RUN dotnet publish -c release -o Build

# Run image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS asp
WORKDIR /Code/MineSweeper.Game.Server/Build/
COPY --from=build /Code/MineSweeper.Game.Server/Build/ .
ENTRYPOINT ["dotnet", "MineSweeper.Game.Server.dll"]