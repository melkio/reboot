using System.Threading.Tasks;
using MassTransit;
using Reboot.Messages;
using MongoDB.Driver;

namespace Reboot.BackEnd
{
    public class UserCreatedConsumer : IConsumer<UserCreated>
    {
        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("users");
            var collection = database.GetCollection<Log>("logs");

            var item = new Log
            {
                Type = "UserCreated",
                Payload = context.Message
            };

            await collection.InsertOneAsync(item);
        }
    }
}