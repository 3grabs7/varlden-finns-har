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

        public RegistrationFormController(ITeacherRegistrationFormRepository formRepo)
        {
            _formRepo = formRepo;
        }

        public ActionResult Index()
        {
            var viewModel = new TeacherRegistrationFormViewModel { Form = new TeacherRegistrationForm() };
            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherRegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                await _formRepo.CreateAsync(form);
                ViewBag.SuccessMessage = _formRepo.SuccessMessage(form);
                return View(nameof(Index), new TeacherRegistrationFormViewModel { SubmitSuccessfull = true });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
