using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;

namespace OdeToFood.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private IGreetService _greetService;

        public GreeterViewComponent(IGreetService greetService)
        {
            _greetService = greetService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greetService.GetMessageOfTheDay();

            return View("Default", model);
        }
    }
}
