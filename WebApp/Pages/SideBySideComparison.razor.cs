using DAL.Registration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class SideBySideComparison : ComponentBase
    {
        private readonly IRegistrationOfInterestService _registrationService;
        public SideBySideComparison(IRegistrationOfInterestService registrationService)
        {
            _registrationService = registrationService;
        }

        public string ComparisonParameter { get; set; }
        private RegistrationOfInterest _registration;
        private RegistrationOfInterest _registrationComparison;

        protected async override Task OnInitializedAsync()
        {
            var registrationIds = ComparisonParameter.Split('-').Select(x => Convert.ToInt32(x)).ToList();

            _registration = await _registrationService.GetAsync(registrationIds[0]);
            _registrationComparison = await _registrationService.GetAsync(registrationIds[1]);

        }

    }
}
