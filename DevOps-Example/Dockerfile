FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DevOps-Example/DevOps-Example.csproj", "DevOps-Example/"]
RUN dotnet restore "DevOps-Example/DevOps-Example.csproj"
COPY . .
WORKDIR "/src/DevOps-Example"
RUN dotnet build "DevOps-Example.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevOps-Example.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevOps-Example.dll"]