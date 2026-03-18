using Microsoft.AspNetCore.Mvc;
using DBFirstEFinApp.Models;
using System.Security.Cryptography.Xml;
namespace DBFirstEFinApp.Controllers
{
    public class NorthWindController : Controller
    {
        public IActionResult SpainCustomers()
        {
            NorthWindContext cnt = new NorthWindContext();
            var spainCustomers = cnt.Customers.Where(x => x.Country == "Spain")
                .Select(x => new SpainCustomerViewModel
                {
                    Cid = x.CustomerId,
                    Cname = x.ContactName,
                    Comname = x.CompanyName
                }).ToList();
            return View(spainCustomers);
        }
        public IActionResult searchCustomer(string contactName)
        {
            NorthWindContext cnt = new NorthWindContext();
            var searchcust = from customer in cnt.Customers
                             where customer.ContactName == contactName
                             select new Customer
                             {
                                 ContactName = customer.ContactName,
                                 ContactTitle = customer.ContactTitle,
                                 CompanyName = customer.CompanyName
                             };
            var searchcust2 = cnt.Customers.Where(x => x.ContactName == contactName)
                .Select(x => new Customer
                {
                    ContactName = x.ContactName,
                    ContactTitle = x.ContactTitle,
                    CompanyName = x.CompanyName
                });
            var query2 = searchcust2.Single();
            var query1 = searchcust.Single();
            return View(query1);

        }
        public ActionResult ProductsInCategory(string categoryName)
        {
            NorthWindContext cnt = new NorthWindContext();
            var prodincat = cnt.Products.Where(x => x.Category.CategoryName == categoryName)
                .Select(x => new ProdCat
                {
                    prodname = x.ProductName,
                    catname = x.Category.CategoryName
                }).ToList();
            return View(prodincat);
        }
        public ActionResult OrderRange(string range)
        {
            NorthWindContext cnt = new NorthWindContext();
            var range1 = Convert.ToInt32(range);
            var custordcount = cnt.Customers.Where(x => x.Orders.Count > range1).
                Select(x => new Customer
                {
                    CustomerId = x.CustomerId,
                    ContactName = x.ContactName

                });
            return View(custordcount);

        }
        public IActionResult CustomerOrderDetails(string id)
        {
            NorthWindContext cnt = new NorthWindContext();

            var orders = cnt.Orders
                .Where(o => o.CustomerId == id)
                .Select(o => new Order
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate
                }).ToList();

            ViewBag.CustomerId = id;

            return View(orders);
        }
    }
}
