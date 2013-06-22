using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using signalR.Hubs;

namespace signalR.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IHubContext _hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalHub>();
        public static int counter;

        public ActionResult Index()
        {
            return RedirectToAction("Updater");
        }

        public ActionResult Updater()
        {
            return View();
        }

        public ActionResult HitMe()
        {
            counter++;
            _hubContext.Clients.All.addNewMessageToPage(new { name = "name", message=counter });
            return View();
        }
    }
}
