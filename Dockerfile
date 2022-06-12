# Build code
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# copy game engine code
WORKDIR /code
COPY . .

RUN dotnet restore

RUN dotnet build --no-restore

RUN dotnet test

# NOTE: Bedre idé: Shared volume til source code, og put "dotnet" kommandoer i et script 'entrypoint.sh'

