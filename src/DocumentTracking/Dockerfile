FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY [*.csproj, ./]
COPY [../*.Infrastructure/*.csproj, ./]
COPY [../*.ApplicationCore/*.csproj, ./]
RUN dotnet restore DocumentTracking.Api.csproj
COPY . .
WORKDIR "/src/DocumentTracking"
RUN dotnet build "./DocumentTracking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocumentTracking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocumentTracking.Api.dll"]