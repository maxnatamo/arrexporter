# ArrExporter

ArrExporter is a simple standalone application that can query other self-hosted applications, like Tautulli and the *Arr-suite. It ingests the data into an Influx database, so it can be used with Grafana. 

Currently, only Tautulli and Radarr are supported, but support for Sonarr and Overseerr is planned.

## Getting Started

To use ArrExporter, you need to have [Docker](https://docs.docker.com/get-docker/) and [Docker Compose](https://docs.docker.com/compose/install/) installed on your machine.

First, create a `docker-compose.yml`

```yml
version: "3.7"

services:
  influx:
    image: influxdb:latest
    container_name: influxdb
    ports:
      - 8086:8086
    environment:
      - DOCKER_INFLUXDB_INIT_MODE=setup
      - DOCKER_INFLUXDB_INIT_USERNAME=tautulli # Only used for WebUI
      - DOCKER_INFLUXDB_INIT_PASSWORD=tautulli # Only used for WebUI
      - DOCKER_INFLUXDB_INIT_ORG=arrexporter
      - DOCKER_INFLUXDB_INIT_BUCKET=arrexporter
      - DOCKER_INFLUXDB_INIT_ADMIN_TOKEN=my-super-secret-auth-token
    restart: unless-stopped

  arrexporter:
    image: ghcr.io/maxnatamo/arrexporter:latest
    container_name: arrexporter
    environment:
      - INFLUX_URL=http://influx:8086
      - INFLUX_TOKEN=my-super-secret-auth-token
      - INFLUX_ORG=arrexporter
      - INFLUX_BUCKET=arrexporter

      - TAUTULLI_URL=true # Set to false to disable
      - TAUTULLI_URL=http://tautulli:8086 # URL to your Tautulli instance.
      - TAUTULLI_API_KEY= # API key from Tautulli: Settings -> Web Interface

      - RADARR_ENABLED=true # Set to false to disable
      - RADARR_URL=http://radarr:7878 # URL to your Radarr instance.
      - RADARR_API_KEY= # API key from Radarr: Settings -> General
    depends_on:
      - influx
    restart: unless-stopped
```

# Contributing

🎉 Hey, thanks for taking the time to contribute! 🎉

Check out some of the open issues and see if anything fits your skills. If you have an idea for a new feature, you can also open a new issue.

If that doesn't fit, you can also write documentation or fix typos, as there might be a handful.