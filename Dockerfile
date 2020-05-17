FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY JWTAuthApi.Web/*.csproj ./JWTAuthApi.Web/
COPY JWTAuthApi.Services/*.csproj ./JWTAuthApi.Services/
COPY JWTAuthApi.Data/*.csproj ./JWTAuthApi.Data/ 
COPY JWTAuthApi.Core/*.csproj ./JWTAuthApi.Core/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY JWTAuthApi.Web/. ./JWTAuthApi.Web/
COPY JWTAuthApi.Services/. ./JWTAuthApi.Services/ 
COPY JWTAuthApi.Data/. ./JWTAuthApi.Data/
COPY JWTAuthApi.Core/. ./JWTAuthApi.Core/ 
RUN mkdir -p JWTAuthApi.Data/Database
RUN mkdir -p .JWTAuthApi.Data/Database
RUN mkdir dupa
COPY JWTAuthApi.Data/Database/applicationDatabase.db JWTAuthApi.Data/Database/applicationDatabase.db
COPY JWTAuthApi.Data/Database/applicationDatabase.db .JWTAuthApi.Data/Database/applicationDatabase.db
COPY JWTAuthApi.Data/Database/applicationDatabase.db .applicationDatabase.db
#
WORKDIR /app/
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/out ./
RUN mkdir -p ../JWTAuthApi.Data/Database
COPY JWTAuthApi.Data/Database/applicationDatabase.db ../JWTAuthApi.Data/Database/applicationDatabase.db
ENTRYPOINT ["dotnet", "JWTAuthApi.Web.dll"]