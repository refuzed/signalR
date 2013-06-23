using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace signalR.Hubs
{
    public class ImageHub : Hub
    {
        private static readonly Random rand = new Random();

        public void SendClick(string x, string y)
        {
            Clients.All.updateXY(new { x = x, y = y });
        }

        public void SendPaint(string x, string y)
        {
            Clients.All.paintXY(new { x = x, y = y, fill = GetRandomColorRGB() });
        }
        
        private object GetRandomColorRGB()
        {
            var r = rand.Next(0, 255);
            var g = rand.Next(0, 255);
            var b = rand.Next(0, 255);

            return new { r, g, b };
        }

        private string GetRandomColorHex()
        {
            var r = rand.Next(0, 255);
            var g = rand.Next(0, 255);
            var b = rand.Next(0, 255);

            return string.Concat("#",r.ToString("X2"),g.ToString("X2"),b.ToString("X2"));
        }
    }
}