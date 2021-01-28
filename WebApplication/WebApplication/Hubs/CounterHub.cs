using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Hubs
{


    public class CounterHub : Hub
    {

        static int ClientConection = 0;

        public  override  Task OnConnectedAsync()
        {
            ClientConection++;
            Clients.All.SendAsync("ReceiveCounter", ClientConection);
            return base.OnConnectedAsync();
        }


        public  override Task OnDisconnectedAsync(Exception exception)
        {
            ClientConection--;
             Clients.All.SendAsync("ReceiveCounter", ClientConection);
            return base.OnDisconnectedAsync(exception);
        }





    }
    
}
