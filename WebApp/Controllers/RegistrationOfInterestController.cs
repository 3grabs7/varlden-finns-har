using DAL.Registration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RegistrationOfInterestController : Controller
    {
        private readonly IRegistrationOfInterestRepository _formRepo;
        private readonly IAvailableTimeSpanRepository _scheduleRepo;
        private readonly StaticEntitiesService _staticEntitiesService;

        public RegistrationOfInterestController(IRegistrationOfInterestRepository formRepo,
            IAvailableTimeSpanRepository scheduleRepo,
            StaticEntitiesService staticEntitiesService)
        {
            _formRepo = formRepo;
            _scheduleRepo = scheduleRepo;
            _staticEntitiesService = staticEntitiesService;
        }

        private const int TIME_BLOCKS = 140;
        public async Task<ActionResult> Form()
        {
            var viewModel = new RegistrationFormViewModel
            {
                Form = new RegistrationOfInterest(),
                TimeSpans = Enumerable.Range(0, TIME_BLOCKS).Select(i => new AvailableTimeSpan()).ToList(),
                Municipalities = await _staticEntitiesService.GetMunicipalitiesAsync(),
                Subjects = await _staticEntitiesService.GetSubjectsAsync()

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegistrationOfInterest form,
            IList<AvailableTimeSpan> timeSpans,
            IList<Subject> subjects,
            Adress adress)
        {
            if (ModelState.IsValid)
            {
                await _formRepo.CreateAsync(form);
                await _scheduleRepo.CreateSchedule(timeSpans, form);
                await _formRepo.AddSubjects(subjects, form);
                await _formRepo.AddAdress(adress, form);
                ViewBag.SuccessMessage = _formRepo.SuccessMessage(form);
                return View(nameof(Form), new RegistrationFormViewModel { SubmitSuccessfull = true });
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
