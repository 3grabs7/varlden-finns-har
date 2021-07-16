﻿using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;

namespace WebApp.Pages
{
    public partial class RegistrationForm : ComponentBase
    {
        private RegistrationOfInterest _form = new();
        private Adress _adress = new();

        private IEnumerable<Municipality> Municipalities { get; set; }
        private IEnumerable<IGrouping<SchoolForm, Subject>> Subjects { get; set; }
        private IEnumerable<Week> Weeks { get; set; }
        private IEnumerable<RegistrationSchedule> TimeSpans { get; set; }

        private List<string> steps = new()
        {
            "Lärare/Skola",
            "Elevgrupp",
            "Mötesval",
            "Tider",
            "Verifiering"
        };
        private string selectedStep = "Om läraren/skolan";

        private Task OnSelectedStepChanged(string name)
        {
            selectedStep = name;
            return Task.CompletedTask;
        }

        public IEnumerable<Subject> _selectedSubjects { get; set; }
        public IEnumerable<Week> _selectedWeeks { get; set; }
        public IEnumerable<RegistrationSchedule> _timeSpans { get; set; }

        private bool SubmitSuccessfull { get; set; }
        private string SuccessMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Extension Approach
            Municipalities = await FormService.GetMunicipalitiesAsync();
            Subjects = await FormService.GetSubjectsAsync();
            Weeks = await FormService.GetWeeksAsync();

            // Service Approach
            TimeSpans = await ScheduleService.LoadScheduleAsync();
        }

        public async Task SubmitForm()
        {
            // Extension Approach
            _selectedSubjects = Subjects.First(g => g.Key == _form.SchoolForm).Where(s => s.IsMarked);
            _selectedWeeks = Weeks.Where(w => w.IsMarked);
            _form
                .AppendAdress(_adress)
                .AppendSubjects(_selectedSubjects)
                .AppendWeeks(_selectedWeeks);

            // Service Approach
            await ScheduleService.CreateScheduleAsync(_timeSpans, _form);

            // Format before adding to database
            _form.PhoneNumber = $"0{_form.PhoneNumber}";

            // Submit registration
            await FormService.CreateRegistrationFormAsync(_form);

            SuccessMessage = $"Välkommen {_form.FirstName}! Tack för ditt visade intresse, vi kommer höra av oss med mer information.";
            SubmitSuccessfull = true;
        }

    }
}
