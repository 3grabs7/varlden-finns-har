using DAL.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Services
{
    public interface IRegistrationOfInterestService : IPaginationService<RegistrationOfInterest>
    {
        Task<RegistrationOfInterest> GetAsync(int id);
        Task<IEnumerable<RegistrationOfInterest>> GetAllAsync();
        Task<IEnumerable<RegistrationOfInterest>> GetRangeAsync(int count);
        Task<RegistrationOfInterest> CreateAsync(RegistrationOfInterest form);
        Task AddSubjects(IEnumerable<Subject> subjects, RegistrationOfInterest form);
        Task AddAdress(Adress adress, RegistrationOfInterest form);
        Task<RegistrationOfInterest> EditAsync(RegistrationOfInterest form);
        Task DeleteAsync(RegistrationOfInterest form);
        Task DeleteAsync(int id);

        string SuccessMessage(RegistrationOfInterest form);
    }
}
