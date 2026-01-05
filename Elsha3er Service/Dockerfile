FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. Copy all project files using the exact paths from your file explorer
COPY ["Elsha3er Service/Elsha3er.csproj", "Elsha3er Service/"]
COPY ["Elsha3er Service/Core/Elsha3er Services/Elsha3er Services.csproj", "Elsha3er Service/Core/Elsha3er Services/"]
COPY ["Elsha3er Service/Infrastructure/Elsha3er Presistence/Elsha3er Presistence.csproj", "Elsha3er Service/Infrastructure/Elsha3er Presistence/"]
COPY ["Elsha3er Service/Core/Elsha3er Domain/Elsha3er Domain.csproj", "Elsha3er Service/Core/Elsha3er Domain/"]
COPY ["Elsha3er Service/Core/Elsha3er Services.Abstractions/Elsha3er Services.Abstractions.csproj", "Elsha3er Service/Core/Elsha3er Services.Abstractions/"]
COPY ["Elsha3er Service/Infrastructure/Elsha3er Presentation/Elsha3er Presentation.csproj", "Elsha3er Service/Infrastructure/Elsha3er Presentation/"]

# FIX: Copy Shared project into the path expected by the other projects
COPY ["Elsha3er Service/Elsha3er Shared/Elsha3er_Shared.csproj", "Elsha3er Service/Elsha3er Shared/"]

# 2. Restore
RUN dotnet restore "Elsha3er Service/Elsha3er.csproj"

# 3. Copy the entire source code
COPY . .

# 4. Move to the main project folder
WORKDIR "/src/Elsha3er Service"

# 5. Build (This will now find the Shared project correctly)
RUN dotnet build "Elsha3er.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ... (rest of build stage remains same)

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# Add --no-restore because we already did it, and ensure it builds everything
RUN dotnet publish "Elsha3er.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Ensure we clear any old state
ENTRYPOINT ["dotnet", "Elsha3er.dll"]