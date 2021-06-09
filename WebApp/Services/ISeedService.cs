using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface ISeedService
    {
        Task ResetAsync();
        Task AddTeacherRegistrationForm(int count);
    }
}
