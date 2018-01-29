using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaViewModels.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            OrderModelContainer DB = new OrderModelContainer();
            return View(DB.CustomerSet);
        }
    }
}