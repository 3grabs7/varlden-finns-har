using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RegistrationOfInterestController : Controller
    {
        private readonly IRegistrationOfInterestService _formRepo;

        public RegistrationOfInterestController(IRegistrationOfInterestService formRepo,
            IScheduleService scheduleRepo,
            IStaticEntitiesService staticEntitiesService)
        {
            _formRepo = formRepo;
        }

        public async Task<ActionResult> Form()
        {
            return View();
        }

        public async Task<ActionResult> List(int currentpage = 1, string sortby = null)
        {
            var viewModel = new RegistrationOfInterestViewModel
            {
                Registrations = await _formRepo.GetPaginatedResult(currentpage, PaginationBase.PAGE_SIZE, sortby),
                Count = await _formRepo.GetCount(),
                CurrentPage = currentpage,
                SortBy = sortby
            };
            return View(viewModel);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
                return View();

            return View(await _formRepo.GetAsync((int)id));
        }
    }
}
