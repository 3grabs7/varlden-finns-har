using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        private readonly ISeedService _seed;
        private readonly IRegistrationOfInterestService _formRepo;

        public TestController(ISeedService seed,
            IRegistrationOfInterestService formRepo)
        {
            _seed = seed;
            _formRepo = formRepo;
        }

        public async Task<IActionResult> Index(string welcomeTag)
        {
            if (!String.IsNullOrEmpty(welcomeTag))
            {
                var viewModel = new TestViewModel
                {
                    WelcomeTag = welcomeTag
                };
                return View(viewModel);
            }
            return View();
        }

        public async Task<IActionResult> Seed()
        {
            await _seed.ResetAsync();
            await _seed.AddTeacherRegistrationForm(32);
            await _seed.AddTimeSpanToTeacherRegistrationForm(5);
            await _seed.AddSubjects();
            await _seed.AddMunicipality();
            return RedirectToAction(nameof(Index), new { welcomeTag = "Loopy?" });
        }


    }
}
