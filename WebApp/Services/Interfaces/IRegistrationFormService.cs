using DAL.Registration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IRegistrationFormService
    {
        Task CreateRegistrationFormAsync(RegistrationOfInterest form);
        Task<IEnumerable<Municipality>> GetMunicipalitiesAsync();
        Task<IEnumerable<IGrouping<SchoolForm, Subject>>> GetSubjectsAsync();
    }
}
