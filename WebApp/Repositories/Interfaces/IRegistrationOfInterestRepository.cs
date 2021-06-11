using DAL.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Repositories
{
    public interface IRegistrationOfInterestRepository : IPaginationService<RegistrationOfInterest>
    {
        Task<RegistrationOfInterest> GetAsync(int id);
        Task<IEnumerable<RegistrationOfInterest>> GetAllAsync();
        Task<IEnumerable<RegistrationOfInterest>> GetRangeAsync(int count);
        Task<RegistrationOfInterest> CreateAsync(RegistrationOfInterest form);
        Task<RegistrationOfInterest> EditAsync(RegistrationOfInterest form);
        Task DeleteAsync(RegistrationOfInterest form);
        Task DeleteAsync(int id);

        string SuccessMessage(RegistrationOfInterest form);
    }
}
