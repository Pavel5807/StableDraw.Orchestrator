FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY "Orchestrator.BackgroundTasks/Orchestrator.BackgroundTasks.csproj" "Orchestrator.BackgroundTasks/Orchestrator.BackgroundTasks.csproj"

RUN dotnet restore Orchestrator.BackgroundTasks/Orchestrator.BackgroundTasks.csproj

COPY . .
WORKDIR /src/Orchestrator.BackgroundTasks
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Orchestrator.BackgroundTasks.dll"]
