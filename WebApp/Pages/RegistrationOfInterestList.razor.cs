using Blazorise;
using DAL.Matching;
using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class RegistrationOfInterestList : ComponentBase
    {
        private readonly IRegistrationOfInterestService _registrationsService;
        private readonly IMatchService _matchService;
        private readonly NavigationManager _navigationManager;
        public RegistrationOfInterestList(IRegistrationOfInterestService registrationsService,
            IMatchService matchService,
            NavigationManager navigationManager)
        {
            _registrationsService = registrationsService;
            _matchService = matchService;
            _navigationManager = navigationManager;
        }

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
        private Modal _matchesModal;

        protected override async Task OnInitializedAsync()
        {
            _registrations = await _registrationsService.GetAllAsync();
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
            _matches = await _matchService.MatchRegistrationAsync(_matchOptions, _registrations, _selectedRegistration);
            _matchesModal.Show();
        }

        private void HideModal()
        {
            _matchesModal.Hide();
        }

        private void GoToDetails(int id)
        {
            _navigationManager.NavigateTo($"{nameof(RegistrationDetails)}/{id}");
        }

        private void GoToSideBySideComparison(int id, int compareId)
        {
            _navigationManager.NavigateTo($"{nameof(SideBySideComparison)}/{id}-{compareId}");
        }

    }
}
