#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY . /app
RUN PWD && ls -l
RUN dotnet restore "SS_EDUP.Web/SS_EDUP.Web.csproj"

RUN dotnet build "SS_EDUP.Web.csproj" -c Release -o /app/build

WORKDIR /app

ENTRYPOINT ["dotnet", "SS_EDUP.Web.dll"]