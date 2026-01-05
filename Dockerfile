FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. Copy projects using root-relative paths
COPY ["Apple1.csproj", "./"]
COPY ["Core/Apple1 Services/Apple1 Services.csproj", "Core/Apple1 Services/"]
COPY ["Infrastructure/Presistence/Presistence.csproj", "Infrastructure/Presistence/"]
COPY ["Core/Apple1 Domain/Apple1 Domain.csproj", "Core/Apple1 Domain/"]
COPY ["Core/Apple1 Services.Abstractions/Apple1 Services.Abstractions.csproj", "Core/Apple1 Services.Abstractions/"]
COPY ["Shared/Shared.csproj", "Shared/"]
COPY ["Infrastructure/Presentation/Presentation.csproj", "Infrastructure/Presentation/"]

# 2. Restore
RUN dotnet restore "Apple1.csproj"

# 3. Copy everything and build from the current root (/src)
COPY . .
# FIX: Do NOT WORKDIR into "Apple1" because the file is already in /src
RUN dotnet build "Apple1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Apple1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apple1.dll"]