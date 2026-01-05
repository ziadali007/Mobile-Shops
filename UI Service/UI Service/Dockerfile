# Base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. Copy all project files individually to leverage Docker layer caching
# These paths are relative to your Solution Root (D:\Hatem Shops\Apple1 Service)
COPY ["UI Service/UI Service/UI Service.csproj", "UI Service/UI Service/"]
COPY ["UI Service/Business Logic Layer/Business Logic Layer.csproj", "UI Service/Business Logic Layer/"]
COPY ["UI Service/Shared.UI/Shared.UI.csproj", "UI Service/Shared.UI/"]
COPY ["UI Service/Presentation Layer/Presentation Layer.csproj", "UI Service/Presentation Layer/"]

# 2. Restore dependencies for the main entry project
RUN dotnet restore "UI Service/UI Service/UI Service.csproj"

# 3. Copy the entire solution context
COPY . .

# 4. Move to the main project folder and build
WORKDIR "/src/UI Service/UI Service"
RUN dotnet build "UI Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 5. Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UI Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 6. Final stage: Copy the build results to the runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UI Service.dll"]