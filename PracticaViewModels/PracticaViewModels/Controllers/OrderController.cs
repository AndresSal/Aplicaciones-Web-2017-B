using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaViewModels.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            OrderModelContainer DB = new OrderModelContainer();
            return View(DB.OrderSet);
        }

        public ActionResult Create()
        {
            populateCustomer();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            OrderModelContainer DB = new OrderModelContainer();
            int currentCustomer = Convert.ToInt32(Request.Form["CustomerId"]);

            var customer = (from q in DB.CustomerSet
                            where q.CustomerId == currentCustomer
                            select q).FirstOrDefault();

            order.Customer = customer;
            DB.OrderSet.Add(order);
            DB.SaveChanges();

            return RedirectToAction("Index");
        }

        public void populateCustomer(object selectCustomer = null)
        {
            OrderModelContainer DB = new OrderModelContainer();

            var customerQuery = from d in DB.CustomerSet
                                orderby d.CustomerName
                                select d;
            ViewBag.CustomerId = new SelectList(customerQuery,"CustomerId","CustomerName",selectCustomer);
        }



    }
}