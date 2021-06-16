using DAL.Registration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class RegistrationOfInterestController : Controller
    {
        private readonly IRegistrationOfInterestRepository _formRepo;
        private readonly IAvailableTimeSpanRepository _scheduleRepo;

        public RegistrationOfInterestController(IRegistrationOfInterestRepository formRepo,
            IAvailableTimeSpanRepository scheduleRepo)
        {
            _formRepo = formRepo;
            _scheduleRepo = scheduleRepo;
        }

        private const int TIME_BLOCKS = 140;
        public ActionResult Form()
        {
            var viewModel = new RegistrationOfInterestViewModel
            {
                Form = new RegistrationOfInterest(),
                TimeSpans = Enumerable.Range(0, TIME_BLOCKS).Select(i => new AvailableTimeSpan()).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegistrationOfInterest form, IList<AvailableTimeSpan> timeSpans)
        {
            if (ModelState.IsValid)
            {
                await _formRepo.CreateAsync(form);
                await _scheduleRepo.CreateSchedule(timeSpans, form);
                ViewBag.SuccessMessage = _formRepo.SuccessMessage(form);
                return View(nameof(Form), new RegistrationOfInterestViewModel { SubmitSuccessfull = true });
            }

            return RedirectToAction(nameof(Form));
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

        public async Task<ActionResult> Match(int? id, bool isprocessing)
        {
            if (id != null)
            {
                // return not found osv
            }


            return View();
        }


    }
}
