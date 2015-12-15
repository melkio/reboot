using Reboot.Messages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Reboot.FrontEnd
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        [Route]
        [HttpPost]
        public HttpResponseMessage Post(Model model)
        {
            var message = new UserCreated
            {
                Name = model.Name,
                Surname = model.Surname
            };
            Startup.ServiceBus.Publish(message);

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        public class Model
        {
            public String Name { get; set; }
            public String Surname { get; set; }
        }
    }
}