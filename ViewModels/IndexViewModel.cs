using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set;}
        public string MessageOfTheDay { get; set; }
    }
}