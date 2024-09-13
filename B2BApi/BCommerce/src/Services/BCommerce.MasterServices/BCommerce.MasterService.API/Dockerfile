#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/BCommerce.MasterServices/BCommerce.MasterService.API/BCommerce.MasterService.API.csproj", "src/Services/BCommerce.MasterServices/BCommerce.MasterService.API/"]
COPY ["src/BuildingBlocks/EventBus/EventBus.csproj", "src/BuildingBlocks/EventBus/"]
COPY ["src/BuildingBlocks/Healthchecks/Healthchecks.csproj", "src/BuildingBlocks/Healthchecks/"]
COPY ["src/Shared/BCommerce.CommonEntities.Shared/BCommerce.CommonEntities.Shared.csproj", "src/Shared/BCommerce.CommonEntities.Shared/"]
COPY ["src/Shared/BCommerce.DataAccess.Shared/BCommerce.DataAccess.Shared.csproj", "src/Shared/BCommerce.DataAccess.Shared/"]
COPY ["src/Shared/BCommerce.Shared/BCommerce.Shared.csproj", "src/Shared/BCommerce.Shared/"]
RUN dotnet restore "./src/Services/BCommerce.MasterServices/BCommerce.MasterService.API/./BCommerce.MasterService.API.csproj"
COPY . .
WORKDIR "/src/src/Services/BCommerce.MasterServices/BCommerce.MasterService.API"
RUN dotnet build "./BCommerce.MasterService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BCommerce.MasterService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCommerce.MasterService.API.dll"]