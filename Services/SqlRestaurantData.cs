using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);

            _dbContext.SaveChanges();

            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            _dbContext.Attach(restaurant).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
    }
}
