using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    // represents the @model for the Razor page for
    // which this is the code behind file
    public class GreetingModel : PageModel
    {
        private IGreetService _greetService;

        public string CurrentGreeting { get; set; }

        public GreetingModel(IGreetService greetService)
        {
            _greetService = greetService;
        }
        public void OnGet(string name)
        {
            CurrentGreeting = $"{name} says: {_greetService.GetMessageOfTheDay()} - from Razor Code behind!";
        }
    }
}