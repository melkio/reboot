Vagrant.configure(2) do |config|
  config.vm.box = "ubuntu/trusty64"

  # RabbitMQ
  config.vm.network "forwarded_port", guest: 5672, host: 5672
  config.vm.network "forwarded_port", guest: 15672, host: 15672
  # MongoDB
  config.vm.network "forwarded_port", guest: 27017, host: 27017

  config.vm.provision "docker" do |docker|
    docker.run "broker",
      image: "rabbitmq:3-management",
      daemonize: true,
      args: "-h env01 -p 5672:5672 -p 15672:15672"

    docker.run "db",
      image: "mongo",
      daemonize: true,
      args: "-p 27017:27017"
  end
end
