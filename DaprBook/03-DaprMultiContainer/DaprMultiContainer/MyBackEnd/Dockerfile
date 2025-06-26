FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

ARG APP_UID=1001
ENV APP_UID=$APP_UID

RUN useradd -m -u $APP_UID appuser

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["MyBackEnd/MyBackEnd.csproj", "./"]
RUN dotnet restore "MyBackEnd.csproj"

COPY . .
WORKDIR "/src/MyBackEnd"
RUN dotnet build "MyBackEnd.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyBackEnd.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
ARG APP_UID=1001

WORKDIR /app
COPY --from=publish /app/publish .

RUN chown -R $APP_UID:$APP_UID /app && \
    find /app -type f -exec chmod 644 {} \; && \
    find /app -type d -exec chmod 755 {} \;

USER $APP_UID
ENTRYPOINT ["dotnet", "MyBackEnd.dll"]