FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Services/Pagamentos.API/Pagamentos.API.csproj", "Services/Pagamentos.API/"]
COPY ["./Services/Pagamentos.MMPag/Pagamentos.MMPag.csproj", "Services/Pagamentos.MMPag/"]
COPY ["./Building Blocks/Core/Core.csproj", "Building Blocks/Core/"]
COPY ["./Building Blocks/WebApi.Core/WebApi.Core.csproj", "Building Blocks/WebApi.Core/"]
COPY ["./Building Blocks/MessageBus/MessageBus.csproj", "Building Blocks/MessageBus/"]
RUN dotnet restore "Services/Pagamentos.API/Pagamentos.API.csproj"
COPY . .
WORKDIR "Services/Pagamentos.API"
RUN dotnet build "Pagamentos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pagamentos.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pagamentos.API.dll"]