using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreetService _greetService;

        public HomeController(IRestaurantData restaurantData, IGreetService greetService)
        {
            this._restaurantData = restaurantData;
            this._greetService = greetService;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                MessageOfTheDay = _greetService.GetMessageOfTheDay()
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditModel model)
        {
            var restaurant = new Restaurant
            {
                Name = model.Name,
                Cuisine = model.Cuisine
            };

            var newRestaurant = _restaurantData.Add(restaurant);

            return RedirectToAction("Details", new { Id = newRestaurant.Id });
        }
    }
}