using DAL.TeacherRegistrationForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class RegistrationFormController : Controller
    {
        private readonly ITeacherRegistrationFormRepository _formRepo;
        private readonly IScheduledTimeSpanRepository _scheduleRepo;

        public RegistrationFormController(ITeacherRegistrationFormRepository formRepo,
            IScheduledTimeSpanRepository scheduleRepo)
        {
            _formRepo = formRepo;
            _scheduleRepo = scheduleRepo;
        }

        public ActionResult Index()
        {
            var viewModel = new TeacherRegistrationFormViewModel
            {
                Form = new TeacherRegistrationForm(),
                TimeSpans = Enumerable.Range(0, TIME_BLOCKS).Select(i => new ScheduledTimeSpan()).ToList()
            };
            return View(viewModel);

        }

        private const int TIME_BLOCKS = 140;
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherRegistrationForm form, IList<ScheduledTimeSpan> timeSpans)
        {
            if (ModelState.IsValid)
            {
                await _formRepo.CreateAsync(form);
                await _scheduleRepo.CreateSchedule(timeSpans, form);
                ViewBag.SuccessMessage = _formRepo.SuccessMessage(form);
                return View(nameof(Index), new TeacherRegistrationFormViewModel { SubmitSuccessfull = true });
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> CollectSchedule()
        {
            return View();
        }
    }
}
