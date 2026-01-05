# Base image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. Copy the project file using the relative path from the Solution Root
# We use quotes because of the spaces in "Auth Service"
COPY ["Auth Service/Auth Service/Auth Service.csproj", "Auth Service/Auth Service/"]

# 2. Restore dependencies
RUN dotnet restore "Auth Service/Auth Service/Auth Service.csproj"

# 3. Copy the entire solution context
COPY . .

# 4. Set working directory to the specific project folder and build
WORKDIR "/src/Auth Service/Auth Service"
RUN dotnet build "Auth Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 5. Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Auth Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 6. Final stage: Copy published files to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth Service.dll"]