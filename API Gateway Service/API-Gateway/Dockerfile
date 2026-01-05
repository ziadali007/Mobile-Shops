FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. Copy project file from the root context
COPY ["API Gateway Service/API-Gateway/API-Gateway.csproj", "API Gateway Service/API-Gateway/"]

# 2. Restore
RUN dotnet restore "API Gateway Service/API-Gateway/API-Gateway.csproj"

# 3. Copy everything (This pulls in ocelot.json from the subfolder)
COPY . .

# 4. Build
WORKDIR "/src/API Gateway Service/API-Gateway"
RUN dotnet build "API-Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "API-Gateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ... (rest of the build/publish stages)

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Use the EXACT relative path from where you run docker-compose
# Looking at your folder image, this is the path:
COPY ["API Gateway Service/API-Gateway/Ocelot.json", "./"]

ENTRYPOINT ["dotnet", "API-Gateway.dll"]