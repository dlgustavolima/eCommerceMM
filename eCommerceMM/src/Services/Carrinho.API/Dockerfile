FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Services/Carrinho.API/Carrinho.API.csproj", "Services/Carrinho.API/"]
COPY ["./Building Blocks/Core/Core.csproj", "Building Blocks/Core/"]
COPY ["./Building Blocks/WebApi.Core/WebApi.Core.csproj", "Building Blocks/WebApi.Core/"]
COPY ["./Building Blocks/MessageBus/MessageBus.csproj", "Building Blocks/MessageBus/"]
RUN dotnet restore "Services/Carrinho.API/Carrinho.API.csproj"
COPY . .
WORKDIR "Services/Carrinho.API"
RUN dotnet build "Carrinho.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carrinho.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carrinho.API.dll"]