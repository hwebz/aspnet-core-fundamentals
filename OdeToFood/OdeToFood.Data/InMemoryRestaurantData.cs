using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Domino's Pizza", Location = "Maryland", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 2, Name = "Kayak", Location = "Washington DC", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 3, Name = "US's Vegetables", Location = "New Zeland", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 4, Name = "Spagetti", Location = "Vietnam", Cuisine = CuisineType.None}
            };
        }

        public Restaurant Add(Restaurant restaurantData)
        {
            restaurantData.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurantData);
            return restaurantData;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count;
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = GetById(updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
    }
}
