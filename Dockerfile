FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
MAINTAINER Trofimchuk Andrii
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . .
RUN dotnet restore "SS_EDUP.Web/SS_EDUP.Web.csproj"

# Install the dotnet-ef tool locally
RUN dotnet tool install -g dotnet-ef --version 7.0.7
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet-ef database update --startup-project "SS_EDUP.Web" --project "SS_EDUP.Infrastructure/SS_EDUP.Infrastructure.csproj"

RUN dotnet publish "SS_EDUP.Web/SS_EDUP.Web.csproj" -c Release -o /app/build
WORKDIR /app/build
EXPOSE 80
ENTRYPOINT ["dotnet", "SS_EDUP.Web.dll", "--urls=http://0.0.0.0:80"]
