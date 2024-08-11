FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./Web/MVC/WebMVC/WebMVC.csproj", "Web/MVC/WebMVC/"]
COPY ["./Building Blocks/Core/Core.csproj", "Building Blocks/Core/"]
COPY ["./Building Blocks/WebApi.Core/WebApi.Core.csproj", "Building Blocks/WebApi.Core/"]
RUN dotnet restore "Web/MVC/WebMVC/WebMVC.csproj"
COPY . .
WORKDIR "Web/MVC/WebMVC"
RUN dotnet build "WebMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMVC.dll"]