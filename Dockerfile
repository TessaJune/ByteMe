# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY ../ /source
WORKDIR /source/Trainor.Wasm/Server

RUN dotnet restore

RUN dotnet publish --configuration Release --output /app
WORKDIR /app

RUN dotnet ef migrations add dbmigration -s 

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "Trainor.Wasm.Server.dll"]