namespace OdeToFood.Services
{
    public class GreetService : IGreetService
    {
        public string GetMessageOfTheDay()
        {
            return "Hello from Ode To Food!";
        }
    }

    public interface IGreetService
    {
        string GetMessageOfTheDay();
    }
}