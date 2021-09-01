#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["WalkToFlayApi/WalkToFlayApi.csproj", "WalkToFlayApi/"]
COPY ["WalkToFlayApi.Common/WalkToFlayApi.Common.csproj", "WalkToFlayApi.Common/"]
COPY ["WalkToFlayApi.Service/WalkToFlayApi.Service.csproj", "WalkToFlayApi.Service/"]
COPY ["WalkToFlayApi.Repository/WalkToFlayApi.Repository.csproj", "WalkToFlayApi.Repository/"]
RUN dotnet restore "WalkToFlayApi/WalkToFlayApi.csproj"
COPY . .
WORKDIR "/src/WalkToFlayApi"
RUN dotnet build "WalkToFlayApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WalkToFlayApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WalkToFlayApi.dll"]