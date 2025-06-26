
# Dapr for .NET Developers

## Dapr Config:
```
$HOME/.dapr/
$HOME/.dapr/components
```
cd ~/Shared/DaprBook/01-DaprCounter/DaprCounter
dapr run --app-id DaprCounter dotnet run

## Install Portainer:
```
from
https://docs.portainer.io/start/install-ce/server/docker/linux

docker volume create portainer_data

docker run -d -p 8000:8000 -p 9443:9443 --name portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce:lts

https://localhost:9443
```
create user w. pass

## How to connect to Dapr redis to check state value

sudo apt-get install redis-tools

redis-cli -h localhost -p 6379

```
dmitry@mint-vm:~/.dapr/components$ redis-cli -h localhost -p 6379
localhost:6379> PING
PONG

localhost:6379> KEYS *
1) "DaprCounter||counter"
```

Dapr typically stores state as a Redis hash. 
To inspect the value, use the HGETALL command:
`HGETALL` is a Redis command used to retrieve all fields and values from a hash stored at a specific key.


```
localhost:6379> HGETALL "DaprCounter||counter"
1) "data"
2) "29"
3) "version"
4) "29"
```

## Git Config:
git config --global --add safe.directory /home/dmitry/Shared/dapr-tutor
git config --global user.email "dpoluektov@gmail.com"
git config --global user.name "Dmitry Poluektov"



For Backend Api:

By default, a Dapr sidecar relies on the network boundary to limit access to its public API. So,
clear the checkbox for Configure for HTTPS:
> [!IMPORTANT]
> If you leave the **Configure for HTTPS** checkbox checked, the generated ASP.NET
Core API project includes middleware to redirect client requests to the HTTPS
endpoint. This breaks communication between the Dapr sidecar and your application,
unless you explicitly configure the use of HTTPS when running your Dapr application.
To enable the Dapr sidecar to communicate over HTTPS, include the [`--appssl`]{custom-style=Code} flag in the Dapr command to start the application. Also
specify the HTTPS port using the [`--app-port`]{custom-style=Code} parameter. The
remainder of this walkthrough uses plain HTTP communication between the sidecar and
the application, and requires you to clear the **Configure for HTTPS** checkbox.

Frontend:
Install-Package Dapr.AspNetCore


docker compose version
 Docker Compose version v2.37.3
docker compose up --build

https://docs.docker.com/compose/how-tos/file-watch/

dotnet build DaprMultiContainer.sln 

docker compose logs myfrontend

docker compose build --no-cache myfrontend

To generate a developer certificate run 'dotnet dev-certs https'. 
To trust the certificate (Windows and macOS only) run 'dotnet dev-certs https --trust'.

docker compose build --no-cache

On Windows and Mac, NOT on Linux?:
dotnet dev-certs https
dotnet dev-certs https --trust

docker compose down -v
docker compose up --build


