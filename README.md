- Setup [Docker Toolbox](https://www.docker.com/docker-toolbox)
- Setup *RabbitMQ* (and management plugin) container
    + docker run -d -p 15672:15672 -p 5672:5672 --hostname env01 --name broker rabbitmq:3-management
- Setup *MongoDB* container
    + docker run -d -p 27017:27017 --name db mongo