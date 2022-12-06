
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StudentProjectAttempt6/StudentProjectAttempt6.csproj", "StudentProjectAttempt6/"]
COPY ["StudentProjectAttempt6.Models/StudentProjectAttempt6.Models.csproj", "StudentProjectAttempt6.Models/"]
RUN dotnet restore "StudentProjectAttempt6/StudentProjectAttempt6.csproj"
RUN dotnet restore "StudentProjectAttempt6.Models/StudentProjectAttempt6.Models.csproj"

COPY . .
WORKDIR "/src"
RUN dotnet build "StudentProjectAttempt6/StudentProjectAttempt6.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StudentProjectAttempt6/StudentProjectAttempt6.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StudentProjectAttempt6.dll"]