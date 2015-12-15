using MassTransit;
using Owin;
using System;
using System.Web.Http;

namespace Reboot.FrontEnd
{
    public class Startup
    {
        public static IBusControl ServiceBus { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            SetupBus();

            app.UseWebApi(config);
        }

        private static void SetupBus()
        {
            ServiceBus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                //sbc.ReceiveEndpoint(host, "test_queue", ep =>
                //{
                //    ep.Handler<YourMessage>(context =>
                //    {
                //        return Console.Out.WriteLineAsync($"Received: {context.Message.Text}");
                //    });
                //});
            });

            ServiceBus.Start();
        }

    }
}