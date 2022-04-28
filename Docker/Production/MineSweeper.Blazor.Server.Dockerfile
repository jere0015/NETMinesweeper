#NOTE1: Docker file is placed here, because the COPY instruction does not support relative pathing fully

# Build code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# copy game engine code
WORKDIR /Code/MineSweeper.Game/
COPY MineSweeper.Game .

# copy Blazor server csproj
WORKDIR /Code/MineSweeper.Blazor.Server/
COPY MineSweeper.Blazor.Server/*.csproj .

# do restore
RUN dotnet restore

# copy Blazor server code
COPY MineSweeper.Blazor.Server .

# publish
RUN dotnet publish -c release -o Build

# Run image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS asp
WORKDIR /Code/MineSweeper.Blazor.Server/Build/
COPY --from=build /Code/MineSweeper.Blazor.Server/Build/ .
ENTRYPOINT ["dotnet", "MineSweeper.Blazor.Server.dll"]