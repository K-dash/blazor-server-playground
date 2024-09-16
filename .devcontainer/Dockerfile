FROM mcr.microsoft.com/devcontainers/dotnet:1-8.0-bookworm

# Install PostgreSQL client
RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends postgresql-client
