# Get Base Image (Full .NET Core SDK)
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build-env
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
WORKDIR /app
EXPOSE 5550
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "ochelotGateway.API.dll"]
