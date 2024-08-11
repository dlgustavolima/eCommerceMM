FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Services/Pedidos.API/Pedidos.API.csproj", "Services/Pedidos.API/"]
COPY ["./Services/Pedidos.Domain/Pedidos.Domain.csproj", "Services/Pedidos.Domain/"]
COPY ["./Services/Pedidos.Infra/Pedidos.Infra.csproj", "Services/Pedidos.Infra/"]
COPY ["./Building Blocks/Core/Core.csproj", "Building Blocks/Core/"]
COPY ["./Building Blocks/WebApi.Core/WebApi.Core.csproj", "Building Blocks/WebApi.Core/"]
COPY ["./Building Blocks/MessageBus/MessageBus.csproj", "Building Blocks/MessageBus/"]
RUN dotnet restore "Services/Pedidos.API/Pedidos.API.csproj"
COPY . .
WORKDIR "Services/Pedidos.API"
RUN dotnet build "Pedidos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pedidos.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pedidos.API.dll"]