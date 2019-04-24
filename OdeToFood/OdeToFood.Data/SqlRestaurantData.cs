using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            Db = db;
        }

        public OdeToFoodDbContext Db { get; }

        public Restaurant Add(Restaurant restaurantData)
        {
            Db.Restaurants.Add(restaurantData);
            return restaurantData;
        }

        public int Commit()
        {
            return Db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                Db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return Db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return Db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in Db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = Db.Restaurants.Attach(updatedRestaurant); // tell EF to track updatedRestaurant has modified state.
            restaurant.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
