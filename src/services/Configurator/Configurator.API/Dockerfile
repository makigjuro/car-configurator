FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Configurator/Configurator.API/Configurator.API.csproj", "Configurator/Configurator.API/"]
RUN dotnet restore "Configurator/Configurator.API/Configurator.API.csproj"
COPY . .
WORKDIR "/src/Configurator/Configurator.API"
RUN dotnet build "Configurator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Configurator.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Configurator.API.dll"]
