FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./ApiGateways/Bff.Compras/Bff.Compras.csproj", "ApiGateways/Bff.Compras/"]
COPY ["./Building Blocks/Core/Core.csproj", "Building Blocks/Core/"]
COPY ["./Building Blocks/WebApi.Core/WebApi.Core.csproj", "Building Blocks/WebApi.Core/"]
COPY ["./Building Blocks/MessageBus/MessageBus.csproj", "Building Blocks/MessageBus/"]
RUN dotnet restore "ApiGateways/Bff.Compras/Bff.Compras.csproj"
COPY . .
WORKDIR "ApiGateways/Bff.Compras"
RUN dotnet build "Bff.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bff.Compras.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bff.Compras.dll"]