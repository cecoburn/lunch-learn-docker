FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src/*.csproj ./src/
WORKDIR /app/src
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY src/. ./src/
WORKDIR /app/src
RUN dotnet publish -c Release -o out


# test application -- see: dotnet-docker-unit-testing.md
FROM build AS testrunner
WORKDIR /app/test
COPY test/. .
ENTRYPOINT ["dotnet", "test"]

# run the console application
# FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS runtime
# WORKDIR /app
# COPY --from=build /app/src/out ./
# ENTRYPOINT ["dotnet", "myapp.dll", "5"]
