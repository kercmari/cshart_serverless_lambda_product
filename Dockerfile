
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["MiProyecto/*.csproj", "MiProyecto/"]
COPY ["Domain/*.csproj", "Domain/"]
COPY ["Infrastructure/*.csproj", "Infrastructure/"]
COPY ["Tests/*.csproj", "Tests/"]
COPY ["MiProyecto.sln", "./"]

RUN dotnet restore "MiProyecto/Api.csproj"
COPY . .
RUN dotnet publish "MiProyecto/Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5227
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5227

ENTRYPOINT ["dotnet", "Api.dll"]
