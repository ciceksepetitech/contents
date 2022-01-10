
Start the docker container by running the following command.

```
docker compose build
```

```
docker compose up
```

Run the tests by running the following command.

Integration test:
```
docker run --network container:userservice-container \postman/newman_ubuntu1404 run https://www.getpostman.com/collections/e42031a2a39a809284c0
```
CDC test:
```
docker run --network container:userservice-container \postman/newman_ubuntu1404 run https://www.getpostman.com/collections/2a1fae3f34ccf53c9ad9 --folder UserCDC
```
Performance test:
```
docker build -t cs-taurus -f ./.build/Dockerfile.taurus .

docker run --network container:userservice-container cs-taurus /bzt-configs/loadtest.yml
```
