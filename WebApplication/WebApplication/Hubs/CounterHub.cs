using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Hubs
{
    public class CounterHub : Hub
    {
        static int counter = 0;

        public void Increment()
        {
            counter++;

           // Clients.All.newClient(counter);
        
        }

    }
}
