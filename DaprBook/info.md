
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
