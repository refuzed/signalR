using System;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace signalR.Hubs
{
    public class SignalHub : Hub
    {
        private static int tickspeed;
        private static int counter;
        private static volatile bool ticking;

        public void StartTicker()
        {
            if (tickspeed == 0) tickspeed = 1000;

            if (!ticking)
            {
                ticking = true;
                Task.Run(() =>
                {
                    while (ticking)
                    {
                        counter++; 
                        Clients.All.addNewMessageToPage(new { name = "Tick", message = counter, tickspeed = tickspeed }); 
                        Thread.Sleep(tickspeed);
                    }
                });
            }
        }

        public void StopTicker()
        {
            ticking = false;
        }

        public void ResetTicker()
        {
            counter = 0;
        }

        public void SpeedUp()
        {
            if (tickspeed > 100)
                tickspeed -= 100;
        }

        public void SlowDown()
        {
            tickspeed += 100;
        }
    }
}