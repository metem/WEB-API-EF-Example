FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build

RUN apt-get update -yq \
&& apt-get install curl gnupg -yq \
&& curl -sL https://deb.nodesource.com/setup_8.x | bash \
&& apt-get install nodejs -yq

WORKDIR /src
COPY ["BookStore.Web.csproj", "."]
RUN dotnet restore BookStore.Web.csproj
COPY . .
WORKDIR "/src"
RUN dotnet build "BookStore.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BookStore.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BookStore.Web.dll"]