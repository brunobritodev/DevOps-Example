FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DevOps-Example/DevOps-Example.csproj", "DevOps-Example/"]
RUN dotnet restore "DevOps-Example/DevOps-Example.csproj"
COPY . .
WORKDIR "/src/DevOps-Example"
RUN dotnet build "DevOps-Example.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DevOps-Example.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DevOps-Example.dll"]