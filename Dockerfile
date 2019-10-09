FROM mcr.microsoft.com/dotnet/core/sdk:2.2.402 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY AppHarbor.sln .
COPY HappyFL/*.csproj ./HappyFL/
COPY HappyFLDB/*.csproj ./HappyFLDB/
RUN dotnet restore

# copy everything else and build app
COPY HappyFL/. ./HappyFL/
COPY HappyFLDB/. ./HappyFLDB/
COPY unsubmodule/. ./unsubmodule/
WORKDIR /app/HappyFL

RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm
RUN npm install -g @angular/cli

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.7 AS runtime
WORKDIR /app
EXPOSE 8080/tcp
ARG ASPNETCORE_ENVIRONMENT=Docker
COPY --from=build /app/HappyFL/out ./
ENTRYPOINT ["dotnet", "HappyFL.dll"]

