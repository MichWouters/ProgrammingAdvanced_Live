using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WelcomeController: ControllerBase
    {
        // Dependencies
        private ILogger<WelcomeController> _logger;

        public WelcomeController(ILogger<WelcomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string SayHello()
        {
            _logger.LogInformation("Method SayHello was called");
            // Perform logic here

            _logger.LogInformation("Method complete");

            return "Hello Thomas More. Hope you had a good holiday";
        }

        [HttpGet("polite")]
        public string SayPoliteHello()
        {
            return "Good morning my liege. What is your command?";
        }

        [HttpGet("{naam}")]
        public string SayHelloWithName(string naam)
        {
            return $"Hello {naam}. How are things";
        }
    }
}
