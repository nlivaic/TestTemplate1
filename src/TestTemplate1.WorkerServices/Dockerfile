#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate1.WorkerServices/TestTemplate1.WorkerServices.csproj", "src/TestTemplate1.WorkerServices/"]
COPY ["src/TestTemplate1.Core/TestTemplate1.Core.csproj", "src/TestTemplate1.Core/"]
COPY ["src/TestTemplate1.Common/TestTemplate1.Common.csproj", "src/TestTemplate1.Common/"]
RUN dotnet restore "src/TestTemplate1.WorkerServices/TestTemplate1.WorkerServices.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate1.WorkerServices"
RUN dotnet build "TestTemplate1.WorkerServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate1.WorkerServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/TestTemplate1.WorkerServices/entrypoint.sh", "src/entrypoint.sh"]
COPY ["src/TestTemplate1.WorkerServices/wait-for-it.sh", "src/wait-for-it.sh"]
CMD ["/bin/bash", "src/entrypoint.sh"]
