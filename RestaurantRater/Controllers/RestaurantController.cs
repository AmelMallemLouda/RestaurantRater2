using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        //we need to do is access our stored Restaurants.We can do this by adding a RestaurantDbContext instance to our class.
        //    We'll be adding one to the class as a field so all future methods can reference the same one.

        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {

            //We're reaching into the _db field, calling the Restaurants property which is the DbSet we created, and then converting it to a List with the .ToList() method call. That list is then passed into the View method which will then pass it to the View as the Model.
            return View(_db.Resaturants.ToList());
        }
    }
}