using System;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace signalR.Hubs
{
    public class SignalHub : Hub
    {
        private static int counter;
        private static bool ticking;

        public void StartTicker()
        {
            if (!ticking)
            {
                ticking = true;
                Task.Run(() => { while (ticking) { Clients.All.addNewMessageToPage(new { name = "Tick", message = counter }); counter++; Thread.Sleep(1000); } });
            }
        }

        public void StopTicker()
        {
            ticking = false;
        }
    }
}