FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app

COPY --from=build /app .

RUN rm -rf *.csproj

ENTRYPOINT ["dotnet", "DesafioFrequencia.Api.dll"]