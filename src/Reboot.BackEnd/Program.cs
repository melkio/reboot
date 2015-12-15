using MassTransit;
using System;

namespace Reboot.BackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "backend", endpoint =>
                {
                    endpoint.Consumer<UserCreatedConsumer>();
                });
            });

            bus.Start();

            Console.ReadLine();
        }
    }
}
