using DAL.TeacherRegistrationForm;
using System.Threading.Tasks;
using WebApp.Data;

namespace WebApp.Services
{
    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext _context;
        public SeedService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ResetAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task AddTeacherRegistrationForm(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var form = new TeacherRegistrationForm
                {
                    Name = "Lärare Lärarsson",
                    Email = "1@2.se",
                    PhoneNumber = "112",
                    School = "HeltOk-Skolan",
                    Municipality = "Göteborg",
                    SchoolForm = SchoolForm.Grundskola,
                    TeachersSubjects = "Matte, Svenska, Engelska",
                    Grade = 9,
                    StudentGroupSubjects = "Matte",
                    AdditionalSubjectsOfInterest = "Matte, Historia",
                    MeetingType = MeetingType.Digitalt
                };
                await _context.AddAsync(form);
            }

            await _context.SaveChangesAsync();
        }
    }
}
