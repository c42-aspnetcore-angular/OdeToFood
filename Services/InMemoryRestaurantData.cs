using System.Collections.Generic;
using System.Linq;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            this._restaurants = new List<Restaurant> {
                new Restaurant {Id = 1, Name = "Rishi's Continental"},
                new Restaurant {Id = 2, Name = "Prabha's Continental"},
                new Restaurant {Id = 3, Name = "Arun's Continental"}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        private IEnumerable<Restaurant> _restaurants;
    }
}