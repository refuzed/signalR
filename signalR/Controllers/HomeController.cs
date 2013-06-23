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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Image1()
        {
            return View();
        }

        public ActionResult Image2()
        {
            return View();
        }

        public ActionResult Image3()
        {
            return View();
        }
    }
}
