FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
ENV ASPNETCORE_URLS=http://+:1001
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BookStore.Api.csproj", "."]
RUN dotnet restore BookStore.Api.csproj
COPY . .
RUN dotnet build "BookStore.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookStore.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookStore.Api.dll"]