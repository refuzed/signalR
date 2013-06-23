using System;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using TaskEx = System.Threading.Tasks.Task;

namespace signalR.Hubs
{
    public class SignalHub : Hub
    {
        private static int tickspeed;
        private static int counter;
        private static volatile bool ticking;

        public void StartTicker()
        {
            if (!ticking)
            {
                ticking = true;
                if (tickspeed == 0) tickspeed = 1000;
                Task.Run(async () =>
                {
                    while (ticking)
                    {
                        counter++; 
                        Clients.All.addNewMessageToPage(new { name = "Tick", message = counter });
                        await TaskEx.Delay(tickspeed);
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
            if (tickspeed > 50)
            {
                tickspeed -= 50;
                Clients.All.updateTimerOnly(new { tickspeed = tickspeed });
            }
        }

        public void SlowDown()
        {
            tickspeed += 50;
            Clients.All.updateTimerOnly(new { tickspeed = tickspeed });
        }
    }
}