# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
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

FROM base AS final
WORKDIR /src
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","Furni.API.dll" ]