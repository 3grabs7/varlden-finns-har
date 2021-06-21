using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;

namespace WebApp.Components
{
    public partial class RegistrationForm : ComponentBase
    {
        private RegistrationOfInterest _form = new();
        private Adress _adress = new();
        private IEnumerable<Municipality> Municipalities { get; set; }
        private IEnumerable<IGrouping<SchoolForm, Subject>> Subjects { get; set; }
        public IEnumerable<Subject> _selectedSubjects { get; set; }
        public List<AvailableTimeSpan> TimeSpans { get; set; }
        private bool SubmitSuccessfull { get; set; }
        private string SuccessMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Municipalities = await FormService.GetMunicipalitiesAsync();
            Subjects = await FormService.GetSubjectsAsync();
        }

        public async Task SubmitForm()
        {
            _selectedSubjects = Subjects.First(g => g.Key == _form.SchoolForm).Where(s => s.IsMarked);

            _form.AppendAdress(_adress).AppendSubjects(_selectedSubjects);

            await FormService.CreateRegistrationFormAsync(_form);

            SuccessMessage = $"Välkommen {_form.FirstName}! Tack för ditt visade intresse, vi kommer höra av oss med mer information.";
            SubmitSuccessfull = true;
        }

        private void UpdateSubjectList(int id, SchoolForm schoolForm)
        {
            var subject = Subjects.First(g => g.Key == schoolForm).First(s => s.Id == id);
            subject.IsMarked = !subject.IsMarked;
        }
    }
}
