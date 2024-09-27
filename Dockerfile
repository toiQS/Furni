# syntax=docker/dockerfile:1

################################################################################
# Stage 1: Build the application
################################################################################

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

# Install ICU package for globalization support
RUN apk add --no-cache icu-libs

# Set environment variable to enable globalization support (disable invariant mode)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
COPY . /source

WORKDIR /source/Furni.API

# Replace TARGETARCH value if "amd64" is used, as .NET uses "x64"
ARG TARGETARCH

# Build the application with caching enabled for NuGet packages
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

    ARG BUILD_CONFIGURATION=Release
    WORKDIR /src
    COPY ["Furni.API/Furni.API.csproj","Furni.API/"]
    COPY ["Furni.Data/Furni.Data.csproj","Furni.Data.csproj/"]
    COPY ["Furni.Entities/Furni.Entities.csproj","Furni.Entities/"]
    COPY ["Furni.Services/Furni.Services.csproj","Furni.Services/"]
    RUN dotnet restore "./Furni.API/Furni.API.csproj"
    COPY . .
    WORKDIR "/src/Furni.API"
    RUN dotnet build "./Furni.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
    
    FROM build AS publish
    ARG BUILD_CONFIGURATION=Release
    RUN dotnet build "./Furni.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

################################################################################
# Stage 2: Run the application
################################################################################

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final

WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app .

# Set environment variable for culture (optional)
# Uncomment if you want to force a specific culture globally, e.g., en-US
# ENV LANG en_US.UTF-8

# Use a non-privileged user for security purposes
USER $APP_UID

# Start the application
# ENTRYPOINT ["dotnet", "Furni.API.dll"]

