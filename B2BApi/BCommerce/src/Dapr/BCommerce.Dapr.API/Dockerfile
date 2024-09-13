#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Dapr/BCommerce.Dapr.API/BCommerce.Dapr.API.csproj", "src/Dapr/BCommerce.Dapr.API/"]
COPY ["src/Shared/BCommerce.Shared/BCommerce.Shared.csproj", "src/Shared/BCommerce.Shared/"]
RUN dotnet restore "./src/Dapr/BCommerce.Dapr.API/./BCommerce.Dapr.API.csproj"
COPY . .
WORKDIR "/src/src/Dapr/BCommerce.Dapr.API"
RUN dotnet build "./BCommerce.Dapr.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BCommerce.Dapr.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BCommerce.Dapr.API.dll"]