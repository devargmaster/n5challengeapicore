FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CoreWebApi/CoreWebApi.csproj", "CoreWebApi/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Exceptions/Exceptions.csproj", "Exceptions/"]
RUN dotnet restore "CoreWebApi/CoreWebApi.csproj"
COPY . .
WORKDIR "/src/CoreWebApi"
RUN dotnet restore
RUN dotnet build "CoreWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CoreWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "CoreWebApi.dll"]
