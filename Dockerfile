#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BattleCalculatorDemo.API/BattleCalculatorDemo.API.csproj", "BattleCalculatorDemo.API/"]
COPY ["BattleCalculatorDemo.Models/BattleCalculatorDemo.Models.csproj", "BattleCalculatorDemo.Models/"]
COPY ["BattleCalculatorDemo.Crud/BattleCalculatorDemo.Crud.csproj", "BattleCalculatorDemo.Crud/"]
RUN dotnet restore "BattleCalculatorDemo.API/BattleCalculatorDemo.API.csproj"
COPY . .
WORKDIR "/src/BattleCalculatorDemo.API"
RUN dotnet build "BattleCalculatorDemo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BattleCalculatorDemo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BattleCalculatorDemo.API.dll"]