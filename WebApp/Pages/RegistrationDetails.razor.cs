using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class RegistrationDetails : ComponentBase
    {
        private readonly IRegistrationOfInterestService _registrationService;
        public RegistrationDetails(IRegistrationOfInterestService registrationService)
        {
            _registrationService = registrationService;
        }

        [Parameter] public string Id { get; set; }
        private RegistrationOfInterest _registration { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (Int32.TryParse(Id, out int id))
            {
                _registration = await _registrationService.GetAsync(id);
            }
        }
    }
}
