FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
MAINTAINER Trofimchuk Andrii
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . /app
WORKDIR /app/SS_EDUP.Web

RUN dotnet restore "SS_EDUP.Web.csproj"

RUN dotnet publish "SS_EDUP.Web.csproj" -c Release -o /app/build
WORKDIR /app/build
ENTRYPOINT ["dotnet", "SS_EDUP.Web.dll", "--urls=http://0.0.0.0:80"]
