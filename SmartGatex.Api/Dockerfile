#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SmartGatex.Api/SmartGatex.Api.csproj", "SmartGatex.Api/"]
COPY ["SmartGatex.Business/SmartGatex.Business.csproj", "SmartGatex.Business/"]
COPY ["SmartGatex.DataAccess/SmartGatex.DataAccess.csproj", "SmartGatex.DataAccess/"]
COPY ["SmartGatex.Entity/SmartGatex.Entity.csproj", "SmartGatex.Entity/"]
RUN dotnet restore "SmartGatex.Api/SmartGatex.Api.csproj"
COPY . .
WORKDIR "/src/SmartGatex.Api"
RUN dotnet build "SmartGatex.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartGatex.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartGatex.Api.dll"]