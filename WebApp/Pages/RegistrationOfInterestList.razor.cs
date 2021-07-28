using Blazorise;
using DAL.Matching;
using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public partial class RegistrationOfInterestList : ComponentBase
    {
        private IEnumerable<RegistrationOfInterest> _registrations { get; set; }
        private RegistrationOfInterest _selectedRegistration { get; set; }
        protected RegistrationOfInterest SelectedRegistration
        {
            get { return _selectedRegistration; }
            set
            {
                _matchOptions.SetAllToFalse();
                _isMatchLoaded = false;
                _matches = null;
                _selectedRegistration = value;
            }
        }

        private bool _isMatchLoaded { get; set; } = false;
        private MatchingOptions _matchOptions { get; set; }
        private IEnumerable<RegistrationOfInterest> _matches { get; set; }
        private Modal matchesModal;

        protected override async Task OnInitializedAsync()
        {
            _registrations = await RegistrationsService.GetAllAsync();
            _matchOptions = new();


            // show modal during testing
            // vvvvvvvvvvvvvvvvvvvvvvvvv
            //_selectedRegistration = _registrations.Last();
            //matchesModal.Show();
            //_isMatchLoaded = true;
        }

        private async Task Match()
        {
            _isMatchLoaded = true;
            _matches = await MatchService.MatchRegistrationAsync(_matchOptions, _registrations, _selectedRegistration);
            matchesModal.Show();
        }

        private void HideModal()
        {
            matchesModal.Hide();
        }

        private void GoToDetails(int id)
        {
            NavigationManager.NavigateTo($"{nameof(RegistrationDetails)}/{id}");
        }



    }
}
