using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            return View(_db.Restaurants.ToList());
        }

        // Get : Restaurant/ Create
        //A GET request is set to just get the information
        public ActionResult Create()
        {
            return View();
        }

        //Post Restaurant Rater/ Create
        //HttpPost is an annotation that specifies that this method is going to be a POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        //ValidateAntiForgeryToken is another annotation that allows the server to match up with the AntiForgeryToken that we have set in the Create form.
        public ActionResult Create (Restaurant restaurant)
        {
            //ModelState.IsValid is going to check the model given to the method.So if restaurant (the parameter) has any requirements that are not met, it would check the ModelState and IsValid would be false and not save the changes
            //If the ModelState isn't valid, we see it return to the View() but we are also passing restaurant back to the view. We do that by putting return View(restaurant); the same way we passed the _db.Restaurants.ToList() in the Index method.
           //If the ModelState.IsValid is true, then we go in and add and save the changes and then return a new method called RedirectToAction("Index"); which takes the string name of another action(the Index method in this case) and redirects the code to that action.So here we're seeing the return kick us over to the Index action which takes us to the Index view.
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //Get :Resturant/Delete/{id}
        // ctrl . means we're using some code we know exists that we had to just import.
        public ActionResult Delete (int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Restaurant restaurant = _db.Restaurants.Find(id);

            if(restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        //Post :Restaurant /Delete /{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get :Restaurant/Edit/{id}

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //Post :Restaurant/Edit/{id}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //get:Restaurant/Details/(ID)
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
    }
}