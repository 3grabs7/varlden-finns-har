using DAL.TeacherRegistrationForm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Repositories
{
    public interface ITeacherRegistrationFormRepository
    {
        Task<TeacherRegistrationForm> GetAsync(int id);
        Task<IEnumerable<TeacherRegistrationForm>> GetAllAsync();
        Task<IEnumerable<TeacherRegistrationForm>> GetRangeAsync(int count);
        Task<TeacherRegistrationForm> CreateAsync(TeacherRegistrationForm form);
        Task<TeacherRegistrationForm> EditAsync(TeacherRegistrationForm form);
        Task DeleteAsync(TeacherRegistrationForm form);
        Task DeleteAsync(int id);

        string SuccessMessage(TeacherRegistrationForm form);
    }
}
