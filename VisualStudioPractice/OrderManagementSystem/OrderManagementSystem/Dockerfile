# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["OrderManagementSystem.csproj", "./"]
RUN dotnet restore "./OrderManagementSystem.csproj"

COPY . .
RUN dotnet publish "OrderManagementSystem.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
RUN mkdir -p /app/logs        
ENTRYPOINT ["dotnet", "OrderManagementSystem.dll"]