#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Aggregate/Aggregate.csproj", "Aggregate/"]
COPY ["Infrastructure/Infrastructure.EFCore/Infrastructure.EFCore.csproj", "Infrastructure/Infrastructure.EFCore/"]
COPY ["Core/Application/Application.csproj", "Core/Application/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Infrastructure/Infrastructure.Mapper/Infrastructure.Mapper.csproj", "Infrastructure/Infrastructure.Mapper/"]
RUN dotnet restore "./Aggregate/./Aggregate.csproj"
COPY . .
WORKDIR "/src/Aggregate"
RUN dotnet build "./Aggregate.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Aggregate.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aggregate.dll"]