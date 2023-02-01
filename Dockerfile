FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ArrExporter.sln .
COPY ArrExporter.Core/*.csproj ./ArrExporter.Core/
COPY ArrExporter.Influx/*.csproj ./ArrExporter.Influx/
COPY ArrExporter.Module.Radarr/*.csproj ./ArrExporter.Module.Radarr/
COPY ArrExporter.Module.Tautulli/*.csproj ./ArrExporter.Module.Tautulli/
COPY ArrExporter.Shared/*.csproj ./ArrExporter.Shared/

RUN dotnet restore "ArrExporter.Core/ArrExporter.Core.csproj"

COPY . .
RUN dotnet publish "ArrExporter.Core/ArrExporter.Core.csproj" -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "ArrExporter.Core.dll"]