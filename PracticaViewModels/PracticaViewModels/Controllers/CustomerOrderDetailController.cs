using PracticaViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticaViewModels.Controllers
{
    public class CustomerOrderDetailController : Controller
    {
        // GET: CustomerOrderDetail
        public ActionResult Index()
        {
            OrderModelContainer DB = new OrderModelContainer();
            List<CustomerViewModel> CustomerVMList = new List<CustomerViewModel>();

            var customerList = (from cust in DB.CustomerSet
                                join ord in DB.OrderSet
                                on cust.CustomerId equals ord.Customer.CustomerId
                                select new
                                {

                                    cust.CustomerId,
                                    cust.CustomerName,
                                    cust.CustomerAddress,
                                    cust.CustomerMail,
                                    ord.OrderDate,
                                    ord.OrderPrice

                                }).ToList();
            foreach (var item in customerList)
            {
                CustomerViewModel cvm = new CustomerViewModel();
                cvm.CustomerId = item.CustomerId;
                cvm.CustomerName = item.CustomerName;
                cvm.CustomerAddress = item.CustomerAddress;
                cvm.CustomerMail = item.CustomerMail;
                cvm.OrderDate = item.OrderDate;
                cvm.OrderPrice = item.OrderPrice;

                CustomerVMList.Add(cvm);
            }

            return View(CustomerVMList);
        }
    }
}