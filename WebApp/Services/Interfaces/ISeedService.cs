using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface ISeedService
    {
        Task ResetAsync();
        Task AddTeacherRegistrationForm(int count);
        Task AddTimeSpanToTeacherRegistrationForm(int count);
        Task AddSubjects();
        Task AddMunicipality();
        Task AddWeeks(int? year);
    }
}
