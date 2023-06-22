#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
# Uncomment if you have other certs this services needs to trust.
#COPY nginx/id-local.crt /usr/local/share/ca-certificates/id-local.crt
#RUN update-ca-certificates
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate1.Api/TestTemplate1.Api.csproj", "src/TestTemplate1.Api/"]
COPY ["src/TestTemplate1.Data/TestTemplate1.Data.csproj", "src/TestTemplate1.Data/"]
COPY ["src/TestTemplate1.Common/TestTemplate1.Common.csproj", "src/TestTemplate1.Common/"]
COPY ["src/TestTemplate1.Core/TestTemplate1.Core.csproj", "src/TestTemplate1.Core/"]
RUN dotnet restore "src/TestTemplate1.Api/TestTemplate1.Api.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate1.Api"
RUN dotnet build "TestTemplate1.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate1.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTemplate1.Api.dll"]