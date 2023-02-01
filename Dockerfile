FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ArrExporter.sln .
COPY ArrExporter.csproj .

RUN dotnet restore "ArrExporter.csproj"

COPY . .
RUN dotnet publish "ArrExporter.csproj" -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "ArrExporter.dll"]