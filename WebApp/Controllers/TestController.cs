using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        private readonly ISeedService _seed;

        public TestController(ISeedService seed)
        {
            _seed = seed;
        }

        public async Task<IActionResult> Index()
        {
            await _seed.ResetAsync();
            await _seed.AddTeacherRegistrationForm(1);
            await _seed.AddTimeSpanToTeacherRegistrationForm(5);
            return View();
        }
    }
}
