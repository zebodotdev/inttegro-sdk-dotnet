# syntax=docker/dockerfile:1.7

FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:bb32ba3ba3ea36e38572d9d8db76fa15f7cbf722f3f886e06bca6d528bd4fba8 AS base
WORKDIR /app
COPY src/Inttegro/Inttegro.csproj src/Inttegro/
COPY src/Inttegro/packages.lock.json src/Inttegro/
COPY tests/Inttegro.Tests/Inttegro.Tests.csproj tests/Inttegro.Tests/
COPY tests/Inttegro.Tests/packages.lock.json tests/Inttegro.Tests/
RUN dotnet restore tests/Inttegro.Tests/Inttegro.Tests.csproj --locked-mode
COPY . .

# Build NuGet package for distribution
FROM base AS dist
RUN dotnet pack src/Inttegro/Inttegro.csproj -c Release -o /out --no-restore

# CI target (use in GitHub Actions)
FROM base AS ci
RUN dotnet test tests/Inttegro.Tests/Inttegro.Tests.csproj -c Release --nologo --no-restore

# Local/development target
FROM base AS dev
CMD ["bash"]
