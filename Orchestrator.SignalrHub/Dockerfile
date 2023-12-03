FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY "Orchestrator.SignalrHub/Orchestrator.SignalrHub.csproj" "Orchestrator.SignalrHub/Orchestrator.SignalrHub.csproj"

RUN dotnet restore Orchestrator.SignalrHub/Orchestrator.SignalrHub.csproj

COPY . .
WORKDIR /src/Orchestrator.SignalrHub
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Orchestrator.SignalrHub.dll"]
