using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
    }

    public class RestaurantDbContext:DbContext
    {
        //DbSet is a collection of entities that can be queried from the database. it will act as a way to access all Restaurant objects that we set in our database
        //Entity is word used to describe objects that are being stored into the database
        //Connection string is used as a connection between our class and the database
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}