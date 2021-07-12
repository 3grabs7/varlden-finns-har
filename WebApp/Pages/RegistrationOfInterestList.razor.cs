using DAL.Matching;
using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public partial class RegistrationOfInterestList : ComponentBase
    {
        private IEnumerable<RegistrationOfInterest> _registrations { get; set; }
        private RegistrationOfInterest _selectedRegistration { get; set; }

        private bool _isMatchLoaded { get; set; } = false;
        private MatchingOptions _matchOptions { get; set; }
        private IEnumerable<RegistrationOfInterest> _matches { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _registrations = await RegistrationsService.GetAllAsync();
            _matchOptions = new();
        }

        private async Task Match()
        {
            _isMatchLoaded = true;
            _matches = await MatchService.MatchRegistrationAsync(_matchOptions, _registrations, _selectedRegistration);
        }
    }
}
