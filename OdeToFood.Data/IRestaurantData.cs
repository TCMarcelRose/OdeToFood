using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

    }

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

        public IEnumerable<Restaurant> GetAll()
        {

            return from x in restaurants
                   orderby x.Name
                   select x;

        }
    }
}
