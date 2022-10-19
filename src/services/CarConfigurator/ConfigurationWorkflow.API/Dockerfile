FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConfigurationWorkflow.API/ConfigurationWorkflow.API.csproj", "ConfigurationWorkflow.API/"]
RUN dotnet restore "ConfigurationWorkflow.API/ConfigurationWorkflow.API.csproj"
COPY . .
WORKDIR "/src/ConfigurationWorkflow.API"
RUN dotnet build "ConfigurationWorkflow.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConfigurationWorkflow.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConfigurationWorkflow.API.dll"]
