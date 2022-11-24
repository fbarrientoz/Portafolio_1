using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portafolio_1.Controllers
{
    public class PortafolioController : Controller
    {
        // GET: Portafolio
        public ActionResult Index()
        {
            return View();
        }
    }
}