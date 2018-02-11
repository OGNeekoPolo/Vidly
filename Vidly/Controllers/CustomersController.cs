using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "John Smith", Id = 1},
            new Customer { Name = "Mary Williams", Id = 2}
        };



        // GET: Customers
        public ActionResult Index()
        {

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("customers/details/{id}")]
        public ActionResult Details(int id)
        {

            foreach (var customer in customers)
            {
                if (id == customer.Id)
                {
                    var viewCustomer = new Customer
                    {
                        Name = customer.Name,
                        Id = customer.Id
                    };

                    return View(viewCustomer);

                }
            }

            return HttpNotFound("Customer does not exist");

        }
    }
}