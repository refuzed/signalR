using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace signalR.Hubs
{
    public class ImageHub : Hub
    {
        public void SendClick(string x, string y)
        {
            Clients.All.updateXY(new { x = x, y = y });
        }
    }
}