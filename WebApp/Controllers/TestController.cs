using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        private readonly ISeedService _seed;
        private readonly ITeacherRegistrationFormRepository _formRepo;

        public TestController(ISeedService seed,
            ITeacherRegistrationFormRepository formRepo)
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
            await _seed.AddTeacherRegistrationForm(1);
            await _seed.AddTimeSpanToTeacherRegistrationForm(5);
            return RedirectToAction(nameof(Index), new { welcomeTag = "Loopy?" });
        }


    }
}
