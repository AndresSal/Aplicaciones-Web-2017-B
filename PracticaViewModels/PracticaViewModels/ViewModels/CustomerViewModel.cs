using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaViewModels.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerMail { get; set; }
        public string OrderDate { get; set; }
        public string OrderPrice { get; set; }

    }
}