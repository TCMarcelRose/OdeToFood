using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        
        public InMemoryRestaurantData()
        {

            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Cuisine = CuisineType.Italian, Location = "Elze", Name = "Marcello´s Pizza"},
                new Restaurant { Id = 2, Cuisine = CuisineType.Chinese, Location = "Hamburg", Name = "Der wilde Schinezze"},
                new Restaurant { Id = 3, Cuisine = CuisineType.Italian, Location = "Dortmund", Name = "Don Frankos"},
                new Restaurant { Id = 4, Cuisine = CuisineType.Mexican, Location = "Essen", Name = "Speedy Gonzales Fastfood"},
                new Restaurant { Id = 5, Cuisine = CuisineType.None, Location = "Lamspringe", Name = "German Sausage"},
                new Restaurant { Id = 6, Cuisine = CuisineType.Indian, Location = "Harsum", Name = "Ghandis"},
                new Restaurant { Id = 7, Cuisine = CuisineType.Italian, Location = "Hildesheim", Name = "Canneloni Express"}
            };

        }

        public Restaurant GetById(int Id)
        {
            return restaurants.SingleOrDefault(r => r.Id == Id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {

            return from x in restaurants
                   where string.IsNullOrEmpty(name) || x.Name.StartsWith(name)
                   orderby x.Name
                   select x;

        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            return newRestaurant;
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
    }
}
