# syntax=docker/dockerfile:1.7

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
COPY src/Commerce/Commerce.csproj src/Commerce/
COPY tests/Commerce.Tests/Commerce.Tests.csproj tests/Commerce.Tests/
RUN dotnet restore tests/Commerce.Tests/Commerce.Tests.csproj
COPY . .

# Build NuGet package for distribution
FROM base AS dist
RUN dotnet pack src/Commerce/Commerce.csproj -c Release -o /out

# CI target (use in GitHub Actions)
FROM base AS ci
RUN dotnet test tests/Commerce.Tests/Commerce.Tests.csproj -c Release --nologo

# Local/development target
FROM base AS dev
CMD ["bash"]
