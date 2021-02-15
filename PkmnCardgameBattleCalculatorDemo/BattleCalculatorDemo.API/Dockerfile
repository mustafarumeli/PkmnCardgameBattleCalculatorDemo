FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base

WORKDIR /app

COPY ./publish .

ENTRYPOINT ["dotnet", "BattleCalculatorDemo.API.dll"]
