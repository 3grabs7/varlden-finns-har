using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;

namespace WebApp.Pages
{
    public partial class RegistrationForm : ComponentBase
    {
        private RegistrationOfInterest _form = new();
        private Address _adress = new();
        private IEnumerable<Municipality> _municipalities { get; set; }
        private IEnumerable<IGrouping<SchoolForm, Subject>> _subjects { get; set; }
        private IEnumerable<Week> _weeks { get; set; }
        private IEnumerable<RegistrationSchedule> _timeSpans { get; set; }
        public IEnumerable<Subject> _selectedSubjects { get; set; }
        public IEnumerable<Week> _selectedWeeks { get; set; }
        private bool SubmitSuccessfull { get; set; }
        private string SuccessMessage { get; set; }

        // Step Validation
        private bool _isStepOneValidated { get; set; } = false;
        private bool _isStepTwoValidated { get; set; } = false;
        private bool _isStepThreeValidated { get; set; } = false;
        private bool _isStepFourValidated { get; set; } = false;
        private List<string> _steps = new()
        {
            "Lärare/Skola",
            "Elevgrupp",
            "Mötesval",
            "Tider",
            "Verifiering"
        };
        private string _selectedStep = "Lärare/Skola";
        private int _selectedStepIndex = 0;
        public int SelectedStepIndex
        {
            get { return _selectedStepIndex; }
            set
            {
                if (_selectedStepIndex < 1)
                    _selectedStepIndex = 0;
                else
                    _selectedStepIndex = value;
                OnSelectedStepChanged(_selectedStepIndex);
            }
        }

        // Hard coded validation
        // !!! TODO !!!
        // how do you get the validation attributes from model
        // to run and validate outside form?? 
        // !!! TODO !!!
        // Make this a method/fields in registration form service
        private void ValidateSteps()
        {
            _isStepOneValidated = _form.FirstName != default &&
                _form.LastName != default &&
                _form.Email != default &&
                _form.PhoneNumber != default &&
                _form.School != default &&
                _adress.StreetAdress != default &&
                _adress.PostalCode != default &&
                _form.MunicipalityRefId != default;

            _isStepTwoValidated = _form.Grade != default &&
                _subjects.SelectMany(x => x)
                    .Any(s => s.IsMarked);

            _isStepThreeValidated = _weeks.Any(w => w.IsMarked) &&
                _form.Theme != default;

            _isStepFourValidated = _timeSpans.Any(ts => ts.IsMarked);
        }

        // Change steps with steps component
        private Task OnSelectedStepChanged(string name)
        {
            ValidateSteps();
            _selectedStep = name;
            return Task.CompletedTask;
        }

        // Change steps with prev/next buttons
        private Task OnSelectedStepChanged(int index)
        {
            _selectedStep = _steps[index];
            return Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            _municipalities = await FormService.GetMunicipalitiesAsync();
            _subjects = await FormService.GetSubjectsAsync();
            _weeks = await FormService.GetWeeksAsync();
            _timeSpans = await ScheduleService.LoadScheduleAsync();
        }

        public async Task SubmitForm()
        {
            _form
                .AppendAdress(_adress)
                .AppendSubjects(_subjects
                    .First(g => g.Key == _form.SchoolForm)
                    .Where(s => s.IsMarked)
                )
                .AppendWeeks(_weeks.Where(w => w.IsMarked));

            // Format before adding to database
            // Do this with attribute magic in model later
            _form.PhoneNumber = $"0{_form.PhoneNumber}";

            // Submit registration
            await FormService.CreateRegistrationFormAsync(_form);

            SuccessMessage = $"Välkommen {_form.FirstName}! Tack för ditt visade intresse, vi kommer höra av oss med mer information.";
            SubmitSuccessfull = true;
        }

    }
}
